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
    public partial class CustomerSearch : Form
    {
        private bool _isLoaded = false;
        private int _CustomerId = -1;
        public int CustomerId
        {
            get { return _CustomerId; }
            set { _CustomerId = value; }
        }

        public CustomerSearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (_isLoaded
                & (string.IsNullOrEmpty(ucCustomerDetail1.GetPriviledgeCardText.Trim()))
                & (string.IsNullOrEmpty(ucCustomerDetail1.FatherName.Trim()))
                & (string.IsNullOrEmpty(ucCustomerDetail1.MotherName.Trim()))
                & (string.IsNullOrEmpty(ucCustomerDetail1.Address.Trim()))
                & (!ucCustomerDetail1.BirthDay.HasValue)
                & (string.IsNullOrEmpty(ucCustomerDetail1.CellNumber.Trim()))
                )
            {
                MessageBox.Show("Provide a search criteria");
                return;
            }

            Entity.Customer customerEntity = new PhotoStore.Entity.Customer();

            //customerEntity.PrivilegeCardCode = txtPrivilegeCardCode.Text;
            customerEntity.PrivilegeCardCode = ucCustomerDetail1.GetPriviledgeCardText.Trim();//cboPriviledgeCard.SelectedText.Trim();
            customerEntity.FathersName = ucCustomerDetail1.FatherName.Trim();//txtFathersName.Text;
            customerEntity.MothersName = ucCustomerDetail1.MotherName.Trim();//txtMothersName.Text;
            customerEntity.Address = ucCustomerDetail1.Address.Trim();//txtAddress.Text;
            if (ucCustomerDetail1.BirthDay.HasValue)
            {
                customerEntity.FathersBirthDate = ucCustomerDetail1.BirthDay.Value;
                customerEntity.MothersBirthDate = ucCustomerDetail1.BirthDay.Value;
            }
          
                customerEntity.FathersCellNumber = ucCustomerDetail1.CellNumber.Trim();
                customerEntity.MothersCellNumber = ucCustomerDetail1.CellNumber.Trim();


            List<Entity.Customer> customerList= BusinessLogic.blCustomer.retrieveByEntity(customerEntity);

            gvSearch.DataSource = null;
            gvSearch.AutoGenerateColumns = false;
            gvSearch.DataSource = customerList;

            lblSearchCount.Text = "Search results count = " + customerList.Count;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (gvSearch.DataSource==null)
            {
                MessageBox.Show("Select a row from the search results");
                return;
            }
            if (gvSearch.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row from the search results");
                return;
            }
            
            _CustomerId = Convert.ToInt32(gvSearch.SelectedRows[0].Cells["colId"].Value);
            //verify if the priviledge card of the user is already expired
            //string code = gvSearch.SelectedRows[0].Cells["colPrivilegeCardCode"].Value.ToString();
            //if (blPrivilegeCard.IsExpired(_CustomerId, code))//change the priviledge card number if true
            //{
            //    List<PhotoStore.Entity.PrivilegeCard> lists = blPrivilegeCard.retrieveActiveByCustomerId(_CustomerId);
            //    if (lists.Count > 0)
            //    {
            //        PhotoStore.Entity.Customer customer = blCustomer.retrieve(_CustomerId);
            //        customer.PrivilegeCardCode = lists[0].Code;
            //    }
                
            //}
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _CustomerId = -1;
            this.Close();
        }

        private void CustomerProfileSearch_Load(object sender, EventArgs e)
        {
            //cboPriviledgeCard.ValueMember = "Id";
            //cboPriviledgeCard.DisplayMember = "PriviledgedCardCode";
            //cboPriviledgeCard.DataSource = UI.BindSource(blCustomer.getPriviledgedCard(true), false);
            ucCustomerDetail1.PopulatePriviledgeCards();
           // cboPriviledgeCard.SelectedIndex = 0;
            _isLoaded = false;
           // btnSearch_Click(sender, e);
            _isLoaded = true;
                                 
        }

        private void gvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnOK_Click(sender, e);
        }

        //private void cboPriviledgeCard_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (Convert.ToInt64(cboPriviledgeCard.SelectedValue) != -1)
        //    {
        //        Entity.Customer customer = blCustomer.retrieve(Convert.ToInt64(cboPriviledgeCard.SelectedValue));
        //        txtFathersName.Text = customer.FathersName;
        //        txtMothersName.Text = customer.MothersName;
        //        txtAddress.Text = customer.Address;
        //    }
        //    else
        //    {
        //        txtFathersName.Clear();
        //        txtAddress.Clear();
        //        txtMothersName.Clear();
        //    }
        //}
    }
}