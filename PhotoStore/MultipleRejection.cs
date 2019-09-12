using System;
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
    public partial class MultipleRejection : Form
    {
        List<JobOrderDetail> _jobOrderDetails;
        Dictionary<long, bool> _jobOrderDetailIdRejection ;
        bool _hasSelected = false;
        public bool HasSelected
        {
            get { return _hasSelected; }
        }

        public MultipleRejection(List<JobOrderDetail> joborderdetail
            , Dictionary<long, bool> jobOrderDetailIdRejection)
        {
            _jobOrderDetails = joborderdetail;
            _jobOrderDetailIdRejection = jobOrderDetailIdRejection;
            InitializeComponent();
        }
        private void BindData()
        {
            foreach (JobOrderDetail jobOrderDetail in _jobOrderDetails)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells["colJobOrderDetailId"].Value = jobOrderDetail.Id;
                row.Cells["colJobOrderNumber"].Value = jobOrderDetail.JobOrder.Code;
                row.Cells["colParticulars"].Value = jobOrderDetail.OrderDetail.Particulars;
                if (_jobOrderDetailIdRejection != null)
                {
                    row.Cells["colChk"].Value = (_jobOrderDetailIdRejection.ContainsKey(jobOrderDetail.Id)) ?
                        _jobOrderDetailIdRejection[jobOrderDetail.Id]:false;
                }
                gvJobOrderDetail.Rows.Add(row);
                row.Dispose();
                row = null;
            }
        }
        private void MultipleRejection_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow row in gvJobOrderDetail.Rows)
            {
                if (row.Cells["colChk"].Value != null)
                {
                    if ((bool)row.Cells["colChk"].Value)
                    {
                        _hasSelected = true;
                        break;
                    }
                }
            }
            if (!_hasSelected)
            {
                MessageBox.Show("Please select a record");
                return;
            }
            this.Close();
        }

        private void gvJobOrderDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (gvJobOrderDetail.Columns[e.ColumnIndex].Name == "colChk")
                {
                    long jobOrderDetailId=Convert.ToInt64(gvJobOrderDetail.Rows[e.RowIndex].Cells["colJobOrderDetailId"].Value);
                    if (gvJobOrderDetail.Rows[e.RowIndex].Cells["colChk"].EditedFormattedValue != null)
                    {
                        if ((bool)gvJobOrderDetail.Rows[e.RowIndex].Cells["colChk"].EditedFormattedValue)
                        {
                            if (_jobOrderDetailIdRejection.ContainsKey(
                                jobOrderDetailId))
                            {
                                _jobOrderDetailIdRejection[jobOrderDetailId] = true;
                            }
                            else
                            {
                                _jobOrderDetailIdRejection.Add(jobOrderDetailId, true);
                            }
                        }
                        else
                        {
                            if (_jobOrderDetailIdRejection.ContainsKey(
                               jobOrderDetailId))
                            {
                                _jobOrderDetailIdRejection[jobOrderDetailId] = false;
                            }
                            else
                            {
                                _jobOrderDetailIdRejection.Add(jobOrderDetailId, false);
                            }
                        }
                    }
                    else
                    {
                        if (_jobOrderDetailIdRejection.ContainsKey(
                              jobOrderDetailId))
                        {
                            _jobOrderDetailIdRejection[jobOrderDetailId] = false;
                        }
                        else
                        {
                            _jobOrderDetailIdRejection.Add(jobOrderDetailId, false);
                        }
                    }
                    
                }
            }
        }
    }
}