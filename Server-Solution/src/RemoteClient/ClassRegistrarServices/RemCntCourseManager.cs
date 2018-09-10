using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RemoteClient
{
    public class RemCntCourseManager : IDisposable
    {
        #region Class Constructor and Destructor

        public RemCntCourseManager() { }

        void IDisposable.Dispose() { }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new subject information
        public void InsertSubjectInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.SubjectInformation subjectInfo,
                                                    DataTable requisiteTable)
        {
            RemoteServerLib.RemSrvCourseManager remServer = (RemoteServerLib.RemSrvCourseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCourseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertSubjectInformation");

            remServer.InsertSubjectInformation(userInfo, ref subjectInfo, requisiteTable);
        } //-------------------------------------

        //this procedure updates a subject information
        public void UpdateSubjectInformation(CommonExchange.SysAccess userInfo, CommonExchange.SubjectInformation subjectInfo,
                                                    DataTable requisiteTable)
        {
            RemoteServerLib.RemSrvCourseManager remServer = (RemoteServerLib.RemSrvCourseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCourseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "UpdateSubjectInformation");

            remServer.UpdateSubjectInformation(userInfo, subjectInfo, requisiteTable);
        } //----------------------------------

        //this procedure inserts a new classroom information
        public void InsertClassroomInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.ClassroomInformation roomInfo)
        {
            RemoteServerLib.RemSrvCourseManager remServer = (RemoteServerLib.RemSrvCourseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCourseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertClassroomInformation");

            remServer.InsertClassroomInformation(userInfo, ref roomInfo);
        } //---------------------------------

        //this procedure updates a classroom information
        public void UpdateClassroomInformation(CommonExchange.SysAccess userInfo, CommonExchange.ClassroomInformation roomInfo)
        {
            RemoteServerLib.RemSrvCourseManager remServer = (RemoteServerLib.RemSrvCourseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCourseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "UpdateClassroomInformation");

            remServer.UpdateClassroomInformation(userInfo, roomInfo);
        } //---------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function is used to get the subject prerequisite by subject id
        public DataTable SelectBySubjectIDSubjectPrerequisite(CommonExchange.SysAccess userInfo, String subjectSysId)
        {
            RemoteServerLib.RemSrvCourseManager remServer = (RemoteServerLib.RemSrvCourseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCourseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectBySubjectIDSubjectPrerequisite");

            return remServer.SelectBySubjectIDSubjectPrerequisite(userInfo, subjectSysId);
        } //---------------------------------------

        //this function is used to get the subject information by subject code or title
        public DataTable SelectSubjectInformation(CommonExchange.SysAccess userInfo, String queryString)
        {
            RemoteServerLib.RemSrvCourseManager remServer = (RemoteServerLib.RemSrvCourseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCourseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectSubjectInformation");

            return remServer.SelectSubjectInformation(userInfo, queryString);
        } //----------------------------------------

        //this function is used to get the classroom information by classroom code or description
        public DataTable SelectClassroomInformation(CommonExchange.SysAccess userInfo, String queryString)
        {
            RemoteServerLib.RemSrvCourseManager remServer = (RemoteServerLib.RemSrvCourseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCourseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectClassroomInformation");

            return remServer.SelectClassroomInformation(userInfo, queryString);
        } //--------------------------------

        //this function is used to get the course information by course title or acronym
        public DataTable SelectCourseInformation(CommonExchange.SysAccess userInfo, String queryString)
        {
            RemoteServerLib.RemSrvCourseManager remServer = (RemoteServerLib.RemSrvCourseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCourseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectCourseInformation");

            return remServer.SelectCourseInformation(userInfo, queryString);
        } //------------------------------------

        //this function determines if the subject code and descriptive title exist
        public Boolean IsExistCodeDescriptionSubjectInformation(CommonExchange.SysAccess userInfo, CommonExchange.SubjectInformation subjectInfo)
        {
            RemoteServerLib.RemSrvCourseManager remServer = (RemoteServerLib.RemSrvCourseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCourseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "IsExistCodeDescriptionSubjectInformation");

            return remServer.IsExistCodeDescriptionSubjectInformation(userInfo, subjectInfo);
        } //----------------------------

        //this function determines if the classroom code exist
        public Boolean IsExistCodeClassroomInformation(CommonExchange.SysAccess userInfo, String roomCode, String roomSysId)
        {
            RemoteServerLib.RemSrvCourseManager remServer = (RemoteServerLib.RemSrvCourseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCourseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "IsExistCodeClassroomInformation");

            return remServer.IsExistCodeClassroomInformation(userInfo, roomCode, roomSysId);
        } //-----------------------

        //this function determines if the course title and acronym exist
        public Boolean IsExistTitleAcronymCourseInformation(CommonExchange.SysAccess userInfo, CommonExchange.CourseInformation courseInfo)
        {
            RemoteServerLib.RemSrvCourseManager remServer = (RemoteServerLib.RemSrvCourseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCourseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "IsExistTitleAcronymCourseInformation");

            return remServer.IsExistTitleAcronymCourseInformation(userInfo, courseInfo);
        } //---------------------------------

        //this function is used to get data tables stored in one dataset used for classroom subject information
        public DataSet GetDataSetForClassroomSubject(CommonExchange.SysAccess userInfo)
        {
            RemoteServerLib.RemSrvCourseManager remServer = (RemoteServerLib.RemSrvCourseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCourseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "GetDataSetForClassroomSubject");

            return remServer.GetDataSetForClassroomSubject(userInfo);
        } //---------------------------------
        

        #endregion
    }
}
