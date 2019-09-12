using System;
using System.Collections.Generic;
using System.Text;
using PhotoStore.BusinessLogic;
using PhotoStore.DataAccess;
using System.Xml;
using System.IO;
using System.Data;
using Microsoft.SqlServer.Server;
using Microsoft.SqlServer.Management.Smo;
using System.Xml.Serialization;
using PhotoStore.Entity;
using PhotoStore.UtilityServices;
using System.IO.Compression;
using Microsoft.SqlServer.Management.Common;
using System.Configuration;
using System.Diagnostics;
namespace LabRat
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(EnumReader.GetDescription(Direction.ASC));
            //Console.ReadLine();
           
           // XmlTextReader reader = new XmlTextReader();
            //GC gc=new GC();
            //gc.Id=1;
            //gc.Code="Hello";
            //XmlSerializer fs = new XmlSerializer(typeof(GC));
            //string xmlSerialized = "";
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    XmlTextWriter xtw = new XmlTextWriter(ms, Encoding.UTF8);
                
            //    fs.Serialize(xtw,gc);
            //    xmlSerialized = (new UTF8Encoding()).GetString(ms.ToArray());
                
            //}

            //using (MemoryStream ms =new MemoryStream((new UTF8Encoding()).GetBytes(xmlSerialized)))
            //{
            //    XmlTextWriter xtw = new XmlTextWriter(ms, Encoding.UTF8);
            //    GC gc1=(GC)fs.Deserialize(ms);

            //}
            //DataSet ds = new DataSet();
            //DBUtility dbUtility=new DBUtility(@"ACERSANTOS\SANTOSSERVER2005",
            //    "PhotoStore");
            //dbUtility.BackUp(@"E:\");
           // Console.ReadLine(); 
            // Path to directory of files to compress and decompress.
            //ServerConnection conn=new ServerConnection(new System.Data.SqlClient.SqlConnection(
            //    ConfigurationManager.ConnectionStrings["CnnStr"].ConnectionString));
            //Server srv = new Server(conn);
            //string file = @"E:\Projects\Photostore\Santos\PhotoStore\DB\05012010\vwRejectedOrder.sql";
            //string query = "";
            //using (FileStream fs = new FileStream(file, FileMode.Open))
            //{
            //    StreamReader sr = new StreamReader(fs);
            //    query = sr.ReadToEnd();
            //}
            //int i = srv.ConnectionContext.ExecuteNonQuery(query, ExecutionTypes.QuotedIdentifierOn);

            
            //srv.ConnectionContext.SqlConnectionObject.Close();
            //Process process = new Process();
            //process.StartInfo.FileName = @"E:\Projects\Photostore\Santos\PhotoStore\PhotoCabMM\Debug\PhotoCab.CAB";
            //process.StartInfo.Verb = "Open";
            //process.Start();

            //UpdateAppService.UpdateApplication(@"E:\Installers\Unzip.exe",
            //    @"E:\PicabooVMCShared\Updates.zip", @"E:\PicabooVMCShared");
            //string destinationPath = @"E:\PicabooVMCShared\PhotoStore_MM";
            //string tempFolder = @"E:\PicabooVMCShared\PhotoStore_MM\Temp05252010112315";
            //string[] extraDirectoryCreated = Directory.GetDirectories(tempFolder);
            //string[] updateFiles;
            //bool isExtraFolder = false;
            //if (extraDirectoryCreated.Length > 0)
            //{
            //    updateFiles = Directory.GetFiles(extraDirectoryCreated[0], "*.*");
            //    isExtraFolder = true;
            //}
            //else
            //{
            //    updateFiles = Directory.GetFiles(destinationPath, "*.*");
            //}

            //UpdateAppService.CopyUpdateFiles(updateFiles, destinationPath, isExtraFolder);
            //Directory.Delete(tempFolder);
            StringBuilder sb = new StringBuilder();
            sb.Append("DECLARE @prodId BIGINT;");
            string insertProdFormat = @"INSERT INTO ProductList
                                       ([Description]
                                       ,[ParticularType_Id]
                                       ,[DateCreated]                                 
                                       ,[IsPackage]
                                       ,[UnitPrice]
                                       ,[MarkAsDeleted])
                                 VALUES
                                       ('{0}'
                                       ,{1}
                                       ,GETDATE()                               
                                       ,{2}
                                       ,{3}
                                       ,{4})";
            string insertProdDetFormat = @"INSERT INTO ProductListDetails
                                        (ProductList_Id
                                       ,Quantity
                                       ,Particulars
                                       ,MarkAsDeleted)
                                 VALUES
                                       (@prodId
                                       ,{0}
                                       ,'{1}'
                                       ,{2})";
            using (DataSet prodDs = daHelper.executeSelect("SELECT * FROM PRODUCTLIST"))
            {
                DataSet prodDetDs = null;
              
                
                foreach (DataRow prodDr in prodDs.Tables[0].Rows)
                {
                    sb.AppendLine(string.Format(insertProdFormat,
                                  prodDr["Description"],
                                  prodDr["ParticularType_Id"],
                                  Convert.ToBoolean(prodDr["IsPackage"]) ? 1 : 0,
                                  prodDr["UnitPrice"],
                                  Convert.ToBoolean(prodDr["MarkAsDeleted"]) ? 1 : 0));
                    sb.AppendLine("SET @prodId = @@identity");
                    prodDetDs = daHelper.executeSelect(string.Format("SELECT * FROM PRODUCTLISTDETAILS WHERE PRODUCTLIST_ID={0}",
                        prodDr["Id"]));
                    if (prodDetDs != null)
                    {
                        foreach (DataRow prodDetDr in prodDetDs.Tables[0].Rows)
                        {
                            sb.AppendLine(string.Format(
                                insertProdDetFormat,
                                prodDetDr["Quantity"],
                                prodDetDr["Particulars"],
                                Convert.ToBoolean(prodDetDr["MarkAsDeleted"]) ? 1 : 0));
                        }
                        prodDetDs.Dispose();
                        prodDetDs = null;
                    }
                    
                }
            }

            if (sb.ToString().Length > 0)
            {
                File.WriteAllText(
                    "script.sql", sb.ToString());
            }
        }

        static void watcher_Created(object sender, FileSystemEventArgs e)
        {
            
        }
        public static void Compress(FileInfo fi)
        {
            // Get the stream of the source file.
            using (FileStream inFile = fi.OpenRead())
            {
                // Prevent compressing hidden and 
                // already compressed files.
                if ((File.GetAttributes(fi.FullName)
                    & FileAttributes.Hidden)
                    != FileAttributes.Hidden & fi.Extension != ".gz")
                {
                    // Create the compressed file.
                    using (FileStream outFile =
                                File.Create(fi.FullName + ".gz"))
                    {
                        using (GZipStream Compress =
                            new GZipStream(outFile,
                            CompressionMode.Compress))
                        {
                            // Copy the source file into 
                            // the compression stream.
                            //inFile.CopyTo(Compress);
                            
                            Console.WriteLine("Compressed {0} from {1} to {2} bytes.",
                                fi.Name, fi.Length.ToString(), outFile.Length.ToString());
                        }
                    }
                }
            }
        }

    }
}
