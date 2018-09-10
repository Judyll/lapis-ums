using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;

namespace RemoteServer
{
    partial class ServerApplication
    {
        #region Class General Variable Declarations
        private Boolean _isClosed = false;
        #endregion

        #region Class Constructor
        public ServerApplication()
        {
            InitializeComponent();

            //register an event handler
            this.Load += new EventHandler(ClassLoad);
            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.KeyUp += new KeyEventHandler(ClassKeyUp);
            //----------------------------------
        }
        #endregion

        #region Class Event Void Procedures
        //###############################CLASS CFBMain EVENTS#########################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            this.lblVersion.Text = "Version " + Application.ProductVersion;

            //creates an instance of the channel
            TcpChannel channel = new TcpChannel(4080);
            ChannelServices.RegisterChannel(channel, false);
            //-----------------------------

            //register the classes
            this.RegRemSrvBinaryUpdater();
            this.RegRemSrvAdministratorManager();
            this.RegRemSrvBaseManager();
            this.RegRemSrvEmployeeManager();
            this.RegRemSrvDeductionManager();
            this.RegRemSrvEarningManager();
            this.RegRemSrvLoanManager();
            this.RegRemSrvSchoolYearSemesterManager();
            this.RegRemSrvCourseManager();
            this.RegRemSrvStudentManager();
            this.RegRemSrvSpecialClassManager();
            this.RegRemSrvSubjectSchedulingManager();
            this.RegRemSrvIdMakerManager();
            this.RegRemSrvTeacherLoadingManager();
            this.RegRemSrvAuxiliaryServicesManager();
            this.RegRemSrvSchoolFeeManager();
            this.RegRemSrvStudentEnrolmentManager();
            this.RegRemSrvStudentLoadingManager();
            this.RegRemSrvCashieringManager();
            this.RegRemSrvScholarshipManager();
            this.RegRemSrvMajorExamScheduleManager();
            this.RegRemSrvTranscriptManager();
            this.RegRemSrvCampusAccessManager();
            this.RegRemSrvAccountingManager();

            //-----------------------

        } //--------------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isClosed)
            {
                e.Cancel = true;
            }
        } //------------------------------

        //event is raised when the key is up
        private void ClassKeyUp(object sender, KeyEventArgs e)
        {
            if ((e.Shift == true && e.Control == true &&
                e.Alt == true && e.KeyCode == Keys.F10))
            {
                _isClosed = true;
                this.Close();
            }
            else
            {
                e.Handled = true;
            }
        }
        //###############################END CLASS CFBMain EVENTS######################################################
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure registeres the RemSrvBinaryUpdater Class
        private void RegRemSrvBinaryUpdater()
        {
            //register as an available service --> Class: RemSrvBinaryUpdater Method: SelectUMSBinaries
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvBinaryUpdater), "SelectUMSBinaries",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvBinaryUpdater Method: SelectUMSCampusAccessBinaries
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvBinaryUpdater), "SelectUMSCampusAccessBinaries",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

        } //------------------------------------------

        //this procedure registers the RemSrvAdministratorManager Class
        private void RegRemSrvAdministratorManager()
        {
            //register as an available service --> Class: RemSrvAdministratorManager Method: InsertSystemUserInfo
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAdministratorManager), "InsertSystemUserInfo",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvAdministratorManager Method: UpdateSystemUserInfo
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAdministratorManager), "UpdateSystemUserInfo",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvAdministratorManager Method: SelectBySystemUserIDSystemUserInfo
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAdministratorManager), "SelectBySystemUserIDSystemUserInfo",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvAdministratorManager Method: SelectBySysIDPersonSystemUserInfo
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAdministratorManager), "SelectBySysIDPersonSystemUserInfo",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvAdministratorManager Method: SelectSystemUserInfo
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAdministratorManager), "SelectSystemUserInfo",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvAdministratorManager Method: AuthenticateSystemUser
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAdministratorManager), "AuthenticateSystemUser",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvAdministratorManager Method: SelectTransactionLog
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAdministratorManager), "SelectTransactionLog",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvAdministratorManager Method: IsExistsNameSystemUserInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAdministratorManager), "IsExistsNameSystemUserInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvAdministratorManager Method: GetDataSetForAdministrator
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAdministratorManager), "GetDataSetForAdministrator",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

        } //-----------------------------------

        //this procedure registers the RegRemSrvGeneral Class
        private void RegRemSrvBaseManager()
        {
            //register as an available service --> Class: RemSrvBaseManager Method: InsertUpdatePersonInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvBaseManager), "InsertUpdatePersonInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvBaseManager Method: InsertUpdatePersonInformationNoAuthenticate
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvBaseManager), "InsertUpdatePersonInformationNoAuthenticate",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvBaseManager Method: InsertPayrollStandard
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvBaseManager), "InsertPayrollStandard",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvBaseManager Method: InsertRegistrarStandard
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvBaseManager), "InsertRegistrarStandard",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvBaseManager Method: InsertFinanceStandard
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvBaseManager), "InsertFinanceStandard",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvBaseManager Method: IsExistsSysIDPersonStudentEmployeeInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvBaseManager), "IsExistsSysIDPersonStudentEmployeeInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvBaseManager Method: SelectPersonInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvBaseManager), "SelectPersonInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvBaseManager Method: SelectBySysIDPersonInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvBaseManager), "SelectBySysIDPersonInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvBaseManager Method: SelectBySysIDPersonInformationNoAuthenticate
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvBaseManager), "SelectBySysIDPersonInformationNoAuthenticate",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvBaseManager Method: SelectPersonImagesPersonInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvBaseManager), "SelectPersonImagesPersonInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvBaseManager Method: SelectPayrollStandard
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvBaseManager), "SelectPayrollStandard",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvBaseManager Method: SelectRegistrarStandard
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvBaseManager), "SelectRegistrarStandard",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvBaseManager Method: SelectFinanceStandard
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvBaseManager), "SelectFinanceStandard",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvBaseManager Method: GetServerDateTime
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvBaseManager), "GetServerDateTime", 
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvBaseManager Method: GetServerDateTimeNoAuthenticate
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvBaseManager), "GetServerDateTimeNoAuthenticate",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvBaseManager Method: GetDataSetForBaseServices
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvBaseManager), "GetDataSetForBaseServices", 
                WellKnownObjectMode.SingleCall);
            //-----------------------------
                        
        } //-----------------------------------

        //this procedure registers the RemSrvEmployeeManager class
        private void RegRemSrvEmployeeManager()
        {

            //register as an available service --> Class: RemSrvEmployeeManager Method: InsertEmployeeInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvEmployeeManager), "InsertEmployeeInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvEmployeeManager Method: UpdateEmployeeInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvEmployeeManager), "UpdateEmployeeInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvEmployeeManager Method: SelectByEmployeeIDEmployeeInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvEmployeeManager), "SelectByEmployeeIDEmployeeInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvEmployeeManager Method: SelectBySysIDPersonEmployeeInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvEmployeeManager), "SelectBySysIDPersonEmployeeInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvEmployeeManager Method: IsExistsEmployeeIdEmployeeInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvEmployeeManager), "IsExistsEmployeeIdEmployeeInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvEmployeeManager Method: GetDataSetForEmployeeInfo
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvEmployeeManager), "GetDataSetForEmployeeInfo",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

        } //----------------------------------------

        
        //this procedure registers the RemSrvDeductionManager class
        private void RegRemSrvDeductionManager()
        {

            //register as an available service --> Class: RemSrvDeductionManager Method: DeleteEmployeeDeduction
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvDeductionManager), "DeleteEmployeeDeduction",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvDeductionManager Method: UpdateEmployeeDeduction
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvDeductionManager), "UpdateEmployeeDeduction",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvDeductionManager Method: InsertEmployeeDeduction
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvDeductionManager), "InsertEmployeeDeduction",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvDeductionManager Method: UpdateDeductionInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvDeductionManager), "UpdateDeductionInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvDeductionManager Method: InsertDeductionInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvDeductionManager), "InsertDeductionInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvDeductionManager Method: IsDeductionDescriptionExist
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvDeductionManager), "IsDeductionDescriptionExist",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvDeductionManager Method: GetDataSetForDeductionInfo
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvDeductionManager), "GetDataSetForDeductionInfo",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvDeductionManager Method: GetByDateFromDateToEmployeeDeduction
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvDeductionManager), "GetByDateFromDateToEmployeeDeduction",
                WellKnownObjectMode.SingleCall);
            //-----------------------------


        } //---------------------------------

        //this procedure registers the RemSrvEarningManager class
        private void RegRemSrvEarningManager()
        {

            //register as an available service --> Class: RemSrvEarningManager Method: DeleteEmployeeEarning
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvEarningManager), "DeleteEmployeeEarning",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvEarningManager Method: UpdateEmployeeEarning
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvEarningManager), "UpdateEmployeeEarning",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvEarningManager Method: InsertEmployeeEarning
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvEarningManager), "InsertEmployeeEarning",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvEarningManager Method: UpdateEarningInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvEarningManager), "UpdateEarningInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvEarningManager Method: InsertEarningInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvEarningManager), "InsertEarningInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvEarningManager Method: IsEarningDescriptionExist
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvEarningManager), "IsEarningDescriptionExist",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvEarningManager Method: GetDataSetForEarningInfo
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvEarningManager), "GetDataSetForEarningInfo",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvEarningManager Method: GetByDateFromDateToEmployeeEarning
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvEarningManager), "GetByDateFromDateToEmployeeEarning",
                WellKnownObjectMode.SingleCall);
            //-----------------------------


        } //---------------------------------

        //this procedure registers the RemSrvLoanManager class
        private void RegRemSrvLoanManager()
        {

            //register as an available service --> Class: RemSrvLoanManager Method: DeleteLoanRemittance
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvLoanManager), "DeleteLoanRemittance",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvLoanManager Method: UpdateDeleteEmployeeRemittance
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvLoanManager), "UpdateDeleteEmployeeRemittance",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvLoanManager Method: InsertEmployeeRemittance
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvLoanManager), "InsertEmployeeRemittance",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvLoanManager Method: UpdateLoanRemittance
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvLoanManager), "UpdateLoanRemittance",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvLoanManager Method: InsertLoanRemittance
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvLoanManager), "InsertLoanRemittance",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvLoanManager Method: UpdateLoanTypeInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvLoanManager), "UpdateLoanTypeInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvLoanManager Method: InsertLoanTypeInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvLoanManager), "InsertLoanTypeInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------         

            //register as an available service --> Class: RemSrvLoanManager Method: IsLoanTypeDescriptionExist
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvLoanManager), "IsLoanTypeDescriptionExist",
                WellKnownObjectMode.SingleCall);
            //-----------------------------   

            //register as an available service --> Class: RemSrvLoanManager Method: GetDataSetForLoanTypeInfo
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvLoanManager), "GetDataSetForLoanTypeInfo",
                WellKnownObjectMode.SingleCall);
            //-----------------------------   

            //register as an available service --> Class: RemSrvLoanManager Method: SelectByEmployeeIDEmployeeRemittance
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvLoanManager), "SelectByEmployeeIDEmployeeRemittance",
                WellKnownObjectMode.SingleCall);
            //-----------------------------  

            //register as an available service --> Class: RemSrvLoanManager Method: SelectByEmployeeIDLoanRemittance
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvLoanManager), "SelectByEmployeeIDLoanRemittance",
                WellKnownObjectMode.SingleCall);
            //-----------------------------  


        } //---------------------------------

        //this procedure registers the RemSrvSchoolYearSemesterManager class
        private void RegRemSrvSchoolYearSemesterManager()
        {

            //register as an available service --> Class: RemSrvSchoolYearSemesterManager Method: InsertSemesterInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolYearSemesterManager), "InsertSemesterInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSchoolYearSemesterManager Method: InsertSchoolYear
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolYearSemesterManager), "InsertSchoolYear",
                WellKnownObjectMode.SingleCall);
            //-----------------------------  

            //register as an available service --> Class: RemSrvSchoolYearSemesterManager Method: InsertSchoolYearSummer
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolYearSemesterManager), "InsertSchoolYearSummer",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSchoolYearSemesterManager Method: SelectByYearDescriptionSchoolYearTable
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolYearSemesterManager), "SelectByYearDescriptionSchoolYearTable",
                WellKnownObjectMode.SingleCall);
            //-----------------------------  

            //register as an available service --> Class: RemSrvSchoolYearSemesterManager Method: SelectYearSemesterDescriptionSemesterInformationTable
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolYearSemesterManager), 
                "SelectYearSemesterDescriptionSemesterInformationTable", WellKnownObjectMode.SingleCall);
            //-----------------------------  

            //register as an available service --> Class: RemSrvSchoolYearSemesterManager Method: GetMaxDateEndSemesterInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolYearSemesterManager), "GetMaxDateEndSemesterInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------  

            //register as an available service --> Class: RemSrvSchoolYearSemesterManager Method: GetMaxDateEndSchoolYear
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolYearSemesterManager), "GetMaxDateEndSchoolYear",
                WellKnownObjectMode.SingleCall);
            //-----------------------------  

            //register as an available service --> Class: RemSrvSchoolYearSemesterManager Method: GetDataSetForSchoolYearSemeter
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolYearSemesterManager), "GetDataSetForSchoolYearSemeter",
                WellKnownObjectMode.SingleCall);
            //-----------------------------  

        } //------------------------------

        //this procedure registers the RemSrvCourseManager class
        private void RegRemSrvCourseManager()
        {
            //register as an available service --> Class: RemSrvCourseManager Method: InsertSubjectInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCourseManager), "InsertSubjectInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCourseManager Method: UpdateSubjectInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCourseManager), "UpdateSubjectInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------  

            //register as an available service --> Class: RemSrvCourseManager Method: InsertClassroomInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCourseManager), "InsertClassroomInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------  

            //register as an available service --> Class: RemSrvCourseManager Method: UpdateClassroomInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCourseManager), "UpdateClassroomInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------  

            //register as an available service --> Class: RemSrvCourseManager Method: SelectBySubjectIDSubjectPrerequisite
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCourseManager), "SelectBySubjectIDSubjectPrerequisite",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCourseManager Method: SelectSubjectInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCourseManager), "SelectSubjectInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------      

            //register as an available service --> Class: RemSrvCourseManager Method: SelectClassroomInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCourseManager), "SelectClassroomInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------  

            //register as an available service --> Class: RemSrvCourseManager Method: SelectByTitleAcronymCourseInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCourseManager), "SelectCourseInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------  

            //register as an available service --> Class: RemSrvCourseManager Method: IsExistCodeDescriptionSubjectInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCourseManager), "IsExistCodeDescriptionSubjectInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCourseManager Method: IsExistCodeClassroomInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCourseManager), "IsExistCodeClassroomInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------  

            //register as an available service --> Class: RemSrvCourseManager Method: IsExistTitleAcronymCourseInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCourseManager), "IsExistTitleAcronymCourseInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------  

            //register as an available service --> Class: RemSrvCourseManager Method: GetDataSetForClassroomSubject
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCourseManager), "GetDataSetForClassroomSubject",
                WellKnownObjectMode.SingleCall);
            //-----------------------------             


        } //---------------------------

        //this procedure registers the RemSrvStudentManager class
        private void RegRemSrvStudentManager()
        {
            //register as an available service --> Class: RemSrvStudentManager Method: InsertStudentInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentManager), "InsertStudentInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentManager Method: UpdateStudentInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentManager), "UpdateStudentInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentManager Method: GetCountForStudentIDStudentInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentManager), "GetCountForStudentIDStudentInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvStudentManager Method: SelectByStudentIDStudentInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentManager), "SelectByStudentIDStudentInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvStudentManager Method: SelectBySysIDPersonStudentInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentManager), "SelectBySysIDPersonStudentInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvStudentManager Method: SelectStudentInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentManager), "SelectStudentInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvStudentManager Method: IsExistStudentIdStudentInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentManager), "IsExistsStudentIdStudentInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvStudentManager Method: GetDataSetForStudentInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentManager), "GetDataSetForStudentInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

        } //---------------------------

        //this procedure registers the RemSrvSpecialClassManager class
        private void RegRemSrvSpecialClassManager()
        {
            //register as an available service --> Class: RemSrvSpecialClassManager Method: InsertSpecialClassInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSpecialClassManager), "InsertSpecialClassInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSpecialClassManager Method: UpdateSpecialClassInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSpecialClassManager), "UpdateSpecialClassInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSpecialClassManager Method: DeleteSpecialClassInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSpecialClassManager), "DeleteSpecialClassInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSpecialClassManager Method: DeleteSpecialClassLoad
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSpecialClassManager), "DeleteSpecialClassLoad",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSpecialClassManager Method: SelectByDateStartEndSpecialClassInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSpecialClassManager), "SelectByDateStartEndSpecialClassInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSpecialClassManager Method: SelectBySysIDSpecialSpecialClassLoad
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSpecialClassManager), "SelectBySysIDSpecialSpecialClassLoad",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSpecialClassManager Method: SelectBySysIDStudentListDateStartEndSpecialClassInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSpecialClassManager), 
                "SelectBySysIDStudentListDateStartEndSpecialClassInformation", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSpecialClassManager Method: SelectBySysIDEmployeeListDateStartEndSpecialClassInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSpecialClassManager),
                "SelectBySysIDEmployeeListDateStartEndSpecialClassInformation", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSpecialClassManager Method: IsExistsInformationSpecialClassInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSpecialClassManager), "IsExistsInformationSpecialClassInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSpecialClassManager Method: GetDataSetForSpecialClassInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSpecialClassManager), "GetDataSetForSpecialClassInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 
            
        } //---------------------------

        //this procedure registers the RemSrvSubjectSchedulingManager class
        private void RegRemSrvSubjectSchedulingManager()
        {
            //register as an available service --> Class: RemSrvSubjectSchedulingManager Method: InsertScheduleInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSubjectSchedulingManager), "InsertScheduleInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSubjectSchedulingManager Method: UpdateScheduleInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSubjectSchedulingManager), "UpdateScheduleInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSubjectSchedulingManager Method: DeleteScheduleInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSubjectSchedulingManager), "DeleteScheduleInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSubjectSchedulingManager Method: InsertScheduleInformationDetails
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSubjectSchedulingManager), "InsertScheduleInformationDetails",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSubjectSchedulingManager Method: UpdateScheduleInformationDetails
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSubjectSchedulingManager), "UpdateScheduleInformationDetails",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvSubjectSchedulingManager Method: DeleteScheduleInformationDetails
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSubjectSchedulingManager), "DeleteScheduleInformationDetails",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvSubjectSchedulingManager Method: SelectByDateStartEndScheduleInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSubjectSchedulingManager), "SelectByDateStartEndScheduleInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvSubjectSchedulingManager Method: SelectByDateStartEndScheduleInformationDetails
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSubjectSchedulingManager), 
                "SelectByDateStartEndScheduleInformationDetails", WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvSubjectSchedulingManager Method: SelectBySysIDScheduleScheduleInformationDetails
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSubjectSchedulingManager), 
                "SelectBySysIDScheduleScheduleInformationDetails", WellKnownObjectMode.SingleCall);
            //-----------------------------      

            //register as an available service --> Class: RemSrvSubjectSchedulingManager Method: SelectByClassroomCodeSubjectSchedule
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSubjectSchedulingManager), "SelectByClassroomCodeSubjectSchedule",
                WellKnownObjectMode.SingleCall);
            //-----------------------------             

            //register as an available service --> Class: RemSrvSubjectSchedulingManager Method: SelectBySysIDScheduleDetailsListSubjectSchedule
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSubjectSchedulingManager), 
                "SelectBySysIDScheduleDetailsListSubjectSchedule", WellKnownObjectMode.SingleCall);
            //-----------------------------   

            //register as an available service --> Class: RemSrvSubjectSchedulingManager Method: GetDataSetForScheduleInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSubjectSchedulingManager), "GetDataSetForScheduleInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

        } //-----------------------------------

        //this procedure registers the RemSrvIdMakerManager class
        private void RegRemSrvIdMakerManager()
        {
            //register as an available service --> Class: RemSrvIdMakerManager Method: UpdateForIdMakerEmployeeInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvIdMakerManager), "UpdateForIdMakerEmployeeInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvIdMakerManager Method: UpdateForIdMakerStudentInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvIdMakerManager), "UpdateForIdMakerStudentInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvIdMakerManager Method: SelectByQueryStringStudentEmployeeInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvIdMakerManager), "SelectByQueryStringStudentEmployeeInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvIdMakerManager Method:  IsExistsCardNumberStudentInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvIdMakerManager), "IsExistsCardNumberStudentInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvIdMakerManager Method:  IsExistsCardNumberEmployeeInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvIdMakerManager), "IsExistsCardNumberEmployeeInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 
        } //-------------------------------------

        //this procedure registers the RemSrvTeacherLoadingManager class
        private void RegRemSrvTeacherLoadingManager()
        {
            //register as an available service --> Class: RemSrvTeacherLoadingManager Method: InsertDeleteTeacherLoad
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvTeacherLoadingManager), "InsertDeleteTeacherLoad",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvTeacherLoadingManager Method: SelectByScheduleDetailsListConflictsWithAnotherScheduleTeacherLoad
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvTeacherLoadingManager),
                "SelectByScheduleDetailsListConflictsWithAnotherScheduleTeacherLoad", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvTeacherLoadingManager Method: SelectByDateStartEndForTeacherLoadingTeacherLoad
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvTeacherLoadingManager), 
                "SelectByDateStartEndForTeacherLoadingTeacherLoad", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvTeacherLoadingManager Method: GetDataSetForTeacherLoad
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvTeacherLoadingManager), "GetDataSetForTeacherLoad",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 
        } //--------------------------------------

        //this procedure registers the RemSrvAuxiliaryServicesManager class
        private void RegRemSrvAuxiliaryServicesManager()
        {
            //register as an available service --> Class: RemSrvAuxiliaryServicesManager Method: InsertAuxiliaryServiceInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAuxiliaryServicesManager), "InsertAuxiliaryServiceInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvAuxiliaryServicesManager Method: UpdateAuxiliaryServiceInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAuxiliaryServicesManager), "UpdateAuxiliaryServiceInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvAuxiliaryServicesManager Method: InsertAuxiliaryServiceSchedule
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAuxiliaryServicesManager), "InsertAuxiliaryServiceSchedule",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvAuxiliaryServicesManager Method: UpdateAuxiliaryServiceSchedule
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAuxiliaryServicesManager), "UpdateAuxiliaryServiceSchedule",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvAuxiliaryServicesManager Method: DeleteAuxiliaryServiceSchedule
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAuxiliaryServicesManager), "DeleteAuxiliaryServiceSchedule",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvAuxiliaryServicesManager Method: InsertAuxiliaryServiceDetails
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAuxiliaryServicesManager), "InsertAuxiliaryServiceDetails",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvAuxiliaryServicesManager Method: UpdateAuxiliaryServiceDetails
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAuxiliaryServicesManager), "UpdateAuxiliaryServiceDetails",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvAuxiliaryServicesManager Method: DeleteAuxiliaryServiceDetails
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAuxiliaryServicesManager), "DeleteAuxiliaryServiceDetails",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvAuxiliaryServicesManager Method: SelectByServiceCodeTitleAuxiliaryServiceInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAuxiliaryServicesManager), 
                "SelectByServiceCodeTitleAuxiliaryServiceInformation", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvAuxiliaryServicesManager Method: SelectByDateStartEndAuxiliaryServiceDetails
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAuxiliaryServicesManager), 
                "SelectByDateStartEndAuxiliaryServiceDetails", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvAuxiliaryServicesManager Method: IsExistCodeDescriptionAuxiliaryServiceInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAuxiliaryServicesManager),  
                "IsExistCodeDescriptionAuxiliaryServiceInformation", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvAuxiliaryServicesManager Method: GetDataSetForTeacherLoad
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAuxiliaryServicesManager), "GetDataSetForAuxiliaryService",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 
            
        } //--------------------------------------

        //this procedure registers the RemSrvSchoolFeeManager class
        private void RegRemSrvSchoolFeeManager()
        {
            //register as an available service --> Class: RemSrvSchoolFeeManager Method: InsertStudentAdditionalFee
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolFeeManager), "InsertStudentAdditionalFee",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSchoolFeeManager Method: InsertStudentAdditionalFeeTable
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolFeeManager), "InsertStudentAdditionalFeeTable",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSchoolFeeManager Method: UpdateStudentAdditionalFee
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolFeeManager), "UpdateStudentAdditionalFee",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSchoolFeeManager Method: DeleteStudentAdditionalFee
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolFeeManager), "DeleteStudentAdditionalFee",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSchoolFeeManager Method: InsertDeleteStudentOptionalFee
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolFeeManager), "InsertDeleteStudentOptionalFee",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSchoolFeeManager Method: InsertSchoolFeeDetails
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolFeeManager), "InsertSchoolFeeDetails",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSchoolFeeManager Method: UpdateSchoolFeeDetails
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolFeeManager), "UpdateSchoolFeeDetails",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSchoolFeeManager Method: DeleteSchoolFeeDetails
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolFeeManager), "DeleteSchoolFeeDetails",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSchoolFeeManager Method: InsertSchoolFeeParticular
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolFeeManager), "InsertSchoolFeeParticular",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSchoolFeeManager Method: UpdateSchoolFeeParticular
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolFeeManager), "UpdateSchoolFeeParticular",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSchoolFeeManager Method: DeleteSchoolFeeParticular
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolFeeManager), "DeleteSchoolFeeParticular",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSchoolFeeManager Method: InsertSchoolFeeLevel
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolFeeManager), "InsertSchoolFeeLevel",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSchoolFeeManager Method: InsertSchoolFeeInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolFeeManager), "InsertSchoolFeeInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvSchoolFeeManager Method: SelectStudentAdditionalFee
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolFeeManager), "SelectStudentAdditionalFee",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvSchoolFeeManager Method: SelectBySysIDStudentDateStartEndStudentAdditionalFee
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolFeeManager), 
                "SelectBySysIDStudentDateStartEndStudentAdditionalFee", WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvSchoolFeeManager Method: SelectByDateStartEndSchoolFeeDetails
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolFeeManager), "SelectByDateStartEndSchoolFeeDetails",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSchoolFeeManager Method: SelectBySysIDSchoolFeeSchoolFeeLevel
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolFeeManager), "SelectBySysIDSchoolFeeSchoolFeeLevel",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSchoolFeeManager Method: SelectBySysIDStudentFeeLevelSemesterForOptionalFeeDetailsStudentOptionalFee
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolFeeManager), 
                "SelectBySysIDStudentFeeLevelSemesterForOptionalFeeDetailsStudentOptionalFee", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSchoolFeeManager Method: IsExistsSchoolFeeYearLevel
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolFeeManager), "IsExistsSchoolFeeYearLevel",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSchoolFeeManager Method: IsExistsYearIDSchoolFeeInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolFeeManager), "IsExistsYearIDSchoolFeeInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSchoolFeeManager Method: IsExistsParticularDescriptionSchoolFeeParticular
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolFeeManager), "IsExistsParticularDescriptionSchoolFeeParticular",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSchoolFeeManager Method: IsExistsLevelParticularSchoolFeeDetails
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolFeeManager), "IsExistsLevelParticularSchoolFeeDetails",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvSchoolFeeManager Method: GetDataSetForSchoolFee
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvSchoolFeeManager), "GetDataSetForSchoolFee",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

        } //----------------------------------

        //this procedure registers the RemSrvStudentEnrolmentManager class
        private void RegRemSrvStudentEnrolmentManager()
        {
            //register as an available service --> Class: RemSrvStudentEnrolmentManager Method: InsertStudentEnrolmentLevel
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager), "InsertStudentEnrolmentLevel",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentEnrolmentManager Method: UpdateStudentEnrolmentLevel
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager), "UpdateStudentEnrolmentLevel",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentEnrolmentManager Method: DeleteStudentEnrolmentLevel
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager), "DeleteStudentEnrolmentLevel",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentEnrolmentManager Method: InsertStudentEnrolmentCourse
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager), "InsertStudentEnrolmentCourse",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentEnrolmentManager Method: UpdateStudentEnrolmentCourse
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager), "UpdateStudentEnrolmentCourse",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentEnrolmentManager Method: SelectBySysIDStudentDateStartEndStudentEnrolmentCourse
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager), 
                "SelectBySysIDStudentDateStartEndStudentEnrolmentCourse", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentEnrolmentManager Method: SelectBySysIDStudentStudentEnrolmentCourse
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager), 
                "SelectBySysIDStudentStudentEnrolmentCourse", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentEnrolmentManager Method: SelectBySysIDStudentYearIDSemesterStudentEnrolmentLevel
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager), 
                "SelectBySysIDStudentYearIDSemesterStudentEnrolmentLevel", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentEnrolmentManager Method: SelectBySysIDStudentStudentEnrolmentLevel
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager), 
                "SelectBySysIDStudentStudentEnrolmentLevel", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentEnrolmentManager Method: SelectBySysIDStudentForEnrolmentHistoryEnrolmentCourse
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager), 
                "SelectBySysIDStudentForEnrolmentHistoryEnrolmentCourse", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentEnrolmentManager Method: SelectBySysIDStudentForEnrolmentHistoryEnrolmentLevel
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager), 
                "SelectBySysIDStudentForEnrolmentHistoryEnrolmentLevel", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentEnrolmentManager Method: SelectByCourseIDSysIDEnrolmentLevelEnrolmentCourseMajor
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager), 
                "SelectByCourseIDSysIDEnrolmentLevelEnrolmentCourseMajor", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentEnrolmentManager Method: IsExistsStudentCourseStudentEnrolmentCourse
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager), 
                "IsExistsStudentCourseStudentEnrolmentCourse", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentEnrolmentManager 
                        //Method: IsValidByCourseInformationSchoolFeeSysIDSemesterStudentEnrolmentCourse
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager), 
                "IsValidByCourseInformationSchoolFeeSysIDSemesterStudentEnrolmentCourse", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentEnrolmentManager Method: IsCourseYearLevelNoLesserStudentEnrolmentLevel
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager), 
                "IsCourseYearLevelNoLesserStudentEnrolmentLevel", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentEnrolmentManager Method: IsValidForYearLevelChangeEnrolmentLevel
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager),
                "IsValidForYearLevelChangeEnrolmentLevel", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentEnrolmentManager Method: IsLevelCourseGroupWithEntryLevelEnrolmentLevel
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager),  
                "IsLevelCourseGroupWithEntryLevelEnrolmentLevel", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentEnrolmentManager Method: IsExistSysIDStudentCourseLevelSemesterEnrolmentLevel
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager), 
                "IsExistSysIDStudentCourseLevelSemesterEnrolmentLevel", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentEnrolmentManager Method: IsNotValidForCourseSchoolFeeSysIDSemesterStudentEnrolmentLevel
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager), 
                "IsNotValidForCourseSchoolFeeSysIDSemesterStudentEnrolmentLevel", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentEnrolmentManager Method: IsValidForShiftToCurrentCourseStudentEnrolmentLevel
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager),
                "IsValidForShiftToCurrentCourseStudentEnrolmentLevel", WellKnownObjectMode.SingleCall);
            //----------------------------- 

        } //---------------------------------------

        //this procedure registers the RemSrvStudentLoadingManager class
        private void RegRemSrvStudentLoadingManager()
        {
            //register as an available service --> Class: RemSrvStudentLoadingManager Method: InsertUpdateDeleteStudentLoad
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentLoadingManager), "InsertUpdateDeleteStudentLoad",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentLoadingManager Method: SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentLoadingManager), 
                "SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentLoadingManager Method: SelectBySysIDEnrolmentLevelDateStartEndScheduleDetailsStudentLoad
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentLoadingManager), 
                "SelectBySysIDEnrolmentLevelDateStartEndScheduleDetailsStudentLoad", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentLoadingManager Method: SelectBySysIDEnrolmentLevelListSubjectScheduleStudentLoad
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentLoadingManager), 
                "SelectBySysIDEnrolmentLevelListSubjectScheduleStudentLoad", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentLoadingManager Method: SelectBySysIDEnrolmentLevelListScheduleDetailsStudentLoad
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentLoadingManager), 
                "SelectBySysIDEnrolmentLevelListScheduleDetailsStudentLoad", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentLoadingManager Method: SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentLoadingManager), 
                "SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvStudentLoadingManager Method: SelectBySysIDStudentEnrolmentLevelListSchoolFeeDetailsStudentLoad
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentLoadingManager), 
                "SelectBySysIDStudentEnrolmentLevelListSchoolFeeDetailsStudentLoad", WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvStudentLoadingManager Method: SelectBySysIDScheduleListStudentLoad
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentLoadingManager), "SelectBySysIDScheduleListStudentLoad",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvStudentLoadingManager Method: SelectBySysIDStudentListDateEndingBalanceCarriedForwardStudentLoad
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentLoadingManager), 
                "SelectBySysIDStudentListDateEndingBalanceCarriedForwardStudentLoad", WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvStudentLoadingManager Method:     
            //SelectBySysIDStudentListDateEndingAccountReceivablePerFiscalYearStudentLoad
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentLoadingManager),
                "SelectBySysIDStudentListDateEndingAccountReceivablePerFiscalYearStudentLoad", WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvStudentLoadingManager Method:     
            //SelectBySysIDStudentListDateStartEndCutOffDateAccountReceivablePerTermStudentLoad
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentLoadingManager),
                "SelectBySysIDStudentListDateStartEndCutOffDateAccountReceivablePerTermStudentLoad", WellKnownObjectMode.SingleCall);
            //-----------------------------
            
            //register as an available service --> Class: RemSrvStudentLoadingManager Method:     
            //SelectBySysIDStudentListForStudentRunningBalanceStudentLoad
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentLoadingManager),
                "SelectBySysIDStudentListForStudentRunningBalanceStudentLoad", WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvStudentLoadingManager Method: GetDataSetForStudentLoad
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvStudentLoadingManager), "GetDataSetForStudentLoad",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 


        } //------------------------------------------

        //this procedure registers the RemSrvCashieringManager class
        private void RegRemSrvCashieringManager()
        {
            //register as an available service --> Class: RemSrvCashieringManager Method: InsertUpdateStudentBalanceForwarded
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "InsertUpdateStudentBalanceForwarded",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvCashieringManager Method: DeleteStudentBalanceForwarded
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "DeleteStudentBalanceForwarded",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvCashieringManager Method: InsertStudentPayments
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "InsertStudentPayments",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvCashieringManager Method: UpdateStudentPayments
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "UpdateStudentPayments",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvCashieringManager Method: DeleteStudentPayments
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "DeleteStudentPayments",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvCashieringManager Method: InsertStudentDiscounts
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "InsertStudentDiscounts",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: UpdateStudentDiscounts
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "UpdateStudentDiscounts",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: DeleteStudentDiscounts
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "DeleteStudentDiscounts",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: InsertStudentReimbursements
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "InsertStudentReimbursements",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: UpdateStudentReimbursements
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "UpdateStudentReimbursements",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: DeleteStudentReimbursements
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "DeleteStudentReimbursements",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: InsertStudentCreditMemo
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "InsertStudentCreditMemo",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: UpdateStudentCreditMemo
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "UpdateStudentCreditMemo",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: DeleteStudentCreditMemo
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "DeleteStudentCreditMemo",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: InsertStudentPromissoryNote
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "InsertStudentPromissoryNote",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: UpdateStudentPromissoryNote
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "UpdateStudentPromissoryNote",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: DeleteStudentPromissoryNote
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "DeleteStudentPromissoryNote",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: InsertCancelledReceiptNo
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "InsertCancelledReceiptNo",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: UpdateCancelledReceiptNo
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "UpdateCancelledReceiptNo",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: DeleteCancelledReceiptNo
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "DeleteCancelledReceiptNo",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: InsertMiscellaneousIncome
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "InsertMiscellaneousIncome",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: UpdateMiscellaneousIncome
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "UpdateMiscellaneousIncome",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: DeleteMiscellaneousIncome
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "DeleteMiscellaneousIncome",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: InsertBreakdownBankDeposit
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "InsertBreakdownBankDeposit",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: UpdateBreakdownBankDeposit
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "UpdateBreakdownBankDeposit",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 
            
            //register as an available service --> Class: RemSrvCashieringManager Method: DeleteBreakdownBankDeposit
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "DeleteBreakdownBankDeposit",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: SelectBySysIDStudentListDateStartEndStudentPromissoryNote
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), 
                "SelectBySysIDStudentListDateStartEndStudentPromissoryNote", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: SelectBySysIDStudentListDateStartEndStudentPaymentsDiscountsReimbursement
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), 
                "SelectBySysIDStudentListDateStartEndStudentPaymentsDiscountsReimbursement", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: SelectByDateStartEndCourseScholarshipListStudentDiscounts
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager),
                "SelectByDateStartEndCourseScholarshipListStudentDiscounts", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: SelectByDateStartEndStudentCreditMemo
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager),
                "SelectByDateStartEndStudentCreditMemo", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: SelectCancelledReceiptNo
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager),
                "SelectCancelledReceiptNo", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: SelectByQueryStringDateStartEndMiscellaneousIncome
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager),
                "SelectByQueryStringDateStartEndMiscellaneousIncome", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager 
            //Method: SelectByDateStartEndCashReceiptsDetailedStudentPaymentMiscellaneousIncome
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager),
                "SelectByDateStartEndCashReceiptsDetailedStudentPaymentMiscellaneousIncome", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager 
            //Method: SelectByDateStartEndCashReceiptsSummarizedStudentPaymentMiscellaneousIncome
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager),
                "SelectByDateStartEndCashReceiptsSummarizedStudentPaymentMiscellaneousIncome", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager 
            //Method: SelectByDateStartEndCashReceiptsDetailedBreakdownBankDeposit
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager),
                "SelectByDateStartEndCashReceiptsDetailedBreakdownBankDeposit", WellKnownObjectMode.SingleCall);
            //-----------------------------  

            //register as an available service --> Class: RemSrvCashieringManager 
            //Method: SelectByDateStartEndCashReceiptsSummarizedBreakdownBankDeposit
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager),
                "SelectByDateStartEndCashReceiptsSummarizedBreakdownBankDeposit", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager 
            //Method: SelectByQueryStringDateStartEndCashReceiptsQueryStudentPaymentMiscellaneousIncome
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager),
                "SelectByQueryStringDateStartEndCashReceiptsQueryStudentPaymentMiscellaneousIncome", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager 
            //Method: SelectByDateStartEndCashDiscountsStudentPaymentMiscellaneousIncome
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager),
                "SelectByDateStartEndCashDiscountsStudentPaymentMiscellaneousIncome", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: IsExistsPaymentBySysIDStudentDateStartEndStudentPayments
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), 
                "IsExistsPaymentBySysIDStudentDateStartEndStudentPayments", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: IsExistsReceiptNoStudentPayments
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "IsExistsReceiptNoStudentPayments",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: IsExistsSysIDStudentStudentBalanceForwarded
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "IsExistsSysIDStudentStudentBalanceForwarded",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCashieringManager Method: GetDataSetForCashiering
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCashieringManager), "GetDataSetForCashiering",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 


        } //------------------------------------------

        //this procedure registers the RemSrvScholarshipManager class
        private void RegRemSrvScholarshipManager()
        {
            //register as an available service --> Class: RemSrvScholarshipManager Method: InsertScholarshipInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvScholarshipManager), "InsertScholarshipInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvScholarshipManager Method: UpdateScholarshipInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvScholarshipManager), "UpdateScholarshipInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvScholarshipManager Method: InsertStudentScholarship
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvScholarshipManager), "InsertStudentScholarship",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvScholarshipManager Method: UpdateStudentScholarship
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvScholarshipManager), "UpdateStudentScholarship",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvScholarshipManager Method: DeleteStudentScholarship
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvScholarshipManager), "DeleteStudentScholarship",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvScholarshipManager Method: SelectStudentScholarship
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvScholarshipManager), "SelectStudentScholarship",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvScholarshipManager Method: SelectBySysIDEnrolmentLevelStudentScholarship
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvScholarshipManager), "SelectBySysIDEnrolmentLevelStudentScholarship",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvScholarshipManager Method: IsExistsScholarshipDescriptionScholarshipInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvScholarshipManager), 
                "IsExistsScholarshipDescriptionScholarshipInformation", WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvScholarshipManager Method: IsExistsSysIDStudentScholarshipEnrolmentLevelStudentScholarship
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvScholarshipManager), 
                "IsExistsSysIDStudentScholarshipEnrolmentLevelStudentScholarship", WellKnownObjectMode.SingleCall);
            //-----------------------------

            //register as an available service --> Class: RemSrvScholarshipManager Method: GetDataSetForScholarship
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvScholarshipManager), "GetDataSetForScholarship",
                WellKnownObjectMode.SingleCall);
            //-----------------------------

        } //------------------------------------------

        //this procedure registers the RemSrvMajorExamScheduleManager class
        private void RegRemSrvMajorExamScheduleManager()
        {
            //register as an available service --> Class: RemSrvMajorExamScheduleManager Method: InsertMajorExamSchedule
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvMajorExamScheduleManager), "InsertMajorExamSchedule",
                WellKnownObjectMode.SingleCall);
            //-----------------------------      

            //register as an available service --> Class: RemSrvMajorExamScheduleManager Method: UpdateMajorExamSchedule
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvMajorExamScheduleManager), "UpdateMajorExamSchedule",
                WellKnownObjectMode.SingleCall);
            //-----------------------------  

            //register as an available service --> Class: RemSrvMajorExamScheduleManager Method: DeleteMajorExamSchedule
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvMajorExamScheduleManager), "DeleteMajorExamSchedule",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvMajorExamScheduleManager Method: SelectMajorExamSchedule
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvMajorExamScheduleManager), "SelectMajorExamSchedule",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvMajorExamScheduleManager Method: IsExistsYearSemesterIDExamDateInformationIDExamSchedule
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvMajorExamScheduleManager), 
                "IsExistsYearSemesterIDExamDateInformationIDExamSchedule", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvMajorExamScheduleManager Method: GetDataSetForMajorExamSchedule
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvMajorExamScheduleManager), "GetDataSetForMajorExamSchedule",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

        } //------------------------------------------

        //this procedure registers the RemSrvTranscriptManager class
        private void RegRemSrvTranscriptManager()
        {
            //register as an available service --> Class: RemSrvTranscriptManager Method: InsertTranscriptInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvTranscriptManager), "InsertTranscriptInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------  

            //register as an available service --> Class: RemSrvTranscriptManager Method: UpdateTranscriptInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvTranscriptManager), "UpdateTranscriptInformation",
                WellKnownObjectMode.SingleCall);
            //-----------------------------  

            //register as an available service --> Class: RemSrvTranscriptManager Method: InsertUpdateDeleteTranscriptDetails
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvTranscriptManager), "InsertUpdateDeleteTranscriptDetails",
                WellKnownObjectMode.SingleCall);
            //-----------------------------  

            //register as an available service --> Class: RemSrvTranscriptManager Method: SelectTranscriptInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvTranscriptManager), "SelectTranscriptInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvTranscriptManager Method: SelectBySysIDTranscriptDetails
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvTranscriptManager), "SelectBySysIDTranscriptDetails",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvTranscriptManager Method: SelectByStudentIDTranscriptDetails
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvTranscriptManager), "SelectByStudentIDTranscriptDetails",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvTranscriptManager Method: SelectBySysIDScheduleSpecialListTranscriptDetails
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvTranscriptManager), "SelectBySysIDScheduleSpecialListTranscriptDetails",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvTranscriptManager Method: SelectTranscriptImagesTranscriptInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvTranscriptManager), "SelectTranscriptImagesTranscriptInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvTranscriptManager Method: IsExistStudentIDTranscriptInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvTranscriptManager), "IsExistStudentIDTranscriptInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvTranscriptManager Method: GetDataSetForTranscriptInfo
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvTranscriptManager), "GetDataSetForTranscriptInfo",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

        } //------------------------------------------

        //this procedure registers the RemSrvCampusAccessManager class
        private void RegRemSrvCampusAccessManager()
        {
            //register as an available service --> Class: RemSrvCampusAccessManager Method: InsertCampusAccessDetails
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCampusAccessManager), "InsertCampusAccessDetails",
                WellKnownObjectMode.SingleCall);
            //-----------------------------  

            //register as an available service --> Class: RemSrvCampusAccessManager Method: SelectForCampusAccessStudentEmployeeInformation
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCampusAccessManager), "SelectForCampusAccessStudentEmployeeInformation",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCampusAccessManager Method: SelectByPersonSysIDListDateStartEndCampusAccessDetails
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCampusAccessManager),
                "SelectByPersonSysIDListDateStartEndCampusAccessDetails", WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvCampusAccessManager Method: GetDataSetForCampusAccess
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvCampusAccessManager), "GetDataSetForCampusAccess",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

        } //------------------------------------------

        //this procedure registers the RemSrvAccountingManager class
        private void RegRemSrvAccountingManager()
        {
            //register as an available service --> Class: RemSrvAccountingManager Method: InsertChartOfAccounts
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAccountingManager), "InsertChartOfAccounts",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvAccountingManager Method: UpdateChartOfAccounts
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAccountingManager), "UpdateChartOfAccounts",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvAccountingManager Method: SelectChartOfAccounts
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAccountingManager), "SelectChartOfAccounts",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvAccountingManager Method: SelectBySysIDAccountChartOfAccounts
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAccountingManager), "SelectBySysIDAccountChartOfAccounts",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvAccountingManager Method: IsValidCategoryBySummaryAccountChartOfAccount
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAccountingManager), "IsValidCategoryBySummaryAccountChartOfAccount",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvAccountingManager Method: IsExistsAccountCodeChartOfAccount
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAccountingManager), "IsExistsAccountCodeChartOfAccount",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

            //register as an available service --> Class: RemSrvAccountingManager Method: GetDataSetForAccounting
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServerLib.RemSrvAccountingManager), "GetDataSetForAccounting",
                WellKnownObjectMode.SingleCall);
            //----------------------------- 

        } //------------------------------------------

        #endregion 

    }
}
