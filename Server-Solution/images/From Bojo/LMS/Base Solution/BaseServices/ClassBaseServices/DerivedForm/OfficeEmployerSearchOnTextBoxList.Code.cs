using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BaseServices
{
    partial class OfficeEmployerSearchOnTextBoxList
    {
        #region Class Data Member Decleration
        private CommonExchange.SysAccess _userInfo;
        private BaseServicesLogic _baseServiceManager;
        #endregion

        #region Class Constructors
        public OfficeEmployerSearchOnTextBoxList(CommonExchange.SysAccess userInfo, BaseServicesLogic baseServicesManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _baseServiceManager = baseServicesManager;

            this.pbxRefresh.Click += new EventHandler(pbxRefreshClick);
            this.lnkCreateOfficeEmployer.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkCreateOfficeEmployerLinkClicked);
            this.lnkUpdateOfficeEmployer.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkUpdateOfficeEmployerLinkClicked);
        }
        #endregion

        #region Class Event Void Procedures
        //####################################CLASS PersonSearchOnTextBoxList EVENTS####################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.SetDataGridViewSource(_baseServiceManager.OfficeEmployerTable);

            base.ClassLoad(sender, e);
        }//-------------------
        //####################################END CLASS PersonSearchOnTextBoxList EVENTS####################################

        //##################################TEXTBOX txtSearch EVENTS##########################################################
        //event is raised when the key is up
        protected override void txtSearchKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    this.SetDataGridViewSource(_baseServiceManager.GetSearchedOfficeEmployerInformation(_userInfo, ((TextBox)sender).Text, false, true));
                }
                catch (Exception ex)
                {
                    ProcStatic.ShowErrorDialog(ex.Message, "Error Office/Employer Infomation List");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }

            base.txtSearchKeyUp(sender, e);
        }//-----------------------------------
        //##################################END TEXTBOX txtSearch EVENTS##########################################################

        //##################################PICTUREBOX pbxRefresh EVENTS######################################################
        //event is raised when the picture box is clicked
        private void pbxRefreshClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.SetDataGridViewSource(_baseServiceManager.OfficeEmployerTable);

            this.txtSearch.Clear();

            this.Cursor = Cursors.Arrow;
        }//---------------------------------
        //##################################END PICTUREBOX pbxRefresh EVENTS######################################################

        //##################################LINKLABEL lnkCreateOfficeEmployer EVENTS######################################################
        //event is raised when the  control is clicked
        private void lnkCreateOfficeEmployerLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            using (OfficeInformationCreate frmCreate = new OfficeInformationCreate(_userInfo, _baseServiceManager))
            {
                frmCreate.ShowDialog(this);

                if (frmCreate.HasCreated)
                {
                    this.SetDataGridViewSource(_baseServiceManager.GetSearchedOfficeEmployerInformation(_userInfo, this.txtSearch.Text, false, true));
                }
            }

            this.Cursor = Cursors.Arrow;
        }//--------------------------------
        //##################################END LINKLABEL lnkCreateOfficeEmployer EVENTS######################################################

        //##################################LINKLABEL lnkUpdateOfficeEmployer EVENTS######################################################
        //event is raised when the  control is clicked
        private void lnkUpdateOfficeEmployerLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (!String.IsNullOrEmpty(this.PrimaryId))
            {
                using (OfficeInformationUpdate frmUpdate = new OfficeInformationUpdate(_userInfo,
                    _baseServiceManager.GetOfficeEmployerInformationDetails(this.PrimaryId), _baseServiceManager))
                {
                    frmUpdate.ShowDialog(this);

                    if (frmUpdate.HasUpdated || frmUpdate.HasDeleted)
                    {
                        this.SetDataGridViewSource(_baseServiceManager.GetSearchedOfficeEmployerInformation(_userInfo, this.txtSearch.Text, false, true));
                    }
                }
            }

            this.Cursor = Cursors.Arrow;
        }//------------------------------
        //##################################END LINKLABEL lnkUpdateOfficeEmployer EVENTS######################################################
        #endregion
    }
}
