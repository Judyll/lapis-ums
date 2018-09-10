using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RemoteClient
{
    public delegate void ControlClassroomSubjectManagerModeOptionCheckedChanged(ClientExchange.RoomSubjectCourseFilter courseFilter);
    public delegate void ControlClassroomSubjectManagerPressEnter(object sender, KeyEventArgs e);

    partial class ControlCourseManager
    {
        #region Class Event Declarations
        public event ControlClassroomSubjectManagerModeOptionCheckedChanged OnModeOptionCheckedChanged;
        public event ControlClassroomSubjectManagerPressEnter OnPressEnter;
        #endregion

        #region Class Constructor
        public ControlCourseManager()
        {
            this.InitializeComponent();

            this.optClassroom.CheckedChanged += new EventHandler(RadioButtonsCheckedChanged);
            this.optSubject.CheckedChanged += new EventHandler(RadioButtonsCheckedChanged);
            this.optCourse.CheckedChanged += new EventHandler(RadioButtonsCheckedChanged);
        }
        #endregion

        #region Class Event Void Procedures

        //#####################################CLASS ControlDeductionManager EVENTS#######################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            base.ClassLoad(sender, e);

            _maxHeight = this.Size.Height;

        } //----------------------------
        //####################################END CLASS ControlDeductionManager EVENTS####################################

        //###########################################RADIOBUTTON EVENTS###########################################
        //event is raised when the check is changed
        private void RadioButtonsCheckedChanged(object sender, EventArgs e)
        {
            ControlClassroomSubjectManagerModeOptionCheckedChanged ev = OnModeOptionCheckedChanged;

            if (ev != null)
            {
                ClientExchange.RoomSubjectCourseFilter courseFilter = new ClientExchange.RoomSubjectCourseFilter();

                courseFilter.ForSubject = optSubject.Checked;
                courseFilter.ForRoom = optClassroom.Checked;
                courseFilter.ForCourse = optCourse.Checked;

                OnModeOptionCheckedChanged(courseFilter);
            }

            this.txtSearch.Clear();
            this.txtSearch.Focus();
            this.txtSearch.Select(0, 0);

        } //------------------------------
        //#########################################END RADIOBUTTON EVENTS##########################################

        //###################################TEXTBOX txtSearch EVENTS##########################################
        //event is raised when the key is up
        protected override void txtSearchKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ControlClassroomSubjectManagerPressEnter ev = OnPressEnter;

                if (ev != null)
                {
                    OnPressEnter(sender, e);
                }
            }
            else
            {
                base.txtSearchKeyUp(sender, e);
            }

        } //----------------------------------
        //#################################END TEXTBOX txtSearch EVENTS########################################

        #endregion
    }
}
