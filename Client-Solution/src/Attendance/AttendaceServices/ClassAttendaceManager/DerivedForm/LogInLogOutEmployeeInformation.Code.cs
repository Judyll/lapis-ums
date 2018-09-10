using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace AttendaceServices
{
    partial class LogInLogOutEmployeeInformation : IDisposable
    {
        #region Class Data Member Decleration and Distructor
        private CommonExchange.Employee _employeeInfo;
        #endregion  

        #region Class Constructors
        public LogInLogOutEmployeeInformation(CommonExchange.SysAccess userInfo, CommonExchange.Employee employeeInfo, AttendanceLogic attendacManager)
            : base(userInfo, attendacManager)
        {
            this.InitializeComponent();

            _employeeInfo = employeeInfo;
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
        //###########################################CLASS LogInLogOutEmployeeInformation EVENTS#####################################################
        //event is raised when the class is loaded
        protected override void ClassCload(object sender, EventArgs e)
        {
            this.lblId.Text = _employeeInfo.EmployeeId;
            this.lblLastName.Text = _employeeInfo.PersonInfo.LastName;
            this.lblFirstName.Text = _employeeInfo.PersonInfo.FirstName;
            this.lblMiddleName.Text = _employeeInfo.PersonInfo.MiddleName;
            this.lblCardNumber.Text = _employeeInfo.CardNumber;

            if (!String.IsNullOrEmpty(_employeeInfo.PersonInfo.FilePath))
            {
                this.pbxPhoto.Image = Image.FromFile(_employeeInfo.PersonInfo.FilePath);
            }

            _dateStart = this.dtpStart.Value.ToShortDateString() + " 12:00:00 AM";
            _dateEnd = this.dtpEnd.Value.ToShortDateString() + " 11:59:59 PM";

            this.SetCampusAccessDetails(_employeeInfo.PersonInfo.PersonSysId);
            RemoteClient.ProcStatic.SetDataGridViewColumns(this.dgvList, false);
        }//---------------------------
        //###########################################END CLASS LogInLogOutEmployeeInformation EVENTS#####################################################

        //###########################################DATETIMEPICKER dtpStart EVENTS#####################################################
        //event is raised when the value ic changed
        protected override void dtpStartValueChanged(object sender, EventArgs e)
        {
            base.dtpStartValueChanged(sender, e);

            this.SetCampusAccessDetails(_employeeInfo.PersonInfo.PersonSysId);
        }//---------------------------
        //###########################################END DATETIMEPICKER dtpStart EVENTS#####################################################

        //###########################################DATETIMEPICKER dtpEnd EVENTS#####################################################
        //event is raised when the value ic changed
        protected override void dtpEndValueChanged(object sender, EventArgs e)
        {
            base.dtpEndValueChanged(sender, e);

            this.SetCampusAccessDetails(_employeeInfo.PersonInfo.PersonSysId);
        }//---------------------------
        //###########################################END DATETIMEPICKER dtpEnd EVENTS#####################################################
        #endregion
    }
}
