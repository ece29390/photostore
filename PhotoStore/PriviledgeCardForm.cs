using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhotoStore.BusinessLogic;
using PhotoStore.Entity;
using PhotoStore.UtilityServices;
namespace PhotoStore
{
    public partial class PriviledgeCardForm : Form
    {
        PhotoStore.Entity.PrivilegeCard _priviledgeCard;
        string[] _branchCodes;
        private string GetGustomerName()
        {
            string customerName = "";
            customerName = _priviledgeCard.CustomerEntity.MothersName.Trim();
            if (string.IsNullOrEmpty(customerName))
                customerName = _priviledgeCard.CustomerEntity.FathersName.Trim();
            return customerName;
        }
        public PriviledgeCardForm(long customerId,string code)
        {
            InitializeComponent();
            string customerName="";
            if (!string.IsNullOrEmpty(code))
            {
                _priviledgeCard = blPrivilegeCard.retrieveByCustomerIdAndCode(customerId,code);
                
            }
            else
            {
                _priviledgeCard = new PhotoStore.Entity.PrivilegeCard();
                _priviledgeCard.CustomerId = customerId;
                _priviledgeCard.CustomerEntity = blCustomer.retrieve(customerId);


            }
            txtCustomerName.Text = GetGustomerName();
        }
        public List<PhotoStore.Entity.PrivilegeCard> PriviledgeCards
        {
            get { return blPrivilegeCard.retrieveActiveByCustomerId(_priviledgeCard.CustomerId); }
        }
        private void dtpIssueDate_ValueChanged(object sender, EventArgs e)
        {
            txtExpirationDate.Text = dtpIssueDate.Value.AddYears(1).ToString("MM/dd/yyyy");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string code = blPrivilegeCard.AddPrefix(cboPrefix.Text,
                txtPriviledgeCard.Text.Trim());
            PhotoStore.Entity.PrivilegeCard pCard=blPrivilegeCard.retrieve(code);
            if (pCard != null)
            {
                if (pCard.CustomerId != _priviledgeCard.CustomerId)
                {
                    MessageBox.Show("Priviledge Card number is already existing");
                    return;
                }
            }
            _priviledgeCard.Code = code;
            //_priviledgeCard.DateLastModified = DateTime.Now;
            _priviledgeCard.ExpirationDate = Convert.ToDateTime(txtExpirationDate.Text.Trim());
            _priviledgeCard.IssueDate = dtpIssueDate.Value;
            _priviledgeCard.Remarks = txtRemarks.Text.Trim();
            if (_priviledgeCard.Id > -1)
                blPrivilegeCard.update(_priviledgeCard);
            else
                blPrivilegeCard.create(_priviledgeCard);

            this.Close();
        }
        private void PopulatePriviledgeEntity()
        {
            string actualCode = "";
            string prefixCode = "" ;
           
            if (_priviledgeCard.Id > -1)
            {
                txtExpirationDate.Text = _priviledgeCard.ExpirationDate.ToString("MM/dd/yyyy");
                actualCode = _priviledgeCard.Code.Trim();
                txtPriviledgeCard.Text = actualCode;
            
                dtpIssueDate.Value = _priviledgeCard.IssueDate;
                txtRemarks.Text = _priviledgeCard.Remarks;
            }
            blPrivilegeCard.BreakUpPrefixAndCode(ref actualCode, _branchCodes,
               out prefixCode);
            txtPriviledgeCard.Text = actualCode;
            cboPrefix.Text = prefixCode;
        }
        private void PriviledgeCardForm_Load(object sender, EventArgs e)
        {
            _branchCodes = ConfigurationManager.AppSettings["BranchCodes"].ToString().Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string branchCode in _branchCodes)
            {
                cboPrefix.Items.Add(branchCode);
            }
            txtExpirationDate.Text = dtpIssueDate.Value.AddYears(1).ToString("MM/dd/yyyy");

            PopulatePriviledgeEntity();
        }

        private void cboPrefix_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtPriviledgeCard_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = txtPriviledgeCard.TextLength > 0 ? true : false;
        }


       
    }
}