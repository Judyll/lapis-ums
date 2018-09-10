using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace RemoteServerLib
{
    public class RemSrvBinaryUpdater : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvBinaryUpdater() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure walks inside the directory
        private void WalkDirectoryTree(List<CommonExchange.UmsBinaries> umsBinList, DirectoryInfo root, String filePath)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;
            String subDirPath = filePath;

            //process all the files directly under this folder
            if (root.Exists)
            {
                files = root.GetFiles("*.*");
            }

            if (files != null)
            {
                foreach (FileInfo fi in files)
                {
                    CommonExchange.UmsBinaries umsBin = new CommonExchange.UmsBinaries();

                    umsBin.FileName = String.IsNullOrEmpty(filePath) ? fi.Name :  filePath + @"\" + fi.Name;
                    umsBin.FileBytes = this.GetFileArrayBytes(fi.FullName);

                    if (umsBinList != null)
                    {
                        umsBinList.Add(umsBin);
                    }
                }
            }

            //find all the subdirectories under this directory
            subDirs = root.GetDirectories();

            foreach (DirectoryInfo dirInfo in subDirs)
            {
                filePath = String.IsNullOrEmpty(subDirPath) ? dirInfo.Name : subDirPath + @"\" + dirInfo.Name;

                this.WalkDirectoryTree(umsBinList, dirInfo, filePath);
            }
        }

        #endregion

        #region Programmer-Defined Function Procedures

        //this function returns the updated binaries
        public List<CommonExchange.UmsBinaries> SelectUMSBinaries()
        {
            List<CommonExchange.UmsBinaries> umsBinList = new List<CommonExchange.UmsBinaries>();

            DirectoryInfo directoryInfo = new DirectoryInfo(CommonExchange.SystemConfiguration.UpdatedBinaryFolder(Application.StartupPath));

            String filePath = String.Empty;

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            this.WalkDirectoryTree(umsBinList, directoryInfo, filePath);

            return umsBinList;
        } //----------------------------

        //this function returns the updated campus access binaries
        public List<CommonExchange.UmsBinaries> SelectUMSCampusAccessBinaries()
        {
            List<CommonExchange.UmsBinaries> umsBinList = new List<CommonExchange.UmsBinaries>();

            DirectoryInfo directoryInfo = new DirectoryInfo(CommonExchange.SystemConfiguration.UpdatedCampusAccessBinaryFolder(Application.StartupPath));

            String filePath = String.Empty;

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            this.WalkDirectoryTree(umsBinList, directoryInfo, filePath);

            return umsBinList;
        } //----------------------------

        //this function gets the array of bytes of a file
        private Byte[] GetFileArrayBytes(String filePath)
        {
            FileStream fileStr = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader binReader = new BinaryReader(fileStr);

            Byte[] fileByte = binReader.ReadBytes((Int32)fileStr.Length);

            fileStr.Close();
            binReader.Close();

            fileStr = null;
            binReader = null;

            return fileByte;

        } //--------------------------

        #endregion
    }
}
