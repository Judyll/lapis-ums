using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace AttendaceServices
{
    partial class LogInLogOutStudentInformation : IDisposable
    {
        #region Class Data Member Decleration and Distructor
        private CommonExchange.Student _studentInfo;
        #endregion

        #region Class Construcrors
        public LogInLogOutStudentInformation(CommonExchange.SysAccess userInfo, CommonExchange.Student studentInfo, AttendanceLogic attendanceManager)
            : base(userInfo, attendanceManager)
        {
            this.InitializeComponent();

            _studentInfo = studentInfo;
        }

        void IDisposable.Dispose()
        {
            if (pbxPhoto.Image != null)
            {
                pbxPhoto.Image.Dispose();
                pbxPhoto.Image = null;

                pbxPhoto.Dispose();
                pbxPhoto = null;
            }

            GC.SuppressFinalize(this);
            GC.Collect();
        }
        #endregion

        #region Class Event Void Procedures
        //###########################################CLASS LogInLogOutInformation ClassLoad EVENTS#####################################################
        //event is raised when the class is loaded
        protected override void ClassCload(object sender, EventArgs e)
        {
            this.lblId.Text = _studentInfo.StudentId;
            this.lblLastName.Text = _studentInfo.PersonInfo.LastName;
            this.lblFirstName.Text = _studentInfo.PersonInfo.FirstName;
            this.lblMiddleName.Text = _studentInfo.PersonInfo.MiddleName;
            this.lblCardNumber.Text = _studentInfo.CardNumber;

            if (!String.IsNullOrEmpty(_studentInfo.PersonInfo.FilePath))
            {
                this.pbxPhoto.Image = Image.FromFile(_studentInfo.PersonInfo.FilePath);
            }

            _dateStart = this.dtpStart.Value.ToShortDateString() + " 12:00:00 AM";
            _dateEnd = this.dtpEnd.Value.ToShortDateString() + " 11:59:59 PM";

            this.SetCampusAccessDetails(_studentInfo.PersonInfo.PersonSysId);
            RemoteClient.ProcStatic.SetDataGridViewColumns(this.dgvList, false);
        }//---------------------------
        //###########################################END CLASS LogInLogOutInformation ClassLoad EVENTS#####################################################

        //###########################################DATETIMEPICKER dtpStart EVENTS#####################################################
        //event is raised when the value ic changed
        protected override void dtpStartValueChanged(object sender, EventArgs e)
        {
            base.dtpStartValueChanged(sender, e);

            this.SetCampusAccessDetails(_studentInfo.PersonInfo.PersonSysId);
        }//---------------------------
        //###########################################END DATETIMEPICKER dtpStart EVENTS#####################################################

        //###########################################DATETIMEPICKER dtpEnd EVENTS#####################################################
        //event is raised when the value ic changed
        protected override void dtpEndValueChanged(object sender, EventArgs e)
        {
            base.dtpEndValueChanged(sender, e);

            this.SetCampusAccessDetails(_studentInfo.PersonInfo.PersonSysId);
        }//---------------------------
        //###########################################END DATETIMEPICKER dtpEnd EVENTS#####################################################
        #endregion
    }
}
