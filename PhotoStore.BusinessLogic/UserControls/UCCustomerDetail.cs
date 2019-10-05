using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PhotoStore.BusinessLogic;
using PhotoStore.Entity;
namespace PhotoStore.BusinessLogic.UserControls
{
    public partial class UCCustomerDetail : UserControl
    {
        public UCCustomerDetail()
        {
            InitializeComponent();
        }
        public object GetPriviledgeCardValue
        {
            get { return cboPriviledgeCard.SelectedValue; }
        }
        public string GetPriviledgeCardText
        {
            get { return cboPriviledgeCard.SelectedText; }
        }
        public string MotherName
        {
            get { return txtMothersName.Text.Trim(); }
        }
        public string FatherName
        {
            get { return txtFathersName.Text.Trim(); }
        }
        public string Address
        {
            get { return txtAddress.Text.Trim(); }
        }

        public bool IncludeBirthday { get { return checkBoxIncludeBirthday.Checked; } }
        


        public DateTime? BirthDay
        {
            get
            {
                if (dtpBirthDay.Value.ToString().Contains("1/1/1900"))
                    return null;
                else
                    return dtpBirthDay.Value;
            }
        }
        public string CellNumber
        {
            get { return txtCellNumber.Text.Trim(); }
        }
        public void HideUnHideControl(string mode)
        {
           lblCellNumber.Visible=mode.Substring(0,1).Trim()=="0"?false:true;
           txtCellNumber.Visible=mode.Substring(1,1).Trim()=="0"?false:true;
            lblBirthDay.Visible=mode.Substring(2,1).Trim()=="0"?false:true;
            dtpBirthDay.Visible=mode.Substring(3,1).Trim()=="0"?false:true;
        }
        public void PopulatePriviledgeCards()
        {
            BindingSource bs = new BindingSource();
          
            cboPriviledgeCard.ValueMember = "Id";
            cboPriviledgeCard.DisplayMember = "PriviledgedCardCode";
            bs.DataSource = blCustomer.getPriviledgedCard(true);
            bs.ResetBindings(false);
            cboPriviledgeCard.DataSource = bs;
        }

        private void UCCustomerDetail_Load(object sender, EventArgs e)
        {
            //PopulatePriviledgeCards();
           
        }

        private void cboPriviledgeCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt64(cboPriviledgeCard.SelectedValue) != -1)
            {
                Entity.Customer customer = blCustomer.retrieve(Convert.ToInt64(cboPriviledgeCard.SelectedValue));
                txtFathersName.Text = customer.FathersName;
                txtMothersName.Text = customer.MothersName;
                txtAddress.Text = customer.Address;
            }
            else
            {
                txtFathersName.Clear();
                txtAddress.Clear();
                txtMothersName.Clear();
            }
        }

        private void CheckBoxIncludeBirthday_CheckedChanged(object sender, EventArgs e)
        {
            lblBirthDay.Visible = checkBoxIncludeBirthday.Checked;
            dtpBirthDay.Visible = lblBirthDay.Visible;
        }
    }
}
