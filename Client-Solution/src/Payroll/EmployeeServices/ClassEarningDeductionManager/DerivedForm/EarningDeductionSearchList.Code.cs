using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EmployeeServices
{
    public delegate void EarningDeductionSearchListLinkAddClick();
    public delegate void EarningDeductionSearchListLinkUpdateClick(String id);

    partial class EarningDeductionSearchList
    {
        #region Class Event Declarations
        public event EarningDeductionSearchListLinkAddClick OnAdd;
        public event EarningDeductionSearchListLinkUpdateClick OnUpdate;
        #endregion

        #region Class Constructor
        public EarningDeductionSearchList()
        {
            this.InitializeComponent();

            this.btnAdd.Click += new EventHandler(btnAddClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);           
        }
        #endregion

        #region Class Event Void Procedures
  
        //################################################DATAGRIDVIEW bntCreate EVENTS####################################################
        //event is raised when the link is clicked
        protected override void dgvListDataSourceChanged(object sender, EventArgs e)
        {
            base.dgvListDataSourceChanged(sender, e);

            if (dgvList.Rows.Count == 0 || dgvList.Rows.Count == 1)
            {
                this.lblResult.Text = dgvList.Rows.Count.ToString() + " Record";
            }
            else
            {
                this.lblResult.Text = dgvList.Rows.Count.ToString() + " Records";
            }
        }//---------------------------
        //################################################END DATAGRIDVIEW bntCreate EVENTS####################################################

        //########################################BUTTON btnAdd EVENTS###############################################
        //event is raised when the control is clicked
        private void btnAddClick(object sender, EventArgs e)
        {
            EarningDeductionSearchListLinkAddClick ev = OnAdd;

            if (ev != null)
            {
                OnAdd();
            }
        }//-------------------------------------
        //######################################END BUTTON btnAdd EVENTS###############################################

        //#########################################BUTTON bntUpdate EVENTS#############################################
        //event is raised when the control is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
             EarningDeductionSearchListLinkUpdateClick ev = OnUpdate;

            if (ev != null)
            {
                OnUpdate(_primaryId);
            }
        }//------------------------------
        //########################################END BUTTON bntUpdate EVENTS##########################################

        //####################################################DATAGRIDVIEW dgvList EVENTS####################################################
        //event is raised when the mouse is down
        protected override void dgvListMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView dgvBase = (DataGridView)sender;

                DataGridView.HitTestInfo hitTest = dgvBase.HitTest(e.X, e.Y);

                Int32 rowIndex = -1;

                switch (hitTest.Type)
                {
                    case DataGridViewHitTestType.Cell:
                        rowIndex = hitTest.RowIndex;
                        break;
                    case DataGridViewHitTestType.RowHeader:
                        rowIndex = hitTest.RowIndex;
                        break;
                    default:
                        rowIndex = -1;
                        _primaryId = "";
                        break;
                }

                if (rowIndex != -1)
                {
                    _primaryId = dgvBase[_primaryIndex, rowIndex].Value.ToString();

                    this.btnUpdate.Enabled = true;
                }
            }

        } //-----------------------------

        //########################################DATAGRIDVIEW dgvList EVENTS###############################################
        //event is raised when the selection is changed
        protected override void  dgvListSelectionChanged(object sender, EventArgs e)
        {
 	        base.dgvListSelectionChanged(sender, e);
            this.btnUpdate.Enabled = true;
        } //------------------------------------
        //######################################END DATAGRIDVIEW dgvList EVENTS#############################################

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure initializes the controls
        public void InitializeControl(Boolean forDeduction)
        {
            if (forDeduction)
            {
                this.btnAdd.Text = "Create a deduction";
                this.btnUpdate.Text = "Update a deduction";
            }
            else
            {
                this.btnAdd.Text = "Create an earning";
                this.btnUpdate.Text = "Update an earning";
            }
        } //-----------------------

        //this procedure sets the data source
        protected override void SetDataGridViewSource(System.Data.DataTable srcTable)
        {
            base.SetDataGridViewSource(srcTable);

            this.btnUpdate.Enabled = false;
        } //--------------------------------
        #endregion
    }
}
