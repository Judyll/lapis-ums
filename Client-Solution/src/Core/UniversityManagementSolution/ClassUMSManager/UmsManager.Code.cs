using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace UniversityManagementSolution
{
    partial class UmsManager
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private UmsLogic _umsManager;

        private Timer _trmSystemTime;
        private DateTime _systemTime;       
        #endregion

        #region Class Constructors
        public UmsManager(CommonExchange.SysAccess userInfo)
        {
            this.InitializeComponent();

            _umsManager = new UmsLogic(userInfo);

            _trmSystemTime = new Timer();

            _userInfo = userInfo;

            this.Load += new EventHandler(ClassLoad);
            this.FormClosed += new FormClosedEventHandler(UmsManagerFormClosed);
            //this.LocationChanged += new EventHandler(UmsManagerLocationChanged);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnClose.MouseEnter += new EventHandler(controlMouseEnter);
            this.btnClose.MouseLeave += new EventHandler(controlMouseLeave);
            this._trmSystemTime.Tick += new EventHandler(trmSystemTimeTick);

            this.btnIdentification.Click += new EventHandler(ShowIdentificationClick);
            this.lblIdentification.Click += new EventHandler(ShowIdentificationClick);
            this.btnIdentification.MouseEnter += new EventHandler(controlMouseEnter);
            this.btnIdentification.MouseLeave += new EventHandler(controlMouseLeave);
            this.lblIdentification.MouseLeave += new EventHandler(controlMouseLeave);
            this.lblIdentification.MouseEnter += new EventHandler(controlMouseEnter);

            this.btnAttendaceSearch.Click += new EventHandler(ShowAttendaceSearchClick);
            this.lblAttendaceSearch.Click += new EventHandler(ShowAttendaceSearchClick);
            this.btnAttendaceSearch.MouseEnter += new EventHandler(controlMouseEnter);
            this.btnAttendaceSearch.MouseLeave += new EventHandler(controlMouseLeave);
            this.lblAttendaceSearch.MouseLeave += new EventHandler(controlMouseLeave);
            this.lblAttendaceSearch.MouseEnter += new EventHandler(controlMouseEnter);

            this.btnCashiering.Click += new EventHandler(ShowCashieringClick);
            this.lblCashiering.Click += new EventHandler(ShowCashieringClick);
            this.btnCashiering.MouseEnter += new EventHandler(controlMouseEnter);
            this.btnCashiering.MouseLeave += new EventHandler(controlMouseLeave);
            this.lblCashiering.MouseEnter += new EventHandler(controlMouseEnter);
            this.lblCashiering.MouseLeave += new EventHandler(controlMouseLeave);

            this.btnStudent.Click += new EventHandler(ShowStudentClick);
            this.lblStudent.Click += new EventHandler(ShowStudentClick);
            this.btnStudent.MouseEnter += new EventHandler(controlMouseEnter);
            this.btnStudent.MouseLeave += new EventHandler(controlMouseLeave);
            this.lblStudent.MouseEnter += new EventHandler(controlMouseEnter);
            this.lblStudent.MouseLeave += new EventHandler(controlMouseLeave);

            this.lblScholarship.Click += new EventHandler(ShowScholarshipClick);
            this.btnScholarship.Click += new EventHandler(ShowScholarshipClick);
            this.btnScholarship.MouseEnter += new EventHandler(controlMouseEnter);
            this.btnScholarship.MouseLeave += new EventHandler(controlMouseLeave);
            this.lblScholarship.MouseEnter += new EventHandler(controlMouseEnter);
            this.lblScholarship.MouseLeave += new EventHandler(controlMouseLeave);

            this.lblMajorExamSchedule.Click += new EventHandler(ShowMajorExamScheduleClick);
            this.btnMajorExamSchedule.Click += new EventHandler(ShowMajorExamScheduleClick);
            this.btnMajorExamSchedule.MouseEnter += new EventHandler(controlMouseEnter);
            this.btnMajorExamSchedule.MouseLeave += new EventHandler(controlMouseLeave);
            this.lblMajorExamSchedule.MouseEnter += new EventHandler(controlMouseEnter);
            this.lblMajorExamSchedule.MouseLeave += new EventHandler(controlMouseLeave);

            this.btnSchoolFee.Click += new EventHandler(ShowSchoolFeeClick);
            this.lblSchoolFee.Click += new EventHandler(ShowSchoolFeeClick);
            this.btnSchoolFee.MouseEnter += new EventHandler(controlMouseEnter);
            this.btnSchoolFee.MouseLeave += new EventHandler(controlMouseLeave);
            this.lblSchoolFee.MouseEnter += new EventHandler(controlMouseEnter);
            this.lblSchoolFee.MouseLeave += new EventHandler(controlMouseLeave);

            this.btnAuxInformation.Click += new EventHandler(ShowAuxiliaryInformationClick);
            this.lblAuxiliaryInformation.Click += new EventHandler(ShowAuxiliaryInformationClick);
            this.btnAuxInformation.MouseEnter += new EventHandler(controlMouseEnter);
            this.btnAuxInformation.MouseLeave += new EventHandler(controlMouseLeave);
            this.lblAuxiliaryInformation.MouseEnter += new EventHandler(controlMouseEnter);
            this.lblAuxiliaryInformation.MouseLeave += new EventHandler(controlMouseLeave);

            this.btnAuxScheduling.Click += new EventHandler(ShowAuxiliarySchedulingClick);
            this.lblAuxiliaryScheduling.Click += new EventHandler(ShowAuxiliarySchedulingClick);
            this.btnAuxScheduling.MouseEnter += new EventHandler(controlMouseEnter);
            this.btnAuxScheduling.MouseLeave += new EventHandler(controlMouseLeave);
            this.lblAuxiliaryScheduling.MouseEnter += new EventHandler(controlMouseEnter);
            this.lblAuxiliaryScheduling.MouseLeave += new EventHandler(controlMouseLeave);

            this.btnStudentLoading.Click += new EventHandler(ShowStudentLoadingClick);
            this.lblStudentLoading.Click += new EventHandler(ShowStudentLoadingClick);
            this.btnStudentLoading.MouseEnter += new EventHandler(controlMouseEnter);
            this.btnStudentLoading.MouseLeave += new EventHandler(controlMouseLeave);
            this.lblStudentLoading.MouseEnter += new EventHandler(controlMouseEnter);
            this.lblStudentLoading.MouseLeave += new EventHandler(controlMouseLeave);

            this.btnSubjectScheduling.Click += new EventHandler(ShowSubjectSchedulingClick);
            this.lblSubjectScheduling.Click += new EventHandler(ShowSubjectSchedulingClick);
            this.btnSubjectScheduling.MouseEnter += new EventHandler(controlMouseEnter);
            this.btnSubjectScheduling.MouseLeave += new EventHandler(controlMouseLeave);
            this.lblSubjectScheduling.MouseEnter += new EventHandler(controlMouseEnter);
            this.lblSubjectScheduling.MouseLeave += new EventHandler(controlMouseLeave);

            this.btnTeacherLoading.Click += new EventHandler(ShowTeacherLoadingClick);
            this.lblTeacherLoading.Click += new EventHandler(ShowTeacherLoadingClick);
            this.btnTeacherLoading.MouseEnter += new EventHandler(controlMouseEnter);
            this.btnTeacherLoading.MouseLeave += new EventHandler(controlMouseLeave);
            this.lblTeacherLoading.MouseEnter += new EventHandler(controlMouseEnter);
            this.lblTeacherLoading.MouseLeave += new EventHandler(controlMouseLeave);

            this.btnEarning.Click += new EventHandler(ShowEarningClick);
            this.lblEarning.Click += new EventHandler(ShowEarningClick);
            this.btnEarning.MouseEnter += new EventHandler(controlMouseEnter);
            this.btnEarning.MouseLeave += new EventHandler(controlMouseLeave);
            this.lblEarning.MouseEnter += new EventHandler(controlMouseEnter);
            this.lblEarning.MouseLeave += new EventHandler(controlMouseLeave);

            this.btnDeduction.Click += new EventHandler(ShowDeductionClick);
            this.lblDeduction.Click += new EventHandler(ShowDeductionClick);
            this.btnDeduction.MouseEnter += new EventHandler(controlMouseEnter);
            this.btnDeduction.MouseLeave += new EventHandler(controlMouseLeave);
            this.lblDeduction.MouseEnter += new EventHandler(controlMouseEnter);
            this.lblDeduction.MouseLeave += new EventHandler(controlMouseLeave);

            this.btnEmployee.Click += new EventHandler(ShowEmployeeClick);
            this.lblEmployee.Click += new EventHandler(ShowEmployeeClick);
            this.btnEmployee.MouseEnter += new EventHandler(controlMouseEnter);
            this.btnEmployee.MouseLeave += new EventHandler(controlMouseLeave);
            this.lblEmployee.MouseEnter += new EventHandler(controlMouseEnter);
            this.lblEmployee.MouseLeave += new EventHandler(controlMouseLeave);

            this.btnLoanRemittance.Click += new EventHandler(ShowLoanRemittanceClick);
            this.lblLoanRemittance.Click += new EventHandler(ShowLoanRemittanceClick);
            this.btnLoanRemittance.MouseEnter += new EventHandler(controlMouseEnter);
            this.btnLoanRemittance.MouseLeave += new EventHandler(controlMouseLeave);
            this.lblLoanRemittance.MouseEnter += new EventHandler(controlMouseEnter);
            this.lblLoanRemittance.MouseLeave += new EventHandler(controlMouseLeave);

            this.btnCourse.Click += new EventHandler(ShowCourseClick);
            this.lblCourse.Click += new EventHandler(ShowCourseClick);
            this.btnCourse.MouseEnter += new EventHandler(controlMouseEnter);
            this.btnCourse.MouseLeave += new EventHandler(controlMouseLeave);
            this.lblCourse.MouseEnter += new EventHandler(controlMouseEnter);
            this.lblCourse.MouseLeave += new EventHandler(controlMouseLeave);

            this.btnSchoolYearSemester.Click += new EventHandler(ShowSchoolYearSemesterClick);
            this.lblSchoolYearSemester.Click += new EventHandler(ShowSchoolYearSemesterClick);
            this.btnSchoolYearSemester.MouseEnter += new EventHandler(controlMouseEnter);
            this.btnSchoolYearSemester.MouseLeave += new EventHandler(controlMouseLeave);
            this.lblSchoolYearSemester.MouseEnter += new EventHandler(controlMouseEnter);
            this.lblSchoolYearSemester.MouseLeave += new EventHandler(controlMouseLeave);

            this.btnSpecialClass.Click += new EventHandler(ShowSpecialClassClick);
            this.lblSpecialClass.Click += new EventHandler(ShowSpecialClassClick);
            this.btnSpecialClass.MouseEnter += new EventHandler(controlMouseEnter);
            this.btnSpecialClass.MouseLeave += new EventHandler(controlMouseLeave);
            this.lblSpecialClass.MouseEnter += new EventHandler(controlMouseEnter);
            this.lblSpecialClass.MouseLeave += new EventHandler(controlMouseLeave);

            this.btnTranscript.Click += new EventHandler(ShowTranscriptClassClick);
            this.lblTranscript.Click += new EventHandler(ShowTranscriptClassClick);
            this.btnTranscript.MouseEnter += new EventHandler(controlMouseEnter);
            this.btnTranscript.MouseLeave += new EventHandler(controlMouseLeave);
            this.lblTranscript.MouseEnter += new EventHandler(controlMouseEnter);
            this.lblTranscript.MouseLeave += new EventHandler(controlMouseLeave);

            this.btnChartOfAccount.Click += new EventHandler(ShowChartOfAccount);
            this.lblChartOfAccount.Click += new EventHandler(ShowChartOfAccount);
            this.btnChartOfAccount.MouseEnter += new EventHandler(controlMouseEnter);
            this.btnChartOfAccount.MouseLeave += new EventHandler(controlMouseLeave);
            this.lblChartOfAccount.MouseEnter += new EventHandler(controlMouseEnter);
            this.lblChartOfAccount.MouseLeave += new EventHandler(controlMouseLeave);

            this.lblUsers.Click += new EventHandler(lblUsersClick);
            this.lblUsers.MouseLeave += new EventHandler(controlMouseLeave);
            this.lblUsers.MouseEnter += new EventHandler(controlMouseEnter);

            this.lblTransaction.Click += new EventHandler(lblTransactionClick);
            this.lblTransaction.MouseLeave += new EventHandler(controlMouseLeave);
            this.lblTransaction.MouseEnter += new EventHandler(controlMouseEnter);

            
        }
    
        #endregion

        #region Class Event Void Procedure
        //###############################################CLASS UmsManager EVENTS##################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _trmSystemTime.Interval = 1000;

            if (DateTime.TryParse(_umsManager.ServerDateTime, out _systemTime))
            {
                _trmSystemTime.Start();
            }

            this.lblUserName.Text = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(_userInfo.PersonInfo.LastName, _userInfo.PersonInfo.FirstName,
                _userInfo.PersonInfo.MiddleName);

            DateTime date = DateTime.MinValue;

            if (DateTime.TryParse(_umsManager.ServerDateTime, out date))
            {
                this.lblDate.Text = date.ToLongDateString();
            }

            wbMain.Url = new Uri(Application.StartupPath + "\\default\\web\\default\\index.htm");

            Boolean isAdmin = RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo);
            Boolean isPayrollMaster = RemoteServerLib.ProcStatic.IsSystemAccessPayrollMaster(_userInfo);
            Boolean isOfficeUser = RemoteServerLib.ProcStatic.IsSystemAccessOfficeUser(_userInfo);          
            Boolean isRegistrarCollege = RemoteServerLib.ProcStatic.IsSystemAccessCollegeRegistrar(_userInfo);
            Boolean isRegistrarHighSchoolGradeSchool = RemoteServerLib.ProcStatic.IsSystemAccessHighSchoolGradeSchoolRegistrar(_userInfo);
            Boolean isDataController = RemoteServerLib.ProcStatic.IsSystemAccessStudentDataController(_userInfo);
            Boolean isIdMaker = RemoteServerLib.ProcStatic.IsSystemAccessIDMaker(_userInfo);
            Boolean isCashier = RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo);
            Boolean isVpOfFinance = RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo);
            Boolean isVpOfAcademicAffairs = RemoteServerLib.ProcStatic.IsSystemAccessVpOfAcademicAffairs(_userInfo);
            Boolean isAcadSecretary = RemoteServerLib.ProcStatic.IsSystemAccessSecretaryOftheVpOfAcademicAffairs(_userInfo);
            Boolean isBookkeeper = RemoteServerLib.ProcStatic.IsSystemAccessBookkeeper(_userInfo);
            

            if (isAdmin)
            {
                this.lblIdentification.Enabled = this.lblStudent.Enabled = this.lblSchoolFee.Enabled = this.lblAuxiliaryInformation.Enabled =
                    this.lblAuxiliaryScheduling.Enabled = this.lblStudentLoading.Enabled = this.lblSubjectScheduling.Enabled =
                    this.lblTeacherLoading.Enabled = this.lblEarning.Enabled = this.lblDeduction.Enabled = this.lblEmployee.Enabled =
                    this.lblLoanRemittance.Enabled = this.lblCourse.Enabled = this.lblSchoolYearSemester.Enabled = this.lblSpecialClass.Enabled =
                    this.btnIdentification.Enabled = this.btnStudent.Enabled = this.btnSchoolFee.Enabled = this.btnAuxInformation.Enabled =
                    this.btnAuxScheduling.Enabled = this.btnStudentLoading.Enabled = this.btnSubjectScheduling.Enabled =
                    this.btnTeacherLoading.Enabled = this.btnEarning.Enabled = this.btnDeduction.Enabled = this.btnEmployee.Enabled =
                    this.btnEarning.Enabled = this.btnLoanRemittance.Enabled = this.btnCourse.Enabled =
                    this.btnSchoolYearSemester.Enabled = this.btnSpecialClass.Enabled = this.adminToolStripMenuItem.Visible =
                    this.lblUsers.Enabled = this.lblTransaction.Enabled = this.btnScholarship.Enabled = this.lblScholarship.Enabled =
                    this.lblMajorExamSchedule.Enabled = this.lblMajorExamSchedule.Enabled = this.lblCashiering.Enabled =
                    this.btnCashiering.Enabled = this.lblMajorExamSchedule.Enabled = this.btnMajorExamSchedule.Enabled = 
                    this.btnChartOfAccount.Enabled = this.lblChartOfAccount.Enabled = this.lblTransaction.Enabled = this.btnTranscript.Enabled = true;

            }
            else
            {
                this.adminToolStripMenuItem.Visible = this.lblUsers.Enabled = this.lblTransaction.Enabled = false;

                this.attendaceSolutionToolStripMenuItem.Enabled = isIdMaker;
                this.financeSolutionToolStripMenuItem.Enabled = isVpOfFinance || isCashier || isRegistrarCollege || isDataController ? true : false;
                this.officeSolutionToolStripMenuItem.Enabled = isVpOfFinance || isCashier || isOfficeUser || isVpOfAcademicAffairs || isAcadSecretary ||
                    isRegistrarCollege || isRegistrarHighSchoolGradeSchool || isPayrollMaster || isDataController ? true : false;
                this.payrollSolutionToolStripMenuItem.Enabled = isVpOfFinance || isPayrollMaster ? true : false;
                this.registrarSolutionToolStripMenuItem.Enabled = isRegistrarCollege || isRegistrarHighSchoolGradeSchool ||
                    isCashier || isVpOfFinance || isPayrollMaster || isVpOfAcademicAffairs ? true : false;
                this.accountingToolStripMenuItem.Enabled = isBookkeeper ? true : false;

                //for Id Maker
                this.lblIdentification.Enabled = this.btnIdentification.Enabled = isIdMaker;
                //-------------

                //for Cashier and Vp of Finance
                this.lblCashiering.Enabled = this.btnCashiering.Enabled = 
                    this.lblSchoolFee.Enabled = this.btnSchoolFee.Enabled = isVpOfFinance || isCashier ? true : false;
                //---------------

                //for Cashier, Vp of Finance, Office User, College Registrar and Vp of Academic Affairs
                this.lblStudentLoading.Enabled = this.btnStudentLoading.Enabled = isVpOfFinance || isCashier || isVpOfAcademicAffairs || isAcadSecretary ||
                    isOfficeUser || isRegistrarCollege || isDataController ? true : false;
                //---------------

                //for Office User, Cashhier, Vp of Finance and Vp of Academic Affairs
                this.lblSubjectScheduling.Enabled = this.btnSubjectScheduling.Enabled = isOfficeUser || isVpOfFinance || 
                    isVpOfAcademicAffairs || isCashier ? true : false;
                //--------------

                //for Payroll Master, Office User, Vp of Finance, Vp of AcademicAffairs and Secretary of Vp of Academic Affairs
                this.lblTeacherLoading.Enabled = this.btnTeacherLoading.Enabled = isPayrollMaster || isOfficeUser ||
                    isVpOfFinance || isVpOfAcademicAffairs || isAcadSecretary || isRegistrarCollege ? true : false;
                //-----------------

                //for Vp of Academic Affairs and  Secretary of Vp of Academic Affairs
                this.lblAuxiliaryScheduling.Enabled = this.btnAuxScheduling.Enabled = 
                    this.lblAuxiliaryInformation.Enabled = this.btnAuxInformation.Enabled = isVpOfAcademicAffairs || isAcadSecretary ? true : false;
                //---------------

                //for Vp of Academic Affairs, Secretary of Vp of Academic Affairs, College Registrar and cashier
                this.lblScholarship.Enabled = this.btnScholarship.Enabled = isVpOfAcademicAffairs || isAcadSecretary || 
                    isRegistrarCollege || isCashier ? true : false;
                //---------------

                //for Payroll Master and Vp of Finance
                this.lblEarning.Enabled = this.lblDeduction.Enabled = this.lblEmployee.Enabled = this.lblLoanRemittance.Enabled =
                    this.btnEarning.Enabled = this.btnDeduction.Enabled = this.btnEmployee.Enabled = this.btnLoanRemittance.Enabled =
                    isPayrollMaster || isVpOfFinance ? true : false;           
                //---------------
                
                //for College Registrar
                this.lblSchoolYearSemester.Enabled = this.btnSchoolYearSemester.Enabled =                    
                    this.lblMajorExamSchedule.Enabled = this.btnMajorExamSchedule.Enabled = this.lblTransaction.Enabled = this.btnTranscript.Enabled = isRegistrarCollege;
                //-----------------

                //for College Registrar, High School and Grade School
                this.lblCourse.Enabled = this.btnCourse.Enabled = isRegistrarCollege || isRegistrarHighSchoolGradeSchool ? true : false;
                //-------------------

                //for College Registrar, High School, Grade School Registrar, Cashier, vp of finance and Payroll Master
                this.lblSpecialClass.Enabled = this.btnSpecialClass.Enabled = isRegistrarCollege || isRegistrarHighSchoolGradeSchool ||
                    isCashier || isVpOfFinance || isPayrollMaster || isVpOfAcademicAffairs ? true : false;
                //-------------------

                //for Data Controller, College Registrar, Cashier
                this.lblStudent.Enabled = this.btnStudent.Enabled = isDataController || isCashier || isVpOfFinance || isRegistrarCollege ? true : false;
                //-------------          

                //for bookkepper
                this.lblChartOfAccount.Enabled = this.btnChartOfAccount.Enabled = isBookkeeper;
                //-----------------
            }
        }//----------------------------

        ////event is raised when the form location is changed
        //private void UmsManagerLocationChanged(object sender, EventArgs e)
        //{
        //    if (_isFirstLoad)
        //    {
        //        _location = this.Location;
        //        _isFirstLoad = false;
        //    }

        //    this.Location = _location;
        //}//-----------------------------
        //###############################################CLASS UmsManager EVENTS##################################################

        //###############################################BUTTON btnClose EVENTS##################################################
        //event is raised when timer tick
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//----------------------------       
        //###############################################END BUTTON btnClose EVENTS##################################################

        //###############################################TIMER trmSystemTime EVENTS##################################################
        //event is raised when timer tick
        private void trmSystemTimeTick(object sender, EventArgs e)
        {
            _systemTime = _systemTime.AddSeconds(((Timer)sender).Interval / 1000);

            lbltime.Text = _systemTime.ToLongTimeString(); 
        }//-----------------------------
        //###############################################END TIMER trmSystemTime EVENTS##################################################

        //###############################################Show Identification Manager EVENTS##################################################
        //event is raised when the control is clicked
        private void ShowIdentificationClick(object sender, EventArgs e)
        {
            this.ShowIdentificationManager();
        }//-----------------------------------
        //###############################################END Show Identification Manager EVENTS##################################################

        //###############################################Show Attendace Search Manager EVENTS##################################################
        //event is raised when the control is clicked
        private void ShowAttendaceSearchClick(object sender, EventArgs e)
        {
            this.ShowAttendaceSearchManager();
        }//----------------

        
        //###############################################END Show Attendace Search Manager EVENTS##################################################

        //###############################################Show Cashiering Manager EVENTS##################################################
        //event is raised when the control is clicked
        private void ShowCashieringClick(object sender, EventArgs e)
        {
            this.ShowCashiering();
        }//-----------------------------------
        //###############################################END Show Cashiering Manager EVENTS##################################################

        //###############################################Show Student Manager EVENTS##################################################
        //event is raised when the control is clicked
        private void ShowStudentClick(object sender, EventArgs e)
        {
            this.ShowStudentManager();
        }//-----------------------------------
        //###############################################END Show Student Manager EVENTS##################################################

        //###############################################Show Scholarship Manager EVENTS##################################################
        //event is raised when the control is clicked
        private void ShowScholarshipClick(object sender, EventArgs e)
        {
            this.ShowScholarship();
        }//-----------------------------------
        //###############################################END Show Scholarship Manager EVENTS##################################################

        //###############################################Show MajorExam Manager EVENTS##################################################
        //event is raised when the control is clicked
        private void ShowMajorExamScheduleClick(object sender, EventArgs e)
        {
            this.ShowMajorExam();
        }//-------------------------
        //###############################################END Show MajorExam Manager EVENTS##################################################

        //###############################################Show School Fee Manager EVENTS##################################################
        //event is raised when the control is clicked
        private void ShowSchoolFeeClick(object sender, EventArgs e)
        {
            this.ShowSchoolFeeManager();
        }//-----------------------------------
        //###############################################END Show School Fee Manager EVENTS##################################################

        //###############################################Show Auxilliary Information Manager EVENTS##################################################
        //event is raised when the control is clicked
        private void ShowAuxiliaryInformationClick(object sender, EventArgs e)
        {
            this.ShowAuxilliaryInformationManager();
        }//-----------------------------------
        //###############################################END Show Auxilliary Information Manager EVENTS##################################################

        //###############################################Show Auxilliary Scheduling Manager EVENTS##################################################
        //event is raised when the control is clicked
        private void ShowAuxiliarySchedulingClick(object sender, EventArgs e)
        {
            this.ShowAuxilliarySchedulingManager();
        }//-----------------------------------
        //###############################################END Show Auxilliary Scheduling Manager EVENTS##################################################

        //###############################################Show Student Loading Manager EVENTS##################################################
        //event is raised when the control is clicked
        private void ShowStudentLoadingClick(object sender, EventArgs e)
        {
            this.ShowStudentLoadingManager();
        }//-----------------------------------
        //###############################################END Show Student Loading Manager EVENTS##################################################

        //###############################################Show Subject Scheduling Manager EVENTS##################################################
        //event is raised when the control is clicked
        private void ShowSubjectSchedulingClick(object sender, EventArgs e)
        {
            this.ShowSubjectSchedulingManager();
        }//-------------------------
        //###############################################END Show Subject Scheduling Manager EVENTS##################################################

        //###############################################Show Teacher Loading Manager EVENTS##################################################
        //event is raised when the control is clicked
        private void ShowTeacherLoadingClick(object sender, EventArgs e)
        {
            this.ShowTeacherLoadingManager();
        }//--------------------
        //###############################################Show Teacher Loading Manager EVENTS##################################################

        //###############################################Show Earning Manager EVENTS##################################################
        //event is raised when the control is clicked
        private void ShowEarningClick(object sender, EventArgs e)
        {
            this.ShowEarningManager();
        }//---------------------
        //###############################################END Show Earning Manager EVENTS##################################################

        //###############################################Show Deduction Manager EVENTS##################################################
        //event is raised when the control is clicked
        private void ShowDeductionClick(object sender, EventArgs e)
        {
            this.ShowDeductionManager();
        }//-----------------------
        //###############################################END Show Deduction Manager EVENTS##################################################

        //###############################################Show Employee Manager EVENTS##################################################
        //event is raised when the control is clicked
        private void ShowEmployeeClick(object sender, EventArgs e)
        {
            this.ShowEmployeeManager();
        }//---------------------
        //###############################################END Show Employee Manager EVENTS##################################################

        //###############################################Show Load Remittance Manager EVENTS##################################################
        //event is raised when the control is clicked
        private void ShowLoanRemittanceClick(object sender, EventArgs e)
        {
            this.ShowLoadRemittanceManager();
        }//----------------------
        //###############################################END Show Load Remittance Manager EVENTS##################################################

        //###############################################Show Course Manager EVENTS##################################################
        //event is raised when the control is clicked
        private void ShowCourseClick(object sender, EventArgs e)
        {
            this.ShowCourseManager();
        }//----------------------
        //###############################################END Show Course Manager EVENTS##################################################

        //###############################################Show SchoolYearSemester Manager EVENTS##################################################
        //event is raised when the control is clicked
        private void ShowSchoolYearSemesterClick(object sender, EventArgs e)
        {
            this.ShowSchoolYearSemesterManager();
        }//---------------------
        //###############################################END Show SchoolYearSemester Manager EVENTS##################################################

        //###############################################Show Special Class Manager EVENTS##################################################
        //event is raised when the control is clicked
        private void ShowSpecialClassClick(object sender, EventArgs e)
        {
            this.ShowSpecialClassManager();
        }//----------------------
        //###############################################END Show Special Class Manager EVENTS##################################################

        //###############################################Show Transcript Class Manager EVENTS##################################################
        //event is raised when the control is clicked
        private void ShowTranscriptClassClick(object sender, EventArgs e)
        {
            this.ShowTranscriptManager();
        }//---------------------------
        //###############################################END Show Transcript Class Manager EVENTS##################################################

        //###############################################Show Chart of Account Manager EVENTS##################################################
        //event is raised when the control is clicked
        private void ShowChartOfAccount(object sender, EventArgs e)
        {
            this.ShowChartOfAccount();
        }//---------------------
        //###############################################END Show Chart of Account Manager EVENTS##################################################

        //###############################################Show Administration Services Manager EVENTS##################################################
        //event is raised when the control is clicked
        private void lblTransactionClick(object sender, EventArgs e)
        {
            this.ShowAdministrationManagerLog();
        }//--------------------

        //event is raised when the control is clicked
        private void lblUsersClick(object sender, EventArgs e)
        {
            this.ShowAdministrationManagerUser();
        }//-----------------------
        //###############################################END Show Administration Services Manager EVENTS##################################################

        //###############################################CLASS Mouse Leave EVENTS##################################################
        //event is raised when the mouse button leave
        private void controlMouseLeave(object sender, EventArgs e)
        {
            this.lblStatus.Text = " Ready";
        }//------------------------
        //###############################################END CLASS Mouse Leave EVENTS##################################################

        //###############################################CLASS Mouse Hover EVENTS##################################################
        //event is raised when the mouse toolstripbutton hover
        private void controlMouseEnter(object sender, EventArgs e)
        {
            String cntName = String.Empty;

            if (sender.GetType().Equals(typeof(ToolStripButton)))
            {
                cntName = ((ToolStripButton)sender).Name;
            }
            else if (sender.GetType().Equals(typeof(ToolStripMenuItem)))
            {
                cntName = ((ToolStripMenuItem)sender).Name;
            }

            if (String.Equals(cntName, this.btnIdentification.Name) || String.Equals(cntName, this.lblIdentification.Name))
            {
                this.lblStatus.Text = " Allows you to create and update student and employee ID";
            }
            else if (String.Equals(cntName, this.btnCashiering.Name) || String.Equals(cntName, this.lblCashiering.Name))
            {
                this.lblStatus.Text = " Allows you to accept and view student payments";
            }
            else if (String.Equals(cntName, this.btnStudent.Name) || String.Equals(cntName, this.lblStudent.Name))
            {
                this.lblStatus.Text = " Allows you to create a new student";
            }
            else if (String.Equals(cntName, this.btnSchoolFee.Name) || String.Equals(cntName, this.lblSchoolFee.Name))
            {
                this.lblStatus.Text = " Allows you to create school fees";
            }
            else if (String.Equals(cntName, this.btnStudentLoading.Name) || String.Equals(cntName, this.lblStudentLoading.Name))
            {
                this.lblStatus.Text = " Allows you to create a subject load";
            }
            else if (String.Equals(cntName, this.btnScholarship.Name) || String.Equals(cntName, this.lblScholarship.Name))
            {
                this.lblStatus.Text = " Allows you to define a scholarship and create a student scholarship";
            }
            else if (String.Equals(cntName, this.btnSubjectScheduling.Name) || String.Equals(cntName, this.lblSubjectScheduling.Name))
            {
                this.lblStatus.Text = " Allows you to create a subject schedule";
            }
            else if (String.Equals(cntName, this.btnTeacherLoading.Name) || String.Equals(cntName, this.lblTeacherLoading.Name))
            {
                this.lblStatus.Text = " Allows you to create a teacher load";
            }
            else if (String.Equals(cntName, this.btnAuxInformation.Name) || String.Equals(cntName, this.lblAuxiliaryInformation.Name))
            {
                this.lblStatus.Text = " Allows you to create an auxiliary information";
            }
            else if (String.Equals(cntName, this.btnAuxScheduling.Name) || String.Equals(cntName, this.lblAuxiliaryScheduling.Name))
            {
                this.lblStatus.Text = " Allows you to create an auxiliary schedule";
            }
            else if (String.Equals(cntName, this.btnEarning.Name) || String.Equals(cntName, this.lblEarning.Name))
            {
                this.lblStatus.Text = " Allows you to create an employee earning";
            }
            else if (String.Equals(cntName, this.btnDeduction.Name) || String.Equals(cntName, this.lblDeduction.Name))
            {
                this.lblStatus.Text = " Allows you to create an employee deduction";
            }
            else if (String.Equals(cntName, this.btnEmployee.Name)|| String.Equals(cntName, this.lblEmployee.Name))
            {
                this.lblStatus.Text = " Allows you to create an employee information";
            }
            else if (String.Equals(cntName, this.btnLoanRemittance.Name) || String.Equals(cntName, this.lblLoanRemittance.Name))
            {
                this.lblStatus.Text = " Allows you to create an employee loan remittance";
            }
            else if (String.Equals(cntName, this.lblMajorExamSchedule.Name) || String.Equals(cntName, this.lblMajorExamSchedule.Name))
            {
                this.lblStatus.Text = " Allows you to create a major exam schedule";
            }
            else if (String.Equals(cntName, this.btnCourse.Name) || String.Equals(cntName, this.lblCourse.Name))
            {
                this.lblStatus.Text = " Allows you to create a subject, create a classroom, and view a course";
            }
            else if (String.Equals(cntName, this.btnSchoolYearSemester.Name) || String.Equals(cntName, this.lblSchoolYearSemester.Name))
            {
                this.lblStatus.Text = " Allows you to open a school year and semester";
            }
            else if (String.Equals(cntName, this.btnSpecialClass.Name) || String.Equals(cntName, this.lblSpecialClass.Name))
            {
                this.lblStatus.Text = " Allows you to create a special class";
            }
            else if (String.Equals(cntName, this.btnMajorExamSchedule.Name) || String.Equals(cntName, this.lblMajorExamSchedule.Name))
            {
                this.lblStatus.Text = " Allows you to create a major exam schedule";
            }
            else if (String.Equals(cntName, this.lblUsers.Name))
            {
                this.lblStatus.Text = " Allows you to create new users";
            }
            else if (String.Equals(cntName, this.lblTransaction.Name))
            {
                this.lblStatus.Text = " Allows you to view and print transaction log";
            }
            else if (String.Equals(cntName, this.btnClose.Name))
            {
                this.lblStatus.Text = " Allows you to exit the application";
            }
            else if (String.Equals(cntName, this.lblHelp.Name))
            {
                this.lblStatus.Text = " Help Information";
            }
            else if (String.Equals(cntName, this.lblAbout.Name))
            {
                this.lblStatus.Text = " View Lapis Information";
            }
            else if (String.Equals(cntName, this.btnChartOfAccount.Name) || String.Equals(cntName, this.lblChartOfAccount.Name))
            {
                this.lblStatus.Text = " Allows you to create and update chart of account";
            }
            else if (String.Equals(cntName, this.btnAttendaceSearch.Name) || String.Equals(cntName, this.lblAttendaceSearch.Name))
            {
                this.lblStatus.Text = " Allows you to search student attendance";
            }
            else if (String.Equals(cntName, this.btnTranscript.Name) || String.Equals(cntName, this.lblTranscript.Name))
            {
                this.lblStatus.Text = " Allows you to create transcript";
            }
            else
            {
                this.lblStatus.Text = " Ready";
            }
        }//------------------------       
        //###############################################END CLASS Mouse Hover EVENTS##################################################

        private void UmsManagerFormClosed(object sender, FormClosedEventArgs e)
        {
            RemoteClient.ProcStatic.DeleteDirectory(CommonExchange.SystemConfiguration.ApplicationDocumentsFolder(Application.StartupPath));
        }
        #endregion

        #region Programers-Defined Void Procedures
        /// <summary>
        /// this procedure calls Identification Manager --------------- Attendance Solution
        /// </summary>
        private void ShowIdentificationManager()
        {
            try
            {
                using (IdentificationServices.IdentificationManager frmShow = new IdentificationServices.IdentificationManager(_userInfo))
                {
                    this.Cursor = Cursors.WaitCursor;
                    
                    frmShow.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Identification Manager Module.", "Error Loading");
            }
        }//-----------------------

        /// <summary>
        /// this procedure calls Attendace Search Manager ---------------- Attendace Solutions
        /// </summary>
        private void ShowAttendaceSearchManager()
        {
            try
            {
                using (AttendaceServices.AttendaceManager frmShow = new AttendaceServices.AttendaceManager(_userInfo))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmShow.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Attendace Search Manager Module.", "Error Loading");
            }
        }//----------------------------

        /// <summary>
        /// this procedure calls Student Mannager -------------- Finance Solution
        /// </summary>
        private void ShowStudentManager()
        {
            try
            {
                using (FinanceServices.StudentManager frmShow = new FinanceServices.StudentManager(_userInfo))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmShow.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Student Manager Module.", "Error Loading");
            }
        }//---------------------------

        /// <summary>
        /// this procedure call School Fee Manager ---------------- Finance Solution
        /// </summary>
        private void ShowSchoolFeeManager()
        {
            try
            {
                using (FinanceServices.SchoolFeeManager frmShow = new FinanceServices.SchoolFeeManager(_userInfo))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmShow.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading School Fee Manager Module.", "Error Loading");
            }
        }//----------------------

        /// <summary>
        /// this procedure calls Auxilliary Information Manager --------------- Office Solution
        /// </summary>
        private void ShowAuxilliaryInformationManager()
        {
            try
            {
                using (OfficeServices.AuxiliaryInformationManager frmShow = new OfficeServices.AuxiliaryInformationManager(_userInfo))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmShow.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Auxilliary Information Module.", "Error Loading");
            }
        }//---------------------

        /// <summary>
        /// this procedure calls Auxilliary Scheduling Manager----------------------- Office Solution
        /// </summary>
        private void ShowAuxilliarySchedulingManager()
        {
            try
            {
                using (OfficeServices.AuxiliarySchedulingManager frmShow = new OfficeServices.AuxiliarySchedulingManager(_userInfo))
                {
                    this.Cursor = Cursors.WaitCursor;
                    
                    frmShow.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Auxilliary Scheduling Module.", "Error Loading");
            }
        }//-------------------------

        /// <summary>
        /// this procedure calls Student Loading Module ----------------- Office Solution
        /// </summary>
        private void ShowStudentLoadingManager()
        {
            try
            {
                using (OfficeServices.StudentLoadingManager frmShow = new OfficeServices.StudentLoadingManager(_userInfo))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmShow.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Student Subject Loading Module.", "Error Loading");
            }
        }//--------------------------

        /// <summary>
        /// this procedure calls Subject Scheduling Manager ------------------ Office Solution
        /// </summary>
        private void ShowSubjectSchedulingManager()
        {
            try
            {
                using (OfficeServices.SubjectSchedulingManager frmShow = new OfficeServices.SubjectSchedulingManager(_userInfo))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmShow.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Subject Scheduling Manager.", "Error Loading");
            }
        }//-----------------------

        /// <summary>
        /// this procedure calls Teacher Loading Manager ------------- Office Solution
        /// </summary>
        private void ShowTeacherLoadingManager()
        {
            try
            {
                using (OfficeServices.TeacherLoadingManager frmShow = new OfficeServices.TeacherLoadingManager(_userInfo))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmShow.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }                
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Teacher Loading Module.", "Error Loading");
            }
        }//------------------------

         /// <summary>
        /// this procedure calls Earning Manager ------------------ Payroll Solution
        /// </summary>
        private void ShowEarningManager()
        {
            try
            {
                using (EmployeeServices.EarningManager frmShow = new EmployeeServices.EarningManager(_userInfo))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmShow.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Earning Module.", "Error Loading");
            }
        }//-----------------------

        /// <summary>
        /// this procedure calls Deduction Manager ------------------- Payroll Solution
        /// </summary>
        private void ShowDeductionManager()
        {
            try
            {
                using (EmployeeServices.DeductionManager frmShow = new EmployeeServices.DeductionManager(_userInfo))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmShow.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Deduction Module.", "Error Loading");
            }
        }//---------------------------

        /// <summary>
        /// this procedure calls Employee Manager Module -------------- Payroll Solution
        /// </summary>
        private void ShowEmployeeManager()
        {
            try
            {
                using (EmployeeServices.EmployeeManager frmShow = new EmployeeServices.EmployeeManager(_userInfo))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmShow.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Employee Module.", "Error Loading");
            }
        }//--------------------------

        /// <summary>
        /// this procedure calls Load Remittance Manager ------------ Payroll Solution
        /// </summary>
        private void ShowLoadRemittanceManager()
        {
            try
            {
                using (EmployeeServices.LoanRemittanceManager frmShow = new EmployeeServices.LoanRemittanceManager(_userInfo)) 
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmShow.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Load REmittance Module.", "Error Loading");
            }
        }//-------------------------

        /// <summary>
        /// this procedure calls Course Manager --------------- Registrar Solution
        /// </summary>
        private void ShowCourseManager()
        {
            try
            {
                using (RegistrarServices.CourseManager frmShow = new RegistrarServices.CourseManager(_userInfo))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmShow.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Course Module.", "Error Loading");
            }
        }//--------------------------


        /// <summary>
        /// this procedure calls School Year Semester Manager ------------------- Registrar Solution
        /// </summary>
        private void ShowSchoolYearSemesterManager()
        {
            try
            {
                using (RegistrarServices.SchoolYearSemesterManager frmShow = new RegistrarServices.SchoolYearSemesterManager(_userInfo))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmShow.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading School Year Semester Module.", "Error Loading");
            }
        }//----------------------

        /// <summary>
        /// this procedure calls Special Class Manager -------------- Registrar Solution
        /// </summary>
        private void ShowSpecialClassManager()
        {
            try
            {
                using (RegistrarServices.SpecialClassManager frmShow = new RegistrarServices.SpecialClassManager(_userInfo))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmShow.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Special Class Module.", "Error Loading");
            }
        }//------------------------

        /// <summary>
        /// this procedure calls Class Administration User Manager
        /// </summary>
        private void ShowAdministrationManagerUser()
        {
            try
            {
                using (AdministratorServices.AdministrationManagerUser frmShow = new AdministratorServices.AdministrationManagerUser(_userInfo))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmShow.ShowDialog(this);                    

                    this.Cursor = Cursors.Arrow;

                    if (frmShow.ExitUMS)
                    {
                        Application.Exit();
                    }
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Class Administration User  Module.", "Error Loading");
            }
        }//---------------------

        /// <summary>
        ///this procedure call the Class Administration Manager Log
        /// </summary>
        private void ShowAdministrationManagerLog()
        {
            try
            {
                using (AdministratorServices.AdministrationManagerLog frmShow = new AdministratorServices.AdministrationManagerLog(_userInfo))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmShow.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Class Administration Log Module.", "Error Loading");
            }
        }//-------------------

        /// <summary>
        /// this procedure calls the Class Scholarship
        /// </summary>
        private void ShowScholarship()
        {
            try
            {
                using (OfficeServices.ScholarshipManager frmShow = new OfficeServices.ScholarshipManager(_userInfo))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmShow.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Class Scholarship Module.", "Error Loading");
            }
        }//----------------

        /// <summary>
        /// this procedure calls the Class Major Exam
        /// </summary>
        private void ShowMajorExam()
        {
            try
            {
                using (RegistrarServices.MajorExamScheduleManager frmShow = new RegistrarServices.MajorExamScheduleManager(_userInfo))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmShow.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Class Major Exam Schedule Module.", "Error Loading");
            }        
        }//---------------------

        /// <summary>
        /// this procedure call the cashiering manager
        /// </summary>
        private void ShowCashiering()
        {
            try
            {
                using (FinanceServices.CashieringManager frmShow = new FinanceServices.CashieringManager(_userInfo))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmShow.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Class Cashiering Manager.", "Error Loading");
            }
        }//----------------------

        /// <summary>
        /// this procedure will show the chart of account manager
        /// </summary>
        private void ShowChartOfAccount()
        {
            try
            {
                using (AccountingServices.ChartOfAccountManager frmShow = new AccountingServices.ChartOfAccountManager(_userInfo))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmShow.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Class Chart of Account Manager.", "Error Loading");
            }
        }//----------------------

        /// <summary>
        /// this procedure will show the transcript manager
        /// </summary>
        private void ShowTranscriptManager()
        {
            try
            {
                using (RegistrarServices.TranscriptManager frmShow = new RegistrarServices.TranscriptManager(_userInfo))
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmShow.ShowDialog(this);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Class Transcript Manager.", "Error Loading");
            }
        }//--------------------------------
        #endregion
    }
}