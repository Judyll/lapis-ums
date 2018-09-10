using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class StudentGrades
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private StudentLoadingLogic _studentManager;

        private CommonExchange.Student _studentInfo;
        #endregion

        #region Class Constructors
        public StudentGrades()
        {
            this.InitializeComponent();
        }

        public StudentGrades(CommonExchange.SysAccess userInfo, StudentLoadingLogic studentManager, CommonExchange.Student studentInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _studentManager = studentManager;

            _studentInfo = studentInfo;

            this.Load += new EventHandler(ClassLoad);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnPrint.Click += new EventHandler(btnPrintClick);
        }
        #endregion

        #region Class Event Void Procedures
        //####################################CLASS StudentGrades EVENTS####################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            this.dgvList.DataSource = _studentManager.StudentTranscriptTable;
            RemoteClient.ProcStatic.SetDataGridViewColumns(this.dgvList, false);

            _studentManager.SelectByStudentIDTranscriptDetails(_userInfo, _studentInfo.StudentId);

            this.dgvList.DataSource = _studentManager.GetStudentGrades();
            
        }//--------------------
        //####################################END CLASS StudentGrades EVENTS####################################

        //####################################BUTTON btnPrint EVENTS####################################
        //event is raised when the control is clicked
        private void btnPrintClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _studentManager.PrintStudentGrade(_userInfo, _studentInfo);
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Student Grade List Report! /n" + ex.Message, "Error Loading");
            }
        }//-------------------
        //####################################END BUTTON btnPrint EVENTS####################################

        //####################################BUTTON btnClose EVENTS####################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//--------------------
        //####################################END BUTTON btnClose EVENTS####################################

        #endregion
    }
}
