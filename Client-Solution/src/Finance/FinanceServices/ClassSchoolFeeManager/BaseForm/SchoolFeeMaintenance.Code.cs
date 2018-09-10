using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class SchoolFeeMaintenance
    {
        #region Class General Variable Declaration
        private CommonExchange.SysAccess _userInfo;
        private CommonExchange.SchoolFeeLevel _levelInfo;
        private CommonExchange.SchoolFeeDetails _detailsInfo;
        private SchoolFeeLogic _schoolFeeManager;

        private String _sysIdSchoolFeeDetails = "";
        private ErrorProvider _errProvider;
        #endregion

        #region Class Properties Declaration
        private Boolean _hasUpdated = false;
        public Boolean HasUpdated
        {
            get { return _hasUpdated; }
        }

        public DataTable DataSource
        {
            set { this.SetDataGridViewSource(value); }
        }

        #endregion

        #region Class Constructors       
        public SchoolFeeMaintenance(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeInformation feeInfo, 
            SchoolFeeLogic schoolFeeManager, String courseGroupId)
        {
            this.InitializeComponent();

            _levelInfo = new CommonExchange.SchoolFeeLevel();
            _detailsInfo = new CommonExchange.SchoolFeeDetails();

            _userInfo = userInfo;
            _schoolFeeManager = schoolFeeManager;
            _levelInfo.SchoolFeeInfo.FeeInformationSysId = _detailsInfo.SchoolFeeLevelInfo.SchoolFeeInfo.FeeInformationSysId = feeInfo.FeeInformationSysId;
            _levelInfo.SchoolFeeInfo.SchoolYearInfo.YearId = _detailsInfo.SchoolFeeLevelInfo.SchoolFeeInfo.SchoolYearInfo.YearId = 
                feeInfo.SchoolYearInfo.YearId;

            _detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.CourseGroupInfo.CourseGroupId = courseGroupId;

            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);         
            this.cboYearLevel.SelectedIndexChanged += new EventHandler(cboYearLevelSelectedIndexChanged);
            this.lnkCreateYearLevel.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkCreateYearLevelLinkClicked);
            this.lnkCreateSchoolFeeDetails.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkCreateLinkClicked);
            this.dgvSchoolFees.MouseDown += new MouseEventHandler(dgvSchoolFeesMouseDown);
            this.dgvSchoolFees.DoubleClick += new EventHandler(dgvSchoolFeesDoubleClick);
            this.btnClose.Click += new EventHandler(btnCloseClick);
        }
        #endregion

        #region Class Event Void Procedures
        //#####################################################CLASS SchoolFeeMaintenace EVENTS #################################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _schoolFeeManager.InitializedYearLevelCombo(this.cboYearLevel, _detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.CourseGroupInfo.CourseGroupId);

            this.SetDataGridViewSource(_schoolFeeManager.FeeDetailsTable);
            
            RemoteClient.ProcStatic.SetDataGridViewColumns(this.dgvSchoolFees, false);           
           
        }//------------------------------

        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//----------------------       
        //#####################################################END CLASS SchoolFeeMaintenace EVENTS #################################################################

        //#####################################################COMBOBOX cboYearLevel EVENTS #################################################################
        //event is raised when the selected index is change
        private void cboYearLevelSelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetDataGridViewSource(_schoolFeeManager.GetSchoolFeeByYearLevel(_detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.CourseGroupInfo.CourseGroupId,
                _schoolFeeManager.GetYearLevelId(_detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.CourseGroupInfo.CourseGroupId, this.cboYearLevel.Text)));

            _levelInfo.FeeLevelSysId = _detailsInfo.SchoolFeeLevelInfo.FeeLevelSysId = 
                _schoolFeeManager.GetFeelLevelId(_schoolFeeManager.GetYearLevelId(_detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.CourseGroupInfo.CourseGroupId,
                this.cboYearLevel.Text));

            _levelInfo.YearLevelInfo.YearLevelId = _detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.YearLevelId =
                _schoolFeeManager.GetYearLevelId(_detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.CourseGroupInfo.CourseGroupId, this.cboYearLevel.Text);
                       
            if (!_schoolFeeManager.IsExistsSchoolFeeYearLevel(_schoolFeeManager.GetYearLevelId(_detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.CourseGroupInfo.CourseGroupId, 
                this.cboYearLevel.Text)))
            {
                this.lnkCreateYearLevel.Visible = true;
                this.dgvSchoolFees.Enabled = this.lnkCreateSchoolFeeDetails.Visible = false;
            }
            else
            {
                this.dgvSchoolFees.Enabled = true;
                this.lnkCreateYearLevel.Visible = false;
                this.lnkCreateSchoolFeeDetails.Visible = this.cboYearLevel.SelectedIndex >= 0 ? true : false;
            }

            this.dgvSchoolFees.Focus();
        }//-----------------------------
        //#####################################################END COMBOBOX cboYearLevel EVENTS #################################################################

        //#####################################################LINKLABEL lnkCreateYearLevel EVENTS #################################################################
        //event is raised when the control is clicked
        private void lnkCreateYearLevelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (this.ValidateControls())
                {
                    String strMsg = "Are you sure you want to create a new school fee year level in " + this.cboYearLevel.Text + "?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Create", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The New School Fee Year Level in " + this.cboYearLevel.Text + " has been successfully recorded.";

                        this.Cursor = Cursors.WaitCursor;

                        _schoolFeeManager.InsertSchoolFeeLevel(_userInfo, ref _levelInfo);

                        _detailsInfo.SchoolFeeLevelInfo.FeeLevelSysId = _levelInfo.FeeLevelSysId;

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        this.lnkCreateYearLevel.Visible = false;
                        this.dgvSchoolFees.Enabled = this.lnkCreateSchoolFeeDetails.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message + "\n\nError Creating new School Fee Year Level", "Error Creating");
            }
        }//-----------------------------
        //#####################################################LINKLABEL lnkCreateYearLevel EVENTS #################################################################

        //#####################################################LINKLABEL lnkCreate EVENTS #################################################################
        //event is raised when the control is clicked
        private void lnkCreateLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                using (SchoolFeeDetailsCreate frmDetails = new SchoolFeeDetailsCreate(_userInfo, _schoolFeeManager,
                    _detailsInfo.SchoolFeeLevelInfo.SchoolFeeInfo.SchoolYearInfo.YearId, _detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.CourseGroupInfo.CourseGroupId,
                    _detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.YearLevelId, _levelInfo.FeeLevelSysId))
                {
                    frmDetails.ShowDialog(this);
                    
                    if (frmDetails.HasCreated)
                    {
                        this.SetDataGridViewSource(_schoolFeeManager.GetSchoolFeeByYearLevel(_detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.CourseGroupInfo.CourseGroupId,
                            _schoolFeeManager.GetYearLevelId(_detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.CourseGroupInfo.CourseGroupId, this.cboYearLevel.Text)));

                        _hasUpdated = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nError Loding School Fee Details Module.", "Error Loading");
            }
        }//---------------------------
        //#####################################################END LINKLABEL lnkCreate EVENTS #################################################################

        //#####################################################DATAGRIDVIEW dgvSchoolFee EVENTS ################################################################
        //event is raised when the control is double clicked
        private void dgvSchoolFeesDoubleClick(object sender, EventArgs e)
        {            
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!String.IsNullOrEmpty(_sysIdSchoolFeeDetails))
                {
                    using (SchoolFeeDetailsUpdate frmUpdate = new SchoolFeeDetailsUpdate(_userInfo, _schoolFeeManager.GetSchoolFeeDetails(_sysIdSchoolFeeDetails),
                        _schoolFeeManager, _detailsInfo.SchoolFeeLevelInfo.SchoolFeeInfo.SchoolYearInfo.YearId, 
                        _detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.CourseGroupInfo.CourseGroupId,
                        _detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.YearLevelId, _levelInfo.FeeLevelSysId))
                    {
                        frmUpdate.ShowDialog(this);

                        if (frmUpdate.HasUpdated || frmUpdate.HasDeleted)
                        {
                            this.SetDataGridViewSource(_schoolFeeManager.GetSchoolFeeByYearLevel(_detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.CourseGroupInfo.CourseGroupId,
                                 _schoolFeeManager.GetYearLevelId(_detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.CourseGroupInfo.CourseGroupId, this.cboYearLevel.Text)));

                            _hasUpdated = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading School Fee Details Module.");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//--------------------      

        //event is raised when the mouse is dowm
        private void dgvSchoolFeesMouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTest = dgvSchoolFees.HitTest(e.X, e.Y);

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
                    _sysIdSchoolFeeDetails = "";
                    break;
            }

            if (rowIndex != -1)
            {
                _sysIdSchoolFeeDetails = dgvSchoolFees[0, rowIndex].Value.ToString();
            }
        }//---------------------
        //#####################################################END DATAGRIDVIEW dgvSchoolFee EVENTS #################################################################
        #endregion

        #region Programers-Defined Void Procedures
        //this procedure sets the datasource
        protected virtual void SetDataGridViewSource(DataTable srcTable)
        {
            this.Cursor = Cursors.WaitCursor;

            this.dgvSchoolFees.DataSource = srcTable;

            if (dgvSchoolFees.Rows.Count >= 1)
            {
                dgvSchoolFees.Rows[0].Selected = false;
            }

            this.WindowState = FormWindowState.Normal;

            this.Cursor = Cursors.Arrow;
        } //----------------------------
        #endregion

        #region Programes-Defined Functions
        //this function will validate controls
        private Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.lnkCreateYearLevel, "");

            if (_schoolFeeManager.IsExistsSchoolFeeYearLevel(_schoolFeeManager.GetYearLevelId(_detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.CourseGroupInfo.CourseGroupId, 
                this.cboYearLevel.Text)))
            {
                _errProvider.SetIconAlignment(this.lnkCreateYearLevel, ErrorIconAlignment.MiddleLeft);
                _errProvider.SetError(this.lnkCreateYearLevel, "School Fee Year Level is already exist.");
                isValid = false;
            }

            return isValid;
        }//-----------------------------------
        #endregion
    }
}
