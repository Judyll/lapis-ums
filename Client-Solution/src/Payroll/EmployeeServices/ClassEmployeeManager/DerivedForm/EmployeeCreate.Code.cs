using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace EmployeeServices
{
    partial class EmployeeCreate
    {
        #region Class Data Member Declaration
        private Boolean hasEnter = false;
        #endregion

        #region Class Properties Declaration
        private Boolean _hasCreated = false;
        public Boolean HasCreated
        {
            get { return _hasCreated; }
        }    
        #endregion

        #region Class Constructors
        public EmployeeCreate(CommonExchange.SysAccess userInfo, EmployeeLogic empManager)
            : base(userInfo, empManager)
        {
            this.InitializeComponent();

            _errProvider = new ErrorProvider();

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnCreate.Click += new EventHandler(btnCreateClick);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
        }
        #endregion        

        #region Class Event Void Procedures

        //##################################CLASS EmployeeCreate EVENTS########################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            base.ClassLoad(sender, e);

            if (!hasEnter)
            {
                //instantiate a new employee information
                _empInfo = new CommonExchange.Employee();
                //---------------------                            

                _empInfo.ObjectState = DataRowState.Added;   

                this.InitializeControls();

                _baseServiceManager.InitializePersonRelationshipDataGridView(this.dgvRelationship, _personInfo.PersonRelationshipList, lblEmerStatus);

                RemoteClient.ProcStatic.SetDataGridViewColumns(this.dgvRelationship, false);

                hasEnter = true;
            }

            this.gbxFirstPart.Enabled = this.gbxSecondPart.Enabled = this.gbxRestDay.Enabled = false;
         
        }//---------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isForEmployeeUpdate)
            {
                if (!_hasCreated)
                {
                    String strMsg = "Are you sure you want to cancel the creation of a new employee?";
                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
        } //----------------------------------
        //###############################END CLASS EmployeeCreate EVENTS########################################

        //######################################COMBOBOX cboStatus EVENTS##########################################################
        //event is raised when the selected index is changed
        protected override void cboStatusSelectedIndexChanged(object sender, EventArgs e)
        {
            base.cboStatusSelectedIndexChanged(sender, e);

            if ((cboStatus.SelectedIndex + 1) != (Int32)CommonExchange.EmploymentStatusNo.LayOff)
            {
                btnCreate.Enabled = true;
            }
            else
            {
                btnCreate.Enabled = false;
            }

        } //---------------------------
        //######################################END COMBOBOX cboStatus EVENTS######################################################

        //#########################################LINLLABEL lnkVerified EVENTS###########################################################
        //event is raised when the control is clicked
        protected override void lnkVerifyLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {         
            base.lnkVerifyLinkClicked(sender, e);
  
            if (_empInfo != null && !String.IsNullOrEmpty(_empInfo.EmployeeSysId))
            {
                _isForEmployeeUpdate = true;

                this.Close();
            }
            else
            {
                base.SetPersonInformationControls(true);
            }

            this.btnCreate.Enabled = true;            
        }//------------------------
        //#########################################END LINLLABEL lnkVerified EVENTS###########################################################

        //#########################################LINLLABEL lnkPersonArchive EVENTS###########################################################
        //event is raised when the control is clicked
        protected override void lnkPersonArchiveLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            base.lnkPersonArchiveLinkClicked(sender, e);

            if (_empInfo != null && !String.IsNullOrEmpty(_empInfo.EmployeeSysId))
            {
                _isForEmployeeUpdate = true;

                this.Close();
            }
            else
            {
                if (base.HasSelectedForPersonUpdate)
                {
                    if (this.pbxPerson.Image != null)
                    {
                        this.pbxPerson.Image.Dispose();
                        this.pbxPerson.Image = null;
                    }

                    GC.SuppressFinalize(this);
                    GC.Collect();

                    _personInfo = _baseServiceManager.GetPersonDetails(_userInfo,
                                 _baseServiceManager.GetPersonSysId(_rowIndexForPersonSearch), Application.StartupPath);

                    base.AssingControlsValue();
                    base.SetPersonInformationControls(true);

                    this.btnCreate.Enabled = true;
                }
            }            
        }//-------------------------
        //#########################################END LINLLABEL lnkPersonArchive EVENTS###########################################################

        //#########################################TEXTBOX txtName EVENTS###########################################################
        //event is raised when the control is clicked
        protected override void TextBoxKeyPressLettersOnly(object sender, KeyPressEventArgs e)
        {
            this.btnCreate.Enabled = false;
        }//------------------------
        //#########################################END TEXTBOX txtName EVENTS###########################################################

        //###########################################BUTTON btnCancel EVENTS########################################################
        //event is raised when the button is clicked
        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }//----------------------------
        //############################################END BUTTON btnCancel EVENTS####################################################

        //###########################################BUTTON btnCreate EVENTS########################################################
        //event is raised when the button is clicked
        private void btnCreateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls() && this.ValidateControlsEmployee())
            {
                try
                {
                    String strMsg = "Are you sure you want to create the employee?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Create", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The employee has been successfully created.";

                        _personInfo.ObjectState = DataRowState.Added;
                        _empInfo.PersonInfo = _personInfo;

                        _empInfo.ObjectState = DataRowState.Added;

                        if (String.IsNullOrEmpty(_empInfo.SalaryInfo.FirstIn) && String.IsNullOrEmpty(_empInfo.SalaryInfo.FirstOut) &&
                            String.IsNullOrEmpty(_empInfo.SalaryInfo.SecondIn) && String.IsNullOrEmpty(_empInfo.SalaryInfo.SecondOut))
                        {
                            _empInfo.SalaryInfo.SecondOut = tmeSecondOut.SelectedTime.ToShortTimeString();
                            _empInfo.SalaryInfo.SecondIn = tmeSecondIn.SelectedTime.ToShortTimeString();
                            _empInfo.SalaryInfo.FirstOut = tmeFirstOut.SelectedTime.ToShortTimeString();
                            _empInfo.SalaryInfo.FirstIn = tmeFirstIn.SelectedTime.ToShortTimeString();
                        }

                        _empManager.InsertEmployeeInformation(_userInfo, _empInfo);

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasCreated = true;

                        this.Close();
                    }
                    else if (msgResult == DialogResult.Cancel)
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Creating");
                }

            }
        }//-----------------------------
        //#########################################END BUTTON btnCreate EVENTS######################################################
        #endregion
    }
}
