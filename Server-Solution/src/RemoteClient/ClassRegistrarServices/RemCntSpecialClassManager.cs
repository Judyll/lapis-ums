using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RemoteClient
{
    public class RemCntSpecialClassManager : IDisposable
    {
        #region Class Constructor and Destructor

        public RemCntSpecialClassManager() { }

        void IDisposable.Dispose() { }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new special class information
        public void InsertSpecialClassInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.SpecialClassInformation specialInfo,
                                                        DataTable studentTable)
        {
            RemoteServerLib.RemSrvSpecialClassManager remServer = 
                (RemoteServerLib.RemSrvSpecialClassManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSpecialClassManager),
                TcpRemoteServer.GetRemoteServerTcp() + "InsertSpecialClassInformation");

            remServer.InsertSpecialClassInformation(userInfo, ref specialInfo, studentTable);
        } //-------------------------------------------

        //this procedure updates a special class information
        public void UpdateSpecialClassInformation(CommonExchange.SysAccess userInfo, CommonExchange.SpecialClassInformation specialInfo,
                                                            DataTable studentTable)
        {
            RemoteServerLib.RemSrvSpecialClassManager remServer = 
                (RemoteServerLib.RemSrvSpecialClassManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSpecialClassManager),
                TcpRemoteServer.GetRemoteServerTcp() + "UpdateSpecialClassInformation");

            remServer.UpdateSpecialClassInformation(userInfo, specialInfo, studentTable);
        } //---------------------------------

        //this procedure deletes a special class information
        public void DeleteSpecialClassInformation(CommonExchange.SysAccess userInfo, String specialSysId)
        {
            RemoteServerLib.RemSrvSpecialClassManager remServer = 
                (RemoteServerLib.RemSrvSpecialClassManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSpecialClassManager),
                TcpRemoteServer.GetRemoteServerTcp() + "DeleteSpecialClassInformation");

            remServer.DeleteSpecialClassInformation(userInfo, specialSysId);
        } //----------------------------------------

        //this procedure deletes a special class load
        public void DeleteSpecialClassLoad(CommonExchange.SysAccess userInfo, Int64 loadId)
        {
            RemoteServerLib.RemSrvSpecialClassManager remServer = 
                (RemoteServerLib.RemSrvSpecialClassManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSpecialClassManager),
                TcpRemoteServer.GetRemoteServerTcp() + "DeleteSpecialClassLoad");

            remServer.DeleteSpecialClassLoad(userInfo, loadId);
        } //------------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function is used to get the special class information by date start and date end
        public DataTable SelectByDateStartEndSpecialClassInformation(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd,
                                                                            Boolean isMarkedDeleted)
        {
            RemoteServerLib.RemSrvSpecialClassManager remServer = 
                (RemoteServerLib.RemSrvSpecialClassManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSpecialClassManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectByDateStartEndSpecialClassInformation");

            return remServer.SelectByDateStartEndSpecialClassInformation(userInfo, dateStart, dateEnd, isMarkedDeleted);
        } //--------------------------------------------------

        //this function is used to get the student loaded in the special class by special class id
        public DataTable SelectBySysIDSpecialSpecialClassLoad(CommonExchange.SysAccess userInfo, String specialSysId, String serverDateTime)
        {
            RemoteServerLib.RemSrvSpecialClassManager remServer = 
                (RemoteServerLib.RemSrvSpecialClassManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSpecialClassManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDSpecialSpecialClassLoad");

            return remServer.SelectBySysIDSpecialSpecialClassLoad(userInfo, specialSysId, serverDateTime);
        } //----------------------------------------

        //this function is used to get the student loaded in the special class by date start end
        public DataTable SelectBySysIDStudentListDateStartEndSpecialClassInformation(CommonExchange.SysAccess userInfo, String studentSysIdList,
            String dateStart, String dateEnd, String serverDateTime)
        {
            RemoteServerLib.RemSrvSpecialClassManager remServer = 
                (RemoteServerLib.RemSrvSpecialClassManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSpecialClassManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDStudentListDateStartEndSpecialClassInformation");

            return remServer.SelectBySysIDStudentListDateStartEndSpecialClassInformation(userInfo, studentSysIdList, dateStart, dateEnd, serverDateTime);
        } //------------------------------

        //this function is used to get the special class information by date start and date end
        public DataTable SelectBySysIDEmployeeListDateStartEndSpecialClassInformation(CommonExchange.SysAccess userInfo, String employeeSysIdList,
            String dateStart, String dateEnd)
        {
            RemoteServerLib.RemSrvSpecialClassManager remServer = 
                (RemoteServerLib.RemSrvSpecialClassManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSpecialClassManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDEmployeeListDateStartEndSpecialClassInformation");

            return remServer.SelectBySysIDEmployeeListDateStartEndSpecialClassInformation(userInfo, employeeSysIdList, dateStart, dateEnd);
        } //---------------------------------

        //this function determines if the special class information already exists
        public Boolean IsExistsInformationSpecialClassInformation(CommonExchange.SysAccess userInfo,
                                                                    CommonExchange.SpecialClassInformation specialInfo)
        {
            RemoteServerLib.RemSrvSpecialClassManager remServer = 
                (RemoteServerLib.RemSrvSpecialClassManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSpecialClassManager),
                TcpRemoteServer.GetRemoteServerTcp() + "IsExistsInformationSpecialClassInformation");

            return remServer.IsExistsInformationSpecialClassInformation(userInfo, specialInfo);
        } //-------------------------------------------

        //this function is used to get data tables stored in one dataset used for special class information
        public DataSet GetDataSetForSpecialClassInformation(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            RemoteServerLib.RemSrvSpecialClassManager remServer = 
                (RemoteServerLib.RemSrvSpecialClassManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSpecialClassManager),
                TcpRemoteServer.GetRemoteServerTcp() + "GetDataSetForSpecialClassInformation");

            return remServer.GetDataSetForSpecialClassInformation(userInfo, serverDateTime);
        } //------------------------------------

        #endregion
    }
}
