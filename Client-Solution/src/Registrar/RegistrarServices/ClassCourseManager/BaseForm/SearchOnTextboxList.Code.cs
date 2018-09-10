using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace RegistrarServices
{
    partial class SearchOnTextboxList
    {
        #region Class General Variable Declarations
        private ToolTip ttpTool;
        #endregion

        #region Class Properties Declarations
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

        private Boolean _adoptGridSize = false;
        public Boolean AdoptGridSize
        {
            get { return _adoptGridSize; }
            set { _adoptGridSize = value; }
        }

        private Boolean _hasSelected;
        public Boolean HasSelected
        {
            get { return _hasSelected; }
        }

        #endregion    
    
        #region Class Constructor
        public SearchOnTextboxList()
        {
            this.InitializeComponent();

            this.Load += new EventHandler(ClassLoad);
            this.dgvList.MouseDown += new MouseEventHandler(dgvListMouseDown);
            this.dgvList.DoubleClick += new EventHandler(dgvListDoubleClick);
            this.dgvList.KeyPress += new KeyPressEventHandler(dgvListKeyPress);
            this.dgvList.KeyDown += new KeyEventHandler(dgvListKeyDown);
            this.dgvList.DataSourceChanged += new EventHandler(dgvListDataSourceChanged);
            this.dgvList.SelectionChanged += new EventHandler(dgvListSelectionChanged);
            this.txtSearch.KeyPress += new KeyPressEventHandler(txtSearchKeyPress);
            this.txtSearch.KeyUp += new KeyEventHandler(txtSearchKeyUp);
            this.pbxDone.Click += new EventHandler(pbxDoneClick);            
        }

        
        #endregion

        #region Class Event Void Procedures

        //###############################################CLASS SearchOnTextboxList EVENTS##################################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            Int32 width = this.Width;

            RemoteClient.ProcStatic.SetDataGridViewColumns(dgvList, _adoptGridSize);

            if (_adoptGridSize)
            {
                this.Width = dgvList.Width + 30;

                if (this.Width > width)
                {
                    this.Location = new Point(this.Location.X - ((this.Width - width) / 2), this.Location.Y);
                }
                else
                {
                    this.Location = new Point(this.Location.X + ((width - this.Width) / 2), this.Location.Y);
                }                
            }

            ttpTool = new ToolTip();

            ttpTool.SetToolTip(pbxDone, "Close");
            ttpTool.SetToolTip(pbxRefresh, "Refresh");            

        } //-------------------------------------

        //############################################END CLASS SearchOnTextboxList EVENTS##################################################

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
                _hasSelected = true;
                this.Close();
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

                    _hasSelected = true;
                    this.Close();
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

        //###################################################TEXTBOX txtSearch EVENTS########################################################
        //event is raised when the key is pressed
        private void txtSearchKeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) ||
                char.IsWhiteSpace(e.KeyChar) || e.KeyChar == '*' || e.KeyChar == '\r' || char.IsPunctuation(e.KeyChar))
            {
                txtSearch.ReadOnly = false;
            }
            else
            {
                txtSearch.ReadOnly = true;
            }
        } //---------------------------------

        //event is raised when the key is up
        protected virtual void txtSearchKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (dgvList.Rows.Count >= 1)
                {
                    dgvList.Rows[0].Selected = true;
                    dgvList.Focus();
                }
            }

        } //----------------------------------
        //#################################################END TEXTBOX txtSearch EVENTS######################################################

        //#############################################PICTUREBOX pbxDone EVENTS##############################################################
        //event is raised when the picturebox is clicked
        private void pbxDoneClick(object sender, EventArgs e)
        {
            this.Close();
        } //--------------------------
        //###########################################END PICTUREBOX pbxDone EVENTS############################################################

        #endregion

        #region Programmer-Defined Void Procedures     

        //this procedure sets the datasource
        protected void SetDataGridViewSource(DataTable srcTable)
        {
            this.Cursor = Cursors.WaitCursor;

            this.dgvList.DataSource = srcTable;

            if (dgvList.Rows.Count >= 1)
            {
                dgvList.Rows[0].Selected = false;
            }            

            this.Cursor = Cursors.Arrow;
        } //----------------------------

        #endregion
    }
}
