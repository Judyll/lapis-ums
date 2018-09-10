using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class OptinalFeeSearchOnTextBoxList
    {
        #region Class Data Member Declaration
        private StudentLoadingLogic _studentManager;
        #endregion

        #region Class Constructors
        public OptinalFeeSearchOnTextBoxList(StudentLoadingLogic studentManager)
        {
            this.InitializeComponent();

            _studentManager = studentManager;

            this.pbxRefresh.Click += new EventHandler(pbxRefreshClick);
        }
       
        #endregion

        #region Class Event Void Procedures
        //####################################CLASS AdditionalFeeSearchOnTextBoxList EVENTS####################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.SetDataGridViewSource(_studentManager.OptinalFeeTableFormat);

            base.ClassLoad(sender, e);
        }//-----------------------------
        //####################################END CLASS AdditionalFeeSearchOnTextBoxList EVENTS####################################

        //##################################TEXTBOX txtSearch EVENTS##########################################################
        //event is raised when the key is up
        protected override void txtSearchKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    this.SetDataGridViewSource(_studentManager.GetSearchedOptinalFee(((TextBox)sender).Text));
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Retrieving Additional Fees Infomation List");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }

            base.txtSearchKeyUp(sender, e);
        }//-----------------------------------
        //##################################END TEXTBOX txtSearch EVENTS##########################################################

        //##################################PICTUREBOX pbxRefresh EVENTS######################################################
        //event is raised when the picture box is clicked
        private void pbxRefreshClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.SetDataGridViewSource(_studentManager.OptinalFeeTableFormat);

            this.txtSearch.Clear();

            this.Cursor = Cursors.Arrow;
        }//---------------------------------
        //##################################END PICTUREBOX pbxRefresh EVENTS######################################################
        #endregion
    }
}
