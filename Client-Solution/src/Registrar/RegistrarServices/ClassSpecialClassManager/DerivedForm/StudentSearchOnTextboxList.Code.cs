using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RegistrarServices
{
    partial class StudentSearchOnTextboxList
    {
        #region Class General Variable Declarations
        private CommonExchange.SysAccess _userInfo;
        private SpecialClassLogic _specialManager;

        private String _dateStart;
        private String _dateEnd;
        #endregion

        #region Class Constructor
        public StudentSearchOnTextboxList(CommonExchange.SysAccess userInfo, SpecialClassLogic specialManager, String dateStart, String dateEnd)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _specialManager = specialManager;

            _dateStart = dateStart;
            _dateEnd = dateEnd;

            this.pbxRefresh.Click += new EventHandler(pbxRefreshClick);
        }

        
        #endregion

        #region Class Event Void Procedures

        //####################################CLASS PrerequisiteSearchOnTextboxList EVENTS####################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.SetDataGridViewSource(_specialManager.StudentSearchFormat);

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

                    this.SetDataGridViewSource(_specialManager.GetSearchedStudentInformation(_userInfo, ((TextBox)sender).Text, true, 
                        _dateStart, _dateEnd));
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
        } //-------------------------
        //#################################END TEXTBOX txtSearch EVENTS#######################################################

        //##################################PICTUREBOX pbxRefresh EVENTS######################################################
        //event is raised when the picture box is clicked
        private void pbxRefreshClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.SetDataGridViewSource(_specialManager.StudentSearchFormat);

            this.txtSearch.Clear();

            this.Cursor = Cursors.Arrow;
        } //----------------------------
        //##############################END PICTUREBOX pbxRefresh EVENTS######################################################
        #endregion

    }
}
