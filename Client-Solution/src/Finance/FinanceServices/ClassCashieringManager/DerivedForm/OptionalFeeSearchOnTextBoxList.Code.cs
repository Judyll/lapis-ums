using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class OptinalFeeSearchOnTextBoxList
    {
        #region Class Data Member Declaration
        private CashieringLogic _cashieringManager;
        #endregion

        #region Class Constructors
        public OptinalFeeSearchOnTextBoxList(CashieringLogic cashieringManager)
        {
            this.InitializeComponent();

            _cashieringManager = cashieringManager;

            this.pbxRefresh.Click += new EventHandler(pbxRefreshClick);
        }
       
        #endregion

        #region Class Event Void Procedures
        //####################################CLASS AdditionalFeeSearchOnTextBoxList EVENTS####################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.SetDataGridViewSource(_cashieringManager.OptinalFeeTableFormat);

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

                    this.SetDataGridViewSource(_cashieringManager.GetSearchedOptinalFee(((TextBox)sender).Text));
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

        //####################################################DATAGRIDVIEW dgvList EVENTS####################################################
        //event is raised when the control is double clicked
        protected override void dgvListDoubleClick(object sender, EventArgs e)
        {
            base.dgvListDoubleClick(sender, e);

            this.Close();
        }//--------------------------
        //####################################################END DATAGRIDVIEW dgvList EVENTS####################################################

        //##################################PICTUREBOX pbxRefresh EVENTS######################################################
        //event is raised when the picture box is clicked
        private void pbxRefreshClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.SetDataGridViewSource(_cashieringManager.OptinalFeeTableFormat);

            this.txtSearch.Clear();

            this.Cursor = Cursors.Arrow;
        }//---------------------------------
        //##################################END PICTUREBOX pbxRefresh EVENTS######################################################

        //##################################DATAGRIDVIEW dgvListDoubleClick EVENTS######################################################
        //event is raised when the key is pressed
        protected override void dgvListKeyPress(object sender, KeyPressEventArgs e)
        {
            base.dgvListKeyPress(sender, e);

            this.Close();
        }//---------------------------
        //##################################DATAGRIDVIEW dgvListDoubleClick EVENTS######################################################
        #endregion
    }
}
