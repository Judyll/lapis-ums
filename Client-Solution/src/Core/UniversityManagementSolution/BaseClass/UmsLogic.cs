using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityManagementSolution
{
    internal class UmsLogic
    {

        #region Class Properties Declaration
        private String _serverDateTime;
        public String ServerDateTime
        {
            get { return _serverDateTime; }
        }
        #endregion

        #region Class Constructors
        public UmsLogic(CommonExchange.SysAccess userInfo)
        {
            this.InitializedClass(userInfo);
        }
        #endregion

        #region Programers-Defined Procedures
        //this procedure will Initialized the class
        private void InitializedClass(CommonExchange.SysAccess userInfo)
        {
            //get server date time
            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                _serverDateTime = remClient.GetServerDateTime(userInfo);
            }
        }//-------------------------
        #endregion
    }
}
