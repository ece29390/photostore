using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.DataAccess
{
    public class daPackage 
    {
        private static string _TableName = "Package";

        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.Package create(Entity.Package itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuPackage";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "CREATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, DBNull.Value);
            daHelper.addInParameter(sqlCmd, "@Code", SqlDbType.VarChar, itemObject.Code);
            daHelper.addInParameter(sqlCmd, "@Description", SqlDbType.VarChar, itemObject.Description);
            daHelper.addInParameter(sqlCmd, "@UnitPrice", SqlDbType.Money, itemObject.UnitPrice);


            //Execute the command
            DataSet ds = daHelper.executeProcedure(sqlCmd);

            return new Entity.Package(ds.Tables[0].Rows[0]);
        }
        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.Package> retrieve()
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName);

            List<Entity.Package> entityList = new List<PhotoStore.Entity.Package>();
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    entityList.Add(new Entity.Package(dr));
                }
            }
            return entityList;
        }

        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.Package retrieve(int Id)
        {
            DataRow dr = daHelper.executeSelectById(_TableName, Id);
            return new Entity.Package(dr);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Id">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.Package retrieve(string Code)
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName + " where Code='" + Code + "'");
            if (ds == null) return null;
            DataRowCollection drc = ds.Tables[0].Rows;
            return new Entity.Package(drc[0]);
        }

        #endregion

        #region update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static void update(Entity.Package itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuPackage";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "UPDATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, itemObject.Id);
            daHelper.addInParameter(sqlCmd, "@Code", SqlDbType.VarChar, itemObject.Code);
            daHelper.addInParameter(sqlCmd, "@Description", SqlDbType.VarChar, itemObject.Description);
            daHelper.addInParameter(sqlCmd, "@UnitPrice", SqlDbType.Money, itemObject.UnitPrice);
            

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
            sqlCmd.CommandText = "spuPackage";
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
