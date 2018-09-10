using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OfficeServices
{    
    public delegate void AuxiliaryInformationSearchListLinkCreateClick();

    partial class AuxiliaryInformationSearchList
    {
        #region Class Event Declaration
        public event AuxiliaryInformationSearchListLinkCreateClick OnCreate;
        #endregion

        #region Class Constructor
        public AuxiliaryInformationSearchList()
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
        //event is raised when the control is clicked
        private void btnCreateClick(object sender, EventArgs e)
        {
            AuxiliaryInformationSearchListLinkCreateClick ev = OnCreate;

            if (ev != null)
            {
                OnCreate();
            }
        }//----------------------------
        //################################################END LINKBUTTON lnkCreate EVENTS####################################################
        #endregion
    }
}
