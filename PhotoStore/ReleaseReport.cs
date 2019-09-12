using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using PhotoStore.BusinessLogic;
namespace PhotoStore
{
    public partial class ReleaseReport : Form
    {
      
       // string _jobordernumber;
        long _id;
        bool _isauto;
        Entity.JobOrder _jobOrder;
        public ReleaseReport(long id,bool isauto)//string jobordernumber)
        {
            //_jobordernumber = jobordernumber;
            InitializeComponent();
            _id = id;
            _isauto = isauto;
        }
        private List<Entity.JobOrderReport> _jobOrderReports = new List<PhotoStore.Entity.JobOrderReport>();
        private void ReleaseReport_Load(object sender, EventArgs e)
        {

            BindCombo();
            
            if (cboJobOrder.Items.Count == 0)
                btnReleaseReport.Enabled = false;

            if (_id != -1)
            {
                //cboJobOrder.SelectedValue = _id;
                for (int i = 0; i < cboJobOrder.Items.Count; i++)
                {
                    PhotoStore.Entity.JobOrder jo = (PhotoStore.Entity.JobOrder)cboJobOrder.Items[i];
                    if (jo.Id == _id)
                    {
                        cboJobOrder.SelectedIndex = i;
                        break;
                    }
                    jo = null;
                }

                
            }
            if (_isauto)
            {
                ExecutePrinting();
            }
        }
        int count = 0;
        private void LocalReport_SubreportProcessing(object sender, Microsoft.Reporting.WinForms.SubreportProcessingEventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportDataSource rds = new Microsoft.Reporting.WinForms.ReportDataSource(
                "Report_JobOrderParticulars", _jobOrderReports[count].Particulars);
            e.DataSources.Add(rds);
            count = count + 1;
            if (count == _jobOrderReports.Count)
                count = 0;
            rds = null;
        }
        private void BindCombo()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = blJobOrder.retrieve();
            bs.ResetBindings(false);
            cboJobOrder.DisplayMember = "Code";
            cboJobOrder.ValueMember = "Id";
            cboJobOrder.DataSource = bs;
        }
        private void ExecutePrinting()
        {
            _jobOrder = blJobOrder.retrieve(_id);
            this.reportViewer1.Reset();
            this.reportViewer1.LocalReport.SubreportProcessing += new Microsoft.Reporting.WinForms.SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
            reportViewer1.LocalReport.ReportEmbeddedResource = "PhotoStore.ReleaseReport.rdlc";
            Microsoft.Reporting.WinForms.ReportDataSource rds = new Microsoft.Reporting.WinForms.ReportDataSource();
            rds.Name = "Report_JobOrderReport";
            _jobOrderReports = blJobOrder.GetJobOrderReport(_id);
            rds.Value = _jobOrderReports;
            reportViewer1.LocalReport.DataSources.Add(rds);
            Microsoft.Reporting.WinForms.ReportParameter[] parameters = new Microsoft.Reporting.WinForms.ReportParameter[2]{
                new Microsoft.Reporting.WinForms.ReportParameter("JODate",_jobOrder.TransactionDate.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("JONumber",_jobOrder.Code)};
            reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
            
        }

        private void cboJobOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
        }

        private void btnReleaseReport_Click(object sender, EventArgs e)
        {
            _id = Convert.ToInt64(cboJobOrder.SelectedValue);
            ExecutePrinting();
        }

        
    }
}