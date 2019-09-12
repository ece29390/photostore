using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PhotoStore
{
    public partial class CustomerAddView : Form
    {
        public CustomerAddView()
        {
            InitializeComponent();
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            Customer frm = new Customer();
            frm.CustomerId = -1;
            frm.ShowDialog();
            frm.Dispose();
            frm = null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CustomerSearch frmSearch = new CustomerSearch();
            frmSearch.ShowDialog();
            int CustomerId = frmSearch.CustomerId;
            if (CustomerId < 0)
            {
                frmSearch.Dispose();
                frmSearch = null;
                return;
            }

            if (CustomerId == -1) return;
            Customer frm = new Customer();
            frm.CustomerId = CustomerId;
            frm.ShowDialog();

            frmSearch.Dispose();
            frmSearch = null;
            frm.Dispose();
            frm = null;

        }

        private void CustomerAddView_Load(object sender, EventArgs e)
        {

        }
    }
}