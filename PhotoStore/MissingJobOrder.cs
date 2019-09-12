using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhotoStore.BusinessLogic;
namespace PhotoStore
{
    public partial class MissingJobOrder : Form
    {
        public MissingJobOrder()
        {
            InitializeComponent();
        }

        private void MissingJobOrder_Load(object sender, EventArgs e)
        {
            dgMissingItems.AutoGenerateColumns = false;
            dgMissingItems.DataSource = UI.BindSource(
                blJobOrder.retrieveMissingJobOrders(),false);
            btnExecuteAdjustment.Enabled = dgMissingItems.RowCount > 0;
        }

        private void btnExecuteAdjustment_Click(object sender, EventArgs e)
        {
            blJobOrder.executeAdjustment();
            DialogResult = MessageBox.Show("Execution Successful", "Successful",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}