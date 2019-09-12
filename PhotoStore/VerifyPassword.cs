using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhotoStore.BusinessLogic;
using PhotoStore.Entity;
namespace PhotoStore
{
    public partial class VerifyPassword : Form
    {
        private string _owner;

        private PhotoStore.Entity.Customer _customer;
        private bool _Canceled=true;
        public bool Canceled
        {
            get { return _Canceled; }
        }
        private Entity.Employee _Employee=null;
        public Entity.Employee Employee
        {
            get { return _Employee; }
            set { _Employee = value; txtUserName.Text = value.UserName; }
        }

        private bool _WithRemarks = false;
        public bool WithRemarks
        {
            get { return _WithRemarks; }
            set { _WithRemarks=value; }
        }

        public string Remarks
        {
            get { return txtRemarks.Text; }
        }

        public VerifyPassword()
        {
            InitializeComponent();
        }
        public VerifyPassword(string owner)
        {
            InitializeComponent();
            _owner = owner;
           
        }
        public VerifyPassword(string owner,PhotoStore.Entity.Customer customer)
        {
            InitializeComponent();
            _owner = owner;
            _customer = customer;
           
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_owner))
            {
                if (txtUserName.Text.Trim() == "")
                {
                    MessageBox.Show("Invalid User Name or Password");
                    return;
                }
                if (_WithRemarks)
                {
                    if (_WithRemarks & txtRemarks.Text.Trim() == "")
                    {
                        MessageBox.Show("Remarks is required");
                        return;
                    }
                }

                _Employee = BusinessLogic.blEmployee.retrieve(txtUserName.Text);

                if (_Employee == null)
                    MessageBox.Show("Invalid User Name or Password");
                else if (_Employee.Password != txtPassword.Text)
                    MessageBox.Show("Invalid User Name or Password");
                else
                {
                    _Canceled = false;
                    this.Close();
                }
            }
            else
            {
                switch (_owner)
                {
                    case "CustomerDelete":
                        if (txtUserName.Text.Trim() == "")
                        {
                            MessageBox.Show("Invalid User Name or Password");
                            return;
                        }
                        if (_WithRemarks & txtRemarks.Text.Trim() == "")
                        {
                            MessageBox.Show("Remarks is required");
                            return;
                        }

                        _Employee = BusinessLogic.blEmployee.retrieve(txtUserName.Text);

                        if (_Employee == null)
                            MessageBox.Show("Invalid User Name or Password");
                        else if (_Employee.Password != txtPassword.Text)
                            MessageBox.Show("Invalid User Name or Password");
                        else if (!_Employee.EmployeeGroupId.Equals(1))
                            MessageBox.Show("Only user with admin user role can delete this record");
                        else
                        {
                            try
                            {
                                blCustomer.delete(_customer.Id);                               
                                MessageBox.Show("Customer has been successfully deleted");
                                _Canceled = false;
                                this.Close();
                            }
                            catch (System.Data.SqlClient.SqlException ex)
                            {

                                if (ex.Message.Contains("conflicted with the REFERENCE constraint"))
                                {
                                    MessageBox.Show("Unable to delete this customer because \r\none or more order tansaction record\r\nis/are attached to this customer",
                                        "Unable to delete", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                           
                        }
                        break;
                    case "PriceList":
                    case "GCAdmin":
                    case "User":
                    case "CouponAdmin":
                        string[] adminGroups =
                            System.Configuration.ConfigurationManager.AppSettings["admingroup"].ToString().Split(
                            new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                        List<long> adminGroupList = new List<long>();
                        foreach (String str in adminGroups)
                        {
                            adminGroupList.Add(Convert.ToInt64(str));
                        }
                        if (txtUserName.Text.Trim() == "")
                        {
                            MessageBox.Show("Invalid User Name or Password");
                            return;
                        }
                        if (_WithRemarks & txtRemarks.Text.Trim() == "")
                        {
                            MessageBox.Show("Remarks is required");
                            return;
                        }

                        _Employee = BusinessLogic.blEmployee.retrieve(txtUserName.Text);

                        if (_Employee == null)
                            MessageBox.Show("Invalid User Name or Password");
                        else if (_Employee.Password != txtPassword.Text)
                            MessageBox.Show("Invalid User Name or Password");
                        else if (!adminGroupList.Contains(_Employee.EmployeeGroupId))
                        {
                            switch (_owner)
                            {
                                case "PriceList":
                                case "User":
                                    MessageBox.Show("Only the user with admin rights can access this section");
                                    return;
                                case "GCAdmin":
                                case "CouponAdmin":
                                    MessageBox.Show("Only the user with admin rights can modify this section");
                                    return;
                                default:
                                    break;
                            }
                          
                            
                        }
                        else
                        {
                            _Canceled = false;
                            this.Close();
                        }
                        break;
                    
                }
            }
        }

        private void VerifyPassword_Load(object sender, EventArgs e)
        {
            if (_WithRemarks)
            {
                this.Height += txtRemarks.Height + 5;
                btnOK.Top += txtRemarks.Height + 1;

                lblRemarks.Visible = true;
                txtRemarks.Visible = true;
            }
            txtUserName.Enabled = (_Employee == null);
        }

        private void VerifyPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.btnOK_Click(sender, null);
            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            VerifyPassword_KeyPress(sender, e);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            VerifyPassword_KeyPress(sender, e);
        }
    }
}