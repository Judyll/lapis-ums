using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace UMSCampusAccessUpdater
{
    public partial class MainForm : Form
    {
        #region Class Data Member Decleration
        private String path = Application.StartupPath + @"\University Management System\";

        private Int32 countUpdate = 0;
        #endregion

        #region Class Constructors
        public MainForm()
        {
            InitializeComponent();

            this.Shown += new EventHandler(MainFormShown);
        }
        #endregion

        #region Class Event Void Procedures
        //event is raised when the form is shown
        private void MainFormShown(object sender, EventArgs e)
        {
            if (this.IsAllowedToUpdated())
            {
                this.lstBoxView.Items.Clear();

                countUpdate = 0;

                this.progressBar.Value = 0;

                this.CopyDirectory();
            }

            Application.Exit();
        }//--------------------------
        #endregion

        #region Programmer Defined Void Procedures
        //this procedure will update files
        private void CopyDirectory()
        {
            try
            {
                List<CommonExchange.UmsBinaries> umsBinList;

                using (RemoteClient.RemCntBinaryUpdater remClient = new RemoteClient.RemCntBinaryUpdater())
                {
                    umsBinList = remClient.SelectUMSCampusAccessBinaries();
                }

                Int32 noOfFiles = umsBinList.Count;

                this.progressBar.Maximum = noOfFiles;
                this.progressBar.Minimum = 0;
                this.progressBar.Step = 1;

                if (umsBinList != null)
                {
                    foreach (CommonExchange.UmsBinaries umsBin in umsBinList)
                    {
                        countUpdate++;

                        String strMessage = "Installing Update " + path + umsBin.FileName +
                            ". (update " + countUpdate + " of " + noOfFiles + ")....";

                        lstBoxView.Items.Add(strMessage);

                        Application.DoEvents();

                        if (!Directory.Exists(Path.GetDirectoryName(path + umsBin.FileName)))
                        {
                            DirectoryInfo createDir = new DirectoryInfo(Path.GetDirectoryName(path + umsBin.FileName));

                            createDir.Create();
                        }

                        using (FileStream fs = File.Create(path + umsBin.FileName, 1024))
                        {
                            fs.Write(umsBin.FileBytes, 0, umsBin.FileBytes.Length);
                        }

                        this.lstBoxView.Items[countUpdate - 1] += "Done!";

                        this.progressBar.PerformStep();

                        Application.DoEvents();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //----------------------------   
        #endregion

        #region Programmer Defined Functions
        //this fucntion will checke if the program is allowed to updated
        private Boolean IsAllowedToUpdated()
        {
            Boolean isAllowed = true;

            Process[] currentProccess = Process.GetProcesses();

            foreach (Process p in currentProccess)
            {
                if (String.Equals(p.ProcessName, "cpas"))
                {
                    String strMsg = "The Campus Access is currently running.\n\n" +
                        "Click YES to terminate the Campus Access application and continue the update.\n" +
                        "Click NO to cancel the update.";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.No)
                    {
                        isAllowed = false;

                        Application.Exit();
                    }
                    else
                    {
                        if (!p.HasExited)
                        {
                            p.Kill();
                        }

                        isAllowed = true;

                        break;
                    }
                }
            }

            return isAllowed;
        }//------------------------
        #endregion
    }
}