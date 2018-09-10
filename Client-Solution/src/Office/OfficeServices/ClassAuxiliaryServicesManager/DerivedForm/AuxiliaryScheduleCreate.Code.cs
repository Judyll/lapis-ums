using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class AuxiliaryScheduleCreate
    {
        #region Class Properties Declarations
        private Boolean _hasCreated = false;
        public Boolean HasCreated
        {
            get { return _hasCreated; }
        }
        #endregion

        #region Class Constructors
        public AuxiliaryScheduleCreate()
        {
            this.InitializeComponent();
        }

        public AuxiliaryScheduleCreate(CommonExchange.SysAccess userInfo, AuxiliaryServiceLogic auxiliaryManager)
            : base(userInfo, auxiliaryManager)
        {
            this.InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnCreate.Click += new EventHandler(btnCreateClick);
        }

        #endregion

        #region Class Event Void Procedures
        //################################################CLASS AuxiliaryScheduleCreate EVENTS#######################################################
        //event is raised when the class is closing
        private void ClassClossing(object sender, FormClosingEventArgs e)
        {
            if (!_hasCreated && !_hasErrors)
            {
                String strMsg = "Are you sure you want to cancel the creation of a new auxiliary service schedule details?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//---------------------------------
        //################################################END CLASS AuxiliaryScheduleCreate EVENTS#######################################################

        //################################################BUTTON btnCancel EVENTS####################################################
        //event is raised when btnCancel is Clicked
        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }//----------------------------------

        //################################################BUTTON btnCreate EVENTS####################################################
        //event is raised when btnCreate is Clicked
        private void btnCreateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to create the new auxiliary service schedule information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Create", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The auxiliary service schedule information has been successfully created.";

                        this.Cursor = Cursors.WaitCursor;

                        _auxiliaryManager.InsertAuxiliaryServiceSchedule(_userInfo, _serviceInfoSchedule);

                        this.Cursor = Cursors.Arrow;

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
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        }//--------------------------------
        //################################################END BUTTON btnCreate EVENTS####################################################
        #endregion
    }
}
