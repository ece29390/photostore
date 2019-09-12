using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.DataAccess
{
    public class daOrderTransactionModifiedBy 
    {
        private static string _TableName = "OrderTransactionModifiedBy";

        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.OrderTransactionModifiedBy create(Entity.OrderTransactionModifiedBy itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuOrderTransactionModifiedBy";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "CREATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, DBNull.Value);
            daHelper.addInParameter(sqlCmd, "@OrderTransactionId", SqlDbType.Int, itemObject.OrderTransactionId);
            daHelper.addInParameter(sqlCmd, "@ModifiedByEmployeeId", SqlDbType.Int, itemObject.ModifiedByEmployeeId);
            daHelper.addInParameter(sqlCmd, "@Remarks", SqlDbType.VarChar, itemObject.Remarks);


            //Execute the command
            DataSet ds = daHelper.executeProcedure(sqlCmd);

            return new Entity.OrderTransactionModifiedBy(ds.Tables[0].Rows[0]);
        }
        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.OrderTransactionModifiedBy> retrieve()
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName);

            List<Entity.OrderTransactionModifiedBy> entityList = new List<PhotoStore.Entity.OrderTransactionModifiedBy>();
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    entityList.Add(new Entity.OrderTransactionModifiedBy(dr));
                }
            }
            return entityList;
        }

        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.OrderTransactionModifiedBy retrieve(int Id)
        {
            DataRow dr = daHelper.executeSelectById(_TableName, Id);
            return new Entity.OrderTransactionModifiedBy(dr);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Id">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.OrderTransactionModifiedBy retrieve(string Code)
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName + " where Code='" + Code + "'");
            if (ds == null) return null;
            DataRowCollection drc = ds.Tables[0].Rows;
            return new Entity.OrderTransactionModifiedBy(drc[0]);
        }

        /// <summary>Retrieve all entities by OrderTransactionId.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.OrderTransactionModifiedBy> retrieveByOrderTransactionId(long OrderTransactionId)
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName + " Where OrderTransactionId = " + OrderTransactionId);
            List<Entity.OrderTransactionModifiedBy> entityList = new List<PhotoStore.Entity.OrderTransactionModifiedBy>();
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    entityList.Add(new Entity.OrderTransactionModifiedBy(dr));
                }
            }
            return entityList;
        }

        /// <summary>Retrieve all entities by ModifiedByEmployeeId.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.OrderTransactionModifiedBy> retrieveByModifiedByEmployeeId(int OrderTransactionId, int ModifiedByEmployeeId)
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName + " Where OrderTransactionId = " + OrderTransactionId + " and ModifiedByEmployeeId = " + ModifiedByEmployeeId);
            List<Entity.OrderTransactionModifiedBy> entityList = new List<PhotoStore.Entity.OrderTransactionModifiedBy>();
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    entityList.Add(new Entity.OrderTransactionModifiedBy(dr));
                }
            }
            return entityList;
        }
        
        #endregion

        #region update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static void update(Entity.OrderTransactionModifiedBy OrderTransactionModifiedByObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuOrderTransactionModifiedBy";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "UPDATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, OrderTransactionModifiedByObject.Id);
            daHelper.addInParameter(sqlCmd, "@OrderTransactionId", SqlDbType.Int, OrderTransactionModifiedByObject.OrderTransactionId);
            daHelper.addInParameter(sqlCmd, "@ModifiedByEmployeeId", SqlDbType.Int, OrderTransactionModifiedByObject.ModifiedByEmployeeId);
            daHelper.addInParameter(sqlCmd, "@Remarks", SqlDbType.VarChar, OrderTransactionModifiedByObject.Remarks);
            

            //Execute the command
            daHelper.executeNonQuery(sqlCmd);

        }
        #endregion

        #region delete
        /// <summary>Delete an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static void delete(long OrderTransactionModifiedById)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuOrderTransactionModifiedBy";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "DELETE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, OrderTransactionModifiedById);

            //Execute the command
            daHelper.executeNonQuery(sqlCmd);

        }
        #endregion
    }
}
