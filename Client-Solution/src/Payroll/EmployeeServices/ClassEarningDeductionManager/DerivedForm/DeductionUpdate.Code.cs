using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EmployeeServices
{
    partial class DeductionUpdate
    {
        #region Class General Variable Declarations
        private CommonExchange.DeductionInformation _deductionTemp;
        private String _deductionId;
        #endregion

        #region Class Properties Declarations
        private Boolean _hasUpdated = false;
        public Boolean HasUpdated
        {
            get { return _hasUpdated; }
        }
        #endregion

        #region Class Constructor
        public DeductionUpdate(CommonExchange.SysAccess userInfo, DeductionLogic decManager, String deductionId)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _decManager = decManager;
            _deductionId = deductionId;

            this.Load += new EventHandler(ClassLoad);
            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnDone.Click += new EventHandler(btnDoneClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
        }
        
        #endregion

        #region Class Event Void Procedures

        //###########################################CLASS DeductionUpdate EVENTS###########################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _deductionInfo = new CommonExchange.DeductionInformation();
            _deductionTemp = new CommonExchange.DeductionInformation();

            this.InitializeControls();
        } //-----------------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasUpdated)
            {
                _deductionInfo.Description = RemoteClient.ProcStatic.TrimStartEndString(txtDescription.Text);

                if (!_deductionInfo.Equals(_deductionTemp))
                {
                    String strMsg = "There has been changes made in the current deduction information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
        } //---------------------------------
        //########################################END CLASS Deduction EVENTS#################################################################

        //#################################################BUTTON btnDone EVENTS###############################################################
        //event is raised when the button is clicked
        private void btnDoneClick(object sender, EventArgs e)
        {
            this.Close();
        } //--------------------------------
        //##############################################END BUTTON btnDone EVENTS##############################################################

        //###############################################BUTTON btnUpdate EVENTS################################################################
        //event is raised when the button is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (this.ValidateDeductionControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to update the deduction information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The deduction information has been successfully updated.";

                        _deductionInfo.Description = RemoteClient.ProcStatic.TrimStartEndString(txtDescription.Text);

                        _decManager.UpdateDeductionInformation(_userInfo, _deductionInfo);

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
            }

        } //-------------------------------
        //##############################################END BUTTON btnUpdate EVENTS#############################################################

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure initializes the controls
        private void InitializeControls()
        {
            _deductionInfo = _decManager.GetDetailsDeductionInformation(_deductionId);
            _deductionTemp = (CommonExchange.DeductionInformation)_deductionInfo.Clone();

            lblId.Text = _deductionInfo.DeductionSysId;
            txtDescription.Text = _deductionInfo.Description;       
        }
        
        #endregion
    }
}
