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
    public partial class Customer : Form
    {
        #region Declarations
        //declare an entity
        Entity.Customer _CustomerEntity;

        private bool _isLoaded = false;

        private bool _promptToSave = false;
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
        public bool isNew
        {
            get { return _CustomerId == -1; }
        }
        #endregion


        #region Methods
        /// <summary>set the button state</summary>
        /// <param name="buttonState"></param>
        public void setButtonState(string buttonState)
        {
            btnAddChild.Enabled = buttonState.Substring(0, 1) == "1";
            btnSave.Enabled = buttonState.Substring(1, 1) == "1";
            btnAddAnother.Enabled = buttonState.Substring(2, 1) == "1";
            btnSearch.Enabled = buttonState.Substring(3, 1) == "1";
            btnMainMenu.Enabled = buttonState.Substring(4, 1) == "1";
        }

        /// <summary>check for required fields</summary>
        /// <returns></returns>
        public bool checkRequiredFields()
        {

            lblCode.ForeColor = Label.DefaultForeColor;
            lblMothersName.ForeColor = Label.DefaultForeColor;
            lblFathersName.ForeColor = Label.DefaultForeColor;

            if (txtCode.Text.Trim() == "") { lblCode.ForeColor = Color.Red; _errorMessage = "Customer Id is a required field."; return false; }
            if ((txtFathersName.Text.Trim() == "") & (txtMothersName.Text.Trim() == ""))
            {
                lblFathersName.ForeColor = Color.Red;
                lblMothersName.ForeColor = Color.Red;
                _errorMessage = "At least 1 parent needs to be specified."; 
                return false;
            }
            if ((txtFathersName.Text.Trim() != "") & (txtFathersBirthDate.Text.Trim() == "")) { lblFathersBirthDate.ForeColor = Color.Red; _errorMessage = "Father's Birth Date is a required field."; return false; }
            if ((txtMothersName.Text.Trim() != "") & (txtMothersBirthDate.Text.Trim() == "")) { lblMothersBirthDate.ForeColor = Color.Red; _errorMessage = "Mother's Birth Date is a required field."; return false; }

            gvChildren.Columns["colChildsName"].HeaderCell.Style.ForeColor = DataGridView.DefaultForeColor;
            gvChildren.Columns["colBirthDate"].HeaderCell.Style.ForeColor = DataGridView.DefaultForeColor;
            foreach (DataGridViewRow row in gvChildren.Rows)
            {
                if (row.Cells["colId"].Value == null) return true;
                if ((row.Cells["colChildsName"].Value.ToString().Trim() == "")
                    | (row.Cells["colBirthDate"].Value.ToString().Trim() == ""))
                {
                    _errorMessage = "Child's Name and Birth Date are required fields.";
                    gvChildren.Columns["colChildsName"].HeaderCell.Style.ForeColor = Color.Red;
                    gvChildren.Columns["colBirthDate"].HeaderCell.Style.ForeColor = Color.Red;
                    return false;
                }
            }

            return true;
        }

        public bool checkEncodedData()
        {

            lblMothersBirthDate.ForeColor = Label.DefaultForeColor;
            lblFathersBirthDate.ForeColor = Label.DefaultForeColor;
            lblPrivilegeCardCode.ForeColor = Label.DefaultForeColor;

            DateTime dt;
            if ((txtFathersName.Text.Trim() != "") & (!DateTime.TryParse(txtFathersBirthDate.Text, out dt))) { lblFathersBirthDate.ForeColor = Color.Red; _errorMessage = "Invalid Father's birth date."; return false; }
            if ((txtMothersName.Text.Trim() != "") & (!DateTime.TryParse(txtMothersBirthDate.Text, out dt))) { lblMothersBirthDate.ForeColor = Color.Red; _errorMessage = "Invalid Mother's birth date."; return false; }

            //if (!isNew)
            //{
            //    //is the card expired
            //    if (blPrivilegeCard.isExpired(txtPrivilegeCardCode.Text))
            //    {
            //        lblPrivilegeCardCode.ForeColor = Color.Red;
            //        _errorMessage = "Privilege card is already expired.";
            //        return false;
            //    }
            //    //is the card owned by the specified customer
            //    if (blPrivilegeCard.isOwned(txtPrivilegeCardCode.Text, _CustomerEntity.Id))
            //    {
            //        lblPrivilegeCardCode.ForeColor = Color.Red;
            //        _errorMessage = "Privilege card is owned by another customer.";
            //        return false;
            //    }
            //}

            //check for duplicate child names
            //TODO:move this to bl
            gvChildren.Columns["colChildsName"].HeaderCell.Style.ForeColor = DataGridView.DefaultForeColor;
            gvChildren.Columns["colBirthDate"].HeaderCell.Style.ForeColor = DataGridView.DefaultForeColor;
            foreach (DataGridViewRow row1 in gvChildren.Rows)
            {
                if (row1.Cells["colId"].Value == null) return true;
                foreach (DataGridViewRow row2 in gvChildren.Rows)
                {
                    if (row1.Index > row2.Index)
                    {
                        if ((row1.Cells["colChildsName"].Value.ToString().Trim() == row2.Cells["colChildsName"].Value.ToString().Trim()))
                        {
                            _errorMessage = "Duplicate child names found.";
                            gvChildren.Columns["colChildsName"].HeaderCell.Style.ForeColor = Color.Red;
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        #endregion
        public Customer()
        {
            InitializeComponent();
        }

        private void CustomerProfile_Load(object sender, EventArgs e)
        {
            _isLoaded = false;
            if (isNew)
                btnAddAnother_Click(sender,e);
            else
            {
                btnSearch_Click(sender,e);
            }

            _isLoaded = true;
            if (blCustomer.PriviledgeCardExpired(txtPrivilegeCardCode.Text.Trim()))
                MessageBox.Show("Priviledge Card is expired already");
        }
                
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (_isLoaded)
                {
                    CustomerSearch frm = new CustomerSearch();
                    frm.ShowDialog();
                    _CustomerId = frm.CustomerId;
                    if (_CustomerId < 0)
                    {
                        frm.Dispose();
                        frm = null;
                        return;
                    }
                }
                //populate the entity
                //_CustomerEntity = BusinessLogic.blCustomer.retrieve(txtCode.Text);
                _CustomerEntity = BusinessLogic.blCustomer.retrieve(_CustomerId);

                //use the entity properties to populate the form
                txtCode.Text = _CustomerEntity.Code;
                txtPrivilegeCardCode.Text = _CustomerEntity.PrivilegeCardCode;
                txtCDNumbers.Text = _CustomerEntity.CDNumbers;
                txtMothersName.Text = _CustomerEntity.MothersName;
                txtMothersBirthDate.Text = _CustomerEntity.MothersBirthDate.ToString("MM/dd/yyyy");
                txtMothersLandLine.Text = _CustomerEntity.MothersLandLine;
                txtMothersCellNumber.Text = _CustomerEntity.MothersCellNumber;
                txtFathersName.Text = _CustomerEntity.FathersName;
                txtFathersBirthDate.Text = _CustomerEntity.FathersBirthDate.ToString("MM/dd/yyyy");
                txtFathersLandLine.Text = _CustomerEntity.FathersLandLine;
                txtFathersCellNumber.Text = _CustomerEntity.FathersCellNumber;
                txtAddress.Text = _CustomerEntity.Address;
                txtArea.Text = _CustomerEntity.Area;
                txtEmail.Text = _CustomerEntity.Email;

                if (_CustomerEntity.CustomerChildList.Count == 0)
                {
                    List<Entity.CustomerChild> noChild = new List<PhotoStore.Entity.CustomerChild>();
                    gvChildren.DataSource = null;
                    gvChildren.AutoGenerateColumns = false;
                    gvChildren.DataSource = noChild;
                }
                else
                {
                    gvChildren.DataSource = null;
                    gvChildren.AutoGenerateColumns = false;
                    gvChildren.DataSource = _CustomerEntity.CustomerChildList;
                }
                setButtonState("11111");
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("code not found!" + ex.Message);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region validation routines
                if (!blUtility.ValidatePreviousRows(gvChildren, "colChildsName"))
                {
                    MessageBox.Show("Child's Name should not be blank");
                    return;
                }
                //validate required data
                if (!checkRequiredFields())
                {
                    MessageBox.Show("Please fill in the required fields.\r\n"
                        + _errorMessage, "Customer");
                    return;
                }

                //validate invalid data
                if (!checkEncodedData())
                {
                    MessageBox.Show("Invalid data found.\r\n"
                        + _errorMessage,"Customer");
                    return;
                }


                #endregion
      
                //pass the form values onto the entity
                _CustomerEntity.Code = txtCode.Text;
                _CustomerEntity.PrivilegeCardCode = txtPrivilegeCardCode.Text;
                _CustomerEntity.CDNumbers = txtCDNumbers.Text;
                _CustomerEntity.FathersName = txtFathersName.Text;
                DateTime dt;
                if (!DateTime.TryParse(txtFathersBirthDate.Text, out dt))
                    _CustomerEntity.FathersBirthDate = Convert.ToDateTime("01/01/1900");
                else
                    _CustomerEntity.FathersBirthDate = Convert.ToDateTime(txtFathersBirthDate.Text);
                _CustomerEntity.FathersLandLine = txtFathersLandLine.Text;
                _CustomerEntity.FathersCellNumber = txtFathersCellNumber.Text;

                _CustomerEntity.MothersName = txtMothersName.Text;
                if (!DateTime.TryParse(txtMothersBirthDate.Text, out dt))
                    _CustomerEntity.MothersBirthDate = Convert.ToDateTime("01/01/1900");
                else
                    _CustomerEntity.MothersBirthDate = Convert.ToDateTime(txtMothersBirthDate.Text);
                _CustomerEntity.MothersLandLine = txtMothersLandLine.Text;
                _CustomerEntity.MothersCellNumber = txtMothersCellNumber.Text;
                _CustomerEntity.Address = txtAddress.Text;
                _CustomerEntity.Area = txtArea.Text;
                _CustomerEntity.Email = txtEmail.Text;

                if (_CustomerEntity.Id == -1)
                    _CustomerEntity = blCustomer.create(_CustomerEntity);
                else
                    _CustomerEntity = blCustomer.update(_CustomerEntity);

                _CustomerId = _CustomerEntity.Id;

                _promptToSave = false;
                MessageBox.Show("save successful!", "Customer");
                setButtonState("11111");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddAnother_Click(object sender, EventArgs e)
        {
            _CustomerEntity = new PhotoStore.Entity.Customer();

            //initialize the controls
            _CustomerId = -1;
            txtCode.Text = BusinessLogic.blCustomer.retrieveNextCode();
            txtPrivilegeCardCode.Text = "";
            txtCDNumbers.Text = "";
            txtMothersName.Text = "";
            txtMothersBirthDate.Text = "01/01/1900";
            txtMothersLandLine.Text = "";
            txtMothersCellNumber.Text = "";
            txtFathersName.Text = "";
            txtFathersBirthDate.Text = "01/01/1900";
            txtFathersLandLine.Text = "";
            txtFathersCellNumber.Text = "";
            txtAddress.Text = "";
            txtArea.Text = "";
            txtEmail.Text = "";

            List<Entity.CustomerChild> noChild = new List<PhotoStore.Entity.CustomerChild>();
            gvChildren.DataSource = null;
            gvChildren.AutoGenerateColumns = false;

            //this will prevent the "Index -1 does not have a value" message
            BindingSource bs = new BindingSource();
            bs.DataSource = noChild;
            bs.ResetBindings(false);
            gvChildren.DataSource = bs;

            _CustomerEntity.CustomerChildList = noChild;

            setButtonState("11111");//add mode

        }

        private void btnAddChild_Click(object sender, EventArgs e)
        {
            if (!blUtility.ValidatePreviousRows(gvChildren, "colChildsName"))
            {
                MessageBox.Show("Child's Name should not be blank");
                return;
            }
            if (_CustomerEntity.CustomerChildList == null)
                _CustomerEntity.CustomerChildList = new List<PhotoStore.Entity.CustomerChild>();
            Entity.CustomerChild child = new Entity.CustomerChild();
            child.CustomerId = _CustomerEntity.Id;
            child.Name = "";
            child.Id = -1;
            _CustomerEntity.CustomerChildList.Add(child);

            gvChildren.DataSource = null;
            gvChildren.AutoGenerateColumns = false;

            //this will prevent the "Index -1 does not have a value" message
            BindingSource bs = new BindingSource();
            bs.DataSource = _CustomerEntity.CustomerChildList;
            bs.ResetBindings(false);
            gvChildren.DataSource = bs;

        }

        private void gvChildren_KeyDown(object sender, KeyEventArgs e)
        {
            if (gvChildren.Rows.Count == 0) return;

            if (e.KeyCode == Keys.Delete)
            {
                _CustomerEntity.CustomerChildList.Remove((Entity.CustomerChild)gvChildren.CurrentRow.DataBoundItem);
                gvChildren.DataSource = null;
                gvChildren.AutoGenerateColumns = false;

                //this will prevent the "Index -1 does not have a value" message
                BindingSource bs = new BindingSource();
                bs.DataSource = _CustomerEntity.CustomerChildList;
                bs.ResetBindings(false);
                gvChildren.DataSource = bs;
                

            }

        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvChildren_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == gvChildren.Columns["colBirthDate"].Index)
            {
                MessageBox.Show("Invalid Birth Date.  Press [Esc] to revert.");
            }
        }


        List<Entity.CustomerOrderTransaction> _CuOrTr;
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Retrieve associated order transaction to the customer 
            if (tabControl1.SelectedIndex == 1)
            {
                //if (_CuOrTr == null)
                //{
                    _CuOrTr = blCustomer.retrieveOrderByCustomerId(_CustomerId);
                    gvTransaction.AutoGenerateColumns = false;
                    BindingSource bs = new BindingSource();
                    gvTransaction.DataSource = bs;
                    bs.DataSource = _CuOrTr;
                    bs.ResetBindings(false);
                   
                    gvTransaction.DataSource = bs;
                //}
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            VerifyPassword verifyPassword = new VerifyPassword("CustomerDelete",_CustomerEntity);
            verifyPassword.ShowDialog();
            bool isCanceled = verifyPassword.Canceled;
            verifyPassword.Dispose();
            verifyPassword = null;
            if (!isCanceled)
            {
                this.Close();
            }
              
        }

        private void btnPrivilegeCard_Click(object sender, EventArgs e)
        {
            if (isNew)
            {
                MessageBox.Show("Customer Id is needed before adding a privilege card.\nSave this entry first before adding a privilege card.",this.Text);
                return;
            }
            PrivilegeCard frm = new PrivilegeCard();
            frm.CustomerId = _CustomerEntity.Id;
            frm.ShowDialog();
            frm.Dispose();
            frm = null;

            List<Entity.PrivilegeCard> activeCards = blPrivilegeCard.retrieveActiveByCustomerId(_CustomerEntity.Id);
            if (activeCards.Count > 0)
                txtPrivilegeCardCode.Text = activeCards[0].Code;
            else
                txtPrivilegeCardCode.Text = "";

            _promptToSave = true;

        }

        private void Customer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_promptToSave)
            {
                if (MessageBox.Show("Data was changed since you last saved.\nDo you want to save before you exit?", this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnSave_Click(sender, e);
                    e.Cancel=true;
                }
            }
        }

        private void gvChildren_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            btnAddChild.Enabled = true;
            btnSave.Enabled = true;
            if (gvChildren.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                if (string.IsNullOrEmpty(gvChildren.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                {
                    MessageBox.Show("Children's name should not be blank");
                    btnAddChild.Enabled = false;
                    btnSave.Enabled = false;

                }
            }
            else
            {
                MessageBox.Show("Children's name should not be blank");
                btnAddChild.Enabled = false;
                btnSave.Enabled = false;
            }
           
        }

        private void gvTransaction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                long id = Convert.ToInt64(gvTransaction.Rows[e.RowIndex].Cells["colOrderTransactionId"].Value);
                
              

                Transaction frm = new Transaction();
                //frm.ModifiedByEmployeeEntity = _EmployeeEntity;
                frm.OrderTransactionId = id;
                frm.ShowDialog();
                frm.Dispose();
                frm = null;

             
            }
        }
        bool _isFromDeletingProcess = false;
        private void btnDeleteChild_Click(object sender, EventArgs e)
        {
            _isFromDeletingProcess = true;
            if (!indexCheck.ContainsValue(true))
            {
                MessageBox.Show("Please select a row");
                return;
            }
            List<long> ids = new List<long>();
            foreach (int key in indexCheck.Keys)
            {
                if (indexCheck[key])
                {
                    int? indexFound=null;
                    for (int i=0; i < gvChildren.Rows.Count; i++)
                    {
                        long id = (long)gvChildren.Rows[i].Cells["colId"].Value;
                        if ((int)gvChildren.Rows[i].Cells["colSequence"].Value == key)
                        {
                            
                            if (id != -1)
                            {
                                ids.Add(id);
                            }
                            else
                                indexFound = i;
                            break;
                        }
                    }
                    if (indexFound.HasValue)
                    {
                        if ((long)gvChildren.Rows[indexFound.Value].Cells["colId"].Value == -1)
                        {
                            gvChildren.Rows.RemoveAt(indexFound.Value);
                        }
                    }
                }
            }
            if (ids.Count > 0)
            {
                foreach (long id in ids)
                {
                    int? indexFound = null;
                    for (int i = 0; i < _CustomerEntity.CustomerChildList.Count; i++)
                    {
                        if (_CustomerEntity.CustomerChildList[i].Id.Equals(id))
                        {
                            indexFound = i;
                            break;
                        }
                    }

                    if (indexFound.HasValue)
                    {
                        _CustomerEntity.CustomerChildList.RemoveAt(indexFound.Value);
                    }
                }
            }

            indexCheck.Clear();
            _isFromDeletingProcess = false;

            gvChildren.DataSource = null;
            gvChildren.AutoGenerateColumns = false;
            gvChildren.DataSource = _CustomerEntity.CustomerChildList;
        }
        Dictionary<int, bool> indexCheck = new Dictionary<int, bool>();
        private void gvChildren_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                bool isSelected = (bool)gvChildren.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue;
                int sequence = (int)gvChildren.Rows[e.RowIndex].Cells["colSequence"].Value;
                    if (indexCheck.ContainsKey(sequence))
                    {
                        indexCheck[sequence] = isSelected;
                    }
                    else
                    {
                        indexCheck.Add(sequence, isSelected);
                    }
               
            }
        }

        private void gvChildren_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (!_isFromDeletingProcess)
            {
                indexCheck.Clear();
                for (int i = 0; i < gvChildren.Rows.Count; i++)
                {
                    gvChildren.Rows[i].Cells["colSequence"].Value = i + 1;
                }
            }
        }



    }
}