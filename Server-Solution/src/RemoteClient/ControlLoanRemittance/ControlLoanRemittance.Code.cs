using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RemoteClient
{
    public delegate void ControlLoanRemittanceModeOptionCheckedChanged(Boolean forLoanType);
    public delegate void ControlLoanRemittancePressEnter(object sender, KeyEventArgs e);

    partial class ControlLoanRemittance
    {
        #region Class Event Declarations
        public event ControlLoanRemittanceModeOptionCheckedChanged OnModeOptionCheckedChanged;
        public event ControlLoanRemittancePressEnter OnPressEnter;
        #endregion

        #region Class Constructor
        public ControlLoanRemittance()
        {
            this.InitializeComponent();

            this.optLoanType.CheckedChanged += new EventHandler(optionButtonCheckedChanged);
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
            ControlLoanRemittanceModeOptionCheckedChanged ev = OnModeOptionCheckedChanged;

            if (ev != null)
            {
                OnModeOptionCheckedChanged(optLoanType.Checked);
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
                ControlLoanRemittancePressEnter ev = OnPressEnter;

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

    }
}
