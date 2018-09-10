using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteClient
{
    [Serializable()]
    internal class AppServer
    {
        public static Boolean IsLocalHost
        {
            get { return false; }
        }

        public static String PrimaryIp
        {
            get { return @"192.168.1.136"; }
        }

        public static String FailOverIp
        {
            get { return PrimaryIp; }
        }

        public static String PortHeader
        {
            get { return @":4080/"; }
        }

        public static String TcpHeader
        {
            get { return @"tcp://"; }
        }

    }
}
