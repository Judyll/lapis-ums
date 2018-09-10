using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteServerLib
{
    [Serializable()]
    internal class DataServer
    {
        public static Boolean IsLocalHost
        {
            get { return true; }
        }

        public static String PrimaryIp
        {
            get { return @"192.168.3.44"; }
        }

        public static String FailOverIp
        {
            get { return PrimaryIp; }
        }

        public static String InitialCatalog
        {
            get { return @"db_umsdev_03_30_2007"; }
        }

        public static String UserId
        {
            get { return @"Um$D3vL06in0408C4ak47@x"; }
        }

        public static String Password
        {
            get { return @"8RjM#s_qW6XiU&^xz4"; }
        }
    }
}
