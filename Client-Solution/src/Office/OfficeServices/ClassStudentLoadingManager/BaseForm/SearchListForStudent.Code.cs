using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace OfficeServices
{
    public delegate void SearchListDataGridDoubleClickEnterStudent(String id);
    public delegate void SearchListPrintButtonClick();
    public delegate void SearchListDataSourceChange();

    partial class SearchListForStudent
    {
        #region Class Event Declarations
        public event SearchListDataGridDoubleClickEnterStudent OnDoubleClickEnter;
        public event SearchListDataSourceChange OnDataSourceChange;
        public event SearchListPrintButtonClick OnPrintStudentLoadClick;
        public event SearchListPrintButtonClick OnPrintStatementOfAccountClick;
        public event SearchListPrintButtonClick OnPrintStudentMasterListClick;
        public event SearchListPrintButtonClick OnPrintStudentInsuranceListClick;
        public event SearchListPrintButtonClick OnPrintStudentEnrolmentListClick;
        public event SearchListPrintButtonClick OnPrintStudentListClick;
        public event SearchListPrintButtonClick OnPrintStudentQuickCountClick; 
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
        public SearchListForStudent()
        {
            InitializeComponent();

            this.Load += new EventHandler(ClassLoad);
            this.dgvList.MouseDown += new MouseEventHandler(dgvListMouseDown);
            this.dgvList.DoubleClick += new EventHandler(dgvListDoubleClick);
            this.dgvList.KeyPress += new KeyPressEventHandler(dgvListKeyPress);
            this.dgvList.KeyDown += new KeyEventHandler(dgvListKeyDown);
            this.dgvList.DataSourceChanged += new EventHandler(dgvListDataSourceChanged);
            this.dgvList.SelectionChanged += new EventHandler(dgvListSelectionChanged);
            this.btnPrintStudentLoad.Click += new EventHandler(btnPrintStudentLoadClick);
            this.btnPrintStatement.Click += new EventHandler(btnPrintStatementClick);
            this.btnPrintStudentMasterList.Click += new EventHandler(btnPrintStudentMasterListClick);
            this.btnPrintStudentInsurance.Click += new EventHandler(btnPrintStudentInsuranceClick);
            this.btnPrintStudentEnrolmentList.Click += new EventHandler(btnPrintStudentEnrolmentListClick);
            this.btnPrintStudentList.Click += new EventHandler(btnPrintStudentListClick);
            this.btnPrintStudentQuickCount.Click += new EventHandler(btnPrintStudentQuickCountClick);
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
                SearchListDataGridDoubleClickEnterStudent ev = OnDoubleClickEnter;

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

                    SearchListDataGridDoubleClickEnterStudent ev = OnDoubleClickEnter;

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

            this.btnPrintStatement.Enabled = this.btnPrintStudentLoad.Enabled = result >= 1 ? true : false;

            SearchListDataSourceChange ev = OnDataSourceChange;

            if (ev != null)
            {
                OnDataSourceChange();
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

        //####################################################BUTTON btnPrintStudentLoad EVENTS####################################################
        //event is raised when control is clicked
        private void btnPrintStudentLoadClick(object sender, EventArgs e)
        {
            SearchListPrintButtonClick ev = OnPrintStudentLoadClick;

            if (ev != null)
            {
                OnPrintStudentLoadClick();
            }
        }//--------------------------------------
        //####################################################END BUTTON btnPrintStudentLoad EVENTS####################################################

        //####################################################BUTTON btnPrintStatement EVENTS####################################################
        //event is raised when control is clicked
        private void btnPrintStatementClick(object sender, EventArgs e)
        {
            SearchListPrintButtonClick ev = OnPrintStatementOfAccountClick;

            if (ev != null)
            {
                this.Cursor = Cursors.WaitCursor;

                OnPrintStatementOfAccountClick();

                this.Cursor = Cursors.Arrow;
            }
        }//---------------------------------------
        //####################################################END BUTTON btnPrintStatement EVENTS####################################################

        //####################################################BUTTON btnPrintStudentMasterList EVENTS####################################################
        //event is raised when control is clicked
        private void btnPrintStudentMasterListClick(object sender, EventArgs e)
        {
            SearchListPrintButtonClick ev = OnPrintStudentMasterListClick;

            if (ev != null)
            {
                OnPrintStudentMasterListClick();
            }
        }//------------------------------------
        //####################################################END BUTTON btnPrintStudentMasterList EVENTS####################################################

        //####################################################BUTTON btnPrintStudentInsuranceList EVENTS####################################################
        //event is raised when control is clicked
        private void btnPrintStudentInsuranceClick(object sender, EventArgs e)
        {
            SearchListPrintButtonClick ev = OnPrintStudentInsuranceListClick;

            if (ev != null)
            {
                OnPrintStudentInsuranceListClick();
            }
        }//------------------------------
        //####################################################END BUTTON btnPrintStudentInsuranceList EVENTS####################################################

        //####################################################BUTTON btnPrintStudentEnrolmentList EVENTS####################################################
        //event is raised when control is clicked
        private void btnPrintStudentEnrolmentListClick(object sender, EventArgs e)
        {
            SearchListPrintButtonClick ev = OnPrintStudentEnrolmentListClick;

            if (ev != null)
            {
                OnPrintStudentEnrolmentListClick();
            }
        }//--------------------------------
        //####################################################END BUTTON btnPrintStudentEnrolmentList EVENTS####################################################

        //####################################################BUTTON btnPrintStudentList EVENTS####################################################
        //event is raised when control is clicked
        private void btnPrintStudentListClick(object sender, EventArgs e)
        {
            SearchListPrintButtonClick ev = OnPrintStudentListClick;

            if (ev != null)
            {
                OnPrintStudentListClick();
            }
        }//-----------------------------
        //####################################################END BUTTON btnPrintStudentList EVENTS####################################################

        //####################################################BUTTON btnPrintQuickCount EVENTS####################################################
        //event is raised when control is clicked
        private void btnPrintStudentQuickCountClick(object sender, EventArgs e)
        {
               SearchListPrintButtonClick ev = OnPrintStudentQuickCountClick;

            if (ev != null)
            {
                OnPrintStudentQuickCountClick();
            }
        }//----------------------------------------
        //####################################################END BUTTON btnPrintQuickCount EVENTS####################################################
       
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

        //this procedure disable/enable print student list
        public void DisableEnableButtonStudentList(CommonExchange.SysAccess userInfo, Boolean value)
        {
            if (RemoteServerLib.ProcStatic.IsSystemAccessAdmin(userInfo) || RemoteServerLib.ProcStatic.IsSystemAccessCollegeRegistrar(userInfo))
            {
                this.btnPrintStudentList.Enabled = value;
                this.btnPrintStudentInsurance.Enabled = value;
            }
        }//---------------------------

        //this procedure disable/enable print student reacord and student statement of account buttons
        public void DisableEnableButtonStudentRecordStatementOfAccount(Boolean value, CommonExchange.SysAccess userInfo)
        {
            this.btnPrintStatement.Enabled = this.btnPrintStudentLoad.Enabled = value;

            if (value && RemoteServerLib.ProcStatic.IsSystemAccessStudentDataController(userInfo))
            {
                this.btnPrintStatement.Enabled = false;
            }
        }//------------------------

        //this procedure disable/enable print student master list
        public void DisableEnablePrintStudentMasterStudentEnrolmentList(Boolean value, CommonExchange.SysAccess userInfo)
        {
            this.btnPrintStudentMasterList.Enabled = value;          
            this.btnPrintStudentEnrolmentList.Enabled = value;
            this.btnPrintStudentQuickCount.Enabled = value;
        }//-----------------------
       
        //this procedure sets progress bar value
        public void SetProgressBarValue(Int16 value)
        {
            this.pgbPrint.Value = value;
        }//--------------------------

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
