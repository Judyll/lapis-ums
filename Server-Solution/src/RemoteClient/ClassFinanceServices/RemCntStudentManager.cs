using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RemoteClient
{
    public class RemCntStudentManager : IDisposable
    {
        #region Class Constructor and Destructor

        public RemCntStudentManager() { }

        void IDisposable.Dispose() { }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new student information
        public void InsertStudentInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.Student studentInfo)
        {
            RemoteServerLib.RemSrvStudentManager remServer = (RemoteServerLib.RemSrvStudentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertStudentInformation");

            remServer.InsertStudentInformation(userInfo, ref studentInfo);
        } //-------------------------------------

        //this procedure updates a student information
        public void UpdateStudentInformation(CommonExchange.SysAccess userInfo, CommonExchange.Student studentInfo)
        {
            RemoteServerLib.RemSrvStudentManager remServer = (RemoteServerLib.RemSrvStudentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "UpdateStudentInformation");

            remServer.UpdateStudentInformation(userInfo, studentInfo);
        } //------------------------------------------        

        #endregion

        #region Programmer-Defined Function Procedures

        //this function returns the student count for student id
        public Int32 GetCountForStudentIDStudentInformation(CommonExchange.SysAccess userInfo, String schoolFeeSysIdList, String yearLevelId)
        {
            RemoteServerLib.RemSrvStudentManager remServer = (RemoteServerLib.RemSrvStudentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "GetCountForStudentIDStudentInformation");

            return remServer.GetCountForStudentIDStudentInformation(userInfo, schoolFeeSysIdList, yearLevelId);
        } //------------------------------------

        //this function returns the student information details
        public CommonExchange.Student SelectByStudentIDStudentInformation(CommonExchange.SysAccess userInfo, String studentId)
        {
            RemoteServerLib.RemSrvStudentManager remServer = (RemoteServerLib.RemSrvStudentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectByStudentIDStudentInformation");

            return remServer.SelectByStudentIDStudentInformation(userInfo, studentId);
        } //--------------------------------

        //this function returns the student information details
        public CommonExchange.Student SelectBySysIDPersonStudentInformation(CommonExchange.SysAccess userInfo, String personSysId)
        {
            RemoteServerLib.RemSrvStudentManager remServer = (RemoteServerLib.RemSrvStudentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDPersonStudentInformation");

            return remServer.SelectBySysIDPersonStudentInformation(userInfo, personSysId);
        } //-------------------------------------

        //this function gets the student information table query
        public DataTable SelectStudentInformation(CommonExchange.SysAccess userInfo, String queryString, String dateStart, String dateEnd,
            String courseIdList, String yearLevelIdList)
        {
            RemoteServerLib.RemSrvStudentManager remServer = (RemoteServerLib.RemSrvStudentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectStudentInformation");

            return remServer.SelectStudentInformation(userInfo, queryString, dateStart, dateEnd, courseIdList, yearLevelIdList);
        } //----------------------------------------

        //this function is used to determine if the student id exists
        public Boolean IsExistsStudentIdStudentInformation(CommonExchange.SysAccess userInfo, String studentId, String studentSysId)
        {
            RemoteServerLib.RemSrvStudentManager remServer = (RemoteServerLib.RemSrvStudentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "IsExistsStudentIdStudentInformation");

            return remServer.IsExistsStudentIdStudentInformation(userInfo, studentId, studentSysId);
        } //--------------------------

        //this function is used to get data tables stored in one dataset used for student manager
        public DataSet GetDataSetForStudentInformation(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            RemoteServerLib.RemSrvStudentManager remServer = (RemoteServerLib.RemSrvStudentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "GetDataSetForStudentInformation");

            return remServer.GetDataSetForStudentInformation(userInfo, serverDateTime);
        } //----------------------------------

        #endregion
    }
}
