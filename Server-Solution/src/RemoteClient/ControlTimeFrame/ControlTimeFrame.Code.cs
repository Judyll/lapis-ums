using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;
using System.Data;

namespace RemoteClient
{
    partial class ControlTimeFrame
    {
        #region Class Enum Definitions
        public enum SelectedReadOnlyIndex
        {
            Selected = 0,
            ReadOnly = 1
        }

        public enum SelectedValue
        {
            Selected = 1,
            NotSelected = 0
        }

        public enum ReadOnlyValue
        {
            ReadOnly = 1,
            NotReadOnly = 0
        }
        #endregion

        #region Class Nested Classes

        #region Class TimeToolTip Definition
        internal class TimeToolTip
        {
            private String _text;
            public String Text
            {
                get { return _text; }
                set { _text = value; }
            }
        }
        #endregion

        #region Class TimeFrameObject Definition
        internal class TimeFrameObject
        {
            public RectangleF Bounds;
            public Boolean Highlighted = false;

            public TimeFrameObject(RectangleF rec)
            {
                Bounds = rec;
            }

            private Boolean _selected = false;
            public virtual Boolean Selected
            {
                get { return _selected; }
                set { _selected = value; }
            }

            private Boolean _isReadOnly = false;
            public Boolean IsReadOnly
            {
                get { return _isReadOnly; }
                set { _isReadOnly = value; }
            }

            public Boolean Contains(Single x, Single y)
            {
                return Bounds.Contains(x, y);
            }

            public Boolean Contains(PointF p)
            {
                return this.Contains(p.X, p.Y);
            }

        }
        #endregion

        #region Class Cell Definition
        internal class Cell : TimeFrameObject
        {
            public Int32 X;
            public Int32 Y;

            public Cell(RectangleF rec, Int32 x, Int32 y)
                : base(rec)
            {
                X = x;
                Y = y;
            }

            public Cell(Int32 x, Int32 y)
                : this(new RectangleF(0, 0, 0, 0), x, y)
            {
            }            
        }
        #endregion

        #region Class WeekDay Definition
        internal class WeekDay : TimeFrameObject
        {
            public Int32 Column;

            //determines if the whole column of the specified day of the week is selected or 
            //selects the whole column of the specified day of the week
            public override Boolean Selected
            {
                get
                {
                    Int32 rowCount = 0;
                    for (Int32 i = 0; i < s_timeSlotTable.Rows.Count; i++)
                    {
                        if (_cellMatrix[i, Column].Selected || _cellMatrix[i, Column].IsReadOnly)
                        {
                            ++rowCount;
                        }
                    }

                    return (rowCount == s_timeSlotTable.Rows.Count);
                }
                set
                {
                    for (Int32 i = 0; i < s_timeSlotTable.Rows.Count; i++)
                    {
                        if (!_cellMatrix[i, Column].IsReadOnly)
                        {
                            _cellMatrix[i, Column].Selected = value;
                        }
                    }
                }
            }

            public WeekDay(RectangleF rec, Int32 column)
                : base(rec)
            {
                Column = column;
            }

            public WeekDay(Int32 column)
                : this(new RectangleF(0, 0, 0, 0), column)
            {

            }
        }
        #endregion

        #region Class TimeSlot
        internal class TimeSlot : TimeFrameObject
        {
            public Int32 Row;            

            //determines if the whole row in the specified time slot is selected or
            //select the whole row in the specified time slot
            public override Boolean Selected
            {
                get
                {
                    Int32 colCount = 0;
                    for (Int32 i = 0; i < s_weekDayTable.Rows.Count; i++)
                    {
                        if (_cellMatrix[Row, i].Selected || _cellMatrix[Row, i].IsReadOnly)
                        {
                            ++colCount;
                        }
                    }

                    return (colCount == s_weekDayTable.Rows.Count);
                }
                set
                {
                    for (Int32 i = 0; i < s_weekDayTable.Rows.Count; i++)
                    {
                        if (!_cellMatrix[Row, i].IsReadOnly)
                        {
                            _cellMatrix[Row, i].Selected = value;
                        }
                    }
                }
            }

            public TimeSlot(Int32 row)
                : this(new RectangleF(0, 0, 0, 0), row)
            {
            }
            public TimeSlot(RectangleF rec, Int32 row)
                : base(rec)
            {
                Row = row;
            }
        }
        #endregion

        #region Class TopLeftCell
        internal class TopLeftCell : TimeFrameObject
        {
            //determines if the top left cell is selected or
            //select the whole region of the time slot and the week day cells
            public override bool Selected
            {
                get
                {
                    Int32 count = 0;
                    for (Int32 i = 0; i < s_timeSlotTable.Rows.Count; i++)
                    {
                        for (Int32 j = 0; j < s_weekDayTable.Rows.Count; j++)
                        {
                            if (_cellMatrix[i, j].Selected || _cellMatrix[i, j].IsReadOnly)
                            {
                                ++count;
                            }
                        }
                    }

                    return (count == (s_timeSlotTable.Rows.Count * s_weekDayTable.Rows.Count));
                }
                set
                {
                    for (Int32 i = 0; i < s_timeSlotTable.Rows.Count; i++)
                    {
                        for (Int32 j = 0; j < s_weekDayTable.Rows.Count; j++)
                        {
                            if (!_cellMatrix[i, j].IsReadOnly)
                            {
                                _cellMatrix[i, j].Selected = value;
                            }
                        }
                    }
                }
            }

            public TopLeftCell(RectangleF rec)
                : base(rec)
            {
            }
            public TopLeftCell()
                : base(new RectangleF(0, 0, 0, 0))
            {
            }


        }
        #endregion

        #endregion

        #region Class Constants Variable Declarations

        private const Int32 c_ToolTipXPad = 12;

        private const Int32 c_LeftMargin = 50;
        private const Int32 c_RightMargin = 15;
        private const Int32 c_Header = 20;
        private const Int32 c_Footer = 0;

        private const Single c_CellBorderWidth = 3F;

        private const Int32 c_MaxTimeDisplay = 26;
        private const Int32 c_timeInterval = 10;

        #endregion

        #region Class Static Variable Declarations

        private static TimeSpan s_TimeSpan = new TimeSpan(1, 0, 0, 0, 0);

        private static DataTable s_weekDayTable;
        private static DataTable s_timeSlotTable;
        private static DataTable s_readOnlySlotTable;

        #endregion

        #region Class Member Variable Declarations  

        private Int32 _leftMargin = c_LeftMargin;
        private Int32 _rightMargin = c_RightMargin;
        private Int32 _header = c_Header;
        private Int32 _footer = c_Footer;

        private Int32 _startTimeDisplay = 0;
        private Int32 _timeInterval = c_timeInterval;

        internal static Cell[,] _cellMatrix;

        private Timer _hoverTimerStart = new Timer();
        private Timer _hoverTimerStop = new Timer();
        private MouseEventArgs _lastMouseHover = null;

        private WeekDay[] _days;
        private TimeSlot[] _timeSlots;
        private TopLeftCell _topLeft;

        private RectangleF _grid;

        private Single _gridIncX = 0.0F;
        private Single _gridIncY = 0.0F;

        private TimeToolTip _timeToolTip = null;

        private TimeFrameObject _timeObjLastHighlighted = null;
        private TimeFrameObject _timeObjLastSelected = null;

        private SolidBrush _sbBack = new SolidBrush(Color.Silver);
        private SolidBrush _sbGridBack = new SolidBrush(Color.White);
        private SolidBrush _sbGridForeColor = new SolidBrush(Color.LightGray);
        private SolidBrush _sbInfoBack = new SolidBrush(SystemColors.Info);
        private SolidBrush _sbInfoText = new SolidBrush(SystemColors.InfoText);
        private SolidBrush _sbHotTrack = new SolidBrush(Color.OrangeRed);
        private SolidBrush _sbSelected = new SolidBrush(Color.DarkSlateBlue);
        private SolidBrush _sbDaysForeColor = new SolidBrush(Color.Maroon);
        private SolidBrush _sbTimeBackColor = new SolidBrush(Color.Gold);
        private SolidBrush _sbTimeForeColor = new SolidBrush(Color.Black);
        private SolidBrush _sbTopLeftBackColor = new SolidBrush(Color.Maroon);
        private SolidBrush _sbReadOnlyColor = new SolidBrush(Color.DimGray);

        private ControlCustomScrollBar _scrollBar = new ControlCustomScrollBar();

        #endregion

        #region Class General Properties Declarations

        public Int32 TimeInterval
        {
            get { return c_timeInterval; }
        }

        private Int32 _numDays;
        public Int32 NumberOfDaysDisplayed
        {
            get { return _numDays; }
        }

        private Int32 _numTimeSlots;
        public Int32 NumberOfTimeSlotsDisplayed
        {
            get { return _numTimeSlots; }
        }

        protected override Size DefaultSize
        {
            get
            {
                return new Size(310, 160);
            }
        }        

        private String _weekDayIdFieldName = "week_id";
        public String WeekDayIdFieldName
        {
            get { return _weekDayIdFieldName; }
            set { _weekDayIdFieldName = value; }
        }

        private String _weekDayDescriptionFieldName = "week_description";
        public String WeekDayDescriptionFieldName
        {
            get { return _weekDayDescriptionFieldName; }
            set { _weekDayDescriptionFieldName = value; }
        }

        private String _weekDayAcronymFieldName = "acronym";
        public String WeekDayAcronymFieldName
        {
            get { return _weekDayAcronymFieldName; }
            set { _weekDayAcronymFieldName = value; }
        }

        private String _timeIdFieldName = "time_id";
        public String TimeIdFieldName
        {
            get { return _timeIdFieldName; }
            set { _timeIdFieldName = value; }
        }

        private String _timeDescriptionFieldName = "time_description";
        public String TimeDescriptionFieldName
        {
            get { return _timeDescriptionFieldName; }
            set { _timeDescriptionFieldName = value; }
        }

        private String _readOnlySubjectCodeFieldName = "subject_code";
        public String ReadOnlySubjectCodeFieldName
        {
            get { return _readOnlySubjectCodeFieldName; }
            set { _readOnlySubjectCodeFieldName = value; }
        }
        
        /// <summary>
        /// Get or set the time frames in a jagged array with the order:\nFirst array: use for the number of days\nSecond array: used for the number of time slots\nThird array: used to determine if the slot is selected or readonly\nBefore setting a value to this property, call first the method InitializeTimeFrameTables(DataTable weekDayTable, DataTable timeSlotTable, Int32 timeInterval)
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        [Description("Get or set the time frames in a jagged array with the order:\nFirst array: use for the number of days\nSecond array: used for the number of time slots\nThird array: used to determine if the slot is selected or readonly\nBefore setting a value to this property, call first the method InitializeTimeFrameTables(DataTable weekDayTable, DataTable timeSlotTable, Int32 timeInterval)")]
        private Int32[][][] _tFrames;
        public Int32[][][] TimeFrames
        {
            get
            {
                //initialize days array
                _tFrames = new Int32[_numDays][][];

                //initialize the time array
                for (Int32 i = 0; i < _numDays; i++)
                {
                    _tFrames[i] = new Int32[_numTimeSlots][];

                    //initialize the selected and readonly array
                    for (Int32 j = 0; j < _numTimeSlots; j++)
                    {
                        _tFrames[i][j] = new Int32[2];
                    } //--------------------
                } //-----------------------------

                //sets the timeframe array
                for (Int32 i = 0; i < _numDays; i++)
                {
                    for (Int32 j = 0; j < _numTimeSlots; j++)
                    {
                        if (_cellMatrix[j, i].Selected)
                        {
                            _tFrames[i][j][(Int32)SelectedReadOnlyIndex.Selected] = (Int32)SelectedValue.Selected;
                        }
                        else
                        {
                            _tFrames[i][j][(Int32)SelectedReadOnlyIndex.Selected] = (Int32)SelectedValue.NotSelected;
                        }

                        if (_cellMatrix[j, i].IsReadOnly)
                        {
                            _tFrames[i][j][(Int32)SelectedReadOnlyIndex.ReadOnly] = (Int32)ReadOnlyValue.ReadOnly;
                        }
                        else
                        {
                            _tFrames[i][j][(Int32)SelectedReadOnlyIndex.ReadOnly] = (Int32)ReadOnlyValue.NotReadOnly;
                        }
                    }
                } //-----------------------------

                return _tFrames;
            }

            set
            {
                _tFrames = value;

                //sets the timeframe array
                for (Int32 i = 0; i < _numDays; i++)
                {
                    for (Int32 j = 0; j < _numTimeSlots; j++)
                    {
                        if (_tFrames[i][j][(Int32)SelectedReadOnlyIndex.Selected] == (Int32)SelectedValue.Selected)
                        {
                            _cellMatrix[j, i].Selected = true;
                        }
                        else
                        {
                            _cellMatrix[j, i].Selected = false;
                        }

                        if (_tFrames[i][j][(Int32)SelectedReadOnlyIndex.ReadOnly] == (Int32)ReadOnlyValue.ReadOnly)
                        {
                            _cellMatrix[j, i].IsReadOnly = true;
                        }
                        else
                        {
                            _cellMatrix[j, i].IsReadOnly = false;
                        }
                    }
                } //------------------------------

                this.OnResize(new EventArgs());
            }

        }
        
        #endregion

        #region Class Constructor
        public ControlTimeFrame()
        {
            InitializeComponent();

            this.IntializeTimeFrameTables();
            
            _hoverTimerStart.Stop();
            _hoverTimerStart.Interval = 50;
            _hoverTimerStop.Stop();
            _hoverTimerStop.Interval = 4000;

            _hoverTimerStart.Tick += new EventHandler(_hoverTimerStartTick);
            _hoverTimerStop.Tick += new EventHandler(_hoverTimerStopTick);

            this.SetLimits();

            _topLeft = new TopLeftCell();

            this.InitializeScrollBar();

        }       

        #endregion

        #region Class OnEvent Override Procedures

        protected override void OnLoad(EventArgs e)
        {
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnResize(EventArgs e)
        {
            
            if (this.Width < DefaultSize.Width)
            {
                this.Width = DefaultSize.Width;
            }

            if (this.Height < DefaultSize.Height)
            {
                this.Height = DefaultSize.Height;
            }           

            _grid = new RectangleF(_leftMargin, _header,
                this.Width - (_leftMargin + _rightMargin + c_CellBorderWidth),
                this.Height - (_footer + _header + c_CellBorderWidth));

            if (_topLeft == null)
            {
                _topLeft = new TopLeftCell();
            }

            _topLeft.Bounds = new RectangleF(0, 0, _grid.X, _grid.Y);

            _gridIncX = (_grid.Width - c_CellBorderWidth) / _numDays;
            _gridIncY = (_grid.Height - c_CellBorderWidth) / c_MaxTimeDisplay;

            //resets the days header
            for (Single i = 0; i < _numDays; i++)
            {
                _days[(Int32)i].Bounds = new RectangleF(_grid.X + (i * _gridIncX), 0.0F, _gridIncX, _header);
            } //----------------------------

            Int32 timeCount = 0;

            //resets the time row
            for (Single i = _startTimeDisplay; i < ((_startTimeDisplay + c_MaxTimeDisplay) <= _numTimeSlots ?
                _startTimeDisplay + c_MaxTimeDisplay : _numTimeSlots); i++)
            {
                _timeSlots[(Int32)i].Bounds = new RectangleF(0.0F, _grid.Y + (timeCount * _gridIncY), _leftMargin, _gridIncY);

                timeCount++;
            } //-----------------------            

            timeCount = 0;

            //resets the cell sizes
            for (Int32 i = _startTimeDisplay; i < ((_startTimeDisplay + c_MaxTimeDisplay) <= _numTimeSlots ?
                _startTimeDisplay + c_MaxTimeDisplay : _numTimeSlots); i++)
            {
                for (Int32 j = 0; j < _numDays; j++)
                {
                    _cellMatrix[i, j].Bounds = new RectangleF(_grid.X + (j * _gridIncX) + c_CellBorderWidth,
                        _grid.Y + (timeCount * _gridIncY) + c_CellBorderWidth, 
                        _gridIncX - c_CellBorderWidth, _gridIncY - c_CellBorderWidth);
                }

                timeCount++;
            } //--------------------

            _scrollBar.Location = new Point(this.Width - _rightMargin, _header);
            _scrollBar.Size = new Size((Int32)_scrollBar.Size.Width, (Int32)_grid.Height);
            _scrollBar.LargeChange = (_scrollBar.Maximum / _scrollBar.Height) + (c_MaxTimeDisplay - 1);

            this.Invalidate(true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.Draw(e.Graphics);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            TimeFrameObject tfo = this.GetTimeFrameObject(e);

            if (tfo != null && e.Button == MouseButtons.Left && !tfo.IsReadOnly)
            {
                 tfo.Selected = !tfo.Selected;
                _timeObjLastSelected = tfo;

                this.Invalidate(true);
            
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            ClearToolTopState();
            TimeFrameObject tfo = GetTimeFrameObject(e);

            if (e.Button == MouseButtons.Left)
            {
                if (tfo is Cell) //selects the cells using a drag selection in the cells
                {
                    Cell cellNewSelected = (Cell)tfo;

                    if (_timeObjLastSelected is Cell)
                    {
                        Cell cellLastSelected = (Cell)_timeObjLastSelected;

                        if (cellLastSelected != cellNewSelected)
                        {
                            SelectCellBlock(cellLastSelected, cellNewSelected);
                        }
                    }
                }
                else if (tfo is TimeSlot) //selects the cells using a drag selection in the time slots
                {
                    TimeSlot tsNewSelected = (TimeSlot)tfo;

                    if (_timeObjLastSelected is TimeSlot)
                    {
                        TimeSlot tsLastSelected = (TimeSlot)_timeObjLastSelected;

                        if (tsLastSelected != tsNewSelected)
                        {
                            if (tsNewSelected.Row > tsLastSelected.Row)
                            {
                                for (int j = tsLastSelected.Row; j < tsNewSelected.Row; ++j)
                                {
                                    _timeSlots[j].Selected = tsLastSelected.Selected;
                                }
                            }
                            else if (tsNewSelected.Row < tsLastSelected.Row)
                            {
                                for (int j = tsNewSelected.Row; j < tsLastSelected.Row; ++j)
                                {
                                    _timeSlots[j].Selected = tsLastSelected.Selected;
                                }
                            }
                        }
                    }
                }
                else if (tfo is WeekDay) //selects the cells using a drag selection in the week day slots
                {
                    WeekDay dNewSelected = (WeekDay)tfo;

                    if (_timeObjLastSelected is WeekDay)
                    {
                        WeekDay dLastSelected = (WeekDay)_timeObjLastSelected;

                        if (dLastSelected != dNewSelected)
                        {
                            if (dNewSelected.Column > dLastSelected.Column)
                            {
                                for (int i = dLastSelected.Column; i < dNewSelected.Column; ++i)
                                {
                                    _days[i].Selected = dLastSelected.Selected;
                                }
                            }
                            else if (dNewSelected.Column < dLastSelected.Column)
                            {
                                for (int i = dNewSelected.Column; i < dLastSelected.Column; ++i)
                                {
                                    _days[i].Selected = dLastSelected.Selected;
                                }
                            }
                        }
                    }
                }
            }

            if (_timeObjLastHighlighted != null)
            {
                _timeObjLastHighlighted.Highlighted = false;
            }
            if (tfo != null)
            {
                tfo.Highlighted = true;
                _timeObjLastHighlighted = tfo;
            }

            if (e.Button == MouseButtons.None)
            {
                if (_grid.Contains(e.X, e.Y))
                {
                    _lastMouseHover = e;
                    _hoverTimerStart.Start();
                }
            }

            this.Invalidate(true);
        }


        #endregion

        #region ToolTip Event Void Procedures and Methods

        private void _hoverTimerStartTick(object sender, EventArgs e)
        {
            if (_lastMouseHover != null)
            {
                if (_grid.Contains(_lastMouseHover.X, _lastMouseHover.Y))
                {
                    _hoverTimerStart.Stop();
                    _hoverTimerStop.Start();
                    _timeToolTip = new TimeToolTip();
                    _timeToolTip.Text = GetToolTipText(_lastMouseHover);

                    this.Invalidate(true);
                }
            }
        }

        private void _hoverTimerStopTick(object sender, EventArgs e)
        {
            if (_grid.Contains(_lastMouseHover.X, _lastMouseHover.Y))
            {
                this.ClearToolTopState();
                this.Invalidate(true);
            }
        }

        private void ClearToolTopState()
        {
            _lastMouseHover = null;
            _timeToolTip = null;
            _hoverTimerStart.Stop();
            _hoverTimerStop.Stop();
        }

        private String GetToolTipText(MouseEventArgs e)
        {
            String strTip = String.Empty;

            if (_grid.Contains(e.X, e.Y) && ((Int32)((e.Y - _header) / _gridIncY) + _startTimeDisplay) < _numTimeSlots &&
                (Int32)(((e.X - c_CellBorderWidth) - _leftMargin) / _gridIncX) < _numDays)
            {
                Cell cell = (Cell)this.GetTimeFrameObject(e);

                if (cell.Selected)
                {
                    Int32 end = 0;
                    Int32 start = 0;

                    for (end = cell.X; end < _numTimeSlots; ++end)
                    {
                        if (!_cellMatrix[end, cell.Y].Selected || 
                            _cellMatrix[end, cell.Y].IsReadOnly)
                        {
                            break;
                        }
                    }

                    end--;

                    for (start = cell.X; start >= 0; --start)
                    {
                        if (!_cellMatrix[start, cell.Y].Selected || 
                            _cellMatrix[start, cell.Y].IsReadOnly)
                        {
                            break;
                        }
                    }

                    start++;

                    DataRow startRow = s_timeSlotTable.Rows[start];
                    DataRow endRow = s_timeSlotTable.Rows[end];
                    DataRow dayRow = s_weekDayTable.Rows[cell.Y];

                    String strStart = String.Empty;
                    String strEnd = String.Empty;

                    DateTime dtStart;

                    if (DateTime.TryParse(startRow[_timeDescriptionFieldName].ToString(), out dtStart))
                    {
                        strStart = dtStart.ToString("t");
                    }

                    DateTime dtEnd;

                    if (DateTime.TryParse(endRow[_timeDescriptionFieldName].ToString(), out dtEnd))
                    {
                        if (start == end)
                        {
                            strEnd = dtEnd.AddMinutes((Double)(_timeInterval - 1)).ToString("t");
                        }
                        else
                        {
                            strEnd = dtEnd.ToString("t");
                        }
                    }                   

                    strTip = dayRow[_weekDayDescriptionFieldName].ToString() + ", " +
                        ((String.IsNullOrEmpty(strStart)) ? "--" : strStart) + " to " + 
                        ((String.IsNullOrEmpty(strEnd)) ? "--" : strEnd);
                }
                else if (cell.IsReadOnly)
                {
                    //strTip = "ReadOnly " + cell.X.ToString() + " " + cell.Y.ToString(); //cell.X - for the time slot, cell.Y - for the week slot
                    strTip = "Locked by: " + this.GetReadOnlySubjectCode((Byte)cell.X, (Byte)cell.Y);
                }
            }
            

            return strTip;
        }
        #endregion

        #region Custom ScrollBar Event Procedures and Methods

        //this procedure initializes the scrollbar
        private void InitializeScrollBar()
        {
            this.Controls.Add(_scrollBar);

            _scrollBar.ChannelColor = Color.GhostWhite;
            _scrollBar.Minimum = 0;
            _scrollBar.Maximum = _numTimeSlots - 1;
            _scrollBar.LargeChange = (_scrollBar.Maximum / _scrollBar.Height) + (c_MaxTimeDisplay - 1);
            _scrollBar.SmallChange = _timeInterval;
            _scrollBar.Value = 0;
            _scrollBar.Scroll += new EventHandler(_scrollBarScroll);
        }

        private void _scrollBarScroll(object sender, EventArgs e)
        {
            _startTimeDisplay = _scrollBar.Value;
            _scrollBar.Invalidate(true);
            this.OnResize(e);
        } //-------------------------------

        #endregion

        #region Programmer-Defined Procedures and Functions

        private void SetLimits()
        {
            _numDays = s_weekDayTable.Rows.Count;
            _numTimeSlots = s_timeSlotTable.Rows.Count;

            _days = new WeekDay[_numDays];
            _timeSlots = new TimeSlot[_numTimeSlots];

            _cellMatrix = new Cell[_numTimeSlots, _numDays];

            //creates cells
            for (Int32 i = 0; i < _numTimeSlots; i++)
            {
                for (Int32 j = 0; j < _numDays; j++)
                {
                    _cellMatrix[i, j] = new Cell(i, j);
                }
            } //-----------------------

            //create timeslots
            for (Int32 i = 0; i < _numTimeSlots; i++)
            {
                _timeSlots[i] = new TimeSlot(i);
            } //-------------------------

            //create days
            for (Int32 i = 0; i < _numDays; i++)
            {
                _days[i] = new WeekDay(i);
            } //------------------------
        }

        private TimeFrameObject GetTimeFrameObject(MouseEventArgs e)
        {
            TimeFrameObject tfo = null;

            if (_grid.Contains(e.X, e.Y) && ((Int32)((e.Y - _header) / _gridIncY) + _startTimeDisplay) < _numTimeSlots &&
                (Int32)(((e.X - c_CellBorderWidth) - _leftMargin) / _gridIncX) < _numDays)
            {
                tfo = _cellMatrix[(Int32)((e.Y - _header) / _gridIncY) + _startTimeDisplay, 
                    (Int32)(((e.X - c_CellBorderWidth) - _leftMargin) / _gridIncX)];
            }
            else if ((e.X > _grid.X) && (e.X < (_grid.X + _grid.Width)) && (e.Y < _grid.Y))
            {
                tfo = (WeekDay)_days[(Int32)(((e.X - c_CellBorderWidth) - _leftMargin) / _gridIncX)];
            }
            else if ((e.X < _grid.X) && (e.Y < (_grid.Y + _grid.Height)) && (e.Y > _grid.Y) &&
                (Int32)((e.Y - _header) / _gridIncY) + _startTimeDisplay < _numTimeSlots)
            {
                tfo = (TimeFrameObject)_timeSlots[(Int32)((e.Y - _header) / _gridIncY) + _startTimeDisplay];
            }
            else if (_topLeft.Contains(e.X, e.Y))
            {
                tfo = _topLeft;
            }

            return tfo;
        }

        //this procedure selects the cell block where the selection is a drag selection within the cells only
        private void SelectCellBlock(Cell cellLast, Cell cellNew)
        {
            if (cellNew.X < cellLast.X)
            {
                if (cellNew.Y < cellLast.Y)
                {
                    for (Int32 i = cellNew.X; i <= cellLast.X; ++i)
                    {
                        for (int j = cellNew.Y; j <= cellLast.Y; ++j)
                        {
                            if (!_cellMatrix[i, j].IsReadOnly)
                            {
                                _cellMatrix[i, j].Selected = cellLast.Selected;                                
                            }
                        }
                    }
                }
                else
                {
                    for (int i = cellNew.X; i <= cellLast.X; ++i)
                    {
                        for (int j = cellLast.Y; j <= cellNew.Y; ++j)
                        {
                            if (!_cellMatrix[i, j].IsReadOnly)
                            {
                                _cellMatrix[i, j].Selected = cellLast.Selected;
                            }
                        }
                    }
                }
            }
            else
            {
                if (cellNew.Y < cellLast.Y)
                {
                    for (int i = cellLast.X; i <= cellNew.X; ++i)
                    {
                        for (int j = cellNew.Y; j <= cellLast.Y; ++j)
                        {
                            if (!_cellMatrix[i, j].IsReadOnly)
                            {
                                _cellMatrix[i, j].Selected = cellLast.Selected;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = cellLast.X; i <= cellNew.X; ++i)
                    {
                        for (int j = cellLast.Y; j <= cellNew.Y; ++j)
                        {
                            if (!_cellMatrix[i, j].IsReadOnly)
                            {
                                _cellMatrix[i, j].Selected = cellLast.Selected;
                            }
                        }
                    }
                }
            }
        } //-------------------------  


        private void Draw(Graphics g)
        {
            //draw the background panel
            g.FillRectangle(_sbBack, 0, 0, this.Width, this.Height);

            //draw the time slot background panel
            g.FillRectangle(_sbGridBack, _grid);

            //draw the time background panel
            g.FillRectangle(_sbTimeBackColor, 0, _grid.Y, _leftMargin, _grid.Height);

            //draw the top left corner background panel
            g.FillRectangle(_sbTopLeftBackColor, 0, 0, _leftMargin, _grid.Y);

            this.DrawTopLeft(g);
            this.DrawDays(g);
            this.DrawTimes(g);
            this.DrawGrid(g);
            this.DrawToolTip(g);
        }

        private void DrawTopLeft(Graphics g)
        {
            if (_timeObjLastHighlighted != null)
            {
                if (_timeObjLastHighlighted is TopLeftCell)
                {
                    g.FillRectangle(_sbHotTrack, _timeObjLastHighlighted.Bounds);
                }
            }
        }

        private void DrawDays(Graphics g)
        {
            Font font = new Font(Control.DefaultFont.FontFamily, this.FindEmSize(g, _days[0].Bounds, true), FontStyle.Bold);

            Int32 i = 0;

            foreach (DataRow wkRow in s_weekDayTable.Rows)
            {
                WeekDay d = _days[i];
                SizeF sf = g.MeasureString(wkRow[_weekDayAcronymFieldName].ToString(), font);

                if (d.Highlighted)
                {
                    g.FillRectangle(_sbHotTrack, d.Bounds);
                }

                g.DrawString(wkRow[_weekDayAcronymFieldName].ToString(), font, _sbDaysForeColor, 
                    this.CenterRectangle(d.Bounds, sf, true).Location);

                i++;
            }
        }

        private void DrawTimes(Graphics g)
        {
            Font font = new Font(Control.DefaultFont.FontFamily, this.FindEmSize(g, _days[0].Bounds, false), FontStyle.Bold);

            for (Int32 i = _startTimeDisplay; i < ((_startTimeDisplay + c_MaxTimeDisplay) <= _numTimeSlots ?
                _startTimeDisplay + c_MaxTimeDisplay : _numTimeSlots); i++)
            {
                DataRow tmRow = s_timeSlotTable.Rows[i];

                TimeSlot ts = _timeSlots[i];
                SizeF sf = g.MeasureString(tmRow[_timeDescriptionFieldName].ToString(), font);

                if (ts.Highlighted)
                {
                    g.FillRectangle(_sbHotTrack, ts.Bounds);
                }

                g.DrawString(tmRow[_timeDescriptionFieldName].ToString(), font, _sbTimeForeColor,
                    this.CenterRectangle(ts.Bounds, sf, false).Location);
            }
        }        

        private void DrawGrid(Graphics g)
        {
            for (Int32 i = _startTimeDisplay; i < ((_startTimeDisplay + c_MaxTimeDisplay) <= _numTimeSlots ?
                _startTimeDisplay + c_MaxTimeDisplay : _numTimeSlots); i++)
            {
                for (Int32 j = 0; j < _numDays; j++)
                {
                    if (_cellMatrix[i, j].Highlighted)
                    {
                        g.FillRectangle(_sbHotTrack, _cellMatrix[i, j].Bounds);
                    }
                    else if (_cellMatrix[i, j].Selected && !_cellMatrix[i, j].IsReadOnly)
                    {
                        g.FillRectangle(_sbSelected, _cellMatrix[i, j].Bounds);
                    }
                    else if (_cellMatrix[i, j].IsReadOnly)
                    {
                        g.FillRectangle(_sbReadOnlyColor, _cellMatrix[i, j].Bounds);
                    }
                    else
                    {
                        g.FillRectangle(_sbGridForeColor, _cellMatrix[i, j].Bounds);
                    }
                }

            }             
        }

        private void DrawToolTip(Graphics g)
        {
            if (_timeToolTip != null && _lastMouseHover != null)
            {
                Font font = new Font(Control.DefaultFont.FontFamily, 8);

                SizeF sf = g.MeasureString(_timeToolTip.Text, font);

                RectangleF lBounds = new RectangleF(_lastMouseHover.X + 1, _lastMouseHover.Y - (2 + sf.Height), sf.Width, sf.Height + 1);

                if ((lBounds.Y < 0) && ((lBounds.X + lBounds.Width + c_ToolTipXPad) > this.Width))
                {
                    lBounds.Y = _lastMouseHover.Y;
                    lBounds.X = lBounds.X - (lBounds.Width + 3);
                }
                else if ((lBounds.Y > 0) && ((lBounds.X + lBounds.Width + c_ToolTipXPad) > this.Width))
                {
                    lBounds.X = lBounds.X - (lBounds.Width + 3);
                }
                else if ((lBounds.Y < 0) && ((lBounds.X + lBounds.Width + c_ToolTipXPad) < this.Width))
                {
                    lBounds.Y = _lastMouseHover.Y;
                    lBounds.X += c_ToolTipXPad;
                }

                g.FillRectangle(_sbInfoBack, lBounds);
                g.DrawRectangle(Pens.Black, Rectangle.Round(lBounds));
                g.DrawString(_timeToolTip.Text, font, _sbInfoText, lBounds.X, lBounds.Y);
            }
        }

        private RectangleF CenterRectangle(RectangleF recLarge, SizeF sizeSmaller, Boolean forDays)
        {
            RectangleF recNew = new RectangleF(recLarge.Location, recLarge.Size);

            if (forDays)
            {
                recNew.X = recLarge.X + ((recLarge.Width / 2.0F) - (sizeSmaller.Width / 2.0F)) + (c_CellBorderWidth / 2);
                recNew.Y = recLarge.Y + ((recLarge.Height / 2.0F) - (sizeSmaller.Height / 2.0F));
            }
            else
            {
                recNew.X = recLarge.X + ((recLarge.Width / 2.0F) - (sizeSmaller.Width / 2.0F));
                recNew.Y = recLarge.Y + ((recLarge.Height / 2.0F) - (sizeSmaller.Height / 2.0F)) + (c_CellBorderWidth / 2);
            }
            
            return recNew;
        }

        private Single FindEmSize(Graphics g, RectangleF rec, Boolean forDays)
        {
            Single i = 1.0F;
            String moreLength = String.Empty;

            if (forDays)
            {
                foreach (DataRow wkRow in s_weekDayTable.Rows)
                {
                    if (wkRow[_weekDayAcronymFieldName].ToString().Length > moreLength.Length)
                    {
                        moreLength = wkRow[_weekDayAcronymFieldName].ToString();
                    }
                }
            }
            else
            {
                foreach (DataRow tmRow in s_timeSlotTable.Rows)
                {
                    if (tmRow[_timeDescriptionFieldName].ToString().Length > moreLength.Length)
                    {
                        moreLength = tmRow[_timeDescriptionFieldName].ToString();
                    }
                }
            }
            
            while (true)
            {
                Font f = new Font(Control.DefaultFont.FontFamily, i);
                SizeF sf = g.MeasureString(moreLength, f);

                if ((sf.Width > rec.Width) || (sf.Height > rec.Height))
                {
                    break;
                }
                i++;
            }

            return (i > 2) ? i - 1 : 1;

        }

        //this procedure resets the control
        public void ResetTimeFrameControl()
        {
            this.SetLimits();
            this.OnResize(new EventArgs());
        } //-------------------------
     
        //this procedure initializes the weekday and timeslot table
        public void InitializeTimeFrameTables(DataTable weekDayTable, DataTable timeSlotTable, DataTable readOnlySlotTable, Int32 timeInterval)
        {
            s_weekDayTable = weekDayTable;
            s_timeSlotTable = timeSlotTable;
            s_readOnlySlotTable = readOnlySlotTable;
            _timeInterval = timeInterval;

            this.SetLimits();

            _scrollBar.Minimum = 0;
            _scrollBar.Maximum = _numTimeSlots - 1;
            _scrollBar.LargeChange = (_scrollBar.Maximum / _scrollBar.Height) + (c_MaxTimeDisplay - 1);
            _scrollBar.SmallChange = _timeInterval;
            _scrollBar.Value = 0;

            this.OnResize(new EventArgs());

        } //----------------------------------        

        //this procedure initializes the weekday and timeslot table
        private void IntializeTimeFrameTables()
        {
            s_weekDayTable = new DataTable("WeekDayTable");
            s_weekDayTable.Columns.Add(_weekDayIdFieldName, System.Type.GetType("System.Byte"));
            s_weekDayTable.Columns.Add(_weekDayDescriptionFieldName, System.Type.GetType("System.String"));
            s_weekDayTable.Columns.Add(_weekDayAcronymFieldName, System.Type.GetType("System.String"));

            s_weekDayTable.Columns[_weekDayIdFieldName].AutoIncrement = true;
            s_weekDayTable.Columns[_weekDayIdFieldName].AutoIncrementSeed = 0;
            s_weekDayTable.Columns[_weekDayIdFieldName].AutoIncrementStep = 1;

            DataRow weekRow = s_weekDayTable.NewRow();
            weekRow[_weekDayDescriptionFieldName] = "Sunday";
            weekRow[_weekDayAcronymFieldName] = "Sun";
            s_weekDayTable.Rows.Add(weekRow);

            weekRow = s_weekDayTable.NewRow();
            weekRow[_weekDayDescriptionFieldName] = "Monday";
            weekRow[_weekDayAcronymFieldName] = "M";
            s_weekDayTable.Rows.Add(weekRow);

            weekRow = s_weekDayTable.NewRow();
            weekRow[_weekDayDescriptionFieldName] = "Tuesday";
            weekRow[_weekDayAcronymFieldName] = "T";
            s_weekDayTable.Rows.Add(weekRow);

            weekRow = s_weekDayTable.NewRow();
            weekRow[_weekDayDescriptionFieldName] = "Wednesday";
            weekRow[_weekDayAcronymFieldName] = "W";
            s_weekDayTable.Rows.Add(weekRow);

            weekRow = s_weekDayTable.NewRow();
            weekRow[_weekDayDescriptionFieldName] = "Thursday";
            weekRow[_weekDayAcronymFieldName] = "Th";
            s_weekDayTable.Rows.Add(weekRow);

            weekRow = s_weekDayTable.NewRow();
            weekRow[_weekDayDescriptionFieldName] = "Friday";
            weekRow[_weekDayAcronymFieldName] = "F";
            s_weekDayTable.Rows.Add(weekRow);

            weekRow = s_weekDayTable.NewRow();
            weekRow[_weekDayDescriptionFieldName] = "Saturday";
            weekRow[_weekDayAcronymFieldName] = "Sat";
            s_weekDayTable.Rows.Add(weekRow);

            s_timeSlotTable = new DataTable("TimeSlotTable");
            s_timeSlotTable.Columns.Add(_timeIdFieldName, System.Type.GetType("System.Byte"));
            s_timeSlotTable.Columns.Add(_timeDescriptionFieldName, System.Type.GetType("System.String"));

            s_timeSlotTable.Columns[_timeIdFieldName].AutoIncrement = true;
            s_timeSlotTable.Columns[_timeIdFieldName].AutoIncrementSeed = 0;
            s_timeSlotTable.Columns[_timeIdFieldName].AutoIncrementStep = 1;

            DataRow timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "06:00";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "06:00";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "06:10";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "06:10";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "06:20";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "06:20";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "06:30";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "06:30";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "06:40";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "06:40";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "06:50";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "06:50";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "07:00";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "07:00";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "07:10";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "07:10";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "07:20";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "07:20";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "07:30";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "07:30";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "07:40";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "07:40";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "07:50";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "07:50";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "08:00";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "08:00";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "08:10";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "08:10";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "08:20";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "08:20";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "08:30";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "08:30";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "08:40";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "08:40";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "08:50";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "08:50";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "09:00";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "09:00";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "09:10";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "09:10";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "09:20";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "09:20";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "09:30";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "09:30";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "09:40";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "09:40";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "09:50";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "09:50";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "10:00";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "10:00";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "10:10";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "10:10";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "10:20";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "10:20";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "10:30";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "10:30";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "10:40";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "10:40";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "10:50";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "10:50";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "11:00";
            s_timeSlotTable.Rows.Add(timeRow);

            timeRow = s_timeSlotTable.NewRow();
            timeRow[_timeDescriptionFieldName] = "11:00";
            s_timeSlotTable.Rows.Add(timeRow);

            s_readOnlySlotTable = new DataTable("ReadOnlySlotTable");
            s_readOnlySlotTable.Columns.Add(_readOnlySubjectCodeFieldName, System.Type.GetType("System.String"));
            s_readOnlySlotTable.Columns.Add(_timeIdFieldName, System.Type.GetType("System.Byte"));
            s_readOnlySlotTable.Columns.Add(_weekDayIdFieldName, System.Type.GetType("System.Byte"));


        } //---------------------------------

        //this procedure gets the subject code which the readonly cell owns
        private String GetReadOnlySubjectCode(Byte timeId, Byte weekId)
        {
            String subjectCode = "";

            String strFilter = _timeIdFieldName + " = " + timeId.ToString() + " AND " + _weekDayIdFieldName + " = " + weekId.ToString();
            DataRow[] selectRow = s_readOnlySlotTable.Select(strFilter, _readOnlySubjectCodeFieldName + " ASC");

            foreach (DataRow subjectRow in selectRow)
            {
                subjectCode = subjectRow[_readOnlySubjectCodeFieldName].ToString();
            }

            return subjectCode;
        } //-----------------------------

        #endregion

    }
}
