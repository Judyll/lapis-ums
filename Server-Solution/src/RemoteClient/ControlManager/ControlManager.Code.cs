using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RemoteClient
{
    public delegate void ControlManagerCloseButtonClick();
    public delegate void ControlManagerRefreshButtonClick();
    public delegate void ControlManagerTextBoxSearchKeyUp(object sender, KeyEventArgs e);

    partial class ControlManager
    {
        #region Class Event Declarations
        public event ControlManagerCloseButtonClick OnClose;
        public event ControlManagerRefreshButtonClick OnRefresh;
        public event ControlManagerTextBoxSearchKeyUp OnTextBoxKeyUp;
        #endregion

        #region Class Member Declarations
        protected ToolTip ttpMain = new ToolTip();
        #endregion

        #region Class Properties Declarations
        public String GetSearchString
        {
            get { return this.txtSearch.Text; }
        }

        #endregion

        #region Class Constructor
        public ControlManager()
        {            
            this.InitializeComponent();

            this.pbxClose.Click += new EventHandler(pbxCloseClick);
            this.pbxRefresh.Click += new EventHandler(pbxRefreshClick);
            this.txtSearch.KeyUp += new KeyEventHandler(txtSearchKeyUp);
            this.txtSearch.KeyPress += new KeyPressEventHandler(txtSearchKeyPress);
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
            ttpMain.SetToolTip(this.pbxClose, "Close");
            ttpMain.SetToolTip(this.pbxRefresh, "Refresh");
        }
        //################################END CLASS ControlManager EVENTS#####################################

        //#################################PICTUREBOX pbxClose EVENTS########################################
        //event is raised when the control is clicked
        private void pbxCloseClick(object sender, EventArgs e)
        {
            ControlManagerCloseButtonClick ev = OnClose;

            if (ev != null)
            {
                OnClose();
            }

        } //----------------------------
        //##############################END PICTUREBOX pbxClose EVENTS#######################################

        //##################################PICTUREBOX pbxRefresh EVENTS#######################################
        //event is raised when the control is clicked
        private void pbxRefreshClick(object sender, EventArgs e)
        {
            ControlManagerRefreshButtonClick ev = OnRefresh;

            if (ev != null)
            {
                OnRefresh();
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
            ControlManagerTextBoxSearchKeyUp ev = OnTextBoxKeyUp;

            if (ev != null)
            {
                OnTextBoxKeyUp(sender, e);
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
