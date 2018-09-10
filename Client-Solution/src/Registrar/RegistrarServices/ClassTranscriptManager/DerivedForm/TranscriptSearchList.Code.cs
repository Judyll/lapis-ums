using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RegistrarServices
{
    public delegate void TranscriptSearchListLinkCreateClick();

    partial class TranscriptSearchList
    {
        #region Class Data Member Declaration
        public event TranscriptSearchListLinkCreateClick OnCreate;
        #endregion

        #region Class Constructors
        public TranscriptSearchList()
        {
            this.InitializeComponent();

            this.btnCreateTranscript.Click += new EventHandler(btnCreateTranscriptClick);
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

        //################################################BUTTON btnCreateTranscript EVENTS####################################################
        //event is raised when the control is clicked
        private void btnCreateTranscriptClick(object sender, EventArgs e)
        {
            TranscriptSearchListLinkCreateClick ev = OnCreate;

            if (ev != null)
            {
                OnCreate();
            }
        }//------------------------
        //################################################END BUTTON btnCreateTranscript EVENTS####################################################

        #region Programmer's Defined Void Procedures
        //this procedure will change enable property of the button
        public void CreateButtonEnableProperty(Boolean isEnable)
        {
            this.btnCreateTranscript.Enabled = isEnable;
        }//------------------------
        #endregion

        #endregion
    }
}
