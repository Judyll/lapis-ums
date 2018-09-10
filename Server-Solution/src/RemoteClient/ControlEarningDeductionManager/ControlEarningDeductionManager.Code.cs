using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RemoteClient
{
    public delegate void ControlEarningDeductionManagerModeOptionCheckedChanged(Boolean forApply);
    public delegate void ControlEarningDeductionManagerPressEnter(object sender, KeyEventArgs e);

    partial class ControlEarningDeductionManager
    {
        #region Class Event Declarations
        public event ControlEarningDeductionManagerModeOptionCheckedChanged OnModeOptionCheckedChanged;
        public event ControlEarningDeductionManagerPressEnter OnPressEnter;
        #endregion

        #region Class Contructor
        public ControlEarningDeductionManager()
        {
            this.InitializeComponent();

            this.optApply.CheckedChanged += new EventHandler(optionButtonCheckedChanged);
        }

        
        #endregion

        #region Class Event Void Procedures

        //#####################################CLASS ControlDeductionManager EVENTS#######################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            base.ClassLoad(sender, e);

            _maxHeight = this.Size.Height;

        } //----------------------------
        //####################################END CLASS ControlDeductionManager EVENTS####################################

        //#######################################OPTION BUTTONS EVENTS######################################################
        //event is raised when the check is changed
        private void optionButtonCheckedChanged(object sender, EventArgs e)
        {
            ControlEarningDeductionManagerModeOptionCheckedChanged ev = OnModeOptionCheckedChanged;

            if (ev != null)
            {
                OnModeOptionCheckedChanged(optApply.Checked);
            }

            this.txtSearch.Clear();
            this.txtSearch.Focus();

        } //------------------------------------
        //#####################################END OPTION BUTTONS EVENTS####################################################

        //###################################TEXTBOX txtSearch EVENTS##########################################
        //event is raised when the key is up
        protected override void txtSearchKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ControlEarningDeductionManagerPressEnter ev = OnPressEnter;

                if (ev != null)
                {
                    OnPressEnter(sender, e);
                }
            }
            else
            {
                base.txtSearchKeyUp(sender, e);
            }

        } //----------------------------------
        //#################################END TEXTBOX txtSearch EVENTS########################################

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure initializes the controls
        public void InitializeControl(Boolean forDeduction)
        {
            if (forDeduction)
            {
                this.optApply.Text = "Apply a deduction to employee(s)";
                this.optView.Text = "View employee deduction(s)";
            }
            else
            {
                this.optApply.Text = "Apply an earning to employee(s)";
                this.optView.Text = "View employee earning(s)";
            }
        } //----------------------------
        #endregion
    }
}
