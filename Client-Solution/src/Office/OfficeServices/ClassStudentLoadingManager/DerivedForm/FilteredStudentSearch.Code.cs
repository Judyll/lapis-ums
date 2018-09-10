using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class FilteredStudentSearch
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private StudentLoadingLogic _studentManager;

        private Int32 _selected = 0;
        #endregion

        #region Class Properties
        private Boolean _hasClickedPrint = false;
        public Boolean HasClickedPrint
        {
            get { return _hasClickedPrint; }
            set { _hasClickedPrint = value; }
        }

        private DataTable _filteredStudentTable;
        public DataTable FilteredStudentTable
        {
            get { return _filteredStudentTable; }
        }
        #endregion

        #region Class Constructors
        public FilteredStudentSearch(CommonExchange.SysAccess userInfo, StudentLoadingLogic studentManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _studentManager = studentManager;

            this.dgvList.CellContentClick += new DataGridViewCellEventHandler(dgvListCellContentClick);
            this.btnPrint.Click += new EventHandler(btnPrintClick);
        }

        #endregion

        #region Class Event Void Procedures
        //####################################CLASS FilteredStudentSearch EVENTS####################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.SetDataGridViewSource(_studentManager.InitializeFilterPrintStatementOfAccount());

            this.lblSelected.Text = this.dgvList.Rows.Count.ToString();

            _selected = this.dgvList.Rows.Count;

            base.ClassLoad(sender, e);

            this.dgvList.ReadOnly = false;
        }//----------------------------
        //####################################END CLASS FilteredStudentSearch EVENTS####################################

        //####################################################DATAGRIDVIEW dgvList EVENTS####################################################            
        //event is raised when the cell content is clicked
        private void dgvListCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewCheckBoxCell checkedCell = this.dgvList.Rows[e.RowIndex].Cells["checkbox_column"] as DataGridViewCheckBoxCell;

                this.dgvList.Rows[e.RowIndex].Cells["checkbox_column"].Value = (Boolean)checkedCell.Value;

                if (!(Boolean)checkedCell.Value)
                {
                    _selected++;
                }
                else if (_selected > 0)
                {
                    _selected--;
                }

                this.lblSelected.Text = _selected.ToString();

                this.btnPrint.Enabled = _selected > 0 ? true : false;                
            }
        }//-----------------------------   

        //event is raised when the control is double clicked
        protected override void dgvListDoubleClick(object sender, EventArgs e)
        {
        }//----------------------
        //####################################################END DATAGRIDVIEW dgvList EVENTS####################################################

        //####################################################BUTTON btnPrint EVENTS####################################################            
        //event is raised when the cell content is clicked
        private void btnPrintClick(object sender, EventArgs e)
        {
            _hasClickedPrint = true;

            this.txtSearch.Focus();

            _filteredStudentTable = _studentManager.GetFilteredStudentStatementOfAccount((DataTable)this.dgvList.DataSource);

            this.Close();
        }//-----------------------
        //####################################################END BUTTON btnPrint EVENTS####################################################            
        #endregion
    }
}
