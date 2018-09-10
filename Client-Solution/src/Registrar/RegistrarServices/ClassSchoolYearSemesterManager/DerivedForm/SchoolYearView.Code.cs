using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace RegistrarServices
{
    partial class SchoolYearView
    {
        #region Class Constructor
        public SchoolYearView(CommonExchange.SchoolYear yearInfo)
        {
            this.InitializeComponent();

            _yearInfo = yearInfo;

            this.Load += new EventHandler(ClassLoad);
            this.btnDone.Click += new EventHandler(btnDoneClick);
        }        
                
        #endregion

        #region Class Event Void Procedures

        //###############################################CLASS SchoolYearView EVENTS##############################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            lblSystemId.Text = _yearInfo.YearId;
            lblDescription.Text = _yearInfo.Description;
            lblDateStart.Text = DateTime.Parse(_yearInfo.DateStart).ToString("MMMM, yyyy", DateTimeFormatInfo.InvariantInfo);
            lblDateEnd.Text = DateTime.Parse(_yearInfo.DateEnd).ToString("MMMM, yyyy", DateTimeFormatInfo.InvariantInfo);
        } //-------------------------------------
        //#############################################END CLASS SchoolYearView EVENTS##############################################

        //################################################BUTTON btnDone EVENTS#####################################################
        //event is raised when the button is clicked
        private void btnDoneClick(object sender, EventArgs e)
        {
            this.Close();
        } //--------------------------------
        //#############################################END BUTTON btnDone EVENTS#####################################################
        #endregion
    }
}
