using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class SubjectSearchOnTextboxList
    {
        #region Class General Variable Declaration
        private CommonExchange.SysAccess _userInfo;
        private SubjectSchedulingLogic _scheduleManager;
        #endregion

        #region Class Constructor
        public SubjectSearchOnTextboxList(CommonExchange.SysAccess userInfo, SubjectSchedulingLogic scheduleManager, Int32 primaryIndex)
        {
            this.InitializeComponent();

            this.PrimaryIndex = primaryIndex;

            _userInfo = userInfo;
            _scheduleManager = scheduleManager;

            this.pbxRefresh.Click += new EventHandler(pbxRefreshClick);
        }        
        #endregion

        #region Class Event Void Procedures

        //####################################CLASS PrerequisiteSearchOnTextboxList EVENTS####################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.SetDataGridViewSource(_scheduleManager.SubjectTableFormat);

            base.ClassLoad(sender, e);
        }//-------------------------
        //####################################END CLASS PrerequisiteSearchOnTextboxList EVENTS####################################

        //##################################TEXTBOX txtSearch EVENTS##########################################################
        //event is raised when the key is up
        protected override void txtSearchKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    this.SetDataGridViewSource(_scheduleManager.GetSearchedSubjectInformation(_userInfo, ((TextBox)sender).Text, true));
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Retrieving Student List");
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

            this.Cursor = Cursors.Arrow;
        }//-------------------
        //##################################END PICTUREBOX pbxRefresh EVENTS######################################################
        #endregion
    }
}
