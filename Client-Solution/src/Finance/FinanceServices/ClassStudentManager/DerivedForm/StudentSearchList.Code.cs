using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FinanceServices
{
    public delegate void StudentSearchListLinkCreateClick();

    partial class StudentSearchList
    {
        #region Class Even Declaration
        public event StudentSearchListLinkCreateClick OnCreate;
        #endregion

        #region Class Constructor
        public StudentSearchList()
        {
            this.InitializeComponent();

            this.btnCreate.Click += new EventHandler(btnCreateClick);
             
        }
       #endregion
        
        #region Class Events Void Procedures
        //###############################################CLASS StudentSearchList EVENTS##################################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            base.ClassLoad(sender, e);

            this.dgvList.Columns[0].SortMode = this.dgvList.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;
        }//-----------------------------
        //###############################################END CLASS StudentSearchList EVENTS##################################################

        //################################################BUTTON bntCreate EVENTS####################################################
        //event is raised when the link is clicked
        private void btnCreateClick(object sender, EventArgs e)
        {
            StudentSearchListLinkCreateClick ev = OnCreate;

            if (ev != null)
            {
                OnCreate();
            }
        }//---------------------------------
        //################################################END LINKBUTTON lnkCreate EVENTS####################################################

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

        #region Programer-Define Procedures

        public void DisableCreateLink()
        {
            this.btnCreate.Visible = false;
        }       
        #endregion

    }
}
