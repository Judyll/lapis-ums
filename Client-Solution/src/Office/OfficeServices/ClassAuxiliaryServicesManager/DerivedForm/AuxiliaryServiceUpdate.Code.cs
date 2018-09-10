using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class AuxiliaryServiceUpdate
    {
        #region Class General Variable Declaration
        private CommonExchange.AuxiliaryServiceInformation _serviceInfoTemp;
        #endregion

        #region Class Properties Declarations
        private Boolean _hasUpdated = false;
        public Boolean HasUpdated
        {
            get { return _hasUpdated; }
        }
        #endregion

        #region Class Constructors
        public AuxiliaryServiceUpdate(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceInformation serviceInfo,
            AuxiliaryServiceLogic auxiliaryInfoManager)
            : base(userInfo, auxiliaryInfoManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _serviceInfo = serviceInfo;
            _serviceInfoTemp = (CommonExchange.AuxiliaryServiceInformation)serviceInfo.Clone();
            _auxiliaryManager = auxiliaryInfoManager;

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
        }        
        #endregion

        #region Class Event Void Procedures
        //########################################CLASS ClassroomUpdate EVENTS####################################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {            
            if (!(RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                RemoteServerLib.ProcStatic.IsSystemAccessVpOfAcademicAffairs(_userInfo) ||
                RemoteServerLib.ProcStatic.IsSystemAccessSecretaryOftheVpOfAcademicAffairs(_userInfo)))
            {
                throw new Exception("You are not authorized to access this module.");
            }

            this.lblSysID.Text = _serviceInfo.AuxServiceSysId;

            _auxiliaryManager.InitializeCourseGroupCombo(this.cboCourseGroup, _serviceInfo.CourseGroupInfo.CourseGroupId);
            _auxiliaryManager.InitializeDepartmentCombo(this.cboDepartment, _serviceInfo.DepartmentInfo.DepartmentId);

            this.txtCode.Text = _serviceInfo.ServiceCode;
            this.txtTitle.Text = _serviceInfo.DescriptiveTitle;
            this.txtLecture.Text = _serviceInfo.LectureUnits.ToString();
            this.txtLaboratory.Text = _serviceInfo.LabUnits.ToString();

            this.cboCourseGroup.Enabled = false;

            Int32 hours = 0, minutes = 0, count = 1;

            if (!String.IsNullOrEmpty(_serviceInfo.NoHours))
            {
                String[] strSplit = _serviceInfo.NoHours.Split(':');

                foreach (String value in strSplit)
                {
                    if (!String.IsNullOrEmpty(value))
                    {
                        if (count == 1)
                        {
                            hours = Int32.Parse(value);
                        }
                        else
                        {
                            minutes = Int32.Parse(value);
                        }
                    }

                    count++;
                }
            }

            this.hrmHours.SetHoursMinutes(hours, minutes);
            //this.hrmHours.SetHoursMinutes(DateTime.Parse(_serviceInfo.NoHours));

            if (!this.hrmHours.IsHourMinuteZero())
            {
                this.optHours.Checked = true;
                this.optUnits.Checked = false;
            }
            else
            {
                this.optHours.Checked = false;
                this.optUnits.Checked = true;
            }
        }//-----------------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasUpdated && (!_serviceInfo.Equals(_serviceInfoTemp)))
            {
                String strMsg = "There has been changes made in the current auxiliary service information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        } //----------------------------------
        //######################################END CLASS ClassroomUpdate EVENTS##################################################

        //#########################################BUTTON btnClose EVENTS##################################################
        //event is raised when the button is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//------------------------------------------
        //#######################################END BUTTON btnClose EVENTS#################################################

        //###########################################BUTTON btnUpdate EVENTS#####################################################
        //event is raised when the button is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to update the auxiliary service information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The auxiliary service information has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _auxiliaryManager.UpdateAuxiliaryServiceInformation(_userInfo, _serviceInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdated = true;

                        this.Close();
                    }
                    else if (msgResult == DialogResult.Cancel)
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Updating");
                }
            }

        }//------------------------------
        //##########################################END BUTTON btnUpdate EVENTS##################################################

        #endregion
    }
}
