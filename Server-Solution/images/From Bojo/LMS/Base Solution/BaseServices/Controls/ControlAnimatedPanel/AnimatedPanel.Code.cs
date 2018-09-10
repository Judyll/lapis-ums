using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BaseServices.Control
{
    partial class AnimatedPanel
    {
        #region Class General Variable Declarations
        private Boolean _forExpand = false;       
        private Int32 _minHeight = 27;
        protected Int32 _maxHeight = 150;
        private Int32 _interval = 10;
        private Int32 _mouseX = 0;
        private Int32 _mouseY = 0;
        private Point _pointLast;        

        private Timer tmrMain = new Timer();
        #endregion

        #region Class Constructor
        public AnimatedPanel()
        {
            this.InitializeComponent();

            this.Load += new EventHandler(ClassLoad);
            this.pbxControl.MouseEnter += new EventHandler(pbxControlMouseEnter);
            this.pbxControl.MouseLeave += new EventHandler(pbxControlMouseLeave);
            this.pbxControl.Click += new EventHandler(pbxControlClick);
            this.tmrMain.Tick += new EventHandler(tmrMainTick);
            this.pnlHeader.MouseDown += new MouseEventHandler(pnlHeaderMouseDown);
            this.pnlHeader.MouseUp += new MouseEventHandler(pnlHeaderMouseUp);
            this.pnlHeader.MouseMove += new MouseEventHandler(pnlHeaderMouseMove);            
        }
         
        #endregion

        #region Class Event Void Procedures

        //##########################################CLASS AnimatedPanel EVENTS####################################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            tmrMain.Interval = 30;
        } //-------------------------------
        //#########################################END CLASS AnimatedPanel EVENTS#################################################

        //################################################PICTUREBOX pbxControl EVENTS############################################
        //event is raised when the mouse enters
        private void pbxControlMouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).BorderStyle = BorderStyle.FixedSingle;
        } //---------------------------

        //event is raised when the mouse leaves
        private void pbxControlMouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).BorderStyle = BorderStyle.None;
        } //-------------------------

        //event is raised when the picture box is clicked
        private void pbxControlClick(object sender, EventArgs e)
        {
            tmrMain.Start();
        } //-------------------------
        //###########################################END PICTUREBOX pbxControl EVENTS###############################################

        //##########################################TIMER tmrMain EVENTS#############################################################
        //event is raised when the timer ticks
        private void tmrMainTick(object sender, EventArgs e)
        {
            if (_forExpand)
            {
                this.Height += _interval;

                if (this.Height >= _maxHeight)
                {
                    this.Height = _maxHeight;
                    tmrMain.Stop();
                    _forExpand = false;
                    this.pbxControl.Image = global::BaseServices.Properties.Resources.cascade;                    
                }
            }
            else
            {
                this.Height -= _interval;

                if (this.Height <= _minHeight)
                {
                    this.Height = _minHeight;
                    tmrMain.Stop();
                    _forExpand = true;

                    this.pbxControl.Image = global::BaseServices.Properties.Resources.expand;
                }
            }
        } //-----------------------------------------
        //########################################END TIMER tmrMain EVENTS############################################################

        //#########################################PANEL pnlHeader EVENTS#############################################################
        //event is raised when the mouse is moved
        private void pnlHeaderMouseMove(object sender, MouseEventArgs e)
        {
            if (((Panel)sender).Capture)
            {
                Point location = this.Location;

                Point point = PointToScreen(new Point(e.X, e.Y));

                if (point != _pointLast)
                {
                    if (point.X > _pointLast.X)
                    {
                        location.X += (point.X - _pointLast.X);
                    }
                    else
                    {
                        location.X -= (_pointLast.X - point.X);
                    }

                    if (point.Y > _pointLast.Y)
                    {
                        location.Y += (point.Y - _pointLast.Y);
                    }
                    else
                    {
                        location.Y -= (_pointLast.Y - point.Y);
                    }

                    _pointLast = point;
                }

                this.Location = location;
                this.BorderStyle = BorderStyle.FixedSingle;

            }
        } //----------------------------------

        //event is raised when the mouse is up
        private void pnlHeaderMouseUp(object sender, MouseEventArgs e)
        {
            ((Panel)sender).Capture = false;
            this.BorderStyle = BorderStyle.None;
        } //------------------------------

        //event is raised when the mouse is down
        private void pnlHeaderMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ((Panel)sender).Capture = true;

                _mouseX = e.Location.X;
                _mouseY = e.Location.Y;

                _pointLast = PointToScreen(new Point(e.X, e.Y));
            }
        } //-------------------------------------
        //########################################END PANEL pnlHeader EVENTS##########################################################

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure initializes the controls
        public void InitializeControls(Boolean defaultExpanded)
        {            
            _forExpand = defaultExpanded;
            tmrMain.Start();
        } //---------------------------

        //this procedure sets the move capability of the control
        public void DisableMoveCapability()
        {
            this.pnlHeader.MouseDown -= new MouseEventHandler(pnlHeaderMouseDown);
            this.pnlHeader.MouseUp -= new MouseEventHandler(pnlHeaderMouseUp);
            this.pnlHeader.MouseMove -= new MouseEventHandler(pnlHeaderMouseMove);            
        } //------------------------------
        #endregion
    }
}
