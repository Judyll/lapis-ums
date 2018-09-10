using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RemoteClient
{
    public delegate void ControlMajorExamScheduleManagerCheckedListBoxSelectedIndexChanged();
    public delegate void ControlMajorExamScheduleManagerSchoolYearSelectedIndexChanged();
    public delegate void ControlMajorExamScheduleManagerSemesterSelectedIndexChanged();
    public delegate void ControlMajorExamScheduleManagerResetQueryLinkClicked();

    partial class ControlMajorExamScheduleManager
    {
        #region Class Event Declarations
        public event ControlMajorExamScheduleManagerCheckedListBoxSelectedIndexChanged OnCourseGroupSelectedIndexChanged;
        public event ControlMajorExamScheduleManagerCheckedListBoxSelectedIndexChanged OnExamSelectedIndexChanged;
        public event ControlMajorExamScheduleManagerSchoolYearSelectedIndexChanged OnSchoolYearSelectedIndexChanged;
        public event ControlMajorExamScheduleManagerSemesterSelectedIndexChanged OnSemesterSelectedIndexChanged;
        public event ControlMajorExamScheduleManagerResetQueryLinkClicked OnResetLinkClicked;
        #endregion

        #region Class Properties Declarations
        public CheckedListBox CourseGroupCheckedListBox
        {
            get { return this.cbxCourseGroup; }
            set { this.lblCourseGroupCount.Text = 0.ToString(); this.cbxCourseGroup = value; }
        }

        public CheckedListBox ExamCheckedListBox
        {
            get { return this.cbxExam; }
            set { this.lblExamCount.Text = 0.ToString(); this.cbxExam = value; }
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
        public ControlMajorExamScheduleManager()
        {
            this.InitializeComponent();

            this.cboYear.SelectedIndexChanged += new EventHandler(cboYearSelectedIndexChanged);
            this.cboSemester.SelectedIndexChanged += new EventHandler(cboSemesterSelectedIndexChanged);
            this.cbxCourseGroup.SelectedIndexChanged += new EventHandler(cbxCourseGroupSelectedIndexChanged);
            this.lnkCourseGroupNone.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkCourseGroupNoneLinkClicked);
            this.cbxExam.SelectedIndexChanged += new EventHandler(cbxExamSelectedIndexChanged);
            this.lnkExamNone.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkExamNoneLinkClicked);
            this.lnkResetQuery.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkResetQueryLinkClicked);
        }
        
        #endregion

        #region Class Event Void Procedures

        //#####################################CLASS ControlMajorExamScheduleManager EVENTS#######################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            base.ClassLoad(sender, e);

            _maxHeight = this.Size.Height;

            this.pbxFind.Visible = this.txtSearch.Visible = false;

        } //----------------------------
        //####################################END CLASS ControlMajorExamScheduleManager EVENTS####################################

        //##########################################COMBOBOX cboYear EVENTS###############################################
        //event is raised when the selected index is changed
        private void cboYearSelectedIndexChanged(object sender, EventArgs e)
        {
            ControlMajorExamScheduleManagerSchoolYearSelectedIndexChanged ev = OnSchoolYearSelectedIndexChanged;

            if (ev != null)
            {
                OnSchoolYearSelectedIndexChanged();
            }

        } //------------------------------------
        //######################################END COMBOBOX cboYear EVENTS################################################

        //############################################COMBOBOX cboSemester EVENTS##########################################
        //event is raised when the selected index is changed
        private void cboSemesterSelectedIndexChanged(object sender, EventArgs e)
        {
            ControlMajorExamScheduleManagerSemesterSelectedIndexChanged ev = OnSemesterSelectedIndexChanged;

            if (ev != null)
            {
                OnSemesterSelectedIndexChanged();
            }
        } //------------------------------------------
        //###########################################END COMBOBOX cboSemester EVENTS#######################################

        //###################################CHECKEDLISTBOX cbxCourseGroup EVENTS############################################
        //event is raised when the selected index is changed
        private void cbxCourseGroupSelectedIndexChanged(object sender, EventArgs e)
        {
            ControlMajorExamScheduleManagerCheckedListBoxSelectedIndexChanged ev = OnCourseGroupSelectedIndexChanged;

            if (ev != null)
            {
                OnCourseGroupSelectedIndexChanged();
            }

            this.lblCourseGroupCount.Text = cbxCourseGroup.CheckedItems.Count.ToString();

        } //-----------------------------------
        //#################################END CHECKEDLISTBOX cbxCourseGroup EVENTS##########################################

        //#########################################LINKBUTTON lnkCourseGroupNone EVENTS###########################################################
        //event is raised when the link is clicked
        private void lnkCourseGroupNoneLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SetAllListAsChecked(cbxCourseGroup, lblCourseGroupCount, false);

            ControlMajorExamScheduleManagerCheckedListBoxSelectedIndexChanged ev = OnCourseGroupSelectedIndexChanged;

            if (ev != null)
            {
                OnCourseGroupSelectedIndexChanged();
            }

        } //-----------------------------
        //########################################END LINKBUTTON lnkCourseGroupNone EVENTS########################################################### 

        //###########################################CHECKEDLISTBOX cbxExam EVENTS#########################################################
        //event is raised when the selected index is changed
        private void cbxExamSelectedIndexChanged(object sender, EventArgs e)
        {
            ControlMajorExamScheduleManagerCheckedListBoxSelectedIndexChanged ev = OnExamSelectedIndexChanged;

            if (ev != null)
            {
                OnExamSelectedIndexChanged();
            }

            this.lblExamCount.Text = cbxExam.CheckedItems.Count.ToString();
        } //-----------------------------------------     
        //########################################END CHECKEDLISTBOX cbxYearLevel EVENTS#########################################################

        //###########################################LINKBUTTON lnkExamNone EVENTS###############################################################
        //event is raised when the link is clicked
        private void lnkExamNoneLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SetAllListAsChecked(cbxExam, lblExamCount, false);

            ControlMajorExamScheduleManagerCheckedListBoxSelectedIndexChanged ev = OnExamSelectedIndexChanged;

            if (ev != null)
            {
                OnExamSelectedIndexChanged();
            }
        } //----------------------------------------------
        //#########################################END LINKBUTTON lnkExamNone EVENTS#############################################################

        //##########################################LINKBUTTON lnkResetQuery EVENTS############################################################
        //event is raised when the link is clicked
        private void lnkResetQueryLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.lblCourseGroupCount.Text = this.lblExamCount.Text = 0.ToString();

            this.cboYear.Focus();

            ControlMajorExamScheduleManagerResetQueryLinkClicked ev = OnResetLinkClicked;

            if (ev != null)
            {
                OnResetLinkClicked();
            }
        } //------------------------------------------          

        //########################################END LINKBUTTON lnkResetQuery EVENTS##########################################################

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
