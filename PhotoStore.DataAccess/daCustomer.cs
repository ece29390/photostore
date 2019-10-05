using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.DataAccess
{
    public class daCustomer:daHelper
    {
        private static string _TableName="Customer";

        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.Customer create(Entity.Customer itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuCustomer";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "CREATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, DBNull.Value);
            daHelper.addInParameter(sqlCmd, "@Code", SqlDbType.VarChar, itemObject.Code);
            daHelper.addInParameter(sqlCmd, "@PrivilegeCardCode", SqlDbType.VarChar, itemObject.PrivilegeCardCode);
            daHelper.addInParameter(sqlCmd, "@CDNumbers", SqlDbType.VarChar, itemObject.CDNumbers);
            daHelper.addInParameter(sqlCmd, "@FathersName", SqlDbType.VarChar, itemObject.FathersName);
            daHelper.addInParameter(sqlCmd, "@FathersBirthDate", SqlDbType.DateTime, itemObject.FathersBirthDate);
            daHelper.addInParameter(sqlCmd, "@FathersLandLine", SqlDbType.VarChar, itemObject.FathersLandLine);
            daHelper.addInParameter(sqlCmd, "@FathersCellNumber", SqlDbType.VarChar, itemObject.FathersCellNumber);
            daHelper.addInParameter(sqlCmd, "@MothersName", SqlDbType.VarChar, itemObject.MothersName);
            daHelper.addInParameter(sqlCmd, "@MothersBirthDate", SqlDbType.DateTime, itemObject.MothersBirthDate);
            daHelper.addInParameter(sqlCmd, "@MothersLandLine", SqlDbType.VarChar, itemObject.MothersLandLine);
            daHelper.addInParameter(sqlCmd, "@MothersCellNumber", SqlDbType.VarChar, itemObject.MothersCellNumber);
            daHelper.addInParameter(sqlCmd, "@Address", SqlDbType.VarChar, itemObject.Address);
            daHelper.addInParameter(sqlCmd, "@Area", SqlDbType.VarChar, itemObject.Area);
            daHelper.addInParameter(sqlCmd, "@Email", SqlDbType.VarChar, itemObject.Email);


            //Execute the command
            DataSet ds = daHelper.executeProcedure(sqlCmd);

            return new Entity.Customer(ds.Tables[0].Rows[0]);
        }
        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.Customer> retrieve()
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName);

            List<Entity.Customer> entityList = new List<PhotoStore.Entity.Customer>();
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    entityList.Add(new Entity.Customer(dr));
                }
            }
            return entityList;
        }

        public static List<Entity.Customer> retrieveBySQL(string sqlStatement)
        {
            DataSet ds = daHelper.executeSelect(sqlStatement);

            List<Entity.Customer> entityList = new List<PhotoStore.Entity.Customer>();
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    entityList.Add(new Entity.Customer(dr));
                }
            }
            return entityList;
        }
        /// <summary>
        /// Retrieve all order by customer
        /// </summary>
        /// <param name="customerId">record id of the particular customer</param>
        /// <returns>record set from customer_ordertransaction_vw </returns>
        public static DataSet retrieveOrderByCustomer(long customerId)
        {
            return executeSelect(string.Concat("SELECT * FROM Customer_OrderTransaction_vw WHERE CustomerId=", customerId));
        }
        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.Customer retrieve(long Id)
        {
            daPrivilegeCard.UpdatePriviledgeCardCode(Id);
            DataRow dr = daHelper.executeSelectById(_TableName, Id);
            return new Entity.Customer(dr);
        }
      
        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Id">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.Customer retrieve(string Code)
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName + " where Code='" + Code + "'");
            if (ds == null) return null;
            DataRowCollection drc = ds.Tables[0].Rows;
            return new Entity.Customer(drc[0]);
        }

        public static List<Entity.PriviledgeCardCombo> retrievePriviledgeCard()
        {
            List<Entity.PriviledgeCardCombo> customers = new List<Entity.PriviledgeCardCombo>();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT Id,PrivilegeCardCode AS PriviledgedCardCode FROM Customer WHERE PrivilegeCardCode!=NULL OR PrivilegeCardCode!=''");
            using (DataSet ds = daHelper.executeSelect(sb.ToString()))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        //customers.Add(new Entity.Customer(dr));
                        //customers.Add((long)dr["Id"], dr["PrivilegeCardCode"].ToString());
                        Entity.PriviledgeCardCombo pcc = new PhotoStore.Entity.PriviledgeCardCombo(
                            (long)dr["Id"], dr["PriviledgedCardCode"].ToString());
                        customers.Add(pcc);
                        pcc = null;
                    }
                }
            }
            return customers;
        }
     
        /// <summary>Retrieve the next code.</summary>
        /// <returns>Return Entity object.</returns>
        public static string retrieveNextCode()
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuCustomer";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "RETRIEVE_NEXT_CODE");

            //Execute the command
            return daHelper.executeProcedure(sqlCmd).Tables[0].Rows[0]["Code"].ToString();
        }
        
        /// <summary>retrieve all data that matches the entities parameters</summary>
        /// <param name="itemObject"></param>
        /// <returns></returns>
        public static List<Entity.Customer> retrieveByEntity(Entity.Customer CustomerObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuCustomer";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "RETRIEVE_BY_ENTITY");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, -1);
            daHelper.addInParameter(sqlCmd, "@PrivilegeCardCode", SqlDbType.VarChar, CustomerObject.PrivilegeCardCode);
            daHelper.addInParameter(sqlCmd, "@FathersName", SqlDbType.VarChar, CustomerObject.FathersName);
            daHelper.addInParameter(sqlCmd, "@MothersName", SqlDbType.VarChar, CustomerObject.MothersName);
            daHelper.addInParameter(sqlCmd, "@Address", SqlDbType.VarChar, CustomerObject.Address);

            if (CustomerObject.MothersBirthDate!=DateTime.MinValue)
            {
                daHelper.addInParameter(sqlCmd, "@MothersBirthDate", SqlDbType.DateTime, CustomerObject.MothersBirthDate);
                
            }
            if (CustomerObject.FathersBirthDate != DateTime.MinValue)
            {
                daHelper.addInParameter(sqlCmd, "@FathersBirthDate", SqlDbType.DateTime, CustomerObject.FathersBirthDate);
            }
            daHelper.addInParameter(sqlCmd, "@FathersCellNumber", SqlDbType.VarChar, CustomerObject.FathersCellNumber.Trim());
            daHelper.addInParameter(sqlCmd, "@MothersCellNumber", SqlDbType.VarChar, CustomerObject.MothersCellNumber.Trim());
            //Execute the command
            //Execute the command
            DataSet ds = daHelper.executeProcedure(sqlCmd);

            List<Entity.Customer> entityList = new List<PhotoStore.Entity.Customer>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                entityList.Add(new Entity.Customer(dr));
            }
            return entityList;
        }


        #endregion

        #region update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static void update(Entity.Customer itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuCustomer";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "UPDATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, itemObject.Id);
            daHelper.addInParameter(sqlCmd, "@Code", SqlDbType.VarChar, itemObject.Code);
            daHelper.addInParameter(sqlCmd, "@PrivilegeCardCode", SqlDbType.VarChar, itemObject.PrivilegeCardCode);
            daHelper.addInParameter(sqlCmd, "@CDNumbers", SqlDbType.VarChar, itemObject.CDNumbers);
            daHelper.addInParameter(sqlCmd, "@FathersName", SqlDbType.VarChar, itemObject.FathersName);
            daHelper.addInParameter(sqlCmd, "@FathersBirthDate", SqlDbType.DateTime, itemObject.FathersBirthDate);
            daHelper.addInParameter(sqlCmd, "@FathersLandLine", SqlDbType.VarChar, itemObject.FathersLandLine);
            daHelper.addInParameter(sqlCmd, "@FathersCellNumber", SqlDbType.VarChar, itemObject.FathersCellNumber);
            daHelper.addInParameter(sqlCmd, "@MothersName", SqlDbType.VarChar, itemObject.MothersName);
            daHelper.addInParameter(sqlCmd, "@MothersBirthDate", SqlDbType.DateTime, itemObject.MothersBirthDate);
            daHelper.addInParameter(sqlCmd, "@MothersLandLine", SqlDbType.VarChar, itemObject.MothersLandLine);
            daHelper.addInParameter(sqlCmd, "@MothersCellNumber", SqlDbType.VarChar, itemObject.MothersCellNumber);
            daHelper.addInParameter(sqlCmd, "@Address", SqlDbType.VarChar, itemObject.Address);
            daHelper.addInParameter(sqlCmd, "@Area", SqlDbType.VarChar, itemObject.Area);
            daHelper.addInParameter(sqlCmd, "@Email", SqlDbType.VarChar, itemObject.Email);
            

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
            sqlCmd.CommandText = "spuCustomer";
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
