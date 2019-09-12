using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PhotoStore
{
    
    public partial class SearchJobOrder : Form
    {
        List<PhotoStore.Entity.SearchJO> _searchJos;
        public SearchJobOrder()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.gvSearch.DataSource = null;
            gvSearch.AutoGenerateColumns = false;
            BindingSource bs = new BindingSource();
            _searchJos = BusinessLogic.blJobOrder.SearchOrderByCategory(Convert.ToInt32(cboSearchBy.SelectedValue),
                txtSearch.Text.Trim());
            bs.DataSource = _searchJos;
            gvSearch.DataSource = bs;
            
        }

      

        private void SearchJobOrder_Load(object sender, EventArgs e)
        {
            
            cboSearchBy.DataSource = BusinessLogic.blJobOrder.SearchTypes();
            cboSearchBy.ValueMember = "Value";
            cboSearchBy.DisplayMember = "Description";
        }

        private void cboSearchBy_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void gvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (gvSearch.Columns[e.ColumnIndex].Name == "colJobOrderNumber")
                {
                    ReleaseReport frm = new ReleaseReport(Convert.ToInt64(gvSearch.Rows[e.RowIndex].Cells["colJobOrderId"].EditedFormattedValue), true);//gvSearch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    frm.ShowDialog();
                    frm.Dispose();
                    frm = null;
                }
            }
        }

        private void btnShowTally_Click(object sender, EventArgs e)
        {
            Tally frm = new Tally();
            frm.ShowDialog();
            frm.Dispose();
            frm = null;
        }

       

        
    }
}