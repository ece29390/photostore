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
    public partial class AdminPriceDetails : Form
    {
        long _productList;
        string _description;
       // string _mode ;
        public AdminPriceDetails(long productList,string description)
        {
            InitializeComponent();
            _productList = productList;
            _description = description;
           // _mode = "CREATE";
        }

        public AdminPriceDetails(ProductListDetails pld,string description)
        {
            InitializeComponent();
            this.pld = pld;
           // txtPCDUnitPrice.Text = pld.UnitPrice.ToString();
            txtPLDParticulars.Text = pld.Particulars;
            txtPLDQuantity.Text = pld.Quantity.ToString();
            _description = description;
        }
        //public string Mode
        //{
        //    get { return _mode; }
        //}
        ProductListDetails pld = null;
        public ProductListDetails ProductListDetails
        {
            get { return pld; }
        }

        private void btnPCDAddItem_Click(object sender, EventArgs e)
        {
            int quantity = 0;
            if (!int.TryParse(txtPLDQuantity.Text.Trim(), out quantity))
            {
                MessageBox.Show("Quantity value is invalid");
                return;
            }
            if (quantity <= 0)
            {
                MessageBox.Show("Quantity should not be equal or less than to zero");
                return;
            }

            //decimal unitPrice = 0;
            //if (!decimal.TryParse(txtPCDUnitPrice.Text.Trim(), out unitPrice))
            //{
            //    MessageBox.Show("Unit Price value is invalid");
            //    return;
            //}
            //if (unitPrice <= 0)
            //{
            //    MessageBox.Show("Unit price should not be less than or equal to zero");
            //    return;
            //}
            if (pld == null)
                pld = new ProductListDetails();
           
            pld.Quantity = quantity;
            //pld.UnitPrice = unitPrice;
            pld.Particulars = txtPLDParticulars.Text.Trim();

   
            //if (blProductListDetails.retrieveByDescription(pld.Particulars).Count > 0)
            //{
            //    MessageBox.Show("Particulars already existing");
            //    pld = null;
            //    return;
            //}

            

            if (pld.Id > 0)
            {
                blProductListDetails.update(pld);
            }
            else
            {
                pld.ProductList_Id = _productList;
                pld = blProductListDetails.create(pld);
            }
            MessageBox.Show("Product List Details has been successfully added");
            this.Close();
           
        }

        private void txtPLDQuantity_TextChanged(object sender, EventArgs e)
        {
            TextBoxChanged();
        }

       

        private void txtPCDUnitPrice_TextChanged(object sender, EventArgs e)
        {
            TextBoxChanged();
        }

        private void TextBoxChanged()
        {
            btnPCDAddItem.Enabled = 
                (txtPLDQuantity.TextLength > 0) && (txtPLDParticulars.TextLength>0);
        }

        private void txtPLDParticulars_TextChanged(object sender, EventArgs e)
        {
            TextBoxChanged();
        }

        private void AdminPriceDetails_Load(object sender, EventArgs e)
        {
            label4.Text = string.Format("Items of {0}", _description);
        }
    }
}