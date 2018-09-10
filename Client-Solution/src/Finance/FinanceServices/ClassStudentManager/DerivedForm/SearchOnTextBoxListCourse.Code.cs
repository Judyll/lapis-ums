using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class SearchOnTextBoxListCourse
    {
        #region Class General Variable Declaration
        private CommonExchange.SysAccess _userInfo;
        private StudentLogic _studentManager;

        private String _courseGroupId = "";
        #endregion

        #region Class Constructors
        public SearchOnTextBoxListCourse(CommonExchange.SysAccess userInfo, StudentLogic studentManager, String courseGroupId)
        {
            _userInfo = userInfo;
            _studentManager = studentManager;

            _courseGroupId = courseGroupId;       
        }
        #endregion

        #region Class Event Void Procedures
        //####################################CLASS SearchOnTextBoxListCourse EVENTS####################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.SetDataGridViewSource(_studentManager.GetSearchedCourseInformation(String.Empty, _courseGroupId));

            base.ClassLoad(sender, e);

            this.Text = "   Course List";
        }//-----------------
        //####################################END CLASS SearchOnTextBoxListCourse EVENTS####################################

        //##################################TEXTBOX txtSearch EVENTS##########################################################
        //event is raised when the key is up
        protected override void txtSearchKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    this.SetDataGridViewSource(_studentManager.GetSearchedCourseInformation(((TextBox)sender).Text, _courseGroupId));
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error student course list.");
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

        //##################################DATAGRIDVIEW dgvListDoubleClick EVENTS######################################################
        //event is raised when the control is double clicked
        protected override void dgvListDoubleClick(object sender, EventArgs e)
        {
            _hasSelected = true;

            this.Close();
        }//-----------------------------

        //event is raised when the key is pressed
        protected override void dgvListKeyPress(object sender, KeyPressEventArgs e)
        {
            base.dgvListKeyPress(sender, e);

            if (_hasSelected)
            {
                this.Close();
            }
        }//----------------------------
        //##################################END DATAGRIDVIEW dgvListDoubleClick EVENTS######################################################

       
        #endregion
    }
}
