using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RemoteClient
{
    public class RemCntScholarshipManager : IDisposable
    {
        #region Constructor and Destructor
        public RemCntScholarshipManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new scholarship information
        public void InsertScholarshipInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.ScholarshipInformation scholarshipInfo)
        {
            RemoteServerLib.RemSrvScholarshipManager remServer = (RemoteServerLib.RemSrvScholarshipManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvScholarshipManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertScholarshipInformation");

            remServer.InsertScholarshipInformation(userInfo, ref scholarshipInfo);
        } //---------------------------------------

        //this procedure updates a scholarship information
        public void UpdateScholarshipInformation(CommonExchange.SysAccess userInfo, CommonExchange.ScholarshipInformation scholarshipInfo)
        {
            RemoteServerLib.RemSrvScholarshipManager remServer = (RemoteServerLib.RemSrvScholarshipManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvScholarshipManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "UpdateScholarshipInformation");

            remServer.UpdateScholarshipInformation(userInfo, scholarshipInfo);
        } //-----------------------------------

        //this procedure inserts a new student scholarship
        public void InsertStudentScholarship(CommonExchange.SysAccess userInfo, ref CommonExchange.StudentScholarship studentScholarship) 
        {
            RemoteServerLib.RemSrvScholarshipManager remServer = (RemoteServerLib.RemSrvScholarshipManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvScholarshipManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertStudentScholarship");

            remServer.InsertStudentScholarship(userInfo, ref studentScholarship);
        } //----------------------------------------

        //this procedure update a student scholarship
        public void UpdateStudentScholarship(CommonExchange.SysAccess userInfo, CommonExchange.StudentScholarship studentScholarship)
        {
            RemoteServerLib.RemSrvScholarshipManager remServer = (RemoteServerLib.RemSrvScholarshipManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvScholarshipManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "UpdateStudentScholarship");

            remServer.UpdateStudentScholarship(userInfo, studentScholarship);
        } //-------------------------------------------

        //this procedure delete a student scholarship
        public void DeleteStudentScholarship(CommonExchange.SysAccess userInfo, CommonExchange.StudentScholarship studentScholarship)
        {
            RemoteServerLib.RemSrvScholarshipManager remServer = (RemoteServerLib.RemSrvScholarshipManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvScholarshipManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "DeleteStudentScholarship");

            remServer.DeleteStudentScholarship(userInfo, studentScholarship);
        } //----------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the student scholarship table
        public DataTable SelectStudentScholarship(CommonExchange.SysAccess userInfo, String queryString, String dateStart, String dateEnd,
            String scholarshipSysIdList, String departmentIdList, String yearLevelIdList)
        {
            RemoteServerLib.RemSrvScholarshipManager remServer = (RemoteServerLib.RemSrvScholarshipManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvScholarshipManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectStudentScholarship");

            return remServer.SelectStudentScholarship(userInfo, queryString, dateStart, dateEnd, scholarshipSysIdList, departmentIdList, yearLevelIdList);
        } //-----------------------------------------

        //this procedure returns the discounts of the student with scholarships
        public DataTable SelectBySysIDEnrolmentLevelStudentScholarship(CommonExchange.SysAccess userInfo, String enrolmentLevelSysId, String serverDateTime)
        {
            RemoteServerLib.RemSrvScholarshipManager remServer = (RemoteServerLib.RemSrvScholarshipManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvScholarshipManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDEnrolmentLevelStudentScholarship");

            return remServer.SelectBySysIDEnrolmentLevelStudentScholarship(userInfo, enrolmentLevelSysId, serverDateTime);
        } //----------------------------------------

        //this function is used to determine if the scholarship description already exists
        public Boolean IsExistsScholarshipDescriptionScholarshipInformation(CommonExchange.SysAccess userInfo,
            CommonExchange.ScholarshipInformation scholarshipInfo)
        {
            RemoteServerLib.RemSrvScholarshipManager remServer = (RemoteServerLib.RemSrvScholarshipManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvScholarshipManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "IsExistsScholarshipDescriptionScholarshipInformation");

            return remServer.IsExistsScholarshipDescriptionScholarshipInformation(userInfo, scholarshipInfo);
        } //-------------------------------------

        //this function is used to determine if the student scholarship already exists
        public Boolean IsExistsSysIDStudentScholarshipEnrolmentLevelStudentScholarship(CommonExchange.SysAccess userInfo,
            CommonExchange.StudentScholarship studentScholarship)
        {
            RemoteServerLib.RemSrvScholarshipManager remServer = (RemoteServerLib.RemSrvScholarshipManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvScholarshipManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "IsExistsSysIDStudentScholarshipEnrolmentLevelStudentScholarship");

            return remServer.IsExistsSysIDStudentScholarshipEnrolmentLevelStudentScholarship(userInfo, studentScholarship);
        } //----------------------------------------

        //this function is used to get data tables stored in one dataset used for scholarship manager
        public DataSet GetDataSetForScholarship(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            RemoteServerLib.RemSrvScholarshipManager remServer = (RemoteServerLib.RemSrvScholarshipManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvScholarshipManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "GetDataSetForScholarship");

            return remServer.GetDataSetForScholarship(userInfo, serverDateTime);
        } //-----------------------------------

        #endregion

    }
}
