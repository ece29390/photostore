using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhotoStore.Entity;
using PhotoStore.BusinessLogic;
using PhotoStore.UtilityServices;
using System.IO;
using System.Threading;
namespace PhotoStore
{
    public partial class Startup : Form
    {
        Mutex _oneMutex = null;
        const string MUTEX_NAME = "PhotoStore.Mutex";
        public Startup()
        {
            InitializeComponent();
        }

        private void btnJobOrder_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("not yet implemented");
            PreJobOrder frm = new PreJobOrder();
            frm.ShowDialog();
            frm.Dispose();
            frm = null;
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            //verify the password of the employee that will cancel the transaction
            //Entity.Employee adminEmployee = null;
            //string cancelRemarks = "";
            VerifyPassword frmVP = new VerifyPassword();
            frmVP.WithRemarks = false;
            frmVP.ShowDialog();

            if (frmVP.Canceled)
            {
                frmVP.Dispose();
                frmVP = null;
                return;
            }
            else
            {
                //adminEmployee = frmVP.Employee;
                //cancelRemarks = frmVP.Remarks;
               
                Admin frm = new Admin(frmVP.Employee);
                frm.ShowDialog();
                frm.Dispose();
                frm = null;
                frmVP.Dispose();
                frmVP = null;
            }

           
        }

        private void btnCustomerDatabase_Click(object sender, EventArgs e)
        {
            CustomerAddView frm = new CustomerAddView();
            frm.ShowDialog();
            frm.Dispose();
            frm = null;
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
           

                TransactionAddView frm = new TransactionAddView();
                frm.ShowDialog();
                frm.Dispose();
                frm = null;
            
            
          
            btnJobOrder.Enabled = (blJobOrder.GetOrderCount() == 0) ? false : true;
        }
        private void BackUpDbAndExecuteScripts()
        {
            string fileName = string.Concat(
                ConfigurationManager.AppSettings["BackUpPath"].ToString(),
                ConfigurationManager.AppSettings["DBName"].ToString(),
                DateTime.Now.ToString("MMddyyyyhhmmss"),
                ".bak"
                );

            string branchCode = ConfigurationManager.AppSettings["BranchCode"];

            this.Text = string.Concat(this.Text, " - ", branchCode);

            using (DBUtility dbUtility = new DBUtility(
                ConfigurationManager.AppSettings["CmdUtility"].ToString(),
                ConfigurationManager.AppSettings["MSSQLBackUp"])
                )
            {
                try
                {

                    string backupArg = dbUtility.BuildBackupArgumentForSqlCmd(ConfigurationManager.AppSettings["MSSQLBackUp"]);
                    
                    dbUtility.AutoBackUpBySQLCMD(
                        backupArg,
                        0,
                        Convert.ToDouble(
                        ConfigurationManager.AppSettings["RetentionDays"]));
                    string[] files = Directory.GetFiles(Application.StartupPath, "*.sql");
                    if (files.Length > 0)
                    {
                        MessageBox.Show(blUtility.ExecuteScripts(
                            Application.StartupPath));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }
        private void UpdateGCAndCouponForDiscrepancy()
        {
            blUtility.AdjustGcOrCouponStatus(NonProductType.GiftCertificateAndCoupon);
        }
        private void Startup_Load(object sender, EventArgs e)
        {
            try
            {
                //check if mutex is already existing 
                //if existing then it means that an instance of this application is already running
                _oneMutex = Mutex.OpenExisting(MUTEX_NAME);
            }
            catch(WaitHandleCannotBeOpenedException)
            {

            }

            if (_oneMutex == null)
            {
                //Create instance of the mutex
                _oneMutex = new Mutex(true, MUTEX_NAME);
                //back up db first thing in the morning
                BackUpDbAndExecuteScripts();
                //check for discrepancies in the gc and coupon status
                UpdateGCAndCouponForDiscrepancy();
            }
            else
            {
                MessageBox.Show("This application is already running\r\nMultiple instance of this application is not allowed",
                    "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();

            }
            //btnJobOrder.Enabled = (blJobOrder.GetOrderCount() == 0) ? false : true;
        }

        private void Startup_FormClosing(object sender, FormClosingEventArgs e)
        {
            _oneMutex.Close();
            //_oneMutex.ReleaseMutex();
        }
    }
}