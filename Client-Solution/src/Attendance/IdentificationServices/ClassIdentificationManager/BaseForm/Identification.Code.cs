using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;

namespace IdentificationServices
{
    partial class Identification
    {

        #region Class Member Variable Declaration
        protected CommonExchange.SysAccess _userInfo;
        protected CommonExchange.Student _studentInfo;
        protected CommonExchange.Employee _employeeInfo;
        protected IdentificationLogic _identificationManager;

        private Socket _smartLinkSocket;

        private const int c_port = 62895;
        #endregion

        #region Class Constructor

        public Identification()
        {
            this.InitializeComponent();
        }

        public Identification(CommonExchange.SysAccess userInfo, IdentificationLogic identificationManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _identificationManager = identificationManager;

            _smartLinkSocket = null;

            this.InitializeSmartLinkSocket();

            this.Load += new EventHandler(ClassLoad);
            this.btnGenerateReader.Click += new EventHandler(btnGenerateReaderClick);
            this.pbxPhoto.Click += new EventHandler(pbxPhotoClick);
            //this.txtCardNumber.Validated += new EventHandler(txtCardNumberValidated);
        }       
        #endregion

        #region Class Event Void Procedures
        //private void txtCardNumberValidated(object sender, EventArgs e)
        //{
        //    _studentInfo.CardNumber = _employeeInfo.CardNumber = RemoteClient.ProcStatic.TrimStartEndString(this.txtCardNumber.Text);
        //}

        //###########################################CLASS IDENTIFICATIONUPDATE ClassLoad EVENTS#####################################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            _employeeInfo = new CommonExchange.Employee();
            _studentInfo = new CommonExchange.Student();
        }//--------------------------------------
        //###########################################END CLASS IDENTIFICATIONUPDATE ClassLoad EVENTS#####################################################

        //########################################BUTTON btnGenerateReader EVENTS#####################################################
        //event is raised whent the controls is clicked
        private void btnGenerateReaderClick(object sender, EventArgs e)
        {
            try
            {
                if (_smartLinkSocket != null && _smartLinkSocket.Connected)
                {
                    _employeeInfo.CardNumber = _studentInfo.CardNumber = this.txtCardNumber.Text = this.SocketSendReceive(_smartLinkSocket);

                    this.btnGenerateReader.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Can't find smart link server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.lblStatusReader.Text = "DISCONNECTED";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't find smart link server.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//----------------------------------
        //########################################END BUTTON btnGenerateReader EVENTS#####################################################

         //#########################################PICTUREBOX pbxPhoto EVENTS###########################################################
        //event is raised when the control is Clicked
        private void pbxPhotoClick(object sender, EventArgs e)
        {
            using(OpenFileDialog imageChooser = new OpenFileDialog())
            {
                imageChooser.Title = "Select an image";
                imageChooser.Filter = "All image file (*.jpg, *.jpeg, *.bmp, *.gif) | *.jpg; *.jpeg; *.bmp; *.gif";
                imageChooser.Multiselect = false;
                imageChooser.CheckFileExists = true;
                imageChooser.CheckPathExists = true;

                //determines if an image has been Selected
                if(imageChooser.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;

                    this.pbxPhoto.Image = Image.FromFile(imageChooser.FileName);

                    _employeeInfo.PersonInfo.FilePath = _studentInfo.PersonInfo.FilePath = imageChooser.FileName;

                    _employeeInfo.PersonInfo.FileData = _studentInfo.PersonInfo.FileData = 
                        RemoteClient.ProcStatic.GetFileArrayBytes(_employeeInfo.PersonInfo.FilePath);
                    _employeeInfo.PersonInfo.FileExtension = _studentInfo.PersonInfo.FileExtension =
                        _identificationManager.GetImageExtensionName(_employeeInfo.PersonInfo.FilePath);
                    _employeeInfo.PersonInfo.FileName = _studentInfo.PersonInfo.FileName = Path.GetFileName(_employeeInfo.PersonInfo.FilePath);

                    this.Cursor = Cursors.Arrow;
                }
            }
        }//----------------------------
        //#########################################END PICTUREBOX pbxPhoto EVENTS###########################################################

        #endregion

        #region Programmers-Defined Void Procedures
        //this procedure will initialize smart link socket
        private void InitializeSmartLinkSocket()
        {
            try
            {
                _smartLinkSocket = this.ConnectSocket(this.GetIPAddress(), c_port);

                if (_smartLinkSocket != null && _smartLinkSocket.Connected)
                {
                    this.lblStatusReader.Text = "CONNECTED";

                    this.btnGenerateReader.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Can't find smart link server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.lblStatusReader.Text = "DISCONNECTED";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't find smart link server.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//--------------------------
        #endregion

        #region Programmers-Defined Functions
        //this fucntion will connect to the socket
        private Socket ConnectSocket(string server, int port)
        {
            Socket s = null;
            IPHostEntry hostEntry = null;

            // Get host related information.
            hostEntry = Dns.GetHostEntry(server);

            // Loop through the AddressList to obtain the supported AddressFamily. This is to avoid
            // an exception that occurs when the host IP Address is not compatible with the address family
            // (typical in the IPv6 case).
            foreach (IPAddress address in hostEntry.AddressList)
            {
                IPEndPoint ipe = new IPEndPoint(address, port);
                Socket tempSocket =
                    new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                tempSocket.Connect(ipe);

                if (tempSocket.Connected)
                {
                    s = tempSocket;
                    break;
                }
                else
                {
                    continue;
                }
            }

            return s;
        }//------------------------------

        //this function will get cart serial number
        // This method requests the home page content for the specified server.
        private String SocketSendReceive(Socket s)
        {
            String request = "DOISMARTSERIAL";
            Byte[] bytesSent = Encoding.ASCII.GetBytes(request);
            Byte[] bytesReceived = new Byte[256];
            
            // Send request to the server.
            s.Send(bytesSent, bytesSent.Length, 0);

            // Receive the server home page content.
            int bytes = 0;
            String value = String.Empty;

            Thread.Sleep(200);

            bytes = s.Receive(bytesReceived, bytesReceived.Length, 0);

            value = Encoding.ASCII.GetString(bytesReceived, 2, bytes-2);
 
            return value;
        }//---------------------

        //this procedure will get ip address
        private String GetIPAddress()
        {
            String ipe = String.Empty;

            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();


            if (nics != null || nics.Length >= 1)
            {
                foreach (NetworkInterface adapter in nics)
                {
                    if (!adapter.Supports(NetworkInterfaceComponent.IPv4))
                    {
                        continue;
                    }

                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    IPv4InterfaceProperties ipV4 = properties.GetIPv4Properties();

                    foreach (UnicastIPAddressInformation ipInfo in properties.UnicastAddresses)
                    {
                        ipe = ipInfo.Address.ToString();

                        break;
                    }

                    if (!String.IsNullOrEmpty(ipe))
                    {
                        break;
                    }
                }
            }

            return ipe;
        }//----------------------
        #endregion
    }
}
