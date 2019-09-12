using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PhotoStore.BusinessLogic;
using PhotoStore.Entity;
using System.Configuration;
namespace PhotoStore.BusinessLogic.UserControls
{
    public delegate void DoneSaving();
  
    public partial class UCAddEdit : UserControl
    {
        string _type;
        object _entity;
        long _productListId;
        long _id = -1;
         string _branchGCCode,_branchCpCode;
         int _maxChars;
        public event DoneSaving _doneSaving;
     
        public UCAddEdit()
        {
            InitializeComponent();
          
        }
        public void LoadStartUpVariables()
        {
            _branchGCCode = ConfigurationManager.AppSettings["BranchCodeGC"].ToString();
            _branchCpCode = ConfigurationManager.AppSettings["BranchCodeCP"].ToString();
            _maxChars = Convert.ToInt32(ConfigurationManager.AppSettings["MaxChars"]);
            txtCode.MaxLength = _maxChars;
        }
        public void LoadDatas(string type,object entity)
        {
            _type = type;
            _entity = entity;


            if (entity != null)
                btnDelete.Enabled = true;
            else
            {
                switch (type)
                {
                    case "AdminCoupon":
                        dateTimePicker1.Value = DateTime.Now.AddMonths(
                            Convert.ToInt32(ConfigurationManager.AppSettings["autocouponadd"]));
                        break;
                    case "AdminGiftCertificate":
                        dateTimePicker1.Value = DateTime.Now.AddMonths(
                              Convert.ToInt32(ConfigurationManager.AppSettings["autogcadd"]));
                        break;
                }
            }
            switch (type)
            {
                case "AdminCoupon":
                    cboType.Enabled = false;
                    txtCodePrefix.Text = _branchCpCode.Trim();
                    cboDescription.DataSource = blProductList.retrieveByCouponComboBox(true);
                    cboDescription.DisplayMember = "Description";
                    cboDescription.ValueMember = "Id";
                    cboStatus.DataSource = blCouponStatus.retrieveForComboBox();
                    cboStatus.DisplayMember = "Description";
                    cboStatus.ValueMember = "Id";
                    chkIsComplementary.Visible = false;
                    if (entity != null)
                        PopulateValue();
                    break;
                case "AdminGiftCertificate":
                    txtCodePrefix.Text = _branchGCCode.Trim();
                    cboType.DataSource = blGiftCertificateType.retrieveForComboBox();
                    cboType.DisplayMember = "Description";
                    cboType.ValueMember = "Id";
                    cboStatus.DataSource = blGiftCertificateStatus.retrieveForComboBox();
                    cboStatus.DisplayMember = "Description";
                    cboStatus.ValueMember = "Id";
                    if(entity!=null)
                        PopulateValue();
                    break;
            }
        }
        private void PopulateValue()
        {
            switch (_type)
            {
                case "AdminCoupon":
                    Coupon coupon = (Coupon)_entity;
                    _productListId = coupon.ProductListId;
                    _id = coupon.Id;
                    txtCode.Text = coupon.Code.Replace(txtCodePrefix.Text.Trim(), "").Trim();
                    if (coupon.ExpirationDate.HasValue)
                        dateTimePicker1.Value = coupon.ExpirationDate.Value;
                    PopulateCombo(cboDescription, coupon.ProductListId);
                    PopulateCombo(cboStatus, coupon.CouponStatus.Id);
                    break;
                case "AdminGiftCertificate":
                    GiftCertificate giftCertificate = (GiftCertificate)_entity;
                    _productListId = giftCertificate.ProductListId;
                    _id = giftCertificate.Id;
                    txtCode.Text = giftCertificate.Code.Replace(txtCodePrefix.Text.Trim(), "").Trim();
                    chkIsComplementary.Visible = false;
                    if (giftCertificate.ExpirationDate.HasValue)
                        dateTimePicker1.Value = giftCertificate.ExpirationDate.Value;
                    PopulateCombo(cboType, giftCertificate.GiftCertificateType.Id);
                    PopulateCombo(cboStatus, giftCertificate.GiftCertificateStatus.Id);
                   
                    break;
            }
        }
        private void PopulateCombo(ComboBox combo,long id)
        {
            int? selectedIndex = null;
            for (int i = 0; i < combo.Items.Count; i++)
            {
                if (combo.Items[i] is GiftCertificateType)
                {
                    GiftCertificateType gct = (GiftCertificateType)combo.Items[i];
                    if (gct.Id.Equals(id))
                    {
                        selectedIndex = i;
                        break;
                    }
                    gct = null;
                }
                else if (combo.Items[i] is GiftCertificateStatus)
                {
                    GiftCertificateStatus gcs = (GiftCertificateStatus)combo.Items[i];
                    if (gcs.Id.Equals(id))
                    {
                        selectedIndex = i;
                        break;
                    }
                    gcs = null;
                }
                else if (combo.Items[i] is ProductList)
                {
                    ProductList pl = (ProductList)combo.Items[i];
                    if (pl.Id.Equals(id))
                    {
                        selectedIndex = i;
                        break;
                    }
                    pl = null;
                }
                else if (combo.Items[i] is CouponStatus)
                {
                    CouponStatus cs = (CouponStatus)combo.Items[i];
                    if (cs.Id.Equals(id))
                    {
                        selectedIndex = i;
                        break;
                    }
                    cs = null;
                }
            }
            if (selectedIndex.HasValue)
            {
                combo.SelectedIndex = selectedIndex.Value;
            }
        }
        private void UCAddEdit_Load(object sender, EventArgs e)
        {
          
            
           
        }
        private bool Validation()
        {
       
            if (cboType.Enabled)
            {
                if (cboType.SelectedValue.ToString() == "-1")
                {
                  
                   return false;
                }
            }
            if (cboDescription.SelectedValue.ToString() == "-1")
               return false;
           if (cboStatus.SelectedValue.ToString() == "-1")
               return false;

           if (txtCode.TextLength == 0)
               return false;

            
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                MessageBox.Show("Please Complete all of the fields");
                return;
            }
            string code = string.Concat(txtCodePrefix.Text, blUtility.FormatCode(txtCode.Text.Trim()));
            switch (_type)
            {
                case "AdminGiftCertificate":
                    #region AdminGiftCertificate
                    GiftCertificate giftCert = blGiftCertificate.retrieve(code);
                    if (giftCert != null)
                    {
                        if (!_id.Equals(giftCert.Id))
                        {
                            MessageBox.Show("Code is already used by other record");
                            return;
                        }
                    }
                    GiftCertificate giftCertificate = null;
                    if (_id != -1)
                    {
                        giftCertificate = (GiftCertificate)_entity;


                    }
                    else
                    {
                        giftCertificate = new GiftCertificate();
                    }
                    giftCertificate.Code = code;
                    giftCertificate.GiftCertificateTypeId = Convert.ToInt64(cboType.SelectedValue);
                    giftCertificate.GiftCertificateStatusId = Convert.ToInt64(cboStatus.SelectedValue);
                    giftCertificate.ProductListId = Convert.ToInt64(cboDescription.SelectedValue);
                    giftCertificate.UnitPrice = blProductList.retreiveById(giftCertificate.ProductListId).UnitPrice;
                    giftCertificate.Description = cboDescription.Text.Trim();
                    giftCertificate.IsComplementary = chkIsComplementary.Checked;
                    if (chkIsComplementary.Checked)
                        giftCertificate.ExpirationDate = null;
                    else
                        giftCertificate.ExpirationDate = dateTimePicker1.Value;
                    if (_id != -1)
                        blGiftCertificate.update(giftCertificate);
                    else
                        blGiftCertificate.create(giftCertificate);
                    MessageBox.Show("Record has been successfully saved");
                    #endregion                    
                    break;
                case "AdminCoupon":
                    #region Coupon
                    Coupon coupon = blCoupon.retrieve(code);
                    if (coupon != null)
                    {
                        if (!_id.Equals(coupon.Id))
                        {
                            MessageBox.Show("Code is already used by other record");
                            return;
                        }
                    }
                    Coupon couponTrans = null;
                    if (_id != -1)
                    {
                        couponTrans = (Coupon)_entity;


                    }
                    else
                    {
                        couponTrans = new Coupon();
                    }
                    couponTrans.Code = code;
                    couponTrans.CouponStatusId = Convert.ToInt64(cboStatus.SelectedValue);
                    couponTrans.ProductListId = Convert.ToInt64(cboDescription.SelectedValue);
                    couponTrans.Description = cboDescription.Text.Trim();
                    couponTrans.ExpirationDate = dateTimePicker1.Value;                    
                    if (_id != -1)
                        blCoupon.update(couponTrans);
                    else
                        blCoupon.create(couponTrans);

                    MessageBox.Show("Record has been successfully saved");
                    #endregion
                    break;
            }
            if (_doneSaving != null)
            {
                _doneSaving();
            }
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult diag = MessageBox.Show(
                "Are you sure you want to delete the record",
                "Confirmation Action"
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Question);
            if (diag == DialogResult.Yes)
            {
                switch (_type)
                {
                    case "AdminGiftCertificate":
                        blGiftCertificate.delete(_id);
                        MessageBox.Show("Record has been deleted");
                        break;
                    case "AdminCoupon":
                        blCoupon.delete(_id);
                        MessageBox.Show("Record has been deleted");
                        break;
                }
            }
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selValue = 0;
            if (int.TryParse(cboType.SelectedValue.ToString(), out selValue))
            {
                //if (cboDescription.Items.Count == 0)
                //{
                    switch (Convert.ToInt32(cboType.SelectedValue))
                    {
                        case 3:
                            cboDescription.DataSource = blProductList.retrieveByPhotoGCComboBox(true);
                            break;
                        case 4:
                            cboDescription.DataSource = blProductList.retrieveByDenominationComboBox(true);
                            break;
                    }
                    cboDescription.DisplayMember = "Description";
                    cboDescription.ValueMember = "Id";
                    if (cboDescription.Items.Count > 0)
                    {
                        PopulateCombo(cboDescription, _productListId);
                    }
                //}
            }
       
        }

        private void cboDescription_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void lblType_Click(object sender, EventArgs e)
        {

        }

        private void chkIsComplementary_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = chkIsComplementary.Checked == false;
        }

      
    
    }
}
