using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class ScheduleSearchOnTextBoxList
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private TeacherLoadingLogic _teacherLoadingManager;

        private String _queryString;
        private String _dateStart;
        private String _dateEnd;
        #endregion

        #region Class Constructos
        public ScheduleSearchOnTextBoxList(CommonExchange.SysAccess userInfo, TeacherLoadingLogic teacherLoadingManager, 
            String queryString, String dateStart, String dateEnd)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _teacherLoadingManager = teacherLoadingManager;

            _queryString = queryString;
            _dateStart = dateStart;
            _dateEnd = dateEnd;

            this.pbxRefresh.Click += new EventHandler(pbxRefreshClick);
        }
        #endregion

        #region Class Event Void Procedures
        //####################################CLASS SubjectSearchOnTextBoxListStudentLoading EVENTS####################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.txtSearch.Text = _queryString;

            this.SetDataGridViewSource(_teacherLoadingManager.SelectByDateStartEndScheduleInformationDetails(_userInfo, _queryString, _dateStart, _dateEnd));

            base.ClassLoad(sender, e);

            this.dgvList.ReadOnly = false;
        }//----------------------------       
        //####################################END CLASS SubjectSearchOnTextBoxListStudentLoading EVENTS####################################

        //####################################################DATAGRIDVIEW dgvList EVENTS####################################################     
        //event is raised when the control is double clicked
        protected override void dgvListDoubleClick(object sender, EventArgs e)
        {
        }//----------------------
        //####################################################END DATAGRIDVIEW dgvList EVENTS####################################################     

        //##################################TEXTBOX txtSearch EVENTS##########################################################
        //event is raised when the key is up
        protected override void txtSearchKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    this.SetDataGridViewSource(_teacherLoadingManager.SelectByDateStartEndScheduleInformationDetails(_userInfo,((TextBox)sender).Text, _dateStart, _dateEnd));

                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Retrieving Schedule List");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }

            base.txtSearchKeyUp(sender, e);
        }//--------------------
        //##################################END TEXTBOX txtSearch EVENTS##########################################################

        //##################################PICTUREBOX pbxRefresh EVENTS######################################################
        //event is raised when the picture box is clicked
        private void pbxRefreshClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.txtSearch.Clear();
            this.dgvList.Refresh();

            this.Cursor = Cursors.Arrow;
        }//----------------------
        //##################################END PICTUREBOX pbxRefresh EVENTS######################################################
        #endregion
    }
}
