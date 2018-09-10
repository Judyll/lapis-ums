using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace RemoteClient
{
    public class RemCntBinaryUpdater : IDisposable
    {
        #region Constructor and Destructor
        public RemCntBinaryUpdater() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Function Procedures   

        //this function returns the updated binaries
        public List<CommonExchange.UmsBinaries> SelectUMSBinaries()
        {
            RemoteServerLib.RemSrvBinaryUpdater remServer = (RemoteServerLib.RemSrvBinaryUpdater)Activator.GetObject(typeof(RemoteServerLib.RemSrvBinaryUpdater),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectUMSBinaries");

            return remServer.SelectUMSBinaries();

        } //----------------------------

        //this function returns the updated campus access binaries
        public List<CommonExchange.UmsBinaries> SelectUMSCampusAccessBinaries()
        {
            RemoteServerLib.RemSrvBinaryUpdater remServer = (RemoteServerLib.RemSrvBinaryUpdater)Activator.GetObject(typeof(RemoteServerLib.RemSrvBinaryUpdater),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectUMSCampusAccessBinaries");

            return remServer.SelectUMSCampusAccessBinaries();
        } //----------------------------

        #endregion
    }
}
