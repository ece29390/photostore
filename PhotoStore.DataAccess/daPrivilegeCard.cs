using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.DataAccess
{
    public class daPrivilegeCard:daHelper
    {
        private static string _TableName = "PrivilegeCard";

        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.PrivilegeCard create(Entity.PrivilegeCard PrivilegeCardObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuPrivilegeCard";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.NVarChar, "CREATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, DBNull.Value);
            daHelper.addInParameter(sqlCmd, "@CustomerId", SqlDbType.BigInt, PrivilegeCardObject.CustomerId);
            daHelper.addInParameter(sqlCmd, "@Code", SqlDbType.NVarChar, PrivilegeCardObject.Code);
            daHelper.addInParameter(sqlCmd, "@IssueDate", SqlDbType.DateTime, PrivilegeCardObject.IssueDate);
            daHelper.addInParameter(sqlCmd, "@ExpirationDate", SqlDbType.DateTime, PrivilegeCardObject.ExpirationDate);
            daHelper.addInParameter(sqlCmd, "@Remarks", SqlDbType.NVarChar, PrivilegeCardObject.Remarks);


            //Execute the command
            DataSet ds = daHelper.executeProcedure(sqlCmd);

            return new Entity.PrivilegeCard(ds.Tables[0].Rows[0]);
        }
        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.PrivilegeCard> retrieve()
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName);

            List<Entity.PrivilegeCard> entityList = new List<PhotoStore.Entity.PrivilegeCard>();
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    entityList.Add(new Entity.PrivilegeCard(dr));
                }
            }
            return entityList;
        }

        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.PrivilegeCard retrieve(int Id)
        {
            DataRow dr = daHelper.executeSelectById(_TableName, Id);
            return new Entity.PrivilegeCard(dr);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Id">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.PrivilegeCard retrieve(string Code)
        {
           
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName + " where Code='" + Code + "'");
            if (ds == null) return null;
            DataRowCollection drc = ds.Tables[0].Rows;
            return new Entity.PrivilegeCard(drc[0]);
        }

        /// <summary>Retrieve all Active entities by CustomerId.</summary>
        /// <returns>a List of Active Entities</returns>
        public static List<Entity.PrivilegeCard> retrieveActiveByCustomerId(long CustomerId)
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName + " Where CustomerId = " + CustomerId + " and getdate() between IssueDate and ExpirationDate");
            List<Entity.PrivilegeCard> entityList = new List<PhotoStore.Entity.PrivilegeCard>();
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    entityList.Add(new Entity.PrivilegeCard(dr));
                }
            }
            return entityList;
        }

        /// <summary>Retrieve all entities by CustomerId.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.PrivilegeCard> retrieveByCustomerId(long CustomerId)
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName + " Where CustomerId = " + CustomerId);
            List<Entity.PrivilegeCard> entityList = new List<PhotoStore.Entity.PrivilegeCard>();
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    entityList.Add(new Entity.PrivilegeCard(dr));
                }
            }
            return entityList;
        }

        #endregion

        #region update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static void update(Entity.PrivilegeCard PrivilegeCardObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuPrivilegeCard";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "UPDATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, PrivilegeCardObject.Id);
            daHelper.addInParameter(sqlCmd, "@CustomerId", SqlDbType.BigInt, PrivilegeCardObject.CustomerId);
            daHelper.addInParameter(sqlCmd, "@Code", SqlDbType.NVarChar, PrivilegeCardObject.Code);
            daHelper.addInParameter(sqlCmd, "@IssueDate", SqlDbType.DateTime, PrivilegeCardObject.IssueDate);
            daHelper.addInParameter(sqlCmd, "@ExpirationDate", SqlDbType.DateTime, PrivilegeCardObject.ExpirationDate);
            daHelper.addInParameter(sqlCmd, "@Remarks", SqlDbType.NVarChar, PrivilegeCardObject.Remarks);
            

            //Execute the command
            daHelper.executeNonQuery(sqlCmd);

            UpdatePriviledgeCardCode(PrivilegeCardObject.CustomerId);

        }
        #endregion

        #region delete
        /// <summary>Delete an item entry in the database.</summary>
        /// <param name="Id">The Id of the Item to delete.</param>
        public static void delete(long PrivilegeCardId)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuPrivilegeCard";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "DELETE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, PrivilegeCardId);

            //Execute the command
            daHelper.executeNonQuery(sqlCmd);

        }

        public static void UpdatePriviledgeCardCode(long customerid)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "dbo.spUpdateCustomerPriviledgeCardByCustomer";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@CUSTOMERID", SqlDbType.BigInt, customerid);
          

            //Execute the command
            daHelper.executeNonQuery(sqlCmd);
        }
        public static void UpdatePriviledgeCardCode()
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "dbo.spUpdateCustomerPriviledgeCard";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;
          
            //Execute the command
            daHelper.executeNonQuery(sqlCmd);
        }
        #endregion
    }
}
