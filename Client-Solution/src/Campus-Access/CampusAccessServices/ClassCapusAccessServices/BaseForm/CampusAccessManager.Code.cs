using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace CampusAccessServices
{
    partial class CampusAccessManager : IDisposable
    {
        #region Class Nested Classes
        internal class ListOfImages
        {
            public ListOfImages()
            {
            }

            private Image _img;
            public Image PersonImage
            {
                get { return _img; }
                set { _img = value; }
            }

            private String _strDescription;
            public String ImageDescription
            {
                get { return _strDescription; }
                set { _strDescription = value; }
            }

            private String _personName;
            public String PersonName
            {
                get { return _personName; }
                set { _personName = value; }
            }

            private String _lastName;
            public String LastName
            {
                get { return _lastName; }
                set { _lastName = value; }
            }

            private String _firstMiddleName;
            public String FirstMiddleName
            {
                get { return _firstMiddleName; }
                set { _firstMiddleName = value; }
            }

            private String _StudentEmployeeSystemId;
            public String StudentEmployeeSystemId
            {
                get { return _StudentEmployeeSystemId; }
                set { _StudentEmployeeSystemId = value; }
            }

            private String _dateTimeSwipString;
            public String DateTimeSwipString
            {
                get { return _dateTimeSwipString; }
                set { _dateTimeSwipString = value; }
            }

            private String _personSysId;
            public String PersonSysId
            {
                get { return _personSysId; }
                set { _personSysId = value; }
            }

            private DateTime _swipeTime;
            public DateTime SwipeTime
            {
                get { return _swipeTime; }
                set { _swipeTime = value; }
            }

        }
        #endregion

        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private CampusAccessLogic _campusAccessManager;

        private String _accessPointId;

        private List<ListOfImages> _imageList;

        private const Int32 c_noImages = 6;
        private const Int32 c_noOfSwipeBeforeUpdate = 20;
        private const Int32 c_minutesPerUpdate = 30;
        private Int32 _swipeCount;

        private Pen _pnBig = new Pen(Color.Green, 2);
        private Pen _pnSmall = new Pen(Color.Green, 1);

        //private SerialPort _port = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
        private SerialPort _port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
                
        private int _imgBigWidth = 293;
        private int _imgBigHeight = 293;

        private int _imgSmallWidth = 156;
        private int _imgSmallHeight = 156;

        private String _lastCardNo = String.Empty;
        private DateTime _timeSwipe = DateTime.MinValue;
        private DateTime _lastTimeUpdated = DateTime.MinValue;
        private DateTime _systemTime;

        private Boolean _isAccessDenied = false;
        private Boolean _isUpdating = false;

        private Image _errorImage;
        #endregion

        #region Class Constructors and Distructors
        public CampusAccessManager(CommonExchange.SysAccess userInfo, CampusAccessLogic campusAccessManager, String accessPointId)
        {
           
            _imageList = new List<ListOfImages>();

            for (Int32 x = 1; x <= c_noImages; x++)
            {
                ListOfImages list = new ListOfImages();

                list.PersonImage = Image.FromFile(Application.StartupPath + @"\default.jpg");

                _imageList.Add(list);
            }

            this.InitializeComponent();

            _userInfo = userInfo;
            _campusAccessManager = campusAccessManager;
            _accessPointId = accessPointId;
            
            this.Load += new EventHandler(ClassLoad);
            this.FormClosed += new FormClosedEventHandler(CampusAccessManagerFormClosed);
            this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.tmrTime.Tick += new EventHandler(tmrTimeTick);
            _port.DataReceived += new SerialDataReceivedEventHandler(_portDataReceived);         
            

            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            this.lblAccessPoint.Text = _campusAccessManager.GetAccessPointDescription(_accessPointId);
        }

        void IDisposable.Dispose()
        {
            this.Dispose();

            GC.SuppressFinalize(this);
            GC.Collect();

            this.Cursor = Cursors.WaitCursor;

            _campusAccessManager.DeletePersonImagesDirectory(Application.StartupPath);

            this.Cursor = Cursors.Arrow;
        }
        #endregion

        #region Class Event Void Procedures
        //####################################################CLASS CampusAccessManager EVENTS###############################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _port.Open();

            _errorImage = Image.FromFile(Application.StartupPath + @"\error.jpg");

            _isUpdating = true;

            this.Cursor = Cursors.WaitCursor;

            using (UpdatingForm frmUpdate = new UpdatingForm(_userInfo, _campusAccessManager))
            {
                frmUpdate.ShowDialog();
            }

            this.Cursor = Cursors.Arrow;

            _isUpdating = false;

            if (DateTime.TryParse(_campusAccessManager.ServerDateTime, out _systemTime))
            {
                this.tmrTime.Start();
            }

            _lastTimeUpdated = _systemTime;

            //this.InitializeImageSize();       
        }//--------------------------------

        //event is raised when the class is clossing
        private void ClassClossing(object sender, FormClosingEventArgs e)
        {
            _imageList.RemoveRange(0, c_noImages);
            this.Dispose();

            using (UpdatingForm frmUpdate = new UpdatingForm(_userInfo, _campusAccessManager))
            {
                frmUpdate.ShowDialog();
            }

            Application.Exit();
        }//-------------------

        //event is raised when the class is clossing
        private void CampusAccessManagerFormClosed(object sender, FormClosedEventArgs e)
        {
            //_port.Dispose();
            //_port.Close();
            this.Dispose();
        }//-------------------------------

        //event is raised when the class is painted
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                Boolean isFirstEnter = true;

                Int32 xLocation = 10;
                Int32 yLocation = 0;

                if (this.Size.Height > 786 && this.Size.Width > 1024)
                {
                    yLocation = this.Size.Height - ((_imgSmallHeight * 2) + 100);
                }
                else
                {
                    yLocation = 345;
                }

                this.ClearControls();

                for (Int32 x = 0; x < c_noImages; x++)
                {
                    if (isFirstEnter)
                    {
                        Int32 xLoc = 10;
                        Int32 yLoc = 20;

                        Image img = _isAccessDenied ? _errorImage : _imageList[x].PersonImage;
                        String strGreate = _isAccessDenied ? "Access Denied!" : this.GetGreeting(_imageList[x].SwipeTime);
                        Graphics g = e.Graphics;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.DrawImage(img, xLoc, yLoc, _imgBigWidth, _imgBigHeight);

                        Label lblGreet = new Label();
                        lblGreet.AutoSize = true;
                        lblGreet.ForeColor = Color.Maroon;
                        lblGreet.Location = new Point(324, yLoc + 30);
                        lblGreet.Font = new Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        lblGreet.Text = strGreate;

                        if (!_isAccessDenied)
                        {
                            Label lblLastName = new Label();
                            lblLastName.AutoSize = true;
                            lblLastName.ForeColor = Color.Black;
                            lblLastName.Location = new Point(324, yLoc + 100);
                            lblLastName.Font = new Font("Calibri", 22.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                            lblLastName.Size = new Size(500, 45);
                            lblLastName.Text = _imageList[x].LastName;
                            lblLastName.TextAlign = ContentAlignment.TopLeft;

                            Label lblFirsMiddleName = new Label();
                            lblFirsMiddleName.AutoSize = true;
                            lblFirsMiddleName.ForeColor = Color.Black;
                            lblFirsMiddleName.Location = new Point(324, yLoc + 138);
                            lblFirsMiddleName.Font = new Font("Calibri", 22.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                            lblFirsMiddleName.Size = new Size(500, 45);
                            lblFirsMiddleName.Text = _imageList[x].FirstMiddleName;
                            lblFirsMiddleName.TextAlign = ContentAlignment.TopLeft;

                            Label lblDescription = new Label();
                            lblDescription.AutoSize = true;
                            lblDescription.ForeColor = Color.DarkGray;
                            lblDescription.Location = new Point(324, yLoc + lblLastName.Height + 140);
                            lblDescription.Font = new Font("Calibri", 14.25F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(0)));
                            lblDescription.Text = _imageList[x].StudentEmployeeSystemId + "\n" + _imageList[x].DateTimeSwipString;

                            this.Controls.AddRange(new Control[] { lblLastName, lblFirsMiddleName, lblDescription });
                        }

                        this.Controls.Add(lblGreet);

                        isFirstEnter = false;
                    }
                    else
                    {
                        Rectangle rcg = new Rectangle(xLocation, yLocation - 5, _imgSmallWidth + 40, _imgSmallHeight + 150);
                        Brush brGradient = new LinearGradientBrush(rcg, Color.Gainsboro, Color.DimGray, 50, false);

                        Graphics b = e.Graphics;
                        b.SmoothingMode = SmoothingMode.HighQuality;
                        b.FillRectangle(brGradient, rcg);
                        b.DrawImage(_imageList[x].PersonImage, xLocation + 5, yLocation, _imgSmallWidth + 30, _imgSmallHeight + 30);

                        Label lblSmallImageText = new Label();
                        lblSmallImageText.Name = _imageList[x].ImageDescription;
                        lblSmallImageText.BackColor = Color.Gainsboro;
                        lblSmallImageText.Location = new Point(xLocation + 5, yLocation + (_imgSmallHeight + 35));
                        lblSmallImageText.Size = new Size(_imgSmallWidth + 30, 105);
                        lblSmallImageText.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                        lblSmallImageText.TextAlign = ContentAlignment.MiddleCenter;

                        this.Controls.Add(lblSmallImageText);

                        lblSmallImageText.Text = _imageList[x].ImageDescription;
                        lblSmallImageText.AutoSize = false;
                        lblSmallImageText.Invalidate(false);
                        lblSmallImageText.BringToFront();
   
                        lblSmallImageText.Invalidate(false);

                        xLocation += (_imgSmallHeight + 45);
                    }
                }                

                base.OnPaint(e);                
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error in painting\n" + ex.Message, "Error Painting");
            }
        }//----------------------------
        //####################################################END CLASS CampusAccessManager EVENTS###############################################

        //####################################################TIMER tmrTime EVENTS###############################################
        //event is raised when the time ticks
        private void tmrTimeTick(object sender, EventArgs e)
        {
            _systemTime = _systemTime.AddSeconds(this.tmrTime.Interval / 1000);            

            this.lblTime.Text = _systemTime.ToLongTimeString();
            this.lblDate.Text = _systemTime.ToLongDateString();

            if (DateTime.Compare(_lastTimeUpdated, _systemTime.AddMinutes(-c_minutesPerUpdate)) == 0)
            {
                _isUpdating = true;

                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    using (UpdatingForm frmUpdate = new UpdatingForm(_userInfo, _campusAccessManager))
                    {
                        frmUpdate.ShowDialog();
                    }

                    this.Cursor = Cursors.Arrow;
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog("Error updating\n" + ex.Message, "Error Updating");
                }

                _isUpdating = false;

                _lastTimeUpdated = _systemTime;
            }
        }//-----------------------------
        //####################################################END TIMER tmrTime EVENTS###############################################

        //####################################################SERIALPORT _port EVENTS###############################################
        //event is raised when the selected index is changed
        private void _portDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (_swipeCount == c_noOfSwipeBeforeUpdate)
                {
                    _isUpdating = true;

                    using (UpdatingForm frmUpdate = new UpdatingForm(_userInfo, _campusAccessManager))
                    {
                        frmUpdate.ShowDialog();
                    }

                    _isUpdating = false;

                    _lastTimeUpdated = _systemTime;

                    _swipeCount = 0;
                }

                if (_port.IsOpen && !_isUpdating)
                {
                    String newCardNo = "SN" + _port.ReadLine().Remove(0, 4).Trim();

                    if (((!String.Equals(_lastCardNo, newCardNo)) || (DateTime.Compare(_timeSwipe.AddMinutes(10), DateTime.Now) < 0)) &&
                        newCardNo.Length == 10)
                    {
                        this.SwapImages();

                        if (_campusAccessManager.IsExistPersonInformation(newCardNo))
                        {
                            if (File.Exists(CommonExchange.SystemConfiguration.PersonImagesFolder(Application.StartupPath) + @"\" +
                                _campusAccessManager.GetImageOrignalName(newCardNo)))
                            {
                                _imageList[0].PersonImage = Image.FromFile(CommonExchange.SystemConfiguration.PersonImagesFolder(Application.StartupPath) + @"\" +
                                    _campusAccessManager.GetImageOrignalName(newCardNo));
                            }
                            else
                            {
                                _imageList[0].PersonImage = Image.FromFile(Application.StartupPath + @"\default.jpg");
                            }

                            _imageList[0].SwipeTime = _systemTime;
                            _imageList[0].PersonSysId = _campusAccessManager.GetPersonSystemId(newCardNo);
                            _imageList[0].PersonName = _campusAccessManager.GetImageInformation(newCardNo, true);
                            _imageList[0].LastName = _campusAccessManager.GetPersonLastNameFirstName(newCardNo, true);
                            _imageList[0].FirstMiddleName = _campusAccessManager.GetPersonLastNameFirstName(newCardNo, false);
                            _imageList[0].StudentEmployeeSystemId = _campusAccessManager.GetImageInformation(newCardNo, false);
                            _imageList[0].DateTimeSwipString = _systemTime.ToShortDateString() + "\n" + _systemTime.ToLongTimeString();

                            _imageList[0].ImageDescription = _imageList[0].PersonName + "\n" + _imageList[0].StudentEmployeeSystemId + "\n" + _imageList[0].DateTimeSwipString;

                            _campusAccessManager.InsertCampusAccessDetails(_imageList[0].PersonSysId, _imageList[0].SwipeTime, _accessPointId);

                            _isAccessDenied = false;
                        }
                        else
                        {
                            _isAccessDenied = true;
                        }

                        _timeSwipe = DateTime.Now;

                        _swipeCount++;

                        this.Invalidate(false);
                    }

                    _lastCardNo = newCardNo;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error in Receiving Data.\n" + ex.Message, "Error");
            }
        }//--------------------------
        //####################################################END SERIALPORT _port EVENTS###############################################        
        #endregion

        #region Programmers-Defined Void Procedures
        //this procedure will do splach event
        //private void DoSplash()
        //{
        //    using (UpdatingForm frmUpdate = new UpdatingForm(_userInfo, _campusAccessManager))
        //    {
        //        frmUpdate.ShowDialog();
        //    }

        //    //_thDoSplash.Join();
        //    //_thDoSplash.Abort();

        //    _isUpdating = false;
        //}//-----------------------
      
        ////this procedure will intialize image size
        //private void InitializeImageSize()
        //{
        //    try
        //    {
        //        Boolean isFirstEnter = true;

        //        Int32 xLocation = 10;
        //        Int32 yLocation = 0;

        //        if (this.Size.Height > 786 && this.Size.Width > 1024)
        //        {
        //            yLocation = this.Size.Height - ((_imgSmallHeight * 2) + 100);
        //        }
        //        else
        //        {
        //            yLocation = 345;
        //        }

        //        this.ClearControls();

        //        IntPtr hwnd = this.Handle;

        //        for (Int32 x = 0; x < c_noImages; x++)
        //        {
        //            if (isFirstEnter)
        //            {
        //                Int32 xLoc = 10;
        //                Int32 yLoc = 20;

        //                Image img = _isAccessDenied ? _errorImage : _imageList[x].PersonImage;
        //                String strGreate = _isAccessDenied ? "Access Denied!" : this.GetGreeting(_imageList[x].SwipeTime);                        

        //                Graphics g = Graphics.FromHwnd(hwnd);
        //                g.SmoothingMode = SmoothingMode.HighQuality;
        //                g.DrawImage(img, xLoc, yLoc, _imgBigWidth, _imgBigHeight);

        //                //Label lblGreet = new Label();
        //                //lblGreet.AutoSize = true;
        //                //lblGreet.ForeColor = Color.Maroon;
        //                //lblGreet.Location = new Point(324, yLoc + 30);
        //                //lblGreet.Font = new Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //                //lblGreet.Text = strGreate;

        //                //if (!_isAccessDenied)
        //                //{
        //                //    Label lblLastName = new Label();
        //                //    lblLastName.AutoSize = false;
        //                //    lblLastName.ForeColor = Color.Black;
        //                //    lblLastName.Location = new Point(324, yLoc + 100);
        //                //    lblLastName.Font = new Font("Calibri", 22.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
        //                //    lblLastName.Size = new Size(500, 45);
        //                //    lblLastName.Text = _imageList[x].LastName;
        //                //    lblLastName.TextAlign = ContentAlignment.TopLeft;

        //                //    Label lblFirsMiddleName = new Label();
        //                //    lblFirsMiddleName.AutoSize = false;
        //                //    lblFirsMiddleName.ForeColor = Color.Black;
        //                //    lblFirsMiddleName.Location = new Point(324, yLoc + 138);
        //                //    lblFirsMiddleName.Font = new Font("Calibri", 22.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
        //                //    lblFirsMiddleName.Size = new Size(500, 45);
        //                //    lblFirsMiddleName.Text = _imageList[x].FirstMiddleName;
        //                //    lblFirsMiddleName.TextAlign = ContentAlignment.TopLeft;

        //                //    Label lblDescription = new Label();
        //                //    lblDescription.AutoSize = true;
        //                //    lblDescription.ForeColor = Color.DarkGray;
        //                //    lblDescription.Location = new Point(324, yLoc + lblLastName.Height + 140);
        //                //    lblDescription.Font = new Font("Calibri", 14.25F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(0)));
        //                //    lblDescription.Text = _imageList[x].StudentEmployeeSystemId + "\n" + _imageList[x].DateTimeSwipString;

        //                //    this.Controls.AddRange(new Control[] { lblLastName, lblFirsMiddleName, lblDescription });
        //                //}

        //                //this.Controls.Add(lblGreet);

        //                isFirstEnter = false;
        //            }
        //            else
        //            {
        //                Rectangle rcg = new Rectangle(xLocation, yLocation - 5, _imgSmallWidth + 40, _imgSmallHeight + 150);
        //                Brush brGradient = new LinearGradientBrush(rcg, Color.Gainsboro, Color.DimGray, 50, false);

        //                Graphics b = Graphics.FromHwnd(hwnd);
        //                b.SmoothingMode = SmoothingMode.HighQuality;
        //                b.FillRectangle(brGradient, rcg);
        //                b.DrawImage(_imageList[x].PersonImage, xLocation + 5, yLocation, _imgSmallWidth + 30, _imgSmallHeight + 30);

        //                //Label lblSmallImageText = new Label();
        //                //lblSmallImageText.BackColor = Color.Gainsboro;
        //                //lblSmallImageText.AutoSize = false;
        //                //lblSmallImageText.Location = new Point(xLocation + 5, yLocation + (_imgSmallHeight + 35));
        //                //lblSmallImageText.Size = new Size(_imgSmallWidth + 30, 105);
        //                //lblSmallImageText.Text = _imageList[x].ImageDescription;
        //                //lblSmallImageText.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
        //                //lblSmallImageText.TextAlign = ContentAlignment.MiddleCenter;

        //                //this.Controls.Add(lblSmallImageText);

        //                xLocation += (_imgSmallHeight + 45);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        RemoteClient.ProcStatic.ShowErrorDialog("Error in painting\n" + ex.Message, "Error Painting");
        //    }

        //    //try
        //    //{
        //    //    //_imgBigWidth = _imgBigHeight = 1;
        //    //    //_imgSmallHeight = _imgSmallWidth = 1;

        //    //    //_bigThreadImg = new Thread(new ThreadStart(RunBig));
        //    //    //_bigThreadImg.Start();

        //    //    //_smallThreadImg = new Thread(new ThreadStart(RunSmall));
        //    //    //_smallThreadImg.Start();
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    RemoteClient.ProcStatic.ShowErrorDialog("Error Initializing Image Size.\n\n" + ex.Message, "Error");
        //    //}
        //}//---------------------------

        ////this procedure is for the center image (Big Image)
        //public void RunBig()
        //{
        //    try
        //    {
        //        int dx = 10, dy = 10;

        //        while (true)
        //        {
        //            for (int i = 0; i < 500; i++)
        //            {
        //                _imgBigWidth += dx;
        //                _imgBigHeight += dy;

        //                Invalidate();
        //                Thread.Sleep(5);

        //                if (this.Size.Height > 786 && this.Size.Width > 1024)
        //                {
        //                    if (_imgBigWidth >= ((this.Size.Height / 2) - 100))
        //                    {
        //                        //_bigThreadImg.Abort();
        //                        _bigThreadImg.Join();

        //                        break;
        //                    }
        //                }
        //                else
        //                {
        //                    if (_imgBigWidth >= 284)
        //                    {
        //                        //_bigThreadImg.Abort();
        //                        _bigThreadImg.Join();

        //                        break;
        //                    }
        //                }
        //            }

        //            dx = -dx; dy = -dy;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        RemoteClient.ProcStatic.ShowErrorDialog("Error when calling the Run Big Procedure.\n\n" + ex.Message, "Error");
        //    }
        //}//--------------------

        ////this procedure is for small images
        //public void RunSmall()
        //{
        //    try
        //    {
        //        int dxSmall = 5, dySmall = 5;

        //        while (true)
        //        {
        //            for (int i = 0; i < 500; i++)
        //            {
        //                _imgSmallWidth += dxSmall;
        //                _imgSmallHeight += dySmall;

        //                Invalidate();
        //                //Thread.Sleep(7);

        //                if (this.Size.Height > 786 && this.Size.Width > 1024)
        //                {
        //                    if (_imgSmallWidth >= ((this.Size.Height / 4) - 40))
        //                    {
        //                        //_smallThreadImg.Abort();
        //                        _smallThreadImg.Join();

        //                        break;
        //                    }
        //                }
        //                else
        //                {
        //                    if (_imgSmallWidth >= 152)
        //                    {
        //                        //_smallThreadImg.Abort();
        //                        _smallThreadImg.Join();

        //                        break;
        //                    }
        //                }
        //            }

        //            dxSmall = -dxSmall; dySmall = -dySmall;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        RemoteClient.ProcStatic.ShowErrorDialog("Error when calling the Run Small Procedure.\n\n" + ex.Message, "Error");
        //    }
        //}//----------------------------

        //this procedure will swap the images
        private void SwapImages()
        {
            try
            {
                if (!_isAccessDenied)
                {
                    Int32 index = _imageList.Count - 1;

                    while (index > 0)
                    {
                        //if (index >= 2)
                        //{
                        //    if (_imageList[index - 2].PersonImage != _imageList[index - 1].PersonImage)
                        //    {
                        //        _imageList[index].PersonImage = _imageList[index - 1].PersonImage;
                        //        _imageList[index].ImageDescription = _imageList[index - 1].ImageDescription;
                        //    }
                        //}
                        //else
                        //{
                            _imageList[index].PersonImage = _imageList[index - 1].PersonImage;
                            _imageList[index].ImageDescription = _imageList[index - 1].ImageDescription;
                        //}

                        index--;
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error when swaping images.\n\n" + ex.Message, "Error");
            }
        }//-----------------------

        //this procedure will clear controls 
        private void ClearControls()
        {
            Int32 index = 0;

            foreach (Control cnt in this.Controls)
            {
                if (!String.Equals(cnt.Name, "tmrTime") && !String.Equals(cnt.Name, "lblTime") &&
                    !String.Equals(cnt.Name, "pnlFooter") && !String.Equals(cnt.Name, "lblDate") && 
                    !String.Equals(cnt.Name, "lblAccessPoint") && !String.Equals(cnt.Name, "pnlLapis") &&
                    !String.Equals(cnt.Name, "pnlLogo") && !String.Equals(cnt.Name, "lblDescription"))
                {
                    Controls.Remove(cnt);
                }

                index++;
            }
        }//-------------------------

        #endregion

        #region Programmers-Defined Function
        //this function will get greating accourding to time
        private String GetGreeting(DateTime swipeTime)
        {
            String strGreating = String.Empty;

            if ((DateTime.Compare(swipeTime, DateTime.Parse("12:00:00 AM")) >= 0) && DateTime.Compare(swipeTime, DateTime.Parse("11:59:59 AM")) <= 0)
            {
                strGreating = "Good Morning!";
            }
            else if ((DateTime.Compare(swipeTime, DateTime.Parse("12:00:00 PM")) >= 0) && DateTime.Compare(swipeTime, DateTime.Parse("5:59:59 PM")) <= 0)
            {
                strGreating = "Good Afternoon!";
            }
            else if ((DateTime.Compare(swipeTime, DateTime.Parse("6:00:00 PM")) >= 0) && DateTime.Compare(swipeTime, DateTime.Parse("11:59:59 PM")) <= 0)
            {
                strGreating = "Good Evening!";
            }

            return strGreating;
        }//------------------------
        #endregion
    }
}


