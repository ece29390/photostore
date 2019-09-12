using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UpgradePhotoStore
{
    public partial class frmUpgrade : Form
    {
        public frmUpgrade()
        {
            InitializeComponent();
        }

        private void btnUpgrade_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CnnStr"].ToString());
                string DBName = System.Configuration.ConfigurationManager.AppSettings["DBName"].ToString();
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("drop database " + DBName);
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("OLD Database was Deleted. Click OK to create a NEW Database.");
                }
                catch
                { }
                //SqlCommand cmd2 = new SqlCommand(
                //                        "RESTORE FILELISTONLY "
                //                        + " FROM DISK = '" + Environment.CurrentDirectory + "\\PhotoStore.BAK'\n"
                //                        + " RESTORE DATABASE " + DBName
                //                        + " FROM DISK = '" + Environment.CurrentDirectory + "\\PhotoStore.bak'"
                //                        + " WITH MOVE '" + DBName + "' TO '" + Environment.CurrentDirectory + "\\" + DBName + ".mdf',"
                //                        + " MOVE '" + DBName + "_log' TO '" + Environment.CurrentDirectory + "\\" + DBName + "_log.ldf'"
                //                        );

                
                
                
                
                //cmd2.Connection = conn;
                //cmd2.ExecuteNonQuery();
                //conn.Close();
                //MessageBox.Show("New database was installed.");
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message); }

            //System.Diagnostics.Process proc = new System.Diagnostics.Process();
            //proc.EnableRaisingEvents = false;
            //proc.StartInfo.FileName = "PhotoStoreDB.exe";
            //proc.Start();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("RESTORE DATABASE " + "DBNAME" +
                                        " FROM DISK = '" + Environment.CurrentDirectory + "\\AdventureWorks.bak'" +
                                        " WITH FILE = 6" +
                                        " NORECOVERY;");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("RESTORE FILELISTONLY "
+ " FROM DISK = 'c:\\acs desktop\\Stufiles_Mar27_boe.BAK'\n"
+ " RESTORE DATABASE Stufiles"
+ " FROM DISK = 'c:\\acs desktop\\Stufiles_Mar27_boe.BAK'"
+ " WITH MOVE 'Stufiles_data' TO 'c:\\sql data\\Stufiles.mdf',"
+ " MOVE 'Stufiles_log' TO 'c:\\sql logs\\Stufiles.ldf'");
        }

    }
}