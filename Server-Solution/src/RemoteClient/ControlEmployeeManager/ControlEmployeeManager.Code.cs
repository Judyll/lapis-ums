using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RemoteClient
{
    public delegate void ControlEmployeeManagerButtonAddClick();
    public delegate void ControlEmployeeManagerStatusOptionCheckedChanged();
    public delegate void ControlEmployeeManagerPressEnter(object sender, KeyEventArgs e);

    partial class ControlEmployeeManager
    {
        #region Class Event Declarations
        public event ControlEmployeeManagerButtonAddClick OnAdd;
        public event ControlEmployeeManagerStatusOptionCheckedChanged OnStatusCheckedChanged;
        public event ControlEmployeeManagerPressEnter OnPressEnter;
        #endregion      
  
        #region Class Properties Declaration

        public Boolean IncludePartTime
        {
            get { return this.chkPartTime.Checked; }
        }

        public Boolean IncludeProbationary
        {
            get { return this.chkProbationary.Checked; }
        }

        public Boolean IncludeRegular
        {
            get { return this.chkRegular.Checked; }
        }

        public Boolean IncludeLayOff
        {
            get { return this.chkLayOff.Checked; }
        }

        public Boolean IncludeGraduateSchoolFaculty
        {
            get { return this.chkGraduate.Checked; }
        }

        public Boolean IncludeGraduateSchoolCollegeFaculty
        {
            get { return this.chkGraduateCollege.Checked; }
        }

        public Boolean IncludeGraduateSchoolHighSchoolFaculty
        {
            get { return this.chkGraduateHS.Checked; }
        }

        public Boolean IncludeGraduateSchoolGradeSchoolKinderFaculty
        {
            get { return this.chkGraduateGSK.Checked; }
        }

        public Boolean IncludeCollegeFaculty
        {
            get { return this.chkCollege.Checked; }            
        }
        
        public Boolean IncludeHighSchoolFaculty
        {
            get { return this.chkHighSchool.Checked; }
        }
        
        public Boolean IncludeGradeKinderFaculty
        {
            get { return this.chkGradeKinder.Checked; }
        }

        public Boolean IncludeStaff
        {
            get { return chkStaff.Checked; }
        }
        
        public Boolean IncludeAcademic
        {
            get { return chkAcademic.Checked; }
        }

        public Boolean IncludeMaintenance
        {
            get { return chkMaintenance.Checked; }
        }

        #endregion

        #region Class Constructor
        public ControlEmployeeManager()
        {
            this.InitializeComponent();

            this.pbxAdd.Click += new EventHandler(pbxAddClick);
            this.chkPartTime.CheckedChanged += new EventHandler(checkBoxStatusCheckedChanged);
            this.chkProbationary.CheckedChanged += new EventHandler(checkBoxStatusCheckedChanged);
            this.chkRegular.CheckedChanged += new EventHandler(checkBoxStatusCheckedChanged);
            this.chkLayOff.CheckedChanged += new EventHandler(checkBoxStatusCheckedChanged);
            this.chkGraduate.CheckedChanged += new EventHandler(checkBoxStatusCheckedChanged);
            this.chkGraduateCollege.CheckedChanged += new EventHandler(checkBoxStatusCheckedChanged);
            this.chkGraduateHS.CheckedChanged += new EventHandler(checkBoxStatusCheckedChanged);
            this.chkGraduateGSK.CheckedChanged += new EventHandler(checkBoxStatusCheckedChanged);
            this.chkCollege.CheckedChanged += new EventHandler(checkBoxStatusCheckedChanged);
            this.chkHighSchool.CheckedChanged += new EventHandler(checkBoxStatusCheckedChanged);
            this.chkGradeKinder.CheckedChanged += new EventHandler(checkBoxStatusCheckedChanged);
            this.chkStaff.CheckedChanged += new EventHandler(checkBoxStatusCheckedChanged);
            this.chkAcademic.CheckedChanged += new EventHandler(checkBoxStatusCheckedChanged);
            this.chkMaintenance.CheckedChanged += new EventHandler(checkBoxStatusCheckedChanged);
        }
                
        #endregion

        #region Class Event Void Procedures

        //#####################################CLASS ControlEmployeeManager EVENTS#######################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            base.ClassLoad(sender, e);

            _maxHeight = this.Size.Height;

            ttpMain.SetToolTip(this.pbxAdd, "Create a new employee");

        } //----------------------------
        //####################################END CLASS ControlEmployeeManager EVENTS####################################

        //##################################PICTUREBOX pbxAdd EVENTS####################################################
        //event is raised when the control is clicked
        private void pbxAddClick(object sender, EventArgs e)
        {
            ControlEmployeeManagerButtonAddClick ev = OnAdd;

            if (ev != null)
            {
                OnAdd();
            }

            this.txtSearch.Focus();
        } //-------------------------------
        //#################################END PICTUREBOX pbxAdd EVENTS#################################################

        //#####################################CHECKBOX STATUS EVENTS####################################################
        //event is raised when the check is changed
        private void checkBoxStatusCheckedChanged(object sender, EventArgs e)
        {
            ControlEmployeeManagerStatusOptionCheckedChanged ev = OnStatusCheckedChanged;

            if (ev != null)
            {
                OnStatusCheckedChanged();
            }

            this.txtSearch.Focus();
            
        } //--------------------------
        //####################################END CHECKBOX STATUS EVENTS#################################################

        //###################################TEXTBOX txtSearch EVENTS##########################################
        //event is raised when the key is up
        protected override void txtSearchKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ControlEmployeeManagerPressEnter ev = OnPressEnter;

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

        //this procedure disables the lay-off option
        public void DisableLayOffOption(Boolean disable)
        {
            chkLayOff.Checked = disable;
            chkLayOff.Enabled = disable;
        } //---------------------

        //this procedure hides the create employee icon
        public void HideCreateEmployeeIcon()
        {
            this.pbxAdd.Visible = false;
        } //-------------------------------

        #endregion

    }
}
