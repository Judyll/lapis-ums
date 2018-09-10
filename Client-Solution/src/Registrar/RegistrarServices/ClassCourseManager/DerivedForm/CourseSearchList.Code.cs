using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RegistrarServices
{
    public delegate void CourseSearchListLinkCreateClick();

    partial class CourseSearchList
    {
        #region Class Event Declarations
        public event CourseSearchListLinkCreateClick OnCreate;
        #endregion

        #region Class Constructor
        public CourseSearchList()
        {
            this.InitializeComponent();

            this.btnCreate.Click += new EventHandler(btnCreateClick);
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
        //event is raised when the link is clicked
        private void btnCreateClick(object sender, EventArgs e)
        {
            CourseSearchListLinkCreateClick ev = OnCreate;

            if (ev != null)
            {
                OnCreate();
            }

        }//-------------------------
        //################################################END BUTTON btnCreate EVENTS####################################################
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure disables the create link button
        public void DisableCreateLink()
        {
            this.btnCreate.Enabled = false;
        } //----------------------
        #endregion

    }
}
