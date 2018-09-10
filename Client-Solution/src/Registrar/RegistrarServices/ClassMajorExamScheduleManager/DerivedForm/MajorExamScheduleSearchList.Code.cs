using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RegistrarServices
{
    public delegate void MajorExamScheduleSearchListLinkCreateClick();

    partial class MajorExamScheduleSearchList
    {
        #region Class Data Member Declaration
        public event MajorExamScheduleSearchListLinkCreateClick OnCreate;
        #endregion

        #region Class Constructors
        public MajorExamScheduleSearchList()
        {
            this.InitializeComponent();

            this.btnCreate.Click += new EventHandler(btnCreateClick);
        }       
        #endregion

        #region Class Event Void Procedure
    
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
            MajorExamScheduleSearchListLinkCreateClick ev = OnCreate;

            if (ev != null)
            {
                OnCreate();
            }
        }//------------------------
        //################################################END LINKBUTTON lnkCreate EVENTS####################################################
        #endregion
    }
}
