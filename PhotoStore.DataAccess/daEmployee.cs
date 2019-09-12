using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.DataAccess
{
    public class daEmployee 
    {
        private static string _TableName = "Employee";

        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.Employee create(Entity.Employee itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuEmployee";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "CREATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, DBNull.Value);
            daHelper.addInParameter(sqlCmd, "@UserName", SqlDbType.VarChar, itemObject.UserName);
            daHelper.addInParameter(sqlCmd, "@Password", SqlDbType.VarChar, itemObject.Password);
            daHelper.addInParameter(sqlCmd, "@FullName", SqlDbType.VarChar, itemObject.FullName);
            daHelper.addInParameter(sqlCmd, "@EmployeeGroupId", SqlDbType.BigInt, itemObject.EmployeeGroupId);


            //Execute the command
            DataSet ds = daHelper.executeProcedure(sqlCmd);

            return new Entity.Employee(ds.Tables[0].Rows[0]);
        }
        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.Employee> retrieve()
        {
            DataSet ds = daHelper.executeSelect(string.Format("Select * from {0} WHERE IsDeactivated = 0", _TableName));

            List<Entity.Employee> entityList = new List<PhotoStore.Entity.Employee>();
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    entityList.Add(new Entity.Employee(dr));
                }
            }
            return entityList;
        }

        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.Employee retrieve(long Id)
        {
            DataRow dr = daHelper.executeSelectById(_TableName, Id);
            if (dr == null)
                return null;
            return (new Entity.Employee(dr));
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Id">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.Employee retrieve(string UserName)
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName + " where UserName='" + UserName + "'");
            if (ds == null) return null;
            DataRowCollection drc = ds.Tables[0].Rows;
            return new Entity.Employee(drc[0]);
        }

        #endregion

        #region update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static void update(Entity.Employee itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuEmployee";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "UPDATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, itemObject.Id);
            daHelper.addInParameter(sqlCmd, "@UserName", SqlDbType.VarChar, itemObject.UserName);
            daHelper.addInParameter(sqlCmd, "@Password", SqlDbType.VarChar, itemObject.Password);
            daHelper.addInParameter(sqlCmd, "@FullName", SqlDbType.VarChar, itemObject.FullName);
            daHelper.addInParameter(sqlCmd, "@EmployeeGroupId", SqlDbType.BigInt, itemObject.EmployeeGroupId);
            

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
            sqlCmd.CommandText = "spuEmployee";
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
