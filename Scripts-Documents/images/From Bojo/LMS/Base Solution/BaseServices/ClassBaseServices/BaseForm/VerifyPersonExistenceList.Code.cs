using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace BaseServices
{
    partial class VerifyPersonExistenceList
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private BaseServicesLogic _baseServicesManager;
        private DataTable _dataSource;

        private ToolTip _ttpTool;
        #endregion

        #region Class Properties Declaration
        private String _primaryId = String.Empty;
        public String PrimaryId
        {
            get { return _primaryId; }
        }

        private Int32 _rowIndex = -1;
        public Int32 RowIndex
        {
            get { return _rowIndex; }
        }

        private Boolean _hasSelected = false;
        public Boolean HasSelected
        {
            get { return _hasSelected; }
        }

        private Boolean _isVerified = false;
        public Boolean IsVerified
        {
            get { return _isVerified; }
        }
        #endregion

        #region Class Constructors
        public VerifyPersonExistenceList(CommonExchange.SysAccess userInfo, BaseServicesLogic baseServicesManager, String personName, DataTable dataSource)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _baseServicesManager = baseServicesManager;
            _dataSource = dataSource;
            this.lblPersonName.Text = personName;

            this.Load += new EventHandler(ClassLoad);
            this.dgvList.MouseDown += new MouseEventHandler(dgvListMouseDown);
            this.dgvList.DataSourceChanged += new EventHandler(dgvListDataSourceChanged);
            this.dgvList.MouseDoubleClick += new MouseEventHandler(dgvListMouseDoubleClick);
            this.dgvList.SelectionChanged += new EventHandler(dgvListSelectionChanged);
            this.pbxProceed.Click += new EventHandler(pbxProceedClick);
        }
        #endregion

        #region Class Event Void Procedures
        //####################################################CLASS VerifyPersonExistenceList EVENTS###############################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _ttpTool = new ToolTip();

            _ttpTool.SetToolTip(this.pbxProceed, "Proceed");

            this.dgvList.DataSource = _dataSource;

            ProcStatic.SetDataGridViewColumns(this.dgvList, false);
        }//------------------------
        //####################################################END CLASS VerifyPersonExistenceList EVENTS###############################################

        //####################################################DATAGRIDVIEW dgvList EVENTS####################################################
        //event is raised when the mouse is down
        private void dgvListMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView dgvBase = (DataGridView)sender;

                DataGridView.HitTestInfo hitTest = dgvBase.HitTest(e.X, e.Y);

                switch (hitTest.Type)
                {
                    case DataGridViewHitTestType.Cell:
                        _rowIndex = hitTest.RowIndex;
                        break;
                    case DataGridViewHitTestType.RowHeader:
                        _rowIndex = hitTest.RowIndex;
                        break;
                    default:
                        _rowIndex = -1;
                        _primaryId = "";
                        break;
                }
            }
        }//------------------------

        //event is raised when the datasource is changed
        private void dgvListDataSourceChanged(object sender, EventArgs e)
        {
            DataGridView dgvBase = (DataGridView)sender;
            Int32 result = dgvBase.Rows.Count;

            if (result == 1)
            {
                _rowIndex = 0;
            }
            else
            {
                _rowIndex = -1;
            }
        }//---------------------------

        //event is raised when the mouse is double clicked
        private void dgvListMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_rowIndex >= 0)
            {
                _hasSelected = true;               

                this.Close();
            }
        }//---------------------------

        //event is raised when the selection is changed
        private void dgvListSelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgvBase = (DataGridView)sender;

            if (dgvBase.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                DataGridViewRow row = dgvBase.SelectedRows[0];

                _primaryId = row.Cells[0].Value.ToString();
            }
        }//-----------------------
        //####################################################END DATAGRIDVIEW dgvList EVENTS####################################################

        //####################################################PICTUREBOX pbxProceed EVENTS#######################################################
        //event is raised when the control is clicked
        private void pbxProceedClick(object sender, EventArgs e)
        {
            _isVerified = true;

            this.Close();

        } //--------------------------
        //####################################################END PICTUREBOX pbxProceed EVENTS####################################################   
        #endregion
    }
}
