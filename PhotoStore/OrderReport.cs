using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhotoStore.BusinessLogic;
using Microsoft.Reporting.WinForms;
using PhotoStore.Entity;
using PhotoStore.UtilityServices.Printing;
namespace PhotoStore
{
    public partial class OrderReport : Form
    {
        long _OrderTransactionId;
        //blOrderTransaction _OrderTransactionBl;
        public OrderReport(long ordertransactionid)
        {
            _OrderTransactionId = ordertransactionid;
            //_OrderTransactionBl = new blOrderTransaction();
            InitializeComponent();
        }

        private void OrderReport_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "PhotoStore.OrderReport.rdlc";
            string[] dataTableNames = new string[] { "Report_Customers"
                                                    ,"Report_OrderStatus"
                                                    ,"Report_OrderTransaction"
                                                    ,"Report_OrderTransactionDetailList"
                                                    ,"Report_OrderTransactionModifiedByList"
                                                    ,"Report_OrderTransactionPaymentList"
                                                    ,"Report_PreparedByEmployeeEntity"
                                                    };

            OrderTransaction orderTransactionEntity = blOrderTransaction.retrieve(_OrderTransactionId);
            

            foreach (string dataTableName in dataTableNames)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = dataTableName;
                switch (dataTableName)
                {
                    case "Report_Customers":
                        List<PhotoStore.Entity.Customer> customers = new List<PhotoStore.Entity.Customer>();
                        customers.Add(orderTransactionEntity.CustomerEntity);
                        rds.Value = customers;
                        break;
                    case "Report_OrderStatus":
                        List<OrderStatus> orderStatus = new List<OrderStatus>();
                        orderStatus.Add(orderTransactionEntity.OrderStatusEntity);
                        rds.Value = orderStatus;
                        break;
                    case "Report_OrderTransaction":
                        List<OrderTransaction> orderTransactions=new List<OrderTransaction>();
                        orderTransactions.Add(orderTransactionEntity);
                        rds.Value = orderTransactions;
                        break;
                    case "Report_OrderTransactionDetailList":
                        rds.Value = orderTransactionEntity.OrderTransactionDetailList;
                        break;
                    case "Report_OrderTransactionModifiedByList":
                        rds.Value = orderTransactionEntity.OrderTransactionModifiedByList;
                        break;
                    case "Report_OrderTransactionPaymentList":
                        rds.Value = orderTransactionEntity.OrderTransactionPaymentList;
                        break;
                    default:
                        List<Employee> employees=new List<Employee>();
                        employees.Add(orderTransactionEntity.PreparedByEmployeeEntity);
                        rds.Value=employees;
                        break;
                }
                
                reportViewer1.LocalReport.DataSources.Add(rds);
               
                rds = null;
                
            }
            List<ReportParameter> reportParameters = new List<ReportParameter>();
            reportParameters.Add(new ReportParameter("OrderStatusId", orderTransactionEntity.OrderStatusId.ToString()));
            reportViewer1.LocalReport.SetParameters(reportParameters);

            Printing printing = new Printing(Application.StartupPath);
            printing.Run("Order", reportViewer1.LocalReport);
            printing.Dispose();

            //List<ReportParameter> parameters = new List<ReportParameter>();
            //reportViewer1.LocalReport.EnableExternalImages = true;
            //string logoPath = string.Concat(Application.StartupPath, "\\logo outline.png");
            //parameters.Add(new ReportParameter("ImagePath", "logo outline.png"));
            //reportViewer1.LocalReport.SetParameters(parameters);

            this.reportViewer1.RefreshReport();
            this.Close();
            
            
        }
    }
}