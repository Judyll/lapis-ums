using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImportInterBaseStudentData
{
    public partial class StudentImport : Form
    {
        #region Class General Variable Declarations
        private DataTable _studentTable;
        private CommonExchange.SysAccess _userInfo;
        private String _imagePath;
        #endregion

        #region Class Constructor
        public StudentImport(CommonExchange.SysAccess userInfo)
        {
            InitializeComponent();

            _userInfo = userInfo;

            this.Load += new EventHandler(ClassLoad);
            this.dgvList.DataSourceChanged += new EventHandler(dgvListDataSourceChanged);
            this.btnGetXml.Click += new EventHandler(btnGetXmlClick);
            this.btnExport.Click += new EventHandler(btnExportClick);
            this.chkImage.CheckedChanged += new EventHandler(chkImageCheckedChanged);
        }

        
        
        #endregion

        #region Class Event Void Procedures

        //##########################################CLASS StudentImport EVENTS################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {          
            this.btnExport.Enabled = false;

            this.InitializeStudentDataTable();

            this.dgvList.DataSource = _studentTable;

        } //-------------------------------------
        //########################################END CLASS StudentImport EVENTS###############################################

        //############################################DATAGRIDVIEW dgvList EVENTS##############################################
        //event is raised when the datasource is changed
        private void dgvListDataSourceChanged(object sender, EventArgs e)
        {
            DataGridView dgvBase = (DataGridView)sender;
            Int32 result = dgvBase.Rows.Count;

            if (result == 0 || result == 1)
            {
                this.lblResult.Text = result.ToString() + " Record";
            }
            else
            {
                this.lblResult.Text = result.ToString() + " Records";
            }

            //if (result >= 1)
            //{
            //    dgvList.Rows[0].Selected = false;
            //}

        } //--------------------------------
        //########################################END DATAGRIDVIEW dgvList EVENTS##############################################

        //###############################################BUTTON btnGetXml EVENTS################################################
        //event is raised when the button is clicked
        private void btnGetXmlClick(object sender, EventArgs e)
        {
            this.ImportStudentDataFromXml();
        } //---------------------------------
        //############################################END BUTTON btnGetXml EVENTS###############################################

        //##############################################BUTTON btnExport EVENTS##################################################
        //event is raised when the button is clicked
        private void btnExportClick(object sender, EventArgs e)
        {
            this.btnExport.Enabled = false;
            this.btnGetXml.Enabled = false;
            this.chkImage.Enabled = false;

            this.ExportStudentDataToSqlServer();

            this.btnExport.Enabled = true;
            this.btnGetXml.Enabled = true;
            this.chkImage.Enabled = true;
        } //----------------------------------
        //##########################################END BUTTON btnExport EVENTS##################################################

        //##############################################CHECKBOX chkImage EVENTS##################################################
        //event is raised when the checked is changed
        private void chkImageCheckedChanged(object sender, EventArgs e)
        {
            if (chkImage.Checked)
            {
                using (FolderBrowserDialog frmBrowser = new FolderBrowserDialog())
                {
                    frmBrowser.Description = "Select the path where the student images are located";

                    if (frmBrowser.ShowDialog() == DialogResult.OK)
                    {
                        _imagePath = frmBrowser.SelectedPath;
                        txtDirectory.Text = _imagePath;
                    }
                    else
                    {
                        chkImage.Checked = false;
                    }
                }
            }
            else
            {
                txtDirectory.Clear();
                _imagePath = "";
            }
        } //---------------------------------------
        //############################################END CHECKBOX chkImage EVENTS################################################
        #endregion
    }
}