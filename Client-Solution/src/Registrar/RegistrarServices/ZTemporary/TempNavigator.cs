using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RegistrarServices
{
    public partial class TempNavigator : Form
    {
        private CommonExchange.SysAccess _userInfo;

        public TempNavigator(CommonExchange.SysAccess userInfo)
        {
            InitializeComponent();

            _userInfo = userInfo;

            this.btnSchoolYear.Click += new EventHandler(btnSchoolYear_Click);
            this.btnClassroom.Click += new EventHandler(btnClassroom_Click);
            this.btnSpecial.Click += new EventHandler(btnSpecial_Click);
        }

        void btnSpecial_Click(object sender, EventArgs e)
        {
            using (SpecialClassManager frmManager = new SpecialClassManager(_userInfo))
            {
                frmManager.ShowDialog(this);
            }
        }

        void btnClassroom_Click(object sender, EventArgs e)
        {
            using (CourseManager frmManager = new CourseManager(_userInfo))
            {
                frmManager.ShowDialog(this);
            }
        }

        void btnSchoolYear_Click(object sender, EventArgs e)
        {
            using (SchoolYearSemesterManager frmManager = new SchoolYearSemesterManager(_userInfo))
            {
                frmManager.ShowDialog(this);
            }
        }
    }
}