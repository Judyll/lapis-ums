using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RegistrarServices
{
    public delegate void SchoolYearSearchListLinkOpenClick();

    partial class SchoolYearSearchList
    {
        #region Class Event Declarations
        public event SchoolYearSearchListLinkOpenClick OnOpen;
        #endregion

        #region Class Constructor
        public SchoolYearSearchList()
        {
            this.InitializeComponent();

            this.btnCreate.Click += new EventHandler(btnCreateClick);
        }

                
        #endregion

        #region Class Event Void Procedures

        //################################################BUTTON btnCreate EVENTS####################################################
        //event is raised when the control is clicked
        private void btnCreateClick(object sender, EventArgs e)
        {
            SchoolYearSearchListLinkOpenClick ev = OnOpen;

            if (ev != null)
            {
                OnOpen();
            }
        }//-------------------------------------
        //################################################END BUTTON btnCreate EVENTS####################################################

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

        #endregion
        
    }
}
