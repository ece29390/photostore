using System;
using System.Collections.Generic;
using System.Text;
using PhotoStore.Entity;
using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.DataAccess
{
    public class daJobOrderDetail
    {
        private static string _TableName="JobOrderDetails";
        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static JobOrderDetail create(JobOrderDetail itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuJobOrderDetails";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "CREATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, DBNull.Value);
            daHelper.addInParameter(sqlCmd, "@OrderDetails_Id", SqlDbType.BigInt, itemObject.OrderDetailsId);
            daHelper.addInParameter(sqlCmd, "@Supplier_Id", SqlDbType.BigInt, itemObject.SupplierId);
            daHelper.addInParameter(sqlCmd, "@ConsumedQuantity", SqlDbType.Int, itemObject.ConsumedQuantity);
            daHelper.addInParameter(sqlCmd, "@JobOrder_Id", SqlDbType.BigInt, itemObject.JobOrderId);           
            daHelper.addInParameter(sqlCmd, "@IsDone", SqlDbType.Bit, itemObject.IsDone);
            //Execute the command
            DataSet ds = daHelper.executeProcedure(sqlCmd);
            return new JobOrderDetail(ds.Tables[0].Rows[0]);
        }
        public static void create(
            long orderdetailsid, long supplierid,
            int consumedquantity, long joborderid, long orderpackagedetailsid, byte isdone)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuJobOrderDetails";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "CREATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, DBNull.Value);
            daHelper.addInParameter(sqlCmd, "@OrderDetails_Id", SqlDbType.BigInt, orderdetailsid);
            daHelper.addInParameter(sqlCmd, "@Supplier_Id", SqlDbType.BigInt, supplierid);
            daHelper.addInParameter(sqlCmd, "@ConsumedQuantity", SqlDbType.Int, consumedquantity);
            daHelper.addInParameter(sqlCmd, "@JobOrder_Id", SqlDbType.BigInt, joborderid);
            daHelper.addInParameter(sqlCmd, "@IsDone", SqlDbType.Bit, isdone);
            if (orderpackagedetailsid != -1)
                daHelper.addInParameter(sqlCmd, "@OrderPackageDetailsId", SqlDbType.BigInt, orderpackagedetailsid);
            
            //Execute the command
             daHelper.executeProcedure(sqlCmd);
            //return new JobOrderDetail(ds.Tables[0].Rows[0]);
        }
        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.JobOrderDetail> retrieve()
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName);

            List<Entity.JobOrderDetail> entityList = new List<PhotoStore.Entity.JobOrderDetail>();
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    entityList.Add(new Entity.JobOrderDetail(dr));
                }
            }
            return entityList;
        }
        public static List<Entity.JobOrders> retrieveJobOrders(string sqlstatement)
        {
            DataSet ds = daHelper.executeSelect(sqlstatement);

            List<Entity.JobOrders> entityList = new List<PhotoStore.Entity.JobOrders>();
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    entityList.Add(new Entity.JobOrders(dr));
                }
            }
            return entityList;
        }
        public static List<JobOrderDetail> retrieveByWhereStatement(string wherestatement)
        {
            List<JobOrderDetail> jobOrderDetails = new List<JobOrderDetail>();
            using (DataSet ds = daHelper.executeSelect(string.Format(
                "SELECT * FROM {0} {1}", _TableName, wherestatement)))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        jobOrderDetails.Add(new JobOrderDetail(dr));
                    }
                }

            }
            return jobOrderDetails;

        }

        public static List<JobOrders> retrieveBySQL(string sqlstatement)
        {
            List<JobOrders> retValue = new List<JobOrders>();
            using (DataSet ds = daHelper.executeSelect(sqlstatement))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        JobOrders jobOrder = new JobOrders(dr);
                        retValue.Add(jobOrder);
                        jobOrder = null;
                    }
                }
            }
            return retValue;
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
        public static Entity.JobOrderDetail retrieve(int Id)
        {
            DataRow dr = daHelper.executeSelectById(_TableName, Id);
            return new Entity.JobOrderDetail(dr);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Id">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.JobOrderDetail retrieve(string Code)
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName + " where Code='" + Code + "'");
            if (ds == null) return null;
            DataRowCollection drc = ds.Tables[0].Rows;
            return new Entity.JobOrderDetail(drc[0]);
        }

        public static List<RejectedPackage> retrieveDoneJobOrder(
            long orderdetailid)
        {
            string sqlStatement = string.Format(@"SELECT		JO.Id
			                                                    ,JOD.Id AS JOBORDERDETAILSID
			                                                    ,OT.DateCreated
			                                                    ,JOD.ConsumedQuantity 	
			                                                    ,OPD.Particulars
			                                                    ,JO.Code AS JobOrderNumber--OT.Code AS ORDERNUMBER			
			                                                    ,OTD.Id AS OrderDetailsId
			                                                    ,JOD.OrderPackageDetailsId 
			                                                    ,dbo.fnGetCustomerName(C.FathersName,C.MothersName) AS CustomerName
                                                                ,OPD.RejectedQuantity
                                                    FROM		JobOrder JO
                                                    INNER JOIN	JobOrderDetails JOD
                                                    ON			JO.Id=JOD.JobOrder_Id
                                                    INNER JOIN	OrderTransactionDetail OTD
                                                    ON			JOD.OrderDetails_Id=OTD.Id
                                                    INNER JOIN	OrderTransaction OT
                                                    ON			OTD.OrderTransactionId=OT.Id
                                                    LEFT JOIN	OrderPackageDetails OPD
                                                    ON			JOD.OrderPackageDetailsId=OPD.Id
                                                    INNER JOIN	Customer C
                                                    ON			OT.CustomerId=C.Id
                                                    WHERE       JOD.OrderDetails_Id={0} AND JOD.IsDone=1",
                                                                                orderdetailid);

            List<RejectedPackage> rejectedPackage = new List<RejectedPackage>();
            using (DataSet ds = daHelper.executeSelect(sqlStatement))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        rejectedPackage.Add(new RejectedPackage(dr));
                    }
                }

            }
            return rejectedPackage;                                                                                                
                                                    
        }
      

     
        #endregion

        #region update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static void update(Entity.JobOrderDetail itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuJobOrderDetails";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "UPDATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt,itemObject.Id);
            daHelper.addInParameter(sqlCmd, "@OrderDetails_Id", SqlDbType.BigInt, itemObject.OrderDetailsId);
            daHelper.addInParameter(sqlCmd, "@Supplier_Id", SqlDbType.BigInt, itemObject.SupplierId);
            daHelper.addInParameter(sqlCmd, "@ConsumedQuantity", SqlDbType.Int, itemObject.ConsumedQuantity);
            daHelper.addInParameter(sqlCmd, "@JobOrder_Id", SqlDbType.BigInt, itemObject.JobOrderId);
            daHelper.addInParameter(sqlCmd, "@IsDone", SqlDbType.Bit, itemObject.IsDone);
            //Execute the command
            daHelper.executeNonQuery(sqlCmd);

        }

        public static void update(long id,
            long supplierid, int consumedquantity, byte isdone)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuJobOrderDetails";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "UPDATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt,id);
            //daHelper.addInParameter(sqlCmd, "@OrderDetails_Id", SqlDbType.BigInt, itemObject.OrderDetailsId);
            daHelper.addInParameter(sqlCmd, "@Supplier_Id", SqlDbType.BigInt, supplierid);
            daHelper.addInParameter(sqlCmd, "@ConsumedQuantity", SqlDbType.Int, consumedquantity);
           // daHelper.addInParameter(sqlCmd, "@JobOrder_Id", SqlDbType.BigInt, itemObject.JobOrderId);
            daHelper.addInParameter(sqlCmd, "@IsDone", SqlDbType.Bit, isdone);
            //Execute the command
            daHelper.executeNonQuery(sqlCmd);
        }
        public static void updateJobOrderItems(long id,
                string suppliercode, int consumedquantity, long joborderid
            , byte isdone, bool isselected)
        {
            string mode = isselected ? "UPDATECHECKITEM" : "UPDATEUNCHECKITEM";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuJobOrders";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, mode);
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, id);
            //daHelper.addInParameter(sqlCmd, "@OrderDetails_Id", SqlDbType.BigInt, itemObject.OrderDetailsId);
            daHelper.addInParameter(sqlCmd, "@SupplierCode", SqlDbType.VarChar, suppliercode);
            daHelper.addInParameter(sqlCmd, "@ConsumedQuantity", SqlDbType.Int, consumedquantity);
            // daHelper.addInParameter(sqlCmd, "@JobOrder_Id", SqlDbType.BigInt, itemObject.JobOrderId);
            daHelper.addInParameter(sqlCmd, "@IsDone", SqlDbType.Bit, isdone);
            //daHelper.addInParameter(sqlCmd, "@IsSave", SqlDbType.Bit, issave);
            daHelper.addInParameter(sqlCmd, "@JobOrderId", SqlDbType.BigInt, joborderid);
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
            sqlCmd.CommandText = "spuJobOrderDetails";
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
