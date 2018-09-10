using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CampusAccessServices
{
    partial class UpdatingForm : IDisposable
    {
        #region Class Data Member Decleration
        private CommonExchange.SysAccess _userInfo;
        private CampusAccessLogic _campusAccessManager;
        #endregion

        #region Class Constructors
        public UpdatingForm(CommonExchange.SysAccess userInfo, CampusAccessLogic campusAccessManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _campusAccessManager = campusAccessManager;

            this.Load += new EventHandler(ClassLoad);
            this.Activated += new EventHandler(UpdatingFormActivated);
        }

        void IDisposable.Dispose()
        {
            this.Dispose();

            GC.SuppressFinalize(this);
            GC.Collect();
        }
        #endregion

        #region Class Event Void Procedures
        private void ClassLoad(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void UpdatingFormActivated(object sender, EventArgs e)
        {
            try
            {
                _campusAccessManager.InsertCampusAccessDetails(_userInfo);

                this.Close();
            }
            catch
            {
                this.Close();
            }
        }
        #endregion
    }
}
