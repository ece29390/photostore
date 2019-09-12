using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhotoStore.BusinessLogic;
using PhotoStore.Entity;
using Microsoft.Reporting.WinForms;
namespace PhotoStore
{
    public partial class PrintForm : Form                                       
    {
        string _embeddedResourceName, _dataSourceName;
        object _dataSource;
        
        public PrintForm(object dataSource,
            string embeddedResourceName,string dataSourceName)
        {
            InitializeComponent();
            _dataSource = dataSource;
            _embeddedResourceName = embeddedResourceName;
            _dataSourceName = dataSourceName;
        }
        
        private void PrintForm_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = _embeddedResourceName;
            ReportDataSource rds = new ReportDataSource();
          
            rds.Name = _dataSourceName;
            rds.Value = _dataSource;
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}