using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RemoteClient
{
    public delegate void ControlSchoolYearSemesterManagerModeOptionCheckedChanged(Boolean forSchoolYear);
    public delegate void ControlSchoolYearSemesterManagerPressEnter(object sender, KeyEventArgs e);

    partial class ControlSchoolYearSemesterManager
    {
        #region Class Event Declarations
        public event ControlSchoolYearSemesterManagerModeOptionCheckedChanged OnModeOptionCheckedChanged;
        public event ControlSchoolYearSemesterManagerPressEnter OnPressEnter;
        #endregion

        #region Class Constructor
        public ControlSchoolYearSemesterManager()
        {
            this.InitializeComponent();

            this.optSchoolYear.CheckedChanged += new EventHandler(optSchoolYearCheckedChanged);
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

        //###########################################CHECKBOX optSchoolYear EVENTS###########################################
        //event is raised when the check is changed
        private void optSchoolYearCheckedChanged(object sender, EventArgs e)
        {
            ControlSchoolYearSemesterManagerModeOptionCheckedChanged ev = OnModeOptionCheckedChanged;

            if (ev != null)
            {
                OnModeOptionCheckedChanged(optSchoolYear.Checked);
            }

            this.txtSearch.Clear();
            this.txtSearch.Focus();

        } //------------------------------
        //#########################################END CHECKBOX optSchoolYear EVENTS##########################################

        //###################################TEXTBOX txtSearch EVENTS##########################################
        //event is raised when the key is up
        protected override void txtSearchKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ControlSchoolYearSemesterManagerPressEnter ev = OnPressEnter;

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

        #region Programmer-Defined Void Procedures

        //this procedure disables the semester option
        public void DisableSemesterOption()
        {
            this.optSemester.Enabled = false;
        } //----------------------------
        #endregion
    }
}
