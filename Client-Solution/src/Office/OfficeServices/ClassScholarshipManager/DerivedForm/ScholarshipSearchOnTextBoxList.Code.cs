using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class ScholarshipSearchOnTextBoxList
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private ScholarshipLogic _scholarshipManager;
        #endregion

        #region Class Constructors
        public ScholarshipSearchOnTextBoxList(CommonExchange.SysAccess userInfo, ScholarshipLogic scholarshipManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _scholarshipManager = scholarshipManager;

            this.pbxRefresh.Click += new EventHandler(pbxRefreshClick);
            this.lnkCreate.Click += new EventHandler(lnkCreateClick);
        }

        
        #endregion

        #region Class Event Void Procedures
        //####################################CLASS PrerequisiteSearchOnTextboxList EVENTS####################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.SetDataGridViewSource(_scholarshipManager.ScholarshpTableFormat);

            base.ClassLoad(sender, e);
        }//-------------------------
        //####################################END CLASS PrerequisiteSearchOnTextboxList EVENTS####################################

        //##################################TEXTBOX txtSearch EVENTS##########################################################
        //event is raised when the key is up
        protected override void txtSearchKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    this.SetDataGridViewSource(_scholarshipManager.GetSearchedScholarshipInformation(((TextBox)sender).Text));
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Retrieving Scholarship List");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }

            base.txtSearchKeyUp(sender, e);
        }//--------------------
        //##################################END TEXTBOX txtSearch EVENTS##########################################################

        //##################################PICTUREBOX pbxRefresh EVENTS######################################################
        //event is raised when the picture box is clicked
        private void pbxRefreshClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.txtSearch.Clear();

            this.Cursor = Cursors.Arrow;
        }//-------------------
        //##################################END PICTUREBOX pbxRefresh EVENTS######################################################

        //##################################DATAGRIDVIEW dgvList EVENTS######################################################
        //event is raised when the control is double clicked
        protected override void dgvListDoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(this.PrimaryId))
                {
                    this.Cursor = Cursors.WaitCursor;

                    using (ScholarshipUpdate frmUpdate = new ScholarshipUpdate(_userInfo,
                        _scholarshipManager.GetDetailsScholarshipInformation(this.PrimaryId), _scholarshipManager))
                    {
                        frmUpdate.ShowDialog(this);

                        if (frmUpdate.HasUpdated)
                        {
                            this.txtSearch.Clear();

                            this.SetDataGridViewSource(_scholarshipManager.GetSearchedScholarshipInformation(String.Empty));
                        }
                    }

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }
        }//-------------------
        //##################################END DATAGRIDVIEW dgvList EVENTS######################################################

        //##################################LINKLABEL lnkCreate EVENTS######################################################
        //event is raised when the control is clicked
        private void lnkCreateClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (ScholarshipCreate frmCreate = new ScholarshipCreate(_userInfo, _scholarshipManager))
                {
                    frmCreate.ShowDialog(this);

                    if (frmCreate.HasCreated)
                    {
                        this.txtSearch.Clear();

                        this.SetDataGridViewSource(_scholarshipManager.GetSearchedScholarshipInformation(String.Empty));
                    }
                }

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }
        }//----------------------
        //##################################LINKLABEL lnkCreate EVENTS######################################################
        #endregion
    }
}
