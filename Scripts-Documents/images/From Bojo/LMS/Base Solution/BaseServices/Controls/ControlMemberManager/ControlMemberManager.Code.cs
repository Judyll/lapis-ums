using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace BaseServices.Controls
{
    public delegate void ControlMemberManagerCheckedListBoxSelectedIndexChanged();

    partial class ControlMemberManager
    {

        #region Class Event Declarations
        public event ControlMemberManagerCheckedListBoxSelectedIndexChanged OnOfficeEmployerSelectedIndexChanged;
        public event ControlMemberManagerCheckedListBoxSelectedIndexChanged OnMemberClassificationSelectedIndexChanged;
        public event ControlMemberManagerCheckedListBoxSelectedIndexChanged OnMemberTypeSelectedIndexChanged;  
        #endregion

        #region Class Properties Declarations
        public CheckedListBox OfficeEmployerCheckedListBox
        {
            get { return this.cbxOfficeEmployer; }
            set { this.lblOfficeCount.Text = 0.ToString(); this.cbxOfficeEmployer = value; }
        }

        public CheckedListBox MemberClassificationCheckedListBox
        {
            get { return this.cbxMemberClassification; }
            set { this.lblMemberClassificationCount.Text = 0.ToString(); this.cbxMemberClassification = value; }
        }

        public CheckedListBox MemberTypeCheckedListBox
        {
            get { return this.cbxMemberType; }
            set { this.lblMemberTypeCount.Text = 0.ToString(); this.cbxMemberType = value; }
        }

        public RadioButton ActiveRadioButton
        {
            get { return this.rdbActive; }
        }
        #endregion

        #region Class Constructors
        public ControlMemberManager()
        {
            this.InitializeComponent();

            this.cbxOfficeEmployer.SelectedIndexChanged += new EventHandler(cbxOfficeEmployerSelectedIndexChanged);
            this.lnkOfficeEmployer.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkOfficeEmployerLinkClicked);
            this.cbxMemberClassification.SelectedIndexChanged += new EventHandler(cbxMemberClassificationSelectedIndexChanged);
            this.lnkMemberClassificationSelectNone.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkMemberClassificationSelectNoneLinkClicked);
            this.cbxMemberType.SelectedIndexChanged += new EventHandler(cbxMemberTypeSelectedIndexChanged);
            this.lnkMemberTypeSelectNone.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkMemberTypeSelectNoneLinkClicked);
            this.chkIncludeMemberStatus.CheckedChanged += new EventHandler(chkIncludeMemberStatusCheckedChanged);
            this.rdbActive.CheckedChanged += new EventHandler(rdbActiveInActiveCheckedChanged);
            this.rdbInActive.CheckedChanged += new EventHandler(rdbActiveInActiveCheckedChanged);
        }
        #endregion

        #region Class Event Void Procedures
        //################################CLASS ControlManager EVENTS########################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            base.ClassLoad(sender, e);

            _maxHeight = this.Size.Height;
        }//------------------------
        //################################END CLASS ControlManager EVENTS#####################################

        //###################################CHECKEDLISTBOX cbxOfficeEmployer EVENTS############################################
        //event is raised when the selected index is changed
        private void cbxOfficeEmployerSelectedIndexChanged(object sender, EventArgs e)
        {
            ControlMemberManagerCheckedListBoxSelectedIndexChanged ev = OnOfficeEmployerSelectedIndexChanged;

            if (ev != null)
            {
                OnOfficeEmployerSelectedIndexChanged();
            }

            this.txtSearch.Focus();

            this.lblOfficeCount.Text = this.cbxOfficeEmployer.CheckedItems.Count.ToString();
        }//---------------------------
        //###################################END CHECKEDLISTBOX cbxOfficeEmployer EVENTS############################################

        //#########################################LINKBUTTON lnkOfficeEmployer EVENTS###########################################################
        //event is raised when the link is clicked
        private void lnkOfficeEmployerLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SetAllListAsChecked(this.cbxOfficeEmployer, this.lblOfficeCount, false);

            ControlMemberManagerCheckedListBoxSelectedIndexChanged ev = OnOfficeEmployerSelectedIndexChanged;

            if (ev != null)
            {
                OnOfficeEmployerSelectedIndexChanged();
            }

            this.txtSearch.Focus();
        }//-------------------------------
        //#########################################END LINKBUTTON lnkOfficeEmployer EVENTS###########################################################

        //###################################CHECKEDLISTBOX cbxMemberClassification EVENTS############################################
        //event is raised when the selected index is changed
        private void cbxMemberClassificationSelectedIndexChanged(object sender, EventArgs e)
        {
            ControlMemberManagerCheckedListBoxSelectedIndexChanged ev = OnMemberClassificationSelectedIndexChanged;

            if (ev != null)
            {
                OnMemberClassificationSelectedIndexChanged();
            }

            this.txtSearch.Focus();

            this.lblMemberClassificationCount.Text = this.cbxMemberClassification.CheckedItems.Count.ToString();
        }//-----------------------------
        //###################################END CHECKEDLISTBOX cbxMemberClassification EVENTS############################################

        //#########################################LINKBUTTON lnkMemberClassificationSelectNone EVENTS#################################################
        //event is raised when the link is clicked
        private void lnkMemberClassificationSelectNoneLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SetAllListAsChecked(this.cbxMemberClassification, this.lblMemberClassificationCount, false);

            ControlMemberManagerCheckedListBoxSelectedIndexChanged ev = OnMemberClassificationSelectedIndexChanged;

            if (ev != null)
            {
                OnMemberClassificationSelectedIndexChanged();
            }

            this.txtSearch.Focus();
        }//-----------------------
        //#########################################END LINKBUTTON lnkMemberClassificationSelectNone EVENTS#################################################

        //###################################CHECKEDLISTBOX cbxMemberType EVENTS############################################
        //event is raised when the selected index is changed
        private void cbxMemberTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            ControlMemberManagerCheckedListBoxSelectedIndexChanged ev = OnMemberTypeSelectedIndexChanged;

            if (ev != null)
            {
                OnMemberTypeSelectedIndexChanged();
            }

            this.txtSearch.Focus();

            this.lblMemberTypeCount.Text = this.cbxMemberType.CheckedItems.Count.ToString();
        }//-------------------------
        //###################################END CHECKEDLISTBOX cbxMemberType EVENTS############################################

        //#########################################LINKBUTTON lnkMemberTypeSelectNone EVENTS#################################################
        //event is raised when the link is clicked
        private void lnkMemberTypeSelectNoneLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SetAllListAsChecked(this.cbxMemberType, this.lblMemberTypeCount, false);

            ControlMemberManagerCheckedListBoxSelectedIndexChanged ev = OnMemberTypeSelectedIndexChanged;

            if (ev != null)
            {
                OnMemberTypeSelectedIndexChanged();
            }

            this.txtSearch.Focus();

        }//-------------------------
        //#########################################END LINKBUTTON lnkMemberTypeSelectNone EVENTS#################################################

        //#########################################CHECKEDBOX chkIncludeMemberStatus EVENTS###########################################################
        //event is raised when the link is clicked
        private void chkIncludeMemberStatusCheckedChanged(object sender, EventArgs e)
        {
            if (this.chkIncludeMemberStatus.Checked)
            {
                this.gbxMemberStatus.Enabled = true;

                this.rdbActive.Checked = true;
            }
            else
            {
                this.gbxMemberStatus.Enabled = false;

                this.rdbActive.Checked = this.rdbInActive.Checked = false;
            }

            this.txtSearch.Focus();
        }//-------------------------------
        //#########################################END CHECKEDBOX chkIncludeMemberStatus EVENTS###########################################################

        //#########################################RADIOBUTTON rdbActive, rdbInActive EVENTS###########################################################
        //event is raised when the link is clicked
        private void rdbActiveInActiveCheckedChanged(object sender, EventArgs e)
        {
            this.txtSearch.Focus();
        }//-------------------------
        //#########################################END RADIOBUTTON rdbActive, rdbInActive EVENTS###########################################################
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

        #region Programmer-Defined Function
        //this fucntion will determine if include active or inactive query
        public Boolean IsIncludeActiveInActive()
        {
            return this.rdbActive.Checked ? true : false;
        }//--------------------------
        #endregion
    }
}
