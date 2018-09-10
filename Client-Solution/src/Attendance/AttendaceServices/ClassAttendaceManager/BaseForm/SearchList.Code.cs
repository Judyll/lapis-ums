using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace AttendaceServices
{
    public delegate void SearchListDataGridDoubleClickEnter(String id);

    partial class SearchList
    {
        #region Class Event Declarations
        public event SearchListDataGridDoubleClickEnter OnDoubleClickEnter;
        #endregion

        #region Class Properties Declarations

        private Point _location = new Point(50, 300);
        public Point LocationPoint
        {
            get { return _location; }
            set { _location = value; }
        }

        private Int32 _primaryIndex = 0;
        public Int32 PrimaryIndex
        {
            get { return _primaryIndex; }
            set { _primaryIndex = value; }
        }

        protected String _primaryId = "";
        public String PrimaryId
        {
            get { return _primaryId; }
        }

        public DataTable DataSource
        {
            set { this.SetDataGridViewSource(value); }
        }

        public Int32 RowCount
        {
            get { return dgvList.Rows.Count; }
        }

        private Boolean _adoptGridSize = false;
        public Boolean AdoptGridSize
        {
            get { return _adoptGridSize; }
            set { _adoptGridSize = value; }
        }

        #endregion        

        #region Class Constructor
        public SearchList()
        {
            InitializeComponent();

            this.Load += new EventHandler(ClassLoad);
            this.dgvList.MouseDown += new MouseEventHandler(dgvListMouseDown);
            this.dgvList.DoubleClick += new EventHandler(dgvListDoubleClick);
            this.dgvList.KeyPress += new KeyPressEventHandler(dgvListKeyPress);
            this.dgvList.KeyDown += new KeyEventHandler(dgvListKeyDown);
            this.dgvList.DataSourceChanged += new EventHandler(dgvListDataSourceChanged);
            this.dgvList.SelectionChanged += new EventHandler(dgvListSelectionChanged);
        }

        
        #endregion

        #region Class Event Void Procedures

        //###############################################CLASS EmployeeSearchList EVENTS##################################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            this.Location = _location;

            RemoteClient.ProcStatic.SetDataGridViewColumns(dgvList, _adoptGridSize);

            if (_adoptGridSize)
            {
                this.Width = dgvList.Width + 30;
            }

        } //-------------------------------------

        //############################################END CLASS EmployeeSearchList EVENTS##################################################

        //####################################################DATAGRIDVIEW dgvList EVENTS####################################################
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
                        _primaryId = "";
                        break;
                }

                if (rowIndex != -1)
                {
                    _primaryId = dgvBase[_primaryIndex, rowIndex].Value.ToString();
                }
            }

        } //-----------------------------

        //event is raised when the mouse is double clicked
        private void dgvListDoubleClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_primaryId))
            {
                SearchListDataGridDoubleClickEnter ev = OnDoubleClickEnter;

                if (ev != null)
                {
                    OnDoubleClickEnter(_primaryId);
                }
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

                    _primaryId = row.Cells[_primaryIndex].Value.ToString();

                    SearchListDataGridDoubleClickEnter ev = OnDoubleClickEnter;

                    if (ev != null)
                    {
                        OnDoubleClickEnter(_primaryId);
                    }
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
        
        //event is raised when the data source is changed
        private void dgvListDataSourceChanged(object sender, EventArgs e)
        {
            DataGridView dgvBase = (DataGridView)sender;
            Int32 result = dgvBase.Rows.Count;

            if (result == 1)
            {
                _primaryId = dgvBase[_primaryIndex, 0].Value.ToString();                
            }
            else
            {
                _primaryId = "";
            }

            if (result == 0 || result == 1)
            {
                this.lblResult.Text = result.ToString() + " Record";                
            }
            else
            {
                this.lblResult.Text = result.ToString() + " Records";
            }
            
        } //--------------------------------

        //event is raised when the selection is changed
        protected virtual void dgvListSelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgvBase = (DataGridView)sender;

            if (dgvBase.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                DataGridViewRow row = dgvBase.SelectedRows[0];

                _primaryId = row.Cells[_primaryIndex].Value.ToString();               
            }
        } //------------------------------------

        //################################################END DATAGRIDVIEW dgvList EVENTS####################################################
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure selects the first row in the datagridview
        public void SelectFirstRowInDataGridView()
        {
            if (dgvList.Rows.Count >= 1)
            {
                dgvList.Rows[0].Selected = true;
                dgvList.Focus();
            }

        } //-----------------------

        //this procedure sets the datasource
        protected virtual void SetDataGridViewSource(DataTable srcTable)
        {
            this.Cursor = Cursors.WaitCursor;

            this.Location = _location;

            this.dgvList.DataSource = srcTable;

            if (dgvList.Rows.Count >= 1)
            {
                dgvList.Rows[0].Selected = false;
            }

            this.Show();
            this.WindowState = FormWindowState.Normal;

            this.Cursor = Cursors.Arrow;
        } //----------------------------

        #endregion
    }
}
