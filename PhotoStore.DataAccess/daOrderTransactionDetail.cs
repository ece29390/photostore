using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.DataAccess
{
    public class daOrderTransactionDetail 
    {
        private static string _TableName = "OrderTransactionDetail";

        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.OrderTransactionDetail create(Entity.OrderTransactionDetail itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuOrderTransactionDetail";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "CREATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, DBNull.Value);
            daHelper.addInParameter(sqlCmd, "@OrderTransactionId", SqlDbType.BigInt, itemObject.OrderTransactionId);
            daHelper.addInParameter(sqlCmd, "@Quantity", SqlDbType.Int, itemObject.Quantity);
            daHelper.addInParameter(sqlCmd, "@ParticularTypeCode", SqlDbType.VarChar, itemObject.ParticularTypeCode);
            //daHelper.addInParameter(sqlCmd, "@ParticularTypeId", SqlDbType.BigInt, itemObject.ParticularTypeId);
            daHelper.addInParameter(sqlCmd, "@ParticularCode", SqlDbType.VarChar, itemObject.ParticularCode);
            daHelper.addInParameter(sqlCmd, "@Particulars", SqlDbType.VarChar, itemObject.Particulars);
            daHelper.addInParameter(sqlCmd, "@UnitPrice", SqlDbType.Money, itemObject.UnitPrice);
            daHelper.addInParameter(sqlCmd, "@Adjustment", SqlDbType.Float, itemObject.Adjustment);
            daHelper.addInParameter(sqlCmd, "@Amount", SqlDbType.Money, itemObject.Amount);
            daHelper.addInParameter(sqlCmd, "@IsRejectedOrder", SqlDbType.Bit, itemObject.IsRejectedOrder);
            daHelper.addInParameter(sqlCmd, "@ParticularTypeId", SqlDbType.BigInt, itemObject.ParticularTypeId);
            daHelper.addInParameter(sqlCmd, "@ProductListId", SqlDbType.BigInt, itemObject.ProductListId);

            //Execute the command
            DataSet ds = daHelper.executeProcedure(sqlCmd);

            if(ds.Tables.Count>1)
                return new Entity.OrderTransactionDetail(ds.Tables[ds.Tables.Count-1].Rows[0]);
            else
                return new Entity.OrderTransactionDetail(ds.Tables[0].Rows[0]);
        }
        #endregion

        #region Retrieve
        

        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.OrderTransactionDetail> retrieve()
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName);

            List<Entity.OrderTransactionDetail> entityList = new List<PhotoStore.Entity.OrderTransactionDetail>();
            if (ds != null)
            {
                int counter = 1;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Entity.OrderTransactionDetail orderDetail = new PhotoStore.Entity.OrderTransactionDetail(dr);
                    entityList.Add(orderDetail);
                    orderDetail.RecordId = counter;
                    orderDetail = null;
                    counter = counter++;
                }
            }
            return entityList;
        }

        public static List<Entity.RejectedOrder> retrieveRejectedItem(string sqlstatement)
        {
            DataSet ds = daHelper.executeSelect(sqlstatement);

            List<Entity.RejectedOrder> entityList = new List<PhotoStore.Entity.RejectedOrder>();
            if (ds != null)
            {
              
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Entity.RejectedOrder orderDetail = new PhotoStore.Entity.RejectedOrder(dr);
                    entityList.Add(orderDetail);
                    orderDetail = null;
                }
            }
            return entityList;
        }
        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.OrderTransactionDetail retrieve(long Id)
        {
            DataRow dr = daHelper.executeSelectById(_TableName, Id);
            return new Entity.OrderTransactionDetail(dr);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Id">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.OrderTransactionDetail retrieve(string Code)
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName + " where Code='" + Code + "'");
            if (ds == null) return null;
            DataRowCollection drc = ds.Tables[0].Rows;
            return new Entity.OrderTransactionDetail(drc[0]);
        }

        public static List<Entity.OrderTransactionDetail> retrieveBySQLStatement(string sqlstatement)
        {
            List<Entity.OrderTransactionDetail> retValues = new List<PhotoStore.Entity.OrderTransactionDetail>();
            using (DataSet ds = daHelper.executeSelect(string.Format("SELECT * FROM {0} {1}",
                                                            _TableName
                                                            , sqlstatement)))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Entity.OrderTransactionDetail orderDetail = new PhotoStore.Entity.OrderTransactionDetail(dr);
                        retValues.Add(orderDetail);
                        orderDetail = null;
                    }
                }
            }
            return retValues;
        }

        /// <summary>Retrieve all entities by OrderTransactionId.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.OrderTransactionDetail> retrieveByOrderTransactionId(long OrderTransactionId)
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName + " Where OrderTransactionId = " + OrderTransactionId);
            List<Entity.OrderTransactionDetail> entityList = new List<PhotoStore.Entity.OrderTransactionDetail>();
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    entityList.Add(new Entity.OrderTransactionDetail(dr));
                }
            }
            return entityList;
        }
       
        #endregion

        #region update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static void update(Entity.OrderTransactionDetail OrderTransactionDetailObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuOrderTransactionDetail";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "UPDATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, OrderTransactionDetailObject.Id);
            daHelper.addInParameter(sqlCmd, "@OrderTransactionId", SqlDbType.BigInt, OrderTransactionDetailObject.OrderTransactionId);
            daHelper.addInParameter(sqlCmd, "@Quantity", SqlDbType.Int, OrderTransactionDetailObject.Quantity);
            daHelper.addInParameter(sqlCmd, "@ParticularTypeCode", SqlDbType.VarChar, OrderTransactionDetailObject.ParticularTypeCode);
            //daHelper.addInParameter(sqlCmd, "@ParticularTypeId", SqlDbType.BigInt, itemObject.ParticularTypeId);
            daHelper.addInParameter(sqlCmd, "@ParticularCode", SqlDbType.VarChar, OrderTransactionDetailObject.ParticularCode);
            daHelper.addInParameter(sqlCmd, "@Particulars", SqlDbType.VarChar, OrderTransactionDetailObject.Particulars);
            daHelper.addInParameter(sqlCmd, "@UnitPrice", SqlDbType.Money, OrderTransactionDetailObject.UnitPrice);
            daHelper.addInParameter(sqlCmd, "@Adjustment", SqlDbType.Float, OrderTransactionDetailObject.Adjustment);
            daHelper.addInParameter(sqlCmd, "@Amount", SqlDbType.Money, OrderTransactionDetailObject.Amount);
            daHelper.addInParameter(sqlCmd, "@IsRejectedOrder", SqlDbType.Bit, OrderTransactionDetailObject.IsRejectedOrder);
            daHelper.addInParameter(sqlCmd, "@ParticularTypeId", SqlDbType.BigInt, OrderTransactionDetailObject.ParticularTypeId);
            daHelper.addInParameter(sqlCmd, "@ProductListId", SqlDbType.BigInt, OrderTransactionDetailObject.ProductListId);
            

            //Execute the command
            daHelper.executeNonQuery(sqlCmd);

        }

        public static void SetToReject(Entity.RejectedOrder rejectedorder)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spSetRejectItem";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;
            long id = (rejectedorder.IsPackage) ? rejectedorder.OrderPackageDetailsId : rejectedorder.OrderDetailsId;
            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@IsPackage", SqlDbType.Bit, rejectedorder.IsPackage?1:0);
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, id);
            daHelper.addInParameter(sqlCmd, "@RejectQuantity", SqlDbType.Int, rejectedorder.Quantity);
            daHelper.addInParameter(sqlCmd, "@IsRejectedOrder", SqlDbType.Bit, 1);


            //Execute the command
            daHelper.executeNonQuery(sqlCmd);
        }
        public static void UnSetToReject(Entity.RejectedOrder rejectedorder)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spSetRejectItem";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            long id=(rejectedorder.IsPackage) ? rejectedorder.OrderPackageDetailsId : rejectedorder.OrderDetailsId;
            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@IsPackage", SqlDbType.Bit, rejectedorder.IsPackage ? 1 : 0);
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, id);
            daHelper.addInParameter(sqlCmd, "@RejectQuantity", SqlDbType.Int, 0);
            daHelper.addInParameter(sqlCmd, "@IsRejectedOrder", SqlDbType.Bit, 0);

            //Execute the command
            daHelper.executeNonQuery(sqlCmd);
        }
        #endregion

        #region delete
        /// <summary>Delete an item entry in the database.</summary>
        /// <param name="Id">The Id of the Item to delete.</param>
        public static void delete(long OrderTransactionDetailId)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuOrderTransactionDetail";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "DELETE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, OrderTransactionDetailId);

            //Execute the command
            daHelper.executeNonQuery(sqlCmd);

        }
        #endregion
    }
}
