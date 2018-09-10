using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RegistrarServices
{
    partial class MajorExamScheduleCreate
    {
        #region Class Properties Declarations
        private Boolean _hasCreated = false;
        public Boolean HasCreated
        {
            get { return _hasCreated; }
        }
        #endregion

        #region Class Constructor
        public MajorExamScheduleCreate(CommonExchange.SysAccess userInfo, MajorExamScheduleLogic majorExamScheduleMananger)
            : base(userInfo, majorExamScheduleMananger)
        {
            this.InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnCreate.Click += new EventHandler(btnCreateClick);
        }
        #endregion

        #region Class Event Void Procedures
        //####################################################CLASS MajorExamScheduleCreate EVENTS###############################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            base.ClassLoad(sender, e);
        }//---------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasCreated)
            {
                String strMsg = "Are you sure you want to cancel the creation of a new examination schedule information?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//--------------------------
        //####################################################END CLASS MajorExamScheduleCreate EVENTS###############################################

        //####################################################COMBOBOX cboYear EVENTS###############################################
        //event is raised when the selected index is changed
        protected override void cboYearSelectedIndexChanged(object sender, EventArgs e)
        {
            base.cboYearSelectedIndexChanged(sender, e);

            this.IsRecordLocked(this.lblStatus, this.btnCreate, null, true);
        }//---------------------------
        //####################################################END COMBOBOX cboYear EVENTS###############################################

        //####################################################COMBOBOX cboSemester EVENTS###############################################
        //event is raised when the selected index is changed
        protected override void cboSemesterSelectedIndexChanged(object sender, EventArgs e)
        {
            base.cboSemesterSelectedIndexChanged(sender, e);

            this.IsRecordLocked(this.lblStatus, this.btnCreate, null, true);
        }//-------------------------
        //####################################################END COMBOBOX cboSemester EVENTS###############################################

        //#########################################BUTTON btnClose EVENTS###########################################################
        //event is raised when the control is clicked
        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }//----------------------------------
        //#########################################END BUTTON btnClose EVENTS###########################################################

        //#########################################BUTTON btnCreate EVENTS###########################################################
        //event is raised when the control is clicked
        private void btnCreateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to create the new examination schedule?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Create", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The new examination schedule has been successfully created.";

                        this.Cursor = Cursors.WaitCursor;

                        _majorExamScheduleManager.InsertMajorExamSchedule(_userInfo, _majorExamScheduleInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasCreated = true;

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Creating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }//-----------------------------------
        //#########################################END BUTTON btnCreate EVENTS###########################################################   
       
        #endregion
    }
}
