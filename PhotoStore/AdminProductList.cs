using System;
using System.Configuration;
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
    public partial class AdminProductList : Form
    {
        long _employeeId;
        SearchPriceList sp = new SearchPriceList();
        ProductList pl = new ProductList();
        List<SearchPriceList> sps;// = new List<SearchPriceList>();
        //List<long> _redemptionGCIds = new List<long>();
        //List<long> _redemptionCouponIds = new List<long>();
        public AdminProductList(long employeeId)
        {
            InitializeComponent();
            _employeeId = employeeId;
            
        }
        List<long> _particularTypeIds = new List<long>();
        blUtility _blUtility = new blUtility();
        private void AdminProductList_Load(object sender, EventArgs e)
        {
            cboProductType.DisplayMember = "Description";
            cboProductType.ValueMember = "Id";
            cboProductType.DataSource = UI.BindSource(blParticularType.retrieveForComboBox(), false);

            cboProductTypeDE.DisplayMember = "Description";
            cboProductTypeDE.ValueMember = "Id";
            cboProductTypeDE.DataSource = UI.BindSource(blParticularType.retrieve(), false);

            //string[] arrGCIds = ConfigurationManager.AppSettings["redemptiongcids"].ToString().Split(
            //    new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            //foreach (string arrGCId in arrGCIds)
            //{
            //    _redemptionGCIds.Add(Convert.ToInt32(arrGCId));
            //}
            //string[] arrCouponIds = ConfigurationManager.AppSettings["redemptioncouponids"].ToString().Split(
            //    new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            //foreach (string arrCouponId in arrCouponIds)
            //{
            //    _redemptionCouponIds.Add(Convert.ToInt32(arrCouponId));
            //}

            //retrieve from the app.config all particular ids with one item only
            string[] ids = ConfigurationManager.AppSettings["particularidswithoneitem"].ToString().Split(
                new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            //put the retrive ids in Generic List
           
            foreach (string str in ids)
            {
                _particularTypeIds.Add(Convert.ToInt64(str));
            }
            BindParentParticular();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            sp = new SearchPriceList();
            sp.ParticularType_Id = (long)cboProductType.SelectedValue;
            UI.InitializeGrid(gvPriceList, false);
            sps = new List<SearchPriceList>();
            sps = blProductList.retrieve(sp,btnSearch.Text);


            if (sps.Count > 0)
                gvPriceList.DataSource = UI.BindSource(sps, false);
            else
            {
                if (e != null)
                    MessageBox.Show(UI.NoRecordsFound());
            }

            _searchMode = btnSearch.Text;
        }
        string _searchMode;
        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            gvPriceList.DataSource = null;
            UI.InitializeGrid(gvPriceList, false);

            sps = new List<SearchPriceList>();
            sps = blProductList.retrieve(null, btnSearchAll.Text);

            if (sps.Count > 0)
                gvPriceList.DataSource = UI.BindSource(sps, false);
            else
            {
                if(e!=null)
                    MessageBox.Show(UI.NoRecordsFound());
            }
         

            _searchMode = btnSearchAll.Text;
            
        }
        private void ControlDataEntryControls(bool isenable)
        {
            foreach (Control control in pnlProductList.Controls)
            {
                if (control is ComboBox)
                {
                    ComboBox cbo = (ComboBox)control;
                    cbo.Enabled = isenable;
                    //cbo.Dispose();
                    cbo = null;

                }

                if (control is CheckBox)
                {
                    CheckBox chk = (CheckBox)control;
                    chk.Enabled = isenable;
                    //chk.Dispose();
                    chk = null;
                }

                if (control is TextBox)
                {
                    TextBox txt = (TextBox)control;
                    txt.Enabled = isenable;
                    //txt.Dispose();
                    txt = null;
                }
            }
        }
        private void ResetControls()
        {
            foreach (Control control in pnlProductList.Controls)
            {
                if (control is ComboBox)
                {
                    ComboBox cbo = (ComboBox)control;
                    cbo.SelectedIndex = 0;
                    cbo = null;
                }

                if (control is CheckBox)
                {
                    CheckBox chk = (CheckBox)control;
                    chk.Checked = false;
                    chk = null;
                }

                if (control is TextBox)
                {
                    TextBox txt = (TextBox)control;
                    txt.Clear();
                    txt = null;
                }
            }
           
        }
        private void RefreshProductListAfterCUD()
        {
            if (!string.IsNullOrEmpty(_searchMode))
            {
                switch (_searchMode)
                {
                    case "Search All":
                        btnSearchAll_Click(btnSearchAll, null);
                        break;
                    case "Search":
                        btnSearch_Click(btnSearch, null);
                        break;
                }

            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            pl = new ProductList();
            ControlDataEntryControls(true);
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnDelete.Enabled = false;
            ResetControls();
            btnAddPriceDetails.Enabled = false;
            btnRemovePriceDetails.Enabled = false;
            BindGridProductDetails();
            cboProductTypeDE.Enabled = true;
            _redemptionGCCoupon = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal unitPrice = 0;
            if (decimal.TryParse(txtUnitPrice.Text.Trim(), out unitPrice))
            {
                pl.Description = txtProductName.Text.Trim();
                pl.ParticularTypeId = (long)cboProductTypeDE.SelectedValue;
                pl.UnitPrice = Convert.ToDouble(txtUnitPrice.Text.Trim());
                // pl.IsPackage = chkIsPackage.Checked;
                List<ProductList> productList = blProductList.retrieveByDescriptionAndParticularType(txtProductName.Text.Trim(), pl.ParticularTypeId);
                if (productList.Count > 0)
                {
                    if (!pl.Id.Equals(productList[0].Id))
                    {
                        MessageBox.Show("Product Name Already Existing");
                        return;
                    }
                }

                if (gbParentGCCoupon.Enabled)
                {
                    if (cboParentParticularType.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please Select an item in GC/Coupon Type");
                        return;
                    }
                    if (cboParentGCCoupon.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please Select an item in GC/Coupon Products");
                        return;
                    }

                }

                if (pl.Id > 0)//Edit Mode
                {
                    pl.ModifiedEmployeeId = _employeeId;
                    blProductList.update(pl);
                }
                else//Create Mode
                {
                    pl.CreatedEmployeeId = _employeeId;
                    pl = blProductList.create(pl);

                }

                if (gbParentGCCoupon.Enabled)
                {
                    
                    blProductList.SaveRedemptionGCCoupon(
                        pl.Id, Convert.ToInt64(cboParentGCCoupon.SelectedValue));
                }

                MessageBox.Show("Price List has been added/updated to the database");
                btnAddPriceDetails.Enabled = true;
                btnDelete.Enabled = true;

                RefreshProductListAfterCUD();
            }
            else
            {
                MessageBox.Show("Unit Price has invalid value");

            }
           
        }
        private void BindProductListDetails(object datasource)
        {
            gvProductListDetails.DataSource = null;
            gvProductListDetails.AutoGenerateColumns = false;
            gvProductListDetails.DataSource = UI.BindSource(datasource, false);

           
            if (_particularTypeIds.Contains(pl.ParticularTypeId))
            {
                //If the particlar type id of the entity contains
                //it means the process should check if the item is equal to 1
                if (pl.ProductListDetails.Count == 1)
                {
                    btnAddPriceDetails.Enabled = false;//disable the control because it should contain only one item
                }
            }

           
            
        }
        private void btnAddPriceDetails_Click(object sender, EventArgs e)
        {
            if (gvProductListDetails.RowCount > 0)
            {
                ParticularType pt = blParticularType.retrieve(
                    Convert.ToInt64(cboProductTypeDE.SelectedValue));
                if (!pt.MultipleItems)
                {
                    MessageBox.Show("Only one item can be added to this particular type");
                    return;
                }
            }
            AdminPriceDetails frm = new AdminPriceDetails(pl.Id,
                pl.Description);
            frm.ShowDialog();
            if(frm.ProductListDetails!=null)
                pl.ProductListDetails.Add(frm.ProductListDetails);
            frm.Dispose();
            frm = null;
            BindGridProductDetails();
            RefreshProductListAfterCUD();

            cboProductTypeDE.Enabled = false;
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = (txtProductName.TextLength > 0);
            btnCancel.Enabled = btnSave.Enabled;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ControlDataEntryControls(false);
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            pl = new ProductList();
            txtProductName.Clear();
        }

        //private bool EnableParentGCCoupon(long particulartypeid)
        //{
        //    bool retValue = false;
        //    if (_redemptionGCIds.Contains(particulartypeid))
        //    {
        //        retValue = true;
        //    }
        //    if (!retValue)
        //    {
        //        if (_redemptionCouponIds.Contains(particulartypeid))
        //        {
        //            retValue = true;
        //        }
        //    }
        //    return retValue;
        //}
        private void BindParentGCCoupon(long particulartypeid)
        {
         
            cboParentGCCoupon.DisplayMember = "Description";
            cboParentGCCoupon.ValueMember = "Id";
            cboParentGCCoupon.DataSource = UI.BindSource(
                                        blProductList.retrieveByParticularTypeId(particulartypeid),false);
        }
        private void BindParentParticular()
        {
            cboParentParticularType.DisplayMember = "Description";
            cboParentParticularType.ValueMember = "Id";
            cboParentParticularType.DataSource = UI.BindSource(
                blParticularType.retrieveParentGCCoupon(), false);
        }
        private void PopulateDataToControls()
        {
            cboProductTypeDE.SelectedValue = pl.ParticularTypeId;
            txtProductName.Text = pl.Description;
            txtUnitPrice.Text = pl.UnitPrice.ToString();

            gbParentGCCoupon.Enabled = (pl.ProductType.IsParent==false
                &&pl.ProductType.IsPrintable);//_blUtility.EnableParentGCCoupon(pl.ParticularTypeId);//EnableParentGCCoupon(pl.ParticularTypeId);
            
           
            

            //chkIsPackage.Checked = pl.IsPackage;
        }
        private void BindGridProductDetails()
        {
            if (pl.ProductListDetails.Count > 0)
            {
                //btnAddPriceDetails.Enabled = true;
                btnRemovePriceDetails.Enabled = true;
            }
                BindProductListDetails(pl.ProductListDetails);
            
        }
        private void BindComboValue(ComboBox cbo,long value,Type type)
        {
            for (int i = 0; i < cbo.Items.Count; i++)
            {
                if (type == typeof(ParticularType))
                {
                    ParticularType particularType = (ParticularType)cbo.Items[i];
                    if (particularType.Id.Equals(value))
                    {
                        cbo.SelectedIndex = i;
                        break;
                    }
                    particularType = null;
                }
                else if (type==typeof(ProductList))
                {
                    ProductList productList = (ProductList)cbo.Items[i];
                    if (productList.Id.Equals(value))
                    {
                        cbo.SelectedIndex = i;
                        break;
                    }
                    productList = null;
                }

            }
        }
        RedemptionGCCoupon _redemptionGCCoupon = null;
        private void gvPriceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (gvPriceList.Columns[e.ColumnIndex].Name == "colProductName")
                {
                    tabControl1.SelectTab(tabRecord);
                    long productListId=Convert.ToInt64(gvPriceList.Rows[e.RowIndex].Cells["colProductListId"].EditedFormattedValue);
                    pl = blProductList.retreiveById(productListId);
                    
                    PopulateDataToControls();
                    BindGridProductDetails();
                    //btnCreate.Enabled = false;
                    ControlDataEntryControls(true);
                    btnAddPriceDetails.Enabled = true;
                    btnDelete.Enabled = true;
                    cboParentParticularType.SelectedIndex = -1;
                    cboParentGCCoupon.SelectedIndex = -1;
                    List<RedemptionGCCoupon> redemptionCoupons = blProductList.GetRetrieveParentProductId(pl.Id);
                    if (redemptionCoupons.Count>0)
                    {
                        _redemptionGCCoupon = redemptionCoupons[0];
                        ProductList productList = blProductList.retreiveById(_redemptionGCCoupon.ParentProductListId);
                        BindComboValue(cboParentParticularType, productList.ParticularTypeId,
                            typeof(ParticularType));

                    }
                    if (gvProductListDetails.RowCount > 0)
                    {
                        cboProductTypeDE.Enabled = false;
                    }
                }
            }
        }

        private void gvProductListDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (gvProductListDetails.Columns[e.ColumnIndex].Name.Equals(
                    "colParticularsDE", StringComparison.InvariantCultureIgnoreCase))
                {
                    long productDetailsId = Convert.ToInt64(
                        gvProductListDetails.Rows[e.RowIndex].Cells["colProductListDetailsId"].EditedFormattedValue);

                    AdminPriceDetails frm = new AdminPriceDetails(blProductListDetails.retreiveById(productDetailsId), pl.Description);
                    frm.ShowDialog();
                    frm.Dispose();
                    frm = null;

                    pl.ProductListDetails = blProductListDetails.retrieveByProductListId(
                        pl.Id);
                    BindGridProductDetails();
                }
                    
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show(
                "Are you sure you want to delete this item?",
                "Delete Confirmation", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dlg == DialogResult.Yes)
            {
                blProductList.delete(pl);
                RefreshProductListAfterCUD();
                ResetControls();
                ControlDataEntryControls(false);
                btnAddPriceDetails.Enabled = false;
                btnRemovePriceDetails.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnDelete.Enabled = false;
                pl = new ProductList();
                BindGridProductDetails();
                MessageBox.Show("Item had been successfully deleted");
            }
        }

        private void btnRemovePriceDetails_Click(object sender, EventArgs e)
        {
            List<long> productDetailsIdList = new List<long>();//Variable that hold the selected item(s)
            //Iterate through the data grid to retrieve the selected item(s)
            foreach (DataGridViewRow dgvr in gvProductListDetails.Rows)
            {
                bool isChecked = Convert.ToBoolean(dgvr.Cells["colChk"].EditedFormattedValue);
                if (isChecked)
                {
                    productDetailsIdList.Add(
                        Convert.ToInt64(dgvr.Cells["colProductListDetailsId"].EditedFormattedValue));
                }
            }

            if (productDetailsIdList.Count == 0)//if no item(s) is/are selected inform the user and exit the process
            {
                MessageBox.Show("Please Select one or more items");
                return;
            }
            //iterate through the product detail list item(s) to delete one by one
            foreach (long productDetailId in productDetailsIdList)
            {
                ProductListDetails pld = new ProductListDetails();
                pld.Id = productDetailId;
                blProductListDetails.delete(pld);
                pld = null;
            }

            //Repopulate the grid
            pl.ProductListDetails = blProductListDetails.retrieveByProductListId(pl.Id);
            BindGridProductDetails();
            if (gvProductListDetails.RowCount == 0)
                cboProductTypeDE.Enabled = true;
        }

        private void cboParentParticularType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboParentParticularType.SelectedIndex != -1)
            {
                BindParentGCCoupon(Convert.ToInt64(
                    cboParentParticularType.SelectedValue));
                if (_redemptionGCCoupon != null)
                {
                    BindComboValue(cboParentGCCoupon, _redemptionGCCoupon.ParentProductListId, typeof(ProductList));
                }
            }
        }
        Entity.ParticularType _particularType;
        private void cboProductTypeDE_SelectedIndexChanged(object sender, EventArgs e)
        {
            _particularType = blParticularType.retrieve(Convert.ToInt64(
                                    cboProductTypeDE.SelectedValue));
            gbParentGCCoupon.Enabled = (_particularType.IsParent==false&&
                                        _particularType.IsPrintable);
            //gbParentGCCoupon.Enabled = _blUtility.EnableParentGCCoupon(Convert.ToInt64(
            //                        cboProductTypeDE.SelectedValue));//EnableParentGCCoupon(Convert.ToInt64(
            //    cboProductTypeDE.SelectedValue));
            if (gbParentGCCoupon.Enabled)
            {
                cboParentParticularType.SelectedIndex = 0;
                
            }
        }

        private void AdminProductList_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

       
      
        

       
    }
}