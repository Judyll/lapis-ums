using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms.Design;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RemoteClient
{
    [Designer(typeof(ScrollbarControlDesigner))]
    partial class ControlCustomScrollBar
    {
        #region Class Events Declarations

        public new event EventHandler Scroll = null;
        public event EventHandler ValueChanged = null;

        #endregion

        #region Class General Members Declarations

        protected Color _channelColor = Color.Empty;
        protected Image _upArrowImage = null;
        protected Image _downArrowImage = null;
        protected Image _thumbArrowImage = null;

        protected Image _thumbTopImage = null;
        protected Image _thumbTopSpanImage = null;
        protected Image _thumbBottomImage = null;
        protected Image _thumbBottomSpanImage = null;
        protected Image _thumbMiddleImage = null;

        protected Int32 _largeChange = 10;
        protected Int32 _smallChange = 1;
        protected Int32 _minimum = 0;
        protected Int32 _maximum = 100;
        protected Int32 _value = 0;
        private Int32 _clickPoint;

        protected Int32 _thumbTop = 0;

        protected Boolean _autoSize = false;

        private Boolean _thumbDown = false;
        private Boolean _thumbDragging = false;

        #endregion

        #region Class Properties Declarations

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("LargeChange")]
        public Int32 LargeChange
        {
            get { return _largeChange; }
            set
            {
                _largeChange = value;
                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("SmallChange")]
        public Int32 SmallChange
        {
            get { return _smallChange; }
            set
            {
                _smallChange = value;
                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("Minimum")]
        public Int32 Minimum
        {
            get { return _minimum; }
            set
            {
                _minimum = value;
                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("Maximum")]
        public Int32 Maximum
        {
            get { return _maximum; }
            set
            {
                _maximum = value;
                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("Value")]
        public Int32 Value
        {
            get { return _value; }
            set
            {
                _value = value;

                Int32 nTrackHeight = (this.Height - (UpArrowImage.Height + DownArrowImage.Height));
                Single fThumbHeight = ((Single)LargeChange / (Single)Maximum) * nTrackHeight;
                Int32 nThumbHeight = (Int32)fThumbHeight;

                if (nThumbHeight > nTrackHeight)
                {
                    nThumbHeight = nTrackHeight;
                    fThumbHeight = nTrackHeight;
                }
                if (nThumbHeight < 56)
                {
                    nThumbHeight = 56;
                    fThumbHeight = 56;
                }

                //figure out value
                Int32 nPixelRange = nTrackHeight - nThumbHeight;
                Int32 nRealRange = (Maximum - Minimum) - LargeChange;
                Single fPerc = 0.0f;
                if (nRealRange != 0)
                {
                    fPerc = (Single)_value / (Single)nRealRange;

                }

                Single fTop = fPerc * nPixelRange;
                _thumbTop = (Int32)fTop;


                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Channel Color")]
        public Color ChannelColor
        {
            get { return _channelColor; }
            set { _channelColor = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Up Arrow Graphic")]
        public Image UpArrowImage
        {
            get { return _upArrowImage; }
            set { _upArrowImage = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Up Arrow Graphic")]
        public Image DownArrowImage
        {
            get { return _downArrowImage; }
            set { _downArrowImage = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Up Arrow Graphic")]
        public Image ThumbTopImage
        {
            get { return _thumbTopImage; }
            set { _thumbTopImage = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Up Arrow Graphic")]
        public Image ThumbTopSpanImage
        {
            get { return _thumbTopSpanImage; }
            set { _thumbTopSpanImage = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Up Arrow Graphic")]
        public Image ThumbBottomImage
        {
            get { return _thumbBottomImage; }
            set { _thumbBottomImage = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Up Arrow Graphic")]
        public Image ThumbBottomSpanImage
        {
            get { return _thumbBottomSpanImage; }
            set { _thumbBottomSpanImage = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Up Arrow Graphic")]
        public Image ThumbMiddleImage
        {
            get { return _thumbMiddleImage; }
            set { _thumbMiddleImage = value; }
        }

        public override Boolean AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
                if (base.AutoSize)
                {
                    this.Width = _upArrowImage.Width;
                }
            }
        }

        #endregion

        #region Class Constructor

        public ControlCustomScrollBar()
        {
            InitializeComponent();

            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            _channelColor = Color.FromArgb(51, 166, 3);
            UpArrowImage = global::RemoteClient.Properties.Resources.uparrow;
            DownArrowImage = global::RemoteClient.Properties.Resources.downarrow;


            ThumbBottomImage = global::RemoteClient.Properties.Resources.ThumbBottom;
            ThumbBottomSpanImage = global::RemoteClient.Properties.Resources.ThumbSpanBottom;
            ThumbTopImage = global::RemoteClient.Properties.Resources.ThumbTop;
            ThumbTopSpanImage = global::RemoteClient.Properties.Resources.ThumbSpanTop;
            ThumbMiddleImage = global::RemoteClient.Properties.Resources.ThumbMiddle;

            this.Width = UpArrowImage.Width;
            base.MinimumSize = new Size(UpArrowImage.Width, UpArrowImage.Height + DownArrowImage.Height + GetThumbHeight());

            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CustomScrollbar_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CustomScrollbar_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CustomScrollbar_MouseUp);
        }

        #endregion

        #region Class Programmer-Defined Void Methods

        private Int32 GetThumbHeight()
        {
            Int32 nTrackHeight = (this.Height - (UpArrowImage.Height + DownArrowImage.Height));
            Single fThumbHeight = ((Single)LargeChange / (Single)Maximum) * nTrackHeight;
            Int32 nThumbHeight = (Int32)fThumbHeight;

            if (nThumbHeight > nTrackHeight)
            {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < 56)
            {
                nThumbHeight = 56;
                fThumbHeight = 56;
            }

            return nThumbHeight;
        }

        #endregion

        #region Class OnEvents Override Methods

        protected override void OnPaint(PaintEventArgs e)
        {

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            if (UpArrowImage != null)
            {
                e.Graphics.DrawImage(UpArrowImage, new Rectangle(new Point(0, 0), new Size(this.Width, UpArrowImage.Height)));
            }

            Brush oBrush = new SolidBrush(_channelColor);
            Brush oWhiteBrush = new SolidBrush(Color.FromArgb(255, 255, 255));

            //draw channel left and right border colors
            e.Graphics.FillRectangle(oWhiteBrush, new Rectangle(0, UpArrowImage.Height, 1, (this.Height - DownArrowImage.Height)));
            e.Graphics.FillRectangle(oWhiteBrush, new Rectangle(this.Width - 1, UpArrowImage.Height, 1, (this.Height - DownArrowImage.Height)));

            //draw channel
            e.Graphics.FillRectangle(oBrush, new Rectangle(1, UpArrowImage.Height, this.Width - 2, (this.Height - DownArrowImage.Height)));

            //draw thumb
            Int32 nTrackHeight = (this.Height - (UpArrowImage.Height + DownArrowImage.Height));
            Single fThumbHeight = ((Single)LargeChange / (Single)Maximum) * nTrackHeight;
            Int32 nThumbHeight = (Int32)fThumbHeight;

            if (nThumbHeight > nTrackHeight)
            {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < 56)
            {
                nThumbHeight = 56;
                fThumbHeight = 56;
            }

            Single fSpanHeight = (fThumbHeight - (ThumbMiddleImage.Height + ThumbTopImage.Height + ThumbBottomImage.Height)) / 2.0f;
            Int32 nSpanHeight = (Int32)fSpanHeight;

            Int32 nTop = _thumbTop;
            nTop += UpArrowImage.Height;

            //draw top
            e.Graphics.DrawImage(ThumbTopImage, new Rectangle(1, nTop, this.Width - 2, ThumbTopImage.Height));

            nTop += ThumbTopImage.Height;
            //draw top span
            Rectangle rect = new Rectangle(1, nTop, this.Width - 2, nSpanHeight);


            e.Graphics.DrawImage(ThumbTopSpanImage, 1.0f, (Single)nTop, (Single)this.Width - 2.0f, (Single)fSpanHeight * 2);

            nTop += nSpanHeight;
            //draw middle
            e.Graphics.DrawImage(ThumbMiddleImage, new Rectangle(1, nTop, this.Width - 2, ThumbMiddleImage.Height));


            nTop += ThumbMiddleImage.Height;
            //draw top span
            rect = new Rectangle(1, nTop, this.Width - 2, nSpanHeight * 2);
            e.Graphics.DrawImage(ThumbBottomSpanImage, rect);

            nTop += nSpanHeight;
            //draw bottom
            //e.Graphics.DrawImage(ThumbBottomImage, new Rectangle(1, nTop, this.Width - 2, nSpanHeight));            
            e.Graphics.DrawImage(ThumbBottomImage, new Rectangle(1, nTop, this.Width - 2, ThumbBottomImage.Height));

            if (DownArrowImage != null)
            {
                e.Graphics.DrawImage(DownArrowImage, new Rectangle(new Point(0, (this.Height - DownArrowImage.Height)), new Size(this.Width, DownArrowImage.Height)));
            }

        }
        #endregion

        #region Class Events Void Methods

        private void CustomScrollbar_MouseDown(object sender, MouseEventArgs e)
        {
            Point ptPoint = this.PointToClient(Cursor.Position);
            Int32 nTrackHeight = (this.Height - (UpArrowImage.Height + DownArrowImage.Height));
            Single fThumbHeight = ((Single)LargeChange / (Single)Maximum) * nTrackHeight;
            Int32 nThumbHeight = (Int32)fThumbHeight;

            if (nThumbHeight > nTrackHeight)
            {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < 56)
            {
                nThumbHeight = 56;
                fThumbHeight = 56;
            }

            Int32 nTop = _thumbTop;
            nTop += UpArrowImage.Height;


            Rectangle thumbrect = new Rectangle(new Point(1, nTop), new Size(ThumbMiddleImage.Width, nThumbHeight));
            if (thumbrect.Contains(ptPoint))
            {

                //hit the thumb
                _clickPoint = (ptPoint.Y - nTop);
                //MessageBox.Show(Convert.ToString((ptPoint.Y - nTop)));
                this._thumbDown = true;
            }

            Rectangle uparrowrect = new Rectangle(new Point(1, 0), new Size(UpArrowImage.Width, UpArrowImage.Height));
            if (uparrowrect.Contains(ptPoint))
            {

                Int32 nRealRange = (Maximum - Minimum) - LargeChange;
                Int32 nPixelRange = (nTrackHeight - nThumbHeight);
                if (nRealRange > 0)
                {
                    if (nPixelRange > 0)
                    {
                        if ((_thumbTop - SmallChange) < 0)
                            _thumbTop = 0;
                        else
                            _thumbTop -= SmallChange;

                        //figure out value
                        Single fPerc = (Single)_thumbTop / (Single)nPixelRange;
                        Single fValue = fPerc * (Maximum - LargeChange);

                        _value = (Int32)fValue;

                        if (ValueChanged != null)
                            ValueChanged(this, new EventArgs());

                        if (Scroll != null)
                            Scroll(this, new EventArgs());

                        Invalidate();
                    }
                }
            }

            Rectangle downarrowrect = new Rectangle(new Point(1, UpArrowImage.Height + nTrackHeight), new Size(UpArrowImage.Width, UpArrowImage.Height));
            if (downarrowrect.Contains(ptPoint))
            {
                Int32 nRealRange = (Maximum - Minimum) - LargeChange;
                Int32 nPixelRange = (nTrackHeight - nThumbHeight);
                if (nRealRange > 0)
                {
                    if (nPixelRange > 0)
                    {
                        if ((_thumbTop + SmallChange) > nPixelRange)
                            _thumbTop = nPixelRange;
                        else
                            _thumbTop += SmallChange;

                        //figure out value
                        Single fPerc = (Single)_thumbTop / (Single)nPixelRange;
                        Single fValue = fPerc * (Maximum - LargeChange);

                        _value = (Int32)fValue;

                        if (ValueChanged != null)
                            ValueChanged(this, new EventArgs());

                        if (Scroll != null)
                            Scroll(this, new EventArgs());

                        Invalidate();
                    }
                }
            }
        }

        private void CustomScrollbar_MouseUp(object sender, MouseEventArgs e)
        {
            this._thumbDown = false;
            this._thumbDragging = false;
        }

        private void MoveThumb(Int32 y)
        {
            Int32 nRealRange = Maximum - Minimum;
            Int32 nTrackHeight = (this.Height - (UpArrowImage.Height + DownArrowImage.Height));
            Single fThumbHeight = ((Single)LargeChange / (Single)Maximum) * nTrackHeight;
            Int32 nThumbHeight = (Int32)fThumbHeight;

            if (nThumbHeight > nTrackHeight)
            {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < 56)
            {
                nThumbHeight = 56;
                fThumbHeight = 56;
            }

            Int32 nSpot = _clickPoint;

            Int32 nPixelRange = (nTrackHeight - nThumbHeight);
            if (_thumbDown && nRealRange > 0)
            {
                if (nPixelRange > 0)
                {
                    Int32 nNewThumbTop = y - (UpArrowImage.Height + nSpot);

                    if (nNewThumbTop < 0)
                    {
                        _thumbTop = nNewThumbTop = 0;
                    }
                    else if (nNewThumbTop > nPixelRange)
                    {
                        _thumbTop = nNewThumbTop = nPixelRange;
                    }
                    else
                    {
                        _thumbTop = y - (UpArrowImage.Height + nSpot);
                    }

                    //figure out value
                    Single fPerc = (Single)_thumbTop / (Single)nPixelRange;
                    Single fValue = fPerc * (Maximum - LargeChange);
                    _value = (Int32)fValue;

                    Application.DoEvents();

                    Invalidate();
                }
            }
        }

        private void CustomScrollbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (_thumbDown == true)
            {
                this._thumbDragging = true;
            }

            if (this._thumbDragging)
            {

                MoveThumb(e.Y);
            }

            if (ValueChanged != null)
                ValueChanged(this, new EventArgs());

            if (Scroll != null)
                Scroll(this, new EventArgs());
        }

        #endregion

        internal class ScrollbarControlDesigner : System.Windows.Forms.Design.ControlDesigner
        {

            public override SelectionRules SelectionRules
            {
                get
                {
                    SelectionRules selectionRules = base.SelectionRules;
                    PropertyDescriptor propDescriptor = TypeDescriptor.GetProperties(this.Component)["AutoSize"];
                    if (propDescriptor != null)
                    {
                        Boolean autoSize = (Boolean)propDescriptor.GetValue(this.Component);
                        if (autoSize)
                        {
                            selectionRules = SelectionRules.Visible | SelectionRules.Moveable | SelectionRules.BottomSizeable | SelectionRules.TopSizeable;
                        }
                        else
                        {
                            selectionRules = SelectionRules.Visible | SelectionRules.AllSizeable | SelectionRules.Moveable;
                        }
                    }
                    return selectionRules;
                }
            }
        }
    }
}
