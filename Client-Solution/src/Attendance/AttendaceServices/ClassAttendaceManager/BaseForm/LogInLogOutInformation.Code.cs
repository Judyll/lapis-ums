using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AttendaceServices
{
    partial class LogInLogOutInformation
    {
        #region Class Data Member Declaration
        protected CommonExchange.SysAccess _userInfo;
        protected AttendanceLogic _attendaceManager;

        protected String _dateStart = String.Empty;
        protected String _dateEnd = String.Empty;
        #endregion

        #region Class Constructors
        public LogInLogOutInformation()
        {
            this.InitializeComponent();
        }

        public LogInLogOutInformation(CommonExchange.SysAccess userInfo, AttendanceLogic attendaceManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _attendaceManager = attendaceManager;

            this.Load += new EventHandler(ClassCload);
            this.dtpStart.ValueChanged += new EventHandler(dtpStartValueChanged);
            this.dtpEnd.ValueChanged += new EventHandler(dtpEndValueChanged);
            this.btnClose.Click += new EventHandler(btnCloseClick);
        }
        #endregion

        #region Class Event Void Procedures
        //###########################################CLASS LogInLogOutInformation ClassLoad EVENTS#####################################################
        //event is raised when the class is loaded
        protected virtual void ClassCload(object sender, EventArgs e)
        {
            this.dgvList.DataSource = _attendaceManager.CampusAccessDetailsTable;
            RemoteClient.ProcStatic.SetDataGridViewColumns(dgvList, false);
        }//-----------------------
        //###########################################END CLASS LogInLogOutInformation ClassLoad EVENTS#####################################################

        //###########################################DATETIMEPICKER dtpStart EVENTS#####################################################
        //event is raised when the value ic changed
        protected virtual void dtpStartValueChanged(object sender, EventArgs e)
        {
            _dateStart = this.dtpStart.Value.ToShortDateString() + " 12:00:00 AM";
        }//-----------------------
        //###########################################END DATETIMEPICKER dtpStart EVENTS#####################################################

        //###########################################DATETIMEPICKER dtpEnd EVENTS#####################################################
        //event is raised when the value ic changed
        protected virtual void dtpEndValueChanged(object sender, EventArgs e)
        {
            _dateEnd = this.dtpEnd.Value.ToShortDateString() + " 11:59:59 PM";
        }//-------------------------
        //###########################################END DATETIMEPICKER dtpEnd EVENTS#####################################################

        //###########################################BUTTON btnClose EVENTS#####################################################
        //event is raised when the value ic changed
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//-------------------------
        //###########################################END BUTTON btnClose EVENTS#####################################################
        #endregion

        #region Programmer's Defined Void Procedures
        //this procedure will set campus access details
        public void SetCampusAccessDetails(String personSysId)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.dgvList.DataSource = _attendaceManager.GetSearchedCampusAccessDetails(_userInfo, personSysId, _dateStart, _dateEnd);

                Int32 result = dgvList.Rows.Count;

                if (result == 0 || result == 1)
                {
                    this.lblResult.Text = result.ToString() + " Record";
                }
                else
                {
                    this.lblResult.Text = result.ToString() + " Records";
                }

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error");
            }
        }//----------------------------
        #endregion
    }
}
