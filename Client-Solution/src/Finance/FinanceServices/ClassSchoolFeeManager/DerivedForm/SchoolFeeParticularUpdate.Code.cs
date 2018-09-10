using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class SchoolFeeParticularUpdate
    {
        #region Class General Variable Declaration
        private CommonExchange.SchoolFeeParticular _particularInfoTemp;
        #endregion

        #region Class Properties Declaration
        private Boolean _hasUpDated = false;
        public Boolean HasUpDated
        {
            get { return _hasUpDated; }
        }
        #endregion

        #region Class Constructors
        public SchoolFeeParticularUpdate(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeParticular particularInfo,
            SchoolFeeLogic schoolFeeManager)
            : base(userInfo, schoolFeeManager)
        {
            this.InitializeComponent();

            _particularInfo = particularInfo;
            _particularInfoTemp = (CommonExchange.SchoolFeeParticular)particularInfo.Clone();

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
            this.btnDelete.Click += new EventHandler(btnDeleteClick);
        }
        #endregion

        #region Class Event Void Procedures
        //########################################CLASS ClassroomUpdate EVENTS####################################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            _schoolFeeManager.InitializeFeeCategoryCombo(this.cboFeeCategory, _particularInfo.SchoolFeeCategoryInfo.FeeCategoryId);

            this.chkIsOptional.CheckedChanged -= new EventHandler(chkIsOptionalCheckedChanged);
            this.chkIsOfficesAccess.CheckedChanged -= new EventHandler(chkIsOfficesAccessCheckedChanged);
            this.chkIsGraduationFee.CheckedChanged -= new EventHandler(chkIsGraduationFeeCheckedChanged);
            this.chkEntryLevelIncluded.CheckedChanged -= new EventHandler(chkEntryLevelIncludedCheckedChanged);

            this.txtParticularDescription.Text = _particularInfo.ParticularDescription;
            this.chkIsOfficesAccess.Checked = _particularInfo.IsOfficeAccess;
            this.chkIsOptional.Checked = _particularInfo.IsOptional;
            this.chkEntryLevelIncluded.Checked = _particularInfo.IsEntryLevelIncluded;
            this.chkIsGraduationFee.Checked = _particularInfo.IsGraduationFee;

            if (_particularInfo.IsOptional)
            {
                this.chkIsOptional.Enabled = this.chkEntryLevelIncluded.Enabled = this.chkIsGraduationFee.Enabled = false;
                this.chkIsOfficesAccess.Enabled = true;
            }
            else
            {
                this.chkIsOptional.Enabled = this.chkEntryLevelIncluded.Enabled = this.chkIsOfficesAccess.Enabled = this.chkIsGraduationFee.Enabled = false;
            }

            this.chkIsOptional.CheckedChanged += new EventHandler(chkIsOptionalCheckedChanged);
            this.chkIsOfficesAccess.CheckedChanged += new EventHandler(chkIsOfficesAccessCheckedChanged);
            this.chkIsGraduationFee.CheckedChanged += new EventHandler(chkIsGraduationFeeCheckedChanged);
            this.chkEntryLevelIncluded.CheckedChanged += new EventHandler(chkEntryLevelIncludedCheckedChanged);
        }//-------------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasUpDated && !_particularInfo.Equals(_particularInfoTemp))
            {
                String strMsg = "There has been changes made in the current School Fee Particular Information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";

                DialogResult msgResutl = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResutl == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//-----------------------------
        //########################################END CLASS ClassroomUpdate EVENTS####################################################

        //########################################BUTTON btnClose EVENTS####################################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//-----------------------------
        //########################################END BUTTON btnClose EVENTS####################################################

        //########################################BUTTON btnUpdate EVENTS####################################################
        //event is raised when the control is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to update the School Fee Particular?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The School Fee Particular has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _schoolFeeManager.UpdateSchoolFeeParticular(_userInfo, _particularInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpDated = true;

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
            }
        }//--------------------------------
        //########################################END BUTTON btnUpdate EVENTS####################################################

        //########################################BUTTON btnDelete EVENTS####################################################
        //event is raised when the control is clicked
        private void btnDeleteClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to delete the School Fee Particular?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The School Fee Particular has been successfully deleted.";

                        this.Cursor = Cursors.WaitCursor;

                        _schoolFeeManager.DeleteSchoolFeeParticular(_userInfo, _particularInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpDated = true;

                        this.Close();
                    }
                    else if (msgResult == DialogResult.Cancel)
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Deleting");
                }
            }
        }//----------------------------
        //########################################END BUTTON btnDelete EVENTS####################################################
        #endregion
    }
}
