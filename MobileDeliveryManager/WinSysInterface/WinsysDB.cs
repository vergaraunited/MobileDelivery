using MobileDeliveryLogger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.IO;
using UMDGeneral.Data;
using UMDGeneral.DataManager.Interfaces;
using UMDGeneral.Interfaces.DataInterfaces;
using static UMDGeneral.Definitions.enums;

namespace MobileDataManager.WinSysInterface
{
    public class WinsysDB : isaDataAccess<OdbcConnection, OdbcCommand, OdbcDataReader>
    {
        string query;
        string path = @"C:\Users\evergara\Desktop\";
        string strConnection;

        WinSysDBFile file;
    
        public WinsysDB(WinSysDBFile file)
        {
            strConnection = @"Driver={SoftVelocity Topspeed driver Read-Only (*.tps)};dbq=" + path + ";extension=TPS;oem=N;nullemptystr=N;nodot=N;ulongasdate=N";
            this.file = file;
        }
        OdbcConnection cnn;
        OdbcConnection NewConnection()
        {
            cnn = new OdbcConnection(strConnection);
            
            return cnn;
        }
        OdbcCommand NewCommand(string SQL)
        {
            return new OdbcCommand(SQL, cnn);
        }

        public void InsertData(String SQL, IMDMMessage msg)
        {
            using (var cnn = NewConnection())
            {
                using (var adapter = new OdbcDataAdapter())
                {
                    using (var command = NewCommand(SQL))
                    {
                        cnn.Open();
                        adapter.InsertCommand = command;
                        adapter.InsertCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        IMDMMessage MyQueryReader_GetOrdNoList(OdbcDataReader reader)
        {
            return null;
        }

        Dictionary<string, string> dictOrderQuoteNumbers;
        void myQueryData_GetOrdNoList()
        {

            dictOrderQuoteNumbers = new Dictionary<string, string>();
            //string query = "SELECT WINSYSLITEORDER FROM \"ORDMST\" WHERE ORD_NO = 872601";
            string query = "SELECT ORD_NO,ORD_DTE,WINSYSLITEORDER FROM \"ORDMST\"  WHERE ORD_DTE "; //WHERE WINSYSLITEORER NOT 0 

            QueryData(MyQueryReader_GetOrdNoList, query);

        }

        IMDMMessage MyQueryReader_GetManifest(OdbcDataReader reader)
        {
            return null;
        }

        IMDMMessage myQueryData_GetManifest()
        {
            string queryjoin_scn_trk = "SELECT ORDOPT.ORD_NO, ORDOPT.PROD_DESC, ORDOPT.SHP_DTE, ORDOPT.SHIPPING, " +
            " SCNFLE.SHP_DTE, SCNFLE.LOT_NO FROM \"SCNFLE\", \"ORDOPT\", \"TRKMST\", \"TRKDTL\" " +
            " where TRKMST.LINK=TRKDTL.LINK and SCNFLE.ORD_NO = ORDOPT.ORD_NO and TRKMST.TRUCKISCLOSED=1";
            return QueryData(MyQueryReader_GetManifest, queryjoin_scn_trk);
        }

        public IMDMMessage QueryData(Func<OdbcDataReader, IMDMMessage> cb, string SQL)
        {
            IMDMMessage data=null;

            try
            {
                using (var cnn = new OdbcConnection(strConnection))
                using (var cmd = new OdbcCommand())
                {
                    Console.WriteLine("Query: " + SQL);
                    cmd.CommandText = SQL;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cnn;

                    OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    OdbcDataReader reader = cmd.ExecuteReader();
                    data = cb(reader);
                }
            }
            catch (Exception ex) { }
            return data;
        }

        private void GetOrdNoList()
        {
            myQueryData_GetOrdNoList();
        }

        private void runQuery(isaWTSQuery dq, double julians = 0)
        {
            if (dq == null)
                return;

            Dictionary<string, string> dictOrderQuoteNumbers = new Dictionary<string, string>();

            if (julians != 0 && dq.DateField != null)
            {
                //pad the query with a search date
                if (dq.SQL.ToLower().Contains("where"))
                    query = dq.SQL + " and " + dq.DateField + "=" + julians + " " + dq.AdditionalConditions;
                else
                    query = dq.SQL + " where " + dq.DateField + "=" + julians + " " + dq.AdditionalConditions;
            }
            else
                query = dq.SQL + " " + dq.AdditionalConditions;
        }

        private void LoadFile(WinSysDBFile file)
        {
            //Pull from desktop looking for *.tps files
            if (Directory.Exists(file.WinSysSrcFilePath))
            {
                // This path is a directory
                ProcessDirectory(file.WinSysSrcFilePath);
            }
        }

        // Process all files in the directory passed in, recurse on any directories 
        // that are found, and process the files they contain.
        void ProcessDirectory(string targetDirectory)
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

        // Insert logic for processing found files here.
        public void ProcessFile(string path)
        {
            //chkbxFiles.Items.Add(new DBFile(Path.GetFileName(path), path));
            Logger.Debug("Processed file " + path);
        }

        public void Connect()
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public void TransferManifest()
        {
            throw new NotImplementedException();
        }

        public IMDMMessage GetManifest()
        {
            return myQueryData_GetManifest();
        }

        public IMDMMessage QueryManifest(Func<OdbcDataReader, IMDMMessage> cb, string SQL)
        {
            throw new NotImplementedException();
        }

        public void InsertData(SPCmds sql, IMDMMessage msg)
        {
            throw new NotImplementedException();
        }

        public IMDMMessage QueryData(Func<OdbcDataReader, IMDMMessage> cb, SPCmds SQL)
        {
            throw new NotImplementedException();
        }
    }
}
