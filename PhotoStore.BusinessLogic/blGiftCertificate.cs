using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using PhotoStore.Entity;
using PhotoStore.BusinessLogic.Paging;
using System.Windows.Forms;
using PhotoStore.DataAccess;
namespace PhotoStore.BusinessLogic
{
    using PhotoStore.UtilityServices.Constants;
    using PhotoStore.UtilityServices;
    using System.IO;
    public class blGiftCertificate
    {
        /// <summary>Populate The GiftCertificate Extention Entities.</summary>
        /// <param name="entityObject">source entity.</param>
        /// <returns>Return the entity object.</returns>
        public static Entity.GiftCertificate populateExtentions(Entity.GiftCertificate entityObject)
        {
            GiftCertificateType certificateType=DataAccess.daGiftCertificateType.retrieve(entityObject.GiftCertificateTypeId);
            GiftCertificateStatus certificateStatus=DataAccess.daGiftCertificateStatus.retrieve(entityObject.GiftCertificateStatusId);
            entityObject.GiftCertificateType = certificateType;
            entityObject.GiftCertificateStatus = certificateStatus;
            string showText = ConfigurationManager.AppSettings["showtext"].ToString();
            switch (showText)
            {
                case "Code":
                    entityObject.GiftCertificateTypeCode = certificateType.Code;
                    entityObject.GiftCertificateStatusCode = certificateStatus.Code;
                    break;
                case "Description":
                    entityObject.GiftCertificateTypeCode = certificateType.Description;
                    entityObject.GiftCertificateStatusCode = certificateStatus.Description;
                    break;
            }
            certificateType=null;
            certificateStatus=null;
            return entityObject;
        }

        /// <summary>Populate The GiftCertificate Extention Entities.</summary>
        /// <param name="entityList">source entity List.</param>
        /// <returns>Return the entity object list.</returns>
        public static List<Entity.GiftCertificate> populateExtentions(List<Entity.GiftCertificate> entityList)
        {
            List<Entity.GiftCertificate> retCol = new List<Entity.GiftCertificate>();

            //populate the list
            foreach (Entity.GiftCertificate entityObject in entityList)
            {
                retCol.Add(populateExtentions(entityObject));
            }

            return retCol;
        }


        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.GiftCertificate create(Entity.GiftCertificate GiftCertificateObject)
        {
            //Call data access.
            Entity.GiftCertificate ret = DataAccess.daGiftCertificate.create(GiftCertificateObject);
            return populateExtentions(ret);
        }

        #endregion

        #region Retrieve

        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.GiftCertificate> retrieve()
        {
            //perform the return
            return populateExtentions(DataAccess.daGiftCertificate.retrieve());
        }

        public static List<Entity.GiftCertificate> retrieveGiftCertificatesByStatusAndType(long gcstatusid,long gctypeid
            ,long productlistid)
        {
            //if (gcstatusid == 1)
            //{
            //    return populateExtentions(DataAccess.daGiftCertificate.retrieveByWhereStatement(
            //        string.Format("WHERE GiftCertificateStatusId={0} AND GiftCertificateTypeId={1} AND IsConsumed=0",
            //        gcstatusid, gctypeid)));
            //}
            //else
            //{
            //    return populateExtentions(DataAccess.daGiftCertificate.retrieveByWhereStatement(
            //        string.Format("WHERE GiftCertificateStatusId={0} AND GiftCertificateTypeId={1}",
            //        gcstatusid, gctypeid)));

            //}

            return populateExtentions(DataAccess.daGiftCertificate.retrieveGCForSelection(gcstatusid, gctypeid,productlistid));
                                        
        }
        //public static System.Data.DataSet Export()
        //{
        //    return DataAccess.daGiftCertificate.exportGC();
        //}

        public static void Import(DataTable dt)
        {
            DataAccess.daGiftCertificate.ImportGC(dt);
        }

        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.GiftCertificate retrieve(long Id)
        {
            //perform the return
            Entity.GiftCertificate ret = DataAccess.daGiftCertificate.retrieve(Id);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Code">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.GiftCertificate retrieve(string Code)
        {
            //perform the return
            Entity.GiftCertificate ret = DataAccess.daGiftCertificate.retrieve(Code);
            if (ret == null) return null;
            return populateExtentions(ret);
        }


        /// <summary>Retrieve all entities filtered by the Gift Certificate Type and Status.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.GiftCertificate> retrieveByGCTypeAndStatus(long GiftCertificateTypeId, long GiftCertificateStatusId)
        {
            //create the data layer
            return DataAccess.daGiftCertificate.retrieveByGCTypeAndStatus(GiftCertificateTypeId, GiftCertificateStatusId);
        }

        /// <summary>Retrieve all entities for a combobox.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.GiftCertificate> retrieveForComboBox(long GiftCertificateTypeId, long GiftCertificateStatusId)
        {
            //create the list
            List<Entity.GiftCertificate> ret = retrieveByGCTypeAndStatus(GiftCertificateTypeId, GiftCertificateStatusId);

            if (ret == null) ret = new List<PhotoStore.Entity.GiftCertificate>();

            //insert a default - for -1 value
            Entity.GiftCertificate EmptyRow = new PhotoStore.Entity.GiftCertificate();
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
        public static Entity.GiftCertificate update(Entity.GiftCertificate GiftCertificateObject)
        {
            //Do business processing here if necessary.
            DataAccess.daGiftCertificate.update(GiftCertificateObject);

            //get the saved data
            return GiftCertificateObject;
        }

        /// <summary>Update an item entry in the database.</summary>        
        /// <param name="GiftCertificateList">Item object.</param>
        /// <param name="isfromtransaction">if true it means deletion of the gift check should not be included</param>
        public static List<Entity.GiftCertificate> updateList(List<Entity.GiftCertificate> GiftCertificateList,
            bool isfromtransaction)
        {
           // string branchCodeGC = ConfigurationManager.AppSettings["BranchCodeGC"].ToString();
            #region update the List
            //look for any removed records and update the existing ones
            List<Entity.GiftCertificate> oldList = retrieve();
            bool IsRecordExist = false;
            foreach (Entity.GiftCertificate oldRecord in oldList)
            {
                IsRecordExist = false;
                foreach (Entity.GiftCertificate newRecord in GiftCertificateList)
                {
                    if (newRecord.Id == oldRecord.Id)
                    {
                        IsRecordExist = true;
                        update(newRecord);
                        break;
                    }
                }
                if (!isfromtransaction)
                {
                    if (!IsRecordExist) delete(oldRecord.Id);
                }
            }

            //create the newly added entities
            foreach (Entity.GiftCertificate newRecord in GiftCertificateList)
            {
                IsRecordExist = false;
                foreach (Entity.GiftCertificate oldRecord in oldList)
                {
                    if (newRecord.Id == oldRecord.Id)
                    {
                        IsRecordExist = true;
                        break;
                    }
                }
                if (!IsRecordExist)
                {
                    //newRecord.Code = string.Concat(branchCodeGC,
                    //    newRecord.Code);
                    create(newRecord);
                }
            }
            #endregion
            //get the saved data
            return retrieve();
        }

        public static void UpdateGCAfterCancelledOrRemoved(string documentNumber,byte isConsumed)
        {
            using (DataSet ds = DataAccess.daHelper.executeSelect(
                string.Format("SELECT Id FROM GiftCertificate WHERE GiftCertificateTypeId=4 AND '{0}' LIKE '%'+Code+'%'",
                documentNumber)))
            {
                using (SqlCommand cmd = new SqlCommand(
                    string.Format("UPDATE GiftCertificate SET IsConsumed={0} WHERE Id={1}",
                    isConsumed,
                    ds.Tables[0].Rows[0]["Id"])))
                {
                    DataAccess.daHelper.executeNonQuery(cmd);
                }
                
            }
            
                
        }
        #endregion

        #region Delete
        /// <summary>delete an item entry from the database.</summary>
        /// <param name="Id">Item to delete.</param>
        public static void delete(long Id)
        {
            //Do business processing here if necessary.
            DataAccess.daGiftCertificate.delete(Id);
        }
        #endregion
        public static int GetCount(Dictionary<string, object> parameterDic)
        {
            int retValue = 0;
            string sqlStatement = "SELECT COUNT(*) FROM GiftCertificate";

            if (parameterDic[Constant.GCTypeId] != null)
                sqlStatement = string.Format(@"SELECT COUNT(*) FROM GiftCertificate WHERE 
                                            GiftCertificateTypeId={0} AND GiftCertificateStatusId={1} ",
                                                                   parameterDic[Constant.GCTypeId],
                                                                   parameterDic[Constant.GCStatusId]);
            if (parameterDic[Constant.GCProductListId] != null)
                sqlStatement = string.Concat(sqlStatement, "AND ProductListId=", parameterDic[Constant.GCProductListId]);

            if (parameterDic[Constant.Code] != null)
            {
                if(sqlStatement.EndsWith("GiftCertificate"))
                    sqlStatement = string.Concat(sqlStatement, string.Format(" WHERE Code LIKE '%{0}%' ", parameterDic[Constant.Code]));
                else
                    sqlStatement = string.Concat(sqlStatement, string.Format(" AND Code LIKE '%{0}%' ", parameterDic[Constant.Code]));
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
                string columnToBeSelected,int currentIndex,
                string direction,
                int upperLimit,
                int lowerLimit,
              Dictionary<string,object> paramDic)
        {
            BindingSource bs = new BindingSource();
            bs.ResetBindings(false);
            
                bs.DataSource =  populateExtentions(DataAccess.daGiftCertificate.retrieveByPaging(
                                                columnToBeSorted,
                                                columnToBeSelected,
                                                currentIndex,
                                                direction,
                                                upperLimit,
                                                lowerLimit,
                                                paramDic));
       
                

            return bs;
             
            
        }

        public static List<Entity.GiftCertificate> Export()
        {
            return DataAccess.daGiftCertificate.exportGC();
        }
        public static string Import(List<Entity.GiftCertificate> giftcertificates, string applicationPath)
        {
            if (MessageBox.Show(string.Format("{0} giftcertificate records will be imported to your database\r\nDo you wish to continue?",
                giftcertificates.Count),
                "Validation",
                MessageBoxButtons.YesNo) == DialogResult.No)
            {

                return "Importing was cancelled";
            }

            string message;
            List<string> notOnListCodes = new List<string>();
            DataAccess.daGiftCertificate.ImportGC(giftcertificates,notOnListCodes, out message);
            if (notOnListCodes.Count > 0)
            {
                string logPath = string.Concat(applicationPath, @"\ImportLogging.log");
                StringBuilder sb = new StringBuilder();
                if (!File.Exists(logPath))
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
                sb.AppendLine("GC's which failed to import");
                message = sb.ToString();
            }
            return message;

        }

   
    }
}
