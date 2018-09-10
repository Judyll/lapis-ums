using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class CashieringManager
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private CashieringLogic _cashieringManager;
        private CashieringSearchList _frmStudentSearch;
        private StudentLogic _studentManager;
        #endregion

        #region Class Constructors
        public CashieringManager(CommonExchange.SysAccess userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;

            this.Load += new EventHandler(ClassLoad);
            this.FormClosed += new FormClosedEventHandler(ClassClosed);
            this.ctlManager.OnClose += new RemoteClient.ControlCashieringManagerCloseButtonClick(ctlManagerOnClose);
            this.ctlManager.OnRefresh += new RemoteClient.ControlCashieringManagerRefreshButtonClick(ctlManagerOnRefresh);
            this.ctlManager.OnTextBoxKeyUp += new RemoteClient.ControlCashieringManagerTextBoxSearchKeyUp(ctlManagerOnTextBoxKeyUp);
            this.ctlManager.OnPressEnter += new RemoteClient.ControlCashieringManagerPressEnter(ctlManagerOnPressEnter);
            this.ctlManager.OnAdditionalFee += new RemoteClient.ControlCashieringManagerAdditionalFeeButtonClick(ctlManagerOnAdditionalFee);
            this.ctlManager.OnScholarshipDiscountsLinkClicked +=
                new RemoteClient.ControlCashieringManagerScholarshipDiscountsLinkClicked(ctlManagerOnIssuedDiscountsLinkClicked); 
            this.ctlManager.OnCreditMemoLinkClicked += new RemoteClient.ControlCashieringManagerCreditMemoLinkClicked(ctlManagerOnCreditMemoLinkClicked);
            this.ctlManager.OnFeesRegisterSummarizedLinkClicked += 
                new RemoteClient.ControlCashieringManagerFeesRegisterSummarizedLinkClicked(ctlManagerOnFeesRegisterSummarizedLinkClicked);
            this.ctlManager.OnFeesRegisterDetailedLinkClicked += 
                new RemoteClient.ControlCashieringManagerFeesRegisterDetailedLinkClicked(ctlManagerOnFeesRegisterDetailedLinkClicked);
            this.ctlManager.OnARStudentPerTermLinkClicked += new RemoteClient.ControlCashieringManagerARStudentPerTermLinkClicked(ctlManagerOnARStudentPerTermLinkClicked);
            this.ctlManager.OnARStudentPerFiscalYearLinkClicked +=
                new RemoteClient.ControlCashieringManagerARStudentPerFiscalYearLinkClicked(ctlManagerOnARStudentFiscalYearLinkClicked);
            this.ctlManager.OnReceiptNoTextBoxValidated += 
                new RemoteClient.ControlCashieringManagerReceiptNoTextBoxValidated(ctlManagerOnReceiptNoTextBoxValidated);
            this.ctlManager.OnIncrementLinkClicked += new RemoteClient.ControlCashieringManagerIncrementLinkClicked(ctlManagerOnIncrementLinkClicked);
            this.ctlManager.OnDecrementLinkClicked += new RemoteClient.ControlCashieringManagerDecrementLinkClicked(ctlManagerOnDecrementLinkClicked);
            this.ctlManager.OnViewCancelledReceiptLinkClicked += 
                new RemoteClient.ControlCashieringManagerViewCancelledReceiptLinkClicked(ctlManagerOnViewCancelledReceiptLinkClicked);
            this.ctlManager.OnCancelReceiptLinkClicked += new RemoteClient.ControlCashieringManagerCancelReceiptLinkClicked(ctlManagerOnCancelReceiptLinkClicked);
            this.ctlManager.OnMiscellaneousIncome += new RemoteClient.ControlCashieringManagerMiscellaneousIncomeClick(ctlManagerOnMiscellaneousIncome);
            this.ctlManager.OnCashReceiptsDetailedLinkClicked += 
                new RemoteClient.ControlCashieringManagerCashReceiptsDetailedLinkClicked(ctlManagerOnCashReceiptsDetailedLinkClicked);
            this.ctlManager.OnCashReceiptsSummarizedLinkClicked += 
                new RemoteClient.ControlCashieringManagerCashReceiptsSummarizedLinkClicked(ctlManagerOnCashReceiptsSummarizedLinkClicked);
            this.ctlManager.OnReceiptDateValueChanged += new RemoteClient.ControlCashieringManagerReceiptDateValueChanged(ctlManagerOnReceiptDateValueChanged);
            this.ctlManager.OnCashDiscountsLinkClicked += new RemoteClient.ControlCashieringManagerCashDiscountsLinkClicked(ctlManagerOnCashDiscountsLinkClicked);
            this.ctlManager.OnCashReceiptsQueryLinkClicked += new RemoteClient.ControlCashieringManagerCashReceiptsQueryLinkClicked(ctlManagerOnCashReceiptsQueryLinkClicked);

        }
        #endregion

        #region Class Event Void Procedures
        //###########################################CLASS CashieringManager EVENTS#####################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            try
            {
                if (!(RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo) ||
                   RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo)))
                {
                    throw new Exception("You are not authorized to access this module.");
                }    

                _cashieringManager = new CashieringLogic(_userInfo);
                _studentManager = new StudentLogic(_userInfo);

                this.ctlManager.ReceiptNo = CashieringLogic.ReceiptNumber;
                this.ctlManager.ReceiptDate = !String.IsNullOrEmpty(CashieringLogic.ReceiptDate) ? DateTime.Parse(CashieringLogic.ReceiptDate) :
                    DateTime.Parse(_cashieringManager.ServerDateTime);

                _frmStudentSearch = new CashieringSearchList();
                _frmStudentSearch.OnDoubleClickEnter += new SearchListDataGridDoubleClickEnter(_frmStudentSearchOnDoubleClickEnter);
                _frmStudentSearch.OnCashierUpdateClick += new SearchListDataGridContextMenuClick(_frmStudentSearchOnCashierUpdateClick);
                _frmStudentSearch.OnDataControllerUpdateClick += new SearchListDataGridContextMenuClick(_frmStudentSearchOnDataControllerUpdateClick);
                _frmStudentSearch.OnViewEnrolmentHistoryClick += new SearchListDataGridContextMenuClick(_frmStudentSearchOnViewEnrolmentHistoryClick);
                _frmStudentSearch.LocationPoint = new Point(14, 300);
                _frmStudentSearch.AdoptGridSize = false;
                _frmStudentSearch.MdiParent = this;
                _frmStudentSearch.DisableContextMenu(false, false, false, false);

                Boolean dataController = false;
                Boolean cashier = false;
                Boolean registrar = false;

                if (RemoteServerLib.ProcStatic.IsSystemAccessStudentDataController(_userInfo))
                {
                    //_frmStudentSearch.DisableContextMenu(false, true, false, true);
                    dataController = true;
                }

                if (RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo) || RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo))
                {
                    //_frmStudentSearch.DisableContextMenu(false, false, true, true);
                    cashier = true;
                }
                
                if (RemoteServerLib.ProcStatic.IsSystemAccessCollegeRegistrar(_userInfo))
                {
                    //_frmStudentSearch.DisableContextMenu(false, false, false, true);
                    registrar = true;
                }

                if (RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo))
                {
                    _frmStudentSearch.DisableContextMenu(false, true, true, true);
                }
                else
                {
                    _frmStudentSearch.DisableContextMenu(false, dataController, cashier, true);
                }

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_cashieringManager.ServerDateTime).ToString();
            }
            catch(Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("\n" + ex.Message, "Error Authenticating");

                this.Close();
            }
        }//------------------------

        //event is raised when the class is closed
        private void ClassClosed(object sender, FormClosedEventArgs e)
        {
            CashieringLogic.ReceiptNumber = this.ctlManager.ReceiptNo;
        }//---------------------
        //###########################################CLASS CashieringManager EVENTS#####################################################

        //############################################CONTROLCLASSROOMSUBJECTMANAGER ctlManager EVENTS##########################################
        //event is raised when the close button is click
        private void ctlManagerOnClose()
        {
            this.Close();
        }//----------------------  

        //event is raised when the refresh button is clicked
        private void ctlManagerOnRefresh()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _cashieringManager.RefreshStudentData(_userInfo);

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_cashieringManager.ServerDateTime).ToString();

            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Refreshing Student's Data Manager");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//---------------------

        //event is raised when the key is up
        private void ctlManagerOnTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                _frmStudentSearch.SelectFirstRowInDataGridView();
            }
            else if (string.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(this.ctlManager.GetSearchString)))
            {
                _frmStudentSearch.WindowState = FormWindowState.Minimized;

                this.ctlManager.SetFocusOnSearchTextBox();
            }
        }//--------------------

        //event is raised when the enter key is raised
        private void ctlManagerOnPressEnter(object sender, KeyEventArgs e)
        {
            this.ShowSearchResultDialog();
        }//------------------------

        //evetn is raised whent the additional fee is clicked
        private void ctlManagerOnAdditionalFee()
        {
            try
            {
                using (MultipleAdditionalFeeCreate frmCreate = new MultipleAdditionalFeeCreate(_userInfo, _cashieringManager))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmCreate.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }
        }//------------------------

        //event is raised when the issued discount is clicked
        private void ctlManagerOnIssuedDiscountsLinkClicked()
        {
            try
            {
                using (DiscountReportControl frmReport = new DiscountReportControl(_userInfo, _cashieringManager))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmReport.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }
        }//-------------------------

        //event is raised when the credit memo prooflist is clicked
        private void ctlManagerOnCreditMemoLinkClicked()
        {
            try
            {
                using (CreditMemoReportControl frmReport = new CreditMemoReportControl(_userInfo, _cashieringManager))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmReport.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }
        } //----------------------------

        //event is raised when the fee register summarized is clicked
        private void ctlManagerOnFeesRegisterSummarizedLinkClicked()
        {
            try
            {
                using (FeeRegisterSummarizedReportControl frmReport = new FeeRegisterSummarizedReportControl(_userInfo, _cashieringManager))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmReport.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }
        }//---------------------------

        //event is raised when the fee register detailed is clicked
        private void ctlManagerOnFeesRegisterDetailedLinkClicked()
        {
            try
            {
                using (FeeRegisterDetailedReportControl frmReport = new FeeRegisterDetailedReportControl(_userInfo, _cashieringManager))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmReport.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }
        }//-----------------------------

        //event is raised when the student balance is clicked
        private void ctlManagerOnStudentBalancesLinkClicked()
        {
            try
            {
                using (StudentBalanceReport frmReport = new StudentBalanceReport(_userInfo, _cashieringManager))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmReport.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }
        }//-------------------------------

        //event is raised when the student account receivable per term is clicked
        private void ctlManagerOnARStudentPerTermLinkClicked()
        {
            try
            {
                using (ARStudentsPerTerm frmReport = new ARStudentsPerTerm(_userInfo, _cashieringManager))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmReport.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }
        }//-------------------------

        //event is raised when the student account receivable per fiscal year is clicked
        private void ctlManagerOnARStudentFiscalYearLinkClicked()
        {
            try
            {
                using (StudentAccountReceivableFiscalYear frmReport = new StudentAccountReceivableFiscalYear(_userInfo, _cashieringManager))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmReport.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }
        }//------------------------

        //event is raised when the decrement link is clicked
        private void ctlManagerOnDecrementLinkClicked()
        {
            CashieringLogic.ReceiptNumber = this.ctlManager.ReceiptNo;
        }//-----------------------

        //event is raised when the increment link is clicked
        private void ctlManagerOnIncrementLinkClicked()
        {
            CashieringLogic.ReceiptNumber = this.ctlManager.ReceiptNo;
        }//---------------------------

        //event is raied when the control is validated
        private void ctlManagerOnReceiptNoTextBoxValidated()
        {
            CashieringLogic.ReceiptNumber = this.ctlManager.ReceiptNo;
        }//----------------------------

        //event is raised when the cancel receipt is clicked
        private void ctlManagerOnCancelReceiptLinkClicked(int receiptNo)
        {
            using (ReceiptInformationCancelRecord frmCancel = new ReceiptInformationCancelRecord(_userInfo, _cashieringManager,
                RemoteClient.ProcStatic.SixDigitZero(CashieringLogic.ReceiptNumber).ToString(), _cashieringManager.ServerDateTime))
            {
                frmCancel.IsFromReIssued = false;

                if (frmCancel.ValidateControls())
                {
                    frmCancel.ShowDialog(this);
                }
                else
                {
                    MessageBox.Show("The receipt number [" + RemoteClient.ProcStatic.SixDigitZero(CashieringLogic.ReceiptNumber).ToString() +
                        "] is being used or it already exist in the cancelled receipt.", "Already Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.ctlManager.ReceiptNo = CashieringLogic.ReceiptNumber;
            }
        }//-------------------------------

        //event is raised when the miscellaneous button or event is clicked
        private void ctlManagerOnMiscellaneousIncome()
        {
            using (MiscellaneousIncome frmShow = new MiscellaneousIncome(_userInfo, _cashieringManager, CashieringLogic.ReceiptDate))
            {
                frmShow.ShowDialog();
            }

            this.ctlManager.SetFocusOnSearchTextBox();
            this.ctlManager.ReceiptNo = CashieringLogic.ReceiptNumber;
        }//-----------------------------------

        //event is raised when the cash receipt details link is clicked
        private void ctlManagerOnCashReceiptsDetailedLinkClicked()
        {
            using (CashReceiptReportControl frmReport = new CashReceiptReportControl(_userInfo, _cashieringManager))
            {
                frmReport.IsForDetails = true;
                frmReport.IsForSummarized = false;

                frmReport.ShowDialog(this);
            }
        }//------------------------

        //event is raised when the cash receipt summarized link is clicked
        private void ctlManagerOnCashReceiptsSummarizedLinkClicked()
        {
            using (CashReceiptReportControl frmReport = new CashReceiptReportControl(_userInfo, _cashieringManager))
            {
                frmReport.IsForDetails = false;
                frmReport.IsForSummarized = true;

                frmReport.ShowDialog(this);
            }
        }//-----------------------

        //event is raised when the cash discounts link is clicked
        private void ctlManagerOnCashDiscountsLinkClicked()
        {
            using (CashDiscountReportControl frmReport = new CashDiscountReportControl(_userInfo, _cashieringManager))
            {
                frmReport.ShowDialog(this);
            }
        }//------------------

        //event is raised when the cash receipt query link is clicked
        private void ctlManagerOnCashReceiptsQueryLinkClicked()
        {
            using (CashReceiptQueryReportControl frmReport = new CashReceiptQueryReportControl(_userInfo, _cashieringManager))
            {
                frmReport.ShowDialog(this);
            }
        }//-------------------------

        //event is raised when the receiptDateValue is changed
        private void ctlManagerOnReceiptDateValueChanged(DateTime d)
        {
            CashieringLogic.ReceiptDate = this.ctlManager.ReceiptDate.ToLongDateString();
        }//-----------------------

        //event is raised when the view cancel receipt is clicked
        private void ctlManagerOnViewCancelledReceiptLinkClicked()
        {
            using (ReceiptNumberSearchOnTextBoxList frmSearch = new ReceiptNumberSearchOnTextBoxList(_userInfo, _cashieringManager))
            {
                frmSearch.AdoptGridSize = true;

                frmSearch.ShowDialog(this);
            }
        }//--------------------------------
        //############################################END CONTROLCLASSROOMSUBJECTMANAGER ctlManager EVENTS##########################################

        //##########################################CLASS StudentSearchList EVENTS#######################################################       
        //event is raised when the datagrid is double clicked or enter
        private void _frmStudentSearchOnDoubleClickEnter(string id)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _cashieringManager.SetServerDateTime(_userInfo);

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_cashieringManager.ServerDateTime).ToString();

                using (StudentTab frmShow = new StudentTab(_userInfo, _cashieringManager.GetDetailsStudentInformation(_userInfo, id,
                    Application.StartupPath), _cashieringManager, CashieringLogic.ReceiptDate))
                {
                    _frmStudentSearch.WindowState = FormWindowState.Minimized;

                    frmShow.ShowDialog(this);

                    _frmStudentSearch.WindowState = FormWindowState.Normal;

                    this.ctlManager.SetFocusOnSearchTextBox();
                    this.ctlManager.ReceiptNo = CashieringLogic.ReceiptNumber;
                }
            }
            catch(Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message + "\n\nError Loading Student Tab Mudule.", "Error Loading");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//------------------------

        //this event is raised when the contextmenustrip is clicked
        private void _frmStudentSearchOnDataControllerUpdateClick(string id)
        {
            this.ShowUpdateStudentInformationDialog(id, true);
        }//--------------------------

        //this event is raised whent the contexmenustrip is clicked
        private void _frmStudentSearchOnViewEnrolmentHistoryClick(string id)
        {
            this.ShowStudentEnrolmentHistory(id);
        }//-------------------------------------

        //this event is raised when the contextmenustrip is clicked
        private void _frmStudentSearchOnCashierUpdateClick(string id)
        {
            this.ShowUpdateStudentInformationDialog(id, false);
        }//--------------------------
        //##########################################END CLASS StudentSearchList EVENTS#######################################################  
        #endregion

        #region Programers-Defined Procedures
        //this procedure shows the search result
        private void ShowSearchResultDialog()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String queryString = RemoteClient.ProcStatic.TrimStartEndString(this.ctlManager.GetSearchString);

                if (!String.IsNullOrEmpty(queryString))
                {
                    if (_cashieringManager.GetSearchedStudentDetails(_userInfo, queryString) == 1)
                    {
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;

                            using (StudentTab frmShow = new StudentTab(_userInfo, _cashieringManager.GetDetailsStudentInformation(_userInfo,
                                _cashieringManager.GetStudentIdForSingleInstance(), Application.StartupPath), _cashieringManager, CashieringLogic.ReceiptDate))
                            {
                                frmShow.ShowDialog(this);

                                this.ctlManager.SetFocusOnSearchTextBox();
                                this.ctlManager.ReceiptNo = CashieringLogic.ReceiptNumber;
                            }
                        }
                        catch(Exception ex)
                        {
                            RemoteClient.ProcStatic.ShowErrorDialog("\n\nError Loading Student Tab Mudule. \n\n" + ex.Message, "Error Loading");
                        }
                        finally
                        {
                            this.Cursor = Cursors.Arrow;
                        }
                    }
                    //else
                    //{
                        _frmStudentSearch.DataSource = _cashieringManager.PopulateStudentSearchedList();
                    //}
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Retrieving Data");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }

        }//---------------------------------       

        //this procedure shows the view update student Information
        private void ShowUpdateStudentInformationDialog(String id, Boolean isAdvance)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (isAdvance)
                {
                    using (StudentGuidanceUpdate frmUpdate = new StudentGuidanceUpdate(_userInfo,
                        _cashieringManager.GetDetailsStudentInformation(_userInfo, id, Application.StartupPath), _studentManager))
                    {
                        _frmStudentSearch.WindowState = FormWindowState.Minimized;

                        frmUpdate.ShowDialog(this);

                        if (frmUpdate.HasUpDated)
                        {
                            this.ShowSearchResultDialog();
                        }

                        _frmStudentSearch.WindowState = FormWindowState.Normal;

                        this.ctlManager.SetFocusOnSearchTextBox();
                    }
                }
                else
                {
                    DataTable tempTable = _cashieringManager.StudentTable;

                    using (StudentCashierUpdate frmUpdate = new StudentCashierUpdate(_userInfo,
                        _cashieringManager.GetDetailsStudentInformation(_userInfo, id, Application.StartupPath), _studentManager, false, true, ref tempTable))
                    {
                        _frmStudentSearch.WindowState = FormWindowState.Minimized;

                        frmUpdate.ShowDialog(this);

                        if (frmUpdate.HasUpDated)
                        {
                            _cashieringManager.StudentTable = tempTable;

                            this.ShowSearchResultDialog();
                        }
                        else if (frmUpdate.IsForStudentUpdate)
                        {
                            this.ShowUpdateStudentInformationDialog(frmUpdate.StudentInfo);
                        }


                        _frmStudentSearch.WindowState = FormWindowState.Normal;

                        this.ctlManager.SetFocusOnSearchTextBox();
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Update Student Information Module");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//----------------------

        //this procedure show the student enrolment history
        private void ShowStudentEnrolmentHistory(String id)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (StudentEnrolmentHistory frmShow = new StudentEnrolmentHistory(_userInfo, _studentManager,
                    _cashieringManager.GetDetailsStudentInformation(_userInfo, id, Application.StartupPath), true))
                {
                    _frmStudentSearch.WindowState = FormWindowState.Minimized;

                    frmShow.ShowDialog(this);

                    _frmStudentSearch.WindowState = FormWindowState.Normal;

                    this.ctlManager.SetFocusOnSearchTextBox();
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Student Enrolment History Module");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//------------------------------

        //this procedure shows the view update student Information
        private void ShowUpdateStudentInformationDialog(CommonExchange.Student studentInfo)
        {
            try
            {
                DataTable tempTable = _cashieringManager.StudentTable;

                using (StudentCashierUpdate frmUpdate = new StudentCashierUpdate(_userInfo, studentInfo, _studentManager, false, true, ref tempTable))
                {
                    _frmStudentSearch.WindowState = FormWindowState.Minimized;

                    frmUpdate.ShowDialog(this);

                    if (frmUpdate.HasUpDated)
                    {
                        _cashieringManager.StudentTable = tempTable;

                        this.ShowSearchResultDialog();
                    }

                    _frmStudentSearch.WindowState = FormWindowState.Normal;

                    this.ctlManager.SetFocusOnSearchTextBox();
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Update Student Information Module");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//----------------------
        #endregion
    }
}
