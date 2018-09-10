using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class ScholarshipUpdate
    {
        #region Class Data Member Declaration
        private CommonExchange.ScholarshipInformation _scholarshipInfoTemp;
        #endregion

        #region Class Properties Declarations
        private Boolean _hasUpdated = false;
        public Boolean HasUpdated
        {
            get { return _hasUpdated; }
        }
        #endregion

        #region Class Constructors
        public ScholarshipUpdate(CommonExchange.SysAccess userInfo, CommonExchange.ScholarshipInformation scholarshipInfo,
            ScholarshipLogic scholarshipManager)
            : base(userInfo, scholarshipManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _scholarshipManager = scholarshipManager;
            _scholarshipInfo = scholarshipInfo;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(ClassClosed);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnEdit.Click += new EventHandler(btnEditClick);
           
        }        
        #endregion

        #region Class Event Void Procedure
        //#####################################CLASS ScholarshipUpdate EVENTS########################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            
            _scholarshipManager.InitializeCourseGroupCombo(this.cboCourseGroup, _scholarshipInfo.CourseGroupInfo.CourseGroupId);
            _scholarshipManager.InitializeDepartmentCombo(this.cboDepartment, _scholarshipInfo.DepartmentInfo.DepartmentId);

            this.lblSystemId.Text = _scholarshipInfo.ScholarshipSysId;
            this.txtScholarship.Text = _scholarshipInfo.ScholarshipDescription;
            this.chkNonAcademic.Checked = _scholarshipInfo.IsNonAcademic;

            _scholarshipInfoTemp = (CommonExchange.ScholarshipInformation)_scholarshipInfo.Clone();
        }//----------------------

        //event is raised when the class is closing
        private void ClassClosed(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (!_hasUpdated && !_scholarshipInfo.Equals(_scholarshipInfoTemp))
            {
                String strMsg = "There has been changes made in the current scholarship information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
        //#####################################END CLASS ScholarshipUpdate EVENTS########################################

        //################################################BUTTON btnClose EVENTS####################################################
        //event is raised when btnClose is Clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//-----------------------
        //################################################END BUTTON btnClose EVENTS####################################################

        //################################################BUTTON btnEdit EVENTS####################################################
        //event is raised when btnUpdate is Clicked
        private void btnEditClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to update the scholarship information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The scholarship information has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _scholarshipManager.UpdateScholarshipInformation(_userInfo, _scholarshipInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdated = true;

                        this.Close();
                    }
                    else if (msgResult == DialogResult.Cancel)
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Updating");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        }//--------------------
        //################################################END BUTTON btnEdit EVENTS####################################################
        #endregion
    }
}
