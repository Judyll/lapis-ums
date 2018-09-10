using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace RemoteClient
{
    partial class HourMinute
    {
        #region Class General Variable Declarations
        private Boolean _hourSelected = false;
        private Boolean _minuteSelected = false;
        
        private Int32 _hours = 0;
        private Int32 _minute = 0;

        private const Int32 c_hourMax = 99;
        private const Int32 c_minMax = 59;

        #endregion

        #region Class Properties Declarations
        //this property is used to get the selected time
        public String SelectedHourMinute
        {
            get { return txtHour.Text + ":" + txtMinute.Text; }
        } //------------------------

        /// <summary>
        /// Get or Set the number of hours
        /// </summary>
        public Int32 Hours
        {
            get
            {
                Int32 hours;

                if (Int32.TryParse(this.txtHour.Text, out hours))
                {
                    return hours;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _hours = ((value <= c_hourMax) && (value >= 0)) ? value : 0;

                txtHour.Text = this.TwoDigitZero(_hours);
            }
        } //---------------------------------

        /// <summary>
        /// Get or Set the number of minutes
        /// </summary>
        public Int32 Minutes
        {
            get
            {
                Int32 minutes;

                if (Int32.TryParse(this.txtMinute.Text, out minutes))
                {
                    return minutes;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _minute = ((value <= c_minMax) && (value >= 0)) ? value : 0;

                txtMinute.Text = this.TwoDigitZero(_minute);
            }
        }

        //this property is used to set the background color
        public Color BackgroundColor
        {
            set
            {
                pnlBack.BackColor = value;
                txtHour.BackColor = value;
                lblSep.BackColor = value;
                txtMinute.BackColor = value;                
            }                    
        } //---------------------

        //this property is used to set the text color
        public Color TextColor
        {
            set
            {
                pnlBack.ForeColor = value;
                txtHour.ForeColor = value;
                lblSep.ForeColor = value;
                txtMinute.ForeColor = value;                
            }
        } //------------------------

        //this property is used to set the enable property
        public Boolean EnableControl
        {
            set
            {
                txtHour.Enabled = value;
                txtMinute.Enabled = value;
                btnUp.Enabled = value;
                btnDown.Enabled = value;
                lblSep.Enabled = value;
                pnlBack.Enabled = value;
            }
        } //--------------------------

        #endregion

        #region Class Constructor
        
        public HourMinute()
        {
            InitializeComponent();

            this.Load += new EventHandler(ClassLoad);
            this.txtHour.KeyPress += new KeyPressEventHandler(TextBoxKeyPress);
            this.txtMinute.KeyPress += new KeyPressEventHandler(TextBoxKeyPress);
            this.txtHour.Click += new EventHandler(TextBoxClick);
            this.txtMinute.Click += new EventHandler(TextBoxClick);            
            this.txtHour.GotFocus += new EventHandler(txtHourGotFocus);
            this.txtHour.KeyUp += new KeyEventHandler(txtHourKeyUp);
            this.txtHour.Validating += new System.ComponentModel.CancelEventHandler(txtHourValidating);
            this.txtMinute.GotFocus += new EventHandler(txtMinuteGotFocus);
            this.txtMinute.KeyUp += new KeyEventHandler(txtMinuteKeyUp);
            this.txtMinute.Validating += new System.ComponentModel.CancelEventHandler(txtMinuteValidating);            
            this.btnUp.Click += new EventHandler(btnUpClick);
            this.btnDown.Click += new EventHandler(btnDownClick);
        }
                                          
        #endregion

        #region Class Event Void Procedures

        //###############################################CLASS TimeInput EVENTS#################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            this.InitializeControl();
        } //--------------------------
        //##############################################END CLASS TimeInput EVENTS################################################

        //#############################################TEXTBOX EVENTS#####################################################
        //event is raised when the key is pressed
        private void TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            this.TextBoxNumbersOnly((TextBox)sender, e);   
        } //----------------------------

        //event is raised when the control is clicked
        private void TextBoxClick(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
            
        } //-------------------------
        //###########################################END TEXTBOX EVENTS#####################################################

        //##########################################TEXTBOX txtHour EVENTS#######################################################
        //event is raised when the control has focus
        private void txtHourGotFocus(object sender, EventArgs e)
        {
            _hourSelected = true;
            _minuteSelected = false;

            ((TextBox)sender).SelectAll();
                       
        } //-------------------------------------

        //event is raised when the key is up
        private void txtHourKeyUp(object sender, KeyEventArgs e)
        {
            _hours = this.IsGreaterThanMax((TextBox)sender, c_hourMax);
        } //---------------------------

        //event is raised when the control is validating
        private void txtHourValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _hours = this.IsValidDigit((TextBox)sender);
        } //----------------------------------

        //##########################################END TEXTBOX txtHour EVENTS###################################################

        //#############################################TEXTBOX txtMinute EVENTS###################################################
        //event is raised when the control has focus
        private void txtMinuteGotFocus(object sender, EventArgs e)
        {
            _hourSelected = false;
            _minuteSelected = true;

            ((TextBox)sender).SelectAll();   
        } //----------------------------------

        //event is raised when the key is up
        private void txtMinuteKeyUp(object sender, KeyEventArgs e)
        {
            _minute = this.IsGreaterThanMax((TextBox)sender, c_minMax);   
        } //------------------------------

        //event is raised when the control is validating
        private void txtMinuteValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _minute = this.IsValidDigit((TextBox)sender);   
        } //-----------------------------------

        //############################################END TEXTBOX txtMinute EVENTS################################################

        //###############################################TEXTBOX txtAmPm EVENTS####################################################
        //event is raised when the control got focus
        private void txtAmPmGotFocus(object sender, EventArgs e)
        {
            _hourSelected = false;
            _minuteSelected = false;

            ((TextBox)sender).SelectAll();      
        } //------------------------------

        //##############################################END TEXTBOX txtAmPm EVENTS##################################################

        //##############################################BUTTON btnUp EVENTS###########################################################
        //event is raised when the button is clicked
        private void btnUpClick(object sender, EventArgs e)
        {
            this.UpButtonIsClicked();
        } //---------------------------
        //##############################################END BUTTON btnUp EVENTS#######################################################

        //#################################################BUTTON btnDown EVENTS########################################################
        //event is raised when the button is clicked
        private void btnDownClick(object sender, EventArgs e)
        {
            this.DownButtonIsClicked();
        } //------------------------------
        //################################################END BUTTON btnDown EVENTS#####################################################


        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure resets the time
        public void ResetHoursMinutes()
        {
            _hours = 0;
            _minute = 0;

            txtHour.Text = this.TwoDigitZero(_hours);
            txtMinute.Text = this.TwoDigitZero(_minute);
        } //--------------------

        //this procedure sets the time
        public void SetHoursMinutes(DateTime d)
        {
            _hours = d.Hour;
            _minute = d.Minute;            

            txtHour.Text = this.TwoDigitZero(_hours);
            txtMinute.Text = this.TwoDigitZero(_minute);
        } //--------------------------

        //this procedure sets the time
        public void SetHoursMinutes(Int32 hours, Int32 minute)
        {
            _hours = ((hours <= c_hourMax) && (hours >= 0)) ? hours : 0;
            _minute = ((minute <= c_minMax) && (minute >= 0)) ? minute : 0;

            txtHour.Text = this.TwoDigitZero(_hours);
            txtMinute.Text = this.TwoDigitZero(_minute);
        } //--------------------------------------

        //this procedure sets the control when the up button is clicked
        private void UpButtonIsClicked()
        {
            if (_hourSelected)
            {
                //increments the hours
                if (_hours < c_hourMax)
                {
                    _hours += 1;
                }
                else
                {
                    _hours = 0;
                }

                txtHour.Text = this.TwoDigitZero(_hours);
                txtHour.Focus();
            }
            else if (_minuteSelected)
            {
                //increments the minutes
                if (_minute < c_minMax)
                {
                    _minute += 1;
                }
                else
                {
                    _minute = 0;
                }

                txtMinute.Text = this.TwoDigitZero(_minute);
                txtMinute.Focus();
            }            

        } //-----------------------------

        //this procedure sets the control when the down button is clicked
        private void DownButtonIsClicked()
        {
            if (_hourSelected)
            {
                //increments the hours
                if (_hours > 0)
                {
                    _hours -= 1;
                }
                else
                {
                    _hours = c_hourMax;
                }

                txtHour.Text = this.TwoDigitZero(_hours);
                txtHour.Focus();
            }
            else if (_minuteSelected)
            {
                //increments the minutes
                if (_minute > 0)
                {
                    _minute -= 1;
                }
                else
                {
                    _minute = c_minMax;
                }

                txtMinute.Text = this.TwoDigitZero(_minute);
                txtMinute.Focus();
            }

        } //--------------------------

        //this procedure initializes the time controller
        private void InitializeControl()
        {
           txtHour.SelectAll();
        } //-----------------------------

        //this procedure makes the textbox accept on numbers only
        private void TextBoxNumbersOnly(TextBox txtInput, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                txtInput.ReadOnly = false;
            }
            else
            {
                txtInput.ReadOnly = true;
            }

        } //------------------------------        

        #endregion

        #region Programmer-Defined Function Procedures

        //this function determines if the hour and minute is equal to zero
        public Boolean IsHourMinuteZero()
        {
            if (_hours == 0 && _minute == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        } //----------------------
        //this function determines if the number is a single digit
        private Int32 IsValidDigit(TextBox txtBase)
        {
            Int32 digit = 0;

            if (Int32.TryParse(txtBase.Text, out digit))
            {
                txtBase.Text = this.TwoDigitZero(digit);
            }
            else
            {
                txtBase.Undo();
            }

            return digit;
        } //-----------------------

        //this function determines if the number is greater than max
        private Int32 IsGreaterThanMax(TextBox txtBase, Int32 max)
        {
            Int32 maxTest = 0;

            if (Int32.TryParse(txtBase.Text, out maxTest) && maxTest > max)
            {
                txtBase.Undo();
            }

            return maxTest;

        } //---------------------------

        //this function returns a two digit number
        private String TwoDigitZero(Int32 numBase)
        {
            String strPrefix = "";

            if (numBase <= 9)
            {
                strPrefix = "0";
            }

            return strPrefix + numBase.ToString();
        } //-----------------------------------

        #endregion
    }
}
