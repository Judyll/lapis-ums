using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RegistrarServices
{
    public delegate void SpecialClassSearchListLinkCreateClick();

    partial class SpecialClassSearchList
    {
        #region Class Event Declarations
        public event SpecialClassSearchListLinkCreateClick OnCreate;
        #endregion

        #region Class Constructor
        public SpecialClassSearchList()
        {
            this.InitializeComponent();

            this.btnCreate.Click += new EventHandler(btnCreateClick);
        }       
        #endregion

        #region Class Event Void Procedures
        //################################################BUTTON btnCreate EVENTS####################################################
        //event is raised when the link is clicked
        private void btnCreateClick(object sender, EventArgs e)
        {
            SpecialClassSearchListLinkCreateClick ev = OnCreate;

            if (ev != null)
            {
                OnCreate();
            }
        }//-------------------------------------
        //############################################END BUTTON btnCreate EVENTS####################################################

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

        #region Programmer-Defined Void Procedures
        //this procedure disables the create link
        public void DisableCreateLink(Boolean value)
        {
            this.btnCreate.Visible = value;
        } //----------------------
        #endregion


    }
}
