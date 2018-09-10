using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RemoteClient
{
    public class RemCntSchoolYearSemesterManager : IDisposable
    {
        #region Class Constructor and Destructor

        public RemCntSchoolYearSemesterManager() { }

        void IDisposable.Dispose() { }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure insterst a school semester information
        public void InsertSemesterInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.SemesterInformation semInfo)
        {
            RemoteServerLib.RemSrvSchoolYearSemesterManager remServer = (RemoteServerLib.RemSrvSchoolYearSemesterManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolYearSemesterManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertSemesterInformation");

            remServer.InsertSemesterInformation(userInfo, ref semInfo);
        } //------------------------------

        //this procedure inserts a school year
        public void InsertSchoolYear(CommonExchange.SysAccess userInfo, ref CommonExchange.SchoolYear yearInfo)
        {
            RemoteServerLib.RemSrvSchoolYearSemesterManager remServer = (RemoteServerLib.RemSrvSchoolYearSemesterManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolYearSemesterManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertSchoolYear");

            remServer.InsertSchoolYear(userInfo, ref yearInfo);
        } //-----------------------------------

         //this procedure inserts a school year (Summer)
        public void InsertSchoolYearSummer(CommonExchange.SysAccess userInfo, CommonExchange.SchoolYear baseYearInfo, ref CommonExchange.SchoolYear yearInfo)
        {
            RemoteServerLib.RemSrvSchoolYearSemesterManager remServer = (RemoteServerLib.RemSrvSchoolYearSemesterManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolYearSemesterManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertSchoolYearSummer");

            remServer.InsertSchoolYearSummer(userInfo, baseYearInfo, ref yearInfo);
        } //-----------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function returns the selected school year information
        public DataTable SelectByYearDescriptionSchoolYearTable(CommonExchange.SysAccess userInfo, String queryString, String serverDateTime)
        {
            RemoteServerLib.RemSrvSchoolYearSemesterManager remServer = (RemoteServerLib.RemSrvSchoolYearSemesterManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolYearSemesterManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectByYearDescriptionSchoolYearTable");

            return remServer.SelectByYearDescriptionSchoolYearTable(userInfo, queryString, serverDateTime);
        } //---------------------------------

        //this function returns the selected semester information
        public DataTable SelectYearSemesterDescriptionSemesterInformationTable(CommonExchange.SysAccess userInfo, String queryString,
            String serverDateTime)
        {
            RemoteServerLib.RemSrvSchoolYearSemesterManager remServer = (RemoteServerLib.RemSrvSchoolYearSemesterManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolYearSemesterManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectYearSemesterDescriptionSemesterInformationTable");

            return remServer.SelectYearSemesterDescriptionSemesterInformationTable(userInfo, queryString, serverDateTime);
        } //--------------------------------------

        //this function returns the last opened semeter information
        public String GetMaxDateEndSemesterInformation(CommonExchange.SysAccess userInfo)
        {
            RemoteServerLib.RemSrvSchoolYearSemesterManager remServer = (RemoteServerLib.RemSrvSchoolYearSemesterManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolYearSemesterManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "GetMaxDateEndSemesterInformation");

            return remServer.GetMaxDateEndSemesterInformation(userInfo);
        } //------------------------------

        //this function returns the max end date
        public String GetMaxDateEndSchoolYear(CommonExchange.SysAccess userInfo)
        {
            RemoteServerLib.RemSrvSchoolYearSemesterManager remServer = (RemoteServerLib.RemSrvSchoolYearSemesterManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolYearSemesterManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "GetMaxDateEndSchoolYear");

            return remServer.GetMaxDateEndSchoolYear(userInfo);
        } //--------------------------------

        //this function is used to get data tables stored in one dataset used for deduction information
        public DataSet GetDataSetForSchoolYearSemeter(CommonExchange.SysAccess userInfo)
        {
            RemoteServerLib.RemSrvSchoolYearSemesterManager remServer = (RemoteServerLib.RemSrvSchoolYearSemesterManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSchoolYearSemesterManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "GetDataSetForSchoolYearSemeter");

            return remServer.GetDataSetForSchoolYearSemeter(userInfo);
        } //-----------------------------------
        #endregion
    }
}
