using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MemberServices
{
    partial class MemberManager
    {
        #region Class Data Member Decleration
        private CommonExchange.SysAccess _userInfo;
        private MemberLogic _memberManager;

        private MemberSearchList _frmMemberSearch;
        #endregion

        #region Class Constructors
        public MemberManager(CommonExchange.SysAccess userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;

            this.Load += new EventHandler(ClassLoad);
            this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.ctlManager.OnClose += new BaseServices.Control.ClickEvent(ctlManagerOnClose);
            this.ctlManager.OnRefresh += new BaseServices.Control.ClickEvent(ctlManagerOnRefresh);
            this.ctlManager.OnTextBoxKeyUp += new BaseServices.Control.KeyEventHandler(ctlManagerOnTextBoxKeyUp);
            this.ctlManager.OnPressEnter += new BaseServices.Control.KeyPressEnter(ctlManagerOnPressEnter);
            this.ctlManager.OnOfficeEmployerSelectedIndexChanged += 
                new BaseServices.Controls.ControlMemberManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnOfficeEmployerSelectedIndexChanged);
            this.ctlManager.OnMemberClassificationSelectedIndexChanged += 
                new BaseServices.Controls.ControlMemberManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnMemberClassificationSelectedIndexChanged);
            this.ctlManager.OnMemberTypeSelectedIndexChanged += 
                new BaseServices.Controls.ControlMemberManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnMemberTypeSelectedIndexChanged);
        }

        #endregion

        #region Class Event Void Procedures
        //###########################################CLASS MemberManager EVENTS#####################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _memberManager = new MemberLogic(_userInfo);

            _frmMemberSearch = new MemberSearchList();
            _frmMemberSearch.OnCreate += new MemberSearchListLinkCreateClick(_frmMemberSearchOnCreate);
            _frmMemberSearch.OnDoubleClickEnter += new BaseServices.SearchListDataGridDoubleClickEnter(_frmMemberSearchOnDoubleClickEnter);
            _frmMemberSearch.LocationPoint = new Point(14, 300);
            _frmMemberSearch.AdoptGridSize = false;
            _frmMemberSearch.MdiParent = this;

            lblRecordDate.Text = "Record Date: " + DateTime.Parse(_memberManager.ServerDateTime).ToString();

            _memberManager.InitializeOfficeEmployerCheckedListBox(this.ctlManager.OfficeEmployerCheckedListBox);
            _memberManager.InitializeMemberClassificationCheckedListBox(this.ctlManager.MemberClassificationCheckedListBox);
            _memberManager.InitializeMemberTypeCheckedListBox(this.ctlManager.MemberTypeCheckedListBox);

            this.ctlManager.Select();
            this.ctlManager.SetFocusOnSearchTextBox();
        }//--------------------------

        //events is raised when the class is clossing
        private void ClassClossing(object sender, FormClosingEventArgs e)
        {
            _memberManager.DeleteDirectory(Application.StartupPath + @"\AppDocuments");
        }//---------------------------
        //###########################################END CLASS MemberManager EVENTS#####################################################

        //##########################################CLASS MemberSearchList EVENTS#######################################################
        //event is raised when the create button is clicked
        private void _frmMemberSearchOnCreate()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (MemberInformationCreate frmCreate = new MemberInformationCreate(_userInfo, _memberManager))
                {
                    _frmMemberSearch.WindowState = FormWindowState.Minimized;

                    frmCreate.ShowDialog(this);

                    if (frmCreate.HasCreated)
                    {
                        this.ShowSearchResultDialog(false);
                    }

                    _frmMemberSearch.WindowState = FormWindowState.Normal;
                }
            }
            catch (Exception ex)
            {
                BaseServices.ProcStatic.ShowErrorDialog(ex.Message, "Error Creating A Member Information");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//--------------------------

        //event is raised when the dgvList control is double clicked
        private void _frmMemberSearchOnDoubleClickEnter(String id)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (MemberInformationUpdate frmUpdate = new MemberInformationUpdate(_userInfo, _memberManager,
                    _memberManager.GetMemberInformationDetailsByMemberId(_userInfo,id), _memberManager))
                {
                    _frmMemberSearch.WindowState = FormWindowState.Minimized;

                    frmUpdate.ShowDialog(this);

                    if (frmUpdate.HasUpDated)
                    {
                        this.ShowSearchResultDialog(false);
                    }

                    _frmMemberSearch.WindowState = FormWindowState.Normal;
                }
            }
            catch (Exception ex)
            {
                BaseServices.ProcStatic.ShowErrorDialog(ex.Message, "Error Updating A Member Information");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//---------------------------------
        //##########################################END CLASS MemberSearchList EVENTS#######################################################

        //############################################CONTROL ctlManager EVENTS##########################################
        //event is raised when the button is click
        private void ctlManagerOnRefresh(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _memberManager.ReferesData(_userInfo);

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_memberManager.ServerDateTime).ToString();

                this.ShowSearchResultDialog(true);
            }
            catch (Exception ex)
            {
                BaseServices.ProcStatic.ShowErrorDialog(ex.Message, "Error Refreshing Student's Data Manager");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//---------------------------

        //event is raised when the refresh button is clicked
        private void ctlManagerOnClose(object sender, EventArgs e)
        {
            this.Close();
        }//--------------------------

        //event is raised when the key is up
        private void ctlManagerOnTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                _frmMemberSearch.SelectFirstRowInDataGridView();
            }
            else if (string.IsNullOrEmpty(BaseServices.ProcStatic.TrimStartEndString(ctlManager.GetSearchString)))
            {
                _frmMemberSearch.WindowState = FormWindowState.Minimized;

                this.ctlManager.SetFocusOnSearchTextBox();
            }
        }//---------------------------

        //event is raised when the enter key is pressed
        private void ctlManagerOnPressEnter()
        {
            this.ShowSearchResultDialog(true);
        }//-----------------------------

        //event is raised when the selected index is changed Office Employer CheckedlistBox
        private void ctlManagerOnOfficeEmployerSelectedIndexChanged()
        {
            this.ShowSearchResultDialog(true);
        }//----------------------

        //event is raised when the selected index is changed Member Classification CheckedlistBox
        private void ctlManagerOnMemberClassificationSelectedIndexChanged()
        {
            this.ShowSearchResultDialog(true);
        }//-------------------------

        //event is raised when the selected index is changed Member Type CheckedlistBox
        private void ctlManagerOnMemberTypeSelectedIndexChanged()
        {
            this.ShowSearchResultDialog(true);
        }//-------------------------
        //############################################END CONTROL ctlManager EVENTS##########################################
        #endregion

        #region Programer-Define Void Procedures
        //this procedure shows the search result
        private void ShowSearchResultDialog(Boolean isNewQuery)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string queryString = BaseServices.ProcStatic.TrimStartEndString(ctlManager.GetSearchString);

                if (!String.IsNullOrEmpty(queryString))
                {
                    _frmMemberSearch.DataSource = _memberManager.GetSearchedMemberInformationTable(_userInfo, queryString,
                        _memberManager.GetOfficeEmployerStringFormat(this.ctlManager.OfficeEmployerCheckedListBox, true, false, false),
                        _memberManager.GetOfficeEmployerStringFormat(this.ctlManager.MemberClassificationCheckedListBox, false, true, false), String.Empty,
                        _memberManager.GetOfficeEmployerStringFormat(this.ctlManager.MemberTypeCheckedListBox, false, false, true), 
                        this.ctlManager.IsIncludeActiveInActive(), this.ctlManager.ActiveRadioButton.Checked, isNewQuery);
                }
            }
            catch (Exception ex)
            {
                BaseServices.ProcStatic.ShowErrorDialog(ex.Message, "Error Retrieving Data");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }

        }//---------------------------------
        #endregion
    }
}
