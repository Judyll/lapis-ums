using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EmployeeServices
{
    partial class ViewUpdateEarning
    {
        #region Class General Variable Declarations
        private CommonExchange.SysAccess _userInfo;
        private CommonExchange.EarningInformation _incInfo;
        private CommonExchange.EarningInformation _incTemp;
        private CommonExchange.Employee _empInfo;
        private EarningLogic _incManager;
        private Int64 _earningId;
        #endregion        

        #region Class Constructor
        public ViewUpdateEarning(CommonExchange.SysAccess userInfo, CommonExchange.Employee empInfo, 
            EarningLogic incManager, Int64 earningId)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _empInfo = empInfo;
            _incManager = incManager;
            _earningId = earningId;

            this.Load += new EventHandler(ClassLoad);
            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.lnkChange.Click += new EventHandler(lnkChangeClick);
        }       
        
        
        #endregion

        #region Class Event Void Procedures

        //#############################################CLASS ViewUpdateDeduction EVENTS###############################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _incInfo = new CommonExchange.EarningInformation();

            _incInfo = _incManager.GetDetailsEarningInformation(_earningId);
            _incInfo.EmployeeInfo.EmployeeSysId = _empInfo.EmployeeSysId;

            _incTemp = (CommonExchange.EarningInformation)_incInfo.Clone();

            lblName.Text = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(_empInfo.PersonInfo.LastName,
                _empInfo.PersonInfo.FirstName, _empInfo.PersonInfo.MiddleName);
            lblDate.Text = DateTime.Parse(_incInfo.EarningDate).ToLongDateString();
            lblDescription.Text = _incInfo.Description;
            txtAmount.Text = _incInfo.Amount.ToString("N");

            if (_empInfo.SalaryInfo.EmployeeStatusInfo.StatusId == (Byte)CommonExchange.EmploymentStatusNo.LayOff)
            {
                lnkChange.Visible = false;
                txtAmount.Enabled = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
            }
            
        } //---------------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasUpdated)
            {
                Decimal amount = 0;

                if (Decimal.TryParse(txtAmount.Text, out amount))
                {
                    _incInfo.Amount = amount;
                }

                if (!_incTemp.Equals(_incInfo))
                {
                    String strMsg = "There has been changes made in the current employee earning information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
        } //------------------------------
        //#############################################END CLASS ViewUpdateDeduction EVENTS###########################################

        //############################################LINKBUTTON lnkChange EVENTS########################################################
        //event is raised when the link is clicked
        private void lnkChangeClick(object sender, EventArgs e)
        {           

            this.Cursor = Cursors.WaitCursor;

            DateTime bDate = DateTime.Parse(_incManager.ServerDateTime);

            using (RemoteClient.DatePicker frmPicker = new RemoteClient.DatePicker(bDate))
            {
                frmPicker.ShowDialog(this);

                if (frmPicker.HasSelectedDate)
                {
                    if (DateTime.TryParse(frmPicker.GetSelectedDate.ToLongDateString() + " " + 
                        DateTime.Parse(_incManager.ServerDateTime).ToLongTimeString(), out bDate))
                    {
                        _incInfo.EarningDate = bDate.ToString("o");
                    }

                    lblDate.Text = DateTime.Parse(_incInfo.EarningDate).ToLongDateString();
                }
            }

            this.Cursor = Cursors.Arrow;

        } //--------------------------------------------
        //############################################END LINKBUTTON lnkChange EVENTS####################################################

        //##############################################BUTTON btnUpdate EVENTS##########################################################
        //event is raised when the button is clicked
        protected override void btnUpdateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Updating an employee earning might affect the system inventory." +
                                    "\n\nAre you sure you want to update the employee earning?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The employee earning has been successfully updated.";

                        Decimal amount = 0;

                        if (Decimal.TryParse(txtAmount.Text, out amount))
                        {
                            _incInfo.Amount = amount;
                        }
                                                
                        _incManager.UpdateEmployeeEarning(_userInfo, _incInfo);

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

        } //-----------------------------------
        //##########################################END BUTTON btnUpdate EVENTS##########################################################

        //##############################################BUTTON btnDelete EVENTS#########################################################
        //event is raised when the button is clicked
        protected override void btnDeleteClick(object sender, EventArgs e)
        {
            try
            {
                String strMsg = "Deleting an employee earning might affect the system inventory." +
                                "\n\nAre you sure you want to delete the employee earning?";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (msgResult == DialogResult.Yes)
                {
                    strMsg = "The employee earning has been successfully deleted.";

                    _incManager.DeleteEmployeeEarning(_userInfo, _incInfo);

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
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Deleting");
            }
            
        } //-----------------------------
        //###########################################END BUTTON btnDelete EVENTS########################################################
        #endregion
    }
}
