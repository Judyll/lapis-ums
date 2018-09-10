using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeServices
{
    partial class EmployeeSearchList
    {
        #region Class Contructor
        public EmployeeSearchList()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Class Event Void Procedures
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
        }
        #endregion
    }
}
