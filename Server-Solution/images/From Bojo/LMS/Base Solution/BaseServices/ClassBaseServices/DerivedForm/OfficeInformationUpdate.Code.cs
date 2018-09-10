using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace BaseServices
{
    partial class OfficeInformationUpdate
    {
        #region Class Data Member Decleration
        private CommonExchange.OfficeEmployer _tempOfficeEmployerInfo;
        #endregion

        #region Class Properties Declarations
        private Boolean _hasUpdated = false;
        public Boolean HasUpdated
        {
            get { return _hasUpdated; }
        }

        private Boolean _hasDeleted = false;
        public Boolean HasDeleted
        {
            get { return _hasDeleted; }
        }
        #endregion

        #region Class Constructors
        public OfficeInformationUpdate(CommonExchange.SysAccess userInfo, CommonExchange.OfficeEmployer officeEmployerInfo,
            BaseServicesLogic baseServicesManager)
            : base(userInfo, baseServicesManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _baseServicesManager = baseServicesManager;
            _officeEmployerInfo = officeEmployerInfo;
            _tempOfficeEmployerInfo = (CommonExchange.OfficeEmployer)officeEmployerInfo.Clone();

            this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
            this.btnDelete.Click += new EventHandler(btnDeleteClick);
        }
        #endregion

        #region Class Event Void Procedures
        //####################################################CLASS OfficeInformationUpdate EVENTS###############################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.txtName.Text = _officeEmployerInfo.OfficeEmployerName;
            this.txtAcronym.Text = _officeEmployerInfo.OfficeEmployerAcronym;
            this.txtAddress.Text = _officeEmployerInfo.OfficeEmployerAddress;
            this.txtPhoneNo.Text = _officeEmployerInfo.OfficeEmployerPhoneNos;
        }//-------------------------------

        //event is raised when the class is clossing
        private void ClassClossing(object sender, FormClosingEventArgs e)
        {
            if ((!_hasUpdated || !_hasDeleted) && !_officeEmployerInfo.Equals(_tempOfficeEmployerInfo))
            {
                String strMsg = "There has been changes made in the current office/employer information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//--------------------------
        //####################################################END CLASS OfficeInformationUpdate EVENTS###############################################

        //#####################################BUTTON btnClose EVENTS########################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//-----------------------------
        //#####################################END BUTTON btnClose EVENTS########################################

        //#####################################BUTTON btnUpdate EVENTS########################################
        //event is raised when the control is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to update the office/employer information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The office/employer information has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _officeEmployerInfo.ObjectState = DataRowState.Modified;

                        _baseServicesManager.UpdateOfficeEmployerInformation(_userInfo, _officeEmployerInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdated = _hasDeleted = true;

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    ProcStatic.ShowErrorDialog(ex.Message, "Error Updating");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        }//-------------------------
        //#####################################END BUTTON btnUpdate EVENTS########################################

        //#####################################BUTTON btnDelete EVENTS########################################
        //event is raised when the control is clicked
        private void btnDeleteClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to delete the office/employer information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The office/employer information has been successfully deleted.";

                        this.Cursor = Cursors.WaitCursor;

                        _officeEmployerInfo.ObjectState = DataRowState.Deleted;

                        _baseServicesManager.DeleteOfficeEmployerInformation(_userInfo, _officeEmployerInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdated = _hasDeleted = true;

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    ProcStatic.ShowErrorDialog(ex.Message, "Error Deleting");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::BaseServices.Properties.Resources.lmspersonreferenceviewupdate1;
            // 
            // OfficeInformationUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(498, 283);
            this.Name = "OfficeInformationUpdate";
            this.ResumeLayout(false);

        }//----------------------
        //#####################################END BUTTON btnDelete EVENTS########################################
        #endregion
    }
}
