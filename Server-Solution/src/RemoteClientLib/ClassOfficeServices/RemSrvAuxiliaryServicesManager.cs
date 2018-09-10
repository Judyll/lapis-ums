using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvAuxiliaryServicesManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvAuxiliaryServicesManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new auxiliary service information
        public void InsertAuxiliaryServiceInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.AuxiliaryServiceInformation serviceInfo) { }

        //this procedure updates an auxiliary service information
        public void UpdateAuxiliaryServiceInformation(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceInformation serviceInfo) { }

        //this procedure inserts a new auxiliary service schedule
        public void InsertAuxiliaryServiceSchedule(CommonExchange.SysAccess userInfo, ref CommonExchange.AuxiliaryServiceSchedule serviceScheduleInfo) { }

        //this procedure updates an auxiliary service schedule
        public void UpdateAuxiliaryServiceSchedule(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceSchedule serviceScheduleInfo) { }

        //this procedure deletes an auxiliary service schedule
        public void DeleteAuxiliaryServiceSchedule(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceSchedule serviceScheduleInfo) { }

        //this procedure inserts a new auxiliary service details
        public void InsertAuxiliaryServiceDetails(CommonExchange.SysAccess userInfo, ref CommonExchange.AuxiliaryServiceDetails serviceDetailsInfo) { }

        //this procedure updates an auxiliary service details
        public void UpdateAuxiliaryServiceDetails(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceDetails serviceDetailsInfo) { }
        
        //this procedure deletes an auxiliary service details
        public void DeleteAuxiliaryServiceDetails(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceDetails serviceDetailsInfo) { }


        #endregion

        #region Programmer-Defined Function Procedures

        //this function is used to get the service information by service code or title
        public DataTable SelectByServiceCodeTitleAuxiliaryServiceInformation(CommonExchange.SysAccess userInfo, String queryString)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //------------------------------------------

        //this function is used to get the auxiliary service details by date start and date end
        public DataTable SelectByDateStartEndAuxiliaryServiceDetails(CommonExchange.SysAccess userInfo, String queryString,
            String dateStart, String dateEnd, Boolean isMarkedDeleted)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //-------------------------------------------------

        //this function determines if the auxiliary service code and descriptive title exist
        public Boolean IsExistCodeDescriptionAuxiliaryServiceInformation(CommonExchange.SysAccess userInfo, 
            CommonExchange.AuxiliaryServiceInformation serviceInfo)
        {
            Boolean isExist = false;

            return isExist;

        } //------------------------------

        //this function is used to get data tables stored in one dataset used for auxiliary service
        public DataSet GetDataSetForAuxiliaryService(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            DataSet dbSet = new DataSet();

            return dbSet;
        } //---------------------------------

        #endregion
    }
}
