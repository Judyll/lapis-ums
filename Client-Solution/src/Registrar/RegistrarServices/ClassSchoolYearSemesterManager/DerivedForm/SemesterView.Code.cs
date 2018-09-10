using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace RegistrarServices
{
    partial class SemesterView
    {
        #region Class Constructor
        public SemesterView(CommonExchange.SemesterInformation semInfo)
        {
            this.InitializeComponent();

            _semInfo = semInfo;

            this.Load += new EventHandler(ClassLoad);
            this.btnDone.Click += new EventHandler(btnDoneClick);
        }        
                
        #endregion

        #region Class Event Void Procedures

        //###############################################CLASS SchoolYearView EVENTS##############################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            lblSystemId.Text = _semInfo.SemesterSysId;
            lblSchoolYearDescription.Text = _semInfo.SchoolYearDescription;
            lblSemesterDescription.Text = _semInfo.SchoolSemesterDescription;
            lblDateStart.Text = DateTime.Parse(_semInfo.DateStart).ToString("MMMM, yyyy", DateTimeFormatInfo.InvariantInfo);
            lblDateEnd.Text = DateTime.Parse(_semInfo.DateEnd).ToString("MMMM, yyyy", DateTimeFormatInfo.InvariantInfo);
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
