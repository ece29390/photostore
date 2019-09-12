using System;
using System.Collections.Generic;
using System.Text;
using PhotoStore.UtilityServices;
using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.DataAccess
{
    using PhotoStore.UtilityServices.Constants;
    using System.IO;
    public class daGiftCertificate
    {
        private static string _TableName = "GiftCertificate";

        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.GiftCertificate create(Entity.GiftCertificate itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuGiftCertificate";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "CREATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, DBNull.Value);
            daHelper.addInParameter(sqlCmd, "@Code", SqlDbType.VarChar, itemObject.Code);
            daHelper.addInParameter(sqlCmd, "@Description", SqlDbType.VarChar, itemObject.Description);
            daHelper.addInParameter(sqlCmd, "@UnitPrice", SqlDbType.Money, itemObject.UnitPrice);
            daHelper.addInParameter(sqlCmd, "@GiftCertificateTypeId", SqlDbType.BigInt, itemObject.GiftCertificateTypeId);
            daHelper.addInParameter(sqlCmd, "@GiftCertificateStatusId", SqlDbType.BigInt, itemObject.GiftCertificateStatusId);
            daHelper.addInParameter(sqlCmd, "@ExpirationDate", SqlDbType.DateTime, itemObject.ExpirationDate);
            daHelper.addInParameter(sqlCmd, "@ProductListId", SqlDbType.BigInt, itemObject.ProductListId);
            daHelper.addInParameter(sqlCmd, "@IsComplementary", SqlDbType.Bit, itemObject.IsComplementary);

            //Execute the command
            DataSet ds = daHelper.executeProcedure(sqlCmd);

            return new Entity.GiftCertificate(ds.Tables[0].Rows[0]);
        }
        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.GiftCertificate> retrieve()
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName);

            List<Entity.GiftCertificate> entityList = new List<PhotoStore.Entity.GiftCertificate>();
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    entityList.Add(new Entity.GiftCertificate(dr));
                }
            }
            return entityList;
        }
      
        public static List<Entity.GiftCertificate> retrieveGCForSelection(long statusid, long typeid,long productlistid)
        {
            List<Entity.GiftCertificate> retValues = new List<PhotoStore.Entity.GiftCertificate>();
            string sqlStatement = "";
            if (statusid == 1)
            {
               sqlStatement= string.Format(@"SELECT  * FROM vwAvailableGC
                                             WHERE  OrderDetailsId IS NULL AND 
                                             IsConsumed=0
                                             AND GIFTCERTIFICATESTATUSID={0}
                                             AND GIFTCERTIFICATETYPEID={1}
                                             AND PRODUCTLISTID = {2}", statusid, typeid, productlistid);

            }
            else
            {
                if (productlistid==0)
                {
                    if (statusid == 2 && typeid == 4)
                    {
                        sqlStatement = @"SELECT			* 
                                        FROM		vwAvailableGC				vGC
                                        LEFT JOIN	OrderTransactionPayment		OTP
                                        ON			OTP.DocumentNumber LIKE		'%'+vGC.Code+'%'
                                        WHERE   	--IsConsumed=1 AND
			                                         GIFTCERTIFICATESTATUSID=2
			                                        AND GIFTCERTIFICATETYPEID=4 
			                                        AND OTP.Id IS  NULL";
                    }
                    else
                    {
                        sqlStatement = string.Format(@"SELECT  * FROM vwAvailableGC
                                                             WHERE   
                                                             IsConsumed=1
                                                             AND GIFTCERTIFICATESTATUSID={0}
                                                             AND GIFTCERTIFICATETYPEID={1}                                                                                
                                                            ", statusid, typeid);
                    }
                }
                else
                {
                  sqlStatement=  string.Format(@"SELECT  * FROM vwAvailableGC
                                                             WHERE  
                                                             IsConsumed=1
                                                             AND GIFTCERTIFICATESTATUSID={0}
                                                             AND GIFTCERTIFICATETYPEID={1}
                                                             AND PRODUCTLISTID = {2}
                                                            ", statusid, typeid, productlistid);
                }
            }
            using (DataSet ds = daHelper.executeSelect(sqlStatement))                                                            
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Entity.GiftCertificate giftCertificate = new PhotoStore.Entity.GiftCertificate(dr);
                        retValues.Add(giftCertificate);
                        giftCertificate = null;
                    }
                }
            }

            
            return retValues;
        }
        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.GiftCertificate retrieve(long Id)
        {
            DataRow dr = daHelper.executeSelectById(_TableName, Id);
            return new Entity.GiftCertificate(dr);
        }
        public static void ImportGC(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = daHelper.commandTimeout;
                    sqlCmd.CommandText = "spuGiftCertificate";

                    daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "IMPORT GC");
                    daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, DBNull.Value);
                    daHelper.addInParameter(sqlCmd, "@Code", SqlDbType.VarChar, dr["Code"].ToString());
                    daHelper.addInParameter(sqlCmd, "@Description", SqlDbType.VarChar, dr["Description"]);
                    daHelper.addInParameter(sqlCmd, "@UnitPrice", SqlDbType.Money, dr["UnitPrice"]);
                    daHelper.addInParameter(sqlCmd, "@GiftCertificateTypeId", SqlDbType.BigInt, dr["GiftCertificateTypeId"]);
                    daHelper.addInParameter(sqlCmd, "@GiftCertificateStatusId", SqlDbType.BigInt, dr["GiftCertificateStatusId"]);
                    daHelper.addInParameter(sqlCmd, "@ExpirationDate", SqlDbType.DateTime, dr["ExpirationDate"]);
                    daHelper.addInParameter(sqlCmd, "@LastModified", SqlDbType.DateTime, dr["DateLastModified"]);
                    daHelper.addInParameter(sqlCmd,"@IsConsumed",SqlDbType.Bit,(dr["IsConsumed"].ToString().ToUpper()=="TRUE")?1:0);
                    daHelper.addInParameter(sqlCmd, "@IsComplementary", SqlDbType.Bit, dr["IsComplementary"]);
                    daHelper.executeNonQuery(sqlCmd);
                }
            }
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Id">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.GiftCertificate retrieve(string Code)
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName + " where Code='" + Code + "'");
            if (ds == null) return null;
            DataRowCollection drc = ds.Tables[0].Rows;
            return new Entity.GiftCertificate(drc[0]);
        }
        public static List<Entity.GiftCertificate> retrieveByWhereStatement(string wherestatement)
        {
            List<Entity.GiftCertificate> giftCertificates = new List<PhotoStore.Entity.GiftCertificate>();
            using (DataSet ds = daHelper.executeSelect(string.Format("SELECT * FROM {0} {1}",
                            _TableName, wherestatement)))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Entity.GiftCertificate giftCertificate = new PhotoStore.Entity.GiftCertificate(dr);
                        giftCertificates.Add(giftCertificate);
                        giftCertificate = null;
                    }
                }
                

            }
            return giftCertificates;
        }

        /// <summary>Retrieve all entities filtered by the Gift Certificate Type and Status.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.GiftCertificate> retrieveByGCTypeAndStatus(long GiftCertificateTypeId, long GiftCertificateStatusId)
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName + " where GiftCertificateTypeId=" + GiftCertificateTypeId + " and GiftCertificateStatusId=" + GiftCertificateStatusId);
            if (ds == null) return null;
            List<Entity.GiftCertificate> entityList = new List<PhotoStore.Entity.GiftCertificate>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                entityList.Add(new Entity.GiftCertificate(dr));
            }
            return entityList;
        }
        
        public static List<Entity.GiftCertificate> retrieveByPaging(string columnToBeSorted,
                string columnToBeSelected,int currentIndex,
                string direction,
                int upperLimit,
                int lowerLimit,
                Dictionary<string,object> paramDic)
        {
            columnToBeSelected = string.IsNullOrEmpty(columnToBeSelected) ? "*" : columnToBeSelected;
            List<Entity.GiftCertificate> retValue = new List<PhotoStore.Entity.GiftCertificate>();
            StringBuilder sb = new StringBuilder();
            sb.Append("WITH tempTable AS (");
            sb.AppendLine("SELECT ROW_NUMBER() ");
            sb.AppendLine(string.Format("OVER (ORDER BY  {0} {1}) Row,",columnToBeSorted,direction));
            sb.AppendLine(columnToBeSelected);
            if (paramDic[Constant.GCStatusId]==null)//!statusId.HasValue)
            {
                if (paramDic[Constant.Code] == null)
                    sb.AppendLine("FROM vwGC)");
                else
                    sb.AppendLine(string.Format("FROM vwGC WHERE Code LIKE '%{0}%')",
                        paramDic[Constant.Code]));
               
               

            }
            else
            {
                string sqlStatementFormat = "FROM vwGC WHERE GiftCertificateTypeId={0} AND GiftCertificateStatusId={1} ";
                if (paramDic[Constant.GCProductListId] != null)//productListId.HasValue)
                    sqlStatementFormat = string.Concat(sqlStatementFormat, "AND ProductListId=", paramDic[Constant.GCProductListId]);//productListId.Value);

                if (paramDic[Constant.Code] != null)
                    sqlStatementFormat = string.Concat(sqlStatementFormat, string.Format(" AND Code LIKE '%{0}%'",
                        paramDic[Constant.Code]));

                sqlStatementFormat = string.Concat(sqlStatementFormat, ")");
                sb.AppendLine(string.Format(sqlStatementFormat,
                    paramDic[Constant.GCTypeId],
                    paramDic[Constant.GCStatusId]));
            }
            
            sb.AppendLine(string.Format("SELECT * FROM tempTable WHERE  Row BETWEEN {0} AND {1}", lowerLimit, upperLimit));
            using (DataSet ds = daHelper.executeSelect(
                sb.ToString()))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Entity.GiftCertificate gc = new PhotoStore.Entity.GiftCertificate(dr);
                        retValue.Add(gc);
                        gc = null;
                    }
                }
            }
            return retValue;
        }
        
        #endregion

        #region update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static void update(Entity.GiftCertificate itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuGiftCertificate";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "UPDATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, itemObject.Id);
            daHelper.addInParameter(sqlCmd, "@Code", SqlDbType.VarChar, itemObject.Code);
            daHelper.addInParameter(sqlCmd, "@Description", SqlDbType.VarChar, itemObject.Description);
            daHelper.addInParameter(sqlCmd, "@UnitPrice", SqlDbType.Money, itemObject.UnitPrice);
            daHelper.addInParameter(sqlCmd, "@GiftCertificateTypeId", SqlDbType.BigInt, itemObject.GiftCertificateTypeId);
            daHelper.addInParameter(sqlCmd, "@GiftCertificateStatusId", SqlDbType.BigInt, itemObject.GiftCertificateStatusId);
            daHelper.addInParameter(sqlCmd, "@ExpirationDate", SqlDbType.DateTime, itemObject.ExpirationDate);
            daHelper.addInParameter(sqlCmd, "@ProductListId", SqlDbType.BigInt, itemObject.ProductListId);
            daHelper.addInParameter(sqlCmd, "@IsComplementary", SqlDbType.Bit, itemObject.IsComplementary);
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
            sqlCmd.CommandText = "spuGiftCertificate";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "DELETE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, Id);

            //Execute the command
            daHelper.executeNonQuery(sqlCmd);

        }
        #endregion
        

        public static List<Entity.GiftCertificate> exportGC()
        {
            List<Entity.GiftCertificate> giftCertificates = new List<PhotoStore.Entity.GiftCertificate>();
            string sqlStatement = "SELECT * FROM GIFTCERTIFICATE WHERE GiftCertificateStatusId = 2 OR GiftCertificateStatusId = 3";
            using (SqlCommand cmd = new SqlCommand(sqlStatement))
            {
                cmd.CommandType = CommandType.Text;
              
                using (DataSet ds = daHelper.executeProcedure(cmd))
                {
                    if (ds != null)
                    {
                        Entity.GiftCertificate cpn;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            cpn = new PhotoStore.Entity.GiftCertificate(dr);
                            giftCertificates.Add(cpn);
                            cpn = null;
                        }
                    }
                }

            }
            return giftCertificates;
        }
       
        public static void ImportGC(List<Entity.GiftCertificate> giftCertificates,List<string> notOnListCodes, out string message)
        {
            int created = 0, updated = 0, notOnList = 0, alreadyRedeemed = 0;
            message = "";
            
            Dictionary<string, object> outDic = null;
            foreach (Entity.GiftCertificate giftCertificate in giftCertificates)
            {
                if (outDic == null)
                    outDic = new Dictionary<string, object>();
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                   
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = "[dbo].[spuGiftCertificate]";
                    sqlCmd.CommandTimeout = daHelper.commandTimeout;

                    //Initialize sql database and assign parameters;
                    daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "IMPORT GC");
                    daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, DBNull.Value);
                    daHelper.addInParameter(sqlCmd, "@Code", SqlDbType.VarChar, giftCertificate.Code);
                    daHelper.addInParameter(sqlCmd, "@Description", SqlDbType.VarChar, giftCertificate.Description);
                    daHelper.addInParameter(sqlCmd, "@UnitPrice", SqlDbType.Money, giftCertificate.UnitPrice);
                    daHelper.addInParameter(sqlCmd, "@GiftCertificateStatusId", SqlDbType.BigInt, giftCertificate.GiftCertificateStatusId);
                    daHelper.addInParameter(sqlCmd, "@GiftCertificateTypeId", SqlDbType.BigInt, giftCertificate.GiftCertificateTypeId);
                    daHelper.addInParameter(sqlCmd, "@ExpirationDate", SqlDbType.DateTime, giftCertificate.ExpirationDate);
                    daHelper.addInParameter(sqlCmd, "@LastModified", SqlDbType.DateTime, giftCertificate.DateLastModified);
                    daHelper.addInParameter(sqlCmd, "@IsConsumed", SqlDbType.Bit, giftCertificate.IsConsumed);
                    daHelper.addInParameter(sqlCmd, "@IssuedDate", SqlDbType.DateTime, giftCertificate.IssuedDate);
                    daHelper.addInParameter(sqlCmd, "@IssuedTo", SqlDbType.VarChar, giftCertificate.IssuedTo);
                    daHelper.addInParameter(sqlCmd, "@RedeemedDate", SqlDbType.DateTime, giftCertificate.RedeemedDate);
                    daHelper.addInParameter(sqlCmd, "@ProductListId", SqlDbType.BigInt, giftCertificate.ProductListId);
                    daHelper.addInParameter(sqlCmd, "@RedeemedBy", SqlDbType.VarChar, giftCertificate.RedeemedBy);
                    daHelper.addOutParameter(sqlCmd, "@TransStatus", SqlDbType.Int, 0);
                    daHelper.addInParameter(sqlCmd, "@IsComplementary", SqlDbType.Bit, giftCertificate.IsComplementary);
                    daHelper.executeNonQueryWithOut(sqlCmd, outDic, "@TransStatus");

                    switch (Convert.ToInt32(outDic["@TransStatus"]))
                    {
                        case 101:
                            created = created + 1;
                            break;
                        case 102:
                            updated = updated + 1;
                            break;
                        case 201:
                            notOnList = notOnList + 1;
                            if (!notOnListCodes.Contains(string.Concat(giftCertificate.Code, "-", giftCertificate.Description)))
                                notOnListCodes.Add(string.Concat(giftCertificate.Code, "-", giftCertificate.Description));
                            break;
                        case 202:
                            alreadyRedeemed = alreadyRedeemed + 1;
                            break;
                    }
                 
                    
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0} Record(s) has been successfully added",
                                        created));
            sb.AppendLine(string.Format("{0} Record(s) has been successfully updated",
                                        updated));
            sb.AppendLine(string.Format("{0} Record(s) unable to locate productlist",
                                        notOnList));
            sb.AppendLine(string.Format("{0} Record(s) has already redeemed status",
                                        alreadyRedeemed));

            message = sb.ToString();

        }
    }
}
