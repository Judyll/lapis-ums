using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RemoteClient
{
    public class RemCntCampusAccessManager : IDisposable
    {
        #region Class Constructor and Destructor

        public RemCntCampusAccessManager() { }

        void IDisposable.Dispose() { }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a campus access details
        public void InsertCampusAccessDetails(CommonExchange.SysAccess userInfo, DataTable campusAccessDetailsTable) 
        {
            RemoteServerLib.RemSrvCampusAccessManager remServer = 
                (RemoteServerLib.RemSrvCampusAccessManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCampusAccessManager),
                TcpRemoteServer.GetRemoteServerTcp() + "InsertCampusAccessDetails");

            remServer.InsertCampusAccessDetails(userInfo, campusAccessDetailsTable);
        } //---------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the student and employee table query
        public DataTable SelectForCampusAccessStudentEmployeeInformation(CommonExchange.SysAccess userInfo, String queryString)
        {
            RemoteServerLib.RemSrvCampusAccessManager remServer =
                (RemoteServerLib.RemSrvCampusAccessManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCampusAccessManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectForCampusAccessStudentEmployeeInformation");

            return remServer.SelectForCampusAccessStudentEmployeeInformation(userInfo, queryString);
        } //-------------------------------------    

        //this function gets the campus access by sysid_person list
        public DataTable SelectByPersonSysIDListDateStartEndCampusAccessDetails(CommonExchange.SysAccess userInfo, String personSysIdList,
            String dateStart, String dateEnd)
        {
            RemoteServerLib.RemSrvCampusAccessManager remServer =
                (RemoteServerLib.RemSrvCampusAccessManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCampusAccessManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectByPersonSysIDListDateStartEndCampusAccessDetails");

            return remServer.SelectByPersonSysIDListDateStartEndCampusAccessDetails(userInfo, personSysIdList, dateStart, dateEnd);

        } //------------------------------

        //this function is used to get data tables stored in one dataset used for campus access
        public DataSet GetDataSetForCampusAccess(CommonExchange.SysAccess userInfo)
        {
            RemoteServerLib.RemSrvCampusAccessManager remServer =
                (RemoteServerLib.RemSrvCampusAccessManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCampusAccessManager),
                TcpRemoteServer.GetRemoteServerTcp() + "GetDataSetForCampusAccess");

            return remServer.GetDataSetForCampusAccess(userInfo);
        } //----------------------------------

        #endregion
    }
}
