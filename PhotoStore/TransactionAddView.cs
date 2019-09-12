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
    public partial class TransactionAddView : Form
    {
        private Entity.Employee _EmployeeEntity = null;
        private Entity.Customer _CustomerEntity = null;
        private Entity.OrderStatus _OrderStatusEntity = null;

        public TransactionAddView()
        {
            InitializeComponent();
            //_EmployeeEntity = employee;
        }

        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            
            //verify the password of the employee that prepares the transaction
            VerifyPassword frmVP = new VerifyPassword();
            frmVP.ShowDialog();
            if (frmVP.Canceled)
            {
                frmVP.Dispose();
                frmVP = null;
                return;
            }
            else
            {
                _EmployeeEntity = frmVP.Employee;
                frmVP.Dispose();
                frmVP = null;
            }
            if (_EmployeeEntity == null) return;


            //look for the customer to make the transaction
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

            _CustomerEntity = BusinessLogic.blCustomer.retrieve(CustomerId);

            //prepare a new order status
            _OrderStatusEntity = BusinessLogic.blOrderStatus.retrieve("Original");

            Transaction frm = new Transaction();
            frm.PreparedByEmployeeEntity = _EmployeeEntity;
            frm.CustomerEntity = _CustomerEntity;
            frm.OrderStatusEntity = _OrderStatusEntity;
            frm.ShowDialog();
            frm.Dispose();
            frm = null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //verify the password of the employee that prepares the transaction
            VerifyPassword frmVP = new VerifyPassword();
            frmVP.ShowDialog();
            if (frmVP.Canceled)
            {
                frmVP.Dispose();
                frmVP = null;
                return;
            }
            else
            {
                _EmployeeEntity = frmVP.Employee;
                frmVP.Dispose();
                frmVP = null;
            }
            if (_EmployeeEntity == null) return;

            TransactionSearch frmSearch = new TransactionSearch(_EmployeeEntity);
            frmSearch.ShowDialog();            
            frmSearch.Dispose();
            frmSearch = null;

        }

        private void TransactionAddView_Load(object sender, EventArgs e)
        {

        }
    }
}