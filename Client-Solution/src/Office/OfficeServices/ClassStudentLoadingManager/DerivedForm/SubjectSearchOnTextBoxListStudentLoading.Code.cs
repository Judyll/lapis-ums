using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace OfficeServices
{
    partial class SubjectSearchOnTextBoxListStudentLoading
    {
        #region Class Properties Declaration
        private Boolean _isIregularLoading = false;
        public Boolean IsIrregularLoading
        {
            get { return _isIregularLoading; }
            set { _isIregularLoading = value; }
        }
        #endregion

        #region Class General Variable Declaration
        private CommonExchange.SysAccess _userInfo;
        private StudentLoadingLogic _studentManager;

        private Boolean _isChecked = false;
        private Boolean _isInternational = false;

        private Int32 _selected = 0;
        #endregion

        #region Class Constructors 
        public SubjectSearchOnTextBoxListStudentLoading(CommonExchange.SysAccess userInfo, 
            StudentLoadingLogic studentManager, Int32 primaryIndex, Boolean isInternational)
        {
            this.InitializeComponent();

            this.PrimaryIndex = primaryIndex;

            _isInternational = isInternational;

            _userInfo = userInfo;
            _studentManager = studentManager;

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.dgvList.CellContentClick += new DataGridViewCellEventHandler(dgvListCellContentClick);
            this.dgvList.CellEnter += new DataGridViewCellEventHandler(dgvListCellEnter);
            this.pbxRefresh.Click += new EventHandler(pbxRefreshClick);
            this.pbxChecked.Click += new EventHandler(pbxCheckedClick);
            this.pbxInsertSubjects.Click += new EventHandler(pbxInsertSubjectsClick);
            this.chkIsIrregular.CheckedChanged += new EventHandler(chkIsIrregularCheckedChanged);
        }
        #endregion

        #region Class Event Void Procedures
        //####################################CLASS SubjectSearchOnTextBoxListStudentLoading EVENTS####################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.SetDataGridViewSource(_studentManager.SubjectTableFormat);
           
            base.ClassLoad(sender, e);

            this.dgvDetails.DataSource = _studentManager.ScheduleDetailsTableFormat;
            RemoteClient.ProcStatic.SetDataGridViewColumns(this.dgvDetails, false);

            ToolTip ttTool = new ToolTip();

            ttTool.SetToolTip(this.pbxInsertSubjects, "Load Selected Schedule.");

            this.pbxChecked.Location = new Point(12, 19);

            this.dgvList.ReadOnly = false;

            this.chkIsIrregular.Checked = _isIregularLoading;
        }//----------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
             if (_selected > 0 && !_hasSelected)
            {
                String strMsg = "There has been changes made in the current subject search module. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }           
        }//---------------------------
        //####################################END CLASS SubjectSearchOnTextBoxListStudentLoading EVENTS####################################

        //#############################################PICTUREBOX pbxDone EVENTS##############################################################
        //event is raised when the picturebox is clicked
        protected override void pbxDoneClick(object sender, EventArgs e)
        {
            _isIregularLoading = false;

            base.pbxDoneClick(sender, e);
        }//-------------------------
        //#############################################END PICTUREBOX pbxDone EVENTS##############################################################

        //####################################################DATAGRIDVIEW dgvList EVENTS####################################################     
        //event is raised when the mouse is enter
        private void dgvListCellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                this.dgvList.BeginEdit(true);

                //DD Code July 20, 2010
                //Int16 slots;                
                //if ((!String.Equals(this.dgvList[6, e.RowIndex].Value.ToString(), "0")) &&
                //    (Int16.TryParse((this.dgvList[6, e.RowIndex].Value).ToString(), out slots) && slots >= 0))

                //AD code July 20, 2010.. Added Code to get no slots available
                if (_studentManager.IsNoHasSlotsAvailable((this.dgvList[1, e.RowIndex].Value).ToString()))
                {
                    this.dgvList[0, e.RowIndex].ReadOnly = true;
                }
                else
                {
                    this.dgvList[0, e.RowIndex].ReadOnly = false;
                }
            
                DataGridViewCell dgvCell = this.dgvList.Rows[e.RowIndex].Cells["sysid_schedule"];

                dgvCell.ErrorText = String.Empty;

                String strTemp = String.Empty;

                if (_studentManager.HasConflictSchedule((System.Data.DataTable)this.dgvList.DataSource,
                   this.dgvList.Rows[e.RowIndex].Cells["sysid_schedule"].Value.ToString(), ref strTemp))
                {
                    this.dgvList[0, e.RowIndex].ReadOnly = true;
                    this.dgvList.ShowRowErrors = true;
                }
                else
                {
                    this.dgvList[0, e.RowIndex].ReadOnly = false;
                }

                this.dgvList.EndEdit();
            }
            else
            {
                this.dgvList.Rows[e.RowIndex].ReadOnly = true;                
            }
        }//---------------------------

        //event is raised when the cell content is clicked
        private void dgvListCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                this.dgvList.ShowCellErrors = false; 

                String scheduleInformation = String.Empty;

                DataGridViewCell dgvCell = this.dgvList.Rows[e.RowIndex].Cells["sysid_schedule"];

                for (Int32 x = 0; x < this.dgvList.Rows.Count; x++)
                {
                    DataGridViewCell dgvCellClear = this.dgvList.Rows[x].Cells["sysid_schedule"];

                    dgvCellClear.ErrorText = String.Empty;
                }

                //DD Code July 20, 2010
                //Int16 slots;
                 //if ((String.Equals(this.dgvList.Rows[e.RowIndex].Cells["slots_available"].Value, "0")) ||
                 //   (Int16.TryParse((this.dgvList.Rows[e.RowIndex].Cells["slots_available"].Value).ToString(), out slots) && slots <= 0))


                //AD code July 20, 2010.. Added Code to get no slots available
                if (_studentManager.IsNoHasSlotsAvailable((this.dgvList.Rows[e.RowIndex].Cells["sysid_schedule"].Value).ToString()))
                {
                    //DataGridViewCell dgvCell = this.dgvList.Rows[e.RowIndex].Cells["sysid_schedule"];

                    dgvCell.ErrorText = "There are no slots available.";

                    ToolTip errToolTip = new ToolTip();

                    errToolTip.Show(dgvCell.ErrorText, this.dgvList, 10);

                    this.dgvList.Rows[e.RowIndex].Cells["checkbox_column"].Value = false;
                                        
                    this.dgvList.ShowCellErrors = true;
                }
                else if (!(Boolean)this.dgvList.Rows[e.RowIndex].Cells["checkbox_column"].Value &&
                    (_studentManager.HasConflictSchedule((System.Data.DataTable)this.dgvList.DataSource,
                    this.dgvList.Rows[e.RowIndex].Cells["sysid_schedule"].Value.ToString(), ref scheduleInformation)))
                {
                    //DataGridViewCell dgvCell = this.dgvList.Rows[e.RowIndex].Cells["sysid_schedule"];

                    String value = String.Empty;

                    if (!String.IsNullOrEmpty(scheduleInformation))
                    {
                        value = scheduleInformation.Remove(scheduleInformation.Length - 2, 2);
                    }

                    dgvCell.ErrorText = value;

                    ToolTip errToolTip = new ToolTip();

                    errToolTip.Show(dgvCell.ErrorText, this.dgvList, 10);

                    this.dgvList.Rows[e.RowIndex].Cells["checkbox_column"].Value = false;

                    this.dgvList.ShowCellErrors = true;
                }
                else
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
                }

                this.dgvList.EndEdit();
            }
        }//-----------------------------   

        //event is raised when the selection is changed
        protected override void dgvListSelectionChanged(object sender, EventArgs e)
        {
            base.dgvListSelectionChanged(sender, e);

            if (!String.IsNullOrEmpty(this.PrimaryId))
            {
                _studentManager.InitializeSubjectLoadWithdrawDetailsListViewDataGridView(null, this.PrimaryId, false, this.dgvDetails);
            }
        }//-----------------------------

        //event is raised when the control is double clicked
        protected override void dgvListDoubleClick(object sender, EventArgs e)
        {            
        }//----------------------
        //####################################################END DATAGRIDVIEW dgvList EVENTS####################################################

        //##################################TEXTBOX txtSearch EVENTS##########################################################
        //event is raised when the key is up
        protected override void txtSearchKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    this.SetDataGridViewSource(_studentManager.GetSearchedSubjectInformation(((TextBox)sender).Text));

                    this.SelectFirstRowInDataGridView();

                    for (Int32 x = 0; x < this.dgvList.Rows.Count; x++)
                    {
                        //DD Cod July 20, 2010
                        //if ((String.Equals(this.dgvList[6, x].Value.ToString(), "0")) ||
                        //    (Int16.TryParse((this.dgvList[6, x].Value).ToString(), out slots) && slots <= 0))


                        //AD code July 20, 2010.. Added Code to get no slots available
                        if (_studentManager.IsNoHasSlotsAvailable((this.dgvList[1, x].Value).ToString()))
                        {
                            this.dgvList[0, x].ReadOnly = true;
                        }
                        else
                        {
                            this.dgvList[0, x].ReadOnly = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Retrieving Student List");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }

            base.txtSearchKeyUp(sender, e);
        }//--------------------
        //##################################END TEXTBOX txtSearch EVENTS##########################################################

        //##################################PICTUREBOX pbxRefresh EVENTS######################################################
        //event is raised when the picture box is clicked
        private void pbxRefreshClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            this.txtSearch.Clear();
            this.dgvList.Refresh();

            this.Cursor = Cursors.Arrow;
        }//----------------------
        //##################################END PICTUREBOX pbxRefresh EVENTS######################################################

        //##################################PICTUREBOX pbxChecked EVENTS######################################################
        //event is raised when the picture box is clicked
        private void pbxCheckedClick(object sender, EventArgs e)
        {
            _isChecked = !_isChecked;

            _selected = 0;

            this.dgvList.EndEdit();

            this.dgvList.ShowCellErrors = _isChecked ? true : false;

            for (Int32 x = 0; x < this.dgvList.Rows.Count; x++)
            {
                String scheduleInformation = String.Empty;

                DataGridViewCell dgvCell = this.dgvList.Rows[x].Cells["sysid_schedule"];

                dgvCell.ErrorText = String.Empty; 

                //DD Code
                //if (String.Equals(this.dgvList.Rows[x].Cells["slots_available"].Value, "0"))

                //AD code July 20, 2010.. Added Code to get no slots available
                if (_studentManager.IsNoHasSlotsAvailable((this.dgvList.Rows[x].Cells["sysid_schedule"].Value).ToString()))
                {
                    //DataGridViewCell dgvCell = this.dgvList.Rows[x].Cells["sysid_schedule"];

                    dgvCell.ErrorText = "There are no slots available.";

                    ToolTip errToolTip = new ToolTip();

                    errToolTip.Show(dgvCell.ErrorText, this.dgvList, 10);

                    this.dgvList[0, x].ReadOnly = true;
                }
                else if (!(Boolean)this.dgvList.Rows[x].Cells["checkbox_column"].Value && 
                    _studentManager.HasConflictSchedule((System.Data.DataTable)this.dgvList.DataSource,
                    this.dgvList.Rows[x].Cells["sysid_schedule"].Value.ToString(), ref scheduleInformation))
                {
                    //DataGridViewCell dgvCell = this.dgvList.Rows[x].Cells["sysid_schedule"];

                    String value = String.Empty;

                    if (!String.IsNullOrEmpty(scheduleInformation))
                        value = scheduleInformation.Remove(scheduleInformation.Length - 2, 2);

                    dgvCell.ErrorText = value;

                    ToolTip errToolTip = new ToolTip();

                    errToolTip.Show(dgvCell.ErrorText, this.dgvList, 10);
                }
                else
                {
                    dgvList.Rows[x].Cells["checkbox_column"].Value = _isChecked;

                    this.dgvList[0, x].ReadOnly = false;

                    if (_isChecked)
                    {
                        _selected++;
                    }
                }
            }
            
            this.lblSelected.Text = _selected.ToString();

            this.pbxInsertSubjects.Focus();
        }//----------------------
        //##################################END PICTUREBOX pbxChecked EVENTS#########################################################

        //##################################PICTUREBOX pbxInsertSubjects EVENTS######################################################
        //event is raised when the picture box is clicked
        private void pbxInsertSubjectsClick(object sender, EventArgs e)
        {
            Boolean isValid = true;
            Boolean hasInserted = false;

            for (Int32 x = 0; x < this.dgvList.Rows.Count; x++)
            {
                if ((Boolean)this.dgvList.Rows[x].Cells["checkbox_column"].Value)
                {
                    if (!_studentManager.InsertStudentLoad(dgvList.Rows[x].Cells["sysid_schedule"].Value.ToString(), _isInternational))
                    {
                        DataGridViewCell dgvCell = this.dgvList.Rows[x].Cells["sysid_schedule"];

                        dgvCell.ErrorText = "This schedule conflicts with another ";

                        ToolTip errToolTip = new ToolTip();

                        errToolTip.Show(dgvCell.ErrorText, this.dgvList, 10);

                        isValid = false;
                    }
                    else
                    {
                        hasInserted = true;
                    }
                }
            }

            if (isValid)
            {
                if (hasInserted)
                {
                    _hasSelected = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("There is no subject schedule that has been selected!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }//-----------------------
        //##################################END PICTUREBOX pbxInsertSubjects EVENTS######################################################

        //##################################CHECKBOX chkIsIrregularLoading EVENTS######################################################
        //event is raised when the checked status is changed
        private void chkIsIrregularCheckedChanged(object sender, EventArgs e)
        {
            _isIregularLoading = this.chkIsIrregular.Checked;
        }//--------------------------
        //##################################END CHECKBOX chkIsIrregularLoading EVENTS######################################################
        #endregion
    }
}
