using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RemoteClient
{
    public delegate void ControlStudentManagerCheckedListBoxSelectedIndexChanged();
    public delegate void ControlStudentManagerPressEnter(object sender, KeyEventArgs e);

    partial class ControlStudentManager
    {
        #region Class Event Declarations
        public event ControlStudentManagerCheckedListBoxSelectedIndexChanged OnSelectedIndexChanged;
        public event ControlStudentManagerPressEnter OnPressEnter;
        #endregion

        #region Class Properties Declarations
        public CheckedListBox CourseCheckedListBox
        {
            get { return this.cbxCourse; }
            set { cbxCourse = value; }
        }
        #endregion

        #region Class Constructor
        public ControlStudentManager()
        {
            this.InitializeComponent();

            this.cbxCourse.SelectedIndexChanged += new EventHandler(cbxCourseSelectedIndexChanged);
            this.lnkNone.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNoneLinkClicked);
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

        //###################################CHECKEDLISTBOX cbxCourse EVENTS############################################
        //event is raised when the selected index is changed
        private void cbxCourseSelectedIndexChanged(object sender, EventArgs e)
        {
            ControlStudentManagerCheckedListBoxSelectedIndexChanged ev = OnSelectedIndexChanged;

            if (ev != null)
            {
                OnSelectedIndexChanged();
            }

            this.txtSearch.Focus();

            this.lblSelected.Text = cbxCourse.CheckedItems.Count.ToString();
   
        } //-----------------------------------
        //#################################END CHECKEDLISTBOX cbxCourse EVENTS##########################################

        //#########################################LINKBUTTON lnkNone EVENTS###########################################################
        //event is raised when the link is clicked
        private void lnkNoneLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SetAllListAsChecked(cbxCourse, false);

            ControlStudentManagerCheckedListBoxSelectedIndexChanged ev = OnSelectedIndexChanged;

            if (ev != null)
            {
                OnSelectedIndexChanged();
            }

            this.txtSearch.Focus();

        } //-----------------------------
        //########################################END LINKBUTTON lnkNone EVENTS########################################################### 

        //###################################TEXTBOX txtSearch EVENTS##########################################
        //event is raised when the key is up
        protected override void txtSearchKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _strSearch = txtSearch.Text;

                ControlStudentManagerPressEnter ev = OnPressEnter;

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
        private void SetAllListAsChecked(CheckedListBox cbxBase, Boolean isChecked)
        {
            for (Int32 i = 0; i < cbxBase.Items.Count; i++)
            {
                cbxBase.SetItemChecked(i, isChecked);
            }

            this.lblSelected.Text = cbxBase.CheckedItems.Count.ToString();

        } //-----------------------------

        #endregion
    }
}
