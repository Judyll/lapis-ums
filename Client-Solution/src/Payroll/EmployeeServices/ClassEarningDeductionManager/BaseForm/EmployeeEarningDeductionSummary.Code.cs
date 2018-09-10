using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EmployeeServices
{
    partial class EmployeeEarningDeductionSummary
    {
        #region Class General Variable Declarations
        protected DateTime _dateTo;
        protected DateTime _dateFrom;
        private Int64 _primaryId;
        #endregion

        #region Class Constructor
        public EmployeeEarningDeductionSummary()
        {
            InitializeComponent();

            this.Load += new EventHandler(ClassLoad);
            this.lnkChange.Click += new EventHandler(lnkChangeClick);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.dgvList.MouseDown += new MouseEventHandler(dgvListMouseDown);
            this.dgvList.DoubleClick += new EventHandler(dgvListDoubleClick);
            this.dgvList.KeyPress += new KeyPressEventHandler(dgvListKeyPress);
            this.dgvList.KeyDown += new KeyEventHandler(dgvListKeyDown);
            this.dgvList.DataSourceChanged += new EventHandler(dgvListDataSourceChanged);
            this.dgvList.SelectionChanged += new EventHandler(dgvListSelectionChanged);
            this.txtSearch.KeyUp += new KeyEventHandler(txtSearchKeyUp);
            this.btnPrint.Click += new EventHandler(btnPrintClick);
        }    
        #endregion

        #region Class Event Void Procedures

        //###########################################CLASS EmployeeEarningDeductionSummary EVENTS####################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            _dateTo = _dateFrom = DateTime.Now;
        } //-----------------------------------
        //#####################################END CLASS EmployeeEarningDeductionSummary EVENTS######################################

        //###################################################LINKBUTTON lnkChange EVENTS###########################################
        //event is raised when the link is clicked
        private void lnkChangeClick(object sender, EventArgs e)
        {
            using (RemoteClient.DateRangePicker frmPicker = new RemoteClient.DateRangePicker(_dateFrom, _dateTo))
            {
                frmPicker.ShowDialog(this);

                if (frmPicker.HasUseRange)
                {
                    DateTime dFrom;
                    DateTime dTo;

                    if (DateTime.TryParse(frmPicker.GetDateFrom.ToShortDateString() + " 12:00:00 AM", out dFrom))
                    {
                        _dateFrom = dFrom;
                    }
                    else
                    {
                        _dateFrom = frmPicker.GetDateFrom;
                    }

                    if (DateTime.TryParse(frmPicker.GetDateTo.ToShortDateString() + " 11:59:59 PM", out dTo))
                    {
                        _dateTo = dTo;
                    }
                    else
                    {
                        _dateTo = frmPicker.GetDateTo;
                    }

                    lblDate.Text = _dateFrom.ToLongDateString() + "  -  " + _dateTo.ToLongDateString();

                    this.UpdateDataGridViewResult(true);
                }
            }

        } //-----------------------------------
        //################################################END LINKBUTTON lnkChange EVENTS###########################################

        //##################################################BUTTON btnClose EVENTS##################################################
        //event is raised when the button is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        } //------------------------------        
        //##############################################END BUTTON btnClose EVENTS####################################################

        //############################################DATAGRIDVIEW dgvList EVENTS#####################################################
        //event is raised when the mouse is down
        private void dgvListMouseDown(object sender, MouseEventArgs e)
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
                        _primaryId = -1;
                        break;
                }

                if (rowIndex != -1)
                {
                    _primaryId = (Int64)dgvBase[0, rowIndex].Value;
                }
            }

        } //-----------------------------

        //event is raised when the mouse is double clicked
        private void dgvListDoubleClick(object sender, EventArgs e)
        {
            if (_primaryId >= 0)
            {
                this.ShowUpdateForm(_primaryId);
            }

        } //---------------------------------

        //event is raised when the key is pressed        
        private void dgvListKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                DataGridView dgvBase = (DataGridView)sender;

                if (dgvBase.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
                {
                    DataGridViewRow row = dgvBase.SelectedRows[0];

                    _primaryId = (Int64)row.Cells[0].Value;

                    this.ShowUpdateForm(_primaryId);
                }

            }
            else
            {
                e.Handled = true;
            }
        } //-----------------------------------

        //event is raised when the key is up
        private void dgvListKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        } //--------------------------------------

        //event is raised when the selection is changed
        protected virtual void dgvListSelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgvBase = (DataGridView)sender;

            if (dgvBase.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                DataGridViewRow row = dgvBase.SelectedRows[0];

                _primaryId = (Int64)row.Cells[0].Value;
            }
        } //------------------------------------


        //event is raised when the datasource is changed
        private void dgvListDataSourceChanged(object sender, EventArgs e)
        {
            DataGridView dgvBase = (DataGridView)sender;
            Int32 result = dgvBase.Rows.Count;

            if (result >= 1)
            {
                dgvList.Rows[0].Selected = false;
            }

            if (result == 0 || result == 1)
            {
                this.lblResult.Text = result.ToString() + " Record";
            }
            else
            {
                this.lblResult.Text = result.ToString() + " Records";
            }
        } //---------------------------------
        //##########################################END DATAGRIDVIEW dgvList EVENTS####################################################

        //#######################################TEXTBOX txtSearch EVENTS##############################################################
        //event is raised when the key is up
        private void txtSearchKeyUp(object sender, KeyEventArgs e)
        {
            this.UpdateDataGridViewResult(false);

            if (e.KeyCode == Keys.Down && dgvList.Rows.Count >= 1)
            {
                dgvList.Rows[0].Selected = true;
                dgvList.Focus();
            }

        } //----------------------------
        //#####################################END TEXTBOX txtSearch EVENTS############################################################

        //##################################################BUTTON btnPrint EVENTS#####################################################
        //event is raised when the button is clicked
        protected virtual void btnPrintClick(object sender, EventArgs e)
        {
            
        } //------------------------------------
        //################################################END BUTTON btnPrint EVENTS######################################################

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure updates the data grid view
        protected virtual void UpdateDataGridViewResult(Boolean update)
        {
        } //---------------------------

        //this procedure shows the update form
        protected virtual void ShowUpdateForm(Int64 id)
        {
        } //---------------------------------

        #endregion
    }
}
