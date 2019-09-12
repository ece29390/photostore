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
    public partial class Tally : Form
    {
        //public Tally()
        //{
        //    InitializeComponent();
        //}
        PhotoStore.BusinessLogic.blJobOrder _blJobOrder;
        string _JobOrderNumber;
        string _columnSort = "SupplierCode";
        Direction _direction = Direction.ASC;
        public Tally()
        {
           
            _blJobOrder = new PhotoStore.BusinessLogic.blJobOrder();
            InitializeComponent();
        }
        List<PhotoStore.Entity.ActualJO> _actualJOS;
        private void Tally_Load(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = blJobOrder.retrieve();
            bs.ResetBindings(false);

            cboJobOrder.DisplayMember = "Code";
            cboJobOrder.ValueMember = "Id";
            cboJobOrder.DataSource = bs;
            
        }
        
        private void btnShowTally_Click(object sender, EventArgs e)
        {
            BindShowTally();          
        }
        private void BindShowTally()
        {
            dgShowTally.DataSource = null;
            dgShowTally.AutoGenerateColumns = false;
            long id = Convert.ToInt64(cboJobOrder.SelectedValue);
            BindingSource bs = new BindingSource();
            bs.DataSource = blJobOrder.GetTallyRecords(id, _columnSort, _direction);
            bs.ResetBindings(false);
            dgShowTally.DataSource = bs;
        }
        private void cboJobOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
        }

        private void dgShowTally_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_columnSort == dgShowTally.Columns[e.ColumnIndex].DataPropertyName)
            {
                _direction = (_direction == Direction.ASC) ? Direction.DESC : Direction.ASC;
            }
            else
            {
                _direction = Direction.ASC;
            }
            _columnSort = dgShowTally.Columns[e.ColumnIndex].DataPropertyName;
            BindShowTally();
        }


    }
}