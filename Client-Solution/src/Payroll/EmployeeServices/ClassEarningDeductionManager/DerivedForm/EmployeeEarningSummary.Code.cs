using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EmployeeServices
{
    partial class EmployeeEarningSummary
    {
        #region Class General Variable Declarations
        private CommonExchange.SysAccess _userInfo;
        private CommonExchange.Employee _empInfo;
        private EarningLogic _incManager;
        #endregion

        #region Class Constructor
        public EmployeeEarningSummary(CommonExchange.SysAccess userInfo, CommonExchange.Employee empInfo, EarningLogic incManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _empInfo = empInfo;
            _incManager = incManager;
            
        }
        #endregion

        #region Class Event Void Procedures

        //###############################################CLASS EmployeeDeductionSummary EVENTS############################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            _dateFrom = _dateTo = DateTime.Parse(_incManager.ServerDateTime);

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
            lblName.Text = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(_empInfo.PersonInfo.LastName,
                _empInfo.PersonInfo.FirstName, _empInfo.PersonInfo.MiddleName);

            this.UpdateDataGridViewResult(true);

            RemoteClient.ProcStatic.SetDataGridViewColumns(dgvList, false);
        }
        //#############################################END CLASS EmployeeDeductionSummary EVENTS###########################################

        //########################################################BUTTON btNPrint EVENTS#####################################################
        //event is raised when the button is clicked
        protected override void btnPrintClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                _incManager.PrintEmployeeEarningList(_userInfo, _empInfo, _dateFrom, _dateTo);

            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Generating Report");
            }

            this.Cursor = Cursors.Arrow;

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
                    _incManager.SetSelectedEmployeeEarningByDate(_userInfo, _empInfo.EmployeeSysId, _dateFrom.ToString(), _dateTo.ToString());
                }

                this.dgvList.DataSource = _incManager.GetSearchedEmployeeEarningByDescription(txtSearch.Text);

                if (_incManager.RowCount >= 1)
                {
                    btnPrint.Enabled = true;
                }
                else
                {
                    btnPrint.Enabled = false;
                }

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Retrieving Earnings");
            }

        } //---------------------------

        //this procedure shows the update form
        protected override void ShowUpdateForm(Int64 id)
        {
            try
            {
                using (ViewUpdateEarning frmUpdate = new ViewUpdateEarning(_userInfo, _empInfo, _incManager, id))
                {
                    frmUpdate.ShowDialog();

                    if (frmUpdate.HasUpdated)
                    {
                        this.dgvList.DataSource = _incManager.GetSearchedEmployeeEarningByDescription(txtSearch.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Updating Deductions");
            }
        } //---------------------------------

        #endregion
    }
}
