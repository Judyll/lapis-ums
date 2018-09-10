using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EmployeeServices
{
    partial class EarningUpdate
    {
        #region Class General Variable Declarations
        private CommonExchange.EarningInformation _earningTemp;
        private String _earningId;
        #endregion

        #region Class Properties Declarations
        private Boolean _hasUpdated = false;
        public Boolean HasUpdated
        {
            get { return _hasUpdated; }
        }
        #endregion

        #region Class Constructor
        public EarningUpdate(CommonExchange.SysAccess userInfo, EarningLogic incManager, String earningId)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _incManager = incManager;
            _earningId = earningId;

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
            _earningInfo = new CommonExchange.EarningInformation();
            _earningTemp = new CommonExchange.EarningInformation();

            this.InitializeControls();
        } //-----------------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasUpdated)
            {
                _earningInfo.Description = RemoteClient.ProcStatic.TrimStartEndString(txtDescription.Text);

                if (!_earningInfo.Equals(_earningTemp))
                {
                    String strMsg = "There has been changes made in the current earning information. \nExiting will not save this changes." +
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
            if (this.ValidateEarningControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to update the earning information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The earning information has been successfully updated.";

                        _earningInfo.Description = RemoteClient.ProcStatic.TrimStartEndString(txtDescription.Text);

                        _incManager.UpdateEarningInformation(_userInfo, _earningInfo);

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
            _earningInfo = _incManager.GetDetailsEarningInformation(_earningId);
            _earningTemp = (CommonExchange.EarningInformation)_earningInfo.Clone();

            lblId.Text = _earningInfo.EarningSysId;
            txtDescription.Text = _earningInfo.Description;       
        }
        
        #endregion
    }
}
