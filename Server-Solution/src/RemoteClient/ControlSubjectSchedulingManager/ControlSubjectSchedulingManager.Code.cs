using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RemoteClient
{
    public delegate void ControlSubjectSchedulingManagerOptionCheckedChanged();
    public delegate void ControlSubjectSchedulingManagerSchoolYearSelectedIndexChanged();
    public delegate void ControlSubjectSchedulingManagerSemesterSelectedIndexChanged();
    public delegate void ControlSubjectSchedulingManagerPressEnter(object sender, KeyEventArgs e);

    partial class ControlSubjectSchedulingManager
    {
        #region Class Event Declarations
        public event ControlSubjectSchedulingManagerOptionCheckedChanged OnOptionCheckedChanged;
        public event ControlSubjectSchedulingManagerSchoolYearSelectedIndexChanged OnSchoolYearSelectedIndexChanged;
        public event ControlSubjectSchedulingManagerSemesterSelectedIndexChanged OnSemesterSelectedIndexChanged;
        public event ControlSubjectSchedulingManagerPressEnter OnPressEnter;
        #endregion

        #region Class Properties Declarations

        public Boolean IsMarkedDeleted
        {
            get { return this.optDelete.Checked; }
        }

        public ComboBox SchoolYearComboBox
        {
            get { return this.cboYear; }
            set { this.cboYear = value; }
        }

        public Int32 SchoolYearIndex
        {
            get { return this.cboYear.SelectedIndex; }
        }

        public ComboBox SemesterComboBox
        {
            get { return this.cboSemester; }
            set { this.cboSemester = value; }
        }

        public Int32 SemesterIndex
        {
            get { return this.cboSemester.SelectedIndex; }
        }

        #endregion

        #region Class Constructor
        public ControlSubjectSchedulingManager()
        {
            this.InitializeComponent();

            this.optLoad.CheckedChanged += new EventHandler(OptionButtonCheckedChanged);
            this.cboYear.SelectedIndexChanged += new EventHandler(cboYearSelectedIndexChanged);
            this.cboSemester.SelectedIndexChanged += new EventHandler(cboSemesterSelectedIndexChanged);
        }  
        
        #endregion

        #region Class Event Void Procedures

        //#####################################CLASS ControlStudentManager EVENTS#######################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            base.ClassLoad(sender, e);

            _maxHeight = this.Size.Height;

        } //----------------------------
        //####################################END CLASS ControlStudentManager EVENTS####################################

        //######################################OPTIONBUTTON EVENTS####################################################
        //event is raised when the option checked is changed
        private void OptionButtonCheckedChanged(object sender, EventArgs e)
        {
            ControlSubjectSchedulingManagerOptionCheckedChanged ev = OnOptionCheckedChanged;

            if (ev != null)
            {
                OnOptionCheckedChanged();
            }

            this.txtSearch.Focus();

        } //----------------------------------
        //###################################END OPTIONBUTTON EVENTS###################################################

        //##########################################COMBOBOX cboYear EVENTS###############################################
        //event is raised when the selected index is changed
        private void cboYearSelectedIndexChanged(object sender, EventArgs e)
        {
            ControlSubjectSchedulingManagerSchoolYearSelectedIndexChanged ev = OnSchoolYearSelectedIndexChanged;

            if (ev != null)
            {
                OnSchoolYearSelectedIndexChanged();
            }

            this.txtSearch.Focus();
        } //------------------------------------
        //######################################END COMBOBOX cboYear EVENTS################################################

        //############################################COMBOBOX cboSemester EVENTS##########################################
        //event is raised when the selected index is changed
        private void cboSemesterSelectedIndexChanged(object sender, EventArgs e)
        {
            ControlSubjectSchedulingManagerSemesterSelectedIndexChanged ev = OnSemesterSelectedIndexChanged;

            if (ev != null)
            {
                OnSemesterSelectedIndexChanged();
            }

            this.txtSearch.Focus();
        } //------------------------------------------
        //###########################################END COMBOBOX cboSemester EVENTS#######################################

        //###################################TEXTBOX txtSearch EVENTS##########################################
        //event is raised when the key is up
        protected override void txtSearchKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ControlSubjectSchedulingManagerPressEnter ev = OnPressEnter;

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
            this.cboSemester.Enabled = false;
        } //----------------------------
        #endregion
    }
}
