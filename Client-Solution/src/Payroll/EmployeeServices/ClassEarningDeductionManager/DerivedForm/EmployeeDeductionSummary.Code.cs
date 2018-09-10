using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EmployeeServices
{
    partial class EmployeeDeductionSummary
    {
        #region Class General Variable Declarations
        private CommonExchange.SysAccess _userInfo;
        private CommonExchange.Employee _empInfo;
        private DeductionLogic _decManager;
        #endregion

        #region Class Constructor
        public EmployeeDeductionSummary(CommonExchange.SysAccess userInfo, CommonExchange.Employee empInfo, DeductionLogic decManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _empInfo = empInfo;
            _decManager = decManager;
            
        }
        #endregion

        #region Class Event Void Procedures
        
        //###############################################CLASS EmployeeDeductionSummary EVENTS############################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            _dateFrom = _dateTo = DateTime.Parse(_decManager.ServerDateTime);

            DateTime tempFrom;
            DateTime tempTo;

            if (DateTime.TryParse(_dateFrom.ToShortDateString() + " 12:00:00 AM", out tempFrom))
            {
                _dateFrom = tempFrom;
            }

            if (DateTime.TryParse(_dateTo.ToShortDateString() + " 11:59:59 PM", out tempTo))
            {
                _dateTo = tempTo;
            }

            lblDate.Text = _dateFrom.ToLongDateString() + "  -  " + _dateTo.ToLongDateString();

            lblId.Text = _empInfo.EmployeeId;
            lblName.Text = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(_empInfo.PersonInfo.LastName, _empInfo.PersonInfo.FirstName,
                _empInfo.PersonInfo.MiddleName);

            this.UpdateDataGridViewResult(true);

            RemoteClient.ProcStatic.SetDataGridViewColumns(dgvList, false);            
        }
        //#############################################END CLASS EmployeeDeductionSummary EVENTS###########################################

        //########################################################BUTTON btNPrint EVENTS#####################################################
        //event is raised when the button is clicked
        protected override void btnPrintClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _decManager.PrintEmployeeDeductionList(_userInfo, _empInfo, _dateFrom, _dateTo);               
                
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Generating Report");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }


        } //------------------------------------
        //#####################################################END BUTTON btnPrint EVENTS######################################################
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure updates the data grid view
        protected override void UpdateDataGridViewResult(Boolean update)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (update)
                {
                    _decManager.SetSelectedEmployeeDeductionByDate(_userInfo, _empInfo.EmployeeSysId, _dateFrom.ToString(), _dateTo.ToString());
                }
                
                this.dgvList.DataSource = _decManager.GetSearchedEmployeeDeductionByDescription(txtSearch.Text);

                if (_decManager.RowCount >= 1)
                {
                    btnPrint.Enabled = true;
                }
                else
                {
                    btnPrint.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Retrieving Deductions");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
            
        } //---------------------------

        //this procedure shows the update form
        protected override void ShowUpdateForm(Int64 id)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (ViewUpdateDeduction frmUpdate = new ViewUpdateDeduction(_userInfo, _empInfo, _decManager, id))
                {
                    frmUpdate.ShowDialog();

                    if (frmUpdate.HasUpdated)
                    {
                        this.dgvList.DataSource = _decManager.GetSearchedEmployeeDeductionByDescription(txtSearch.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Updating Deductions");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        } //---------------------------------

        #endregion
    }
}
