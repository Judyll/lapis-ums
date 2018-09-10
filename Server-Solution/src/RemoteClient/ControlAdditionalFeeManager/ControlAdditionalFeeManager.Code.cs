using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RemoteClient
{
    public delegate void ControlAdditionalFeeManagerModeOptionCheckedChanged(Boolean forApply);
    public delegate void ControlAdditionalFeeManagerCheckedListBoxSelectedIndexChanged();
    public delegate void ControlAdditionalFeeManagerSchoolYearSelectedIndexChanged();
    public delegate void ControlAdditionalFeeManagerSemesterSelectedIndexChanged();
    public delegate void ControlAdditionalFeeManagerResetQueryLinkClicked();
    public delegate void ControlAdditionalFeeManagerPressEnter(object sender, KeyEventArgs e);

    partial class ControlAdditionalFeeManager
    {
        #region Class Event Declarations
        public event ControlAdditionalFeeManagerModeOptionCheckedChanged OnModeOptionCheckedChanged;
        public event ControlAdditionalFeeManagerCheckedListBoxSelectedIndexChanged OnCourseSelectedIndexChanged;
        public event ControlAdditionalFeeManagerCheckedListBoxSelectedIndexChanged OnYearLevelSelectedIndexChanged;
        public event ControlAdditionalFeeManagerSchoolYearSelectedIndexChanged OnSchoolYearSelectedIndexChanged;
        public event ControlAdditionalFeeManagerSemesterSelectedIndexChanged OnSemesterSelectedIndexChanged;
        public event ControlAdditionalFeeManagerResetQueryLinkClicked OnResetLinkClicked;
        public event ControlAdditionalFeeManagerPressEnter OnPressEnter;
        #endregion

        #region Class Properties Declarations
        public Boolean IsForApply
        {
            get { return this.optApply.Checked; }
            set { this.optApply.Checked = value; }
        }

        public CheckedListBox CourseCheckedListBox
        {
            get { return this.cbxCourse; }
            set { this.lblCourseCount.Text = 0.ToString(); this.cbxCourse = value; }
        }

        public CheckedListBox YearLevelCheckedListBox
        {
            get { return this.cbxYearLevel; }
            set { this.lblYearCount.Text = 0.ToString(); this.cbxYearLevel = value; }
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

        #region Class Contructor
        public ControlAdditionalFeeManager()
        {
            this.InitializeComponent();

            this.optApply.CheckedChanged += new EventHandler(optionButtonCheckedChanged);
            this.cboYear.SelectedIndexChanged += new EventHandler(cboYearSelectedIndexChanged);
            this.cboSemester.SelectedIndexChanged += new EventHandler(cboSemesterSelectedIndexChanged);
            this.cbxCourse.SelectedIndexChanged += new EventHandler(cbxCourseSelectedIndexChanged);
            this.lnkCourseNone.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkCourseNoneLinkClicked);
            this.cbxYearLevel.SelectedIndexChanged += new EventHandler(cbxYearLevelSelectedIndexChanged);
            this.lnkYearNone.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkYearNoneLinkClicked);
            this.lnkResetQuery.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkResetQueryLinkClicked);
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

        //#######################################OPTION BUTTONS EVENTS######################################################
        //event is raised when the check is changed
        private void optionButtonCheckedChanged(object sender, EventArgs e)
        {
            ControlAdditionalFeeManagerModeOptionCheckedChanged ev = OnModeOptionCheckedChanged;

            if (ev != null)
            {
                OnModeOptionCheckedChanged(optApply.Checked);
            }

            this.txtSearch.Clear();
            this.txtSearch.Focus();

        } //------------------------------------
        //#####################################END OPTION BUTTONS EVENTS####################################################

        //##########################################COMBOBOX cboYear EVENTS###############################################
        //event is raised when the selected index is changed
        private void cboYearSelectedIndexChanged(object sender, EventArgs e)
        {
            ControlAdditionalFeeManagerSchoolYearSelectedIndexChanged ev = OnSchoolYearSelectedIndexChanged;

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
            ControlAdditionalFeeManagerSemesterSelectedIndexChanged ev = OnSemesterSelectedIndexChanged;

            if (ev != null)
            {
                OnSemesterSelectedIndexChanged();
            }

            this.txtSearch.Focus();
        } //------------------------------------------
        //###########################################END COMBOBOX cboSemester EVENTS#######################################

        //###################################CHECKEDLISTBOX cbxCourse EVENTS############################################
        //event is raised when the selected index is changed
        private void cbxCourseSelectedIndexChanged(object sender, EventArgs e)
        {
            ControlAdditionalFeeManagerCheckedListBoxSelectedIndexChanged ev = OnCourseSelectedIndexChanged;

            if (ev != null)
            {
                OnCourseSelectedIndexChanged();
            }

            this.txtSearch.Focus();

            this.lblCourseCount.Text = cbxCourse.CheckedItems.Count.ToString();

        } //-----------------------------------
        //#################################END CHECKEDLISTBOX cbxCourse EVENTS##########################################

        //#########################################LINKBUTTON lnkCourseNone EVENTS###########################################################
        //event is raised when the link is clicked
        private void lnkCourseNoneLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SetAllListAsChecked(cbxCourse, lblCourseCount, false);

            ControlAdditionalFeeManagerCheckedListBoxSelectedIndexChanged ev = OnCourseSelectedIndexChanged;

            if (ev != null)
            {
                OnCourseSelectedIndexChanged();
            }

            this.txtSearch.Focus();

        } //-----------------------------
        //########################################END LINKBUTTON lnkCourseNone EVENTS########################################################### 

        //###########################################CHECKEDLISTBOX cbxYearLevel EVENTS#########################################################
        //event is raised when the selected index is changed
        private void cbxYearLevelSelectedIndexChanged(object sender, EventArgs e)
        {
            ControlAdditionalFeeManagerCheckedListBoxSelectedIndexChanged ev = OnYearLevelSelectedIndexChanged;

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

            ControlAdditionalFeeManagerCheckedListBoxSelectedIndexChanged ev = OnYearLevelSelectedIndexChanged;

            if (ev != null)
            {
                OnYearLevelSelectedIndexChanged();
            }

            this.txtSearch.Focus();
        } //----------------------------------------------
        //#########################################END LINKBUTTON lnkYearNone EVENTS#############################################################

        //##########################################LINKBUTTON lnkResetQuery EVENTS############################################################
        //event is raised when the link is clicked
        private void lnkResetQueryLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.lblCourseCount.Text = this.lblYearCount.Text = 0.ToString();

            this.txtSearch.Clear();
            this.txtSearch.Focus();

            ControlAdditionalFeeManagerResetQueryLinkClicked ev = OnResetLinkClicked;

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
                ControlAdditionalFeeManagerPressEnter ev = OnPressEnter;

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
