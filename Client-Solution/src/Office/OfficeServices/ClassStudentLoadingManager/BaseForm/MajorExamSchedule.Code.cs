using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class MajorExamSchedule
    {

        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private StudentLoadingLogic _studentManager;

        private String _majorExamId;

        private ListViewItem _editItem;
        #endregion

        #region Class Properties
        private Boolean _hasClickedPrint = false;
        public Boolean HasClickedPrint
        {
            get { return _hasClickedPrint; }
            set { _hasClickedPrint = value; }
        }

        private String _editedDate = String.Empty;
        public String EditedDate
        {
            get { return _editedDate; }
        }

        private DataTable _studentTable;
        public DataTable StudentTable
        {
            get { return _studentTable; }
        }
        #endregion

        #region Class Constructor
        public MajorExamSchedule(CommonExchange.SysAccess userInfo, StudentLoadingLogic studentManager, Boolean showFilterLink)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _studentManager = studentManager;

            this.Load += new EventHandler(ClassLoad);
            this.btnClose.Click += new EventHandler(btnClose_lick);
            this.lsvMajorExam.ItemChecked += new ItemCheckedEventHandler(lsvMajorExamItemChecked);
            this.lsvMajorExam.MouseDown += new MouseEventHandler(lsvMajorExamMouseDown);
            this.btnPrint.Click += new EventHandler(btnPrintClick);
            this.lblChangeExamDate.Click += new EventHandler(lblChangeExamDateClick);

            if (showFilterLink)
            {
                this.lnkFilter.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkFilterLinkClicked);
                this.lnkFilter.Visible = true;
            }
        }
        #endregion

        #region Class Event Void Procedures
        //###########################################CLASS MajorExamSchedule EVENTS#####################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _studentManager.InitializeMajorExamListView(this.lsvMajorExam);

            _editItem = new ListViewItem();
        }//-----------------------
        //###########################################END CLASS MajorExamSchedule EVENTS#####################################################

        //###########################################BUTTON btnClose EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnClose_lick(object sender, EventArgs e)
        {
            this.Close();
        }//---------------------
        //###########################################END BUTTON btnClose EVENTS####################################################

        //###########################################LISTVIEW lsvMajorExam EVENTS#####################################################
        //event is raised when the checked is changed
        private void lsvMajorExamItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked && _studentManager.IsClearanceIncluded(e.Item.SubItems[1].Text))
            {
                this.lsvMajorExam.ItemChecked -= new ItemCheckedEventHandler(lsvMajorExamItemChecked);

                _studentManager.InitializeInsertedExamSchedule(e.Item.SubItems[1].Text, e.Item.Checked);

                Int32 index = 0;

                foreach (ListViewItem item in lsvMajorExam.Items)
                {
                    if (item.Checked && index!= e.Item.Index)
                    {
                        item.Checked = false;

                        _studentManager.InitializeInsertedExamSchedule(item.SubItems[1].Text, item.Checked);
                    }

                    index++;
                }

                this.lsvMajorExam.ItemChecked += new ItemCheckedEventHandler(lsvMajorExamItemChecked);
            }
            else if (e.Item.Checked && !_studentManager.IsClearanceIncluded(e.Item.SubItems[1].Text))
            {
                this.lsvMajorExam.ItemChecked -= new ItemCheckedEventHandler(lsvMajorExamItemChecked);

                _studentManager.InitializeInsertedExamSchedule(e.Item.SubItems[1].Text, e.Item.Checked);

                Int32 index = 0;

                foreach (ListViewItem item in lsvMajorExam.Items)
                {
                    if (_studentManager.IsClearanceIncluded(item.SubItems[1].Text))
                    {
                        item.Checked = false;

                        _studentManager.InitializeInsertedExamSchedule(item.SubItems[1].Text, item.Checked);
                    }

                    index++;
                }

                this.lsvMajorExam.ItemChecked += new ItemCheckedEventHandler(lsvMajorExamItemChecked);
            }
            else
            {
                this.lsvMajorExam.ItemChecked -= new ItemCheckedEventHandler(lsvMajorExamItemChecked);

                _studentManager.InitializeInsertedExamSchedule(e.Item.SubItems[1].Text, e.Item.Checked);
               
                this.lsvMajorExam.ItemChecked += new ItemCheckedEventHandler(lsvMajorExamItemChecked);
            }           

            this.btnPrint.Enabled = this.lnkFilter.Enabled = this.lsvMajorExam.CheckedItems.Count <= 0 ? false : true;
        }//-----------------------

        //event is raise when the mouse is down
        private void lsvMajorExamMouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Right || e.Button == MouseButtons.Left) &&
                 (this.lsvMajorExam.Items.Count > 0 && this.lsvMajorExam.FocusedItem != null))
            {
                if (this.lsvMajorExam.SelectedItems.Count > 0)
                {
                    if (this.lsvMajorExam.GetItemAt(e.X, e.Y) != null && e.Button == MouseButtons.Right)
                    {
                        _editItem = this.lsvMajorExam.GetItemAt(e.X, e.Y);

                        _majorExamId = this.lsvMajorExam.GetItemAt(e.X, e.Y).SubItems[1].Text;

                        this.cmsChangeExamDate.Show(this.lsvMajorExam, new Point(e.X, e.Y));                        
                    }
                }
            }
        }//---------------------
        //###########################################END LISTVIEW lsvMajorExam EVENTS#####################################################

        //###########################################BUTTON btnPrint EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnPrintClick(object sender, EventArgs e)
        {
            _hasClickedPrint = true;

            _studentTable = _studentManager.StudentTable;

            this.Close();
        }//----------------------
        //###########################################END BUTTON btnPrint EVENTS#####################################################

        //###########################################BUTTON lnkFilter EVENTS#####################################################
        //event is raised when the control is clicked
        private void lnkFilterLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (FilteredStudentSearch frmFilter = new FilteredStudentSearch(_userInfo, _studentManager))
            {
                frmFilter.ShowDialog(this);

                if (frmFilter.HasClickedPrint)
                {
                    _hasClickedPrint = true;

                    _studentTable = frmFilter.FilteredStudentTable;

                    this.Close();
                }
            }
        }//----------------------
        //###########################################END BUTTON lnkFilter EVENTS#####################################################

        //###########################################BUTTON lblChangeExamDate EVENTS#####################################################
        //event is raised when the control is clicked
        private void lblChangeExamDateClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            DateTime eDate = DateTime.Parse(_studentManager.ServerDateTime);

            using (RemoteClient.DatePicker frmPicker = new RemoteClient.DatePicker(eDate))
            {
                frmPicker.ShowDialog(this);

                if (frmPicker.HasSelectedDate)
                {
                    if (DateTime.TryParse(frmPicker.GetSelectedDate.ToLongDateString() + " " +
                            DateTime.Parse(_studentManager.ServerDateTime).ToLongTimeString(), out eDate))
                    {
                        _editItem.SubItems[2].Text = _editedDate = eDate.ToLongDateString();

                        _studentManager.EditMajorExamTable(_majorExamId, _editedDate);
                    }
                }
                else
                {
                    _editedDate = String.Empty;
                }
            }

            this.Cursor = Cursors.Arrow;
        }//------------------------
        //###########################################END BUTTON lblChangeExamDate EVENTS#####################################################
        #endregion
    }
}
