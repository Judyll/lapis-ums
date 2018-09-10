using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MemberServices
{
    public delegate void MemberSearchListLinkCreateClick();

    partial class MemberSearchList
    {
        #region Class Even Declaration
        public event MemberSearchListLinkCreateClick OnCreate;
        #endregion

        #region Class Constructors
        public MemberSearchList()
        {
            this.InitializeComponent();

            this.btnCreate.Click += new EventHandler(btnCreateClick);
        }
        #endregion

        #region Class Event Void Procedures
        //################################################BUTTON bntCreate EVENTS####################################################
        //event is raised when the link is clicked
        private void btnCreateClick(object sender, EventArgs e)
        {
            MemberSearchListLinkCreateClick ev = OnCreate;

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
        //this procedure will disable create button
        public void DisableCreateLink()
        {
            this.btnCreate.Visible = false;
        }//-------------------------------
        #endregion
    }
}
