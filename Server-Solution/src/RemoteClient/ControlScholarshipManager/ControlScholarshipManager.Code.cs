using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RemoteClient
{
    public delegate void ControlScholarshipManagerCheckedListBoxSelectedIndexChanged();
    public delegate void ControlScholarshipManagerSchoolYearSelectedIndexChanged();
    public delegate void ControlScholarshipManagerSemesterSelectedIndexChanged();
    public delegate void ControlScholarshipManagerResetQueryLinkClicked();
    public delegate void ControlScholarshipManagerPressEnter(object sender, KeyEventArgs e);
    public delegate void ControlScholarshipManagerScholarshipButtonClick();

    partial class ControlScholarshipManager
    {
        #region Class Event Declarations
        public event ControlScholarshipManagerCheckedListBoxSelectedIndexChanged OnDepartmentSelectedIndexChanged;
        public event ControlScholarshipManagerCheckedListBoxSelectedIndexChanged OnYearLevelSelectedIndexChanged;
        public event ControlScholarshipManagerCheckedListBoxSelectedIndexChanged OnScholarshipSelectedIndexChanged;
        public event ControlScholarshipManagerSchoolYearSelectedIndexChanged OnSchoolYearSelectedIndexChanged;
        public event ControlScholarshipManagerSemesterSelectedIndexChanged OnSemesterSelectedIndexChanged;
        public event ControlScholarshipManagerResetQueryLinkClicked OnResetLinkClicked;
        public event ControlScholarshipManagerPressEnter OnPressEnter;
        public event ControlScholarshipManagerScholarshipButtonClick OnScholarshipInformationClick;
        #endregion

        #region Class Properties Declarations
        public CheckedListBox DepartmentCheckedListBox
        {
            get { return this.cbxDepartment; }
            set { this.lblDepartmentCount.Text = 0.ToString(); this.cbxDepartment = value; }
        }

        public CheckedListBox YearLevelCheckedListBox
        {
            get { return this.cbxYearLevel; }
            set { this.lblYearCount.Text = 0.ToString(); this.cbxYearLevel = value; }
        }

        public CheckedListBox ScholarshipCheckedListBox
        {
            get { return this.cbxScholarship; }
            set { this.lblScholarshipCount.Text = 0.ToString(); this.cbxScholarship = value; }
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
        public ControlScholarshipManager()
        {
            this.InitializeComponent();

            this.pbxScholarship.Click += new EventHandler(pbxScholarshipClick);
            this.cboYear.SelectedIndexChanged += new EventHandler(cboYearSelectedIndexChanged);
            this.cboSemester.SelectedIndexChanged += new EventHandler(cboSemesterSelectedIndexChanged);
            this.cbxDepartment.SelectedIndexChanged += new EventHandler(cbxDepartmentSelectedIndexChanged);
            this.lnkDepartmentNone.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkDepartmentNoneLinkClicked);
            this.cbxYearLevel.SelectedIndexChanged += new EventHandler(cbxYearLevelSelectedIndexChanged);
            this.lnkYearNone.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkYearNoneLinkClicked);
            this.cbxScholarship.SelectedIndexChanged += new EventHandler(cbxScholarshipSelectedIndexChanged);
            this.lnkScholarshipNone.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkScholarshipNoneLinkClicked);
            this.lnkResetQuery.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkResetQueryLinkClicked);
        }
        
        #endregion

        #region Class Event Void Procedures

        //#####################################CLASS ControlScholarshipManager EVENTS#######################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            base.ClassLoad(sender, e);

            _maxHeight = this.Size.Height;

            ttpMain.SetToolTip(this.pbxScholarship, "Scholarship Information");

        } //----------------------------
        //####################################END CLASS ControlScholarshipManager EVENTS####################################

        //#################################PICTUREBOX pbxScholarship EVENTS########################################
        //event is raised when the control is clicked
        private void pbxScholarshipClick(object sender, EventArgs e)
        {
            ControlScholarshipManagerScholarshipButtonClick ev = OnScholarshipInformationClick;

            if (ev != null)
            {
                OnScholarshipInformationClick();
            }

            this.txtSearch.Focus();

        } //----------------------------
        //##############################END PICTUREBOX pbxScholarship EVENTS#######################################

        //##########################################COMBOBOX cboYear EVENTS###############################################
        //event is raised when the selected index is changed
        private void cboYearSelectedIndexChanged(object sender, EventArgs e)
        {
            ControlScholarshipManagerSchoolYearSelectedIndexChanged ev = OnSchoolYearSelectedIndexChanged;

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
            ControlScholarshipManagerSemesterSelectedIndexChanged ev = OnSemesterSelectedIndexChanged;

            if (ev != null)
            {
                OnSemesterSelectedIndexChanged();
            }

            this.txtSearch.Focus();
        } //------------------------------------------
        //###########################################END COMBOBOX cboSemester EVENTS#######################################

        //###################################CHECKEDLISTBOX cbxDepartment EVENTS############################################
        //event is raised when the selected index is changed
        private void cbxDepartmentSelectedIndexChanged(object sender, EventArgs e)
        {
            ControlScholarshipManagerCheckedListBoxSelectedIndexChanged ev = OnDepartmentSelectedIndexChanged;

            if (ev != null)
            {
                OnDepartmentSelectedIndexChanged();
            }

            this.txtSearch.Focus();

            this.lblDepartmentCount.Text = cbxDepartment.CheckedItems.Count.ToString();

        } //-----------------------------------
        //#################################END CHECKEDLISTBOX cbxDepartment EVENTS##########################################

        //#########################################LINKBUTTON lnkDepartmentNone EVENTS###########################################################
        //event is raised when the link is clicked
        private void lnkDepartmentNoneLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SetAllListAsChecked(cbxDepartment, lblDepartmentCount, false);

            ControlScholarshipManagerCheckedListBoxSelectedIndexChanged ev = OnDepartmentSelectedIndexChanged;

            if (ev != null)
            {
                OnDepartmentSelectedIndexChanged();
            }

            this.txtSearch.Focus();

        } //-----------------------------
        //########################################END LINKBUTTON lnkDepartmentNone EVENTS########################################################### 

        //###########################################CHECKEDLISTBOX cbxYearLevel EVENTS#########################################################
        //event is raised when the selected index is changed
        private void cbxYearLevelSelectedIndexChanged(object sender, EventArgs e)
        {
            ControlScholarshipManagerCheckedListBoxSelectedIndexChanged ev = OnYearLevelSelectedIndexChanged;

            if (ev != null)
            {
                OnYearLevelSelectedIndexChanged();
            }

            this.txtSearch.Focus();

            this.lblYearCount.Text = cbxYearLevel.CheckedItems.Count.ToString();
        } //-----------------------------------------     
        //########################################END CHECKEDLISTBOX cbxYearLevel EVENTS#########################################################

        //###########################################LINKBUTTON lnkYearNone EVENTS###############################################################
        //event is raised when the link is clicked
        private void lnkYearNoneLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SetAllListAsChecked(cbxYearLevel, lblYearCount, false);

            ControlScholarshipManagerCheckedListBoxSelectedIndexChanged ev = OnYearLevelSelectedIndexChanged;

            if (ev != null)
            {
                OnYearLevelSelectedIndexChanged();
            }

            this.txtSearch.Focus();
        } //----------------------------------------------
        //#########################################END LINKBUTTON lnkYearNone EVENTS#############################################################

        //###########################################CHECKEDLISTBOX cbxScholarship EVENTS#########################################################
        //event is raised when the selected index is changed
        private void cbxScholarshipSelectedIndexChanged(object sender, EventArgs e)
        {
            ControlScholarshipManagerCheckedListBoxSelectedIndexChanged ev = OnScholarshipSelectedIndexChanged;

            if (ev != null)
            {
                OnScholarshipSelectedIndexChanged();
            }

            this.txtSearch.Focus();

            this.lblScholarshipCount.Text = cbxScholarship.CheckedItems.Count.ToString();
        } //-----------------------------------------     
        //########################################END CHECKEDLISTBOX cbxScholarship EVENTS#########################################################

        //###########################################LINKBUTTON lnkScholarshipNone EVENTS###############################################################
        //event is raised when the link is clicked
        private void lnkScholarshipNoneLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SetAllListAsChecked(cbxScholarship, lblScholarshipCount, false);

            ControlScholarshipManagerCheckedListBoxSelectedIndexChanged ev = OnScholarshipSelectedIndexChanged;

            if (ev != null)
            {
                OnScholarshipSelectedIndexChanged();
            }

            this.txtSearch.Focus();
        } //----------------------------------------------
        //#########################################END LINKBUTTON lnkScholarshipNone EVENTS#############################################################

        //##########################################LINKBUTTON lnkResetQuery EVENTS############################################################
        //event is raised when the link is clicked
        private void lnkResetQueryLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.lblDepartmentCount.Text = this.lblYearCount.Text = this.lblScholarshipCount.Text = 0.ToString();

            this.txtSearch.Clear();
            this.txtSearch.Focus();

            ControlScholarshipManagerResetQueryLinkClicked ev = OnResetLinkClicked;

            if (ev != null)
            {
                OnResetLinkClicked();
            }            

        } //------------------------------------------          

        //########################################END LINKBUTTON lnkResetQuery EVENTS##########################################################

        //###################################TEXTBOX txtSearch EVENTS##########################################
        //event is raised when the key is up
        protected override void txtSearchKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ControlScholarshipManagerPressEnter ev = OnPressEnter;

                if (ev != null)
                {
                    OnPressEnter(sender, e);
                }
            }
            else
            {
                base.txtSearchKeyUp(sender, e);
            }

        }
        //#################################END TEXTBOX txtSearch EVENTS########################################

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure disables the scholarship information button
        public void DisableScholarshipButton(Boolean isDisabled)
        {
            this.pbxScholarship.Enabled = !isDisabled;
        } //---------------------------------------

        //this procedure checks all the list in the checkbox
        private void SetAllListAsChecked(CheckedListBox cbxBase, Label lblBase, Boolean isChecked)
        {
            for (Int32 i = 0; i < cbxBase.Items.Count; i++)
            {
                cbxBase.SetItemChecked(i, isChecked);
            }

            lblBase.Text = cbxBase.CheckedItems.Count.ToString();

        } //-----------------------------

        #endregion
    }
}
