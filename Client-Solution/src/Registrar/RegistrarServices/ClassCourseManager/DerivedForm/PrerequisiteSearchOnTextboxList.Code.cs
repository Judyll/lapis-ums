using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RegistrarServices
{
    partial class PrerequisiteSearchOnTextboxList
    {
        #region Class General Variable Declarations
        private CommonExchange.SysAccess _userInfo;
        private CourseLogic _roomSubjectManager;
        private String _departmentId;
        #endregion

        #region Class Constructor
        public PrerequisiteSearchOnTextboxList(CommonExchange.SysAccess userInfo, CourseLogic roomSubjectManager, String departmentId)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _roomSubjectManager = roomSubjectManager;
            _departmentId = departmentId;

            this.pbxRefresh.Click += new EventHandler(pbxRefreshClick);
        }

        
        #endregion

        #region Class Event Void Procedures

        //####################################CLASS PrerequisiteSearchOnTextboxList EVENTS####################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.SetDataGridViewSource(_roomSubjectManager.SubjectTableFormat);

            base.ClassLoad(sender, e);
        } //------------------------------
        //################################END CLASS PrerequisiteSearchOnTextboxList EVENTS####################################

        //##################################TEXTBOX txtSearch EVENTS##########################################################
        //event is raised when the key is up
        protected override void txtSearchKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    this.SetDataGridViewSource(_roomSubjectManager.GetSearchedSubjectInformation(_userInfo, ((TextBox)sender).Text, _departmentId, true));
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Retrieving Subject List");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }

            }

            base.txtSearchKeyUp(sender, e);
        } //-------------------------
        //#################################END TEXTBOX txtSearch EVENTS#######################################################

        //##################################PICTUREBOX pbxRefresh EVENTS######################################################
        //event is raised when the picture box is clicked
        private void pbxRefreshClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.txtSearch.Clear();

            this.Cursor = Cursors.Arrow;
        } //----------------------------
        //##############################END PICTUREBOX pbxRefresh EVENTS######################################################
        #endregion
    }
}
