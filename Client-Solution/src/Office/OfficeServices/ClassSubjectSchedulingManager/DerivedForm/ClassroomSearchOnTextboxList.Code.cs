using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class ClassroomSearchOnTextboxList
    {
        #region Class General Variable Declarations
        private CommonExchange.SysAccess _userInfo;
        private SubjectSchedulingLogic _scheduleManager;
        #endregion

        #region Class Constructor
        public ClassroomSearchOnTextboxList(CommonExchange.SysAccess userInfo, SubjectSchedulingLogic scheduleManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _scheduleManager = scheduleManager;
        }
        #endregion

        #region Class Event Void Procedures

        //####################################CLASS PrerequisiteSearchOnTextboxList EVENTS####################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.SetDataGridViewSource(_scheduleManager.ClassroomTableFormat);

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

                    this.SetDataGridViewSource(_scheduleManager.GetSearchedClassroomInformation(((TextBox)sender).Text));
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Retrieving Classroom List");
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
