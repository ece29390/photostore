using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using PhotoStore.BusinessLogic;
using PhotoStore.BusinessLogic.UserControls;
using PhotoStore.Entity;
namespace PhotoStore
{
    public partial class TransactionSearch : Form
    {
        
        private long _OrderTransactionId = -1;
        private Employee _employee;
        const string TOTALAMOUNTCOLUMN = "colTotalAmount";
        const string FULLNAMECOLUMN = "colFullName";
        ListSortDirection _sortDirection = ListSortDirection.Ascending;
        string _sortedGridColumn="Code";
        public long OrderTransactionId
        {
            get { return _OrderTransactionId; }
            set { _OrderTransactionId = value; }
        }

        public TransactionSearch(Employee employee)
        {
            InitializeComponent();
            _employee = employee;
        }
        private bool Validate()
        {
            return !string.IsNullOrEmpty(txtCode.Text.Trim()) ||
                !string.IsNullOrEmpty(ucCustomerDetail1.GetPriviledgeCardText) ||
                !string.IsNullOrEmpty(ucCustomerDetail1.MotherName) ||
                !string.IsNullOrEmpty(ucCustomerDetail1.FatherName) ||
                !string.IsNullOrEmpty(ucCustomerDetail1.Address);
                
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            List<Entity.OrderTransactionView> OrderTransactionEntities = new List<PhotoStore.Entity.OrderTransactionView>();
            gvResultList.AutoGenerateColumns = false;
            gvResultList.DataSource = UI.BindSource(OrderTransactionEntities, false);

            if (!chkSearchWithDates.Checked)
            {
                if (!Validate())
                {
                    MessageBox.Show("Please input atleast one criteria");
                    return;
                }
            }

            if (chkSearchWithDates.Checked)
            {
                if (!BLService.IsValidDates(dtpFrom, dtpTo))
                    return;
            }
            DateTime? dtFrom = null;
            if (chkSearchWithDates.Checked)
                dtFrom = dtpFrom.Value;
            DateTime? dtTo = null;
            if (chkSearchWithDates.Checked)
                dtTo = dtpTo.Value;
            //gvResultList.Enabled = false;
          
         OrderTransactionEntities = blOrderTransaction.retrieveSearchTransactionView(
                txtCode.Text.Trim(), ucCustomerDetail1.GetPriviledgeCardText, ucCustomerDetail1.FatherName,
                ucCustomerDetail1.MotherName, ucCustomerDetail1.Address,dtFrom
                , dtTo,_sortedGridColumn,_sortDirection);
            // //blOrderTransaction.retrieve(txtCode.Text);
        // gvResultList.Enabled = true;
            if (OrderTransactionEntities.Count == 0)
            {
                MessageBox.Show("No Records found");
                return;
            }
            gvResultList.AutoGenerateColumns = false;
            gvResultList.DataSource = UI.BindSource(OrderTransactionEntities, false);
            //_OrderTransactionId = OrderTransactionEntity.Id;
            //this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _OrderTransactionId = -1;
            this.Close();
        }
        
    

        private void TransactionSearch_Load(object sender, EventArgs e)
        {
            _sortedGridColumn = "colCode";
            ucCustomerDetail1.PopulatePriviledgeCards();
            ucCustomerDetail1.HideUnHideControl("0000");
            if (_employee.EmployeeGroup.Code != "ADMIN")
            {
                foreach (DataGridViewColumn gvColumn in gvResultList.Columns)
                {
                    switch (gvColumn.Name)
                    {
                        case FULLNAMECOLUMN:
                        case TOTALAMOUNTCOLUMN:
                            gvColumn.Visible = false;
                            break;
                            
                    }
                }
            }
        }

        private void gvResultList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (gvResultList.Columns[e.ColumnIndex].Name != "colCode")
                    return;

                _OrderTransactionId = Convert.ToInt64(gvResultList.Rows[e.RowIndex].Cells["colId"].Value);
                //this.Close();
                
                if (_OrderTransactionId < 0)
                {
                    this.Close();
                }

                Transaction frm = new Transaction();
                //frm.ModifiedByEmployeeEntity = _EmployeeEntity;
                frm.OrderTransactionId = OrderTransactionId;
                frm.ShowDialog();
                frm.Dispose();
                frm = null;
            }
        }

        private void chkSearchWithDates_CheckedChanged(object sender, EventArgs e)
        {
            dtpFrom.Enabled = chkSearchWithDates.Checked;
            dtpTo.Enabled = chkSearchWithDates.Checked;
        }
        
        private void gvResultList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_sortedGridColumn == gvResultList.Columns[e.ColumnIndex].Name)
            {
                _sortDirection = (_sortDirection == ListSortDirection.Ascending) ?
                    ListSortDirection.Descending :
                    ListSortDirection.Ascending;
            }
            else
            {
                _sortDirection = ListSortDirection.Ascending;
            }
            _sortedGridColumn = gvResultList.Columns[e.ColumnIndex].Name;
            btnOK_Click(null, null);
        }

        

    }
}