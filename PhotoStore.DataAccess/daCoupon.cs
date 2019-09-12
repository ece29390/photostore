using System;
using System.Collections.Generic;
using System.Text;
using PhotoStore.UtilityServices.Constants;
using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.DataAccess
{
    public class daCoupon 
    {
        private static string _TableName = "Coupon";

        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.Coupon create(Entity.Coupon itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuCoupon";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "CREATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, DBNull.Value);
            daHelper.addInParameter(sqlCmd, "@Code", SqlDbType.VarChar, itemObject.Code);
            daHelper.addInParameter(sqlCmd, "@Description", SqlDbType.VarChar, itemObject.Description);
            daHelper.addInParameter(sqlCmd, "@UnitPrice", SqlDbType.Money, itemObject.UnitPrice);
            //daHelper.addInParameter(sqlCmd, "@CouponTypeId", SqlDbType.BigInt, itemObject.CouponTypeId);
            daHelper.addInParameter(sqlCmd, "@CouponStatusId", SqlDbType.BigInt, itemObject.CouponStatusId);
            daHelper.addInParameter(sqlCmd, "@ExpirationDate", SqlDbType.DateTime, itemObject.ExpirationDate);
            daHelper.addInParameter(sqlCmd, "@ProductListId", SqlDbType.BigInt, itemObject.ProductListId);

            //Execute the command
            DataSet ds = daHelper.executeProcedure(sqlCmd);

            return new Entity.Coupon(ds.Tables[0].Rows[0]);
        }
        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.Coupon> retrieve()
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName);

            List<Entity.Coupon> entityList = new List<PhotoStore.Entity.Coupon>();
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    entityList.Add(new Entity.Coupon(dr));
                }
            }
            return entityList;
        }
        public static List<Entity.Coupon> retrieveByWhereStatement(string wherestatement)
        {
            List<Entity.Coupon> coupons = new List<PhotoStore.Entity.Coupon>();
            using (DataSet ds = daHelper.executeSelect(string.Format("SELECT * FROM {0} {1}",
                _TableName, wherestatement)))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Entity.Coupon coupon = new PhotoStore.Entity.Coupon(dr);
                        coupons.Add(coupon);
                        coupon = null;
                    }
                }
            }
            return coupons;
        }
        public static List<Entity.Coupon> retrieveByPaging(string columnToBeSorted,
               string columnToBeSelected, int currentIndex,
               string direction,
               int upperLimit,
               int lowerLimit,
               Dictionary<string, object> paramDic)
        {
            columnToBeSelected = string.IsNullOrEmpty(columnToBeSelected) ? "*" : columnToBeSelected;
            List<Entity.Coupon> retValue = new List<PhotoStore.Entity.Coupon>();
            StringBuilder sb = new StringBuilder();
            sb.Append("WITH tempTable AS (");
            sb.AppendLine("SELECT ROW_NUMBER() ");
            sb.AppendLine(string.Format("OVER (ORDER BY  {0} {1}) Row,", columnToBeSorted, direction));
            sb.AppendLine(columnToBeSelected);
            if (paramDic[Constant.CPStatusId]==null)//!statusId.HasValue)
            {
                if(paramDic[Constant.Code]==null)
                    sb.AppendLine("FROM vw_Coupon_CouponStatus)");
                else
                    sb.AppendLine(string.Format("FROM vw_Coupon_CouponStatus WHERE Code LIKE '%{0}%')",
                        paramDic[Constant.Code]));
            }
            else
            {
                if (Convert.ToInt32(paramDic[Constant.CPStatusId]) == 1)
                {
                    string sqlStatementFormat = "FROM vw_Coupon_CouponStatus WHERE CouponStatusId={0} AND IsConsumed=0  AND ProductListId={1}";
                    sb.AppendLine(string.Format(sqlStatementFormat,
                        paramDic[Constant.CPStatusId],
                        paramDic[Constant.CPProductListId]));
                }
                else
                {
                    string sqlStatementFormat = "FROM vw_Coupon_CouponStatus WHERE CouponStatusId={0} AND  ProductListId={1}";
                    sb.AppendLine(string.Format(sqlStatementFormat,
                        paramDic[Constant.CPStatusId],
                        paramDic[Constant.CPProductListId]));
                }

                if (paramDic[Constant.Code] != null)
                {
                    sb.AppendFormat(" AND Code LIKE '%{0}%'", paramDic[Constant.Code]);
                }
                sb.Append(")");
            }

            sb.AppendLine(string.Format("SELECT * FROM tempTable WHERE  Row BETWEEN {0} AND {1}", lowerLimit, upperLimit));
            using (DataSet ds = daHelper.executeSelect(
                sb.ToString()))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Entity.Coupon gc = new PhotoStore.Entity.Coupon(dr);
                        retValue.Add(gc);
                        gc = null;
                    }
                }
            }
            return retValue;
        }
   
        public static List<Entity.Coupon> exportCoupon()
        {
            List<Entity.Coupon> coupons = new List<PhotoStore.Entity.Coupon>();
            string sqlStatement = "select * from coupon where couponstatusid = 2 or couponstatusid =3";
            using (SqlCommand cmd = new SqlCommand(sqlStatement))
            {
                cmd.CommandType = CommandType.Text;
                
                using (DataSet ds = daHelper.executeProcedure(cmd))
                {
                    if (ds != null)
                    {
                        Entity.Coupon cpn;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            cpn = new PhotoStore.Entity.Coupon(dr);
                            coupons.Add(cpn);
                            cpn = null;
                        }
                    }
                }
                
            }
            return coupons;
        }
        public static void ImportCoupon(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = "spuCoupon";
                    sqlCmd.CommandTimeout = daHelper.commandTimeout;

                    //Initialize sql database and assign parameters;
                    daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "IMPORT COUPON");
                    daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, DBNull.Value);
                    daHelper.addInParameter(sqlCmd, "@Code", SqlDbType.VarChar, dr["Code"]);
                    daHelper.addInParameter(sqlCmd, "@Description", SqlDbType.VarChar, dr["Description"]);
                    daHelper.addInParameter(sqlCmd, "@UnitPrice", SqlDbType.Money, dr["UnitPrice"]);
                    //daHelper.addInParameter(sqlCmd, "@CouponTypeId", SqlDbType.BigInt, itemObject.CouponTypeId);
                    daHelper.addInParameter(sqlCmd, "@CouponStatusId", SqlDbType.BigInt, dr["CouponStatusId"]);
                    daHelper.addInParameter(sqlCmd, "@ExpirationDate", SqlDbType.DateTime, dr["ExpirationDate"]);
                    daHelper.addInParameter(sqlCmd, "@LastModified", SqlDbType.DateTime, dr["DateLastModified"]);
                    daHelper.addInParameter(sqlCmd, "@IsConsumed", SqlDbType.Bit, (dr["IsConsumed"].ToString().ToUpper() == "TRUE") ? 1 : 0);
                    daHelper.executeNonQuery(sqlCmd);
                }
            }
        }

        public static void ImportCoupon(List<Entity.Coupon> coupons,List<string> notOnListCodes,out string message)
        {
            int created=0,updated=0,notOnList=0,alreadyRedeemed=0;
            message = "";
            string msg = "";
            Dictionary<string,object> outDic=null;
            foreach (Entity.Coupon coupon in coupons)
            {
                if (outDic == null)
                    outDic = new Dictionary<string, object>();
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = "spuCoupon";
                    sqlCmd.CommandTimeout = daHelper.commandTimeout;
                    
                    //Initialize sql database and assign parameters;
                    daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "IMPORT COUPON");
                    daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, DBNull.Value);
                    daHelper.addInParameter(sqlCmd, "@Code", SqlDbType.VarChar, coupon.Code);
                    daHelper.addInParameter(sqlCmd, "@Description", SqlDbType.VarChar, coupon.Description);
                    daHelper.addInParameter(sqlCmd, "@UnitPrice", SqlDbType.Money, coupon.UnitPrice);                    
                    daHelper.addInParameter(sqlCmd, "@CouponStatusId", SqlDbType.BigInt, coupon.CouponStatusId);
                    daHelper.addInParameter(sqlCmd, "@ExpirationDate", SqlDbType.DateTime, coupon.ExpirationDate);
                    daHelper.addInParameter(sqlCmd, "@LastModified", SqlDbType.DateTime, coupon.DateLastModified);
                    daHelper.addInParameter(sqlCmd, "@IsConsumed", SqlDbType.Bit, coupon.IsConsumed);
                    daHelper.addInParameter(sqlCmd, "@IssuedDate", SqlDbType.DateTime, coupon.IssuedDate);
                    daHelper.addInParameter(sqlCmd, "@IssuedTo", SqlDbType.VarChar, coupon.IssuedTo);
                    daHelper.addInParameter(sqlCmd, "@RedeemedDate", SqlDbType.DateTime, coupon.RedeemedDate);
                    daHelper.addInParameter(sqlCmd, "@ProductListId", SqlDbType.BigInt, coupon.ProductListId);
                    daHelper.addInParameter(sqlCmd, "@RedeemedBy", SqlDbType.VarChar, coupon.RedeemedBy);
                    daHelper.addOutParameter(sqlCmd, "@TransStatus", SqlDbType.Int,0);

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
                            if (!notOnListCodes.Contains(string.Concat(coupon.Code, "-", coupon.Description)))
                                notOnListCodes.Add(string.Concat(coupon.Code, "-", coupon.Description));
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
        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.Coupon retrieve(long Id)
        {
            DataRow dr = daHelper.executeSelectById(_TableName, Id);
            return new Entity.Coupon(dr);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Id">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.Coupon retrieve(string Code)
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName + " where Code='" + Code + "'");
            if (ds == null) return null;
            DataRowCollection drc = ds.Tables[0].Rows;
            return new Entity.Coupon(drc[0]);
        }

        #endregion

        #region update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static void update(Entity.Coupon itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuCoupon";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "UPDATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, itemObject.Id);
            daHelper.addInParameter(sqlCmd, "@Code", SqlDbType.VarChar, itemObject.Code);
            daHelper.addInParameter(sqlCmd, "@Description", SqlDbType.VarChar, itemObject.Description);
            daHelper.addInParameter(sqlCmd, "@UnitPrice", SqlDbType.Money, itemObject.UnitPrice);
           // daHelper.addInParameter(sqlCmd, "@CouponTypeId", SqlDbType.BigInt, itemObject.CouponTypeId);
            daHelper.addInParameter(sqlCmd, "@CouponStatusId", SqlDbType.BigInt, itemObject.CouponStatusId);
            daHelper.addInParameter(sqlCmd, "@ExpirationDate", SqlDbType.DateTime, itemObject.ExpirationDate);
            
            daHelper.addInParameter(sqlCmd, "@ProductListId", SqlDbType.BigInt, itemObject.ProductListId);
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
            sqlCmd.CommandText = "spuCoupon";
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
