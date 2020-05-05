using MobileDeliveryGeneral.Data;
using MobileDeliveryLogger;
using MobileDeliveryManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MobileDataManagerWinsys.WinSysInterface
{
    public class FileTransfer
    {
        string srcPath = @"L:\Winsys32\DATA\";
        //string dstPath = @"C:\inetpub\wwwroot\DealerDashboard";
        string dstPath = @"C:\inetpub\temp\";

        List<string> lstWinSysFiles = new List<string>();

        public string path = "";

        static Dictionary<string, string> sql4Files = new Dictionary<string, string>();
        
        public FileTransfer(WinSysDBFile WinsysFile)
        {
            srcPath = WinsysFile.WinSysSrcFilePath;
            dstPath = WinsysFile.WinsysDstFilePath;
            initSql4Files();
            //CopyFiles();
        }

        //string appendPathFname(WinSysDBFile winsysFile)
        //{
        //    if (winsysFile.WinSysDBFileName.Length > 0 && winsysFile.WinSysDBFilePath.Length > 0)
        //        return winsysFile.WinSysDBFilePath + winsysFile.WinSysDBFileName;
        //    else if (winsysFile.WinSysDBFileName.Length > 0 && winsysFile.WinSysDBFilePath.Length == 0)
        //        return winsysFile.WinSysDBFileName;
        //    else if (winsysFile.WinSysDBFileName.Length == 0 && winsysFile.WinSysDBFilePath.Length > 0)
        //        return winsysFile.WinSysDBFilePath;
        //    else
        //        throw new Exception("Erroneaous file and path names.");
        //}
        public FileCopy CopyFiles()
        {
            FileCopy fc = new FileCopy();
            fc.status = eStatus.InProgress;
            fc.datetime = DateTime.Now;
            try
            {
                string[] files = FileTransfer.GetFiles(srcPath, "*.tps", SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                    System.IO.File.Copy(@file, @dstPath + file.Remove(0, file.LastIndexOf("\\")), true);
                    fc.files.Add(file);
                }
                fc.status = eStatus.Success;
            }
            catch (Exception ex)
            {
                Logger.Debug($" {MobileDeliveryManagerAPI.AppName} - Error Copying tps Winsys files : " + ex.Message);
                fc.status = eStatus.Failed;
            }
            return fc;
        }

        private static string[] GetFiles(string sourceFolder, string filters, System.IO.SearchOption searchOption)
        {
            return filters.Split('|').SelectMany(filter => System.IO.Directory.GetFiles(sourceFolder, filter, searchOption))
                .Where(fs => sql4Files.Keys.Contains(Path.GetFileNameWithoutExtension(fs))).ToArray();
        }
        Boolean CheckFiles(DateTime dt)
        {
            string[] files = System.IO.Directory.GetFiles(this.path);
            string fileName;
            string destFile;

            // Copy the files and overwrite destination files if they already exist.
            foreach (string s in files)
            {
                // Use static Path methods to extract only the file name from the path.
                fileName = System.IO.Path.GetFileName(s);
                destFile = System.IO.Path.Combine(dstPath, fileName);
                
            }

            return true;
        }

        public string SQLResult { get; set; }
        public string FileName { get; set; }

        static private void initSql4Files()
        {
            try
            {
                //Truck Master
                if (sql4Files.Keys.Contains("trkmst"))
                    sql4Files.Remove("trkmst");
                sql4Files.Add("trkmst", "SELECT * FROM \"TRKMST\"");

                //Truck Detail
                if (sql4Files.Keys.Contains("trkdtl"))
                    sql4Files.Remove("trkdtl");
                sql4Files.Add("trkdtl", "SELECT * FROM \"TRKDTL\"");

                //Order Options
                if (sql4Files.Keys.Contains("ordopt"))
                    sql4Files.Remove("ordopt");
                sql4Files.Add("ordopt", "SELECT * FROM \"ORDOPT\"");

                //Option Detail
                if (sql4Files.Keys.Contains("optdtl"))
                    sql4Files.Remove("optdtl");
                sql4Files.Add("optdtl", "SELECT * FROM \"OPTDTL\"");

                //Order Master
                if (sql4Files.Keys.Contains("ordmst"))
                    sql4Files.Remove("ordmst");
                sql4Files.Add("ordmst", "SELECT * FROM \"ORDMST\"");

                //Scan to Truck
                if (sql4Files.Keys.Contains("scnfle"))
                    sql4Files.Remove("scnfle");
                sql4Files.Add("scnfle", "SELECT* FROM \"SCNFLE\"");
            }
            catch (Exception ex) { }
        }

        public FileCopy LoadFiles()
        {
            //Pull from desktop looking for *.tps files
            if (Directory.Exists(path))
            {
                // This path is a directory
                ProcessDirectory(path);
            }
            FileCopy fc = new FileCopy();

            return fc;
        }

        // Process all files in the directory passed in, recurse on any directories 
        // that are found, and process the files they contain.
        public void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory, "*.tps");
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }

        List<String> lstSrcFiles = new List<string>();
        // Insert logic for processing found files here.
        public void ProcessFile(string path)
        {
            if (lstSrcFiles.Contains(path)==false)
                lstSrcFiles.Add(path);
            // chkbxFiles.Items.Add(new DBFile(Path.GetFileName(path), path));
            Logger.Debug("Processed file " + path);
        }


        public class DBFile
        {
            public string FileName { get; set; }
            public string FilePath { get; set; }
            public DBFile(string name, string path)
            {
                FileName = name;
                FilePath = path;
            }
            public override string ToString()
            {
                return FileName;
            }
        }

        //private void chkbxFiles_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int iSelectedIndex = chkbxFiles.SelectedIndex;
        //    if (iSelectedIndex == -1)
        //        return;
        //    for (int iIndex = 0; iIndex < chkbxFiles.Items.Count; iIndex++)
        //        chkbxFiles.SetItemCheckState(iIndex, CheckState.Unchecked);
        //    chkbxFiles.SetItemCheckState(iSelectedIndex, CheckState.Checked);
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    var selected = chkbxFiles.SelectedItems.Cast<DBFile>().Select(x => x.FileName.Remove(x.FileName.IndexOf('.'), x.FileName.Length - x.FileName.IndexOf('.')));

        //    string file = selected.FirstOrDefault();
        //    string sql = "";
        //    if (file.Length > 0)
        //        //get the sql from dictionary
        //        sql = sql4Files[file];

        //    //this.DialogResult = DialogResult.OK;
        //    this.SQLResult = sql;
        //    this.FileName = file;
        //}
    }
}
