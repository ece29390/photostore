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
    public partial class AdminSales : Form
    {
        public AdminSales()
        {
            InitializeComponent();
        }

        private bool IsValid()
        {
            return dtpFrom.Value <= dtpTo.Value;
        }

        private void GetReports(bool isview)
        {
            if (!IsValid())
            {
                MessageBox.Show("Start Date must not exceed the End Date", "Invalid Search Criteria",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DateTime startDate = Convert.ToDateTime(dtpFrom.Value.ToShortDateString());
            DateTime endDate = Convert.ToDateTime(string.Concat(
                dtpTo.Value.ToShortDateString(), " ", "11:59:59 PM"));

            if (tbReports.SelectedTab == tbPageSalesReport)
            {
                dgvSalesReport.DataSource = null;
                dgvSalesReport.AutoGenerateColumns = false;
                List<PhotoStore.Entity.SalesReport> salesReports = (new SaleReportFactory()).CreateProduct().GetData(
                    startDate, endDate);
                double totalSale = 0;
                foreach (PhotoStore.Entity.SalesReport salesReport in salesReports)
                {
                    totalSale = totalSale + (salesReport.Cash + salesReport.ATMReceived + salesReport.CCReceived+salesReport.Check);
                }

                dgvSalesReport.DataSource = UI.BindSource(salesReports, false);
                lblTotalSales.Text = totalSale.ToString("#,###.00");

                if (isview)
                {
                    PrintSalesReport frm = new PrintSalesReport("Report_Sales_Report",
                        salesReports,
                        startDate, endDate);
                    frm.ShowDialog();
                    frm.Dispose();
                    frm = null;
                }
            }
            else if (tbReports.SelectedTab == tbPageRejected)
            {
                dgvRejected.DataSource = null;
                dgvRejected.AutoGenerateColumns = false;
                List<RejectedReport> rejectedReports =
                    (new RejectedReportFactory()).CreateProduct().GetData(startDate, endDate);
                dgvRejected.DataSource = UI.BindSource(rejectedReports, false);
                if (isview)
                {
                    PrintSalesReport frm = new PrintSalesReport("Report_Sales_Rejected",
                        rejectedReports,
                        startDate, endDate);
                    frm.ShowDialog();
                    frm.Dispose();
                    frm = null;
                }
            }
            else if (tbReports.SelectedTab == tbPageProductType)
            {
                dgvProductTypeSales.DataSource = null;
                dgvProductTypeSales.AutoGenerateColumns = false;
                List<ProductTypeReport> productTypeReports =
                    new ProductTypeReportFactory().CreateProduct().GetData(startDate, endDate, cboProductType.SelectedValue);
                dgvProductTypeSales.DataSource = UI.BindSource(productTypeReports, false);
                if (isview)
                {
                    PrintSalesReport frm = new PrintSalesReport("Report_Sales_ProductType",
                        productTypeReports,
                        startDate, endDate);
                    frm.ShowDialog();
                    frm.Dispose();
                    frm = null;
                }
            }
            else if (tbReports.SelectedTab == tbPageBalance)
            {
                dgvBalance.DataSource = null;
                dgvBalance.AutoGenerateColumns = false;
                List<BalanceReport> balanceReports =
                    new BalanceReportFactory().CreateProduct().GetData(
                    startDate, endDate, txtMommysName.Text,
                   EnumReader.GetDescription(_direction),
                   _columnToBeSorted);
                dgvBalance.DataSource = UI.BindSource(balanceReports, false);
                if (isview)
                {
                    PrintSalesReport frm = new PrintSalesReport("Report_Sale_Balances",
                        balanceReports,
                        startDate, endDate);
                    frm.ShowDialog();
                    frm.Dispose();
                    frm = null;
                }
            }
            else if (tbReports.SelectedTab == tbPageGCReport)
            {
                dgvGCReport.DataSource = null;
                dgvGCReport.AutoGenerateColumns = false;
                List<GiftCertificateReport> giftCertificateReports =
                    new GiftCertificateReportFactory().CreateProduct().GetData(
                    startDate, endDate);
                dgvGCReport.DataSource = giftCertificateReports;
                if (isview)
                {
                    PrintSalesReport frm = new PrintSalesReport("Report_Sale_GiftCertificate",
                        giftCertificateReports,
                        startDate, endDate);
                    frm.ShowDialog();
                    frm.Dispose();
                    frm = null;
                }
            }
            else if (tbReports.SelectedTab == tbPageCouponReport)
            {
                dgvCouponReport.DataSource = null;
                dgvCouponReport.AutoGenerateColumns = false;
                List<CouponReport> couponReports =
                    new CouponReportFactory().CreateProduct().GetData(
                    startDate, endDate);
                dgvCouponReport.DataSource = UI.BindSource(couponReports, false);
                if (isview)
                {
                    PrintSalesReport frm = new PrintSalesReport("Report_Sale_Coupon",
                        couponReports,
                        startDate, endDate);
                    frm.ShowDialog();
                    frm.Dispose();
                    frm = null;
                }
            }
            else if (tbReports.SelectedTab == tbPageDetailedSalesReport)
            {
                gvDetailedSalesReport.DataSource = null;
                gvDetailedSalesReport.AutoGenerateColumns = false;
                List<DetailedSalesReport> detailedSalesReport = new DetailedSalesReportFactory().CreateProduct().GetData(
                    startDate, endDate);
                gvDetailedSalesReport.DataSource = UI.BindSource(detailedSalesReport, false);
                if (isview)
                {
                    PrintSalesReport frm = new PrintSalesReport("Report_Detailed_Sales_Report",
                        detailedSalesReport,
                        startDate,
                        endDate);
                    frm.ShowDialog();
                    frm.Dispose();
                    frm = null;
                }
            }
            else if (tbReports.SelectedTab == tbGCRedeemed)
            {
                this.dgvGCTypeRedeemed.DataSource = null;
                dgvGCTypeRedeemed.AutoGenerateColumns = false;
                List<GiftCertificateReport> giftCertificateReports =
                    new GiftCertificateReportRedeemedFactory().CreateProduct().GetData(
                    startDate, endDate);
                dgvGCTypeRedeemed.DataSource = giftCertificateReports;
                if (isview)
                {
                    PrintSalesReport frm = new PrintSalesReport("Report_Sale_GiftCertificate",
                        giftCertificateReports,
                        startDate, endDate);
                    frm.ShowDialog();
                    frm.Dispose();
                    frm = null;
                }
            }
            else if (tbReports.SelectedTab == tbCouponRedeemed)
            {
                this.dgvCouponTypeRedeemed.DataSource = null;
                dgvCouponTypeRedeemed.AutoGenerateColumns = false;
                List<CouponReport> couponReports =
                    new CouponReportRedeemedFactory().CreateProduct().GetData(
                    startDate, endDate);
                dgvCouponTypeRedeemed.DataSource = UI.BindSource(couponReports, false);
                if (isview)
                {
                    PrintSalesReport frm = new PrintSalesReport("Report_Sale_Coupon",
                        couponReports,
                        startDate, endDate);
                    frm.ShowDialog();
                    frm.Dispose();
                    frm = null;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetReports(false);                                  
        }

        private void tbReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboProductType.Enabled = (tbReports.SelectedTab == tbPageProductType);
            this.txtMommysName.Enabled = (tbReports.SelectedTab == tbPageBalance);
        }

        private void AdminSales_Load(object sender, EventArgs e)
        {
            cboProductType.ValueMember = "Id";
            cboProductType.DisplayMember = "Description";
            cboProductType.DataSource = UI.BindSource(
                blParticularType.retrieveParticularLessGCCoupon(), false);
            txtMommysName.Enabled = false;
            //cboCustomer.ValueMember = "Id";
            //cboCustomer.DisplayMember = "MothersName";
            //cboCustomer.DataSource = UI.BindSource(
            //    blCustomer.customerForComboBox(true), false);
            //Entity.Customer customer = new PhotoStore.Entity.Customer();
            //customer.Id = -1;
            //customer.MothersName = "";
            //cboCustomer.Items.Insert(0, customer);

          
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            GetReports(true);
        }
        string _columnToBeSorted="DateCreated";
        Direction _direction = Direction.DESC;
        private void dgvBalance_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _direction = _direction == Direction.ASC ? Direction.DESC : Direction.ASC;
            switch (dgvBalance.Columns[e.ColumnIndex].DataPropertyName)
            {
                case "DateCreated":
                    _columnToBeSorted = dgvBalance.Columns[e.ColumnIndex].DataPropertyName;
                    break;
                case "Code":
                    _columnToBeSorted = "OrderNumber";
                    break;
                case "MothersName":
                    _columnToBeSorted = "MommysName";
                    break;
                case "BalanceDue":
                    _columnToBeSorted = "(vwBalanceReport.TotalPrice-vwBalanceReport.TotalPayment)";
                    break;
            }
            GetReports(false);
        }
    }
}