using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace BaseServices.Control
{
    public partial class CrystalReportViewer : Form
    {
        #region Class General Variable Declarations
        private ReportDocument _rptDocument;
        #endregion

        #region Class Constructor
        public CrystalReportViewer(ReportDocument rptDocument)
        {
            InitializeComponent();

            _rptDocument = rptDocument;

            this.Load += new EventHandler(ClassLoad);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(ClassKeyDown);
        }

        
        
        #endregion

        #region Class Event Void Procedures
        //#########################################CLASS CFBCrystalReportViewer EVENTS##################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            rptViewer.ReportSource = _rptDocument;

            this.Cursor = Cursors.Arrow;
        } //---------------------------------

        //event is raised when the key is down
        private void ClassKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        } //------------------------------

        //########################################END CLASS CFBCrystalReportViewer EVENTS################################################
        #endregion
    }
}