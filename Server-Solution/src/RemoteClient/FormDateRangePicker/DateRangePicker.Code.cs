using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RemoteClient
{
    partial class DateRangePicker
    {
        #region Class Properties Declarations
        private DateTime _dateFrom;
        public DateTime GetDateFrom
        {
            get { return _dateFrom; }
        }

        private DateTime _dateTo;
        public DateTime GetDateTo
        {
            get { return _dateTo; }
        }

        private Boolean _hasUseRange;
        public Boolean HasUseRange
        {
            get { return _hasUseRange; }
        }
        #endregion

        #region Class Constructor
        public DateRangePicker()
        {
            InitializeComponent();

            _dateFrom = DateTime.Now;
            _dateTo = DateTime.Now;

            this.Load += new EventHandler(ClassLoad);
            this.lnkDateFrom.Click += new EventHandler(lnkDateFromClick);
            this.lnkDateTo.Click += new EventHandler(lnkDateToClick);
            this.btnUse.Click += new EventHandler(btnUseClick);
        }

        public DateRangePicker(DateTime dateFrom, DateTime dateTo)
        {
            InitializeComponent();

            _dateFrom = dateFrom;
            _dateTo = dateTo;

            this.Load += new EventHandler(ClassLoad);
            this.lnkDateFrom.Click += new EventHandler(lnkDateFromClick);
            this.lnkDateTo.Click += new EventHandler(lnkDateToClick);
            this.btnUse.Click += new EventHandler(btnUseClick);
        }
        
        #endregion

        #region Class Event Void Procedures

        //##############################################CLASS DateRangePicker EVENTS########################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _hasUseRange = false;

            lblDateFrom.Text = _dateFrom.ToLongDateString();
            lblDateTo.Text = _dateTo.ToLongDateString();
        } //----------------------------

        //#############################################END CLASS DateRangePicker EVENTS#####################################################

        //####################################################LINKBUTTON lnkDateFrom EVENTS################################################
        //event is raised when the link is clicked
        private void lnkDateFromClick(object sender, EventArgs e)
        {
            DateTime bDate;

            this.Cursor = Cursors.WaitCursor;

            if (!DateTime.TryParse(lblDateFrom.Text, out bDate))
            {
                bDate = DateTime.Now;
            }

            using (RemoteClient.DatePicker frmPicker = new RemoteClient.DatePicker(bDate))
            {
                frmPicker.ShowDialog(this);

                if (frmPicker.HasSelectedDate && DateTime.Compare(frmPicker.GetSelectedDate, _dateTo) <= 0)
                {
                    _dateFrom = frmPicker.GetSelectedDate;

                    lblDateFrom.Text = _dateFrom.ToLongDateString();
                }
            }

            this.Cursor = Cursors.Arrow;
           
        } //---------------------------------------
        //#################################################END LINKBUTTON lnkDateFrom EVENTS#################################################

        //##################################################LINKBUTTON lnkDateTo EVENTS#####################################################
        //event is raised when the link is clicked
        private void lnkDateToClick(object sender, EventArgs e)
        {
            DateTime bDate;

            this.Cursor = Cursors.WaitCursor;

            if (!DateTime.TryParse(lblDateTo.Text, out bDate))
            {
                bDate = DateTime.Now;
            }

            using (RemoteClient.DatePicker frmPicker = new RemoteClient.DatePicker(bDate))
            {
                frmPicker.ShowDialog(this);

                if (frmPicker.HasSelectedDate && DateTime.Compare(frmPicker.GetSelectedDate, _dateFrom) >= 0)
                {
                    _dateTo = frmPicker.GetSelectedDate;

                    lblDateTo.Text = _dateTo.ToLongDateString();
                }
            }

            this.Cursor = Cursors.Arrow;
            
        } //-------------------------------------
        //#################################################END LINKBUTTON lnkDateTo EVENTS###################################################

        //#####################################################BUTTON btnUse EVENTS##########################################################
        //event is raised when the button is clicked
        private void btnUseClick(object sender, EventArgs e)
        {
            _hasUseRange = true;

            this.Close();
        } //---------------------------------------
        //###################################################END BUTTON btnUse EVENTS########################################################

        #endregion


    }
}
