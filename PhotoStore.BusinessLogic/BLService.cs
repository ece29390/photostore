using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PhotoStore.Entity;
using PhotoStore.DataAccess;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace PhotoStore.BusinessLogic
{
    public class BLService
    {
        public static List<vwParticularsForRejection> RetrieveParticularAllowedForRejection(
            string code)
        {
            List<vwParticularsForRejection> retValue = new List<vwParticularsForRejection>();
            using (DataSet ds = daHelper.executeSelect(
                string.Format("SELECT * FROM vwParticularsForRejection WHERE IsDone=1 AND Code='{0}'",
                                        code)))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        vwParticularsForRejection vpfr = new vwParticularsForRejection(dr);
                        retValue.Add(vpfr);
                        vpfr = null;
                    }
                }
            }

            
            return retValue;
        }
        

        private static bool ValidateRejectedQuantity(DataGridView gv,
            string columnquantity, string rejectedquantity, Dictionary<int, bool> selectedindexes)
        {
            bool isValid = true;
            foreach (int key in selectedindexes.Keys)
            {
                if (selectedindexes[key])
                {
                    if (Convert.ToInt32(
                        gv.Rows[key].Cells[rejectedquantity].EditedFormattedValue) == 0)
                    {
                        isValid = false;
                        gv.Rows[key].Cells[rejectedquantity].Style.BackColor = System.Drawing.Color.Aqua;
                        break;
                    }
                    

                    if (Convert.ToInt32(
                        gv.Rows[key].Cells[rejectedquantity].EditedFormattedValue) >
                        Convert.ToInt32(
                        gv.Rows[key].Cells[columnquantity].Value))
                    {
                        isValid = false;
                        gv.Rows[key].Cells[rejectedquantity].Style.BackColor = System.Drawing.Color.Aqua;
                        break;
                    }
                    
                    
                }
            }
            return isValid;
        }
        public static void KeyPressNumeric(TextBox txt,
            KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar == 46) || e.KeyChar == 8)
            {
                if (e.KeyChar.ToString() == ".")
                {
                    if (txt.Text.Contains("."))
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = false;
                    }
                }

            }
            else
            {
                e.Handled = true;
            }
        }

        public static string RejectParticulars(DataGridView gv,
            string columnid, string columnquantity,string rejectedquantity, Dictionary<int, bool> selectedindexes
            
            )
        {
           
            if (!ValidateRejectedQuantity(gv, columnquantity, rejectedquantity, selectedindexes))
            {
                return "Atleast one particular has a rejected quantity larger than the consumed quantity or 0 value";
            }

            foreach (int key in selectedindexes.Keys)
            {
                if (selectedindexes[key])
                {
                    using (SqlCommand cmd = new SqlCommand(
                        string.Format(
                        "EXEC [dbo].[spuJobOrders] \r\n@Mode='REJECT',@Id={0},@RejectedQuantity={1}",
                        Convert.ToInt64(
                        gv.Rows[key].Cells[columnid].Value),
                        Convert.ToInt32(gv.Rows[key].Cells[rejectedquantity].Value))))
                    {
                        daHelper.executeNonQuery(cmd);
                    }
                    gv.Rows[key].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                }
            }
           
            return "Particular(s) successfully rejected";
        }

        public static void ApplyColor(System.Drawing.Color color, DataGridView gv, Dictionary<int, bool> selectedindexes)
        {
            foreach (int key in selectedindexes.Keys)
            {
                if (selectedindexes[key])
                {

                    gv.Rows[key].DefaultCellStyle.BackColor = color;
                }
            }
        }

        public static bool HasDiscount(DataGridView gv)
        {
            bool retValue = false;
            foreach (DataGridViewRow row in gv.Rows)
            {
                if (row.Cells["colAdjustment"].Value != null)
                {
                    decimal discount = 0;
                    decimal.TryParse(row.Cells["colAdjustment"].Value.ToString(), out discount);
                    if (discount > 0)
                    {
                        retValue = true;
                        break;
                    }
                }
            }
            return retValue;
        }
        public static void ComputeBankFee(out double bankFee,
            out double amountPaid,bool hasdiscount,int currentIndex,long paymentTypeId,double amountReceived,
            DataGridView gvOrderTransactionPayment)
        {

            amountPaid = amountReceived;
            bankFee = 0;
            if (!hasdiscount)
            {
                amountPaid = amountReceived;
                switch (paymentTypeId)
                {
                    case 3://ATM                       
                        bankFee = amountReceived * Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["ATMFee"]);
                        break;
                    case 4://Credit Card
                        bankFee = amountReceived * Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["CCFee"]);
                        break;
                    default:
                        bankFee = 0;
                        break;
                }
            }
            else
            {

                if (currentIndex== 0)//if true it means first payment
                {
                    amountPaid = amountReceived;
                    switch (paymentTypeId)
                    {
                        case 3://ATM                            
                            bankFee = amountReceived * Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["ATMFee"]);
                            break;
                        case 4://Credit Card
                            bankFee = amountReceived * Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["CCFee"]);
                            break;
                        default:
                            bankFee = 0;
                            break;
                    }
                }
                else//other wise 2nd or onwards payment
                {

                    switch (paymentTypeId)
                    {
                        case 3://ATM     
                            amountPaid = amountReceived;
                            bankFee = amountReceived * Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["ATMFee"]);
                            break;
                        case 4://Credit Card
                            bool hasCreditCard = false;
                            if (gvOrderTransactionPayment != null)
                            {
                                //List<OrderTransactionPayment> payments = blOrderTransactionPayment.retrieveByOrderTransactionId(ordertransactionid);
                                //for (int i = 0; i < currentIndex; i++)
                                //{
                                //    if (payments[i].PaymentTypeId == 4)
                                //    {
                                //        hasCreditCard = true;
                                //        break;
                                //    }
                                //}
                                for (int i = 0; i < currentIndex; i++)
                                {
                                    if (Convert.ToInt64(gvOrderTransactionPayment.Rows[i].Cells["colPaymentTypeId"].Value) == 4)
                                    {
                                        hasCreditCard = true;
                                        break;
                                    }
                                }
                            }
                            //else
                            //{
                            //    for (int i = 0; i < currentIndex; i++)
                            //    {
                            //        if (Convert.ToInt64(gvOrderTransactionPayment.Rows[i].Cells["colPaymentTypeId"].Value) == 4)
                            //        {
                            //            hasCreditCard = true;
                            //            break;
                            //        }
                            //    }
                               
                            //}

                            if (!hasCreditCard)
                            {
                            
                                WithCreditCardPayment(amountReceived, out amountPaid, out bankFee);
                            }
                            else
                            {
                                if (Convert.ToInt64(gvOrderTransactionPayment.Rows[0].Cells["colPaymentTypeId"].Value) != 4)
                                {
                                    WithCreditCardPayment(amountReceived, out amountPaid, out bankFee);
                                }
                                else
                                {
                                    amountPaid = amountReceived;
                                    bankFee = amountReceived * Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["CCFee"]);
                                }
                               
                            }
                            break;
                        default:
                           amountPaid = amountReceived;
                           bankFee = 0;
                            break;
                    }
                }
            }
        }
        public static void ComputeBankFee(TextBox txtAmountPaid, TextBox txtBankFee,
            long paymentTypeId, TextBox txtAmountReceived, bool hasdiscount
            , int rowIndex, DataGridView gvOrderTransactionPayment)
        {
            double amountReceived;            
            double.TryParse(txtAmountReceived.Text.Trim(),out amountReceived);
            double bankFee = 0.0;
            double amountPaid = 0.0;
            ComputeBankFee(out bankFee, out amountPaid, hasdiscount, rowIndex,
                paymentTypeId, amountReceived,gvOrderTransactionPayment);
            txtAmountPaid.Text = amountPaid.ToString("#,###.00");
            txtBankFee.Text = bankFee.ToString("#,###.00");
            //if (!hasdiscount)
            //{

            //    txtAmountPaid.Text = txtAmountReceived.Text.Trim();
            //    switch (paymentTypeId)
            //    {
            //        case 3://ATM   
            //            bankFee = amountReceived * Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["ATMFee"]);                     
            //            break;
            //        case 4://Credit Card                                               
            //            bankFee = amountReceived * Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["CCFee"]);
            //            break;
            //        default:
            //            bankFee = 0.0;
            //            break;
            //    }
            //}
            //else
            //{

            //    if (rowIndex==0)//if true it means first payment
            //    {
            //        txtAmountPaid.Text = amountReceived.ToString("#,###.00");
            //        switch (paymentTypeId)
            //        {
            //            case 3://ATM                            
            //                bankFee = amountReceived * Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["ATMFee"]);
            //                break;
            //            case 4://Credit Card
            //                bankFee = amountReceived * Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["CCFee"]);
            //                break;
            //            default:
            //                bankFee = 0.0;
            //                break;
            //        }
            //    }
            //    else//other wise 2nd or onwards payment
            //    {

            //        switch (paymentTypeId)
            //        {
            //            case 3://ATM     
            //                txtAmountPaid.Text = amountReceived.ToString("#,###.00");                            
            //                bankFee = amountReceived * Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["ATMFee"]);
            //                break;
            //            case 4://Credit Card
            //                bool hasCreditCard = false;
            //                for (int i = 0; i < rowIndex; i++)
            //                {
            //                    if (Convert.ToInt64(gvOrderTransactionPayment.Rows[i].Cells["colPaymentTypeId"].Value) == 4)
            //                    {
            //                        hasCreditCard = true;
            //                        break;
            //                    }
            //                }

            //                if (!hasCreditCard)
            //                {
            //                    double denom = (1 - Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["CCFee"]));
            //                    double ccAmountPaid = amountReceived / denom;
            //                    txtAmountPaid.Text = ccAmountPaid.ToString("#,###.00");
            //                    bankFee = ccAmountPaid * Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["CCFee"]);
            //                }
            //                else
            //                {
            //                    txtAmountPaid.Text = amountReceived.ToString("#,###.00");
            //                    bankFee = amountReceived * Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["CCFee"]);
            //                }
            //                break;
            //            default:
            //                txtAmountPaid.Text= amountReceived.ToString("#,###.00");
            //               bankFee = 0.0;
            //                break;
            //        }
            //    }
            //}
            //txtBankFee.Text = bankFee.ToString("#,###.00");
        }

        private static void WithCreditCardPayment(double amountReceived,
            out double amountPaid,out double bankFee)
        {
            double denom = (1 - Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["CCFee"]));
            double ccAmountPaid = amountReceived / denom;
            amountPaid = ccAmountPaid;
            bankFee = ccAmountPaid * Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["CCFee"]);
        }

        public static void ComputeBankFeeFromList(out double bankFee,
            out double amountPaid, bool hasdiscount, int currentIndex, long ordertransactionid, long paymentTypeId, double amountReceived,
            List<Entity.OrderTransactionPayment> paymentList)
        {

            amountPaid = amountReceived;
            bankFee = 0;
            if (!hasdiscount)
            {
                amountPaid = amountReceived;
                switch (paymentTypeId)
                {
                    case 3://ATM                       
                        bankFee = amountReceived * Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["ATMFee"]);
                        break;
                    case 4://Credit Card
                        bankFee = amountReceived * Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["CCFee"]);
                        break;
                    default:
                        bankFee = 0;
                        break;
                }
            }
            else
            {

                if (currentIndex == 0)//if true it means first payment
                {
                    amountPaid = amountReceived;
                    switch (paymentTypeId)
                    {
                        case 3://ATM                            
                            bankFee = amountReceived * Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["ATMFee"]);
                            break;
                        case 4://Credit Card
                            bankFee = amountReceived * Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["CCFee"]);
                            break;
                        default:
                            bankFee = 0;
                            break;
                    }
                }
                else//other wise 2nd or onwards payment
                {

                    switch (paymentTypeId)
                    {
                        case 3://ATM     
                            amountPaid = amountReceived;
                            bankFee = amountReceived * Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["ATMFee"]);
                            break;
                        case 4://Credit Card
                            bool hasCreditCard = false;
                           
                                for (int i = 0; i < currentIndex; i++)
                                {
                                    if (paymentList.Count ==currentIndex)
                                    {
                                        if (paymentList[currentIndex-1].PaymentTypeId == 4)
                                        //Convert.ToInt64(gvOrderTransactionPayment.Rows[i].Cells["colPaymentTypeId"].Value) == 4)
                                        {
                                            hasCreditCard = true;
                                            break;
                                        }
                                    }
                                    else if (paymentList.Count > currentIndex)
                                    {
                                        if (paymentList[currentIndex].PaymentTypeId == 4)
                                        //Convert.ToInt64(gvOrderTransactionPayment.Rows[i].Cells["colPaymentTypeId"].Value) == 4)
                                        {
                                            hasCreditCard = true;
                                            break;
                                        }
                                    }
                                }


                            if (!hasCreditCard)
                            {
                                //double denom = (1 - Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["CCFee"]));
                                //double ccAmountPaid = amountReceived / denom;
                                //amountPaid = ccAmountPaid;
                                //bankFee = ccAmountPaid * Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["CCFee"]);
                                WithCreditCardPayment(amountReceived, out amountPaid, out bankFee);
                            }
                            else
                            {
                                if (paymentList[0].PaymentTypeId != 4)
                                {
                                    WithCreditCardPayment(amountReceived, out amountPaid, out bankFee);
                                }
                                else
                                {
                                    amountPaid = amountReceived;
                                    bankFee = amountReceived * Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["CCFee"]);
                                }
                            }
                            break;
                        default:
                            amountPaid = amountReceived;
                            bankFee = 0;
                            break;
                    }
                }
            }
        }
        
        
        public static void ComputeBankFeeFromList(TextBox txtAmountPaid, TextBox txtBankFee,
            long paymentTypeId, TextBox txtAmountReceived, bool hasdiscount
            , int rowIndex, List<Entity.OrderTransactionPayment> paymentList)
        {
            double amountReceived;
            double.TryParse(txtAmountReceived.Text.Trim(), out amountReceived);
            double bankFee = 0.0;
            double amountPaid = 0.0;
            ComputeBankFeeFromList(out bankFee, out amountPaid, hasdiscount, rowIndex, 0,
                paymentTypeId, amountReceived, paymentList);
            txtAmountPaid.Text = amountPaid.ToString("#,###.00");
            txtBankFee.Text = bankFee.ToString("#,###.00");
           
        }
        public static int? GetIndex(List<OrderTransactionPayment> baseList,
            Guid recordId)
        {
            int? retValue = null;
            for (int i = 0; i < baseList.Count; i++)
            {
                if (baseList[i].RecordId == recordId)
                {
                    retValue = i;
                    break;
                }
            }
            return retValue;
        }
        public static bool IsValidDates(DateTimePicker dtpFrom, DateTimePicker dtpTo)
        {
            bool retValue = dtpFrom.Value <= dtpTo.Value;
            if (!retValue)
                MessageBox.Show("Date From should be later than Date To");
            return retValue;
        }
        public static void ComputeBankFee(DataGridViewRow dgvr, bool hasdiscount,DataGridView gvOrderTransactionPayment)
        {
            long paymentTypeId = Convert.ToInt64(dgvr.Cells["colPaymentTypeId"].Value);
            double amountReceived = (double)dgvr.Cells["colAmountReceived"].Value;
            double bankFee,amountPaid;
            ComputeBankFee(out bankFee, out amountPaid, hasdiscount, dgvr.Index,
                paymentTypeId, amountReceived, gvOrderTransactionPayment);
            dgvr.Cells["colBankFee"].Value = bankFee.ToString("#,###.00");
            dgvr.Cells["colAmountPaid"].Value = amountPaid.ToString("#,###.00");

       
        }


        
    }
}
