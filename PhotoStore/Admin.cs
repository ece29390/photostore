using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhotoStore.Entity;
using PhotoStore.UtilityServices;
using System.Configuration;
namespace PhotoStore
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        Employee _employee;
        public Admin(Employee employee)
        {
            _employee = employee;
            InitializeComponent();
        }
        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            //VerifyPassword verifyPassword = new VerifyPassword("User", null);
            //verifyPassword.ShowDialog();
            //bool isCanceled = verifyPassword.Canceled;
            //verifyPassword.Dispose();
            //verifyPassword = null;
            //if (!isCanceled)
            //{
                AdminUser frm = new AdminUser();
                frm.ShowDialog();
                //frm.Dispose();
                //frm = null;
            //}
          
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            AdminProduct frm = new AdminProduct();
            frm.ShowDialog();
            frm.Dispose();
            frm = null;

        }

        private void btnPackages_Click(object sender, EventArgs e)
        {
            AdminPackage frm = new AdminPackage();
            frm.ShowDialog();
            frm.Dispose();
            frm = null;
        }

        private void btnGCDatabase_Click(object sender, EventArgs e)
        {
            AdminGiftCertificate frm = new AdminGiftCertificate((_employee.EmployeeGroup.Code == "ADMIN") ? true : false);
            frm.ShowDialog();
            frm.Dispose();
            frm = null;

        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            AdminSales frm = new AdminSales();
            frm.ShowDialog();
            frm.Dispose();
            frm = null;
        }

        private void btnCouponDatabase_Click(object sender, EventArgs e)
        {
            AdminCoupon frm = new AdminCoupon((_employee.EmployeeGroup.Code == "ADMIN") ? true : false);
            frm.ShowDialog();
            frm.Dispose();
            frm = null;

        }

        private void btnFreebies_Click(object sender, EventArgs e)
        {
            AdminFreebie frm = new AdminFreebie();
            frm.ShowDialog();
            frm.Dispose();
            frm = null;

        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            AdminSupplier frm = new AdminSupplier();
            frm.ShowDialog();
            frm.Dispose();
            frm = null;

        }

        private void btnPriceList_Click(object sender, EventArgs e)
        {
            //VerifyPassword vp = new VerifyPassword("PriceList");
            //vp.ShowDialog();
            //if (!vp.Canceled)
            //{
            //    if (vp.Employee != null)
            //    {
                    AdminProductList frm = new AdminProductList(_employee.Id);
                    frm.ShowDialog();
                //    frm = null;
                //}
            //}
            //vp.Dispose();
            //vp = null;
        }
        private void ControlButtons(string mode)
        {
            btnCouponDatabase.Enabled = mode.Substring(0, 1)=="1"?true:false;
            btnGCDatabase.Enabled = mode.Substring(1, 1) == "1" ? true : false;
            btnSupplier.Enabled = mode.Substring(2, 1) == "1" ? true : false;
            btnUserManagement.Enabled = mode.Substring(3, 1) == "1" ? true : false;
            btnSales.Enabled = mode.Substring(4, 1) == "1" ? true : false;
            btnPriceList.Enabled = mode.Substring(5, 1) == "1" ? true : false;
            restoreToolStripMenuItem.Enabled = mode.Substring(6, 1) == "1" ? true : false;
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            if (_employee.EmployeeGroup.Code == "ADMIN")
            {
                ControlButtons("1111111");
            }
            else
            {
                ControlButtons("1100000");
            }
        }

        private void btnParticularType_Click(object sender, EventArgs e)
        {
            AdminParticularType frm = new AdminParticularType();
            frm.ShowDialog();
            frm.Dispose();
            frm = null;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            MessageBox.Show(PhotoStore.BusinessLogic.blUtility.ExecuteScripts(Application.StartupPath));
        }

        private void backUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == folderBrowserDialog1.ShowDialog())
            {
                string directory = folderBrowserDialog1.SelectedPath;
                using (DBUtility dbUtility = new DBUtility(
                    ConfigurationManager.AppSettings["CmdUtility"].ToString(),
                    directory)
                    )
                {
                    try
                    {
                        string arg = dbUtility.BuildBackupArgumentForSqlCmd(directory);
                        dbUtility.AutoBackUpBySQLCMD(arg, 0, Convert.ToDouble(ConfigurationManager.AppSettings["RetentionDays"]));
                        MessageBox.Show("Database has been successfully backed up");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                //string directory = folderBrowserDialog1.SelectedPath;
                // string fileName = string.Concat(
                //directory,
                //ConfigurationManager.AppSettings["DBName"].ToString(),
                //DateTime.Now.ToString("MMddyyyyhhmmss"),
                //".bak"
                //);
                //using (DBUtility dbUtility = new DBUtility(
                //        ConfigurationManager.AppSettings["CmdUtility"].ToString(),
                //        directory
                //        ))
                //{
                //    try
                //    {
                //        //dbUtility.BackUp();
                //        dbUtility.BackUpBySQLCmd(string.Format(ConfigurationManager.AppSettings["BackUpArgument"].ToString(),
                //        ConfigurationManager.AppSettings["InstanceName"],
                //        ConfigurationManager.AppSettings["DBName"],
                //        fileName),
                //        Convert.ToInt32(ConfigurationManager.AppSettings["WaitTimeOut"]));
                      
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.Message);
                //    }
                //}
            }
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK ==openFileDialog1.ShowDialog())
            {
                string fileName = openFileDialog1.FileName;
                using (DBUtility dbUtility = new DBUtility(
                        ConfigurationManager.AppSettings["CmdUtility"].ToString(),
                        ""
                        ))
                {
                    try
                    {
                        dbUtility.RestoreBySQLCmd(string.Format(ConfigurationManager.AppSettings["RestoreArgument"].ToString(),
                        ConfigurationManager.AppSettings["InstanceName"],
                        ConfigurationManager.AppSettings["DBName"],
                        fileName),
                        Convert.ToInt32(ConfigurationManager.AppSettings["WaitTimeOut"]));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                //using (DBUtility dbUtility = new DBUtility(
                //    ConfigurationManager.AppSettings["InstanceName"].ToString(),
                //    ConfigurationManager.AppSettings["DBName"].ToString(),
                //    directory))
                //{
                //    try
                //    {
                //        dbUtility.Restore();
                //        MessageBox.Show("File has been successfully restored into the database");
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.Message);
                //    }
                //}
            }
        }

      
    }
}