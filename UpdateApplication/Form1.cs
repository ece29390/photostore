using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhotoStore.UtilityServices;
using System.IO;
using System.Diagnostics;
namespace UpdateApplication
{
    public partial class PicabooUpdate : Form
    {
        public PicabooUpdate()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDestination.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btnUpdate.Enabled = (txtDestination.TextLength > 0&&txtSourcePath.TextLength>0) ? true : false;
        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Do you want to backup the existing application first?",
                "Application BackUp", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                string destinationPath=Directory.GetParent(txtDestination.Text.Trim()).FullName;
                UpdateAppService.BackUpApplication(string.Concat(
                Application.StartupPath, @"\Zip.exe"),string.Concat(
                destinationPath,@"\PhotoStore", DateTime.Now.ToString("MMddyyyy"), ".zip"),
                txtDestination.Text.Trim());
            }
            UpdateAppService.UpdateApplication(string.Concat(
                Application.StartupPath, @"\Unzip.exe"),
                txtSourcePath.Text.Trim(),
                txtDestination.Text.Trim());
           
            
            MessageBox.Show("Picaboo application is successfully updated");
           
        }

        private void txtSourcePath_TextChanged(object sender, EventArgs e)
        {
            btnUpdate.Enabled = (txtDestination.TextLength > 0 && txtSourcePath.TextLength > 0) ? true : false;
        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSourcePath.Text = openFileDialog1.FileName;
            }
        }
    }
}