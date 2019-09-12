using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PhotoStore.BusinessLogic.Forms;
using PhotoStore.UtilityServices;
namespace PhotoStore.BusinessLogic.UserControls
{
    public  delegate void ImportingComplete();
    public partial class UCImportExport : UserControl
    {
        public event ImportingComplete _importingComplete;
        string _type;
        const string  _gcRootName="ArrayOfGiftCertificate";
        const string  _couponName= "ArrayOfCoupon";
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public UCImportExport()
        {
            InitializeComponent();
            this.openFileDialog1.Multiselect = false;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            DialogResult diagResult;
            //DataSet ds = new DataSet();
            
            string selectedPath;
            XMLSerializingService xss;
            switch (_type)
            {
                case "AdminCoupon":
                    diagResult = this.openFileDialog1.ShowDialog();
                    if (diagResult == DialogResult.OK)
                    {
                        selectedPath = this.openFileDialog1.FileName;
                        xss = new XMLSerializingService(selectedPath,
                            System.IO.FileMode.Open);
                        MessageBox.Show(
                            xss.Import<Entity.Coupon>(
                            new Import<PhotoStore.Entity.Coupon>(
                            blCoupon.Import),Application.StartupPath));
                        xss.Dispose();
                        //06/30/2010
                        blUtility.AdjustGcOrCouponStatus(NonProductType.Coupon);
                       
                    }
                   
                    break;
                case "AdminGiftCertificate":
                    diagResult = this.openFileDialog1.ShowDialog();
                    if (diagResult == DialogResult.OK)
                    {
                        selectedPath = this.openFileDialog1.FileName;
                        xss = new XMLSerializingService(selectedPath,
                            System.IO.FileMode.Open);
                        MessageBox.Show(
                            xss.Import<Entity.GiftCertificate>(
                            new Import<PhotoStore.Entity.GiftCertificate>(
                            blGiftCertificate.Import), Application.StartupPath));
                        xss.Dispose();
                        //06/30/2010
                        blUtility.AdjustGcOrCouponStatus(NonProductType.GiftCertificate);
                    }
                   
                    break;
            }
            //ds.Dispose();
            //ds = null;
            if (_importingComplete != null)
            {
                _importingComplete();
            }
        }
       
        private void btnExport_Click(object sender, EventArgs e)
        {
            
            //DateSelector dateSelector = new DateSelector();
            //if (dateSelector.ShowDialog() != DialogResult.OK)
            //{
            //    MessageBox.Show("Please select a date range");
            //    dateSelector.Dispose();
            //    dateSelector = null;
            //    return;
            //}
            
            //DateTime dtFrom = Convert.ToDateTime(dateSelector.DateFrom.ToShortDateString());
            //DateTime dtTo=dateSelector.DateTo;
            //if (dtFrom > dateSelector.DateTo)
            //{
            //    MessageBox.Show("Expiration Date From should not be later that Expiration Date To");
            //    dateSelector.Dispose();
            //    dateSelector = null;
            //     return;
            //}

            //dateSelector.Dispose();
            //dateSelector = null;
            DialogResult diagResult;
            DataSet ds=null;
            string fileName;
            XMLSerializingService xss;
            switch (_type)
            {
                case "AdminCoupon":
                    fileName = string.Format("{0}Coupon{1}.xml",
                        System.Configuration.ConfigurationManager.AppSettings["BranchCode"].ToString(),
                        DateTime.Now.ToString("MMddyyyyhhmmss"));
                    saveFileDialog1.FileName = fileName;
                    diagResult = saveFileDialog1.ShowDialog();
                    if (diagResult == DialogResult.OK)
                    {
                        xss = new XMLSerializingService(saveFileDialog1.FileName,
                            System.IO.FileMode.Create);
                        xss.Export<Entity.Coupon>(
                            new Export<PhotoStore.Entity.Coupon>(
                            blCoupon.Export));
                        
                        //ds.WriteXml(saveFileDialog1.FileName);
                        MessageBox.Show("Exporting Coupon successful");
                        xss.Dispose();
                    }
                    //ds = blCoupon.Export();
                    //if (ds != null)
                    //{
                    //    if (ds.Tables[0].Rows.Count > 0)
                    //    {
                    //        fileName = string.Format("{0}Coupon{1}.xml",
                    //            System.Configuration.ConfigurationManager.AppSettings["BranchCode"].ToString(),
                    //            DateTime.Now.ToString("MMddyyyyhhmmss"));
                    //        saveFileDialog1.FileName = fileName;
                    //        diagResult = saveFileDialog1.ShowDialog();
                    //        if (diagResult == DialogResult.OK)
                    //        {

                    //            ds.WriteXml(saveFileDialog1.FileName);
                    //            MessageBox.Show("Exporting Coupon successful");
                    //        }

                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("No Coupon to export");

                    //    }

                    //}
                    break;
                case "AdminGiftCertificate":
                    fileName = string.Format("{0}GC{1}.xml",
                               System.Configuration.ConfigurationManager.AppSettings["BranchCode"].ToString(),
                               DateTime.Now.ToString("MMddyyyyhhmmss"));
                    saveFileDialog1.FileName = fileName;
                    diagResult = saveFileDialog1.ShowDialog();
                    if (diagResult == DialogResult.OK)
                    {
                        
                        xss = new XMLSerializingService(
                            saveFileDialog1.FileName,
                            System.IO.FileMode.Create);
                        xss.Export<PhotoStore.Entity.GiftCertificate>(
                            new Export<PhotoStore.Entity.GiftCertificate>(
                            blGiftCertificate.Export));
                        MessageBox.Show("Exporting GC successful");
                        xss.Dispose();
                    }
                   
                    // ds = blGiftCertificate.Export();
                    //if (ds != null)
                    //{
                    //    if (ds.Tables[0].Rows.Count > 0)
                    //    {
                    //        fileName=string.Format("{0}GC{1}.xml",
                    //            System.Configuration.ConfigurationManager.AppSettings["BranchCode"].ToString(),
                    //            DateTime.Now.ToString("MMddyyyyhhmmss"));
                    //        saveFileDialog1.FileName = fileName;                                
                    //        diagResult = saveFileDialog1.ShowDialog();
                    //        if (diagResult == DialogResult.OK)
                    //        {
                    //            ds.WriteXml(saveFileDialog1.FileName);                                  
                    //            MessageBox.Show("Exporting GC successful");
                    //        }
                         
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("No GC to export");
                            
                    //    }
                    //}
                    break;
            }
            if (ds != null)
                ds.Dispose();

            ds = null;
        }

        private void UCImportExport_Load(object sender, EventArgs e)
        {
           
        }
    }
}
