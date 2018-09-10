using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RemoteClient
{
    public class RemCntTranscriptManager : IDisposable
    {
        #region Class Constructor and Destructor

        public RemCntTranscriptManager() { }

        void IDisposable.Dispose() { }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new transcript information
        public void InsertTranscriptInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.TranscriptInformation transcriptInfo) 
        {
            RemoteServerLib.RemSrvTranscriptManager remServer = 
                (RemoteServerLib.RemSrvTranscriptManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvTranscriptManager),
                TcpRemoteServer.GetRemoteServerTcp() + "InsertTranscriptInformation");

            remServer.InsertTranscriptInformation(userInfo, ref transcriptInfo);
        } //--------------------------------------------------------

        //this procedure inserts a new transcript information
        public void UpdateTranscriptInformation(CommonExchange.SysAccess userInfo, CommonExchange.TranscriptInformation transcriptInfo) 
        {
            RemoteServerLib.RemSrvTranscriptManager remServer =
                (RemoteServerLib.RemSrvTranscriptManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvTranscriptManager),
                TcpRemoteServer.GetRemoteServerTcp() + "UpdateTranscriptInformation");

            remServer.UpdateTranscriptInformation(userInfo, transcriptInfo);
        } //-----------------------------------------------------

        //this procedure insert, update or delete a transcript details
        public void InsertUpdateDeleteTranscriptDetails(CommonExchange.SysAccess userInfo, String transcriptSysId, DataTable transcriptDetailsTable)
        {
            RemoteServerLib.RemSrvTranscriptManager remServer =
                (RemoteServerLib.RemSrvTranscriptManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvTranscriptManager),
                TcpRemoteServer.GetRemoteServerTcp() + "InsertUpdateDeleteTranscriptDetails");

            remServer.InsertUpdateDeleteTranscriptDetails(userInfo, transcriptSysId, transcriptDetailsTable);
        } //---------------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the student information table query
        public DataTable SelectTranscriptInformation(CommonExchange.SysAccess userInfo, String queryString)
        {
            RemoteServerLib.RemSrvTranscriptManager remServer = 
                (RemoteServerLib.RemSrvTranscriptManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvTranscriptManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectTranscriptInformation");

            return remServer.SelectTranscriptInformation(userInfo, queryString);

        } //------------------------------

        //this function gets the transcript details table query
        public DataTable SelectBySysIDTranscriptDetails(CommonExchange.SysAccess userInfo, String transcriptSysId)
        {
            RemoteServerLib.RemSrvTranscriptManager remServer =
                (RemoteServerLib.RemSrvTranscriptManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvTranscriptManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDTranscriptDetails");

            return remServer.SelectBySysIDTranscriptDetails(userInfo, transcriptSysId);
        } //-------------------------------------------

        /// <summary>
        /// This function returns the transcript information details
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public DataTable SelectByStudentIDTranscriptDetails(CommonExchange.SysAccess userInfo, String studentId)
        {
            RemoteServerLib.RemSrvTranscriptManager remServer =
                (RemoteServerLib.RemSrvTranscriptManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvTranscriptManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectByStudentIDTranscriptDetails");

            return remServer.SelectByStudentIDTranscriptDetails(userInfo, studentId);

        } //------------------------------

        /// <summary>
        /// This function returns the transcript details by student id list and semester sysid
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="studentIdList"></param>
        /// <param name="semesterSysId"></param>
        /// <returns></returns>
        public DataTable SelectBySysIDScheduleSpecialListTranscriptDetails(CommonExchange.SysAccess userInfo, String studentIdList, String semesterSysId)
        {
            RemoteServerLib.RemSrvTranscriptManager remServer =
                (RemoteServerLib.RemSrvTranscriptManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvTranscriptManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDScheduleSpecialListTranscriptDetails");

            return remServer.SelectBySysIDScheduleSpecialListTranscriptDetails(userInfo, studentIdList, semesterSysId);

        } //------------------------------

        //this function gets the transcript information images by sysid_transcript list
        public DataTable SelectTranscriptImagesTranscriptInformation(CommonExchange.SysAccess userInfo, String transcriptSysIdList)
        {
            RemoteServerLib.RemSrvTranscriptManager remServer =
                (RemoteServerLib.RemSrvTranscriptManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvTranscriptManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectTranscriptImagesTranscriptInformation");

            return remServer.SelectTranscriptImagesTranscriptInformation(userInfo, transcriptSysIdList);

        } //------------------------------

        //this function is used to determine if the student id exists
        public Boolean IsExistStudentIDTranscriptInformation(CommonExchange.SysAccess userInfo, String studentId, String transcriptSysId)
        {
            RemoteServerLib.RemSrvTranscriptManager remServer =
                (RemoteServerLib.RemSrvTranscriptManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvTranscriptManager),
                TcpRemoteServer.GetRemoteServerTcp() + "IsExistStudentIDTranscriptInformation");

            return remServer.IsExistStudentIDTranscriptInformation(userInfo, studentId, transcriptSysId);
        } //----------------------------- 

        //this function is used to get data tables stored in one dataset used for transcript information
        public DataSet GetDataSetForTranscriptInfo(CommonExchange.SysAccess userInfo)
        {
            RemoteServerLib.RemSrvTranscriptManager remServer =
                (RemoteServerLib.RemSrvTranscriptManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvTranscriptManager),
                TcpRemoteServer.GetRemoteServerTcp() + "GetDataSetForTranscriptInfo");

            return remServer.GetDataSetForTranscriptInfo(userInfo);
        } //----------------------------------


        #endregion
    }
}
