using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.BusinessLogic
{
    public class blOrderTransactionPayment
    {
        /// <summary>Populate The OrderTransactionPayment Extention Entities.</summary>
        /// <param name="entityObject">source entity.</param>
        /// <returns>Return the entity object.</returns>
        public static Entity.OrderTransactionPayment populateExtentions(Entity.OrderTransactionPayment entityObject)
        {
            entityObject.OrderTransactionEntity = blOrderTransaction.retrieve(entityObject.OrderTransactionId);
            return entityObject;
        }

        /// <summary>Populate The OrderTransactionPayment Extention Entities.</summary>
        /// <param name="entityList">source entity List.</param>
        /// <returns>Return the entity object list.</returns>
        public static List<Entity.OrderTransactionPayment> populateExtentions(List<Entity.OrderTransactionPayment> entityList)
        {
            List<Entity.OrderTransactionPayment> retCol = new List<Entity.OrderTransactionPayment>();

            //populate the list
            foreach (Entity.OrderTransactionPayment entityObject in entityList)
            {
                retCol.Add(populateExtentions(entityObject));
            }

            return retCol;
        }

        public static bool DenominationGCExists(string code)
        {
            return  DataAccess.daOrderTransactionPayment.GCDenominationExists(code);
        }


        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.OrderTransactionPayment create(Entity.OrderTransactionPayment OrderTransactionPaymentObject)
        {
            //Call data access.
            Entity.OrderTransactionPayment ret = DataAccess.daOrderTransactionPayment.create(OrderTransactionPaymentObject);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static List<Entity.OrderTransactionPayment> create(List<Entity.OrderTransactionPayment> OrderTransactionPaymentList)
        {
            if (OrderTransactionPaymentList.Count == 0) return null;
            //Call data access.
            foreach (Entity.OrderTransactionPayment OrderTransactionPaymentObject in OrderTransactionPaymentList)
            {
                create(OrderTransactionPaymentObject);
            }

            return retrieveByOrderTransactionId(OrderTransactionPaymentList[0].OrderTransactionId);
        }

        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.OrderTransactionPayment> retrieve()
        {
            //create the list
            List<Entity.OrderTransactionPayment> retList = DataAccess.daOrderTransactionPayment.retrieve();
            if (retList == null) return null;
            return populateExtentions(retList);

        }
        
        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.OrderTransactionPayment retrieve(int Id)
        {
            //call the retrieval
            Entity.OrderTransactionPayment ret = DataAccess.daOrderTransactionPayment.retrieve(Id);
            if (ret == null) return null;
            return populateExtentions(ret);
        }
        /// <summary>
        /// Retrieve a single entity by id
        /// </summary>
        /// <typeparam name="T">the data type of the primary id</typeparam>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.OrderTransactionPayment retrieve<T>(T Id)
        {
            //call the retrieval
            Entity.OrderTransactionPayment ret = DataAccess.daOrderTransactionPayment.retrieve(Id);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.OrderTransactionPayment> retrieveByOrderTransactionId(long OrderTransactionId)
        {
            //create the list
            List<Entity.OrderTransactionPayment> retList = DataAccess.daOrderTransactionPayment.retrieveByOrderTransactionId(OrderTransactionId);
            if (retList == null) return null;
            return populateExtentions(retList);
        }

        #endregion

        #region Update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.OrderTransactionPayment update(Entity.OrderTransactionPayment OrderTransactionPaymentObject)
        {
            //Do business processing here if necessary.

            //Call data access.
            DataAccess.daOrderTransactionPayment.update(OrderTransactionPaymentObject);

            //get the saved data
            return OrderTransactionPaymentObject;
        }
        public static List<Entity.OrderTransactionPayment> GetPaymentsByTypeAndOrderTransactionId(
            long orderTransactionId, long paymentTypeId)
        {
            string sqlStatement = string.Format("SELECT OrderTransactionPayment.* FROM OrderTransactionPayment WHERE OrderTransactionId={0} AND PaymentTypeId={1} AND AmountReceived>0",
                orderTransactionId, paymentTypeId);
            return DataAccess.daOrderTransactionPayment.retrieveBySQL(sqlStatement);
        }

       
        /// <summary>Update the details of a particular transaction.</summary>
        /// <param name="OrderTransactionObject">Order Transaction object.</param>
        public static List<Entity.OrderTransactionPayment> updateListByOrderTransactionId(long OrderTransactionId, List<Entity.OrderTransactionPayment> OrderTransactionPaymentList)
        {
            //look for any removed details and update the existing ones
            List<Entity.OrderTransactionPayment> oldItems = retrieveByOrderTransactionId(OrderTransactionId);
            bool IsdetailExist = false;
            foreach (Entity.OrderTransactionPayment oldItem in oldItems)
            {
                IsdetailExist = false;
                foreach (Entity.OrderTransactionPayment newItem in OrderTransactionPaymentList)
                {
                    if (newItem.Id == oldItem.Id)
                    {
                        IsdetailExist = true;
                        update(newItem);
                        break;
                    }
                }
                if (!IsdetailExist) delete(oldItem.Id);
            }

            //create the newly added records
            foreach (Entity.OrderTransactionPayment newItem in OrderTransactionPaymentList)
            {
                IsdetailExist = false;
                foreach (Entity.OrderTransactionPayment oldItem in oldItems)
                {
                    if (newItem.Id == oldItem.Id)
                    {
                        IsdetailExist = true;
                        break;
                    }
                }
                if (!IsdetailExist)
                {
                    newItem.OrderTransactionId = OrderTransactionId;
                    create(newItem);
                }
            }

            return retrieveByOrderTransactionId(OrderTransactionId);
        }
        public static bool AllowPayment(CancelBaseForm frm)
        {
            bool retValue = false;
            if (frm.AmountReceived >= 0)
            {
                retValue = true;
            }
            else
            {
                long paymentTypeId = frm.PaymentTypeId;
                switch (paymentTypeId)
                {
                    case 3:
                    case 4:                    
                        frm.ShowDialog();
                        retValue = frm.AllowPayment;
                        frm.Dispose();
                        frm = null;
                        break;
                    default:
                        retValue = true;
                        break;
                }
             
            }
            return retValue;
        }
        public static bool CheckIfGCExistonQueuedPayment(List<Entity.OrderTransactionPayment> payments,
            string documentNumber)
        {
            bool retValue = false;
            
            foreach (Entity.OrderTransactionPayment payment in payments)
            {
                if (payment.PaymentTypeId == 5)
                {
                    if (payment.DocumentNumber.ToUpper() == documentNumber.ToUpper())
                    {
                        MessageBox.Show("Denomination GC is already on the payment list");
                        retValue = true;
                        break;
                    }
                }
            }
            return retValue;
        }

        public static void RecomputePayment(long ordertransactionid)
        {
            List<Entity.OrderTransactionDetail> orderDetails = DataAccess.daOrderTransactionDetail.retrieveByOrderTransactionId(ordertransactionid);
            bool hasDiscount = false;
            foreach (Entity.OrderTransactionDetail orderDetail in orderDetails)
            {
                if (orderDetail.Adjustment > 0)
                {
                    hasDiscount = true;
                    break;
                }
            }
            List<Entity.OrderTransactionPayment> payments = DataAccess.daOrderTransactionPayment.retrieveByOrderTransactionId(ordertransactionid);
            for (int i = 0; i < payments.Count;i++)
            {
                double bankFee, amountPaid;
                BLService.ComputeBankFee(out bankFee, out amountPaid, hasDiscount, i, 
                    payments[i].PaymentTypeId, payments[i].AmountReceived, null);
                payments[i].BankFee = bankFee;
                payments[i].AmountPaid = amountPaid;               
                blOrderTransactionPayment.update(payments[i]);
            }

        }

        public static void RecomputePayment(
            List<Entity.OrderTransactionPayment> paymentList, List<Entity.OrderTransactionDetail> orderDetails)
        {
            
            bool hasDiscount = false;
            foreach (Entity.OrderTransactionDetail orderDetail in orderDetails)
            {
                if (orderDetail.Adjustment > 0)
                {
                    hasDiscount = true;
                    break;
                }
            }
            for (int i = 0; i < paymentList.Count; i++)
            {
                double bankFee, amountPaid;
                BLService.ComputeBankFee(out bankFee, out amountPaid, hasDiscount, i,
                    paymentList[i].PaymentTypeId, paymentList[i].AmountReceived, null);
                paymentList[i].BankFee = bankFee;
                paymentList[i].AmountPaid = amountPaid;
               
            }
        }

        public static string EnableCancel(long id,List<Entity.OrderTransactionPayment> paymentList,
            double amountReceived,long paymentTypeId)
        {
            string retValue = "";            
//            long id = Convert.ToInt64(gvr.Cells["colOrderPaymentId"].Value);
//            double totalCancelledAmount = GetTotalCancelledAmount(id,
//                Convert.ToInt64(gvr.Cells["colCancelledId"].Value));

//            if (totalCancelledAmount < 0)
//                 totalCancelledAmount = totalCancelledAmount * -1;

//            double gvrAmountReceived = Convert.ToDouble(gvr.Cells["colAmountReceived"].Value);
//            if (totalCancelledAmount == gvrAmountReceived)
//            {
//                retValue = "Selected payment was already cancelled";
//            }

//            if (Convert.ToInt64(gvr.Cells["colPaymentTypeId"].Value) == 5)
//                retValue = @"Gift Check payment is not available on this process
//                             Please click the link button and press the remove button
//                             If you wish to cancel the payment";

            if (paymentTypeId == 5)
            {
                return @"Gift Check payment is not available on this process
                         Please click the link button and press the remove button
                         If you wish to cancel the payment";
            }

            double totalCancelledAmount=0;
            foreach (Entity.OrderTransactionPayment payment in paymentList)
            {
                if (payment.CancelledId == id)
                {
                    totalCancelledAmount +=payment.AmountReceived;
                }
            }   
            if(totalCancelledAmount<0)
                totalCancelledAmount = totalCancelledAmount * -1;
            if(amountReceived==totalCancelledAmount)
                retValue = "Selected payment was already cancelled";

            return retValue;   
         
           
        }
        public static bool RefundAll(long orderTransactionId)
        {
            bool retValue = true;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "[dbo].[spuOrderTransactionPayment]";
                cmd.CommandType = CommandType.StoredProcedure;
                DataAccess.daHelper.addInParameter(cmd, "@Mode", SqlDbType.VarChar, "RETRIEVEBYDATEPAID");
                DataAccess.daHelper.addInParameter(cmd, "@OrderTransactionId", SqlDbType.BigInt, orderTransactionId);
                using (DataSet ds = DataAccess.daHelper.executeProcedure(cmd))
                {
                    if (ds != null)
                    {
                        retValue = ds.Tables[0].Rows.Count > 0 ? false : true;
                    }
                }
            }
              

            return retValue;

        }
        public static void DeletePaymentByOrderTransactionId(long orderTransactionId)
        {
            DataAccess.daOrderTransactionPayment.deleteByOrderId(orderTransactionId);
        }
        public static bool HasCheckPayment(long orderTransactionId)
        {
            bool retValue = false;
            using (DataSet ds = DataAccess.daHelper.executeSelect(
                string.Format(@"SELECT * FROM OrderTransactionPayment WHERE OrderTransactionId={0} AND
                            PaymentTypeId=2", orderTransactionId)))
            {
                if (ds != null)
                {
                    retValue = ds.Tables[0].Rows.Count > 0 ? true : false;
                }
            }

            return retValue;
        }

        public static void AutoCancelPayment(DataGridView gv,long orderTransactionId)
        {
            foreach (DataGridViewRow row in gv.Rows)
            {
                Entity.OrderTransactionPayment payment = new Entity.OrderTransactionPayment();
                switch(Convert.ToInt64(row.Cells["colPaymentTypeId"].Value))
                {
                    case 4:
                    case 3:
                    case 1:
                        payment.AmountReceived = Convert.ToDouble(row.Cells["colAmountReceived"].Value) * -1;
                        payment.AmountPaid = payment.AmountReceived;
                        payment.DatePaid = DateTime.Now;
                        payment.DocumentNumber = string.Format("{0}(CANCELLED)",
                            row.Cells["colDocumentNumber"].Value.ToString());
                        payment.OrderTransactionId = orderTransactionId;
                        payment.PaymentTypeCode = "Cash";
                        payment.PaymentTypeId = 1;
                        payment.CancelledId = Convert.ToInt64(row.Cells["colOrderPaymentId"].Value);
                        create(payment);
                        break;
                    case 5:
                        DataAccess.daOrderTransactionPayment.deleteByCancellation(Convert.ToInt64(row.Cells["colOrderPaymentId"].Value));
                        break;
                    default:
                        break;

                        
                }
                payment = null;
            }
        }

        public static double GetTotalCancelledAmount(long orderPaymentId,
            List<Entity.OrderTransactionPayment> paymentList)//,long cancelledOrderPaymentId)
        {

            double retValue = 0;
            foreach (Entity.OrderTransactionPayment payment in paymentList)
            {
                if (payment.CancelledId == orderPaymentId)
                {
                    retValue += payment.AmountReceived;
                }
            }
            if (retValue < 0)
                retValue = retValue * -1;
            return retValue;
        
        
        }
        public static void GetProperMode(RadioButton rb
            ,RadioButton rbCash
            ,Entity.OrderTransactionPayment payment)
        {
            switch (payment.PaymentTypeId)
            {
               
                case 3://ATM
                    rb.Visible = false;
                    rbCash.Checked = true;
                    break;
                case 4://Credit Card
                    if (payment.DatePaid.ToShortDateString() !=
                        DateTime.Now.ToShortDateString())
                    {
                        rbCash.Checked = true;
                        rb.Visible = false;
                        rb.Checked = false;
                    }
                    else
                    {
                        rb.Visible = true;
                        rb.Text = payment.PaymentTypeCode;
                        rb.Checked = true;
                    }
                    break;
                case 2://Check
                    rb.Text = payment.PaymentTypeCode;
                    break;
                default:
                    break;
                
            }
        }
        public static double GetAmountReceived(long cancelledOrderPaymentId,
            List<Entity.OrderTransactionPayment> paymentList)
        {
            double retValue = 0;
         
            //using (DataSet ds = DataAccess.daHelper.executeSelect(
            //    string.Format("SELECT AmountReceived FROM OrderTransactionPayment WHERE Id={0}",cancelledOrderPaymentId)))
            //{
            //    if (ds != null)
            //    {
            //        retValue = Convert.ToDouble(ds.Tables[0].Rows[0][0]);
            //    }
            //}
            foreach (Entity.OrderTransactionPayment payment in paymentList)
            {
                if (payment.Id == cancelledOrderPaymentId)
                {
                    retValue = payment.AmountReceived;
                    break;
                }
            }

            if (retValue < 0)
                retValue = retValue * -1;
            return retValue;
        }
        public static void RadioButton_CheckedChanged(RadioButton rb, EventArgs e, TextBox txt)
        {
           
                txt.Text = rb.Text.Trim();
            
        }
        public static Entity.OrderTransactionPayment retrieveByCancelledId(long id)
        {
            return DataAccess.daOrderTransactionPayment.retrieveCancelledId(id);
        }
        public static void SaveCancelledPayment(Entity.OrderTransactionPayment orderTransactionPayment,string modeOfPayment,string amountCancel,
            long orderTransactionId,double amountBalance,List<Entity.OrderTransactionPayment> paymentList,int index)
        {
            double amountCancelled = Convert.ToDouble(amountCancel);
            if (amountCancelled < 0)
                amountCancelled = amountCancelled * -1;

           

            if (amountCancelled > amountBalance)
            {
                MessageBox.Show("Cancelled amount should not be greater than the total cancelled amount for this particular payment");
                return;
            }

            
            Entity.PaymentType paymentType = blPaymentType.retrieveByDescription(modeOfPayment);
            double bankFee = 0;
            double amountPaid = Convert.ToDouble(amountCancel) * -1;
            if (paymentType.Id == 3 ||
                paymentType.Id == 4)
            {
                if (orderTransactionPayment.DatePaid.ToShortDateString() ==
                    DateTime.Now.ToShortDateString())
                {
                    bankFee = -1 * orderTransactionPayment.BankFee;
                    amountPaid = -1 * paymentList[index].AmountPaid;
                }

            }

            if (orderTransactionPayment.CancelledId == -1)//It means record is  not a cancelled payment
            {
                Entity.OrderTransactionPayment payment = new Entity.OrderTransactionPayment();
                payment.AmountReceived = Convert.ToDouble(amountCancel) * -1;
                payment.AmountPaid = amountPaid;//payment.AmountReceived;
                payment.CancelledId = orderTransactionPayment.Id;//Convert.ToInt64(row.Cells["colOrderPaymentId"].Value);
                payment.DatePaid = DateTime.Now;
                payment.PaymentTypeCode = modeOfPayment;
                payment.OrderTransactionId = orderTransactionId;
                payment.PaymentTypeId = paymentType.Id;
                payment.BankFee = bankFee;
                //if (paymentType.Id == 5)//it means denomination gc
                //{
                //    blGiftCertificate.UpdateGCAfterCancelledOrRemoved(orderTransactionPayment.DocumentNumber,0);
                //}
                payment.DocumentNumber = string.Format("{0}(CANCELLED PAYMENT)",
                  orderTransactionPayment.DocumentNumber);
                paymentList.Add(payment);
                //blOrderTransactionPayment.create(payment);
            }
            else
            {
                //payment = blOrderTransactionPayment.retrieve(orderTransactionPayment.Id);
                //payment = paymentList[index];                
                //payment.PaymentTypeId = paymentType.Id;
                //payment.PaymentTypeCode = paymentType.Description;
                //payment.AmountReceived =amountCancelled * -1;
                //payment.AmountPaid = payment.AmountReceived;
                //blOrderTransactionPayment.update(payment);
                paymentList[index].PaymentTypeId = paymentType.Id;
                paymentList[index].PaymentTypeCode = paymentType.Description;
                paymentList[index].AmountReceived = amountCancelled * -1;
                paymentList[index].AmountPaid = amountPaid;
                paymentList[index].BankFee = bankFee;
                paymentList[index].AmountPaid = paymentList[index].AmountReceived;
                
            }
        }
        public static void GetCorrectModeOfPaymentAndRemarks(TextBox txtModeOfPayment
            , Label lblRemarks
            ,Entity.OrderTransactionPayment orderTransactionPayment
            ,RadioButton rdo
            )
        {

            switch (orderTransactionPayment.PaymentTypeId)
            {
                case 1:
                case 2:
                    txtModeOfPayment.Text = orderTransactionPayment.PaymentTypeCode;//rowPayment.Cells["colPaymentTypeCode"].Value.ToString();
                    lblRemarks.Text = string.Empty;
                    break;
                case 3:
                    txtModeOfPayment.Text = "Cash";
                    break;
                case 4:

                    if (orderTransactionPayment.DatePaid.Date != DateTime.Now.Date)
                    {
                        txtModeOfPayment.Text = "Cash";
                        //lblRemarks.Text = "Cancellation of payment using ATM or Credit Card is not allowed if the date of \r\ncancellation exceeds the actual date of payment";

                    }
                    else
                    {
                        lblRemarks.Text = string.Empty;
                        switch (orderTransactionPayment.PaymentTypeId)
                        {
                            case 3:                               
                                txtModeOfPayment.Text = rdo.Checked==false?"Cash":
                                    rdo.Text.Trim();
                                break;
                            case 4:
                                txtModeOfPayment.Text = "Credit Card";
                                break;
                        }
                    }
                    break;
                case 5:
                    txtModeOfPayment.Text = orderTransactionPayment.PaymentTypeCode; //rowPayment.Cells["colPaymentTypeCode"].Value.ToString();
                    lblRemarks.Text = string.Empty;
                    break;

            }
        }
        #endregion

        #region Delete
        /// <summary>delete an item entry from the database.</summary>
        /// <param name="OrderTransactionId">Item to delete.</param>
        public static void delete(long OrderTransactionId)
        {
            //Call data access.
            DataAccess.daOrderTransactionPayment.delete(OrderTransactionId);
        }
        public static void delete(Entity.OrderTransactionPayment payment)
        {
            DataAccess.daOrderTransactionPayment.delete(payment.Id);
        }
        #endregion
    }
}
