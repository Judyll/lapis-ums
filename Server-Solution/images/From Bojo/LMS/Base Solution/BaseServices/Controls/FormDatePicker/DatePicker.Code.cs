using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Windows.Forms;

namespace BaseServices.Control
{
    partial class DatePicker
    {
        #region Class General Variable Declaration
        private int _indexMonth;
        private int _indexDay;
        private int _indexYear;
        #endregion

        #region Class Properties Declarations
        //this property is used to get the selected date
        private DateTime _selectedDate;
        public DateTime GetSelectedDate
        {
            get { return _selectedDate; }
        } //-----------------------

        //this property is used to determine if a date has been selected
        private Boolean _hasSelectedDate = false;
        public Boolean HasSelectedDate
        {
            get { return _hasSelectedDate; }
        } //-----------------------------
        #endregion

        #region Class Constructor
        public DatePicker()
        {
            InitializeComponent();

            _selectedDate = DateTime.Now;

            RegEventHandlers();
        }

        public DatePicker(DateTime initDate)
        {
            InitializeComponent();

            _selectedDate = initDate;
            calMain.SetDate(initDate);

            RegEventHandlers();
        }
        #endregion

        #region Class Event Void Procedures

        //###############################################CLASS CFBDatePicker EVENTS######################################################
        //event is raised when the class is loaded
        private void ClassLoad(Object sender, EventArgs e)
        {
            InitializeControls();
        } //--------------------------
        //###############################################END CLASS CFBDatePicker EVENTS##################################################

        //#############################################BUTTON btnUseDate EVENTS##########################################################
        //event is raised when the button is clicked
        private void btnUseDateClick(object sender, EventArgs e)
        {
            _hasSelectedDate = true;
            this.Close();
        } //-----------------------------
        //##############################################END BUTTON btnUseDate EVENTS#####################################################

        //############################################COMBOBOX cboMonth EVENTS###########################################################
        //event is raised when the selection change is committed
        void cboMonthSelectionChangeCommitted(object sender, EventArgs e)
        {
            _indexMonth = cboMonth.SelectedIndex;

            SetComboDay();
            SetMainCalendar();
        } //---------------------------------------

        //event is raised when the combo box is validating
        void cboMonthValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Boolean monthFound = false;
            DateTimeFormatInfo dateInfo = new DateTimeFormatInfo();

            String strMonth = ((ComboBox)sender).Text;

            for (int index = 1; index <= 12; index++)
            {
                if (String.Equals(strMonth.ToUpper(), dateInfo.GetMonthName(index).ToUpper()))
                {
                    _indexMonth = index - 1;
                    
                    SetMainCalendar();

                    monthFound = true;

                    break;
                }
            }

            if (!monthFound)
            {
                cboMonth.SelectedIndex = _indexMonth;
            }
            
        }//-------------------------------    

        //event is raised when the key is pressed
        private void cboMonthKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')  //Enter key is pressed
            {
                Boolean monthFound = false;
                DateTimeFormatInfo dateInfo = new DateTimeFormatInfo();

                String strMonth = ((ComboBox)sender).Text;

                for (int index = 1; index <= 12; index++)
                {
                    if (String.Equals(strMonth.ToUpper(), dateInfo.GetMonthName(index).ToUpper()))
                    {
                        _indexMonth = index - 1;
                        
                        SetMainCalendar();

                        monthFound = true;

                        cboDay.Focus();

                        break;
                    }
                }

                if (!monthFound)
                {
                    cboMonth.SelectedIndex = _indexMonth;
                }
            }
        } //---------------------------------------
        //###########################################END COMBOBOX cboMonth EVENTS########################################################

        //################################################COMBOBOX cboDay EVENTS#########################################################
        //event is raised when the selection change is committed
        private void cboDaySelectionChangeCommitted(object sender, EventArgs e)
        {
            _indexDay = cboDay.SelectedIndex;

            SetMainCalendar();

        } //---------------------------------------------

        //event is raised when the combo box is validating
        private void cboDayValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int intDay;

            if (Int32.TryParse(cboDay.Text, out intDay))
            {
                int maxDay = DateTime.DaysInMonth(_selectedDate.Year, _selectedDate.Month);

                if ((intDay >= 1) && (intDay <= maxDay))
                {
                    _indexDay = intDay - 1;
                    
                    SetMainCalendar();

                }
                else
                {
                    cboDay.SelectedIndex = _indexDay;
                }
            }
            else
            {
                cboDay.SelectedIndex = _indexDay;
            }

        } //----------------------------------------

        //event is raised when the key is pressed
        private void cboDayKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                int intDay;

                if (Int32.TryParse(cboDay.Text, out intDay))
                {
                    int maxDay = DateTime.DaysInMonth(_selectedDate.Year, _selectedDate.Month);

                    if ((intDay >= 1) && (intDay <= maxDay))
                    {
                        _indexDay = intDay - 1;
                        
                        SetMainCalendar();

                        cboYear.Focus();
                    }
                    else
                    {
                        cboDay.SelectedIndex = _indexDay;
                    }
                }
                else
                {
                    cboDay.SelectedIndex = _indexDay;
                }
            }
        } //-------------------------------------
        //###############################################END COMBOBOX cboDay EVENTS######################################################

        //################################################COMBOBOX cboYear EVENTS########################################################
        //event is raised when the selection change is committed
        private void cboYearSelectionChangeCommitted(object sender, EventArgs e)
        {
            _indexYear = cboYear.SelectedIndex;

            SetMainCalendar();

        } //---------------------------------------------

        //event is raised when the combo box is validating
        private void cboYearValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int intYear;

            if (Int32.TryParse(cboYear.Text, out intYear))
            {
                int minYear = calMain.MinDate.Year;
                int maxYear = calMain.MaxDate.Year;

                if ((intYear >= minYear) && (intYear <= maxYear))
                {
                    _indexYear = intYear - minYear;

                    SetMainCalendar();

                }
            }
            else
            {
                cboYear.SelectedIndex = _indexYear;
            }
        } //--------------------------------------------

        //event is raised when the key is pressed
        private void cboYearKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                int intYear;

                if (Int32.TryParse(cboYear.Text, out intYear))
                {
                    int minYear = calMain.MinDate.Year;
                    int maxYear = calMain.MaxDate.Year;

                    if ((intYear >= minYear) && (intYear <= maxYear))
                    {
                        _indexYear = intYear - minYear;

                        SetMainCalendar();

                        btnUseDate.Focus();
                    }
                    else
                    {
                        cboYear.SelectedIndex = _indexYear;
                    }
                }
                else
                {
                    cboYear.SelectedIndex = _indexYear;
                }
            }
        } //---------------------------------------
        //###########################################END COMBOBOX cboYear EVENTS#########################################################

        //###########################################MONTHLYCALENDAR calMain EVENTS######################################################
        //event is raised when the date is changed
        private void calMainDateChanged(object sender, DateRangeEventArgs e)
        {
            DateTimeFormatInfo dateInfo = new DateTimeFormatInfo();

            cboMonth.Text = dateInfo.GetMonthName(e.Start.Month);
            cboDay.Text = e.Start.Day.ToString();
            cboYear.Text = e.Start.Year.ToString();

            _selectedDate = e.Start;

        } //---------------------------
        //###########################################END MONTHLYCALENDAR calMain EVENTS######################################################

        #endregion

        #region Programmer-Defined Void Procedures
        //this procedure registers the event handlers
        private void RegEventHandlers()
        {
            this.Load += new EventHandler(ClassLoad);

            btnUseDate.Click += new EventHandler(btnUseDateClick);

            cboMonth.SelectionChangeCommitted += new EventHandler(cboMonthSelectionChangeCommitted);
            cboMonth.Validating += new System.ComponentModel.CancelEventHandler(cboMonthValidating);
            cboMonth.KeyPress += new KeyPressEventHandler(cboMonthKeyPress);

            cboDay.SelectionChangeCommitted += new EventHandler(cboDaySelectionChangeCommitted);
            cboDay.Validating += new System.ComponentModel.CancelEventHandler(cboDayValidating);
            cboDay.KeyPress += new KeyPressEventHandler(cboDayKeyPress);

            cboYear.SelectionChangeCommitted += new EventHandler(cboYearSelectionChangeCommitted);
            cboYear.Validating += new System.ComponentModel.CancelEventHandler(cboYearValidating);
            cboYear.KeyPress += new KeyPressEventHandler(cboYearKeyPress);

            calMain.DateChanged += new DateRangeEventHandler(calMainDateChanged);
            

        } //---------------------------------

        
        //this procedure initialize the combo boxes and the calendar
        private void InitializeControls()
        {
            //sets the index that will be used for the combo box
            _indexMonth = _selectedDate.Month - 1;
            _indexDay = _selectedDate.Day - 1;
            _indexYear = _selectedDate.Year - calMain.MinDate.Year;
            //----------------------

            SetComboMonth();
            SetComboDay();
            SetComboYear();

        } //---------------------

        //this procedure sets the combo month
        private void SetComboMonth()
        {
            //initialize the combo box month
            cboMonth.Items.Clear();

            DateTimeFormatInfo dateInfo = new DateTimeFormatInfo();

            for (int index = 1; index <= 12; index++)
            {
                cboMonth.Items.Add(dateInfo.GetMonthName(index));
            } //-----------------------

            cboMonth.SelectedIndex = _selectedDate.Month - 1;

        } //-------------------------------

        //this procedure sets the combo box day
        private void SetComboDay()
        {
            //initialize the combo box day
            cboDay.Items.Clear();

            for (int index = 1; index <= DateTime.DaysInMonth(_selectedDate.Year, _selectedDate.Month); index++)
            {
                cboDay.Items.Add(index);
            }

            cboDay.SelectedIndex = _selectedDate.Day - 1;

        }//------------------------

        //this procedure sets the combo year
        private void SetComboYear()
        {
            //initialize the combo box year
            cboYear.Items.Clear();

            for (int index = calMain.MinDate.Year; index <= calMain.MaxDate.Year; index++)
            {
                cboYear.Items.Add(index);
            }

            cboYear.SelectedIndex = _selectedDate.Year - calMain.MinDate.Year;
        } //----------------------

        //this procedure concats the combo boxes
        private void SetMainCalendar()
        {
            String strDate = cboMonth.Items[_indexMonth].ToString() + " 1, " + DateTime.Now.Year.ToString();
            int comboDay = (int)cboDay.Items[_indexDay];
            DateTime defaultDate = System.Convert.ToDateTime(strDate);

            if (DateTime.DaysInMonth(defaultDate.Year, defaultDate.Month) < comboDay)
            {
                strDate = cboMonth.Items[_indexMonth].ToString() + " " + DateTime.DaysInMonth(defaultDate.Year, defaultDate.Month).ToString() +
                    ", " + cboYear.Items[_indexYear].ToString();

                _indexDay = DateTime.DaysInMonth(defaultDate.Year, defaultDate.Month) - 1;
            }
            else
            {
                strDate = cboMonth.Items[_indexMonth].ToString() + " " + cboDay.Items[_indexDay].ToString() +
                    ", " + cboYear.Items[_indexYear].ToString();
            }

            _selectedDate = System.Convert.ToDateTime(strDate);
            calMain.SetDate(_selectedDate);

        } //-------------------------

        #endregion
    }
}
