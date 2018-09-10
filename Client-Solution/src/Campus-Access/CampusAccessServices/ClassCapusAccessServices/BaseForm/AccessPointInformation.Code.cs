using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CampusAccessServices
{
    partial class AccessPointInformation
    {
        #region Class Data Member Decleration
        private CommonExchange.SysAccess _userInfo;
        private CampusAccessLogic _campusAccessManager;
        #endregion

        #region Class Constructors
        public AccessPointInformation(CommonExchange.SysAccess userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;

            this.Load += new EventHandler(ClassLoad);
            this.btnConnect.Click += new EventHandler(btnConnectClick);
        }
        #endregion

        #region Class Event Void Procedures
        //####################################################CLASS AccessPointInformation EVENTS###############################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            if (!(RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                RemoteServerLib.ProcStatic.IsSystemAccessGateKeepers(_userInfo)))
            {
                throw new Exception("You are not authorized to access this module.");
            }
            else
            {
                _campusAccessManager = new CampusAccessLogic(_userInfo);

                _campusAccessManager.InitializeAccessPointComboBox(this.cboAccessPoint);
            }
        }//--------------------------
        //####################################################END CLASS AccessPointInformation EVENTS###############################################

        //####################################################BUTTON btnConnect EVENTS###############################################
        //event is raised when the class is loaded
        private void btnConnectClick(object sender, EventArgs e)
        {
            if (this.cboAccessPoint.SelectedIndex > 0)
            {
                this.Cursor = Cursors.WaitCursor;

                this.pgbBase.PerformStep();

                _campusAccessManager.SelectForCampusAccessStudentEmployeeInformation(_userInfo);

                this.pgbBase.PerformStep();

                String personSysIdList = _campusAccessManager.GetPersonSysIdListFormat(this.pgbBase, ref this.lblStatus);

                this.pgbBase.Value = 0;

                _campusAccessManager.InitializePersonImages(_userInfo, personSysIdList, Application.StartupPath, this.pgbBase, this.lblStatus);

                this.Hide();

                using (CampusAccessManager frmShow = new CampusAccessManager(_userInfo, _campusAccessManager, 
                    _campusAccessManager.GetAccessPointId(this.cboAccessPoint.SelectedIndex)))
                {
                    frmShow.ShowDialog(this);
                }

                this.pgbBase.Value = 0;

                this.Cursor = Cursors.Arrow;
            }
            else
            {
                MessageBox.Show("Plese select an access point.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//-------------------------
        //####################################################END BUTTON btnConnect EVENTS###############################################
        #endregion
    }
}
