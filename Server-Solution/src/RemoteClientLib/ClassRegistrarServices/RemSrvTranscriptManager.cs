using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvTranscriptManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvTranscriptManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new transcript information
        public void InsertTranscriptInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.TranscriptInformation transcriptInfo) { }

        //this procedure inserts a new transcript information
        public void UpdateTranscriptInformation(CommonExchange.SysAccess userInfo, CommonExchange.TranscriptInformation transcriptInfo) { }

        //this procedure insert, update or delete a transcript details
        public void InsertUpdateDeleteTranscriptDetails(CommonExchange.SysAccess userInfo, String transcriptSysId, DataTable transcriptDetailsTable) { }

        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the student information table query
        public DataTable SelectTranscriptInformation(CommonExchange.SysAccess userInfo, String queryString)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

        } //------------------------------

        //this function gets the transcript details table query
        public DataTable SelectBySysIDTranscriptDetails(CommonExchange.SysAccess userInfo, String transcriptSysId)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

        } //------------------------------

        /// <summary>
        /// This function returns the transcript information details
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public DataTable SelectByStudentIDTranscriptDetails(CommonExchange.SysAccess userInfo, String studentId)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

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
            DataTable dbTable = new DataTable();

            return dbTable;

        } //------------------------------

        //this function gets the transcript information images by sysid_transcript list
        public DataTable SelectTranscriptImagesTranscriptInformation(CommonExchange.SysAccess userInfo, String transcriptSysIdList)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

        } //------------------------------

        //this function is used to determine if the student id exists
        public Boolean IsExistStudentIDTranscriptInformation(CommonExchange.SysAccess userInfo, String studentId, String transcriptSysId)
        {
            Boolean isExist = false;

            return isExist;
        } //-----------------------------  

        //this function is used to get data tables stored in one dataset used for transcript information
        public DataSet GetDataSetForTranscriptInfo(CommonExchange.SysAccess userInfo)
        {
            DataSet dbSet = new DataSet();

            return dbSet;
        } //----------------------------------


        #endregion
    }
}
