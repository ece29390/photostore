using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace PhotoStore
{
    public partial class PrintSalesReport : Form
    {
        string _mode;
        object _dataSource;
        DateTime _dateFrom, _dateTo;
        List<ReportParameter> _parameter = new List<ReportParameter>();
        public PrintSalesReport(string mode,
            object datasource,DateTime datefrom,DateTime dateto)
        {
            InitializeComponent();
            _mode = mode;
            _dataSource = datasource;
            _dateFrom = datefrom;
            _dateTo = dateto;

            ReportParameter rpDateFrom = new ReportParameter("DateFrom", _dateFrom.ToString("MM/dd/yyyy"));
            ReportParameter rpDateTo = new ReportParameter("DateTo", _dateTo.ToString("MM/dd/yyyy"));

            _parameter.Add(rpDateFrom);
            _parameter.Add(rpDateTo);

        }
        private DataTable GetTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DateFrom", typeof(DateTime));
            dt.Columns.Add("DateTo", typeof(DateTime));
            return dt;
        }
        private void PrintSalesReport_Load(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource();
            switch (_mode)
            {
                case "Report_Sales_Report":                                      
                    reportViewer1.LocalReport.ReportEmbeddedResource = "PhotoStore.SalesReport.rdlc";                                            
                    rds.Name = _mode;
                    rds.Value = _dataSource;
                    reportViewer1.LocalReport.SetParameters(_parameter);
                    reportViewer1.LocalReport.DataSources.Add(rds);
                    rds = null;
                  break;
                case "Report_Sales_Rejected":
                    reportViewer1.LocalReport.ReportEmbeddedResource = "PhotoStore.RejectedSales.rdlc";
                   
                    rds.Name = _mode;
                    rds.Value = _dataSource;
                    reportViewer1.LocalReport.SetParameters(_parameter);
                    reportViewer1.LocalReport.DataSources.Add(rds);
                    break;
                case "Report_Sales_ProductType":
                    reportViewer1.LocalReport.ReportEmbeddedResource = "PhotoStore.ProductType.rdlc";

                    rds.Name = _mode;
                    rds.Value = _dataSource;
                    reportViewer1.LocalReport.SetParameters(_parameter);
                    reportViewer1.LocalReport.DataSources.Add(rds);
                    break;
                case "Report_Sale_Balances":
                    reportViewer1.LocalReport.ReportEmbeddedResource = "PhotoStore.BalanceReport.rdlc";

                    rds.Name = _mode;
                    rds.Value = _dataSource;
                    reportViewer1.LocalReport.SetParameters(_parameter);
                    reportViewer1.LocalReport.DataSources.Add(rds);
                    break;
                case "Report_Sale_GiftCertificate":
                    reportViewer1.LocalReport.ReportEmbeddedResource = "PhotoStore.GiftCertificateSales.rdlc";

                    rds.Name = _mode;
                    rds.Value = _dataSource;
                    reportViewer1.LocalReport.SetParameters(_parameter);
                    reportViewer1.LocalReport.DataSources.Add(rds);
                    break;
                case "Report_Sale_Coupon":
                    reportViewer1.LocalReport.ReportEmbeddedResource = "PhotoStore.CouponSales.rdlc";

                    rds.Name = _mode;
                    rds.Value = _dataSource;
                    reportViewer1.LocalReport.SetParameters(_parameter);
                    reportViewer1.LocalReport.DataSources.Add(rds);
                    break;
                case "Report_Detailed_Sales_Report":
                    reportViewer1.LocalReport.ReportEmbeddedResource = "PhotoStore.DetailedSalesReport.rdlc";

                    rds.Name = _mode;
                    rds.Value = _dataSource;
                    reportViewer1.LocalReport.SetParameters(_parameter);
                    reportViewer1.LocalReport.DataSources.Add(rds);
                    break;
            }


            //ReportPageSettings rps = reportViewer1.LocalReport.GetDefaultPageSettings();
            //reportViewer1.UseWaitCursor = true;
           // this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.RefreshReport();
        }
    }
}