using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FinanceServices
{
    partial class ParticularSearchOnTextBoxList
    {
        #region Class General Variable Declaration
        private CommonExchange.SysAccess _userInfo;
        private SchoolFeeLogic _schoolFeeManager;
        #endregion

        #region Class Constructos
        public ParticularSearchOnTextBoxList(CommonExchange.SysAccess userInfo, SchoolFeeLogic schoolFeeManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _schoolFeeManager = schoolFeeManager;

            this.pbxRefresh.Click += new EventHandler(pbxRefreshClick);
            this.lnkCreate.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkCreateLinkClicked);
        }       
        #endregion

        #region Class Event Void Procedures
        //####################################CLASS ParticularSearchOnTextBoxList EVENTS####################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.SetDataGridViewSource(_schoolFeeManager.FeeParticularTable);

            base.ClassLoad(sender, e);
        }//----------------------------
        //####################################END CLASS ParticularSearchOnTextBoxList EVENTS####################################

        //##################################TEXTBOX txtSearch EVENTS##########################################################
        //event is raised when the key is up
        protected override void txtSearchKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    this.SetDataGridViewSource(_schoolFeeManager.GetSearchedSchoolFeeParticular(((TextBox)sender).Text));
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error School Fee Particular List");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }

            }

            base.txtSearchKeyUp(sender, e);
        } //-------------------------
        //#################################END TEXTBOX txtSearch EVENTS#######################################################

        //##################################PICTUREBOX pbxRefresh EVENTS######################################################
        //event is raised when the picture box is clicked
        private void pbxRefreshClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.txtSearch.Clear();

            this.Cursor = Cursors.Arrow;
        } //----------------------------
        //##############################END PICTUREBOX pbxRefresh EVENTS######################################################

        //##################################LINKLABEL lnkCreate EVENTS######################################################
        //event is raised when the control is clicked
        private void lnkCreateLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (SchoolFeeParticularCreate frmCreate = new SchoolFeeParticularCreate(_userInfo, _schoolFeeManager))
            {
                frmCreate.ShowDialog(this);

                if (frmCreate.HasCreated)
                {
                    this.Cursor = Cursors.WaitCursor;

                    this.SetDataGridViewSource(_schoolFeeManager.GetSearchedSchoolFeeParticular(RemoteClient.ProcStatic.TrimStartEndString(this.txtSearch.Text)));

                    this.Cursor = Cursors.Arrow;
                }
            }
        }//----------------------------
        //##################################END LINKLABEL lnkCreate EVENTS######################################################

        //##################################DATAGRIDVIEW dgvListDoubleClick EVENTS######################################################
        //event is raised when the control is double clicked
        protected override void dgvListDoubleClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_primaryId))
            {
                using (SchoolFeeParticularUpdate frmUpdate = new SchoolFeeParticularUpdate(_userInfo,
                    _schoolFeeManager.GetParticularInfoBySysId(_primaryId), _schoolFeeManager))
                {
                    frmUpdate.ShowDialog(this);

                    if (frmUpdate.HasUpDated)
                    {
                        this.SetDataGridViewSource(_schoolFeeManager.GetSearchedSchoolFeeParticular(RemoteClient.ProcStatic.TrimStartEndString(this.txtSearch.Text)));
                    }

                    this.Show();
                }
            }
        }//---------------------

        //event is raised when the key is pressed      
        protected override void dgvListKeyPress(object sender, KeyPressEventArgs e)
        {
            base.dgvListKeyPress(sender, e);

            if (!String.IsNullOrEmpty(_primaryId))
            {
                using (SchoolFeeParticularUpdate frmUpdate = new SchoolFeeParticularUpdate(_userInfo,
                    _schoolFeeManager.GetParticularInfoBySysId(_primaryId), _schoolFeeManager))
                {
                    frmUpdate.ShowDialog(this);

                    if (frmUpdate.HasUpDated)
                    {
                        this.SetDataGridViewSource(_schoolFeeManager.GetSearchedSchoolFeeParticular(_primaryId));
                    }

                    this.Show();
                }
            }
        }
        //##################################END DATAGRIDVIEW dgvListDoubleClick EVENTS######################################################
        #endregion
    }
}
