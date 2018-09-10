using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class MultipleAdditionalFeeCreate
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private CommonExchange.StudentAdditionalFee _additionalFeeInfo;
        private CommonExchange.StudentAdditionalFee _additionalFeeInfoTemp;
        private CashieringLogic _cashieringManager;

        private String _dateStart = String.Empty;
        private String _dateEnd = String.Empty;
        private String _primaryId = "";

        private Boolean _hasRecorded = false;
        private Boolean _isChecked = false;

        private Int32 _selected = 0;
        private Int32 _primaryIndex = 0;
        private Int32 _rowIndex = -1;

        private ErrorProvider _errProvider;
        #endregion

        #region Class Constructors
        public MultipleAdditionalFeeCreate(CommonExchange.SysAccess userInfo, CashieringLogic cashieringManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _cashieringManager = cashieringManager;

            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.ctlPayment.OnClose += new RemoteClient.ControlManagerCloseButtonClick(ctlPaymentOnClose);
            this.ctlPayment.OnRefresh += new RemoteClient.ControlManagerRefreshButtonClick(ctlPaymentOnRefresh);
            this.ctlPayment.OnTextBoxKeyUp += new RemoteClient.ControlManagerTextBoxSearchKeyUp(ctlPaymentOnTextBoxKeyUp);
            this.ctlPayment.OnPressEnter += new RemoteClient.ControlAdditionalFeeManagerPressEnter(ctlPaymentOnPressEnter);
            this.ctlPayment.OnSchoolYearSelectedIndexChanged += 
                new RemoteClient.ControlAdditionalFeeManagerSchoolYearSelectedIndexChanged(ctlPaymentOnSchoolYearSelectedIndexChanged);
            this.ctlPayment.OnSemesterSelectedIndexChanged += 
                new RemoteClient.ControlAdditionalFeeManagerSemesterSelectedIndexChanged(ctlPaymentOnSemesterSelectedIndexChanged);
            this.ctlPayment.OnCourseSelectedIndexChanged += 
                new RemoteClient.ControlAdditionalFeeManagerCheckedListBoxSelectedIndexChanged(ctlPaymentOnCourseLevelSelectedIndexChanged);
            this.ctlPayment.OnYearLevelSelectedIndexChanged += 
                new RemoteClient.ControlAdditionalFeeManagerCheckedListBoxSelectedIndexChanged(ctlPaymentOnCourseLevelSelectedIndexChanged);
            this.ctlPayment.OnResetLinkClicked += new RemoteClient.ControlAdditionalFeeManagerResetQueryLinkClicked(ctlPaymentOnResetLinkClicked);
            this.ctlPayment.OnModeOptionCheckedChanged += 
                new RemoteClient.ControlAdditionalFeeManagerModeOptionCheckedChanged(ctlPaymentOnModeOptionCheckedChanged);
            this.dgvList.CellContentClick += new DataGridViewCellEventHandler(dgvListCellContentClick);
            this.dgvList.MouseDown += new MouseEventHandler(dgvListMouseDown);
            this.dgvList.MouseDoubleClick += new MouseEventHandler(dgvListDoubleClick);
            this.dgvList.DataSourceChanged += new EventHandler(dgvListDataSourceChanged);
            this.dgvList.SelectionChanged += new EventHandler(dgvListSelectionChanged);
            this.txtAmount.KeyPress += new KeyPressEventHandler(txtAmountKeyPress);
            this.txtAmount.Validating += new System.ComponentModel.CancelEventHandler(txtAmountValidating);
            this.txtAmount.Validated += new EventHandler(txtAmountValidated);
            this.txtAdditionalFeeRemarks.Validated += new EventHandler(txtAdditionalFeeRemarksValidated);
            this.pbxChecked.Click += new EventHandler(pbxCheckedClick);
            this.btnSearchAdditionalFee.Click += new EventHandler(btnSearchAdditionalFeeClick);
            this.btnRecord.Click += new EventHandler(btnRecordClick);
        } 
        #endregion

        #region Class Event Void Procedure
        //###############################################CLASS MultipleAdditionalPaymentCreate EVENTS##################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            dgvList.DataSource = _cashieringManager.StudentTableFormatIsForApply;
            RemoteClient.ProcStatic.SetDataGridViewColumns(dgvList, false);

            _additionalFeeInfo = new CommonExchange.StudentAdditionalFee();
            _additionalFeeInfoTemp = (CommonExchange.StudentAdditionalFee)_additionalFeeInfo.Clone();            

            this.ctlPayment.SchoolYearComboBox.Enabled = false;
            this.ctlPayment.DisableMoveCapability();

            _cashieringManager.InitializeSchoolYearCombo(this.ctlPayment.SchoolYearComboBox);
            _cashieringManager.InitializeCourseCheckedListBox(this.ctlPayment.CourseCheckedListBox);
            _cashieringManager.InitializeYearLevelCheckedListBox(this.ctlPayment.YearLevelCheckedListBox);

            this.ctlPayment.Select();
            this.ctlPayment.SetFocusOnSearchTextBox();
        }//------------------

        //event is raised when the class is closed
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasRecorded && !_additionalFeeInfo.Equals(_additionalFeeInfoTemp))
            {
                String strMsg = "There has been changes made in the multiple additional fee module. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//--------------------------
        //###############################################END CLASS MultipleAdditionalPaymentCreate EVENTS##################################################

        //############################################CONTROLCLASSROOMSUBJECTMANAGER ctlPayment EVENTS##########################################
        //event is raised when the button is click
        private void ctlPaymentOnClose()
        {
            _cashieringManager.ClearCachedData();

            this.Close();
        }//-------------------

        //event is raised when the button is click
        private void ctlPaymentOnRefresh()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _cashieringManager.RefreshData(_userInfo);

                this.ShowSearchResultDialog();
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Refreshing Student's Data Manager");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//-------------------

        //event is raised when the key is up
        private void ctlPaymentOnTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (String.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(ctlPayment.GetSearchString)))
            {
                this.ctlPayment.SetFocusOnSearchTextBox();
            }
        }//-----------------------

        //event is raised when the enter key is press
        private void ctlPaymentOnPressEnter(object sender, KeyEventArgs e)
        {
            this.ShowSearchResultDialog();
        }//-----------------------

        //event is raised whent the selected index is changed
        private void ctlPaymentOnSchoolYearSelectedIndexChanged()
        {
            _dateStart = _cashieringManager.GetSchoolYearDateStart(_cashieringManager.GetSchoolYearYearId(this.ctlPayment.SchoolYearComboBox.SelectedIndex)).ToShortDateString()
                + " 12:00:00 AM";
            _dateEnd = _cashieringManager.GetSchoolYearDateEnd(_cashieringManager.GetSchoolYearYearId(this.ctlPayment.SchoolYearComboBox.SelectedIndex)).ToShortDateString()
                + " 11:59:59 PM";

            _cashieringManager.InitializeSemesterCombo(this.ctlPayment.SemesterComboBox, this.ctlPayment.SchoolYearComboBox.SelectedIndex);

            this.ShowSearchResultDialog();
        }//-------------------

        //event is raised when the selected index is changed
        private void ctlPaymentOnSemesterSelectedIndexChanged()
        {
            _dateStart = _cashieringManager.GetSemesterDateStart(_cashieringManager.GetSemesterSystemId(this.ctlPayment.SchoolYearComboBox.SelectedIndex,
               this.ctlPayment.SemesterComboBox.SelectedIndex)).ToShortDateString() + " 12:00:00 AM";
            _dateEnd = _cashieringManager.GetSemesterDateEnd(_cashieringManager.GetSemesterSystemId(this.ctlPayment.SchoolYearComboBox.SelectedIndex,
                this.ctlPayment.SemesterComboBox.SelectedIndex)).ToShortDateString() + " 11:59:59 PM";

            _additionalFeeInfo = new CommonExchange.StudentAdditionalFee();
            this.lblParticularDescription.Text = "-";
            this.txtAmount.Clear();
            this.txtAdditionalFeeRemarks.Clear();

            this.ShowSearchResultDialog();

            if (this.ctlPayment.IsForApply)
                this.IsRecordLocked();
        }//----------------------

        //event is raised when the selected index is changed
        private void ctlPaymentOnCourseLevelSelectedIndexChanged()
        {
            this.ShowSearchResultDialog();
        }//-------------------------

        //event is raised whent the control is clicked
        private void ctlPaymentOnResetLinkClicked()
        {
            this.ResetQuery();
        }//------------------------

        //event is raised when the mode is changed
        private void ctlPaymentOnModeOptionCheckedChanged(bool forApply)
        {
            this.gbxAdditionalPayment.Visible = this.btnRecord.Visible = this.ctlPayment.IsForApply ? true : false;

            _errProvider.SetError(this.lblParticularDescription, "");
            _errProvider.SetError(this.txtAmount, "");
            _errProvider.SetError(this.pbxChecked, "");

            _additionalFeeInfo = new CommonExchange.StudentAdditionalFee();

            this.txtAmount.Text = String.Empty;
            this.lblParticularDescription.Text = "-";

            if (!String.IsNullOrEmpty(this.ctlPayment.GetSearchString))
                this.ShowSearchResultDialog();

            _selected = 0;

            this.lblSelected.Text = _selected.ToString();  
         
            _dateStart = _dateEnd = String.Empty;

            this.ctlPayment.SemesterComboBox.Items.Clear();

            _cashieringManager.InitializeSchoolYearCombo(this.ctlPayment.SchoolYearComboBox);

            if (this.ctlPayment.IsForApply)
            {
                this.pbxChecked.Visible = true;
                this.gbxAdditionalPayment.Location = new Point(9, 64);
                this.gbxData.Location = new Point(9, 205);
                this.gbxData.Size = new Size(590, 481);
                this.dgvList.Location = new Point(6, 40);
                this.dgvList.Size = new Size(578, 405);

                this.ctlPayment.SchoolYearComboBox.Enabled = false;

                this.pbxUnlock.Visible = this.pbxLocked.Visible = this.lblStatus.Visible = this.lblLine.Visible =
                   this.lblTextSelected.Visible = this.lblSelected.Visible = true;

                this.dgvList.DataSource = null;

                dgvList.DataSource = _cashieringManager.StudentTableFormatIsForApply;
                RemoteClient.ProcStatic.SetDataGridViewColumns(dgvList, false);
            }
            else
            {   
                this.pbxChecked.Visible = false;

                this.gbxData.Location = new Point(9, 64);
                this.gbxData.Size = new Size(590, 625);
                this.dgvList.Location = new Point(6, 14);
                this.dgvList.Size = new Size(578, 580);

                this.ctlPayment.SchoolYearComboBox.Enabled = true;

                this.pbxUnlock.Visible = this.pbxLocked.Visible = this.lblStatus.Visible = this.lblLine.Visible =
                    this.lblTextSelected.Visible = this.lblSelected.Visible = false;

                this.dgvList.DataSource = null;

                dgvList.DataSource = _cashieringManager.StudentTableFormatIsForViewing;
                RemoteClient.ProcStatic.SetDataGridViewColumns(dgvList, false);              
            }
        }//---------------------
        //############################################END CONTROLCLASSROOMSUBJECTMANAGER ctlPayment EVENTS##########################################

        //####################################################DATAGRIDVIEW dgvList EVENTS####################################################
        //event is raised when the cell content is clicked
        private void dgvListCellContentClick(object sender, DataGridViewCellEventArgs e)
        {     
            if (e.ColumnIndex == 0 && this.ctlPayment.IsForApply)
            {
                this.dgvList.EndEdit();

                this.dgvList.ReadOnly = false;

                DataGridViewCheckBoxCell checkedCell = this.dgvList.Rows[e.RowIndex].Cells[0] as DataGridViewCheckBoxCell;

                this.dgvList.Rows[e.RowIndex].Cells[0].Value = (Boolean)checkedCell.Value;

                if ((Boolean)checkedCell.Value)
                {
                    _selected++;
                }
                else
                {
                    _selected--;
                }
            }
            else
            {
                this.dgvList.ReadOnly = true;
            }

            this.lblSelected.Text = _selected.ToString();
        }//-------------------------              
      
        //event is raised when the mouse is down
        private void dgvListMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView dgvBase = (DataGridView)sender;

                DataGridView.HitTestInfo hitTest = dgvBase.HitTest(e.X, e.Y);

                switch (hitTest.Type)
                {
                    case DataGridViewHitTestType.Cell:
                        _rowIndex = hitTest.RowIndex;
                        break;
                    case DataGridViewHitTestType.RowHeader:
                        _rowIndex = hitTest.RowIndex;
                        break;
                    default:
                        _rowIndex = -1;
                        _primaryId = "";
                        break;
                }

                if (_rowIndex != -1)
                {
                    _primaryId = dgvBase[_primaryIndex, _rowIndex].Value.ToString();
                }
            }
        }//----------------------

        //event is raised when the mouse is double clicked
        private void dgvListDoubleClick(object sender, EventArgs e)
        {
            if (_rowIndex >= 0 && !this.ctlPayment.IsForApply)
            {
                using (StudentAdditionalFee frmUpdate = new StudentAdditionalFee(_userInfo, _cashieringManager, _rowIndex, _dateStart, _dateEnd))
                {
                    frmUpdate.ShowDialog(this);

                    if (frmUpdate.HasUpDated || frmUpdate.HasDeleted)
                    {
                        this.ShowSearchResultDialog();
                    }
                }
            }
        }//---------------------------------

        //event is raised when the data source is changed
        private void dgvListDataSourceChanged(object sender, EventArgs e)
        {
            DataGridView dgvBase = (DataGridView)sender;
            Int32 result = dgvBase.Rows.Count;

            if (result == 1)
            {
                _primaryId = dgvBase[_primaryIndex, 0].Value.ToString();
            }
            else
            {
                _primaryId = "";
            }

            if (result == 0 || result == 1)
            {
                this.lblResult.Text = result.ToString() + " Record";
            }
            else
            {
                this.lblResult.Text = result.ToString() + " Records";
            }

        } //--------------------------------

        //event is raised when the selection is changed
        private void dgvListSelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgvBase = (DataGridView)sender;

            if (dgvBase.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                DataGridViewRow row = dgvBase.SelectedRows[0];

                _primaryId = row.Cells[_primaryIndex].Value.ToString();
            }
        } //------------------------------------

        //####################################################END DATAGRIDVIEW dgvList EVENTS####################################################

        //###########################################TEXTBOX txtAmount EVENTS#####################################################
        //event is raised when the key is pressed
        private void txtAmountKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxAmountOnly(e);
        }//----------------------

        //event is raised when the control is validating
        private void txtAmountValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxValidateAmount((TextBox)sender);
        }//---------------------     
   
        //event is raised when the control is validated
        private void txtAmountValidated(object sender, EventArgs e)
        {
            Decimal amount;

            if (Decimal.TryParse(txtAmount.Text, out amount))
            {
                _additionalFeeInfo.Amount = amount;
            }
        }//--------------------
        //###########################################END TEXTBOX txtAmount EVENTS#####################################################

        //##################################TEXTBOX txtAdditionalFeeRemarks EVENTS######################################################
        //event is raised when the picture box is clicked
        private void txtAdditionalFeeRemarksValidated(object sender, EventArgs e)
        {
            _additionalFeeInfo.Remarks = RemoteClient.ProcStatic.TrimStartEndString(this.txtAdditionalFeeRemarks.Text);
        }//-------------------
        //##################################END TEXTBOX txtAdditionalFeeRemarks EVENTS######################################################

        //##################################PICTUREBOX pbxChecked EVENTS######################################################
        //event is raised when the picture box is clicked
        private void pbxCheckedClick(object sender, EventArgs e)
        {
            if (this.ctlPayment.IsForApply)
            {
                this.dgvList.EndEdit(); 

                _isChecked = !_isChecked;

                _selected = 0;

                for (Int32 x = 0; x < this.dgvList.Rows.Count; x++)
                {
                    this.dgvList.Rows[x].Selected = false;

                    dgvList.Rows[x].Cells[0].Value = _isChecked;

                    if (_isChecked)
                    {
                        _selected++;
                    }
                }

                this.lblSelected.Text = _selected.ToString();
            }
        }//-----------------------
        //##################################END PICTUREBOX pbxChecked EVENTS######################################################

        //##################################BUTTON btnAdditionalFee EVENTS######################################################
        //event is raised when the picture box is clicked
        private void btnSearchAdditionalFeeClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                using (AdditionalFeeSearchOnTextBoxList frmSearch = new AdditionalFeeSearchOnTextBoxList(_cashieringManager))
                {
                    frmSearch.AdoptGridSize = false;
                    frmSearch.ShowDialog(this);

                    if (frmSearch.HasSelected)
                    {
                        _additionalFeeInfo = _cashieringManager.GetDetailsAdditionalFee(frmSearch.PrimaryId);

                        this.lblParticularDescription.Text = _additionalFeeInfo.SchoolFeeParticularInfo.ParticularDescription;

                        this.txtAmount.Focus();
                        this.txtAmount.Select();

                        this.ctlPayment.Enabled = this.pbxChecked.Enabled = this.btnRecord.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }

            this.Cursor = Cursors.Arrow;
        }//---------------------
        //##################################END BUTTON btnAdditionalFee EVENTS######################################################

        //##################################BUTTON btnRecord EVENTS######################################################
        //event is raised when the picture box is clicked
        private void btnRecordClick(object sender, EventArgs e)
        {
            try
            {
                Boolean hasInserted = false;

                for (Int32 x = 0; x < this.dgvList.Rows.Count; x++)
                {
                    if ((Boolean)this.dgvList.Rows[x].Cells[0].Value)
                    {
                        _cashieringManager.InsertAdditionalFeeCached(this.dgvList.Rows[x].Cells["sysid_enrolmentlevel"].Value.ToString(),
                            _additionalFeeInfo.SchoolFeeParticularInfo.FeeParticularSysId, _additionalFeeInfo.Amount, _additionalFeeInfo.Remarks);

                        hasInserted = true;
                    }
                }

                if (this.ValidateControls(hasInserted))
                {
                    String strMsg = "Are you sure you want to record the new students additional fee?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The students additional fee has been successfully recorded.";

                        this.Cursor = Cursors.WaitCursor;                        

                        _cashieringManager.InsertStudentAdditionalFee(_userInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasRecorded = true;

                        this.ResetQuery();

                        this.lblParticularDescription.Text = "-";
                        this.txtAmount.Text = String.Empty;
                        this.txtAdditionalFeeRemarks.Clear();

                        this.btnRecord.Enabled = false;

                        _additionalFeeInfo = new CommonExchange.StudentAdditionalFee();

                        _cashieringManager.ClearCachedData();
                    }
                }                
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Recording");
            }
        }//--------------------
        //##################################END BUTTON btnRecord EVENTS######################################################
        #endregion

        #region Programmer-Defined Void Procedures
        //this procedure shows the search result
        private void ShowSearchResultDialog()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String queryString = RemoteClient.ProcStatic.TrimStartEndString(ctlPayment.GetSearchString);

                if (!String.IsNullOrEmpty(queryString) && !String.IsNullOrEmpty(_dateStart) && !String.IsNullOrEmpty(_dateEnd))
                {
                    dgvList.DataSource = _cashieringManager.GetSearchedStudentInformation(_userInfo, queryString, _dateStart, _dateEnd,
                        _cashieringManager.GetCourseYearLevelStringFormat(ctlPayment.YearLevelCheckedListBox, false),
                        _cashieringManager.GetCourseYearLevelStringFormat(ctlPayment.CourseCheckedListBox, true), this.ctlPayment.IsForApply);

                    if (this.ctlPayment.IsForApply)
                    {
                        this.dgvList.Columns["checkbox_column"].ReadOnly = false;
                    }

                    this.dgvList.ReadOnly = this.ctlPayment.IsForApply ? false : true;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Retrieving Data");
            }
            finally
            {
                this.ctlPayment.SetFocusOnSearchTextBox();
                
                this.Cursor = Cursors.Arrow;
            }
        }//--------------------------------- 

        //this procedure will set record locked control
        private void IsRecordLocked()
        {
            if (!RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo))//Code Added Feb. 9, 2011..Code Purpose: Remove record locking for administrator
            {
                if (RemoteClient.ProcStatic.IsRecordLocked(DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd), DateTime.Parse(_cashieringManager.ServerDateTime)))
                {
                    this.lblStatus.Text = "This record is LOCKED";

                    this.btnRecord.Enabled = false;

                    this.pbxLocked.Visible = this.txtAmount.ReadOnly = true;
                    this.pbxUnlock.Visible = this.btnSearchAdditionalFee.Enabled = false;

                    this.pbxChecked.Click -= new EventHandler(pbxCheckedClick);
                    this.dgvList.CellContentClick -= new DataGridViewCellEventHandler(dgvListCellContentClick);

                    this.dgvList.ReadOnly = true;
                }
                else
                {
                    this.lblStatus.Text = "This record is OPEN";

                    this.btnRecord.Enabled = true;

                    this.pbxLocked.Visible = this.txtAmount.ReadOnly = false;
                    this.pbxUnlock.Visible = this.btnSearchAdditionalFee.Enabled = true;

                    this.pbxChecked.Click -= new EventHandler(pbxCheckedClick);
                    this.pbxChecked.Click += new EventHandler(pbxCheckedClick);

                    this.dgvList.CellContentClick -= new DataGridViewCellEventHandler(dgvListCellContentClick);
                    this.dgvList.CellContentClick += new DataGridViewCellEventHandler(dgvListCellContentClick);

                    this.dgvList.ReadOnly = false;
                }
            }
        }//-----------------------------

        //this procedure will reset the query
        private void ResetQuery()
        {
            this.ctlPayment.OnSchoolYearSelectedIndexChanged -=
           new RemoteClient.ControlAdditionalFeeManagerSchoolYearSelectedIndexChanged(ctlPaymentOnSchoolYearSelectedIndexChanged);
            this.ctlPayment.OnCourseSelectedIndexChanged -=
                 new RemoteClient.ControlAdditionalFeeManagerCheckedListBoxSelectedIndexChanged(ctlPaymentOnCourseLevelSelectedIndexChanged);
            this.ctlPayment.OnYearLevelSelectedIndexChanged -=
                new RemoteClient.ControlAdditionalFeeManagerCheckedListBoxSelectedIndexChanged(ctlPaymentOnCourseLevelSelectedIndexChanged);

            _cashieringManager.InitializeSchoolYearCombo(this.ctlPayment.SchoolYearComboBox);

            this.ctlPayment.SemesterComboBox.Items.Clear();

            if (this.ctlPayment.SchoolYearIndex != -1)
                _cashieringManager.InitializeSemesterCombo(this.ctlPayment.SemesterComboBox, this.ctlPayment.SchoolYearComboBox.SelectedIndex);

            _cashieringManager.InitializeCourseCheckedListBox(this.ctlPayment.CourseCheckedListBox);
            _cashieringManager.InitializeYearLevelCheckedListBox(this.ctlPayment.YearLevelCheckedListBox);


            this.ctlPayment.OnSchoolYearSelectedIndexChanged -=
           new RemoteClient.ControlAdditionalFeeManagerSchoolYearSelectedIndexChanged(ctlPaymentOnSchoolYearSelectedIndexChanged);
            this.ctlPayment.OnCourseSelectedIndexChanged -=
                 new RemoteClient.ControlAdditionalFeeManagerCheckedListBoxSelectedIndexChanged(ctlPaymentOnCourseLevelSelectedIndexChanged);
            this.ctlPayment.OnYearLevelSelectedIndexChanged -=
                new RemoteClient.ControlAdditionalFeeManagerCheckedListBoxSelectedIndexChanged(ctlPaymentOnCourseLevelSelectedIndexChanged);
            this.ctlPayment.OnSchoolYearSelectedIndexChanged +=
           new RemoteClient.ControlAdditionalFeeManagerSchoolYearSelectedIndexChanged(ctlPaymentOnSchoolYearSelectedIndexChanged);
            this.ctlPayment.OnCourseSelectedIndexChanged +=
                new RemoteClient.ControlAdditionalFeeManagerCheckedListBoxSelectedIndexChanged(ctlPaymentOnCourseLevelSelectedIndexChanged);
            this.ctlPayment.OnYearLevelSelectedIndexChanged +=
                new RemoteClient.ControlAdditionalFeeManagerCheckedListBoxSelectedIndexChanged(ctlPaymentOnCourseLevelSelectedIndexChanged);

            if (this.ctlPayment.IsForApply)
            {
                dgvList.DataSource = _cashieringManager.StudentTableFormatIsForApply;
            }
            else
            {
                dgvList.DataSource = _cashieringManager.StudentTableFormatIsForViewing;
            }
        }//----------------------------
        #endregion

        #region Programer-Defined Functions
        //this function will validate controls
        public Boolean ValidateControls(Boolean hasInserted)
        {
            Boolean isValid = true;

            _errProvider.SetError(this.lblParticularDescription, "");
            _errProvider.SetError(this.txtAmount, "");
            _errProvider.SetError(this.pbxChecked, "");

            if (String.IsNullOrEmpty(_additionalFeeInfo.SchoolFeeParticularInfo.FeeParticularSysId))
            {
                _errProvider.SetError(this.lblParticularDescription, "You must select a additional fee.");
                _errProvider.SetIconAlignment(this.lblParticularDescription, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            if (_additionalFeeInfo.Amount <= 0)
            {
                _errProvider.SetError(this.txtAmount, "Amount must be greater than zero.");
                _errProvider.SetIconAlignment(this.txtAmount, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            if (!hasInserted)
            {
                _errProvider.SetError(this.pbxChecked, "You must select a student.");
                _errProvider.SetIconAlignment(this.pbxChecked, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            return isValid;
        }//-------------------
        #endregion
    }
}
