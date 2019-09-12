using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
namespace PhotoStore.DataAccess
{
    public class daOrderTransaction 
    {
        private static string _TableName = "OrderTransaction";

        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.OrderTransaction create(Entity.OrderTransaction itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuOrderTransaction";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "CREATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, DBNull.Value);
            daHelper.addInParameter(sqlCmd, "@Code", SqlDbType.VarChar, itemObject.Code);
            daHelper.addInParameter(sqlCmd, "@DateCreated", SqlDbType.DateTime, itemObject.DateCreated);
            daHelper.addInParameter(sqlCmd, "@CustomerId", SqlDbType.BigInt, itemObject.CustomerId);
            daHelper.addInParameter(sqlCmd, "@OrderStatusId", SqlDbType.BigInt, itemObject.OrderStatusId);
            daHelper.addInParameter(sqlCmd, "@PrivilegeCardCode", SqlDbType.VarChar, itemObject.PriviledgeCard);
            //daHelper.addInParameter(sqlCmd, "@Freebies", SqlDbType.VarChar, itemObject.Freebies);
            daHelper.addInParameter(sqlCmd, "@PreparedByEmployeeId", SqlDbType.BigInt, itemObject.PreparedByEmployeeId);
            daHelper.addInParameter(sqlCmd, "@CancelledCode", SqlDbType.VarChar, itemObject.CancelledCode);
            daHelper.addInParameter(sqlCmd, "@RejectedCode", SqlDbType.VarChar, itemObject.RejectedCode);


            //Execute the command
            DataSet ds = daHelper.executeProcedure(sqlCmd);

            return new Entity.OrderTransaction(ds.Tables[0].Rows[0]);
        }
        #endregion

        #region Retrieve
        public static Entity.OrderTransaction GetRejectedTransaction(string refcode)
        {
            Entity.OrderTransaction orderTransaction = null;
            using (DataSet ds = daHelper.executeSelect(
                string.Format("SELECT * FROM {0} WHERE RejectedCode='{1}'",
                            _TableName
                            , refcode)))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        orderTransaction = new PhotoStore.Entity.OrderTransaction(dr);
                    }
                }
            }
            return orderTransaction;
        }

                /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.OrderTransaction> retrieve()
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName);

            List<Entity.OrderTransaction> entityList = new List<PhotoStore.Entity.OrderTransaction>();

            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    entityList.Add(new Entity.OrderTransaction(dr));
                }
            }

            return entityList;
        }

        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.OrderTransaction retrieve(long Id)
        {
            DataRow dr = daHelper.executeSelectById<long>(_TableName, Id);
            return new Entity.OrderTransaction(dr);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Id">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.OrderTransaction retrieve(string Code)
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName + " where Code='" + Code + "'");
            if (ds == null) return null;
            DataRowCollection drc = ds.Tables[0].Rows;
            return new Entity.OrderTransaction(drc[0]);
        }
        

        /// <summary>Retrieve the next code.</summary>
        /// <returns>Return Entity object.</returns>
        public static string retrieveNextCode()
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuOrderTransaction";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "RETRIEVE_NEXT_CODE");

            //Execute the command
            return daHelper.executeProcedure(sqlCmd).Tables[0].Rows[0]["Code"].ToString();
           
        }


        public static List<Entity.OrderTransaction> GetOrderTransaction(
                                                    string ordernumber
                                                    , string priviledgecode
                                                    , string fathername
                                                    , string mothername
                                                    , string address)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "spSearchOrderTransaction";
            cmd.CommandTimeout = daHelper.commandTimeout;
            cmd.CommandType = CommandType.StoredProcedure;

            daHelper.addInParameter(cmd, "@ORDERNUMBER", SqlDbType.VarChar, ordernumber);
            daHelper.addInParameter(cmd, "@PRIVILEDGECARDCODE", SqlDbType.VarChar, priviledgecode);
            daHelper.addInParameter(cmd, "@FATHERNAME", SqlDbType.VarChar, fathername);
            daHelper.addInParameter(cmd, "@MOTHERNAME", SqlDbType.VarChar, mothername);
            daHelper.addInParameter(cmd, "@ADDRESS", SqlDbType.VarChar, address);
            List<PhotoStore.Entity.OrderTransaction> retValues = new List<PhotoStore.Entity.OrderTransaction>();
            using (DataSet ds = daHelper.executeProcedure(cmd))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        PhotoStore.Entity.OrderTransaction orderTransaction = new PhotoStore.Entity.OrderTransaction(
                            dr);
                        retValues.Add(orderTransaction);
                        orderTransaction = null;
                    }
                }
            }
            return retValues;


        }

        public static List<Entity.OrderTransactionView> GetOrderTransactionView(
                                                    string ordernumber
                                                    , string priviledgecode
                                                    , string fathername
                                                    , string mothername
                                                    , string address
                                                    ,DateTime? dtFrom
                                                    ,DateTime? dtTo
                                                    ,string sortedcolumn
                                                    ,ListSortDirection sortdirection)
        {
            string dataCol = string.Empty;
            switch (sortedcolumn)
            {
                case "colCode":
                    dataCol = "OT.Code";
                    break;
                case "colTransactionDate":
                    dataCol = "DateCreated";
                    break;
                case "colMothersName":
                    dataCol = "MothersName";
                    break;
                case "colBalance":
                    dataCol = "TotalBalance";
                    break;
                case "colTotalAmount":
                    dataCol = "TransactionAmount";
                    break;
                case "colFullName":
                    dataCol = "FullName";
                    break;
            }
            string direction = sortdirection == ListSortDirection.Ascending ? "ASC" : "DESC";

            SqlCommand cmd = new SqlCommand();           
            cmd.CommandTimeout = daHelper.commandTimeout;
            cmd.CommandType = CommandType.Text;

            string sqlQuery = @"SELECT			OT.*,ISNULL(OTD.TransactionAmount,0.00) AS TransactionAmount,ISNULL(E.FullName,'#Deleted Employee#') AS FullName
                                ,(ISNULL(vBR.TotalPrice,0) - ISNULL(vBR.TotalPayment,0)) AS TotalBalance,C.MothersName
                                FROM			ORDERTRANSACTION		OT
                                LEFT JOIN		
                                (
	                                SELECT		OrderTransactionId,SUM(Amount) AS TransactionAmount
	                                FROM		OrderTransactionDetail 
	                                GROUP		BY OrderTransactionId
                                )				AS						OTD
                                ON				OT.Id		=		OTD.OrderTransactionId
                                LEFT JOIN		Employee				E
                                ON				OT.PreparedByEmployeeId = E.Id
                                INNER JOIN		CUSTOMER				C
                                ON				OT.CUSTOMERID=C.ID
                                LEFT JOIN		vwBalanceReport			vBR
                                ON				OT.Id =	vBR.Id WHERE";
            if (!string.IsNullOrEmpty(ordernumber))
            {
                
                sqlQuery = string.Concat(sqlQuery, " OT.CODE LIKE @CODE AND");               
                daHelper.addInParameter(cmd, "@CODE", SqlDbType.VarChar, ordernumber);
            }
            if (!string.IsNullOrEmpty(fathername))
            {
                
                sqlQuery = string.Concat(sqlQuery, " C.FATHERSNAME LIKE '%'+@FATHERSNAME+'%' AND");
                daHelper.addInParameter(cmd, "@FATHERSNAME", SqlDbType.VarChar, fathername);
            }
            if (!string.IsNullOrEmpty(mothername))
            {
                sqlQuery = string.Concat(sqlQuery, " C.MOTHERSNAME LIKE '%'+@MOTHERSNAME+'%' AND");
              
                daHelper.addInParameter(cmd, "@MOTHERSNAME", SqlDbType.VarChar, mothername);
            }
            if (!string.IsNullOrEmpty(address))
            {
                sqlQuery = string.Concat(sqlQuery, " C.ADDRESS LIKE '%'+@ADDRESS+'%' AND");
                daHelper.addInParameter(cmd, "@ADDRESS", SqlDbType.VarChar, address);
            }
            if (dtFrom.HasValue)
            {
                sqlQuery = string.Concat(sqlQuery, " vBR.DateCreated BETWEEN @STARTDATE AND @ENDDATE");
                daHelper.addInParameter(cmd, "@STARTDATE", SqlDbType.DateTime, dtFrom.Value.Date);
                daHelper.addInParameter(cmd, "@ENDDATE", SqlDbType.DateTime, dtTo.Value);
            }
            sqlQuery = sqlQuery.EndsWith("AND") ? sqlQuery.TrimEnd(new char[3] { 'A', 'N', 'D' }) : sqlQuery;
            sqlQuery = string.Concat(sqlQuery, string.Format(" ORDER BY {0} {1}", dataCol, direction));

          cmd.CommandText = sqlQuery;
            List<PhotoStore.Entity.OrderTransactionView> retValues = new List<PhotoStore.Entity.OrderTransactionView>();
            using (DataSet ds = daHelper.executeProcedure(cmd))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        PhotoStore.Entity.OrderTransactionView orderTransaction = new PhotoStore.Entity.OrderTransactionView(
                            dr);
                        retValues.Add(orderTransaction);
                        orderTransaction = null;
                    }
                }
            }
            return retValues;


        }
        #endregion

        #region update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static void update(Entity.OrderTransaction itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuOrderTransaction";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "UPDATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, itemObject.Id);
            daHelper.addInParameter(sqlCmd, "@Code", SqlDbType.VarChar, itemObject.Code);
            daHelper.addInParameter(sqlCmd, "@DateCreated", SqlDbType.DateTime, itemObject.DateCreated);
            daHelper.addInParameter(sqlCmd, "@CustomerId", SqlDbType.BigInt, itemObject.CustomerId);
            daHelper.addInParameter(sqlCmd, "@OrderStatusId", SqlDbType.BigInt, itemObject.OrderStatusId);
            daHelper.addInParameter(sqlCmd, "@PrivilegeCardCode", SqlDbType.VarChar, itemObject.PriviledgeCard);
            //daHelper.addInParameter(sqlCmd, "@Freebies", SqlDbType.VarChar, itemObject.Freebies);
            daHelper.addInParameter(sqlCmd, "@PreparedByEmployeeId", SqlDbType.BigInt, itemObject.PreparedByEmployeeId);
            daHelper.addInParameter(sqlCmd, "@CancelledCode", SqlDbType.VarChar, itemObject.CancelledCode);
            daHelper.addInParameter(sqlCmd, "@RejectedCode", SqlDbType.VarChar, itemObject.RejectedCode);
            

            //Execute the command
            daHelper.executeNonQuery(sqlCmd);

        }
        #endregion

        #region delete
        /// <summary>Delete an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static void delete(int Id)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuOrderTransaction";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "DELETE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, Id);

            //Execute the command
            daHelper.executeNonQuery(sqlCmd);

        }
        #endregion

        #region Custom
        /// <summary>Revise a cancelled transaction.</summary>
        /// <param name="OrderTransactionId"></param>
        /// <returns></returns>
        public static long revise(long OrderTransactionId)
        {

            //get the next transaction code
            string Code = retrieveNextCode();

            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuOrderTransaction";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "REVISE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, OrderTransactionId);//id of the canceled transaction
            daHelper.addInParameter(sqlCmd, "@Code", SqlDbType.VarChar, Code);//the new code of the revised transaction

            //Execute the command
            long orderTransactionId;
            using(DataSet ds=daHelper.executeProcedure(sqlCmd))
            {
                orderTransactionId=Convert.ToInt64(ds.Tables[ds.Tables.Count-1].Rows[0]["Id"]);
            }
            return orderTransactionId;
        }

        /// <summary>Reject a cancelled transaction.</summary>
        /// <param name="OrderTransactionId"></param>
        /// <returns></returns>
        public static int rejectOrder(long OrderTransactionId)
        {

            //get the next transaction code
            string Code = retrieveNextCode();

            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuOrderTransaction";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "REJECTORDER");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, OrderTransactionId);//id of the canceled transaction
            daHelper.addInParameter(sqlCmd, "@Code", SqlDbType.VarChar, Code);//the new code of the rejectd transaction

            //Execute the command
            return Convert.ToInt32(daHelper.executeProcedure(sqlCmd).Tables[0].Rows[0]["Id"]);
        }
        #endregion
    }
}
