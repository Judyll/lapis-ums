using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace EmployeeServices
{
    partial class LoanRemittanceSummary : IDisposable
    {
        #region Class General Variable Declarations
        private CommonExchange.SysAccess _userInfo;
        private CommonExchange.Employee _empInfo;
        private LoanRemittanceLogic _loanManager;
        private String _loanSysId;
        private Int64 _remSysId;
        private Int32 _primaryIndex = 0;
        #endregion

        #region Class Properties Declarations
        private Boolean _hasCreated = false;
        public Boolean HasCreated
        {
            get { return _hasCreated; }
        }

        private Boolean _hasUpdated = false;
        public Boolean HasUpdated
        {
            get { return _hasUpdated; }
        }
        #endregion

        #region Class Constructor
        public LoanRemittanceSummary(CommonExchange.SysAccess userInfo, CommonExchange.Employee empInfo, LoanRemittanceLogic loanManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _empInfo = empInfo;
            _loanManager = loanManager;

            this.Load += new EventHandler(ClassLoad);
            this.dgvLoan.MouseDown += new MouseEventHandler(dgvLoanMouseDown);
            this.dgvLoan.DoubleClick += new EventHandler(dgvLoanDoubleClick);
            this.dgvLoan.KeyPress += new KeyPressEventHandler(dgvLoanKeyPress);
            this.dgvLoan.KeyDown += new KeyEventHandler(dgvLoanKeyDown);
            this.dgvLoan.DataSourceChanged += new EventHandler(dgvLoanDataSourceChanged);
            this.dgvLoan.SelectionChanged += new EventHandler(dgvLoanSelectionChanged);
            this.dgvRemittance.MouseDown += new MouseEventHandler(dgvRemittanceMouseDown);
            this.dgvRemittance.DoubleClick += new EventHandler(dgvRemittanceDoubleClick);
            this.dgvRemittance.KeyPress += new KeyPressEventHandler(dgvRemittanceKeyPress);
            this.dgvRemittance.KeyDown += new KeyEventHandler(dgvRemittanceKeyDown);
            this.dgvRemittance.DataSourceChanged += new EventHandler(dgvRemittanceDataSourceChanged);
            this.dgvRemittance.SelectionChanged += new EventHandler(dgvRemittanceSelectionChanged);
            this.btnApply.Click += new EventHandler(btnApplyClick);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnCreate.Click += new EventHandler(btnCreateClick);
            this.btnPrint.Click += new EventHandler(btnPrintClick);
        }

                
        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            if (this.pbxPerson.Image != null)
            {
                this.pbxPerson.Image.Dispose();
                this.pbxPerson.Image = null;

                this.pbxPerson.Dispose();
                this.pbxPerson = null;
            }

            GC.SuppressFinalize(this);
            GC.Collect();
        }

        #endregion

        #region Class Event Void Procedures
        //#######################################CLASS LoanRemittanceSummary EVENTS###############################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            lblID.Text = _empInfo.EmployeeId;
            lblName.Text = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(_empInfo.PersonInfo.LastName,
                _empInfo.PersonInfo.FirstName, _empInfo.PersonInfo.MiddleName);

            _empInfo.PersonInfo = _loanManager.GetPersonDetails(_userInfo, _empInfo.PersonInfo.PersonSysId, Application.StartupPath);

            if (!String.IsNullOrEmpty(_empInfo.PersonInfo.FilePath) && File.Exists(_empInfo.PersonInfo.FilePath))
            {
                this.pbxPerson.Image = Image.FromFile(_empInfo.PersonInfo.FilePath);
            }

            _loanManager.InitializeRemittanceSummaryData(_userInfo, _empInfo.EmployeeSysId);

            this.SetDataGridViewSource();

            RemoteClient.ProcStatic.SetDataGridViewColumns(dgvLoan, false);
            RemoteClient.ProcStatic.SetDataGridViewColumns(dgvRemittance, false);

            if (_empInfo.SalaryInfo.EmployeeStatusInfo.StatusId == (Byte)CommonExchange.EmploymentStatusNo.LayOff)
            {
                btnApply.Enabled = false;
            }
            
        } //----------------------------
        //####################################END CLASS LoanRemittanceSummary EVENTS###############################################

        //####################################DATAGRIDVIEW dgvLoan EVENTS###########################################################
        //event is raised when the mouse is down
        private void dgvLoanMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView dgvBase = (DataGridView)sender;

                DataGridView.HitTestInfo hitTest = dgvBase.HitTest(e.X, e.Y);

                Int32 rowIndex = -1;

                switch (hitTest.Type)
                {
                    case DataGridViewHitTestType.Cell:
                        rowIndex = hitTest.RowIndex;
                        break;
                    case DataGridViewHitTestType.RowHeader:
                        rowIndex = hitTest.RowIndex;
                        break;
                    default:
                        rowIndex = -1;
                        _loanSysId = "";
                        break;
                }

                if (rowIndex != -1)
                {
                    _loanSysId = dgvBase[_primaryIndex, rowIndex].Value.ToString();

                    this.ShowLoanRemittanceInfo(true);
                }
            }

        } //-----------------------------

        //event is raised when the mouse is double clicked
        private void dgvLoanDoubleClick(object sender, EventArgs e)
        {
            this.ShowLoanRemittanceUpdate();
            
        } //---------------------------------

        //event is raised when the key is pressed        
        private void dgvLoanKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                DataGridView dgvBase = (DataGridView)sender;

                if (dgvBase.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
                {
                    DataGridViewRow row = dgvBase.SelectedRows[0];

                    _loanSysId = row.Cells[_primaryIndex].Value.ToString();

                    this.ShowLoanRemittanceUpdate();                    
                }                

            }
            else
            {
                e.Handled = true;
            }            

        } //-----------------------------------

        //event is raised when the key is down
        private void dgvLoanKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        } //--------------------------------------

        //event is raised when the data source is changed
        private void dgvLoanDataSourceChanged(object sender, EventArgs e)
        {
            DataGridView dgvBase = (DataGridView)sender;
            Int32 result = dgvBase.Rows.Count;

            if (result == 1)
            {
                _loanSysId = dgvBase[_primaryIndex, 0].Value.ToString();
            }
            else
            {
                _loanSysId = "";
            }

            if (result == 0 || result == 1)
            {
                this.lblLoanResult.Text = result.ToString() + " Record";
            }
            else
            {
                this.lblLoanResult.Text = result.ToString() + " Records";
            }

            //unselect the first row
            if (dgvBase.Rows.Count >= 1)
            {
                dgvBase.Rows[0].Selected = false;
            }

            this.ShowLoanRemittanceInfo(false);

        } //--------------------------------

        //event is raised when the selection is changed
        private void dgvLoanSelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgvBase = (DataGridView)sender;

            if (dgvBase.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                DataGridViewRow row = dgvBase.SelectedRows[0];

                _loanSysId = row.Cells[_primaryIndex].Value.ToString();

                this.ShowLoanRemittanceInfo(true);
            }
        } //------------------------------------

        //#################################END DATAGRIDVIEW dgvLoan EVENTS#########################################################

        //#########################################DATAGRIDVIEW dgvRemittance EVENTS#################################################
        //event is raised when the mouse is down
        private void dgvRemittanceMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView dgvBase = (DataGridView)sender;

                DataGridView.HitTestInfo hitTest = dgvBase.HitTest(e.X, e.Y);

                Int32 rowIndex = -1;

                switch (hitTest.Type)
                {
                    case DataGridViewHitTestType.Cell:
                        rowIndex = hitTest.RowIndex;
                        break;
                    case DataGridViewHitTestType.RowHeader:
                        rowIndex = hitTest.RowIndex;
                        break;
                    default:
                        rowIndex = -1;
                        _remSysId = 0;
                        break;
                }

                if (rowIndex != -1)
                {
                    _remSysId = (Int64)dgvBase[_primaryIndex, rowIndex].Value;                    
                }
            }

        } //-----------------------------

        //event is raised when the mouse is double clicked
        private void dgvRemittanceDoubleClick(object sender, EventArgs e)
        {

            this.ShowEmployeeRemittanceUpdate();

        } //---------------------------------

        //event is raised when the key is pressed        
        private void dgvRemittanceKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                DataGridView dgvBase = (DataGridView)sender;

                if (dgvBase.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
                {
                    DataGridViewRow row = dgvBase.SelectedRows[0];

                    _remSysId = (Int64)row.Cells[_primaryIndex].Value;

                    this.ShowEmployeeRemittanceUpdate();
                }                

            }
            else
            {
                e.Handled = true;
            }
        } //-----------------------------------

        //event is raised when the key is down
        private void dgvRemittanceKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        } //--------------------------------------

        //event is raised when the data source is changed
        private void dgvRemittanceDataSourceChanged(object sender, EventArgs e)
        {
            DataGridView dgvBase = (DataGridView)sender;
            Int32 result = dgvBase.Rows.Count;

            if (result == 1)
            {
                _remSysId = (Int64)dgvBase[_primaryIndex, 0].Value;
            }
            else
            {
                _remSysId = 0;
            }

            if (result == 0 || result == 1)
            {
                this.lblRemittanceResult.Text = result.ToString() + " Record";
            }
            else
            {
                this.lblRemittanceResult.Text = result.ToString() + " Records";
            }

            //unselect the first row
            if (dgvBase.Rows.Count >= 1)
            {
                dgvBase.Rows[0].Selected = false;
            }            

        } //--------------------------------

        //event is raised when the selection is changed
        private void dgvRemittanceSelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgvBase = (DataGridView)sender;

            if (dgvBase.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                DataGridViewRow row = dgvBase.SelectedRows[0];

                _remSysId = (Int64)row.Cells[_primaryIndex].Value;
            }
        } //------------------------------------       
        //###################################END DATAGRIDVIEW dgvRemittance EVENTS###################################################

        //########################################BUTTON btnApply EVENTS###########################################################
        //event is raised when the button is clicked
        private void btnApplyClick(object sender, EventArgs e)
        {
            using (LoanInformationCreate frmCreate = new LoanInformationCreate(_userInfo, _empInfo, _loanManager))
            {
                frmCreate.ShowDialog(this);

                if (frmCreate.HasCreated)
                {
                    this.SetDataGridViewSource();                    
                }

                _hasCreated = frmCreate.HasCreated;
            }
        } //-------------------------------
        //#####################################END BUTTON btnApply EVENTS##########################################################

        //##############################################BUTTON btnCreate EVENTS######################################################
        //event is raised when the button is clicked
        private void btnCreateClick(object sender, EventArgs e)
        {
            using (EmployeeRemittanceCreate frmCreate = new EmployeeRemittanceCreate(_userInfo, _empInfo, _loanManager.GetDetailsLoanRemittance(_loanSysId),
                                                                                        _loanManager))
            {
                frmCreate.ShowDialog(this);

                if (frmCreate.HasCreated)
                {
                    String id = _loanSysId;

                    this.SetDataGridViewSource();

                    //select the specified loan
                    if (dgvLoan.Rows.Count >= 1)
                    {
                        dgvLoan.Rows[_loanManager.GetLoanDataSourceIndex(id)].Selected = true;
                    }            
                }

                _hasCreated = frmCreate.HasCreated;
            }

        } //-------------------------------
        //#############################################END BUTTON btnCreate EVENTS####################################################

        //################################################BUTTON btnClose EVENTS######################################################
        //event is raised when the button is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        } //----------------------------------
        //###############################################END BUTTON btnClose EVENTS###################################################

        //#############################################BUTTON btnPrint EVENTS#######################################################
        //event is raised when the button is clicked
        private void btnPrintClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {                
                _loanManager.PrintEmployeeRemittance(_userInfo, _loanManager.GetDetailsLoanRemittance(_loanSysId), _empInfo);

            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Generating Report");
            }

            this.Cursor = Cursors.Arrow;
        } //--------------------------------
        //###########################################END BUTTON btnPrint EVENTS#######################################################

        #endregion

        #region Programmer-Defined Void Procedures
        //this procedure sets the datasource for the data grid view
        private void SetDataGridViewSource()
        {
            dgvLoan.DataSource = _loanManager.GetLoanRemittanceTable();
            dgvRemittance.DataSource = _loanManager.GetEmployeeRemittanceTable("");                

        } //--------------------------------

        //this procedure shows the loan remittance information
        private void ShowLoanRemittanceInfo(Boolean show)
        {
            gbxRemittance.Enabled = show;

            if (show)
            {
                CommonExchange.LoanInformation loanInfo = _loanManager.GetDetailsLoanRemittance(_loanSysId);

                lblReferenceNo.Text = loanInfo.ReferenceNo;
                lblLoanType.Text = loanInfo.Description;
                lblReleaseDate.Text = loanInfo.ReleaseDate;
                lblMaturityDate.Text = loanInfo.MaturityDate;
                lblPrincipalInterest.Text = loanInfo.PrincipalInterest.ToString("N");

                Decimal totalPaid = _loanManager.GetTotalPaidLoanRemittance(_loanSysId);

                lblAmountPaid.Text = totalPaid.ToString("N");
                lblBalance.Text = ((Decimal)(loanInfo.PrincipalInterest - totalPaid)).ToString("N");

                dgvRemittance.DataSource = _loanManager.GetEmployeeRemittanceTable(_loanSysId);
            }
            else
            {
                lblReferenceNo.Text = "--";
                lblLoanType.Text = "--";
                lblReleaseDate.Text = "--";
                lblMaturityDate.Text = "--";
                lblPrincipalInterest.Text = "--";
                lblAmountPaid.Text = "--";
                lblBalance.Text = "--";
            }

        } //----------------------------------

        //this procedure shows the loan remittance update form
        private void ShowLoanRemittanceUpdate()
        {
            using (LoanInformationUpdate frmUpdate = new LoanInformationUpdate(_userInfo, _empInfo, _loanManager.GetDetailsLoanRemittance(_loanSysId),
                                            _loanManager))
            {
                frmUpdate.ShowDialog(this);

                if (frmUpdate.HasUpdated)
                {
                    String id = _loanSysId;

                    this.SetDataGridViewSource();

                    //select the specified loan
                    if (dgvLoan.Rows.Count >= 1)
                    {
                        dgvLoan.Rows[_loanManager.GetLoanDataSourceIndex(id)].Selected = true;
                    }

                    _hasUpdated = frmUpdate.HasUpdated;
                }
                else if (frmUpdate.HasDeleted)
                {
                    this.SetDataGridViewSource();

                    _hasUpdated = frmUpdate.HasDeleted;
                }                
            }

        } //----------------------------

        //this procedure show the employee remittance update form
        private void ShowEmployeeRemittanceUpdate()
        {
            using (EmployeeRemittanceUpdate frmUpdate = new EmployeeRemittanceUpdate(_userInfo, _empInfo, _loanManager.GetDetailsLoanRemittance(_loanSysId),
                                            _loanManager.GetDetailsEmployeeRemittance(_remSysId), _loanManager))
            {
                frmUpdate.ShowDialog(this);

                if (frmUpdate.HasUpdated)
                {
                    String id = _loanSysId;

                    this.SetDataGridViewSource();

                    //select the specified loan
                    if (dgvLoan.Rows.Count >= 1)
                    {
                        dgvLoan.Rows[_loanManager.GetLoanDataSourceIndex(id)].Selected = true;
                    }            
                }

                _hasUpdated = frmUpdate.HasUpdated;
            }
        } //-------------------------------
        #endregion
    }
}
