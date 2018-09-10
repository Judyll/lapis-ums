using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EmployeeServices
{
    partial class ViewUpdateDeduction
    {
        #region Class General Variable Declarations
        private CommonExchange.SysAccess _userInfo;
        private CommonExchange.DeductionInformation _decInfo;
        private CommonExchange.DeductionInformation _decTemp;
        private CommonExchange.Employee _empInfo;
        private DeductionLogic _decManager;
        private Int64 _deductionId;
        #endregion        

        #region Class Constructor
        public ViewUpdateDeduction(CommonExchange.SysAccess userInfo, CommonExchange.Employee empInfo, 
            DeductionLogic decManager, Int64 deductionId)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _empInfo = empInfo;
            _decManager = decManager;
            _deductionId = deductionId;

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
            _decInfo = new CommonExchange.DeductionInformation();

            _decInfo = _decManager.GetDetailsDeductionInformation(_deductionId);
            _decInfo.EmployeeInfo.EmployeeSysId = _empInfo.EmployeeSysId;

            _decTemp = (CommonExchange.DeductionInformation)_decInfo.Clone();

            lblName.Text = _empInfo.PersonInfo.LastName + ", " + _empInfo.PersonInfo.FirstName + " " + _empInfo.PersonInfo.MiddleName;
            lblDate.Text = DateTime.Parse(_decInfo.DeductionDate).ToLongDateString();
            lblDescription.Text = _decInfo.Description;
            txtAmount.Text = _decInfo.Amount.ToString("N");

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
                    _decInfo.Amount = amount;
                }

                if (!_decTemp.Equals(_decInfo))
                {
                    String strMsg = "There has been changes made in the current employee deduction information. \nExiting will not save this changes." +
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

            DateTime bDate = DateTime.Parse(_decManager.ServerDateTime);

            using (RemoteClient.DatePicker frmPicker = new RemoteClient.DatePicker(bDate))
            {
                frmPicker.ShowDialog(this);

                if (frmPicker.HasSelectedDate)
                {
                    if (DateTime.TryParse(frmPicker.GetSelectedDate.ToLongDateString() + " " + 
                        DateTime.Parse(_decManager.ServerDateTime).ToLongTimeString(), out bDate))
                    {
                        _decInfo.DeductionDate = bDate.ToString("o");
                    }

                    lblDate.Text = DateTime.Parse(_decInfo.DeductionDate).ToLongDateString();
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
                    String strMsg = "Updating an employee deduction might affect the system inventory." +
                                    "\n\nAre you sure you want to update the employee deduction?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The employee deduction has been successfully updated.";

                        Decimal amount = 0;

                        if (Decimal.TryParse(txtAmount.Text, out amount))
                        {
                            _decInfo.Amount = amount;
                        }
                                                
                        _decManager.UpdateEmployeeDeduction(_userInfo, _decInfo);

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
                String strMsg = "Deleting an employee deduction might affect the system inventory." +
                                "\n\nAre you sure you want to delete the employee deduction?";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (msgResult == DialogResult.Yes)
                {
                    strMsg = "The employee deduction has been successfully deleted.";

                    _decManager.DeleteEmployeeDeduction(_userInfo, _decInfo);

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
