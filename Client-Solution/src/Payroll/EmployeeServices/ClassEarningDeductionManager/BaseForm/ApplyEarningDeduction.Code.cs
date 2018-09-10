using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace EmployeeServices
{
    partial class ApplyEarningDeduction
    {
        #region Class General Variable Declarations
        private ErrorProvider errProvider = new ErrorProvider();
        #endregion

        #region Class Constructor

        public ApplyEarningDeduction()
        {
            InitializeComponent();

            this.lnkAll.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkAllLinkClicked);
            this.lnkNone.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNoneLinkClicked);
            this.cbxEmployee.SelectedIndexChanged += new EventHandler(cbxEmployeeSelectedIndexChanged);
            this.txtAmount.KeyPress += new KeyPressEventHandler(txtAmountKeyPress);
            this.txtAmount.Validating += new System.ComponentModel.CancelEventHandler(txtAmountValidating);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnApply.Click += new EventHandler(btnApplyClick);
            
            this.ctlManager.DisableLayOffOption(false);
            this.ctlManager.DisableMoveCapability();
            this.ctlManager.HideCreateEmployeeIcon();
        }

        #endregion

        #region Class Event Void Procedures
        //########################################TEXTBOX txtAmount EVENTS###########################################################
        //event is raised when the key is pressed
        private void txtAmountKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxAmountOnly(e);

        } //----------------------------------

        //event is raised when the control is validating
        private void txtAmountValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxValidateAmount((TextBox)sender);
        } //-----------------------------------------
        //#######################################END TEXTBOX txtAmount EVENTS########################################################

        //########################################CHECKEDLISTBOX cbxEmployee EVENTS###################################################
        //event is raised when the selected index is changed
        private void cbxEmployeeSelectedIndexChanged(object sender, EventArgs e)
        {
            lblSelected.Text = cbxEmployee.CheckedItems.Count.ToString();
            
        } //---------------------------------  
        
        //######################################END CHECKEDLISTBOX cbxEmployee EVENTS##################################################

        //###########################################LINKBUTTON lnkAll EVENTS##########################################################
        //event is raised when the link is clicked
        private void lnkAllLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SetAllListAsChecked(cbxEmployee, true);
        } //------------------------
        //###########################################END LINKBUTTON lnkAll EVENTS######################################################

        //#########################################LINKBUTTON lnkNone EVENTS###########################################################
        //event is raised when the link is clicked
        private void lnkNoneLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SetAllListAsChecked(cbxEmployee, false);
        } //--------------------------
        //########################################END LINKBUTTON lnkNone EVENTS###########################################################   

        //#############################################BUTTON btnCancel EVENTS###########################################################
        //event is raised when the button is clicked
        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        } //-----------------------------------
        //##########################################END BUTTON btnCancel EVENTS###########################################################

        //################################################BUTTON btnApply EVENTS##########################################################
        //event is raised when the button is clicked
        protected virtual void btnApplyClick(object sender, EventArgs e)
        {

        } //--------------------------------------------
        //###############################################END BUTTON btnApply EVENTS#######################################################

        
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure fills the checkbox list
        protected void SetEmployeeCheckedListBox(DataTable srcTable, String colName)
        {
            
            cbxEmployee.Items.Clear();
            lblSelected.Text = cbxEmployee.CheckedItems.Count.ToString();

            foreach (DataRow baseRow in srcTable.Rows)
            {
                cbxEmployee.Items.Add(baseRow[colName].ToString());
            }

        } //---------------------------
        
        //this procedure checks all the list in the checkbox
        private void SetAllListAsChecked(CheckedListBox cbxBase, Boolean isChecked)
        {
            for (Int32 i = 0; i < cbxBase.Items.Count; i++)
            {
                cbxBase.SetItemChecked(i, isChecked);
            }

            lblSelected.Text = cbxEmployee.CheckedItems.Count.ToString();

        } //-----------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this procedure validates the controls
        protected Boolean ValidateControls()
        {
            Boolean isValid = true;

            errProvider.SetIconAlignment(txtAmount, ErrorIconAlignment.MiddleLeft);
            errProvider.SetIconAlignment(lblSelected, ErrorIconAlignment.MiddleRight);
            errProvider.SetError(txtAmount, "");
            errProvider.SetError(lblSelected, "");

            Decimal amount = 0;

            if (!Decimal.TryParse(txtAmount.Text, out amount) || amount == 0)
            {
                errProvider.SetError(txtAmount, "An amount is required or the amount should not be equal to zero.");
                isValid = false;
            }

            if (cbxEmployee.CheckedItems.Count == 0)
            {
                errProvider.SetError(lblSelected, "An employee selection is required.");
                isValid = false;
            }

            return isValid;
        } //-----------------------

        #endregion
    }
}
