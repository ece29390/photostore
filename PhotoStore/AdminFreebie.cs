using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PhotoStore
{
    public partial class AdminFreebie : Form
    {
        #region Declarations
        //declare an entity
        List<Entity.Freebie> _FreebieList = new List<PhotoStore.Entity.Freebie>();

        private string _errorMessage = "";
        #endregion

        #region Methods
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
                //look for null columns and empty data
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                    {
                        _errorMessage = gvDataEntry.Columns[cell.ColumnIndex].HeaderText + " is a required field.";
                        gvDataEntry.Columns[cell.ColumnIndex].HeaderCell.Style.ForeColor = Color.Red;
                        //gvFreebie.Rows[cell.RowIndex].Selected = true;
                        gvDataEntry.Focus();
                        cell.Selected = true;
                        return false;
                    }

                    if (cell.Value.ToString().Trim() == "")
                    {
                        _errorMessage = gvDataEntry.Columns[cell.ColumnIndex].HeaderText + " is a required field.";
                        gvDataEntry.Columns[cell.ColumnIndex].HeaderCell.Style.ForeColor = Color.Red;
                        //gvFreebie.Rows[cell.RowIndex].Selected = true;
                        gvDataEntry.Focus();
                        cell.Selected = true;
                        return false;
                    }
                }


            }

            return true;
        }


        public bool checkEncodedData()
        {

            gvDataEntry.Columns["colCode"].HeaderCell.Style.ForeColor = DataGridView.DefaultForeColor;
            foreach (DataGridViewRow row1 in gvDataEntry.Rows)
            {
                if (row1.Cells["colId"].Value == null) return true;
                foreach (DataGridViewRow row2 in gvDataEntry.Rows)
                {
                    if (row1.Index > row2.Index)
                    {
                        //check for duplicates
                        if ((row1.Cells["colCode"].Value.ToString().Trim() == row2.Cells["colCode"].Value.ToString().Trim()))
                        {
                            _errorMessage = "Duplicate " + gvDataEntry.Columns["colCode"].HeaderText + " found.";
                            gvDataEntry.Columns["colCode"].HeaderCell.Style.ForeColor = Color.Red;
                            gvDataEntry.Focus();
                            row1.Cells["colCode"].Selected = true;
                            return false;
                        }

                    }
                }
            }

            return true;
        }
        #endregion

        public AdminFreebie()
        {
            InitializeComponent();
        }

        private void FreebieManagement_Load(object sender, EventArgs e)
        {
            LoadFreebies();
        }

        private void LoadFreebies()
        {

            _FreebieList = BusinessLogic.blFreebie.retrieve();

            gvDataEntry.DataSource = null;
            gvDataEntry.AutoGenerateColumns = false;

            //this will prevent the "Index -1 does not have a value" message
            BindingSource bs = new BindingSource();
            bs.DataSource = _FreebieList;
            bs.ResetBindings(false);


            gvDataEntry.DataSource = bs;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region validation routines
            //validate required data
            if (!checkRequiredFields())
            {
                MessageBox.Show("Please fill in the required fields.\r\n"
                    + _errorMessage);
                return;
            }

            //validate invalid data
            if (!checkEncodedData())
            {
                MessageBox.Show("Invalid data found.\r\n"
                    + _errorMessage);
                return;
            }
            #endregion

            _FreebieList = BusinessLogic.blFreebie.updateList(_FreebieList);
            MessageBox.Show("Save Succeeded!");
        }


    }
}