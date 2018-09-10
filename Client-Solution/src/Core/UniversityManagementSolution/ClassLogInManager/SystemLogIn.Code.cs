using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace UniversityManagementSolution
{
    partial class SystemLogIn
    {
        #region Class Member Declarations
        private Int32 _tryCounter = 1;
        private Int32 _counterLoading = 7;

        private System.Windows.Forms.Timer _tmrLogIn;
        private System.Windows.Forms.Timer _tmrLoading;        
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

            _tmrLogIn = new System.Windows.Forms.Timer();
            _tmrLoading = new System.Windows.Forms.Timer();
            _userInfo = new CommonExchange.SysAccess();            

            this.Load += new EventHandler(ClassLoad);
            this.txtUsername.GotFocus += new EventHandler(txtUsernameGotFocus);
            this.txtUsername.KeyPress += new KeyPressEventHandler(txtUsernameKeyPress);
            this.txtUsername.Validated += new EventHandler(txtUsernameValidated);
            this.txtPassword.GotFocus += new EventHandler(txtPasswordGotFocus);
            this.txtPassword.KeyPress += new KeyPressEventHandler(txtPasswordKeyPress);            
            this._tmrLogIn.Tick += new EventHandler(tmrLogInTick);
            this._tmrLoading.Tick += new EventHandler(_tmrLoadingTick);
            this.pbxDone.Click += new EventHandler(pbxDoneClick);            
        }       
        
        #endregion

        #region Class Event Void Procedures
        //#####################################CLASS SystemLogIn EVENTS###################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            this.lblVersion.Text = "Version " + Application.ProductVersion;
 
            _tmrLogIn.Interval = _tmrLoading.Interval = 300;
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
            this.lblAuthenticate.Text = "Please enter your username...";
            this.lblAuthenticate.ForeColor = Color.Maroon;

            this.pbxIcon.Image = global::UniversityManagementSolution.Properties.Resources.login_48x48;

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
            this.lblAuthenticate.Text = "Please enter your password...";
            this.lblAuthenticate.ForeColor = Color.Maroon;

            this.pbxIcon.Image = global::UniversityManagementSolution.Properties.Resources.secrecy_48x48;

            if (this.txtPassword.Text.Length > 0)
            {
                this.txtPassword.SelectAll();
            }

            this._tmrLogIn.Stop();
        } //--------------------

        //event is raised when the key is pressed
        private void txtPasswordKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            { 
                this.pbxIcon.Image = global::UniversityManagementSolution.Properties.Resources.loading2;
                this.lblAuthenticate.Text = "Authenticating user...";

                Application.DoEvents();

                _userInfo.Password = this.txtPassword.Text;

                _userInfo.NetworkInformation = RemoteClient.ProcStatic.GetNetworkInformation();

                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    using (RemoteClient.RemCntAdministratorManager remClient = new RemoteClient.RemCntAdministratorManager())
                    {
                        Boolean isExpired = false;
                        
                        if (remClient.AuthenticateSystemUser(ref _userInfo, ref isExpired))
                        {
                            _hasAccess = true;

                            //_tmrLoading.Start();
                            this.Close();
                        }
                        else
                        {
                            this.pbxIcon.Image = global::UniversityManagementSolution.Properties.Resources.Symbol_Error;

                            if (!isExpired)
                            {
                                this.lblAuthenticate.Text = "ACCESS DENIED";
                            }
                            else
                            {
                                this.lblAuthenticate.Text = "Your Software License is already expired.";
                            }

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
                catch
                {
                    RemoteClient.ProcStatic.ShowErrorDialog("There has been a problem in the attempt to access the system.\n\nPlease contact your system administrator.", "System Error");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
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

        //#########################################TIMER tmrLoading EVENTS####################################################
        //event is raised when the timer ticks
        private void _tmrLoadingTick(object sender, EventArgs e)
        {
            _counterLoading--;

            if (_counterLoading == 0)
            {
                _tmrLoading.Stop();

                this.Close();
            }
        }//---------------------------
        //#########################################END TIMER tmrLoading EVENTS####################################################

        #endregion

    }
}
