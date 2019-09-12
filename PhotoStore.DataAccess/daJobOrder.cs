using System;
using System.Collections.Generic;
using System.Text;
using PhotoStore.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PhotoStore.DataAccess
{
    public class daJobOrder 
    {
        private static string _TableName = "JobOrder";

        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.JobOrder create(Entity.JobOrder itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuJobOrder";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "CREATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, DBNull.Value);
            daHelper.addInParameter(sqlCmd, "@Code", SqlDbType.VarChar, itemObject.Code);
            //daHelper.addInParameter(sqlCmd, "@IsDone", SqlDbType.Bit, itemObject.IsDone);
            daHelper.addInParameter(sqlCmd, "@TransactionDate", SqlDbType.DateTime, itemObject.TransactionDate);


            //Execute the command
            DataSet ds = daHelper.executeProcedure(sqlCmd);
            return new Entity.JobOrder(ds.Tables[0].Rows[0]);
        }
        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.JobOrder> retrieve()
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName);

            List<Entity.JobOrder> entityList = new List<PhotoStore.Entity.JobOrder>();
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    entityList.Add(new Entity.JobOrder(dr));
                }
            }
            return entityList;
        }
        public static int GetOrderDetailsCount()
        {
            int count = 0;
            using (DataSet ds = daHelper.executeSelect("SELECT * FROM OrderTransactionDetail"))
            {
                if (ds != null)
                {
                    count = ds.Tables[0].Rows.Count;
                }
            }
            return count;
        }

   
        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.JobOrder retrieve(long Id)
        {
            DataRow dr = daHelper.executeSelectById(_TableName, Id);
            return new Entity.JobOrder(dr);
        }
        public static List<Entity.MissingJobOrder> retrieveMissingJobOrder()
        {
            List<Entity.MissingJobOrder> missingJobOrders = new List<MissingJobOrder>();
            using (DataSet ds = daHelper.executeSelect(
                "SELECT * FROM vwMissingItems"))
            {
                if (ds != null)
                {
                    Entity.MissingJobOrder mjo;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        mjo = new MissingJobOrder(dr);
                        missingJobOrders.Add(mjo);
                        mjo = null;
                    }
                }
            }
            return missingJobOrders;
        }
        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Id">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.JobOrder retrieve(string Code)
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName + " where Code='" + Code + "'");
            if (ds == null) return null;
            DataRowCollection drc = ds.Tables[0].Rows;
            return new Entity.JobOrder(drc[0]);
        }

        /// <summary>Retrieve the next code.</summary>
        /// <returns>Return Entity object.</returns>
        public static string retrieveNextCode()
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuJobOrder";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "RETRIEVE_NEXT_CODE");

            //Execute the command
            return daHelper.executeProcedure(sqlCmd).Tables[0].Rows[0]["Code"].ToString();
        }

        /// <summary>
        /// Get the data for JobOrder Creation
        /// </summary>
        /// <returns>DataSet of JobOrder to create</returns>
        public static List<PhotoStore.Entity.CreateJO> RetrieveDataCreateJobOrderData()
        {
            DataSet ds = daHelper.executeSelect("Select * from CreateJO_vw");
            List<Entity.CreateJO> entityList = new List<PhotoStore.Entity.CreateJO>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                entityList.Add(new Entity.CreateJO(dr));
            }
            return entityList;
        }
        /// <summary>
        /// Retrieve all JobOrder records which are saved but not yet done
        /// </summary>
        /// <returns>JobOrder Records</returns>
        public static bool IsPendingJobOrderExist()
        {
            bool ret = false;
            //call retrieval
            using (DataSet ds = daHelper.executeSelect(string.Concat("SELECT * FROM ", _TableName, " WHERE IsDone=0")))
            {
                if(ds!=null)
                    ret = (ds.Tables[0].Rows.Count > 0) ? true : false;
            }
            return ret;

        }
        public static List<ReleaseReport> GetReleaseReport(long id)
        {
            List<ReleaseReport> retValue = new List<ReleaseReport>();
            using (DataSet ds = daHelper.executeSelect(
                string.Concat("SELECT * FROM ReleaseReportJo_vw WHERE Id=", id)))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ReleaseReport releaseReport = new ReleaseReport(dr);
                        retValue.Add(releaseReport);
                        releaseReport = null;
                    }
                }
            }
            return retValue;
        }

        public DataSet retrieveBySQL(string sqlStatement)
        {
            return daHelper.executeSelect(sqlStatement);
        }

        public static List<JobOrderReport> GetJobOrderReport(long id)
        {
            List<JobOrderReport> retValue = new List<JobOrderReport>();
            using (DataSet ds = daHelper.executeSelect(
                string.Format(@"SELECT DateCreated,OrderNumber,MothersName FROM ReleaseReportJo_vw WHERE id={0} GROUP BY OrderNumber,DateCreated,MothersName ORDER BY OrderNumber ASC", id)))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        JobOrderReport jor = new JobOrderReport(Convert.ToDateTime(dr["DateCreated"]),
                            dr["OrderNumber"].ToString());
                        if (dr["MothersName"] != DBNull.Value)
                        {
                            jor.MothersName = dr["MothersName"].ToString();
                        }

                        using (DataSet dsParticulars = daHelper.executeSelect(
                           string.Format(@"SELECT	SUM(Quantity) AS Quantity,Particulars,RejectedQuantity
                                FROM		ReleaseReportJo_vw 
                                WHERE		id={0} AND  OrderNumber='{1}'
                                GROUP BY	Particulars,RejectedQuantity
                                ORDER BY	Particulars ASC", id, dr["OrderNumber"])))
                        {
                            if (dsParticulars != null)
                            {
                                foreach (DataRow drParticulars in dsParticulars.Tables[0].Rows)
                                {
                                    Particulars particulars = new Particulars(
                                        drParticulars["Particulars"].ToString(),
                                        Convert.ToInt32(drParticulars["Quantity"]),
                                        Convert.ToInt32(drParticulars["RejectedQuantity"]));
                                    jor.Particulars.Add(particulars);
                                    particulars = null;

                                }
                            }
                        }
                        retValue.Add(jor);
                        jor = null;
                       
                    }
                }
            }
                      
            return retValue;
        }
        private static void AddVwJobOrderItems(DataSet ds,List<vwJobOrderItems> jobOrderItems,int pointer)
        {
           
            if (pointer < ds.Tables[0].Rows.Count)
            {
                vwJobOrderItems jobOrderItem = new vwJobOrderItems(ds.Tables[0].Rows[pointer]);
                jobOrderItems.Add(jobOrderItem);
                AddVwJobOrderItems(ds, jobOrderItems, ++pointer);
                jobOrderItems = null;
            }
          
        }

        public static List<vwJobOrderItems> GetJobOrderItem(string column,string direction,DateTime dtFrom,
            DateTime dtTo,string code,string customerName)
        {
            string sqlStatement = string.Format("SELECT * FROM vwJobOrderItems WHERE (DateCreated BETWEEN CONVERT(DATETIME,'{0}') AND CONVERT(DATETIME,'{1}'))",
                dtFrom.ToString(), dtTo.ToString());

            if (!string.IsNullOrEmpty(code) || !string.IsNullOrEmpty(customerName))
            {
                sqlStatement = string.Concat(sqlStatement, " AND (");
            }
            
            if (!string.IsNullOrEmpty(code))
            {
                
                sqlStatement = string.Concat(sqlStatement,"Code=@Code");
            }

            if (!string.IsNullOrEmpty(customerName))
            {
                if (!string.IsNullOrEmpty(code))
                {
                    sqlStatement = string.Concat(sqlStatement, " AND");
                }

                sqlStatement = string.Concat(sqlStatement, " CustomerName LIKE '%'+@CustomerName+'%'");
            }

            if (!string.IsNullOrEmpty(code) || !string.IsNullOrEmpty(customerName))
            {
                sqlStatement = string.Concat(sqlStatement, ")");
            }
            sqlStatement = string.Concat(sqlStatement, " ORDER BY {0} {1}");
            sqlStatement = string.Format(sqlStatement, column, direction);
            List<vwJobOrderItems> retValue = new List<vwJobOrderItems>();
            using (SqlCommand cmd = new SqlCommand(sqlStatement))
            {
                cmd.CommandType = CommandType.Text;
                if (!string.IsNullOrEmpty(code))                
                    daHelper.addInParameter(cmd, "@Code", SqlDbType.VarChar, code);

                if (!string.IsNullOrEmpty(customerName))
                    daHelper.addInParameter(cmd, "@CustomerName", SqlDbType.VarChar, customerName);

                using (DataSet ds = daHelper.executeSelect(cmd))
                {
                    if (ds != null)
                    {
                        AddVwJobOrderItems(ds, retValue, 0);
                    }
                }
            }

            //List<vwJobOrderItems> retValue = new List<vwJobOrderItems>();
            //using (DataSet ds = daHelper.executeSelect(string.Format(
            //    "SELECT * FROM vwJobOrderItems ORDER BY {0} {1}",
            //                                column
            //                                , direction)))
            //{
            //    if (ds != null)
            //    {
            //        AddVwJobOrderItems(ds, retValue, 0);
            //    }
            //}
            return retValue;
        }

        public static List<vwJobOrderItems> GetUnsavedJobOrders()
        {
            List<vwJobOrderItems> retValue = new List<vwJobOrderItems>();
            using (DataSet ds = daHelper.executeSelect(
                "SELECT * FROM vwJobOrderItems WHERE JobOrderId IS NOT NULL AND IsDone=0"
                                           ))
            {
                if (ds != null)
                {
                   // foreach (DataRow dr in ds.Tables[0].Rows)
                    //{
                        AddVwJobOrderItems(ds, retValue, 0);
                    //}
                }
            }
            return retValue;
        }

        public static int GetUnsavedJobOrdersCount()
        {
            int retValue = 0;
            using (DataSet ds = daHelper.executeSelect(
               "SELECT COUNT(*) AS TotalCount FROM vwJobOrderItems WHERE JobOrderId IS NOT NULL AND IsDone=0"
                                          ))
            {
                if (ds != null)
                {
                    retValue = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalCount"]);
                }
            }
            return retValue;
        }
        public static JobOrder GetNotDoneJobOrder()
        {
            JobOrder jo=null;
            using (DataSet ds = daHelper.executeSelect(string.Concat("SELECT * FROM ", _TableName, " WHERE IsDone=0")))
            {
                if(ds!=null)
                {
                    jo=new JobOrder(ds.Tables[0].Rows[0]);
                }
                    
            }
            return jo;

        }
        public static List<JobOrder> retrieveByWhereStatement(string wherestatement)
        {
            List<JobOrder> jobOrders = new List<JobOrder>();
            using (DataSet ds = daHelper.executeSelect(string.Format(
                "SELECT * FROM {0} {1}", _TableName, wherestatement)))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        jobOrders.Add(new JobOrder(dr));
                    }
                }

            }
            return jobOrders;

        }
        /// <summary>
        /// Get the JO record
        /// </summary>
        /// <returns>JobOrder collection</returns>
        public static List<PhotoStore.Entity.CreateJO> spGetJO()
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "sp_GetJO";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            DataSet ds = daHelper.executeProcedure(sqlCmd);
            List<Entity.CreateJO> entityList = new List<PhotoStore.Entity.CreateJO>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                entityList.Add(new Entity.CreateJO(dr));
            }
            return entityList;
        }
        /// <summary>
        /// Get the search categories
        /// </summary>
        /// <returns>Data from Reference table where Category is equal to Search</returns>
        public static List<Entity.SearchCategory> SearchCategories()
        {
            DataSet ds = daHelper.executeSelect("SELECT Code,Description FROM Reference WHERE Category='SearchJobOrder'");

            List<Entity.SearchCategory> entityList = new List<PhotoStore.Entity.SearchCategory>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                entityList.Add(new Entity.SearchCategory(dr));
            }
            return entityList;
        }
        /// <summary>
        /// Search the data in SearchOrder_vw
        /// </summary>
        /// <param name="mode">0=All,1=Order Number,2=Mother's name etc</param>
        /// <param name="filterValue">value to used in filtering</param>
        /// <returns></returns>
        public static List<PhotoStore.Entity.SearchJO> SearchByCategory(int mode, string filterValue)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuSearchBy";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;
            daHelper.addInParameter(sqlCmd, "@Code", SqlDbType.Int, mode);
            daHelper.addInParameter(sqlCmd, "@FilterValue", SqlDbType.NVarChar, filterValue);
            DataSet ds = daHelper.executeProcedure(sqlCmd);

            List<Entity.SearchJO> entityList = new List<PhotoStore.Entity.SearchJO>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                entityList.Add(new Entity.SearchJO(dr));
            }
            return entityList;

        }
        public static List<PhotoStore.Entity.JobOrderByType> GetJobOrderByType(int ordertype)
        {
            List<PhotoStore.Entity.JobOrderByType> retValues = new List<PhotoStore.Entity.JobOrderByType>();
            using (DataSet ds = daHelper.executeSelect(string.Format(@"SELECT	JO.ID AS JOBORDERID,JO.CODE,JO.QUANTITY,OTOTD.CODE AS ORDERTRANSACTIONCODE,S.CODE AS SUPPLIERCODE	
                                                                        FROM 
                                                                        JOBORDER JO 
                                                                        LEFT JOIN	
                                                                        (SELECT OT.CODE,OTD.PARTICULARCODE,OTD.PARTICULARS,OTD.QUANTITY,OTD.ID
                                                                         FROM ORDERTRANSACTION OT
                                                                         LEFT JOIN ORDERTRANSACTIONDETAIL OTD
                                                                         ON OT.ID=OTD.ORDERTRANSACTIONID) OTOTD
                                                                        ON JO.ORDERDETAILSID_FK=OTOTD.ID
                                                                        LEFT JOIN
                                                                        SUPPLIER S
                                                                        ON
                                                                        JO.SUPPLIERID_FK=S.ID
                                                                        WHERE ISDONE={0}", ordertype))) 
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        PhotoStore.Entity.JobOrderByType joType = new PhotoStore.Entity.JobOrderByType(dr);
                        retValues.Add(joType);
                    }
                
                }
               

            }
            return retValues;
        }
        public static DataSet ExecSpGetAvailableQuantity(long joborderdetailsid,
            long ordertransactiondetailsid, int desiredquantity,long orderpackagedetailid)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "spGetAvailableQuantity";
            sqlCommand.CommandTimeout = daHelper.commandTimeout;
            daHelper.addInParameter(sqlCommand, "@JobOrderDetailsId", SqlDbType.BigInt,
                joborderdetailsid);
            daHelper.addInParameter(sqlCommand, "@OrderTransactionDetailsId",
                SqlDbType.BigInt, ordertransactiondetailsid);
            daHelper.addInParameter(sqlCommand, "@DesiredQuantity", SqlDbType.Int,
                desiredquantity);
            daHelper.addInParameter(sqlCommand, "@OrderPackageDetailId", SqlDbType.BigInt, orderpackagedetailid);
            return daHelper.executeProcedure(sqlCommand);
        }

        public static DataSet ExecSpGetJobOrderItems(bool hasjoborder)
        {
            string[] gcTypes = ConfigurationManager.AppSettings["gcparticulartype"].ToString().Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < gcTypes.Length; i++)
            {
                if (i == gcTypes.Length - 1)
                {
                    sb.Append(string.Concat("\'", gcTypes[i], "\'"));
                }
                else
                {
                    sb.Append(string.Concat("\'", gcTypes[i], "\',"));
                }
            }
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spJobOrderItems";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;

            //daHelper.addInParameter(sqlCmd, "@GCParticularType", SqlDbType.VarChar, sb.ToString());
            daHelper.addInParameter(sqlCmd, "@HasJobOrder", SqlDbType.Bit, hasjoborder);
            
            //Execute the command
            
            return daHelper.executeProcedure(sqlCmd);

        }

        public enum ActualJOType { ShowTally, ReleaseReport }
        /// <summary>
        /// Get the actual Job order for reporting purposes
        /// </summary>
        /// <param name="actualJOType">Enumeration of ActualJOType</param>
        /// <param name="JONumber">Job Order Number</param>
        /// <returns>Records of actualJo in dataset type</returns>
        public static List<PhotoStore.Entity.ActualJO> GetActualJO(ActualJOType actualJOType, string JONumber)
        {
            DataSet ds = null;
            switch (actualJOType)
            {
                case ActualJOType.ShowTally:
                    ds = daHelper.executeSelect(string.Concat("SELECT * FROM ActualJO_vw WHERE Code='",
                        JONumber, "' ORDER BY SupplierDescription ASC"));
                    break;
                default:
                    ds = daHelper.executeSelect(string.Concat("SELECT * FROM ActualJO_vw WHERE Code='",
                        JONumber, "' ORDER BY DateCreated DESC"));
                    break;
            }

            List<Entity.ActualJO> entityList = new List<PhotoStore.Entity.ActualJO>();
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    entityList.Add(new Entity.ActualJO(dr));
                }
            }
            return entityList;
        }
        public static List<Tally> GetTally(long id,string column,string direction)
        {
            List<Tally> tallies = new List<Tally>();
            using (DataSet ds = daHelper.executeSelect(string.Format(@"SELECT			TJVW.Id
                                                                                        ,TJVW.Code
				                                                                        ,SUM(TJVW.Qty) AS Qty
				                                                                        ,TJVW.SupplierCode
				                                                                        ,TJVW.Particulars 
                                                                        FROM			TallyJo_vw TJVW
                                                                        WHERE Id={0}
                                                                        GROUP BY		TJVW.Id,TJVW.SupplierCode,TJVW.Particulars,TJVW.Code
                                                                        ORDER BY  {1} {2}"
                                                                        , id
                                                                        ,column
                                                                        ,direction)))
            {
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            Tally tally = new Tally(dr);
                            tallies.Add(tally);
                            tally = null;
                        }
                    }
                }
            }
            return tallies;
        }
        #endregion

        #region update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static void update(Entity.JobOrder itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuJobOrder";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "UPDATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int,itemObject.Id);
            //daHelper.addInParameter(sqlCmd, "@Code", SqlDbType.VarChar, itemObject.Code);
            //daHelper.addInParameter(sqlCmd, "@IsDone", SqlDbType.Bit, itemObject.IsDone);            
            //Execute the command
            daHelper.executeNonQuery(sqlCmd);

        }
        #endregion

        public static void executeAdjustment()
        {
             SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;//CommandType.Text;
            sqlCommand.CommandText = "[dbo].[spItemsFailedToSaveInJobOrder]";
            sqlCommand.CommandTimeout = daHelper.commandTimeout;
            daHelper.executeProcedure(sqlCommand);
        }
        public static void CreateJobOrderDetails(
            long orderdetailsid, long supplierid,
            int consumedquantity, long joborderid,long orderpackagedetailsid,byte isdone)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;//CommandType.Text;
            sqlCommand.CommandText = "spuJobOrderDetails";
            sqlCommand.CommandTimeout = daHelper.commandTimeout;
            //if (orderpackagedetailsid == -1)
            //{
//                sqlCommand.CommandText = string.Format(@"Insert into JobOrderDetails(OrderDetails_Id,Supplier_Id,ConsumedQuantity,JobOrder_Id,IsDone)
//                                                     Values({0},{1},{2},{3},{4})"
//                                                         , orderdetailsid
//                                                         , supplierid
//                                                         , consumedquantity
//                                                         , joborderid
//                                                         ,isdone
//                                                         );
                daJobOrderDetail.create(orderdetailsid, supplierid, consumedquantity, joborderid, orderpackagedetailsid, isdone);
            //}
            //else
            //{
//                sqlCommand.CommandText = string.Format(@"Insert into JobOrderDetails(OrderDetails_Id,Supplier_Id,ConsumedQuantity,JobOrder_Id,OrderPackageDetailsId,IsDone)
//                                                     Values({0},{1},{2},{3},{4},{5})"
//                                                         , orderdetailsid
//                                                         , supplierid
//                                                         , consumedquantity
//                                                         , joborderid
//                                                         ,orderpackagedetailsid
//                                                         ,isdone
//                                                         );
            //}
            daHelper.executeNonQuery(sqlCommand);

        }

        public static void UpdateJobOrderDetails(long id,
            long supplierid, int consumedquantity,byte isdone)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandTimeout = daHelper.commandTimeout;
           
                sqlCommand.CommandText = string.Format(@"Update JobOrderDetails Set Supplier_Id={0},ConsumedQuantity={1},IsDone={2} Where Id={3}"
                                                         , supplierid
                                                         , consumedquantity
                                                         ,isdone
                                                         , id);
        
           
            daHelper.executeNonQuery(sqlCommand);
        }


        #region delete
        /// <summary>Delete an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static void delete(long Id)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuJobOrder";
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

      