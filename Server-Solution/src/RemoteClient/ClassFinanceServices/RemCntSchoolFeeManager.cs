using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RemoteClient
{
    public class RemCntSchoolFeeManager : IDisposable
    {
        #region Constructor and Destructor

        public RemCntSchoolFeeManager() { }

        void IDisposable.Dispose() { }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a student additional fee
        public void InsertStudentAdditionalFee(CommonExchange.SysAccess userInfo, CommonExchange.StudentAdditionalFee additionalFee)
        {
            RemoteServerLib.RemSrvSchoolFeeManager remServer = 
                (RemoteServerLib.RemSrvSchoolFeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolFeeManager),
                TcpRemoteServer.GetRemoteServerTcp() + "InsertStudentAdditionalFee");

            remServer.InsertStudentAdditionalFee(userInfo, additionalFee);
        } //---------------------------------------

        //this procedure inserts a student additional fee
        public void InsertStudentAdditionalFeeTable(CommonExchange.SysAccess userInfo, DataTable additionalFeeTable) 
        {
            RemoteServerLib.RemSrvSchoolFeeManager remServer = 
                (RemoteServerLib.RemSrvSchoolFeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolFeeManager),
                TcpRemoteServer.GetRemoteServerTcp() + "InsertStudentAdditionalFeeTable");

            remServer.InsertStudentAdditionalFeeTable(userInfo, additionalFeeTable);
        } //----------------------------------

        //this procedure updates a student additional fee
        public void UpdateStudentAdditionalFee(CommonExchange.SysAccess userInfo, CommonExchange.StudentAdditionalFee additionalFee)
        {
            RemoteServerLib.RemSrvSchoolFeeManager remServer = 
                (RemoteServerLib.RemSrvSchoolFeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolFeeManager),
                TcpRemoteServer.GetRemoteServerTcp() + "UpdateStudentAdditionalFee");

            remServer.UpdateStudentAdditionalFee(userInfo, additionalFee);
        } //-----------------------------------

        //this procedure deletes a student additional fee
        public void DeleteStudentAdditionalFee(CommonExchange.SysAccess userInfo, CommonExchange.StudentAdditionalFee additionalFee)
        {
            RemoteServerLib.RemSrvSchoolFeeManager remServer = 
                (RemoteServerLib.RemSrvSchoolFeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolFeeManager),
                TcpRemoteServer.GetRemoteServerTcp() + "DeleteStudentAdditionalFee");

            remServer.DeleteStudentAdditionalFee(userInfo, additionalFee);
        } //----------------------------------

        //this procedure inserts and delete a student optional fee
        public void InsertDeleteStudentOptionalFee(CommonExchange.SysAccess userInfo, DataTable optionalFeeTable) 
        {
            RemoteServerLib.RemSrvSchoolFeeManager remServer = 
                (RemoteServerLib.RemSrvSchoolFeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolFeeManager),
                TcpRemoteServer.GetRemoteServerTcp() + "InsertDeleteStudentOptionalFee");

            remServer.InsertDeleteStudentOptionalFee(userInfo, optionalFeeTable);
        } //-------------------------------------------

        //this procedure inserts a new school fee details
        public void InsertSchoolFeeDetails(CommonExchange.SysAccess userInfo, ref CommonExchange.SchoolFeeDetails detailsInfo) 
        {
            RemoteServerLib.RemSrvSchoolFeeManager remServer = 
                (RemoteServerLib.RemSrvSchoolFeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolFeeManager),
                TcpRemoteServer.GetRemoteServerTcp() + "InsertSchoolFeeDetails");

            remServer.InsertSchoolFeeDetails(userInfo, ref detailsInfo);
        } //---------------------------------------

        //this procedure update a school fee details
        public void UpdateSchoolFeeDetails(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeDetails detailsInfo) 
        {
            RemoteServerLib.RemSrvSchoolFeeManager remServer = 
                (RemoteServerLib.RemSrvSchoolFeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolFeeManager),
                TcpRemoteServer.GetRemoteServerTcp() + "UpdateSchoolFeeDetails");

            remServer.UpdateSchoolFeeDetails(userInfo, detailsInfo);
        } //-------------------------------------

        //this procedure delete a school fee details
        public void DeleteSchoolFeeDetails(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeDetails detailsInfo) 
        {
            RemoteServerLib.RemSrvSchoolFeeManager remServer = 
                (RemoteServerLib.RemSrvSchoolFeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolFeeManager),
                TcpRemoteServer.GetRemoteServerTcp() + "DeleteSchoolFeeDetails");

            remServer.DeleteSchoolFeeDetails(userInfo, detailsInfo);
        } //---------------------------------

        //this procedure inserts a new school fee particular
        public void InsertSchoolFeeParticular(CommonExchange.SysAccess userInfo, ref CommonExchange.SchoolFeeParticular particularInfo) 
        {
            RemoteServerLib.RemSrvSchoolFeeManager remServer = 
                (RemoteServerLib.RemSrvSchoolFeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolFeeManager),
                TcpRemoteServer.GetRemoteServerTcp() + "InsertSchoolFeeParticular");

            remServer.InsertSchoolFeeParticular(userInfo, ref particularInfo);
        } //----------------------------------------

        //this procedure updates a school fee particular
        public void UpdateSchoolFeeParticular(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeParticular particularInfo) 
        {
            RemoteServerLib.RemSrvSchoolFeeManager remServer = 
                (RemoteServerLib.RemSrvSchoolFeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolFeeManager),
                TcpRemoteServer.GetRemoteServerTcp() + "UpdateSchoolFeeParticular");

            remServer.UpdateSchoolFeeParticular(userInfo, particularInfo);
        } //-----------------------------------------

        //this procedure deletes a school fee particular
        public void DeleteSchoolFeeParticular(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeParticular particularInfo) 
        {
            RemoteServerLib.RemSrvSchoolFeeManager remServer =
                (RemoteServerLib.RemSrvSchoolFeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolFeeManager),
                TcpRemoteServer.GetRemoteServerTcp() + "DeleteSchoolFeeParticular");

            remServer.DeleteSchoolFeeParticular(userInfo, particularInfo);
        } //------------------------------------------

        //this procedure inserts a new school fee level
        public void InsertSchoolFeeLevel(CommonExchange.SysAccess userInfo, ref CommonExchange.SchoolFeeLevel levelInfo) 
        {
            RemoteServerLib.RemSrvSchoolFeeManager remServer = 
                (RemoteServerLib.RemSrvSchoolFeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolFeeManager),
                TcpRemoteServer.GetRemoteServerTcp() + "InsertSchoolFeeLevel");

            remServer.InsertSchoolFeeLevel(userInfo, ref levelInfo);
        } //------------------------------------------

        //this procedure inserts a new school fee information
        public void InsertSchoolFeeInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.SchoolFeeInformation feeInfo) 
        {
            RemoteServerLib.RemSrvSchoolFeeManager remServer = 
                (RemoteServerLib.RemSrvSchoolFeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolFeeManager),
                TcpRemoteServer.GetRemoteServerTcp() + "InsertSchoolFeeInformation");

            remServer.InsertSchoolFeeInformation(userInfo, ref feeInfo);
        } //----------------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the additional fee table query
        public DataTable SelectStudentAdditionalFee(CommonExchange.SysAccess userInfo, String queryString, String dateStart, String dateEnd,
            String courseIdList, String yearLevelIdList)
        {
            RemoteServerLib.RemSrvSchoolFeeManager remServer = 
                (RemoteServerLib.RemSrvSchoolFeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolFeeManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectStudentAdditionalFee");

            return remServer.SelectStudentAdditionalFee(userInfo, queryString, dateStart, dateEnd, courseIdList, yearLevelIdList);
        } //------------------------------------------------

        //this function gets the additional fee table query by sysid_student date start end
        public DataTable SelectBySysIDStudentDateStartEndStudentAdditionalFee(CommonExchange.SysAccess userInfo, String studentSysId,
            String dateStart, String dateEnd)
        {
            RemoteServerLib.RemSrvSchoolFeeManager remServer = 
                (RemoteServerLib.RemSrvSchoolFeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolFeeManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDStudentDateStartEndStudentAdditionalFee");

            return remServer.SelectBySysIDStudentDateStartEndStudentAdditionalFee(userInfo, studentSysId, dateStart, dateEnd);
        } //-------------------------------------

        //this procedure returns the selected school fee details by date start and end 
        public DataTable SelectByDateStartEndSchoolFeeDetails(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd)
        {
            RemoteServerLib.RemSrvSchoolFeeManager remServer = 
                (RemoteServerLib.RemSrvSchoolFeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolFeeManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectByDateStartEndSchoolFeeDetails");

            return remServer.SelectByDateStartEndSchoolFeeDetails(userInfo, dateStart, dateEnd);
        } //-------------------------------------------  

        //this procedure returns the selected school fee level by date start and end 
        public DataTable SelectBySysIDSchoolFeeSchoolFeeLevel(CommonExchange.SysAccess userInfo, String schoolFeeSysId)
        {
            RemoteServerLib.RemSrvSchoolFeeManager remServer =
                (RemoteServerLib.RemSrvSchoolFeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolFeeManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDSchoolFeeSchoolFeeLevel");

            return remServer.SelectBySysIDSchoolFeeSchoolFeeLevel(userInfo, schoolFeeSysId);
        } //----------------------------------------

        //this procedure returns the optional school fee details by student system id, fee level system id
        public DataTable SelectBySysIDStudentFeeLevelSemesterForOptionalFeeDetailsStudentOptionalFee(CommonExchange.SysAccess userInfo, String studentSysId,
            String feeLevelSysId, String semesterSysId, Boolean isInternational)
        {
            RemoteServerLib.RemSrvSchoolFeeManager remServer = 
                (RemoteServerLib.RemSrvSchoolFeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolFeeManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDStudentFeeLevelSemesterForOptionalFeeDetailsStudentOptionalFee");

            return remServer.SelectBySysIDStudentFeeLevelSemesterForOptionalFeeDetailsStudentOptionalFee(userInfo, studentSysId, 
                feeLevelSysId, semesterSysId, isInternational);
        } //--------------------------------------------

        //this function is used to determine if the school fee information and the year level id already exists
        public Boolean IsExistsSchoolFeeYearLevel(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeLevel levelInfo)
        {
            RemoteServerLib.RemSrvSchoolFeeManager remServer = 
                (RemoteServerLib.RemSrvSchoolFeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolFeeManager),
                TcpRemoteServer.GetRemoteServerTcp() + "IsExistsSchoolFeeYearLevel");

            return remServer.IsExistsSchoolFeeYearLevel(userInfo, levelInfo);
        } //------------------------------------

        //this function is used to determine if the year id for the school fee informati\on already exists
        public Boolean IsExistsYearIDSchoolFeeInformation(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeInformation feeInfo)
        {
            RemoteServerLib.RemSrvSchoolFeeManager remServer = 
                (RemoteServerLib.RemSrvSchoolFeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolFeeManager),
                TcpRemoteServer.GetRemoteServerTcp() + "IsExistsYearIDSchoolFeeInformation");

            return remServer.IsExistsYearIDSchoolFeeInformation(userInfo, feeInfo);
        } //------------------------------

        //this function is used to determine if the particular description exists
        public Boolean IsExistsParticularDescriptionSchoolFeeParticular(CommonExchange.SysAccess userInfo, String particularSysId, String particularDescription)
        {
            RemoteServerLib.RemSrvSchoolFeeManager remServer = 
                (RemoteServerLib.RemSrvSchoolFeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolFeeManager),
                TcpRemoteServer.GetRemoteServerTcp() + "IsExistsParticularDescriptionSchoolFeeParticular");

            return remServer.IsExistsParticularDescriptionSchoolFeeParticular(userInfo, particularSysId, particularDescription);
        } //-----------------------------  

        //this function is sued to determine if the year level and particular already exists
        public Boolean IsExistsLevelParticularSchoolFeeDetails(CommonExchange.SysAccess userInfo, String feeLevelSysId, String particularSysId)
        {
            RemoteServerLib.RemSrvSchoolFeeManager remServer = 
                (RemoteServerLib.RemSrvSchoolFeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolFeeManager),
                TcpRemoteServer.GetRemoteServerTcp() + "IsExistsLevelParticularSchoolFeeDetails");

            return remServer.IsExistsLevelParticularSchoolFeeDetails(userInfo, feeLevelSysId, particularSysId);
        } //-------------------------------------------

        //this function is used to get data tables stored in one dataset used for school fee
        public DataSet GetDataSetForSchoolFee(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            RemoteServerLib.RemSrvSchoolFeeManager remServer = 
                (RemoteServerLib.RemSrvSchoolFeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolFeeManager),
                TcpRemoteServer.GetRemoteServerTcp() + "GetDataSetForSchoolFee");

            return remServer.GetDataSetForSchoolFee(userInfo, serverDateTime);
        } //----------------------------------

        #endregion
    }
}
