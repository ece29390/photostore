using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhotoStore.BusinessLogic;
using PhotoStore.Entity;
namespace PhotoStore
{
    public partial class GCCouponEntry : Form
    {
        private bool _isGiftCheque = false;
        long _typeId;
        long _productListId;
        string _productDescription;
        public GCCouponEntry(bool isgc,long typeid,long productlistid,string productdescription)
        {
            _isGiftCheque = isgc;
            _typeId = typeid;
            InitializeComponent();
            txtGCCouponCode.MaxLength = Convert.ToInt32(ConfigurationManager.AppSettings["MaxChars"]);
            _productListId = productlistid;
            _productDescription = productdescription;
        }

        private void GCCouponEntry_Load(object sender, EventArgs e)
        {
            //txtGCCouponCode.Text =
            //    ConfigurationManager.AppSettings["BranchCode"].ToString();
            //txtGCCouponCode.SelectionStart = txtGCCouponCode.Text.Length;
            
            if (_isGiftCheque)
            {
                //string[] gcDescriptions = _typeId==3?ConfigurationManager.AppSettings["gcproducts"].ToString().Split(
                //    new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries) : ConfigurationManager.AppSettings["denomgcs"].ToString().Split(
                //    new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                //foreach (string gcDescription in gcDescriptions)
                //{
                //    cboDescription.Items.Add(gcDescription);
                //}
                txtPrefix.Text = ConfigurationManager.AppSettings["BranchCodeGC"].ToString().Trim();
                txtProductDescription.Text = _productDescription;
               // cboDescription.SelectedIndex = 0;
                txtExpirationDate.Text = DateTime.Now.AddMonths(
                   Convert.ToInt32(ConfigurationManager.AppSettings["autogcadd"])).ToString("MM/dd/yyyy");
            }
            else
            {
                //string[] couponDescriptions = ConfigurationManager.AppSettings["couponproducts"].ToString().Split(
                //    new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                //foreach (string couponDescription in couponDescriptions)
                //{
                //    cboDescription.Items.Add(couponDescription);
                //}
                //cboDescription.SelectedIndex = 0;
                txtPrefix.Text = ConfigurationManager.AppSettings["BranchCodeCP"].ToString();
                txtProductDescription.Text = _productDescription;
                txtExpirationDate.Text = DateTime.Now.AddMonths(
                    Convert.ToInt32(ConfigurationManager.AppSettings["autocouponadd"])).ToString("MM/dd/yyyy");
            }
        }

        private void txtGCCouponCode_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = (txtGCCouponCode.TextLength > 0);// && (txtDesc.TextLength > 0);
        }

        //private void txtDesc_TextChanged(object sender, EventArgs e)
        //{
        //    txtGCCouponCode_TextChanged(sender, e);
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            string code;
            if (_isGiftCheque)
            {
                code = string.Concat(txtPrefix.Text.Trim(), blUtility.FormatCode(txtGCCouponCode.Text.Trim()));
                GiftCertificate giftCertificate = blGiftCertificate.retrieve(code);
                if (giftCertificate != null)
                {
                    MessageBox.Show("Code already exists!");
                    txtGCCouponCode.Focus();
                    return;
                }
                else
                {
                    ProductList pl = blProductList.retreiveById(_productListId);
                    
                    giftCertificate = new GiftCertificate();
                    giftCertificate.Code = code;
                    giftCertificate.UnitPrice = pl.UnitPrice;
                    giftCertificate.Description = txtProductDescription.Text.Trim();
                    giftCertificate.ProductListId = _productListId;//cboDescription.Text.Trim();//txtDesc.Text.Trim();
                    giftCertificate.ExpirationDate = Convert.ToDateTime(
                        txtExpirationDate.Text.Trim());
                    giftCertificate.GiftCertificateStatusId = 1;//Pending
                    giftCertificate.GiftCertificateTypeId = _typeId;
                    giftCertificate.IsComplementary = chkComplementary.Checked;
                    if (chkComplementary.Checked)
                        giftCertificate.ExpirationDate = null;
                    blGiftCertificate.create(giftCertificate);
                    MessageBox.Show("Save successfully");
                }
                                
            }
            else
            {
                code = string.Concat(txtPrefix.Text.Trim(), blUtility.FormatCode(txtGCCouponCode.Text.Trim()));
                Coupon coupon = blCoupon.retrieve(code);
                if (coupon != null)
                {
                    MessageBox.Show("Code already exists!");
                    txtGCCouponCode.Focus();
                    return;
                }
                else
                {
                    ProductList pl = blProductList.retreiveById(_productListId);
                    coupon = new Coupon();
                    coupon.Code = code;
                    coupon.Description = txtProductDescription.Text.Trim();//cboDescription.Text.Trim();//txtDesc.Text.Trim();
                    coupon.ExpirationDate = Convert.ToDateTime(
                        txtExpirationDate.Text.Trim());
                   // coupon.CouponTypeId = _typeId;
                    coupon.UnitPrice = pl.UnitPrice;
                    coupon.ProductListId = _productListId;
                    coupon.CouponStatusId = 1;
                   blCoupon.create(coupon);
                    MessageBox.Show("Save successfully");
                }
            }
        }

        private void chkComplementary_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        
    }
}