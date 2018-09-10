using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DentalSystem
{
    partial class SystemLogIn
    {
        #region Class Member Declarations
        private Int32 _tryCounter = 1;

        private Timer _tmrLogIn;        
        #endregion

        #region Class Properties Declarations
        private Boolean _hasAccess = false;
        public Boolean HasAccess
        {
            get { return _hasAccess; }
        }

        private CommonExchange.SysAccess _userInfo;
        public CommonExchange.SysAccess UserInformation
        {
            get { return _userInfo; }
        }
        #endregion

        #region Class Constructor
        public SystemLogIn()
        {
            this.InitializeComponent();

            _tmrLogIn = new Timer();
            _userInfo = new CommonExchange.SysAccess();

            this.Load += new EventHandler(ClassLoad);
            this.txtUsername.GotFocus += new EventHandler(txtUsernameGotFocus);
            this.txtUsername.KeyPress += new KeyPressEventHandler(txtUsernameKeyPress);
            this.txtUsername.Validated += new EventHandler(txtUsernameValidated);
            this.txtPassword.GotFocus += new EventHandler(txtPasswordGotFocus);
            this.txtPassword.KeyPress += new KeyPressEventHandler(txtPasswordKeyPress);
            this._tmrLogIn.Tick += new EventHandler(tmrLogInTick);
            this.pbxDone.Click += new EventHandler(pbxDoneClick);
            
        }
        
        #endregion

        #region Class Event Void Procedures
        //#####################################CLASS SystemLogIn EVENTS###################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _tmrLogIn.Interval = 300;
        } //------------------
        //###################################END CLASS SystemLogIn EVENTS#################################################

        //###################################PICTUREBOX pbxDone EVENTS###################################################
        //event is raised when the picturebox is clicked
        private void pbxDoneClick(object sender, EventArgs e)
        {
            this.Close();
        } //----------------------------
        //##################################END PICTUREBOX pbxDone EVENTS################################################

        //##################################TEXTBOX txtUsername EVENTS####################################################
        //event is raised when the control got focused
        private void txtUsernameGotFocus(object sender, EventArgs e)
        {
            this.lblAuthenticate.Visible = true;
            this.lblAuthenticate.Text = "Authenticating User...";
            this.lblAuthenticate.ForeColor = Color.Maroon;

            this._tmrLogIn.Stop();
        } //------------------------
        //event is raised when the key is pressed
        private void txtUsernameKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.txtPassword.Focus();
            }

        } //------------------------

        //event is raised whent the control is validated
        private void txtUsernameValidated(object sender, EventArgs e)
        {
            _userInfo.UserName = this.txtUsername.Text;
        } //--------------------------
        //#################################END TEXTBOX txtUsername EVENTS#################################################

        //##########################################TEXTBOX txtPassword EVENTS############################################
        //event is raised when the control got focused
        private void txtPasswordGotFocus(object sender, EventArgs e)
        {
            this.lblAuthenticate.Visible = true;
            this.lblAuthenticate.Text = "Authenticating User...";
            this.lblAuthenticate.ForeColor = Color.Maroon;

            this._tmrLogIn.Stop();
        } //--------------------

        //event is raised when the key is pressed
        private void txtPasswordKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                _userInfo.Password = this.txtPassword.Text;

                using (DatabaseLib.DbLibGeneral dbLib = new DatabaseLib.DbLibGeneral())
                {
                    if (dbLib.AuthenticateUser(ref _userInfo))
                    {
                        _hasAccess = true;

                        this.Close();
                    }
                    else
                    {
                        this.lblAuthenticate.Text = "ACCESS DENIED";
                        this.lblAuthenticate.ForeColor = Color.Red;

                        _tmrLogIn.Start();

                        if (_tryCounter == 3)
                        {
                            _hasAccess = false;

                            this.Close();
                        }
                        else
                        {
                            _tryCounter++;
                        }
                    }
                }
            }
        } //--------------------------------
        //########################################END TEXTBOX txtPassword EVENTS##########################################

        //#########################################TIMER tmrLogIn EVENTS####################################################
        //event is raised when the timer ticks
        private void tmrLogInTick(object sender, EventArgs e)
        {
            this.lblAuthenticate.Visible = !this.lblAuthenticate.Visible;   
        } //----------------------
        //#######################################END TIMER tmrLogIn EVENTS##################################################

        #endregion

    }
}
