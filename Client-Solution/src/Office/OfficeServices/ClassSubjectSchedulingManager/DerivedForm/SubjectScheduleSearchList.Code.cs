using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OfficeServices
{
    public delegate void SubjectScheduleSearchListLinkCreateClick();

    partial class SubjectScheduleSearchList
    {
        #region Class Event Declarations
        public event SubjectScheduleSearchListLinkCreateClick OnCreate;
        public event SubjectScheduleSearchListLinkCreateClick OnPrint;
        #endregion

        #region Class Constructor
        public SubjectScheduleSearchList()
        {
            this.InitializeComponent();

            this.btnCreate.Click += new EventHandler(btnCreateClick);
            this.btnPrintScheduleList.Click += new EventHandler(btnPrintScheduleListClick);
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

        //################################################BUTTON btnCreate EVENTS####################################################
        //event is raised when the control is clicked
        private void btnCreateClick(object sender, EventArgs e)
        {
            SubjectScheduleSearchListLinkCreateClick ev = OnCreate;

            if (ev != null)
            {
                OnCreate();
            }
        }//--------------------------
        //################################################END BUTTON btnCreate EVENTS####################################################

        //################################################BUTTON btnPrint EVENTS####################################################
        //event is raised when the control is clicked
        private void btnPrintScheduleListClick(object sender, EventArgs e)
        {
            SubjectScheduleSearchListLinkCreateClick ev = OnPrint;

            if (ev != null)
            {
                OnPrint();
            }
        }//-----------------------
        //################################################END BUTTON btnPrint EVENTS####################################################
       #endregion

        #region Programmer-Defined Void Procedure
        //this procedure will enable/disable create button
        public void SetCreateButton(Boolean isEnabled)
        {
            this.btnCreate.Enabled = isEnabled;
        }//--------------------
        #endregion
    }
}
