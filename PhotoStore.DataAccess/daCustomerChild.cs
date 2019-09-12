using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.DataAccess
{
    public class daCustomerChild:daHelper
    {
        private static string _TableName="CustomerChild";

        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.CustomerChild create(Entity.CustomerChild itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuCustomerChild";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "CREATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, DBNull.Value);
            daHelper.addInParameter(sqlCmd, "@CustomerId", SqlDbType.VarChar, itemObject.CustomerId);
            daHelper.addInParameter(sqlCmd, "@Name", SqlDbType.VarChar, itemObject.Name);
            daHelper.addInParameter(sqlCmd, "@BirthDate", SqlDbType.DateTime, itemObject.BirthDate);


            //Execute the command
            DataSet ds = daHelper.executeProcedure(sqlCmd);

            return new Entity.CustomerChild(ds.Tables[0].Rows[0]);
        }
        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.CustomerChild> retrieve()
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName);

            List<Entity.CustomerChild> entityList = new List<PhotoStore.Entity.CustomerChild>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                entityList.Add(new Entity.CustomerChild(dr));
            }
            return entityList;
        }

        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.CustomerChild retrieve(int Id)
        {
            DataRow dr = daHelper.executeSelectById(_TableName, Id);
            return new Entity.CustomerChild(dr);
        }


        /// <summary>Retrieve all entities by CustomerId.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.CustomerChild> retrieveByCustomerId(long CustomerId)
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName + " where CustomerId=" + CustomerId);
            List<Entity.CustomerChild> entityList = new List<PhotoStore.Entity.CustomerChild>();
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    entityList.Add(new Entity.CustomerChild(dr));
                }
            }
            return entityList;
        }

        /// <summary>Retrieve a single entity by Name.</summary>
        /// <param name="CustomerId">Parent's Id.</param>
        /// <param name="Name">Entity Name.</param>
        /// <returns>Return Entity object.</returns>
        public static List<Entity.CustomerChild> retrieveByCustomerIdAndName(int CustomerId, string Name)
        {
            DataSet ds = executeSelect("Select * from " + _TableName + " where CustomerId=" + CustomerId.ToString() + " and [Name]='" + Name + "'");

            List<Entity.CustomerChild> entityList = new List<PhotoStore.Entity.CustomerChild>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                entityList.Add(new Entity.CustomerChild(dr));
            }
            return entityList;
        }

        #endregion
        #region Update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static void update(Entity.CustomerChild itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuCustomerChild";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "UPDATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, itemObject.Id);
            daHelper.addInParameter(sqlCmd, "@CustomerId", SqlDbType.VarChar, itemObject.CustomerId);
            daHelper.addInParameter(sqlCmd, "@Name", SqlDbType.VarChar, itemObject.Name);
            daHelper.addInParameter(sqlCmd, "@BirthDate", SqlDbType.DateTime, itemObject.BirthDate);
            

            //Execute the command
            daHelper.executeNonQuery(sqlCmd);
        }
        #endregion

        #region Delete
        /// <summary>Delete an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static void delete(long Id)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuCustomerChild";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "DELETE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, Id);

            //Execute the command
            daHelper.executeNonQuery(sqlCmd);
        }
        #endregion
    }
}
