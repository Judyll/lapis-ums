using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;

namespace RemoteClient
{
    [Serializable()]
    internal class TcpRemoteServer
    {
        #region Programmer-Defined Function Procedures

        //this function returns the tcp path of the remote server
        public static String GetRemoteServerTcp()
        {
            String tcpPath = String.Empty;      //    "tcp://192.168.1.135:4080/";     "tcp://localhost:4080/";

            if (AppServer.IsLocalHost)
            {
                tcpPath = AppServer.TcpHeader + "localhost" + AppServer.PortHeader;
            }
            else
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send(AppServer.PrimaryIp, 10);

                    if (reply.Status == IPStatus.Success)
                    {
                        tcpPath = AppServer.TcpHeader + AppServer.PrimaryIp + AppServer.PortHeader;
                    }
                    else
                    {
                        tcpPath = AppServer.TcpHeader + AppServer.FailOverIp + AppServer.PortHeader;
                    }
                }
            }          

            return tcpPath;
        } //-----------------------------

        //this function returns the tcp path of the remote server
        public static String GetRemoteServerTcp(CommonExchange.ServerCode sCode)
        {
            String tcpPath = String.Empty;      //    "tcp://192.168.1.135:4080/";     "tcp://localhost:4080/";

            if (AppServer.IsLocalHost)
            {
                tcpPath = AppServer.TcpHeader + "localhost" + AppServer.PortHeader;
            }
            else
            {
                if (sCode == CommonExchange.ServerCode.PrimaryServer)
                {
                    using (Ping ping = new Ping())
                    {
                        PingReply reply = ping.Send(AppServer.PrimaryIp, 10);

                        if (reply.Status == IPStatus.Success)
                        {
                            tcpPath = AppServer.TcpHeader + AppServer.PrimaryIp + AppServer.PortHeader;
                        }
                        else
                        {
                            tcpPath = AppServer.TcpHeader + AppServer.FailOverIp + AppServer.PortHeader;
                        }
                    }
                }
                else if (sCode == CommonExchange.ServerCode.FailOverServer)
                {
                    using (Ping ping = new Ping())
                    {
                        PingReply reply = ping.Send(AppServer.FailOverIp, 10);

                        if (reply.Status == IPStatus.Success)
                        {
                            tcpPath = AppServer.TcpHeader + AppServer.FailOverIp + AppServer.PortHeader;                            
                        }
                        else
                        {
                            tcpPath = AppServer.TcpHeader + AppServer.PrimaryIp + AppServer.PortHeader;
                        }
                    }
                }
            }

            return tcpPath;
        } //-----------------------------

        #endregion
    }
}
