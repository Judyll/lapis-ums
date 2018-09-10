using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class StudentIdGenerator
    {
        #region Class Properties Declaration
        private Boolean _hasAdded = false;
        public Boolean HasAdded
        {
            get { return _hasAdded; }
            set { _hasAdded = value; }
        }

        private String _studentId = "";
        public String StudentId
        {
            get { return _studentId; }
            set { _studentId = value; }
        }

        private String _yearLevelId = String.Empty;
        public String YearLevelId
        {
            get { return _yearLevelId; }
        }

        private String _courseGroupId = String.Empty;
        public String CourseGroupId
        {
            get { return _courseGroupId; }
        }
        #endregion

        #region Class General Variable Declaration
        private CommonExchange.SysAccess _userInfo;
        private StudentLogic _studentManager;

        private ErrorProvider _errProvider;
        #endregion

        #region Class Constructors
        public StudentIdGenerator(CommonExchange.SysAccess userInfo, StudentLogic studentManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _studentManager = studentManager;

            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.cboYear.SelectedIndexChanged += new EventHandler(cboYearSelectedIndexChanged);
            this.cboYearLevel.SelectedIndexChanged += new EventHandler(cboYearLevelSelectedIndexChanged);
            this.btnInsert.Click += new EventHandler(btnInsertClick);
        }          
        #endregion

        #region Class Event Void Procedures
        //############################################CLASS StudentIdGenerator EVENTS#######################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {           
            _studentManager.InitializeSchoolYearForIdCombo(this.cboYear);
        }//---------------------------

        //event is raised when the class closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasAdded)
            {
                String strMsg = "Are you sure you want to cancel the creation of a new student Id?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//-------------------------       
        //############################################END CLASS StudentIdGenerator EVENTS#######################################################

        //############################################BUTTON btnCancel EVENTS#######################################################
        //event is raised when the control is clicked
        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }//-----------------------------------
        //############################################END BUTTON btnCancel EVENTS#######################################################

        //############################################COMBOBOX cboYear EVENTS#######################################################
        //event is raised when the control selected index changed
        private void cboYearSelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblId.Text = "Acquiring...";

            _studentManager.SelectBySysIDSchoolFeeSchoolFeeLevel(_userInfo, _studentManager.GetFeeInformationSysIdForId(this.cboYear.SelectedIndex));

            _studentManager.InitializeYearLevelCombo(this.cboYearLevel);
        }//-------------------------------------
        //############################################END COMBOBOX cboYear EVENTS#######################################################

        //############################################COMBOBOX cboYearLevel EVENTS#######################################################
        //event is raised when the control selected index changed
        private void cboYearLevelSelectedIndexChanged(object sender, EventArgs e)
        {
            _studentId = _studentManager.GetYearLevelPrefix(this.cboYearLevel.SelectedIndex) +
                _studentManager.GetSchoolYearDateStart(_studentManager.GetSchoolYearYearIdNoSummer(this.cboYear.SelectedIndex)).Year +
                "-" + _studentManager.GetCountForStudentIDStudentInformation(_userInfo,
                _studentManager.GetFeeInformationSysIdNoSummer(this.cboYear.SelectedIndex), _studentManager.GetYearLevelIdBySchoolFeeTable(this.cboYearLevel.SelectedIndex));

            _yearLevelId = _studentManager.GetYearLevelIdBySchoolFeeTable(this.cboYearLevel.SelectedIndex);
            _courseGroupId = _studentManager.GetCourseGroupIDBySchoolFeeTable(this.cboYearLevel.SelectedIndex);

            this.lblId.Text = _studentId;
        }//--------------------------------------
        //############################################END COMBOBOX cboYearLevel EVENTS#######################################################

        //############################################BUTTON btnInsert EVENTS#######################################################
        //event is raised when the control is clicked
        private void btnInsertClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    _hasAdded = true;

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }//---------------------------------
        //############################################END BUTTON btnInsert EVENTS#######################################################
        #endregion

        #region Programers-Defined Fucntions
        //this procedure will validate controls
        private  Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.lblId, "");

            if (String.IsNullOrEmpty(_studentId))
            {
                _errProvider.SetIconAlignment(this.lblId, ErrorIconAlignment.MiddleLeft);
                _errProvider.SetError(this.lblId, "You must select year level.");

                isValid = false;
            }

            return isValid;
        }
        #endregion
    }
}
