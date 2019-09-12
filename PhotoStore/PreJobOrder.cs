using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhotoStore.Entity;
using PhotoStore.BusinessLogic;
namespace PhotoStore
{
    public partial class PreJobOrder : Form
    {
        public PreJobOrder()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchJobOrder frm = new SearchJobOrder();
            frm.ShowDialog();
            frm.Dispose();
            frm = null;
        }

        private void btnViewJob_Click(object sender, EventArgs e)
        {
            ViewJobOrder frm = new ViewJobOrder();
            frm.ShowDialog();
            frm.Dispose();
            frm = null;
        }

        private void btnCreateAmend_Click(object sender, EventArgs e)
        {
            //Check first if supplier is existing if true procedd to JobOrderMain
            //population otherwise Go to SupplierMaintenanceModule
            List<Supplier> suppliers = new List<Supplier>();
            // just in case if a user decided to populate the supplier form 
            //then cancel it still won't proceed to JobOrderMain form
            DialogResult diag;
            do
            {
                suppliers = blSupplier.retrieve();
                if (suppliers.Count.Equals(0))
                {
                    diag = MessageBox.Show("You can't create joborder if no \r\nsupplier is present in the system\r\nWould you like to create?",
                        "No supplier detected", MessageBoxButtons.OKCancel);
                    if (diag == DialogResult.OK)
                    {
                        AdminSupplier sfrm = new AdminSupplier();
                        sfrm.ShowDialog();
                        sfrm.Dispose();
                        sfrm = null;
                    }
                    else
                    {
                        this.Close();
                        break;
                    }

                }
            }
            while (suppliers.Count == 0);

            if (suppliers.Count == 0)
                return;

            JobOrderMain frm = new JobOrderMain();
            frm.ShowDialog();
            frm.Dispose();
            frm = null;
        }
    }
}