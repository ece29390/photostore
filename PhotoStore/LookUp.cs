using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhotoStore.BusinessLogic;
using PhotoStore.Entity;
namespace PhotoStore
{
    public partial class LookUp : Form
    {
        long _Id;
        long? _initialid=null;
        string _owner;
        public LookUp(long id,string owner)
        {
            InitializeComponent();
            _owner = owner;
            if (id != -1)
            {
                _initialid = id;
            }
        }

        string _description;
        public LookUp(string description, string owner)
        {
            InitializeComponent();
            _description = description;
            _owner = owner;
        }
        public LookUp(string description, string owner,int subid)
        {
            InitializeComponent();
            _description = description;
            _owner = owner;
            _subId = subid;
        }
        int _subId;
        public LookUp(long id,string owner,int subid)
        {
            InitializeComponent();
            _Id = id;
            if (_Id != -1)
                _initialid = id;
            _owner = owner;
            _subId = subid;
        }
        string _code = "";
        public string Code
        {
            get { return _code; }
        }

        double? _unitPrice = null;
        public double? UnitPrice
        {
            get { return _unitPrice; }
        }

        public long Id
        {
            get { return _Id; }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _Id = Convert.ToInt64(cbo.SelectedValue);
            _code = cbo.Text.Trim();
            Close();
        }

        private void LookUpSuppler_Load(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = blSupplier.retrieveForComboBox();
            bs.ResetBindings(false);
            cbo.DisplayMember = "Code";
            cbo.ValueMember = "Id";
            cbo.DataSource = bs;
           
           if(_initialid.HasValue)
            {
                for (int i = 0; i < cbo.Items.Count; i++)
                {
                    PhotoStore.Entity.Supplier supplier = (PhotoStore.Entity.Supplier)cbo.Items[i];
                    if (supplier.Id==_initialid.Value)
                    {
                        cbo.SelectedIndex = i;
                        break;
                    }
                    supplier = null;
                }
                //cboSupplier.SelectedValue = _initialsupplierid.Value;// _supplierId;
            }
        }

      

        private void cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (  _owner != "CouponProducts")
            //{
                _code = "";
                _Id = -1;
                _unitPrice = null;
                if (cbo.SelectedValue != null)
                {
                    if (!cbo.SelectedValue.ToString().Equals("-1"))
                        btnAdd.Enabled = true;
                    else
                        btnAdd.Enabled = false;
                }
                if (btnAdd.Enabled)
                {
                    switch (_owner)
                    {
                        case "GiftCertificateProducts":
                            _unitPrice = blProductList.retreiveById(
                                Convert.ToInt64(cbo.SelectedValue)).UnitPrice;
                            break;
                    }
                }
            //}
          
        
      
        }

        private void SelectDataSource()
        {
            BindingSource bs =new BindingSource();
            switch (_owner)
            {
                case "Supplier":
                    bs= UI.BindSource(blSupplier.retrieveForComboBox(),false);
                    break;
                case "GiftCertificateType":
                    bs = UI.BindSource(BusinessLogic.blGiftCertificateType.retrieveForComboBox(),false);
                    break;
                case "GiftCertificateStatus":
                    bs = UI.BindSource(BusinessLogic.blGiftCertificateStatus.retrieveForComboBox(),false);
                    break;
                case "CouponStatus":
                    bs = UI.BindSource(BusinessLogic.blCouponStatus.retrieveForComboBox(), false);
                    break;
                case "PaymentTypeCode":
                    bs = UI.BindSource(BusinessLogic.blPaymentType.retrieveForComboBox(), false);
                    break;
                case "User":
                    bs = UI.BindSource(BusinessLogic.blEmployeeGroup.retrieveForComboBox(true), false);
                    break;
                case "GiftCertificateProducts":
                    switch (_subId)
                    {
                        case 3:
                       //     string[] gcProducts = System.Configuration.ConfigurationManager.AppSettings["gcproducts"].ToString().Split(
                       //new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                       //     foreach (string gcProduct in gcProducts)
                       //     {
                       //         cbo.Items.Add(gcProduct);
                       //     }
                       //     btnAdd.Enabled = true;
                            bs = UI.BindSource(blProductList.retrieveByPhotoGCComboBox(true), false);
                            break;
                        case 4:
                            //string[] dcProducts = System.Configuration.ConfigurationManager.AppSettings["denomgcs"].ToString().Split(
                            //    new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                            //foreach (string dcProduct in dcProducts)
                            //{
                            //    cbo.Items.Add(dcProduct);

                            //}
                            //btnAdd.Enabled = true;
                            bs = UI.BindSource(blProductList.retrieveByDenominationComboBox(true),
                                false);
                            break;
                    }
                   
            
                    break;
                case "CouponProducts":
                    //string[] couponProducts = System.Configuration.ConfigurationManager.AppSettings["couponproducts"].ToString().Split(
                    //    new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    //foreach (string couponProduct in couponProducts)
                    //{
                    //    cbo.Items.Add(couponProduct);
                    //}
                    //btnAdd.Enabled = true;
                    bs=UI.BindSource(blProductList.retrieveByCouponComboBox(true),false);
                    break;

            }

            if (_owner != "GiftCertificateProducts" && _owner!="CouponProducts")
            {
                cbo.DisplayMember = System.Configuration.ConfigurationManager.AppSettings["showtext"].ToString();
                cbo.ValueMember = "Id";
                cbo.DataSource = bs;

                if (_initialid.HasValue)
                {
                    for (int i = 0; i < cbo.Items.Count; i++)
                    {
                        switch (_owner)
                        {
                            case "GiftCertificateType":
                                GiftCertificateType certificateType = (GiftCertificateType)cbo.Items[i];
                                if (certificateType.Id == _initialid.Value)
                                {
                                    cbo.SelectedIndex = i;
                                    break;
                                }
                                certificateType = null;
                                break;
                            case "Supplier":
                                Supplier supplier = (Supplier)cbo.Items[i];
                                if (supplier.Id == _initialid.Value)
                                {
                                    cbo.SelectedIndex = i;
                                    break;
                                }
                                supplier = null;
                                break;
                            case "GiftCertificateStatus":
                                GiftCertificateStatus certificateStatus = (GiftCertificateStatus)cbo.Items[i];
                                if (certificateStatus.Id == _initialid.Value)
                                {
                                    cbo.SelectedIndex = i;
                                    break;
                                }
                                certificateStatus = null;
                                break;
                            case "CouponStatus":
                                CouponStatus couponStatus = (CouponStatus)cbo.Items[i];
                                if (couponStatus.Id == _initialid.Value)
                                {
                                    cbo.SelectedIndex = i;
                                    break;
                                }
                                couponStatus = null;
                                break;
                            case "PaymentTypeCode":
                                PaymentType paymentType = (PaymentType)cbo.Items[i];
                                if (paymentType.Id == _initialid.Value)
                                {
                                    cbo.SelectedIndex = i;
                                    break;
                                }
                                paymentType = null;
                                break;
                            case "User":
                                EmployeeGroup employeeGroup = (EmployeeGroup)cbo.Items[i];
                                if (employeeGroup.Id == _initialid.Value)
                                {
                                    cbo.SelectedIndex = i;
                                    break;
                                }
                                employeeGroup = null;
                                break;
                        }

                    }
                    //cboSupplier.SelectedValue = _initialsupplierid.Value;// _supplierId;
                }
            }
            else
            {
                cbo.DisplayMember = "Description";
                cbo.ValueMember = "Id";
                cbo.DataSource = bs;
                //List<Entity.ProductList> productLists = blProductList.retrieveByDescription(_description);
                //if (productLists.Count > 0)
                //{
                if (_initialid.HasValue)
                {
                    for (int i = 0; i < cbo.Items.Count; i++)
                    {
                        ProductList productList = (ProductList)cbo.Items[i];
                        if (productList.Id.Equals(_initialid.Value))
                        {
                            cbo.SelectedIndex = i;
                            break;
                        }
                        productList = null;
                    }
                }
                //}
                             
            }
        }
        private void cbo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void LookUp_Load(object sender, EventArgs e)
        {
            SelectDataSource();
        }
    }
}