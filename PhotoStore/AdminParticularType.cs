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
    public partial class AdminParticularType : Form
    {
        public AdminParticularType()
        {
            InitializeComponent();
        }
        private void BindData(List<ParticularTypeView> particularTypeViews)
        {
            gvParticularType.AutoGenerateColumns = false;
            gvParticularType.DataSource = null;
            BindingSource bs = UI.BindSource(
                particularTypeViews, false);
            gvParticularType.DataSource = bs;
           
        }
        private void AdminParticularType_Load(object sender, EventArgs e)
        {
            BindData(blParticularType.retrieveView());
        }
        ParticularType _particularType = new ParticularType();
        private void gvParticularType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string colName = gvParticularType.Columns[e.ColumnIndex].Name;
                if (colName == "colCode")
                {
                    txtCode.Enabled = false;
                    DataGridViewRow row=gvParticularType.Rows[e.RowIndex];
                    _particularType.Id = Convert.ToInt64(row.Cells["colId"].Value);
                    _particularType.Code = row.Cells["colCode"].Value.ToString();
                    _particularType.Description = row.Cells["colDescription"].Value.ToString();
                    _particularType.MultipleItems = (row.Cells["colMultipleItem"].Value.ToString().ToUpper() == "TRUE") ? true : false;
                    _particularType.IsParent = Convert.ToBoolean(row.Cells["colParent"].Value);
                    _particularType.IsPrintable = Convert.ToBoolean(row.Cells["colIsPrintable"].Value);
                    btnDelete.Enabled = true;
                    PopulateData();
                   
                }
            }
        }
        private void SendData()
        {
            _particularType.Id = Convert.ToInt64(lblId.Text.Trim());
            _particularType.Code = txtCode.Text.Trim();
            _particularType.Description = txtDescription.Text.Trim();
            _particularType.MultipleItems = chkMultipleItems.Checked;
            _particularType.IsParent = chkParent.Checked;
            _particularType.IsPrintable = chkPrintable.Checked;

        }
        private void PopulateData()
        {
            lblId.Text = _particularType.Id.ToString();
            txtCode.Text = !string.IsNullOrEmpty(_particularType.Code)?_particularType.Code.Trim():"";
            txtDescription.Text = !string.IsNullOrEmpty(_particularType.Description) ? _particularType.Description.Trim() : "";
            chkMultipleItems.Checked = _particularType.MultipleItems;
            chkPrintable.Checked = _particularType.IsPrintable;
            chkParent.Checked = _particularType.IsParent;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            SendData();
            if (_particularType.Id > -1)
            {
                blParticularType.update(_particularType);
            }
            else
            {
                //if (blParticularType.retrieve(_particularType.Code) == null)
                    blParticularType.create(_particularType);
                //else
                //    MessageBox.Show("Code already existing!");
            }
            BindData(blParticularType.retrieveView());
            New();
            MessageBox.Show("Item has been successfully saved or updated");
     
        }
        private void New()
        {
            txtCode.Enabled = true;
            _particularType = new ParticularType();
            btnDelete.Enabled = false;
            PopulateData();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            New();            
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            ControlSaveButton();
        }
        private void ControlSaveButton()
        {
            btnSave.Enabled = (txtCode.TextLength > 0) && (txtDescription.TextLength>0);
        }
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            ControlSaveButton();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string[] gcIds = System.Configuration.ConfigurationManager.AppSettings["rejectidsnotincluded"].ToString().Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            //if (blProductList.retrieveByParticularTypeId(_particularType.Id).Count>0)
            //{
            //    MessageBox.Show("Selected Item had been reference to another data");
            //    return;
            //}

            foreach (string gcId in gcIds)
            {
                if (gcId.Equals(_particularType.Id.ToString()))
                {
                    MessageBox.Show("Deleting this type is not allowed\r\nbecause this type maybe gc or coupon related");
                    return;
                }
            }

            blParticularType.delete(_particularType.Id);
            BindData(blParticularType.retrieveView());
            New();
            MessageBox.Show("Item has been successfully delete");
        }

        private void chkPrintable_CheckedChanged(object sender, EventArgs e)
        {
            //chkParent.Enabled = !chkPrintable.Checked;
            //if (chkPrintable.Checked)
            //    chkParent.Checked = false;
        }
    }
}