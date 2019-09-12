using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PhotoStore
{
    public partial class AdminUser : Form
    {
        #region Declarations
        //declare an entity
        List<Entity.Employee> _EmployeeList = new List<PhotoStore.Entity.Employee>();

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

            return true;
        }


        public bool checkEncodedData()
        {

            gvDataEntry.Columns["colUserName"].HeaderCell.Style.ForeColor = DataGridView.DefaultForeColor;
            foreach (DataGridViewRow row1 in gvDataEntry.Rows)
            {
                if (row1.Cells["colId"].Value == null) return true;
                foreach (DataGridViewRow row2 in gvDataEntry.Rows)
                {
                    if (row1.Index > row2.Index)
                    {
                        //check for duplicates
                        if ((row1.Cells["colUserName"].Value.ToString().Trim() == row2.Cells["colUserName"].Value.ToString().Trim()))
                        {
                            _errorMessage = "Duplicate " + gvDataEntry.Columns["colUserName"].HeaderText + " found.";
                            gvDataEntry.Columns["colUserName"].HeaderCell.Style.ForeColor = Color.Red;
                            gvDataEntry.Focus();
                            row1.Cells["colUserName"].Selected = true;
                            return false;
                        }

                    }
                }
            }

            return true;
        }
        #endregion

        public AdminUser()
        {
            InitializeComponent();
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            BindEmployeeGroup();

        }
        private void BindEmployeeGroup()
        {
            cboGroupDescription.DisplayMember = "Description";
            cboGroupDescription.ValueMember = "Id";
            cboGroupDescription.DataSource = UI.BindSource(BusinessLogic.blEmployeeGroup.retrieveForComboBox(false), false);
        }
        private void BindDataGridViewComboBox(DataGridViewComboBoxColumn col, object dataSource, string dataPropertyName, string displayMember, string valueMember, Type valueType)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;
            bs.ResetBindings(false);

            col.DataSource = bs;
            col.DataPropertyName = dataPropertyName;
            col.DisplayMember = displayMember;
            col.ValueMember = valueMember;
            col.ValueType = valueType;
        }

        private void LoadEmployees()
        {

            _EmployeeList = BusinessLogic.blEmployee.retrieve();

            gvDataEntry.DataSource = null;
            gvDataEntry.AutoGenerateColumns = false;

            //this will prevent the "Index -1 does not have a value" message
            BindingSource bs = new BindingSource();
            bs.DataSource = _EmployeeList;
            bs.ResetBindings(false);
            gvDataEntry.DataSource = bs;

            //BindDataGridViewComboBox((DataGridViewComboBoxColumn)gvDataEntry.Columns["colEmployeeGroup"]
            //            , BusinessLogic.blEmployeeGroup.retrieveForComboBox(), "EmployeeGroupId", "Description", "Id", typeof(int));

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region validation routines
            //validate required data
            //if (!checkRequiredFields())
            //{
            //    MessageBox.Show("Please fill in the required fields.\r\n"
            //        + _errorMessage);
            //    return;
            //}

            ////validate invalid data
            //if (!checkEncodedData())
            //{
            //    MessageBox.Show("Invalid data found.\r\n"
            //        + _errorMessage);
            //    return;
            //}


            #endregion
            Entity.Employee emp = new PhotoStore.Entity.Employee();
            emp.Id = (_employeeId.HasValue) ? _employeeId.Value : -1;
            emp.FullName = txtFullName.Text.Trim();
            emp.Password = txtPassword.Text.Trim();
            emp.UserName = txtUserName.Text.Trim();
            emp.EmployeeGroupId = Convert.ToInt32(
                cboGroupDescription.SelectedValue);

           BusinessLogic.blEmployee.SaveEmployee(emp);
            MessageBox.Show("Save Succeeded!");
            emp=null;
            _employeeId = null;
            LoadEmployees();
            ResetControls();
            
        }
        private void ResetControls()
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtFullName.Clear();
            cboGroupDescription.SelectedIndex = 0;
            txtUserName.Focus();
            btnDelete.Enabled = false;
        }
        private void gvDataEntry_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //use this link for sorting http://dotnetslackers.com/Community/blogs/simoneb/archive/2007/06/20/How-to-sort-a-generic-List_3C00_T_3E00_.aspx
            //gvEmployee.Sort(gvEmployee.Columns[e.ColumnIndex], ListSortDirection.Ascending);

        }

        private void gvDataEntry_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }
        long? _employeeId = null;
        private void PopulateDataToControl(DataGridViewRow row)
        {
            _employeeId = Convert.ToInt64(row.Cells["colId"].Value);
            txtUserName.Text = row.Cells["colUserName"].Value.ToString();
            txtPassword.Text = row.Cells["colPassword"].Value.ToString();
            txtFullName.Text = row.Cells["colFullName"].Value.ToString();

            for (int i = 0; i < cboGroupDescription.Items.Count; i++)
            {
                Entity.EmployeeGroup employeeGroup = (Entity.EmployeeGroup)cboGroupDescription.Items[i];
                if (employeeGroup.Id.Equals(Convert.ToInt64(row.Cells["colEmployeeGroup"].Value)))
                {
                    cboGroupDescription.SelectedIndex = i;
                    break;
                }
                employeeGroup = null;
            }
            btnDelete.Enabled = true;
        }
        private void gvDataEntry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                //if (gvDataEntry.Columns[e.ColumnIndex].Name=="colGroupDescription")
                //{
                //    if(!((!string.IsNullOrEmpty(gvDataEntry.Rows[e.RowIndex].Cells["colUserName"].Value.ToString()))
                //                    && (!string.IsNullOrEmpty(gvDataEntry.Rows[e.RowIndex].Cells["colPassword"].Value.ToString()))
                //                    && (!string.IsNullOrEmpty(gvDataEntry.Rows[e.RowIndex].Cells["colFullName"].Value.ToString()))))
                //    {
                //        MessageBox.Show("Please Fill up first the other column before selecting an employee Group");
                //        return;
                //    }

                //    long userGroupId = Convert.ToInt64(gvDataEntry.Rows[e.RowIndex].Cells["colEmployeeGroup"].Value);
                //    LookUp lookUp = new LookUp(userGroupId, "User");
                //    lookUp.ShowDialog();
                //    lookUp.Dispose();
                //    if (lookUp.Id != -1)
                //    {
                //        gvDataEntry.Rows[e.RowIndex].Cells["colGroupDescription"].Value = lookUp.Code;
                //        gvDataEntry.Rows[e.RowIndex].Cells["colEmployeeGroup"].Value = lookUp.Id;
                //    }
                //    btnSave.Enabled = true;//(!string.IsNullOrEmpty(gvDataEntry.Rows[e.RowIndex].Cells["colUserName"].Value.ToString()))
                //    //                && (!string.IsNullOrEmpty(gvDataEntry.Rows[e.RowIndex].Cells["colPassword"].Value.ToString()))
                //    //                && (!string.IsNullOrEmpty(gvDataEntry.Rows[e.RowIndex].Cells["colFullName"].Value.ToString()))
                //    //                && (gvDataEntry.Rows[e.RowIndex].Cells["colEmployeeGroup"].Value.ToString() != "-1");
                
                   
                //}
                if (gvDataEntry.Columns[e.ColumnIndex].Name == "colUserName")
                {
                    PopulateDataToControl(gvDataEntry.Rows[e.RowIndex]);
                }
            }
        }

        private void gvDataEntry_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (gvDataEntry.Rows[e.RowIndex].Cells["colId"].Value != null)
            {
              
                if (gvDataEntry.Rows[e.RowIndex].Cells["colId"].Value.ToString() != "-1")
                {
                    btnSave.Enabled = true;
                  
                }
                else
                    btnSave.Enabled = false;
            }
            
        }

        private void gvDataEntry_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row=gvDataEntry.Rows[e.RowIndex];
            if (row.Cells["colId"].Value != null)
            {
                //if (row.Cells["colId"].Value.ToString() == "-1")
                //{
                    btnSave.Enabled = (!string.IsNullOrEmpty(row.Cells["colUserName"].Value.ToString()))
                                    && (!string.IsNullOrEmpty(row.Cells["colPassword"].Value.ToString()))
                                    && (!string.IsNullOrEmpty(row.Cells["colFullName"].Value.ToString()))
                                    && (row.Cells["colEmployeeGroup"].Value.ToString() != "-1");
               // }
            }
            row=null;
        }
        private void TextChanged(object sender, EventArgs e, TextBox txt)
        {
            btnSave.Enabled = (txtUserName.Text.Trim().Length > 0) &&
                (txtFullName.Text.Trim().Length > 0) && (txtPassword.Text.Trim().Length > 0);
        }
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            TextChanged(sender, e, txtUserName);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            TextChanged(sender, e, txtPassword);
        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {
            TextChanged(sender, e, txtFullName);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BusinessLogic.blEmployee.delete(_employeeId.Value);
            ResetControls();
            LoadEmployees();
            _employeeId = null;
        }
    }
}