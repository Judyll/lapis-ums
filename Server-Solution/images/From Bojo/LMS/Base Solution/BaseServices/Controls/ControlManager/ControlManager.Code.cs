using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BaseServices.Control
{
    partial class ControlManager
    {
        #region Class Event Declarations
        public event BaseServices.Control.ClickEvent OnClose;
        public event BaseServices.Control.ClickEvent OnRefresh;
        public event BaseServices.Control.KeyEventHandler OnTextBoxKeyUp;
        public event BaseServices.Control.KeyPressEnter OnPressEnter;
        #endregion

        #region Class Member Declarations
        protected ToolTip ttpMain = new ToolTip();
        #endregion

        #region Class Properties Declarations
        protected String _strSearch;
        public String GetSearchString
        {
            get { return _strSearch; }
        }
        #endregion

        #region Class Constructor
        public ControlManager()
        {            
            this.InitializeComponent();

            this.pbxClose.Click += new EventHandler(pbxCloseClick);
            this.pbxRefresh.Click += new EventHandler(pbxRefreshClick);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(txtSearchKeyUp);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtSearchKeyPress);
        }                
        
        #endregion

        #region Class Event Void Procedures

        //################################CLASS ControlManager EVENTS########################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            base.ClassLoad(sender, e);

            ttpMain.ToolTipIcon = ToolTipIcon.Info;
            ttpMain.ToolTipTitle = "Console";
            ttpMain.UseAnimation = true;
            ttpMain.UseFading = true;
            ttpMain.IsBalloon = true;
            ttpMain.AutoPopDelay = 3000;
            ttpMain.SetToolTip(this.pbxClose, "Done");
            ttpMain.SetToolTip(this.pbxRefresh, "Refresh");
        }
        //################################END CLASS ControlManager EVENTS#####################################

        //#################################PICTUREBOX pbxClose EVENTS########################################
        //event is raised when the control is clicked
        private void pbxCloseClick(object sender, EventArgs e)
        {
            BaseServices.Control.ClickEvent ev = OnClose;

            if (ev != null)
            {
                OnClose(sender, e);
            }

        } //----------------------------
        //##############################END PICTUREBOX pbxClose EVENTS#######################################

        //##################################PICTUREBOX pbxRefresh EVENTS#######################################
        //event is raised when the control is clicked
        private void pbxRefreshClick(object sender, EventArgs e)
        {
            BaseServices.Control.ClickEvent ev = OnRefresh;

            if (ev != null)
            {
                OnRefresh(sender, e);
            }

            this.SetFocusOnSearchTextBox();
        } //--------------------------------
        //################################END PICTUREBOX pbxRefresh EVENTS#####################################

        //###################################TEXTBOX txtSearch EVENTS##########################################
        //event is raised when the key is pressed
        private void txtSearchKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) &&
                !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '*' && e.KeyChar != '\r' && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        } //---------------------------------

        //event is raised when the key is up
        protected virtual void txtSearchKeyUp(object sender, KeyEventArgs e)
        {
            _strSearch = ((TextBox)sender).Text;

            if (e.KeyCode == Keys.Enter)
            {
                _strSearch = txtSearch.Text;

                BaseServices.Control.KeyPressEnter ev = OnPressEnter;

                if (ev != null)
                {
                    OnPressEnter();
                }
            }
            else
            {
                BaseServices.Control.KeyEventHandler ev = OnTextBoxKeyUp;

                if (ev != null)
                {
                    OnTextBoxKeyUp(sender, e);
                }
            }
            
        }        
        //#################################END TEXTBOX txtSearch EVENTS########################################
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure sets the focus on search textbox
        public void SetFocusOnSearchTextBox()
        {
            this.txtSearch.Focus();
        } //----------------------------
        #endregion
    }
}
