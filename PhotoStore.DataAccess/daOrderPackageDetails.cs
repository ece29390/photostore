using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.DataAccess
{
    public class daOrderPackageDetails 
    {
        private static string _TableName = "OrderPackageDetails";

        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.OrderPackageDetails create(Entity.OrderPackageDetails itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuOrderPackageDetails";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "CREATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, DBNull.Value);
            daHelper.addInParameter(sqlCmd, "@Particulars", SqlDbType.VarChar, itemObject.Particulars);
            daHelper.addInParameter(sqlCmd, "@Quantity", SqlDbType.Int, itemObject.Quantity);
            daHelper.addInParameter(sqlCmd, "@OrderDetails_Id", SqlDbType.BigInt, itemObject.OrderTransactionDetailId);
            daHelper.addInParameter(sqlCmd, "@IsRejectedOrder", SqlDbType.Bit, itemObject.IsRejected);
            
            

            //Execute the command
            DataSet ds = daHelper.executeProcedure(sqlCmd);

            return new Entity.OrderPackageDetails(ds.Tables[0].Rows[0]);
        }
        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.OrderPackageDetails> retrieve()
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName);

            List<Entity.OrderPackageDetails> entityList = new List<PhotoStore.Entity.OrderPackageDetails>();
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    entityList.Add(new Entity.OrderPackageDetails(dr));
                }
            }
            return entityList;
        }
        public static List<Entity.OrderPackageDetails> retrieveByWhereStatement(string wherestatement)
        {
            List<Entity.OrderPackageDetails> OrderPackageDetailss = new List<PhotoStore.Entity.OrderPackageDetails>();
            using (DataSet ds = daHelper.executeSelect(string.Format("SELECT * FROM {0} {1}",
                _TableName, wherestatement)))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Entity.OrderPackageDetails OrderPackageDetails = new PhotoStore.Entity.OrderPackageDetails(dr);
                        OrderPackageDetailss.Add(OrderPackageDetails);
                        OrderPackageDetails = null;
                    }
                }
            }
            return OrderPackageDetailss;
        }
        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.OrderPackageDetails retrieve(int Id)
        {
            DataRow dr = daHelper.executeSelectById(_TableName, Id);
            return new Entity.OrderPackageDetails(dr);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Id">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.OrderPackageDetails retrieve(string Code)
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName + " where Code='" + Code + "'");
            if (ds == null) return null;
            DataRowCollection drc = ds.Tables[0].Rows;
            return new Entity.OrderPackageDetails(drc[0]);
        }

        public static List<Entity.OrderPackageDetails> retrievePrintedItems(long orderdetailsid)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spGetPrintedPackageItems";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@OrderDetailsId", SqlDbType.BigInt, orderdetailsid);        
            //Execute the command
            List<Entity.OrderPackageDetails> retValues = new List<PhotoStore.Entity.OrderPackageDetails>();
            using (DataSet ds = daHelper.executeProcedure(sqlCmd))
            {
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            Entity.OrderPackageDetails op = new PhotoStore.Entity.OrderPackageDetails(dr);
                            retValues.Add(op);
                            op = null;
                        }
                    }
                }
            }
            return retValues;
            
        }

        #endregion

        #region update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static void update(Entity.OrderPackageDetails itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuOrderPackageDetails";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "UPDATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, itemObject.Id);
            daHelper.addInParameter(sqlCmd, "@Particulars", SqlDbType.VarChar, itemObject.Particulars);
            daHelper.addInParameter(sqlCmd, "@Quantity", SqlDbType.Int, itemObject.Quantity);
            daHelper.addInParameter(sqlCmd, "@OrderDetails_Id", SqlDbType.BigInt, itemObject.OrderTransactionDetailId);
            daHelper.addInParameter(sqlCmd, "@IsRejectedOrder", SqlDbType.Bit, itemObject.IsRejected);
            

            //Execute the command
            daHelper.executeNonQuery(sqlCmd);

        }
        #endregion

        #region delete
        /// <summary>Delete an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static void delete(long Id)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuOrderPackageDetails";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "DELETE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, Id);

            //Execute the command
            daHelper.executeNonQuery(sqlCmd);

        }
        #endregion
    }
}
