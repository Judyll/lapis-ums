using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CommonExchange
{
    #region Common Structure Exchange

    [Serializable()]
    public class AccessPoint
    {
        private AccessPoint() { }

        public static String Gate01
        {
            get { return "APID001"; }
        }

        public static String Gate02
        {
            get { return "APID002"; }
        }

        public static String Gate03
        {
            get { return "APID003"; }
        }
    }

    #endregion
}
