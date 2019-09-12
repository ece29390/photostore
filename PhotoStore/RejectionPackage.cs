using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhotoStore.Entity;
using PhotoStore.BusinessLogic;
using System.Configuration;
namespace PhotoStore
{
    public partial class RejectionPackage : Form
    {
        long  _orderDetailsId;
        Dictionary<long, bool> _queuedForRejection;
        public RejectionPackage(long orderdetailsid,
            Dictionary<long,bool> queuedforrejection)
        {
            _orderDetailsId = orderdetailsid;
            _queuedForRejection = queuedforrejection;
            InitializeComponent();
        }

      

        private void RejectionPackage_Load(object sender, EventArgs e)
        {
           // if(!Convert.ToBoolean(ConfigurationManager.AppSettings["OrderTransactionDetail"]))
                BindData();

        }
        private void BindOrderPackageData()
        {
            if (gvPackage.RowCount > 0)
            {
                foreach (DataGridViewRow row in gvPackage.Rows)
                {
                    long orderPackageDetailsId = Convert.ToInt64(row.Cells["colOrderPackageDetailsId"].Value);
                    if (_queuedForRejection.ContainsKey(orderPackageDetailsId
                        ))
                    {
                        if (_queuedForRejection[orderPackageDetailsId])
                        {
                            row.Cells["colChk"].Value = true;
                        }
                    }
                }
            }
            else
            {
                btnAdd.Enabled = false;
            }
        }
        private void BindJobOrderData()
        {
            if (gvPackage.RowCount > 0)
            {
                foreach (DataGridViewRow row in gvPackage.Rows)
                {
                    //long jobOrderDetailId = Convert.ToInt64(row.Cells["colJobDetailsId"].Value);
                    //if (_queuedForRejection.ContainsKey(jobOrderDetailId
                    //    ))
                    //{
                    //    if (_queuedForRejection[jobOrderDetailId])
                    //    {
                    //        row.Cells["colChk"].Value = true;
                    //    }
                    //}
                    OrderPackageDetails op = (OrderPackageDetails)row.DataBoundItem;
                    if (op != null)
                    {
                        if (_queuedForRejection.ContainsKey(op.Id))
                        {
                            if (_queuedForRejection[op.Id])
                            {
                                row.Cells["colChk"].Value = true;
                            }
                        }
                    }
                    op = null;

                }
            }
            else
            {
                btnAdd.Enabled = false;
            }
        }

        private void BindData()
        {
            gvPackage.AutoGenerateColumns = false;
            BindingSource bs = UI.BindSource(blOrderPackageDetails.GetDoneOrderPackage(
                _orderDetailsId), false);
            gvPackage.DataSource = bs;
            //Set the checkbox depending on the item on _queuedForRejection
            //if (!Convert.ToBoolean(ConfigurationManager.AppSettings["OrderTransactionDetail"]))
            //{
                BindJobOrderData();
            //}
            //else
            //{
            //    BindOrderPackageData();
            //}

        }
        bool _itemSelected = false;
        public bool ItemSelected
        {
            get
            {

                return _itemSelected;
            }
        }
        private void ValidateProcess()
        {
            foreach (DataGridViewRow row in gvPackage.Rows)
            {
                if (row.Cells["colChk"].Value != null)
                {
                   
                    if ((bool)row.Cells["colChk"].Value)
                    {
                        _itemSelected = true;
                        break;
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ValidateProcess();
            //if (_itemSelected)
            //{
                foreach (DataGridViewRow row in gvPackage.Rows)
                {
                    long orderPackageDetailId = Convert.ToInt64(row.Cells["colOrderPackageDetailsId"].Value);
                    if ((bool)row.Cells["colChk"].EditedFormattedValue)
                    {
                        
                        if (_queuedForRejection.ContainsKey(orderPackageDetailId))
                        {
                            _queuedForRejection[orderPackageDetailId] = true;
                        }
                        else
                        {
                            _queuedForRejection.Add(orderPackageDetailId, true);
                        }
                    }
                    else
                    {
                        if (_queuedForRejection.ContainsKey(orderPackageDetailId))
                        {
                            _queuedForRejection[orderPackageDetailId] = false;
                        }
                    }
                }
                  this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Please select one or more items\r\nor press the X button if you want to exit this form");
            //}
          
                
        }

        private void RejectionPackage_FormClosing(object sender, FormClosingEventArgs e)
        {
            ValidateProcess();
        }

        //private void gvPackage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex != -1)
        //    {
        //        if (gvPackage.Columns[e.ColumnIndex].Name == "colChk")
        //        {
        //            //if (!Convert.ToBoolean(ConfigurationManager.AppSettings["OrderTransactionDetail"]))
        //            //{
        //                long jobDetailsId = Convert.ToInt64(gvPackage.Rows[e.RowIndex].Cells["colJobDetailsId"].Value);
        //                if ((bool)gvPackage.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue)//if check
        //                {
        //                    if (_queuedForRejection.ContainsKey(jobDetailsId))
        //                    {
        //                        _queuedForRejection[jobDetailsId] = true;
        //                    }
        //                    else
        //                    {
        //                        _queuedForRejection.Add(jobDetailsId, true);
        //                    }
        //                }
        //                else
        //                {
        //                    if (_queuedForRejection.ContainsKey(jobDetailsId))
        //                    {
        //                        _queuedForRejection[jobDetailsId] = false;
        //                    }
        //                    else
        //                    {
        //                        _queuedForRejection.Add(jobDetailsId, false);
        //                    }
        //                }
        //            //}
        //            //else
        //            //{
        //            //    long orderPackageDetailId = Convert.ToInt64(gvPackage.Rows[e.RowIndex].Cells["colOrderPackageDetailsId"].Value);
        //            //    if ((bool)gvPackage.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue)//if check
        //            //    {
        //            //        if (_queuedForRejection.ContainsKey(orderPackageDetailId))
        //            //        {
        //            //            _queuedForRejection[orderPackageDetailId] = true;
        //            //        }
        //            //        else
        //            //        {
        //            //            _queuedForRejection.Add(orderPackageDetailId, true);
        //            //        }
        //            //    }
        //            //    else
        //            //    {
        //            //        if (_queuedForRejection.ContainsKey(orderPackageDetailId))
        //            //        {
        //            //            _queuedForRejection[orderPackageDetailId] = false;
        //            //        }
        //            //        else
        //            //        {
        //            //            _queuedForRejection.Add(orderPackageDetailId, false);
        //            //        }
        //            //    }
        //            //}
        //        }
        //    }
        //}
    }
}