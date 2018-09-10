using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RemoteClient
{
    public delegate void ControlCashieringManagerCloseButtonClick();
    public delegate void ControlCashieringManagerRefreshButtonClick();
    public delegate void ControlCashieringManagerAdditionalFeeButtonClick();
    public delegate void ControlCashieringManagerMiscellaneousIncomeClick();
    public delegate void ControlCashieringManagerTextBoxSearchKeyUp(object sender, KeyEventArgs e);
    public delegate void ControlCashieringManagerPressEnter(object sender, KeyEventArgs e);
    public delegate void ControlCashieringManagerScholarshipDiscountsLinkClicked();
    public delegate void ControlCashieringManagerCashDiscountsLinkClicked();
    public delegate void ControlCashieringManagerCreditMemoLinkClicked();
    public delegate void ControlCashieringManagerFeesRegisterDetailedLinkClicked();
    public delegate void ControlCashieringManagerFeesRegisterSummarizedLinkClicked();
    public delegate void ControlCashieringManagerARStudentPerTermLinkClicked();
    public delegate void ControlCashieringManagerARStudentPerFiscalYearLinkClicked();
    public delegate void ControlCashieringManagerCashReceiptsDetailedLinkClicked();
    public delegate void ControlCashieringManagerCashReceiptsSummarizedLinkClicked();
    public delegate void ControlCashieringManagerCashReceiptsQueryLinkClicked();
    public delegate void ControlCashieringManagerReceiptNoTextBoxValidated();
    public delegate void ControlCashieringManagerDecrementLinkClicked();
    public delegate void ControlCashieringManagerIncrementLinkClicked();
    public delegate void ControlCashieringManagerCancelReceiptLinkClicked(Int32 receiptNo);
    public delegate void ControlCashieringManagerViewCancelledReceiptLinkClicked();
    public delegate void ControlCashieringManagerReceiptDateValueChanged(DateTime d);

    partial class ControlCashieringManager
    {
        #region Class Event Declarations
        public event ControlCashieringManagerCloseButtonClick OnClose;
        public event ControlCashieringManagerRefreshButtonClick OnRefresh;
        public event ControlCashieringManagerAdditionalFeeButtonClick OnAdditionalFee;
        public event ControlCashieringManagerMiscellaneousIncomeClick OnMiscellaneousIncome;
        public event ControlCashieringManagerTextBoxSearchKeyUp OnTextBoxKeyUp;
        public event ControlCashieringManagerPressEnter OnPressEnter;
        public event ControlCashieringManagerScholarshipDiscountsLinkClicked OnScholarshipDiscountsLinkClicked;
        public event ControlCashieringManagerCashDiscountsLinkClicked OnCashDiscountsLinkClicked;
        public event ControlCashieringManagerCreditMemoLinkClicked OnCreditMemoLinkClicked;
        public event ControlCashieringManagerFeesRegisterDetailedLinkClicked OnFeesRegisterDetailedLinkClicked;
        public event ControlCashieringManagerFeesRegisterSummarizedLinkClicked OnFeesRegisterSummarizedLinkClicked;
        public event ControlCashieringManagerARStudentPerTermLinkClicked OnARStudentPerTermLinkClicked;
        public event ControlCashieringManagerARStudentPerFiscalYearLinkClicked OnARStudentPerFiscalYearLinkClicked;
        public event ControlCashieringManagerCashReceiptsDetailedLinkClicked OnCashReceiptsDetailedLinkClicked;
        public event ControlCashieringManagerCashReceiptsSummarizedLinkClicked OnCashReceiptsSummarizedLinkClicked;
        public event ControlCashieringManagerCashReceiptsQueryLinkClicked OnCashReceiptsQueryLinkClicked;
        public event ControlCashieringManagerReceiptNoTextBoxValidated OnReceiptNoTextBoxValidated;
        public event ControlCashieringManagerDecrementLinkClicked OnDecrementLinkClicked;
        public event ControlCashieringManagerIncrementLinkClicked OnIncrementLinkClicked;
        public event ControlCashieringManagerCancelReceiptLinkClicked OnCancelReceiptLinkClicked;
        public event ControlCashieringManagerViewCancelledReceiptLinkClicked OnViewCancelledReceiptLinkClicked;
        public event ControlCashieringManagerReceiptDateValueChanged OnReceiptDateValueChanged;
        #endregion

        #region Class Member Declarations
        protected ToolTip ttpMain = new ToolTip();
        #endregion

        #region Class Properties Declarations
        private Boolean _isStudentTabSearch = false;
        public Boolean IsStudentTabSearch
        {
            get { return _isStudentTabSearch; }
            set { _isStudentTabSearch = value; }
        }

        protected String _strSearch;
        public String GetSearchString
        {
            get { return _strSearch; }
        }

        public Int32 ReceiptNo
        {
            get 
            {
                Int32 result;

                if (Int32.TryParse(this.txtReceiptNo.Text, out result))
                {
                    return result;
                }

                return 0;
            }
            set 
            {
                this.txtReceiptNo.Text = ProcStatic.SixDigitZero(value);
            }
        }

        public DateTime ReceiptDate
        {
            get { return this.dtpReceiptDate.Value; }
            set { this.dtpReceiptDate.Value = value; }
        }

        #endregion

        #region Class Constructor
        public ControlCashieringManager()
        {            
            this.InitializeComponent();

            this.pbxClose.Click += new EventHandler(pbxCloseClick);
            this.pbxRefresh.Click += new EventHandler(pbxRefreshClick);
            this.pbxAdditionalFee.Click += new EventHandler(pbxAdditionalFeeClick);
            this.pbxMiscellaneousIncome.Click += new EventHandler(pbxMiscellaneousIncomeClick);
            this.txtStudentTab.KeyPress += new KeyPressEventHandler(TextBoxSearchKeyPress);
            this.txtStudentTab.KeyUp += new KeyEventHandler(txtStudentTabKeyUp);
            this.lnkScholarshipDiscounts.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkScholarshipDiscountsLinkClicked);
            this.lnkCashDiscounts.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkCashDiscountsLinkClicked);
            this.lnkCreditMemo.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkCreditMemoLinkClicked);
            this.lnkRegisterDetailed.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkRegisterDetailedLinkClicked);
            this.lnkRegisterSummarized.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkRegisterSummarizedLinkClicked);
            this.lnkARStudentPerTerm.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkARStudentPerTermLinkClicked);
            this.lnkARStudentPerFiscalYear.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkARStudentPerFiscalYearLinkClicked);
            this.lnkCashReceiptsDetailed.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkCashReceiptsDetailedLinkClicked);
            this.lnkCashReceiptsSummarized.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkCashReceiptsSummarizedLinkClicked);
            this.lnkCashReceiptsQuery.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkCashReceiptsQueryLinkClicked);
            this.txtReceiptNo.KeyPress += new KeyPressEventHandler(txtReceiptNoKeyPress);
            this.txtReceiptNo.Validated += new EventHandler(txtReceiptNoValidated);
            this.lnkDecrement.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkDecrementLinkClicked);
            this.lnkIncrement.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkIncrementLinkClicked);
            this.lnkCancelReceipt.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkCancelReceiptLinkClicked);
            this.lnkViewCancel.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkViewCancelLinkClicked);
            this.dtpReceiptDate.ValueChanged += new EventHandler(dtpReceiptDateValueChanged);
        }

        #endregion

        #region Class Event Void Procedures

        //################################CLASS ControlManager EVENTS########################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            base.ClassLoad(sender, e);

            _maxHeight = this.Size.Height;

            ttpMain.ToolTipIcon = ToolTipIcon.Info;
            ttpMain.ToolTipTitle = "Console";
            ttpMain.UseAnimation = true;
            ttpMain.UseFading = true;
            ttpMain.IsBalloon = true;
            ttpMain.AutoPopDelay = 3000;
            ttpMain.SetToolTip(this.pbxClose, "Close");
            ttpMain.SetToolTip(this.pbxRefresh, "Refresh");
            ttpMain.SetToolTip(this.pbxAdditionalFee, "Additional Fees");
            ttpMain.SetToolTip(this.pbxMiscellaneousIncome, "Miscellaneous Income");

            this.dtpReceiptDate.Format = DateTimePickerFormat.Custom;
            //this.dateTimePicker1.CustomFormat = "(ddd)  MMM dd, yyyy   hh:mm tt";
            this.dtpReceiptDate.CustomFormat = "<dddd> MMM dd, yyyy";
            
        }
        //################################END CLASS ControlManager EVENTS#####################################

        //#################################PICTUREBOX pbxClose EVENTS########################################
        //event is raised when the control is clicked
        private void pbxCloseClick(object sender, EventArgs e)
        {
            ControlCashieringManagerCloseButtonClick ev = OnClose;

            if (ev != null)
            {
                OnClose();
            }

        } //----------------------------
        //##############################END PICTUREBOX pbxClose EVENTS#######################################

        //##################################PICTUREBOX pbxRefresh EVENTS#######################################
        //event is raised when the control is clicked
        private void pbxRefreshClick(object sender, EventArgs e)
        {
            ControlCashieringManagerRefreshButtonClick ev = OnRefresh;

            if (ev != null)
            {
                OnRefresh();
            }

            this.SetFocusOnSearchTextBox();
        } //--------------------------------
        //################################END PICTUREBOX pbxRefresh EVENTS#####################################

        //#####################################PICTUREBOX pbxAdditionalFee EVENTS################################
        //event is raised when the control is clicked
        private void pbxAdditionalFeeClick(object sender, EventArgs e)
        {
            ControlCashieringManagerAdditionalFeeButtonClick ev = OnAdditionalFee;

            if (ev != null)
            {
                OnAdditionalFee();
            }

            this.SetFocusOnSearchTextBox();
            
        } //-------------------------------
        //##################################END PICTUREBOX pbxAdditionalFee EVENTS################################

        //##################################PICTUREBOX pbxMiscellaneousIncome EVENTS#####################################
        //event is raised when the control is clicked
        private void pbxMiscellaneousIncomeClick(object sender, EventArgs e)
        {
            ControlCashieringManagerMiscellaneousIncomeClick ev = OnMiscellaneousIncome;

            if (ev != null)
            {
                OnMiscellaneousIncome();
            }

            this.SetFocusOnSearchTextBox();
        }//-------------------------------------------

        //################################END PICTUREBOX pbxMiscellaneousIncome EVENTS#####################################

        //###################################TEXTBOX EVENTS##########################################
        //event is raised when the key is pressed
        private void TextBoxSearchKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) &&
                !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '*' && e.KeyChar != '\r' && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        } //---------------------------------
        //#################################END TEXTBOX EVENTS########################################

        //####################################TEXTBOX txtStudentTab EVENTS##################################
        //event is raised when the key is up
        private void txtStudentTabKeyUp(object sender, KeyEventArgs e)
        {
            _strSearch = ((TextBox)sender).Text;
            _isStudentTabSearch = true;

            if (e.KeyCode == Keys.Enter)
            {
                ControlCashieringManagerPressEnter ev = OnPressEnter;

                if (ev != null)
                {
                    OnPressEnter(sender, e);
                }
            }
            else
            {
                ControlCashieringManagerTextBoxSearchKeyUp ev = OnTextBoxKeyUp;

                if (ev != null)
                {
                    OnTextBoxKeyUp(sender, e);
                }
            }
        }
        //################################END TEXTBOX txtStudentTab EVENTS#####################################


        //######################################LINKLABEL lnkIssuedDiscounts EVENTS############################
        //event is raised when the link is clicked
        private void lnkScholarshipDiscountsLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ControlCashieringManagerScholarshipDiscountsLinkClicked ev = OnScholarshipDiscountsLinkClicked;

            if (ev != null)
            {
                OnScholarshipDiscountsLinkClicked();
            }

            this.SetFocusOnSearchTextBox();
        }
        //######################################END LINKLABEL lnkIssuedDiscounts EVENTS############################

        //#####################################LINKLABEL lnkCashDiscounts EVENTS####################################
        //event is raised when the link is clicked
        private void lnkCashDiscountsLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ControlCashieringManagerCashDiscountsLinkClicked ev = OnCashDiscountsLinkClicked;

            if (ev != null)
            {
                OnCashDiscountsLinkClicked();
            }

            this.SetFocusOnSearchTextBox();
        }  
        //###################################END LINKLABEL lnkCashDiscounts EVENTS###################################


        //####################################LINKLABEL lnkCreditMemo EVENTS########################################
        //event is raised when the link is clicked
        private void lnkCreditMemoLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ControlCashieringManagerCreditMemoLinkClicked ev = OnCreditMemoLinkClicked;

            if (ev != null)
            {
                OnCreditMemoLinkClicked();
            }

            this.SetFocusOnSearchTextBox();
        }
        //####################################END LINKLABEL lnkCreditMemo EVENTS########################################

        //######################################LINKLABEL lnkRegisterDetailed EVENTS#####################################
        //event is raised when the link is clicked
        private void lnkRegisterDetailedLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ControlCashieringManagerFeesRegisterDetailedLinkClicked ev = OnFeesRegisterDetailedLinkClicked;

            if (ev != null)
            {
                OnFeesRegisterDetailedLinkClicked();
            }

            this.SetFocusOnSearchTextBox();
        } //----------------------------------------------
        //####################################END LINKLABEL lnkRegisterDetailed EVENTS#####################################

        //#######################################LINKLABEL lnkRegisterSummarized EVENTS#####################################
        //event is raised when the link is clicked
        private void lnkRegisterSummarizedLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ControlCashieringManagerFeesRegisterSummarizedLinkClicked ev = OnFeesRegisterSummarizedLinkClicked;

            if (ev != null)
            {
                OnFeesRegisterSummarizedLinkClicked();
            }

            this.SetFocusOnSearchTextBox();
        } //---------------------------------------------
        //#####################################END LINKLABEL lnkRegisterSummarized EVENTS#####################################


        //########################################LINKLABEL lnkARStudentPerTerm EVENTS###########################################
        //event is raised when the link is clicked
        private void lnkARStudentPerTermLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ControlCashieringManagerARStudentPerTermLinkClicked ev = OnARStudentPerTermLinkClicked;

            if (ev != null)
            {
                OnARStudentPerTermLinkClicked();
            }

            this.SetFocusOnSearchTextBox();
        } //----------------------------------------------------
        //######################################END LINKLABEL lnkARStudentPerTerm EVENTS#########################################

        //########################################LINKLABEL lnkARStudentPerFiscalYear EVENTS############################################
        //event is raised when the link is clicked
        private void lnkARStudentPerFiscalYearLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ControlCashieringManagerARStudentPerFiscalYearLinkClicked ev = OnARStudentPerFiscalYearLinkClicked;

            if (ev != null)
            {
                OnARStudentPerFiscalYearLinkClicked();
            }

            this.SetFocusOnSearchTextBox();
        } //-----------------------------------------------
        //######################################END LINKLABEL lnkARStudentPerFiscalYear EVENTS##########################################

        //########################################LINKLABEL lnkCashReceiptsDetailed EVENTS#######################################
        //event is raised when the link is clicked
        private void lnkCashReceiptsDetailedLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ControlCashieringManagerCashReceiptsDetailedLinkClicked ev = OnCashReceiptsDetailedLinkClicked;

            if (ev != null)
            {
                OnCashReceiptsDetailedLinkClicked();
            }

            this.SetFocusOnSearchTextBox();
        } //---------------------------------------------------
        //#######################################END LINKLABEL lnkCashReceiptsDetailed EVENTS####################################

        //########################################LINKLABEL lnkCashReceiptsSummarized EVENTS######################################
        //event is raised when the link is clicked
        private void lnkCashReceiptsSummarizedLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ControlCashieringManagerCashReceiptsSummarizedLinkClicked ev = OnCashReceiptsSummarizedLinkClicked;

            if (ev != null)
            {
                OnCashReceiptsSummarizedLinkClicked();
            }

            this.SetFocusOnSearchTextBox();
        } //---------------------------------------    
        //######################################END LINKLABEL lnkCashReceiptsSummarized EVENTS####################################

        //###############################################LINKLABEL lnkCashReceiptsQuery EVENTS#####################################
        //event is raised when the link is clicked
        private void lnkCashReceiptsQueryLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ControlCashieringManagerCashReceiptsQueryLinkClicked ev = OnCashReceiptsQueryLinkClicked;

            if (ev != null)
            {
                OnCashReceiptsQueryLinkClicked();
            }

            this.SetFocusOnSearchTextBox();
        } //----------------------------------------------
        //############################################END LINKLABEL lnkCashReceiptsQuery EVENTS#####################################

        //#########################################TEXTBOX txtReceiptNo EVENTS###################################################
        //event is raised when the key is pressed
        private void txtReceiptNoKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;                
            }
        } //-----------------------------------

        //event is raised when the control is validated
        private void txtReceiptNoValidated(object sender, EventArgs e)
        {
            Int32 result;

            if (Int32.TryParse(this.txtReceiptNo.Text, out result) && result < Int32.MaxValue)
            {
                this.txtReceiptNo.Text = ProcStatic.SixDigitZero(result);
            }
            else
            {
                this.txtReceiptNo.Text = ProcStatic.SixDigitZero(0);
            }

            ControlCashieringManagerReceiptNoTextBoxValidated ev = OnReceiptNoTextBoxValidated;

            if (ev != null)
            {
                OnReceiptNoTextBoxValidated();
            }

            
        } //----------------------------------
        //######################################END TEXTBOX txtReceiptNo EVENTS#################################################

        //########################################LINKLABEL lnkDecrement EVENTS#################################################
        //event is raised when the link is clicked
        private void lnkDecrementLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SetCurrentReceiptNo(false);

            ControlCashieringManagerDecrementLinkClicked ev = OnDecrementLinkClicked;

            if (ev != null)
            {
                OnDecrementLinkClicked();
            }
            
        } //-----------------------------------------------
        //######################################END LINKLABEL lnkDecrement EVENTS###############################################

        //########################################LINKLABEL lnkIncrement EVENTS#################################################
        //event is raised when the linked is clicked
        private void lnkIncrementLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SetCurrentReceiptNo(true);

            ControlCashieringManagerIncrementLinkClicked ev = OnIncrementLinkClicked;

            if (ev != null)
            {
                OnIncrementLinkClicked();
            }

        } //--------------------------------------------
        //######################################END LINKLABEL lnkIncrement EVENTS################################################

        //##########################################LINKLABEL lnkCancelReceipt EVENTS#############################################
        //event is raised when the linked is clicked
        private void lnkCancelReceiptLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Int32 result;

            if (Int32.TryParse(this.txtReceiptNo.Text, out result))
            {
                ControlCashieringManagerCancelReceiptLinkClicked ev = OnCancelReceiptLinkClicked;

                if (ev != null)
                {
                    OnCancelReceiptLinkClicked(result);
                }
            }
        } //--------------------------------------
        //########################################END LINKLABEL lnkCancelReceipt EVENTS###########################################

        //###########################################LINKLABEL lnkViewCancel EVENTS##################################################
        //event is raised when the linked is clicked
        private void lnkViewCancelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ControlCashieringManagerViewCancelledReceiptLinkClicked ev = OnViewCancelledReceiptLinkClicked;

            if (ev != null)
            {
                OnViewCancelledReceiptLinkClicked();
            }
        } //-----------------------------------------
        //##########################################END LINKLABEL lnkViewCancel EVENTS###############################################


        //#########################################DATETIMEPICKER dtpReceiptDate EVENTS##############################################
        //event is raised when the value is changed
        private void dtpReceiptDateValueChanged(object sender, EventArgs e)
        {
            ControlCashieringManagerReceiptDateValueChanged ev = OnReceiptDateValueChanged;

            if (ev != null)
            {
                OnReceiptDateValueChanged(this.dtpReceiptDate.Value);
            }
        } //-----------------------------------------
        //#########################################END DATETIMEPICKER dtpReceiptDate EVENTS##############################################

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure sets the current receipt as already issued
        public void SetCurrentReceiptNo(Boolean forIncrement)
        {
            Int32 result;

            if (Int32.TryParse(this.txtReceiptNo.Text, out result))
            {
                this.txtReceiptNo.Text = forIncrement ? ProcStatic.SixDigitZero(((result + 1) >= Int32.MaxValue) ? result : (result + 1)) : 
                    ProcStatic.SixDigitZero(((result - 1) < 0) ? result : (result - 1));
            }
            else
            {
                this.txtReceiptNo.Text = ProcStatic.SixDigitZero(0);
            }
        } //-------------------------------------

        //this procedure sets the focus on search textbox
        public void SetFocusOnSearchTextBox()
        {
            if (_isStudentTabSearch)
            {
                this.txtStudentTab.Focus();
            }
        } //----------------------------

        #endregion
    }
}
