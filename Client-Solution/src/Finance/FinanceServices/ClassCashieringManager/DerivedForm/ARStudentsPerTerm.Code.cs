using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class ARStudentsPerTerm
    {

        #region Class Data Member Decleration
        private ErrorProvider _errProvider;
        #endregion

        #region Class Constructors
        public ARStudentsPerTerm(CommonExchange.SysAccess userInfo, CashieringLogic cashieringManager)
            : base(userInfo, cashieringManager)
        {
            this.InitializeComponent();

            _errProvider = new ErrorProvider();
        }
        #endregion

        #region Class Event Void Procedures
        //###########################################BUTTON btnGenerateReport EVENTS#####################################################
        //event is raised when the control link is clicked
        protected override void btnGenerateReportClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.ValidateControls())
                {
                    String sem = String.Empty;

                    sem = this.cboSemester.SelectedIndex != -1 ? " - " + this.cboSemester.Text : String.Empty;

                    _cashieringManager.PrintPerTermStudentAccountsReceivable(_userInfo, this.cbxCourse, this.cbxYearLevel, this.progressBar,
                        this.cboYear.Text + sem, _dateStart, _dateEnd, this.dtpCutOfDate.Value.ToShortDateString() + " 11:59:59 PM", _isSemestral);

                    this.progressBar.Value = 0;
                }

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error");
            }
        }//---------------------------------
        #endregion

        #region Programmer's Defined Functions
        //this function will determine if the cutOfDAte is valid (VAlidate Controls)
        private Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.dtpCutOfDate, String.Empty);

            if ((DateTime.Compare(DateTime.Parse(_dateStart), this.dtpCutOfDate.Value) > 0) ||
                (DateTime.Compare(DateTime.Parse(_dateEnd), this.dtpCutOfDate.Value) < 0))
            {
                _errProvider.SetError(this.dtpCutOfDate, "The selected Cut-Off Date is Invalid.");
                _errProvider.SetIconAlignment(this.dtpCutOfDate, ErrorIconAlignment.MiddleRight);
                isValid = false;
            }

            return isValid;
        }//-------------------------

        #endregion
    }
}
