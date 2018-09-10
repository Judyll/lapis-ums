using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class AuxiliarySchedule
    {
        #region Class General Variable Declaration
        protected CommonExchange.SysAccess _userInfo;
        protected CommonExchange.AuxiliaryServiceSchedule _serviceInfoSchedule;
        protected AuxiliaryServiceLogic _auxiliaryManager;
        protected Boolean _hasErrors;
        protected Boolean _hasUpdatedDetails = false;

        private ErrorProvider _errProvider;

        private String _sysIdScheduleDetails = "";
        #endregion

        #region Class Constructors
        public AuxiliarySchedule()
        {
            this.InitializeComponent();
        }

        public AuxiliarySchedule(CommonExchange.SysAccess userInfo, AuxiliaryServiceLogic auxiliaryInfoManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _auxiliaryManager = auxiliaryInfoManager;

            _errProvider = new ErrorProvider();
            
            this.Load += new EventHandler(ClassLoad);
            this.cboYearSemester.SelectedIndexChanged += new EventHandler(cboYearSemesterSelectedIndexChanged);
            this.btnSearchAuxiliary.Click += new EventHandler(btnSearchAuxiliaryClick);
            this.lnkAddDetails.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkAddDetailsLinkClicked);
            this.dgvAuxiliaryDetails.MouseDown += new MouseEventHandler(dgvAuxiliaryDetailsMouseDown);
            this.dgvAuxiliaryDetails.DoubleClick += new EventHandler(dgvAuxiliaryDetailsDoubleClick);
            this.chkFixedAmount.CheckedChanged += new EventHandler(chkFixedAmountCheckedChanged);
            this.txtFixedAmount.KeyPress += new KeyPressEventHandler(txtFixedAmountKeyPress);
            this.txtFixedAmount.Validating += new System.ComponentModel.CancelEventHandler(txtFixedAmountValidating);
            this.txtFixedAmount.Validated += new EventHandler(txtFixedAmountValidated);
        }
        #endregion

        #region Class Event Void Procedures
        //############################################CLASS SubjectSchedule EVENTS#######################################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            if (_auxiliaryManager.MustOpenSchoolYearSemester())
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Please open another school year / semester before creating a new subject schedule.",
                   "Error Creating A Subject Schedule");

                _hasErrors = true;

                this.Close();
            }

            _serviceInfoSchedule = new CommonExchange.AuxiliaryServiceSchedule();

            this.dgvAuxiliaryDetails.DataSource = _auxiliaryManager.AuxiliaryDetailsTableFormat;
            this.dgvMarkDeleted.DataSource = _auxiliaryManager.AuxiliaryDetailsTableFormat;

            RemoteClient.ProcStatic.SetDataGridViewColumns(this.dgvAuxiliaryDetails, false);
            RemoteClient.ProcStatic.SetDataGridViewColumns(this.dgvMarkDeleted, false);
        }//---------------------------
        //############################################END CLASS SubjectSchedule EVENTS#######################################################

        //#############################################COMBOBOX cboYearSemester EVENTS#################################################
        //event is raised when the selected index is changed
        protected void cboYearSemesterSelectedIndexChanged(object sender, EventArgs e)
        {
            if (_serviceInfoSchedule.AuxiliaryServiceInfo.CourseGroupInfo.IsSemestral)
            {
                _serviceInfoSchedule.SemesterInfo.SemesterSysId = 
                    _auxiliaryManager.GetYearSemesterId(_serviceInfoSchedule.AuxiliaryServiceInfo.CourseGroupInfo.IsSemestral, ((ComboBox)sender).SelectedIndex);
            }
            else
            {
                _serviceInfoSchedule.SchoolYearInfo.YearId = 
                    _auxiliaryManager.GetYearSemesterId(_serviceInfoSchedule.AuxiliaryServiceInfo.CourseGroupInfo.IsSemestral, ((ComboBox)sender).SelectedIndex);
            }
        }//---------------------------
        //#############################################END COMBOBOX cboYearSemester EVENTS#################################################

        //##############################################BUTTON btnSearchAuxiliary EVENTS####################################################
        //event is raised when the button is clicked
        private void btnSearchAuxiliaryClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (AuxiliarySearchOnTextboxList frmSearch = new AuxiliarySearchOnTextboxList(_userInfo, _auxiliaryManager))
                {
                    frmSearch.AdoptGridSize = true;
                    frmSearch.ShowDialog(this);

                    if (frmSearch.HasSelected)
                    {
                        CommonExchange.AuxiliaryServiceInformation serviceInfo = _auxiliaryManager.GetDetailsAuxiliaryServiceInfomation(frmSearch.PrimaryId);
                        
                        _serviceInfoSchedule.AuxiliaryServiceInfo.AuxServiceSysId = serviceInfo.AuxServiceSysId;
                        _serviceInfoSchedule.AuxiliaryServiceInfo.DepartmentInfo.DepartmentId = serviceInfo.DepartmentInfo.DepartmentId;
                        _serviceInfoSchedule.AuxiliaryServiceInfo.DepartmentInfo.DepartmentName = serviceInfo.DepartmentInfo.DepartmentName;
                        _serviceInfoSchedule.AuxiliaryServiceInfo.DescriptiveTitle = serviceInfo.DescriptiveTitle;
                        _serviceInfoSchedule.AuxiliaryServiceInfo.CourseGroupInfo.IsSemestral = serviceInfo.CourseGroupInfo.IsSemestral;
                        _serviceInfoSchedule.AuxiliaryServiceInfo.LabUnits = serviceInfo.LabUnits;
                        _serviceInfoSchedule.AuxiliaryServiceInfo.LectureUnits = serviceInfo.LectureUnits;
                        _serviceInfoSchedule.AuxiliaryServiceInfo.NoHours = serviceInfo.NoHours;
                        _serviceInfoSchedule.AuxiliaryServiceInfo.ServiceCode = serviceInfo.ServiceCode;

                        lblSysIdAuxiliary.Text  = serviceInfo.AuxServiceSysId;
                        lblAuxiliaryCodeDescription.Text = serviceInfo.ServiceCode + " - " + serviceInfo.DescriptiveTitle;
                        lblAuxiliaryDepartment.Text = serviceInfo.DepartmentInfo.DepartmentName;
                        lblUnitsLabHours.Text = _auxiliaryManager.GetAuxiliaryUnitsHours(serviceInfo.LectureUnits, serviceInfo.LabUnits, serviceInfo.NoHours);

                        _auxiliaryManager.InitializeSchoolYearSemesterCombo(this.cboYearSemester, serviceInfo.CourseGroupInfo.IsSemestral);

                        this.tabAuxiliary.Enabled = true;
                    }

                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Auxiliary Service Infomation Search Module");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//------------------------
        //##############################################END BUTTON btnSearchSubject EVENTS####################################################

        //##############################################LINK LABEL lblAddDetails EVENTS####################################################
        //event is raised when the control is clicked
        private void lnkAddDetailsLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (AuxiliaryScheduleDetailsCreate frmCreate = new AuxiliaryScheduleDetailsCreate(_userInfo, _serviceInfoSchedule, _auxiliaryManager))
                {
                    frmCreate.ShowDialog(this);

                    if (frmCreate.HasCreated)
                    {
                        _hasUpdatedDetails = true;

                        this.dgvAuxiliaryDetails.DataSource = 
                            _auxiliaryManager.GetBySysIdAuxiliaryServiceDetailsTable(_serviceInfoSchedule.AuxServiceScheduleSysId, false);
                        this.dgvMarkDeleted.DataSource = 
                            _auxiliaryManager.GetBySysIdAuxiliaryServiceDetailsTable(_serviceInfoSchedule.AuxServiceScheduleSysId, true);

                        this.btnSearchAuxiliary.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Auxiliary Service Details Create Module");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//----------------------------
        //##############################################END LINK LABEL lblAddDetails EVENTS####################################################

        //##############################################DATAGRIDVIEW dgvAuxiliaryDetails EVENTS####################################################
        //event is raised when dgvAuxiliaryDetails MouseDown
        private void dgvAuxiliaryDetailsMouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTest = dgvAuxiliaryDetails.HitTest(e.X, e.Y);

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
                    _sysIdScheduleDetails = "";
                    break;
            }

            if (rowIndex != -1)
            {
                _sysIdScheduleDetails = dgvAuxiliaryDetails[0, rowIndex].Value.ToString();
            }
        }//--------------------------

        //event is raised when the control is double clicked
        private void dgvAuxiliaryDetailsDoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!String.IsNullOrEmpty(_sysIdScheduleDetails))
                {
                    using (AuxiliaryScheduleDetailsUpdate frmUpdate = new AuxiliaryScheduleDetailsUpdate(_userInfo, _serviceInfoSchedule, 
                        _auxiliaryManager.GetDetailsAuxiliaryScheduleDetails(_sysIdScheduleDetails), _auxiliaryManager))
                    {
                        frmUpdate.ShowDialog(this);

                        if (frmUpdate.HasUpdated || frmUpdate.HasDeleted)
                        {
                            _hasUpdatedDetails = true;

                            this.dgvAuxiliaryDetails.DataSource =
                                _auxiliaryManager.GetBySysIdAuxiliaryServiceDetailsTable(_serviceInfoSchedule.AuxServiceScheduleSysId, false);
                            this.dgvMarkDeleted.DataSource = 
                                _auxiliaryManager.GetBySysIdAuxiliaryServiceDetailsTable(_serviceInfoSchedule.AuxServiceScheduleSysId, true);                                                        
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Subject Schedule Details Module");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//----------------------------
        //##############################################END DATAGRIDVIEW dgvAuxiliaryDetails EVENTS####################################################

        //##############################################CHECKEDBOX chkFixedAmount EVENTS####################################################
        //event is raised when the checked changed
        private void chkFixedAmountCheckedChanged(object sender, EventArgs e)
        {
            _serviceInfoSchedule.IsFixedAmount = this.chkFixedAmount.Checked;

            if (_serviceInfoSchedule.IsFixedAmount)
            {
                this.txtFixedAmount.Enabled = true;
                this.txtFixedAmount.Focus();
            }
            else
            {
                this.txtFixedAmount.Enabled = false;

                Decimal amount;

                if (Decimal.TryParse(txtFixedAmount.Text, out amount) && _serviceInfoSchedule.IsFixedAmount)
                {
                    _serviceInfoSchedule.Amount = amount;
                }

                this.txtFixedAmount.Text = _serviceInfoSchedule.Amount.ToString("N");
            }
        }//--------------------------
        //#############################################END CHECKEDBOX chkFixedAmount EVENTS####################################################

        //##############################################TEXTBOX txtFixedAmount EVENTS####################################################
        //event is raised when the textbox keypress
        private void txtFixedAmountKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxAmountOnly(e);
        }//---------------------------

        //event is raised when the textbox is validating
        private void txtFixedAmountValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxValidateAmount((TextBox)sender);
        }//----------------------------

        //event is raised when the textbox is validated
        private void txtFixedAmountValidated(object sender, EventArgs e)
        {
            Decimal amount;

            if (Decimal.TryParse(txtFixedAmount.Text, out amount) && _serviceInfoSchedule.IsFixedAmount)
            {
               _serviceInfoSchedule.Amount = amount;
            }
        }//----------------------

        //##############################################END TEXTBOX txtFixedAmount EVENTS####################################################
        #endregion

        #region Programer-Defined Funtions

        //this function determines if the controls are validated
        protected Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.cboYearSemester, "");
            _errProvider.SetError(this.btnSearchAuxiliary, "");
            _errProvider.SetError(this.lnkAddDetails, "");
           
            if (cboYearSemester.SelectedIndex == -1)
            {
                _errProvider.SetIconAlignment(this.cboYearSemester, ErrorIconAlignment.MiddleRight);
                _errProvider.SetError(this.cboYearSemester, "Please select a school year / semester the schedule information is enrolled.");
                isValid = false;
            }

            if (String.IsNullOrEmpty(_serviceInfoSchedule.AuxiliaryServiceInfo.AuxServiceSysId))
            {
                _errProvider.SetIconAlignment(this.btnSearchAuxiliary, ErrorIconAlignment.MiddleLeft);
                _errProvider.SetError(this.btnSearchAuxiliary, "Please select a subject for the schedule information.");
                isValid = false;
            }

            if (dgvAuxiliaryDetails.Rows.Count <= 0)
            {
                _errProvider.SetIconAlignment(this.lnkAddDetails, ErrorIconAlignment.MiddleLeft);
                _errProvider.SetError(this.lnkAddDetails, "There must be at least one schedule details.");
                isValid = false;

                this.tabAuxiliary.SelectedIndex = 0;
            }

            return isValid;
        } //------------------------

        #endregion
    }
}
