using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class ReceiptNumberSearchOnTextBoxList
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private CashieringLogic _cashieringManager;
        #endregion

        #region Class Constructos
        public ReceiptNumberSearchOnTextBoxList(CommonExchange.SysAccess userInfo, CashieringLogic cashieringManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _cashieringManager = cashieringManager;

            this.pbxRefresh.Click += new EventHandler(pbxRefreshClick);
        }
        #endregion

        #region Class Event Void Procedures
        //####################################CLASS ReceiptNumberSearchOnTextBoxList EVENTS####################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.SetDataGridViewSource(_cashieringManager.GetSearchedCancelledReceiptNo(_userInfo));

            base.ClassLoad(sender, e);

            this.txtSearch.Visible = false;

        }//-------------------------
        //####################################END CLASS ReceiptNumberSearchOnTextBoxList EVENTS####################################        

        //##################################DATAGRIDVIEW dgvList EVENTS##########################################################
        //event is raised when the mouse is double clicked
        protected override void dgvListDoubleClick(object sender, EventArgs e)
        {
            base.dgvListDoubleClick(sender, e);

            using (ReceiptInformationUpdate frmUpdate =
                new ReceiptInformationUpdate(_userInfo, _cashieringManager.GetCancelledReceiptInformationDetails(this.PrimaryId), _cashieringManager))
            {
                frmUpdate.ShowDialog(this);

                if (frmUpdate.HasUpdated || frmUpdate.HasDeleted)
                {
                    this.SetDataGridViewSource(_cashieringManager.GetSearchedCancelledReceiptNo(_userInfo));
                }
            }
        }
        //--------------------------
        //##################################END DATAGRIDVIEW dgvList EVENTS##########################################################

        //##################################PICTUREBOX pbxRefresh EVENTS######################################################
        //event is raised when the picture box is clicked
        private void pbxRefreshClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.txtSearch.Clear();

            this.Cursor = Cursors.Arrow;
        }//-----------------
        //##################################END PICTUREBOX pbxRefresh EVENTS######################################################

        #endregion
    }
}
