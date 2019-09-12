using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using PhotoStore.UtilityServices.Constants;
using PhotoStore.UtilityServices;
using System.IO;
namespace PhotoStore.BusinessLogic
{
    public class blCoupon
    {

        /// <summary>Populate The Coupon Extention Entities.</summary>
        /// <param name="entityObject">source entity.</param>
        /// <returns>Return the entity object.</returns>
        public static Entity.Coupon populateExtentions(Entity.Coupon entityObject)
        {
            //entityObject.CouponType = DataAccess.daCouponType.retrieve(entityObject.CouponTypeId);
            Entity.CouponStatus couponStatus=DataAccess.daCouponStatus.retrieve(entityObject.CouponStatusId);
            entityObject.CouponStatus = couponStatus;
            entityObject.CouponStatusCode = (System.Configuration.ConfigurationManager.AppSettings["showtext"].ToString() == "Description") ?
                couponStatus.Description : couponStatus.Code;
            return entityObject;
        }

        /// <summary>Populate The Coupon Extention Entities.</summary>
        /// <param name="entityList">source entity List.</param>
        /// <returns>Return the entity object list.</returns>
        public static List<Entity.Coupon> populateExtentions(List<Entity.Coupon> entityList)
        {
            List<Entity.Coupon> retCol = new List<Entity.Coupon>();

            //populate the list
            foreach (Entity.Coupon entityObject in entityList)
            {
                retCol.Add(populateExtentions(entityObject));
            }

            return retCol;
        }


        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.Coupon create(Entity.Coupon CouponObject)
        {
            //Call data access.
            Entity.Coupon ret = DataAccess.daCoupon.create(CouponObject);
            if (ret == null) return null;
            return populateExtentions(ret);
        }
        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.Coupon> retrieve()
        {
            //perform the return
            return populateExtentions(DataAccess.daCoupon.retrieve());
        }
        public static int GetCount(Dictionary<string,object> paramDic)
        {
            int retValue = 0;
            string sqlStatement = "SELECT COUNT(*) FROM Coupon";
            if (paramDic[Constant.CPStatusId]!=null) //statusId.HasValue)
                sqlStatement = string.Format(@"SELECT COUNT(*) FROM Coupon WHERE 
                                            CouponStatusId={0} AND ProductListId={1} ",
                                                                   paramDic[Constant.CPStatusId],
                                                                   paramDic[Constant.CPProductListId]);

            if (paramDic[Constant.Code] != null)
            {
                if (sqlStatement.EndsWith("Coupon"))
                    sqlStatement = string.Concat(sqlStatement, string.Format(
                        " WHERE Code LIKE '%{0}%'", paramDic[Constant.Code]));
                else
                    sqlStatement = string.Concat(
                        sqlStatement,
                        string.Format(" AND Code LIKE '%{0}%'",
                        paramDic[Constant.Code]));
            }
           
            using (System.Data.DataSet ds = DataAccess.daHelper.executeSelect(sqlStatement))
            {
                if (ds != null)
                {
                    retValue = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                }
            }
            return retValue;
        }
        public static BindingSource PagingRetrieve(string columnToBeSorted,
                string columnToBeSelected, int currentIndex,
                string direction,
                int upperLimit,
                int lowerLimit,
                Dictionary<string, object> paramDic)
        {
            BindingSource bs = new BindingSource();
            bs.ResetBindings(false);

            bs.DataSource = populateExtentions(DataAccess.daCoupon.retrieveByPaging(
                                            columnToBeSorted,
                                            columnToBeSelected,
                                            currentIndex,
                                            direction,
                                            upperLimit,
                                            lowerLimit,
                                            paramDic));



            return bs;


        }
        public static List<Entity.Coupon> retrieveByStatusId(long statusid,long productlistid)
        {
            if (statusid == 1)
            {
                return populateExtentions(DataAccess.daCoupon.retrieveByWhereStatement(
                    string.Format("WHERE CouponStatusId={0} AND IsConsumed=0 AND ProductListId={1}",
                    statusid,
                    productlistid)));
            }
            else
            {
                return populateExtentions(DataAccess.daCoupon.retrieveByWhereStatement(
                    string.Format("WHERE CouponStatusId={0} AND ProductListId={1}",
                    statusid,
                    productlistid)));
            }
        }
        //public static DataSet Export()
        //{
        //    return DataAccess.daCoupon.exportCoupon();
        //}
        public static List<Entity.Coupon> Export()
        {
            return DataAccess.daCoupon.exportCoupon();
        }

        public static void Import(DataTable dt)
        {
             DataAccess.daCoupon.ImportCoupon(dt);
        }
        public static string Import(List<Entity.Coupon> coupons,string applicationPath)
        {
            if (MessageBox.Show(string.Format("{0} coupon records will be imported to your database\r\nDo you wish to continue?",
                coupons.Count),
                "Validation",
                MessageBoxButtons.YesNo) == DialogResult.No)
            {

                return "Importing was cancelled";
            }

            string message;
            List<string> notOnListCodes=new List<string>();
            DataAccess.daCoupon.ImportCoupon(coupons,notOnListCodes, out message);
            if (notOnListCodes.Count > 0)
            {
                string logPath = string.Concat(applicationPath, @"\ImportLogging.log");
                StringBuilder sb = new StringBuilder();
                if(!File.Exists(logPath))             
                    sb.AppendLine("==========================Importing Failure=================");
                else
                    sb.AppendLine("=============================================================");
                sb.AppendLine(string.Concat("Date Imported:", DateTime.Now.ToString()));
                foreach (string item in notOnListCodes)
                {
                    sb.AppendLine(item);
                }
                sb.AppendLine("============================================================");
                LoggingService.LogFailureTask(logPath,
                 sb.ToString());
                sb = new StringBuilder();
                sb.AppendLine(message);
                sb.AppendLine(
                    string.Format("Please Check the importing log file at {0} to see all",
                    logPath));
                sb.AppendLine("Coupon's which failed to import");
                message = sb.ToString();
            }
            return message;

        }
        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.Coupon retrieve(long Id)
        {
            //perform the return
            Entity.Coupon ret = DataAccess.daCoupon.retrieve(Id);
            return populateExtentions(ret);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Code">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.Coupon retrieve(string Code)
        {
            //perform the return
            Entity.Coupon ret = DataAccess.daCoupon.retrieve(Code);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve all entities for a combobox.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.Coupon> retrieveForComboBox()
        {
            //create the list
            List<Entity.Coupon> ret = retrieve();

            if (ret == null) ret = new List<PhotoStore.Entity.Coupon>();

            //insert a default - for -1 value
            Entity.Coupon EmptyRow = new PhotoStore.Entity.Coupon();
            EmptyRow.Id = -1;
            EmptyRow.Code = "--";
            EmptyRow.Description = "-Select-";

            ret.Insert(0, EmptyRow);

            //perform the return
            return ret;
        }

      
        #endregion

        #region Update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.Coupon update(Entity.Coupon CouponObject)
        {
            //Do business processing here if necessary.
            DataAccess.daCoupon.update(CouponObject);

            //get the saved data
            return CouponObject;
        }

        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static List<Entity.Coupon> updateList(List<Entity.Coupon> CouponList)
        {
            #region update the List
            //look for any removed records and update the existing ones
            List<Entity.Coupon> oldList = retrieve();
            bool IsRecordExist = false;
            foreach (Entity.Coupon oldRecord in oldList)
            {
                IsRecordExist = false;
                foreach (Entity.Coupon newRecord in CouponList)
                {
                    if (newRecord.Id == oldRecord.Id)
                    {
                        IsRecordExist = true;
                        update(newRecord);
                        break;
                    }
                }
                if (!IsRecordExist) delete(oldRecord.Id);
            }

            //create the newly added entities
            foreach (Entity.Coupon newRecord in CouponList)
            {
                IsRecordExist = false;
                foreach (Entity.Coupon oldRecord in oldList)
                {
                    if (newRecord.Id == oldRecord.Id)
                    {
                        IsRecordExist = true;
                        break;
                    }
                }
                if (!IsRecordExist) create(newRecord);
            }
            #endregion
            //get the saved data
            return retrieve();
        }
        #endregion

        #region Delete
        /// <summary>delete an item entry from the database.</summary>
        /// <param name="Id">Item to delete.</param>
        public static void delete(long Id)
        {
            //Do business processing here if necessary.
            DataAccess.daCoupon.delete(Id);
        }
        #endregion
    }
}
