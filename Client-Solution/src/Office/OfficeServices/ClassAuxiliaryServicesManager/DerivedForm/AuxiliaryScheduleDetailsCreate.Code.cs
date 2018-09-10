using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class AuxiliaryScheduleDetailsCreate
    {
        #region Class Properties Declarations
        private Boolean _hasCreated = false;
        public Boolean HasCreated
        {
            get { return _hasCreated; }
        }
        #endregion

        #region ClassConstructors
        public AuxiliaryScheduleDetailsCreate(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceSchedule serviceInfoSchedule,
            AuxiliaryServiceLogic auxiliaryManager)
            : base(userInfo, serviceInfoSchedule, auxiliaryManager)
        {
            this.InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnAddDetails.Click += new EventHandler(btnAddDetailsClick);
        }
        

        #endregion

        #region Class Event Void Procedures
        //################################################CLASS AuxiliaryScheduleDetailsCreate EVENTS#######################################################
        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
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

        }//--------------------------------
        //################################################END CLASS AuxiliaryScheduleDetailsCreate EVENTS#######################################################

        //##############################################BUTTON btnCancel EVENTS########################################################
        //event is raised when the button is clicked
        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }//--------------------------------
        //##############################################END BUTTON btnCancel EVENTS########################################################

        //#############################################BUTTON btnAddDetails EVENTS########################################################
        //event is raised when the button is clicked
        private void btnAddDetailsClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to add the new auxiliary service schedule information details?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Add", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The auxiliary service schedule information details has been successfully added.";

                        this.Cursor = Cursors.WaitCursor;

                        _auxiliaryManager.InsertAuxiliaryServiceScheduleDetails(_serviceInfoDetails);

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
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Adding");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        }//------------------------------
        //#############################################END BUTTON btnAddDetails EVENTS########################################################
        #endregion

    }
}
