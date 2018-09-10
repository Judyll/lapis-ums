using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EmployeeServices
{
    internal partial class TempNavigator : Form
    {
        private CommonExchange.SysAccess _userInfo;

        public TempNavigator(CommonExchange.SysAccess userInfo)
        {
            InitializeComponent();

            _userInfo = userInfo;

            this.btnEmployee.Click += new EventHandler(btnEmployee_Click);
            this.btnDeduction.Click += new EventHandler(btnDeduction_Click);
            this.btnEarning.Click += new EventHandler(btnEarning_Click);
            this.btnLoan.Click += new EventHandler(btnLoanClick);
        }

        void btnLoanClick(object sender, EventArgs e)
        {
            using (LoanRemittanceManager frmManager = new LoanRemittanceManager(_userInfo))
            {
                frmManager.ShowDialog();
            }
        }

        void btnEarning_Click(object sender, EventArgs e)
        {
            using (EarningManager frmManager = new EarningManager(_userInfo))
            {
                frmManager.ShowDialog();
            }
        }

        void btnDeduction_Click(object sender, EventArgs e)
        {
            using (DeductionManager frmManager = new DeductionManager(_userInfo))
            {
                
                frmManager.ShowDialog();
            }
        }

        void btnEmployee_Click(object sender, EventArgs e)
        {
            using (EmployeeManager frmManager = new EmployeeManager(_userInfo))
            {               

                frmManager.ShowDialog();
            }
        }
    }
}