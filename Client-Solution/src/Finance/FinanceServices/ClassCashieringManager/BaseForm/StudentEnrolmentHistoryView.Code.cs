using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceServices
{
    partial class StudentEnrolmentHistoryView
    {
        #region Class Data Member Declaration
        private CashieringLogic _cashieringManager;
        #endregion

        #region Class Constructors
        public StudentEnrolmentHistoryView(CashieringLogic cashieringManager)
        {
            this.InitializeComponent();

            _cashieringManager = cashieringManager;

            this.Load += new EventHandler(ClassLoad);
            this.btnClose.Click += new EventHandler(btnCloseClick);
        }
         
        #endregion

        #region Class Event Void Procedures
        //###########################################CLASS StudentEnrolmentHistory EVENTS#####################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _cashieringManager.InitializeTreeViewControl(this.trvStudentEnrolment);
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
