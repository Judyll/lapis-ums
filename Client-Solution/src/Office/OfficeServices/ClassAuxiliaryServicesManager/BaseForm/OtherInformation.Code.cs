using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class OtherInformation
    {
        #region Class Properties Declarations
        public String AuxiliaryServiceOtherInformation
        {
            get { return RemoteClient.ProcStatic.TrimStartEndString(txtOtherInfo.Text); }
            set { txtOtherInfo.Text = value; }
        }
        #endregion

        #region Class Constructor
        public OtherInformation()
        {
            this.InitializeComponent();
            
            this.pbxDone.Click += new EventHandler(pbxDoneClick);
        }

        
        #endregion

        #region Class Event Void Procedures

        //########################################PICTUREBOX pbxDone EVENTS#######################################################
        //event is raised when the picturebox is clicked
        private void pbxDoneClick(object sender, EventArgs e)
        {
            this.Close();
        } //-------------------------------------
        //######################################END PICTUREBOX pbxDone EVENTS#####################################################
        #endregion
    }
}
