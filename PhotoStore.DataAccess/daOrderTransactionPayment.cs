using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.DataAccess
{
    public class daOrderTransactionPayment:daHelper
    {
        private static string _TableName = "OrderTransactionPayment";

        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.OrderTransactionPayment create(Entity.OrderTransactionPayment itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuOrderTransactionPayment";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "CREATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, DBNull.Value);
            daHelper.addInParameter(sqlCmd, "@OrderTransactionId", SqlDbType.BigInt, itemObject.OrderTransactionId);
            daHelper.addInParameter(sqlCmd, "@DatePaid", SqlDbType.DateTime, itemObject.DatePaid);
            daHelper.addInParameter(sqlCmd, "@PaymentTypeCode", SqlDbType.VarChar, itemObject.PaymentTypeCode);
            daHelper.addInParameter(sqlCmd, "@DocumentNumber", SqlDbType.VarChar, itemObject.DocumentNumber);
            daHelper.addInParameter(sqlCmd, "@AmountPaid", SqlDbType.Money, itemObject.AmountPaid);
            daHelper.addInParameter(sqlCmd, "@BankFee", SqlDbType.Money, itemObject.BankFee);
            daHelper.addInParameter(sqlCmd, "@AmountReceived", SqlDbType.Money, itemObject.AmountReceived);
            daHelper.addInParameter(sqlCmd, "@PaymentTypeId", SqlDbType.BigInt, itemObject.PaymentTypeId);
            if (itemObject.CancelledId != -1)
                daHelper.addInParameter(sqlCmd, "@CancelledId", SqlDbType.BigInt, itemObject.CancelledId);
            //Execute the command
            DataSet ds = daHelper.executeProcedure(sqlCmd);

            return new Entity.OrderTransactionPayment(ds.Tables[0].Rows[0]);
        }
        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.OrderTransactionPayment> retrieve()
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName);

            List<Entity.OrderTransactionPayment> entityList = new List<PhotoStore.Entity.OrderTransactionPayment>();
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    entityList.Add(new Entity.OrderTransactionPayment(dr));
                }
            }
            return entityList;
        }
        //public static List<Entity.OrderTransactionPayment> GetPaymentsByType(long orderTransactionId, long paymentTypeId)
        //{

        //}
        public static bool GCDenominationExists(string code)
        {
            bool retValue = false;
            string sqlStatement = string.Format("SELECT * FROM {0} WHERE DocumentNumber LIKE '%{1}%'",
                _TableName,code);
            using (DataSet ds = daHelper.executeSelect(sqlStatement))
            {
                if (ds != null)
                {
                    retValue = ds.Tables[0].Rows.Count > 0 ? true : false;
                }
            }
                
            return retValue;
        }
        public static Entity.OrderTransactionPayment retrieveCancelledId(long id)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuOrderTransactionPayment";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "RETRIEVEBYCANCELLED");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, id);
            //Execute the command
            DataSet ds = daHelper.executeProcedure(sqlCmd);

            return new Entity.OrderTransactionPayment(ds.Tables[0].Rows[0]);

        }
        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.OrderTransactionPayment retrieve(int Id)
        {
            DataRow dr = daHelper.executeSelectById(_TableName, Id);
            return new Entity.OrderTransactionPayment(dr);
        }
        public static Entity.OrderTransactionPayment retrieve<T>(T Id)
        {
            DataRow dr = daHelper.executeSelectById(_TableName, Id);
            return new Entity.OrderTransactionPayment(dr);
        }
        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Id">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.OrderTransactionPayment retrieve(string Code)
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName + " where Code='" + Code + "'");
            if (ds == null) return null;
            DataRowCollection drc = ds.Tables[0].Rows;
            return new Entity.OrderTransactionPayment(drc[0]);
        }
        public static List<Entity.OrderTransactionPayment> retrieveBySQL(string sqlstatement)
        {
            List<Entity.OrderTransactionPayment> payments = new List<PhotoStore.Entity.OrderTransactionPayment>();
            using (DataSet ds = daHelper.executeSelect(sqlstatement))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Entity.OrderTransactionPayment payment = new PhotoStore.Entity.OrderTransactionPayment(dr);
                        payments.Add(payment);
                        payment = null;
                    }
                }
            }
            return payments;
        }
        /// <summary>Retrieve all entities by OrderTransactionId.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.OrderTransactionPayment> retrieveByOrderTransactionId(long OrderTransactionId)
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName + " Where OrderTransactionId = " + OrderTransactionId);
            List<Entity.OrderTransactionPayment> entityList = new List<PhotoStore.Entity.OrderTransactionPayment>();
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    entityList.Add(new Entity.OrderTransactionPayment(dr));
                }
            }
            return entityList;
        }

        #endregion

        #region update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static void update(Entity.OrderTransactionPayment OrderTransactionPaymentObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuOrderTransactionPayment";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "UPDATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, OrderTransactionPaymentObject.Id);
            daHelper.addInParameter(sqlCmd, "@OrderTransactionId", SqlDbType.BigInt, OrderTransactionPaymentObject.OrderTransactionId);
            daHelper.addInParameter(sqlCmd, "@DatePaid", SqlDbType.DateTime, OrderTransactionPaymentObject.DatePaid);
            daHelper.addInParameter(sqlCmd, "@PaymentTypeCode", SqlDbType.VarChar, OrderTransactionPaymentObject.PaymentTypeCode);
            daHelper.addInParameter(sqlCmd, "@DocumentNumber", SqlDbType.VarChar, OrderTransactionPaymentObject.DocumentNumber);
            daHelper.addInParameter(sqlCmd, "@AmountPaid", SqlDbType.Money, OrderTransactionPaymentObject.AmountPaid);
            daHelper.addInParameter(sqlCmd, "@BankFee", SqlDbType.Money, OrderTransactionPaymentObject.BankFee);
            daHelper.addInParameter(sqlCmd, "@AmountReceived", SqlDbType.Money, OrderTransactionPaymentObject.AmountReceived);
            daHelper.addInParameter(sqlCmd, "@PaymentTypeId", SqlDbType.BigInt, OrderTransactionPaymentObject.PaymentTypeId);

            //Execute the command
            daHelper.executeNonQuery(sqlCmd);

        }
        #endregion

        #region delete
        /// <summary>Delete an item entry in the database.</summary>
        /// <param name="Id">The Id of the Item to delete.</param>
        public static void delete(long OrderTransactionPaymentId)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuOrderTransactionPayment";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "DELETE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, OrderTransactionPaymentId);

            //Execute the command
            daHelper.executeNonQuery(sqlCmd);

        }
        /// <summary>Delete an item entry in the database.</summary>
        /// <param name="Id">The Id of the Item to delete.</param>
        public static void deleteByCancellation(long OrderTransactionPaymentId)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuOrderTransactionPayment";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "DELETEGCPAYMENT");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, OrderTransactionPaymentId);

            //Execute the command
            daHelper.executeNonQuery(sqlCmd);
            
        }
        /// <summary>Delete an item entry in the database.</summary>
        /// <param name="Id">The Id of the Item to delete.</param>
        public static void deleteByOrderId(long orderId)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuOrderTransactionPayment";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "DELETEBYORDERID");
            daHelper.addInParameter(sqlCmd, "@OrderTransactionId", SqlDbType.BigInt, orderId);

            //Execute the command
            daHelper.executeNonQuery(sqlCmd);
            
        }

        #endregion
    }
}
