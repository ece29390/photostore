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
    public partial class PrivilegeCard : Form
    {
        #region Declarations
        //declare an entity
        List<Entity.PrivilegeCard> _PrivilegeCardList = new List<PhotoStore.Entity.PrivilegeCard>();

        private string _errorMessage = "";
        #endregion

        #region Properties
        private long _CustomerId = -1;
        public long CustomerId
        {
            get { return _CustomerId; }
            set { _CustomerId = value; }
        }

        /// <summary>check if the data is new</summary>
        public bool isNewCustomer
        {
            get { return _CustomerId == -1; }
        }
        #endregion

        #region Methods
        /// <summary>validate required fields</summary>
        /// <returns></returns>
        public bool checkRequiredFields()
        {
            //initialize
            foreach (DataGridViewColumn col in gvDataEntry.Columns)
            {
                col.HeaderCell.Style.ForeColor = DataGridView.DefaultForeColor;
            }

            //check
            foreach (DataGridViewRow row in gvDataEntry.Rows)
            {
                if (row.Cells["colId"].Value == null) return true;

                //validate new records only
                if (Convert.ToInt32( row.Cells["ColId"].Value) == -1)
                {
                    //look for null columns and empty data
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.ColumnIndex != gvDataEntry.Columns["colRemarks"].Index)
                        {
                            if (cell.Value == null)
                            {
                                _errorMessage = gvDataEntry.Columns[cell.ColumnIndex].HeaderText + " is a required field.";
                                gvDataEntry.Columns[cell.ColumnIndex].HeaderCell.Style.ForeColor = Color.Red;
                                gvDataEntry.Focus();
                                cell.Selected = true;
                                return false;
                            }

                            if (cell.Value.ToString().Trim() == "")
                            {
                                _errorMessage = gvDataEntry.Columns[cell.ColumnIndex].HeaderText + " is a required field.";
                                gvDataEntry.Columns[cell.ColumnIndex].HeaderCell.Style.ForeColor = Color.Red;
                                gvDataEntry.Focus();
                                cell.Selected = true;
                                return false;
                            }

                        }

                    }

                }
            }
            return true;
        }
    

        /// <summary>check the validity of the encoded data</summary>
        /// <returns></returns>
        public bool checkEncodedData()
        {

            gvDataEntry.Columns["colCode"].HeaderCell.Style.ForeColor = DataGridView.DefaultForeColor;
            string PrivilegeCardCode = "";
            foreach (DataGridViewRow row in gvDataEntry.Rows)
            {
                if (row.Cells["colId"].Value == null) return true;

                PrivilegeCardCode = string.Concat(row.Cells["colPrefix"].Value.ToString().Trim(),row.Cells["colCode"].Value.ToString().Trim());
                row.Cells["colCode"].Style.ForeColor = DataGridView.DefaultForeColor;

                ////validate new records only
                //if (Convert.ToInt32(row.Cells["ColId"].Value) == -1)
                //{
                    //check if the priviledge card is available
                    if (blPrivilegeCard.isUsed(PrivilegeCardCode))
                    {
                        //is the card owned by the specified customer
                        if (row.Cells["colId"].Value.ToString() != "-1")
                        {
                            if (!blPrivilegeCard.isOwned(PrivilegeCardCode, _CustomerId))
                            {
                                row.Cells["colCode"].Style.ForeColor = Color.Red;
                                row.Cells["colCode"].OwningColumn.HeaderCell.Style.ForeColor = Color.Red;
                                _errorMessage = "Privilege card number is owned by another customer.";
                                return false;
                            }
                        }
                        else
                        {
                            row.Cells["colCode"].Style.ForeColor = Color.Red;
                            row.Cells["colCode"].OwningColumn.HeaderCell.Style.ForeColor = Color.Red;
                            _errorMessage = "Privilege card number is owned by another customer.";
                            return false;
                        }

                        //row.Cells["colCode"].Style.ForeColor = Color.Red;
                        //row.Cells["colCode"].OwningColumn.HeaderCell.Style.ForeColor = Color.Red;
                        //_errorMessage = "Privilege card was already used.";
                        //return false;
                    }

                //}

                if (!row.Cells["colCode"].ReadOnly)
                {
                    //is the card expired
                    if (blPrivilegeCard.isExpired(PrivilegeCardCode))
                    {
                        row.Cells["colCode"].Style.ForeColor = Color.Red;
                        row.Cells["colCode"].OwningColumn.HeaderCell.Style.ForeColor = Color.Red;
                        _errorMessage = "Privilege card is already expired.";
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion

        public PrivilegeCard()
        {
            InitializeComponent();
        }

        private void PrivilegeCard_Load(object sender, EventArgs e)
        {
            LoadPrivilegeCards();
        }

        private void RemovePrefix()
        {
            for (int i = 0; i < _PrivilegeCardList.Count; i++)
            {
                _PrivilegeCardList[i].Code = _PrivilegeCardList[i].Code.Replace(
                    _branchCode, "").Trim();
            }
        }
        string _branchCode;
        private void LoadPrivilegeCards()
        {
             _branchCode = System.Configuration.ConfigurationManager.AppSettings["BranchCode"].ToString();
            _PrivilegeCardList = BusinessLogic.blPrivilegeCard.retrieveByCustomerId(_CustomerId);

            //RemovePrefix();

            gvDataEntry.DataSource = null;
            gvDataEntry.AutoGenerateColumns = false;

            //this will prevent the "Index -1 does not have a value" message
            BindingSource bs = new BindingSource();
            bs.DataSource = _PrivilegeCardList;
            bs.ResetBindings(false);
            
            
            gvDataEntry.DataSource = bs;
            //DateTime? expirationDate = null;
            //set existing records to readonly
            blPrivilegeCard.SetState(gvDataEntry);

            //if (expirationDate.HasValue)
            //{
            //    expirationDate = Convert.ToDateTime(expirationDate.Value.ToString("MM/dd/yyyy"));
            //    DateTime dt = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy"));
            //    if (expirationDate <= dt)
            //    {
            //        gvDataEntry.AllowUserToAddRows = true;
            //    }
            //    else
            //    {
            //        gvDataEntry.AllowUserToAddRows = false;
            //    }
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (Entity.PrivilegeCard item in _PrivilegeCardList)
            {
                item.CustomerId = _CustomerId;
            }

            #region validation routines
            //validate required data
            if (!checkRequiredFields())
            {
                MessageBox.Show("Please fill in the required fields.\r\n"
                    + _errorMessage,this.Text);
                return;
            }

            //validate invalid data
            if (!checkEncodedData())
            {
                MessageBox.Show("Invalid data found.\r\n"
                    + _errorMessage, this.Text);
                return;
            }
            #endregion
            _PrivilegeCardList = BusinessLogic.blPrivilegeCard.updateListByCustomerId(_CustomerId,_PrivilegeCardList);
            RemovePrefix();
            MessageBox.Show("Save Succeeded!");
            this.Close();
        }

        private void gvDataEntry_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (gvDataEntry.ReadOnly) return;
            string colName = gvDataEntry.CurrentCell.OwningColumn.Name;
            //if (colName != "colIssueDate") return;
            //if (gvDataEntry.Rows[e.RowIndex].Cells["colIssueDate"].ReadOnly) return;
            //gvDataEntry.Rows[e.RowIndex].Cells["colExpirationDate"].Value = Convert.ToDateTime(gvDataEntry.CurrentCell.Value).AddYears(1);

            //colCode
            switch (colName)
            {
                case "colIssueDate":
                    if (gvDataEntry.Rows[e.RowIndex].Cells["colIssueDate"].ReadOnly) return;
                    gvDataEntry.Rows[e.RowIndex].Cells["colExpirationDate"].Value = Convert.ToDateTime(gvDataEntry.CurrentCell.Value).AddMonths(
                        Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["autogcadd"]));
                    break;
                case "colCode":
                    gvDataEntry.Rows[e.RowIndex].Cells[colName].Value =
                        blUtility.FormatCode(gvDataEntry.Rows[e.RowIndex].Cells[colName].Value.ToString());
                    break;

            }

        }

        private void gvDataEntry_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string colName = gvDataEntry.CurrentCell.OwningColumn.Name;
            if (colName != "colIssueDate") return;
            if (gvDataEntry.Rows[e.RowIndex].Cells["colIssueDate"].ReadOnly) return;
            DateTime res = DateTime.Now;
            if (!DateTime.TryParse(e.FormattedValue.ToString(), out res))
            {
                MessageBox.Show("Invalid Date/Time Format", this.Text);
                e.Cancel = true;
            }
        }

        private void gvDataEntry_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           // gvDataEntry.Rows[e.RowIndex].Cells["colPrefix"].Value = _branchCode;
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PriviledgeCardForm frm = new PriviledgeCardForm(
                _CustomerId, "");
            frm.ShowDialog();
            gvDataEntry.AutoGenerateColumns = false;
            gvDataEntry.DataSource=UI.BindSource(
                frm.PriviledgeCards,false);
            blPrivilegeCard.SetState(gvDataEntry);
            frm.Dispose();
            frm = null;
        }

        private void gvDataEntry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex != -1)
            {
                if (gvDataEntry.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor==Color.LightGray)
                {
                    MessageBox.Show("Selected record is currently in use", "Modification Not Allowed",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                switch (gvDataEntry.Columns[e.ColumnIndex].Name)
                {
                    case "colCode":
                        string code = gvDataEntry.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        //if (blPrivilegeCard.isUsed(code))
                        //{
                        //    MessageBox.Show("Selected record is currently in use", "Modification Not Allowed",
                        //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                               
                        //    return;
                        //}
                        PriviledgeCardForm frm = new PriviledgeCardForm(
                            _CustomerId, code);
                        frm.ShowDialog();
                        gvDataEntry.AutoGenerateColumns = false;
                        gvDataEntry.DataSource = UI.BindSource(
                            frm.PriviledgeCards, false);
                        blPrivilegeCard.SetState(gvDataEntry);
                        frm.Dispose();
                        frm = null;
                        break;
                    default:
                        break;
                }
            }
        }


    }
}