using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrarServices
{
    partial class SchoolYear
    {
        #region Class General Variable Declarations
        protected CommonExchange.SysAccess _userInfo;
        protected CommonExchange.SchoolYear _yearInfo;
        protected SchoolYearLogic _yearSemManager;
        #endregion  

        #region Class Constructor
        public SchoolYear()
        {
            InitializeComponent();
        }
        #endregion
    }
}
