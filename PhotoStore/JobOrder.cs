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
    public enum TransactionMode { Save, Done }
    public partial class JobOrderMain : Form
    {
        List<PhotoStore.Entity.CreateJO> _createJos;
        List<PhotoStore.Entity.JobOrderByType> _jobOrderTypes;
        List<vwJobOrderItems> _jobOrderGrids;
        string _columnSort = "Code";
        Direction _direction = Direction.ASC;
        Dictionary<int, bool> _selectedDictionary;
        List<long> _previousSelectedId;
        public JobOrderMain()
        {
            InitializeComponent();
        }

        private void btnShowTally_Click(object sender, EventArgs e)
        {
            Tally frm = new Tally();
            frm.ShowDialog();
            frm.Dispose();
            frm = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            SaveOrDone(TransactionMode.Save);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            DialogResult diagResult = MessageBox.Show(
                "Are you sure you're done with the transaction?",
                "Confirmation"
                 , MessageBoxButtons.YesNo
                , MessageBoxIcon.Question);


            if(diagResult== DialogResult.Yes)
                SaveOrDone(TransactionMode.Done);
        }
      
        JobOrder _jobOrder;
       
      

        private bool CheckIfItemHadBeenSelected()
        {
            bool retValue = false;
            foreach (DataGridViewRow row in gvDataEntry.Rows)
            {
                DataGridViewCheckBoxCell chkCell = (DataGridViewCheckBoxCell)row.Cells["colchkbox"];
          

               
                if ((bool)chkCell.EditedFormattedValue)
                {
                    retValue = true;
                    break;
                }

                chkCell.Dispose();
                chkCell = null;
            }
            return retValue;
        }

        private bool ValidEntry()
        {
            bool retValue = true;
            foreach (int idx in _selectedDictionary.Keys)
            {
                DataGridViewRow row = gvDataEntry.Rows[idx];
                if (_selectedDictionary[idx])
                {



                    bool validItem = true;
                    bool validSupplier = true;
                    int quantity;
                    #region Check if the remaining quantity is valid
                    if (int.TryParse(row.Cells["colQuantity"].EditedFormattedValue.ToString(), out quantity))
                    {
                        if (quantity > 0)
                        {
                            //int availableQuantity = Convert.ToInt32(row.Cells["colMaxQuantity"].Value) -
                            //                        quantity;

                            //if (availableQuantity < 0)
                            //{
                            if (quantity > Convert.ToInt32(row.Cells["colMaxQuantity"].Value))
                            {

                                retValue = false;
                                validItem = false;
                                DataGridViewCellStyle gridStyle = new DataGridViewCellStyle();
                                gridStyle.BackColor = Color.Aqua;
                                row.Cells["colQuantity"].Style = gridStyle;
                                gridStyle = null;
                            }

                            //}
                        }
                        else
                        {
                            retValue = false;
                            validItem = false;
                            DataGridViewCellStyle gridStyle = new DataGridViewCellStyle();
                            gridStyle.BackColor = Color.Aqua;
                            row.Cells["colQuantity"].Style = gridStyle;
                            gridStyle = null;
                        }
                    }
                    else
                    {
                        validItem = false;
                        retValue = false;
                        DataGridViewCellStyle gridStyle = new DataGridViewCellStyle();
                        gridStyle.BackColor = Color.Aqua;
                        row.Cells["colQuantity"].Style = gridStyle;
                        gridStyle = null;
                    }
                    #endregion

                    #region Check if Supplier is selected
                    long supplierId = Convert.ToInt64(row.Cells["colSupplierId"].EditedFormattedValue);//dgvComboCell.Value);                  
                    if (supplierId == -1)
                    {
                        validSupplier = false;
                        retValue = false;
                        DataGridViewCellStyle gridStyle = new DataGridViewCellStyle();
                        gridStyle.BackColor = Color.Aqua;
                        row.Cells["colSupplierCode"].Style = gridStyle;
                        gridStyle = null;

                    }
                    #endregion
                    if (validItem)
                    {
                        row.Cells["colQuantity"].Style.BackColor = Color.White;

                    }
                    if (validSupplier)
                    {
                        row.Cells["colSupplierCode"].Style.BackColor = Color.White;
                    }





                }
                else
                {
                    row.Cells["colQuantity"].Style.BackColor = Color.White;
                    row.Cells["colSupplierCode"].Style.BackColor = Color.White;
                }
            }
            
            return retValue;
        }

        private void SaveOrDone(TransactionMode transactionMode)
        {
            //if (!CheckIfItemHadBeenSelected())
            //{
            //    MessageBox.Show("No Job order record is selected!",
            //        "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}


            if (_selectedDictionary==null|| !_selectedDictionary.ContainsValue(true))
            {
                MessageBox.Show("Please Select atleast one item to save");
                return;
            }
            if (!ValidEntry())
            {
                MessageBox.Show("Some Item(s) had failed to save due to some invalid input(s)");
                return;
            }
            if (_jobOrder.Id == -1)
            {
                _jobOrder.Code = txtJONumber.Text.Trim();
                _jobOrder.TransactionDate = Convert.ToDateTime(string.Format("{0} 12:00:00 AM", txtDate.Text.Trim()));

            }
         
           _jobOrder = blJobOrder.SaveParentJobOrder(_jobOrder);
            foreach (int idx in _selectedDictionary.Keys)
            {
                using (DataGridViewRow row = gvDataEntry.Rows[idx])
                {
                    if (_selectedDictionary[idx])
                    {

                        blJobOrder.SaveJobOrderDetails(
                        Convert.ToInt64(row.Cells["colId"].Value),
                        row.Cells["colSupplierCode"].Value.ToString(),
                        Convert.ToInt32(row.Cells["colQuantity"].Value),
                        _jobOrder.Id, (transactionMode == TransactionMode.Done) ? Convert.ToByte(1) :
                        Convert.ToByte(0),
                        true);

                    }
                    else
                    {
                        if (_previousSelectedId.Contains(Convert.ToInt64(row.Cells["colId"].Value)))
                        {
                            blJobOrder.SaveJobOrderDetails(
                            Convert.ToInt64(row.Cells["colId"].Value),
                            row.Cells["colSupplierCode"].Value.ToString(),
                            Convert.ToInt32(row.Cells["colQuantity"].Value),
                            _jobOrder.Id, (transactionMode == TransactionMode.Done) ? Convert.ToByte(1) :
                            Convert.ToByte(0),
                            false);
                        }
                    }
                }
            }
            
            string statusMessage;
            statusMessage=(transactionMode == TransactionMode.Done) ?
                "Selected Items had been tagged as printed":
                "";
            if(!string.IsNullOrEmpty(statusMessage))
            MessageBox.Show(statusMessage);

            SetJobOrderItem();
            GetJobOrderNumber();
            
           
        }
        private void ReleaseReport(long id, bool isauto)
        {
            ReleaseReport frm = new ReleaseReport(id, isauto);
            frm.ShowDialog();
            frm.Dispose();
            frm = null;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            ReleaseReport(-1, false);
        }
        //bool _existingJO = false;
        //List<int> _initialQuantity;
        private void GetJobOrderNumber()
        {
            if (string.IsNullOrEmpty(_jobOrder.Code))
            {
                txtJONumber.Text = blJobOrder.retrieveNextCode();
                txtDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                _jobOrder.Code = txtJONumber.Text.Trim();
                _jobOrder.TransactionDate = Convert.ToDateTime(txtDate.Text.Trim());
            }
            else
            {
                txtJONumber.Text = _jobOrder.Code;
                txtDate.Text = _jobOrder.DateLastModified.ToString("MM/dd/yyyy");//DateTime.Now.ToString("MM/dd/yyyy");

            }
        }
        private void SetJobOrderItem()
        {
            JobOrder jobOrder = new JobOrder();            
            _jobOrderGrids = blJobOrder.GetJobOrderItems(_columnSort, _direction,
                dtpFrom.Value,dtpTo.Value,txtOrderNumber.Text.Trim(),txtCustomerName.Text.Trim());
            jobOrder=blJobOrder.GetUnsavedJobOrder();
            _jobOrder = jobOrder;                           
            BindGrid();
        }

        private void JobOrderMain_Load(object sender, EventArgs e)
        {

           this.SetJobOrderItem();
           GetJobOrderNumber();

          
        }
      //  bool _isFromBindingGrid = false;
        private void BindGrid()
        {
            gvDataEntry.DataSource = null;
            gvDataEntry.AutoGenerateColumns = false;
            BindingSource bs = new BindingSource();
            bs.DataSource = _jobOrderGrids; //_createJos;
            bs.ResetBindings(false);
            gvDataEntry.DataSource = bs;

            if (_selectedDictionary != null)
                _selectedDictionary.Clear();

            if (_previousSelectedId != null)
                _previousSelectedId.Clear();

            _selectedDictionary = blUtility.SelectedItems(gvDataEntry, "colchkbox");
            _previousSelectedId = blUtility.PreviousSelectedIds<long>(_selectedDictionary,gvDataEntry,"colId");
        }
     
            
        private void gvDataEntry_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
           // e.Cancel = true;
            Exception ex = e.Exception;

            if (ex.GetType() == typeof(System.ArgumentException)
                || ex.GetType() == typeof(System.FormatException))
            {
                MessageBox.Show("Input should be in numbers!", "Invalid Input", MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
            }
            else
            {
                e.ThrowException = true;
            }
          
        }

        private void cboSaveOrDone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
        }

        private void gvDataEntry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                switch (e.ColumnIndex)
                {
                    //case 8:
                    //    long supplierId = Convert.ToInt64(gvDataEntry.Rows[e.RowIndex].Cells["colSupplierId"].EditedFormattedValue);
                    //    LookUp lookupSuppler = new LookUp(supplierId, "Supplier");
                    //    lookupSuppler.ShowDialog();
                    //    if (lookupSuppler.Id > -1)
                    //    {
                    //        gvDataEntry.Rows[e.RowIndex].Cells["colSupplierCode"].Value = lookupSuppler.Code;
                    //        gvDataEntry.Rows[e.RowIndex].Cells["colSupplierId"].Value = lookupSuppler.Id;
                    //    }
                    //    lookupSuppler.Dispose();
                    //    lookupSuppler = null;
                    //    break;
                    case 0:
                        blUtility.ManipulateDictionary<int, bool>(_selectedDictionary,
                            e.RowIndex
                             , Convert.ToBoolean(gvDataEntry.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue));
                        break;
                }

             
            }
        }

        private void gvDataEntry_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DialogResult diag = MessageBox.Show(
                "Sorting the data will remove any checkbox(es) set to true\r\nWould you like to proceed?",
                "Confirmation Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (diag == DialogResult.Yes)
            {
                _selectedDictionary.Clear();
                if (_columnSort == gvDataEntry.Columns[e.ColumnIndex].DataPropertyName)
                {
                    _direction = (_direction == Direction.ASC) ? Direction.DESC : Direction.ASC;
                }
                else
                {
                    _direction = Direction.ASC;
                }
                _columnSort = gvDataEntry.Columns[e.ColumnIndex].DataPropertyName;
                this.SetJobOrderItem();
            }

        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            dtpTo.MinDate = dtpFrom.Value;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dtpFrom.Value.ToShortDateString()) > dtpTo.Value)
            {
                MessageBox.Show("Date Created From should be earlier or equal to Date Created To");
                return;
            }
            this.SetJobOrderItem();
            lnkSupplier.Enabled = gvDataEntry.RowCount > 0 ? true : false;
        }

        private void lnkMissingItems_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MissingJobOrder frm = new MissingJobOrder();
            if(frm.ShowDialog()==DialogResult.OK)
            {
                btnSearch_Click(null, null);
            }

            frm.Dispose();
            frm = null;
        }

        private void lnkSupplier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool hasSelected = false;
            for (int i = 0; i < gvDataEntry.Rows.Count; i++)
            {
                if (gvDataEntry.Rows[i].Cells[8].Selected)
                {
                    hasSelected = true;
                    break;
                }
            }

            if (!hasSelected)
            {
                MessageBox.Show("Please select or highlight the items inside the supplier column \r\nto select a supplier");
                return;
            }

            long supplierId = -1;
            LookUp lookupSuppler = new LookUp(supplierId, "Supplier");
            lookupSuppler.ShowDialog();
            if (lookupSuppler.Id > -1)
            {
                for (int i = 0; i < gvDataEntry.Rows.Count; i++)
                {
                    if (gvDataEntry.Rows[i].Cells[8].Selected)
                    {
                        gvDataEntry.Rows[i].Cells["colSupplierId"].Value = lookupSuppler.Id;
                        gvDataEntry.Rows[i].Cells["colSupplierCode"].Value = lookupSuppler.Code;
                    }
                }
            }
            lookupSuppler.Dispose();
            lookupSuppler = null;
        }

       
        

       
      

        
    }
}