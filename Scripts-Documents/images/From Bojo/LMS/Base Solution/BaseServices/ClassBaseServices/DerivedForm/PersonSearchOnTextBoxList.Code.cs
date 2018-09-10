using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BaseServices
{
    partial class PersonSearchOnTextBoxList
    {
        #region Class Data Memeber Declaration
        private CommonExchange.SysAccess _userInfo;
        private BaseServicesLogic _baseServiceManager;

        private String _personSysIdExcludeList;      
        #endregion

        #region Class Properties Decleration
        public Boolean CreatePersonVisible
        {
            set { this.lnkCreatePerson.Visible = value; }
        }

        private Boolean _hasRecorded = false;
        public Boolean HasRecorded
        {
            get { return _hasRecorded; }
        }

        private Boolean _usePersonInfo = false;
        public Boolean UsePersonInfo
        {
            get { return _usePersonInfo; }
        }

        private CommonExchange.Person _personInfo = new CommonExchange.Person();
        public CommonExchange.Person PersonInfo
        {
            get { return _personInfo; }
        }
        #endregion

        #region Class Constructor
        public PersonSearchOnTextBoxList(CommonExchange.SysAccess userInfo, BaseServicesLogic baseServiceManager, String personSysIdExcludeList)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _baseServiceManager = baseServiceManager;
            _personSysIdExcludeList = personSysIdExcludeList;

            this.pbxRefresh.Click += new EventHandler(pbxRefreshClick);
            this.lnkCreatePerson.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkCreatePersonLinkClicked);
            this.lnkUpdatePerson.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkUpdatePersonLinkClicked);
        }      
        #endregion

        #region Class Event Void Procedures
        //####################################CLASS PersonSearchOnTextBoxList EVENTS####################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.SetDataGridViewSource(_baseServiceManager.PersonTable);
            
            base.ClassLoad(sender, e);
        }//-------------------
        //####################################END CLASS PersonSearchOnTextBoxList EVENTS####################################

        //##################################DATAGRIDVIEW dgvList EVENTS##########################################################
        //event is raised when the selection is changed
        protected override void dgvListSelectionChanged(object sender, EventArgs e)
        {
            base.dgvListSelectionChanged(sender, e);

            this.lnkUpdatePerson.Enabled = !String.IsNullOrEmpty(this.PrimaryId) ? true : false;
        }//---------------------------

        //evet is raised when the control is double clicked
        protected override void dgvListDoubleClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.PrimaryId))
            {
                _usePersonInfo = true;

                _hasSelected = true;

                this.Close();
            }
        }//----------------------------
        //##################################END DATAGRIDVIEW dgvList EVENTS##########################################################

        //##################################TEXTBOX txtSearch EVENTS##########################################################
        //event is raised when the key is up
        protected override void txtSearchKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    this.SetDataGridViewSource(_baseServiceManager.GetSearchPersonInformation(_userInfo, ((TextBox)sender).Text, 
                        String.Empty, String.Empty, _personSysIdExcludeList, true));
                }
                catch (Exception ex)
                {
                    ProcStatic.ShowErrorDialog(ex.Message, "Error Retrieving Person Infomation List");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }

            base.txtSearchKeyUp(sender, e);
        }//-----------------------------------
        //##################################END TEXTBOX txtSearch EVENTS##########################################################

        //##################################PICTUREBOX pbxRefresh EVENTS######################################################
        //event is raised when the picture box is clicked
        private void pbxRefreshClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.SetDataGridViewSource(_baseServiceManager.PersonTable);

            this.txtSearch.Clear();

            this.Cursor = Cursors.Arrow;
        }//---------------------------------
        //##################################END PICTUREBOX pbxRefresh EVENTS######################################################

        //##################################LINKLABEL lnkCreatePerson EVENTS######################################################
        //event is raised when the  control is clicked
        private void lnkCreatePersonLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            Boolean openUpdateForm = false;

            using (PersonInformationCreate frmCreate = new PersonInformationCreate(_userInfo, _baseServiceManager))
            {
                frmCreate.PersonArchiveVisible = false;
                frmCreate.ShowDialog(this);

                if (frmCreate.HasRecorded)
                {
                    _hasRecorded = true;

                    _personInfo = frmCreate.PersonInfo;

                    this.SetDataGridViewSource(_baseServiceManager.GetSearchPersonInformation(_userInfo, this.txtSearch.Text,
                           String.Empty, String.Empty, _personSysIdExcludeList, true));
                }
                else if (frmCreate.IsForUpdatePerson)
                {
                    _personInfo = frmCreate.PersonInfo;

                    openUpdateForm = true;
                }
            }

            if (openUpdateForm)
            {
                using (PersonInformationUpdate frmUpdate = new PersonInformationUpdate(_userInfo, _personInfo, _baseServiceManager))
                {
                    frmUpdate.PersonArchiveVisible = false;
                    frmUpdate.ShowDialog(this);

                    if (frmUpdate.HasUpdated)
                    {
                        _personInfo = frmUpdate.PersonInfo;

                        this.SetDataGridViewSource(_baseServiceManager.GetSearchPersonInformation(_userInfo, this.txtSearch.Text,
                            String.Empty, String.Empty, _personSysIdExcludeList, true));
                    }
                }
            }

            this.Cursor = Cursors.Arrow;
        }//-------------------------
        //##################################END LINKLABEL lnkCreatePerson EVENTS######################################################

        //##################################LINKLABEL lnkUpdatePerson EVENTS######################################################
        //event is raised when the  control is clicked
        private void lnkUpdatePersonLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.PrimaryId))
            {
                using (PersonInformationUpdate frmUpdate = new PersonInformationUpdate(_userInfo,
                    _baseServiceManager.GetPersonDetails(_userInfo, this.PrimaryId), _baseServiceManager))
                {
                    frmUpdate.PersonArchiveVisible = false;
                    frmUpdate.ShowDialog(this);

                    if (frmUpdate.HasUpdated)
                    {
                        _personInfo = frmUpdate.PersonInfo;

                        this.SetDataGridViewSource(_baseServiceManager.GetSearchPersonInformation(_userInfo, this.txtSearch.Text,
                            String.Empty, String.Empty, _personSysIdExcludeList, true));
                    }
                }
            }
        }//------------------------------
        //##################################END LINKLABEL lnkUpdatePerson EVENTS######################################################
        #endregion
    }
}
