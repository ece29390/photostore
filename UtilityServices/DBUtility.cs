using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Agent;
using Microsoft.SqlServer.Management.Smo.Broker;
using Microsoft.SqlServer.Management.Smo.Mail;
using Microsoft.SqlServer.Management.Smo.RegisteredServers;
using Microsoft.SqlServer.Management.Smo.Wmi;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Configuration;
using System.Security;
namespace PhotoStore.UtilityServices
{
    public class DBUtility:IDisposable
    {
        Server _srv;
        ServerConnection _srvConnection;
        string _dbName,_locationPath;
        Process _process;
        public DBUtility(string instanceName,string dbName,string locationPath)
        {
            _srv = new Server(instanceName);
            _srvConnection = _srv.ConnectionContext;
           //_srvConnection.LoginSecure = true;
           _dbName = dbName;
           _locationPath = locationPath;
        }

        public DBUtility(string sqlCmdExePath, string locationPath)
        {
            _process = new Process();
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = sqlCmdExePath;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            _process.StartInfo = processStartInfo;
            _locationPath = locationPath;
        }
        private void ExecuteBySQLCmd(string argument,int waitTime)
        {
            _process.StartInfo.Arguments = argument;
            _process.Start();
                                
        }
        public static bool IsFileAlreadyExist(string fileName)
        {
            return File.Exists(fileName);
        }
        public void BackUpBySQLCmd(string argument, int waitTime)
        {

            ExecuteBySQLCmd(argument, waitTime);

        }
        private string[] GetFileNames(string fullName)
        {
            string[] retValue=null;
            using (FileStream fs = new FileStream(fullName, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    retValue = reader.ReadToEnd().Split(
                        new string[1] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    reader.Close();
                }
                fs.Close();
            }
            return retValue;
        }
        
        public string ExecuteScripts(string path)
        {
            string msg = "Scripts successfully executed";
            ServerConnection srvConn = new ServerConnection(
                new System.Data.SqlClient.SqlConnection(
                ConfigurationManager.ConnectionStrings["CnnStr"].ConnectionString));
            Server srv = new Server(srvConn);
            string fileName= "Sequence.txt";
            string fullName = string.Concat(path,@"\", fileName);
            string[] fileNames;
            if (File.Exists(fullName))
            {
                fileNames = GetFileNames(fullName);
                FileStream fs=null;
                StreamReader sr=null;
                string subFullName = "";
                List<string> fileNameStatus = new List<string>();
                try
                {
                    foreach (string file in fileNames)
                    {
                        
                        subFullName = string.Concat(path, @"\", file);
                        fs = new FileStream(subFullName, FileMode.Open);
                        sr = new StreamReader(fs);
                        srv.ConnectionContext.ExecuteNonQuery(sr.ReadToEnd(),
                            ExecutionTypes.QuotedIdentifierOn);
                        sr.Close();
                        fs.Close();
                        sr = null;
                        fs = null;

                        if(File.Exists(file))
                            File.Delete(file);

                        fileNameStatus.Add(file);
                    }
                    
                  
                }
                catch (Exception ex)
                {
                    msg = "";
                    MessageBox.Show(ex.StackTrace);
                    
                }
                finally
                {
                    if (sr != null)
                    {
                        sr.Close();
                        sr.Dispose();
                    }
                    if (fs != null)
                    {
                        fs.Close();
                        fs.Dispose();
                    }

                    File.Delete(fullName);

                }
               
               
               
            }
            else
                msg = "";

            

            if (srv.ConnectionContext.SqlConnectionObject.State ==
                System.Data.ConnectionState.Open)
            {
                srv.ConnectionContext.SqlConnectionObject.Close();
            }

            return msg;
                                                      
        }

        public void RestoreBySQLCmd(string argument, int waitTime)
        {
            ExecuteBySQLCmd(argument, waitTime);

        }
        public void AutoBackUpBySQLCMD(string argument, int waitTime,double retentionPeriod)
        {
            if (!Directory.Exists(_locationPath))
            {
                
                Directory.CreateDirectory(_locationPath);
                ExecuteBySQLCmd(argument, waitTime);
            }
            else
            {
                DateTime dt = DateTime.Now;
               
                string[] files = Directory.GetFiles(_locationPath);
                FileInfo fiInfo;
                bool _alreadyBackedUp = false;
                foreach (string file in files)
                {
                    fiInfo = new FileInfo(file);
                    if (fiInfo.Extension == ".bak")
                    {
                        if (dt.ToShortDateString() ==
                            fiInfo.CreationTime.ToShortDateString())
                        {
                            _alreadyBackedUp = true;
                            break;
                        }

                        //Delete files exceeded than retention days
                        if (dt > fiInfo.CreationTime.AddDays(retentionPeriod))
                        {
                            File.Delete(fiInfo.FullName);
                        }
                    }
                    
                    fiInfo = null;
                }
                if (!_alreadyBackedUp)
                {
                    BackUpBySQLCmd(argument, waitTime);
                }
                
            }
        }

        public string BuildBackupArgumentForSqlCmd(string backupfullpath)
        {
            string serverName = ConfigurationManager.AppSettings["InstanceName"];
            string dbname = ConfigurationManager.AppSettings["DBName"];
            string backupName = string.Concat(dbname, "_", DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, ".bak");
            string backupFullPath = Path.Combine(backupfullpath, backupName);
            string backupArg = string.Format(ConfigurationManager.AppSettings["BackUpArgument"]
            , serverName, dbname, backupFullPath);
            return backupArg;
        }

        public void AutoBackUp(int retentionPeriod)
        {
            if (!Directory.Exists(_locationPath))
            {
                Directory.CreateDirectory(_locationPath);
                BackUp();
            }
            else
            {
                DateTime dt = DateTime.Now;

                string[] files = Directory.GetFiles(_locationPath);
                FileInfo fiInfo;
                bool _alreadyBackedUp = false;
                foreach (string file in files)
                {
                    fiInfo = new FileInfo(file);
                    if (fiInfo.Extension == ".bak")
                    {
                        if (dt.ToShortDateString() ==
                            fiInfo.CreationTime.ToShortDateString())
                        {
                            _alreadyBackedUp = true;
                            break;
                        }
                        
                        //Delete files exceeded than retention days
                        if (dt > fiInfo.CreationTime.AddDays(retentionPeriod))
                        {
                            File.Delete(fiInfo.FullName);
                        }
                    }

                    fiInfo = null;
                }
                if (!_alreadyBackedUp)
                {
                    BackUp();
                }
            }
           
        }
        public void BackUp()
        {
            string branchCode = ConfigurationManager.AppSettings["BranchCode"].ToString();
            Backup backUp = new Backup();
            backUp.Database = _dbName;
            backUp.BackupSetDescription = "Full back up of Photostore database";
            backUp.Action = BackupActionType.Database;
            backUp.BackupSetName = "PhotoStore Backup";
            //SecureString securityString=new SecureString();
            //char[] chars="santos123".ToCharArray();
            //for(int i=0;i<chars.Length;i++)
            //{
            //    securityString.SetAt(i,chars[i]);
            //}
            //backUp.SetPassword("Sunny");
            backUp.MediaDescription = "Disk";
            backUp.Devices.AddDevice(
                string.Format(@"{0}\{1}{2}_{3}.bak",
                _locationPath,
                _dbName,
                DateTime.Now.ToString("MMddyyyyhhmmss"),
                branchCode), DeviceType.File);
            backUp.SqlBackup(_srv);


            MessageBox.Show("Database has been successfully backed up");
        }
        public void Restore()
        {
            Restore sqlRestore = new Restore();

            BackupDeviceItem deviceItem = new BackupDeviceItem(_locationPath, DeviceType.File);
            sqlRestore.Devices.Add(deviceItem);
            sqlRestore.Database = _dbName;                       
            sqlRestore.Action = RestoreActionType.Database;
                       
            sqlRestore.ReplaceDatabase = true;           
            sqlRestore.SqlRestore(_srv);

        }

        #region IDisposable Members

        public void Dispose()
        {
            _srv = null;
            _srvConnection = null;
            if (_process != null)
            {
                _process.Close();
                _process.Dispose();
            }
        }

        #endregion
    }
}
