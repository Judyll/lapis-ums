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
        private Boolean _isForStudentVerificaion = false;
        private Boolean _isForNewUserVerification = false;

        private CommonExchange.Student _studentInfo;
        public CommonExchange.Student StudentInfo
        {
            get { return _studentInfo; }
        }

        private CommonExchange.Employee _empInfo;
        public CommonExchange.Employee EmployeeInfo
        {
            get { return _empInfo; }
        }

        private CommonExchange.SysAccess _newUserInfo;
        public CommonExchange.SysAccess NewUserInfo
        {
            get { return _newUserInfo; }
        }

        private PictureBox _pbxBase;
        #endregion

        #region Class Properties Declaration
        public Boolean CreatePersonVisible
        {
            set { this.lnkCreatePerson.Visible = value; }
        }

        private Boolean _hasRecorded = false;
        public Boolean HasRecorded
        {
            get { return _hasRecorded; }
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
        }  

        public PersonSearchOnTextBoxList(CommonExchange.SysAccess userInfo, BaseServicesLogic baseServiceManager, 
            Boolean isForStudentVerification, Boolean isForNewUserVerification, PictureBox pbxBase)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _baseServiceManager = baseServiceManager;

            _isForStudentVerificaion = isForStudentVerification;
            _isForNewUserVerification = isForNewUserVerification;
            _pbxBase = pbxBase;

            this.pbxRefresh.Click += new EventHandler(pbxRefreshClick);
            this.lnkCreatePerson.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkCreatePersonLinkClicked);
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
        //event is raised when the control is double clicked
        protected override void dgvListDoubleClick(object sender, EventArgs e)
        {
            if (_pbxBase != null && _pbxBase.Image != null)
            {
                _pbxBase.Image.Dispose();
                _pbxBase.Image = null;
            }

            GC.SuppressFinalize(this);
            GC.Collect();

            if (_isForStudentVerificaion && !_isForNewUserVerification)
            {
                _studentInfo = _baseServiceManager.SelectBySysIDPersonStudentInformation(_userInfo,
                    _baseServiceManager.GetPersonSysId(_rowIndex), Application.StartupPath);
            }
            else if (!_isForStudentVerificaion && _isForNewUserVerification)
            {
                _newUserInfo = _baseServiceManager.SelectBySysIDPersonSystemUserInfo(_userInfo,
                    _baseServiceManager.GetPersonSysId(_rowIndex), Application.StartupPath);
            }
            else
            {
                _empInfo = _baseServiceManager.SelectBySysIDPersonEmployeeInformation(_userInfo,
                    _baseServiceManager.GetPersonSysId(_rowIndex), Application.StartupPath);
            }

            base.dgvListDoubleClick(sender, e);
        }//---------------------

        //event is raised when the key is pressed
        protected override void dgvListKeyPress(object sender, KeyPressEventArgs e)
        {
            base.dgvListKeyPress(sender, e);

            if (_hasSelected)
            {
                if (_pbxBase != null && _pbxBase.Image != null)
                {
                    _pbxBase.Image.Dispose();
                    _pbxBase.Image = null;
                }

                GC.SuppressFinalize(this);
                GC.Collect();

                if (_isForStudentVerificaion && !_isForNewUserVerification)
                {
                    _studentInfo = _baseServiceManager.SelectBySysIDPersonStudentInformation(_userInfo,
                        _baseServiceManager.GetPersonSysId(_rowIndex), Application.StartupPath);
                }
                else if (!_isForStudentVerificaion && _isForNewUserVerification)
                {
                    _newUserInfo = _baseServiceManager.SelectBySysIDPersonSystemUserInfo(_userInfo,
                        _baseServiceManager.GetPersonSysId(_rowIndex), Application.StartupPath);
                }
                else
                {
                    _empInfo = _baseServiceManager.SelectBySysIDPersonEmployeeInformation(_userInfo,
                        _baseServiceManager.GetPersonSysId(_rowIndex), Application.StartupPath);
                }


                this.Close();
            }
        }//--------------------
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
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Retrieving Person Infomation List");
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
            using (PersonInformationCreate frmCreate = new PersonInformationCreate(_userInfo, _baseServiceManager))
            {
                frmCreate.PersonArchiveVisible = false;
                frmCreate.ShowDialog(this);

                if (frmCreate.HasRecorded)
                {
                    _hasRecorded = true;

                    _personInfo = frmCreate.PersonInfo;

                    this.Close();
                }
            }
        }//-------------------------
        //##################################END LINKLABEL lnkCreatePerson EVENTS######################################################
        #endregion
    }
}
