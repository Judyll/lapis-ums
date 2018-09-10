using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeServices
{
    partial class StudentEnrolmentHistory
    {
        #region Class Data Member Declaration
        private StudentLoadingLogic _studentManger;
        #endregion

        #region Class Constructors
        public StudentEnrolmentHistory(StudentLoadingLogic studentManager)
        {
            this.InitializeComponent();

            _studentManger = studentManager;

            this.Load += new EventHandler(ClassLoad);
            this.btnClose.Click += new EventHandler(btnCloseClick);
        }
         
        #endregion

        #region Class Event Void Procedures
        //###########################################CLASS StudentEnrolmentHistory EVENTS#####################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _studentManger.InitializeTreeViewControl(this.trvStudentEnrolment);
        }//----------------------------------
        //###########################################END CLASS StudentEnrolmentHistory EVENTS#####################################################

        //###########################################BUTTON btnClose EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//----------------------------------
        //###########################################END BUTTON btnClose EVENTS#####################################################
        #endregion

    }
}
