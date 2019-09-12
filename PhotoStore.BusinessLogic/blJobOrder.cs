using System;
using System.Collections.Generic;
using System.Text;
using PhotoStore.Entity;
using PhotoStore.DataAccess;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace PhotoStore.BusinessLogic
{
    public class blJobOrder
    {
        ///// <summary>Populate The JobOrder Extention Entities.</summary>
        ///// <param name="entityObject">source entity.</param>
        ///// <returns>Return the entity object.</returns>
        //public static Entity.JobOrder populateExtentions(Entity.JobOrder entityObject)
        //{
        //    entityObject.OrderTransaction = DataAccess.daOrderTransaction.retrieve(entityObject.OrderTransactionId);
        //    entityObject.Supplier = DataAccess.daSupplier.retrieve(entityObject.SupplierId);
        //    return entityObject;
        //}

        ///// <summary>Populate The JobOrder Extention Entities.</summary>
        ///// <param name="entityList">source entity List.</param>
        ///// <returns>Return the entity object list.</returns>
        //public static List<Entity.JobOrder> populateExtentions(List<Entity.JobOrder> entityList)
        //{
        //    List<Entity.JobOrder> retCol = new List<Entity.JobOrder>();

        //    //populate the list
        //    foreach (Entity.JobOrder entityObject in entityList)
        //    {
        //        retCol.Add(populateExtentions(entityObject));
        //    }

        //    return retCol;
        //}


        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.JobOrder create(Entity.JobOrder JobOrderObject)
        {
            //Call data access.
            Entity.JobOrder ret = DataAccess.daJobOrder.create(JobOrderObject);
            return ret;//populateExtentions(ret);
        }

        ///// <summary>
        ///// Create new job order base on existing job order with quantity less than the maximum allowed
        ///// </summary>
        ///// <param name="itemObject">Job order</param>
        //public static void createOnExisting(Entity.JobOrder JobOrderObject)
        //{
        //    //Do business processing here if necessary.

        //    //Call data access.
        //    DataAccess.daJobOrder.createOnExisting(JobOrderObject);
        //}
        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.JobOrder> retrieve()
        {
            //perform the return
            List<Entity.JobOrder> retList = DataAccess.daJobOrder.retrieve();
            if (retList == null) return null;
            return retList;//populateExtentions(retList);
        }

        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.JobOrder retrieve(long Id)
        {
            //perform the return
            Entity.JobOrder ret = DataAccess.daJobOrder.retrieve(Id);
            if (ret == null) return null;
            return ret;//populateExtentions(ret);
        }
        public static int GetAvailableQuantity(long joborderdetailid, long ordertransactiondetailid,
            int desiredquantity,long orderpackagedetailid)
        {
            int retValue = 0;
            using (DataSet ds = daJobOrder.ExecSpGetAvailableQuantity(
                joborderdetailid, ordertransactiondetailid, desiredquantity,orderpackagedetailid))
            {
                retValue = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            return retValue;
        }
        public static List<Entity.MissingJobOrder> retrieveMissingJobOrders()
        {
            return daJobOrder.retrieveMissingJobOrder();
        }
        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Code">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.JobOrder retrieve(string Code)
        {
            //perform the return
            Entity.JobOrder ret = DataAccess.daJobOrder.retrieve(Code);
            if (ret == null) return null;
            return ret;//populateExtentions(ret);
        }

        /// <summary>Retrieve the next Code.</summary>
        /// <returns>Return the next code.</returns>
        public static string retrieveNextCode()
        {
            //perform the return
            return DataAccess.daJobOrder.retrieveNextCode();
        }

        /// <summary>
        /// Get the collection to be used in creating new Job orders
        /// </summary>
        /// <returns>CreateJO collection</returns>
        public static List<PhotoStore.Entity.CreateJO> retrieveDataForJO()
        {
            //perform the return
            return DataAccess.daJobOrder.RetrieveDataCreateJobOrderData();
        }
        public static void executeAdjustment()
        {
            daJobOrder.executeAdjustment();
        }
        /// <summary>
        /// Retrieve the Records for ShowTally
        /// </summary>
        /// <param name="JONumber">Job Order number</param>
        /// <returns>Job order in Generic List</returns>
        public static List<PhotoStore.Entity.ActualJO> GetShowTallyRecords(string JONumber)
        {
            //perform the return
            return DataAccess.daJobOrder.GetActualJO(DataAccess.daJobOrder.ActualJOType.ShowTally,JONumber);
        }

        public static List<Tally> GetTallyRecords(long id,string column,Direction direction)
        {
            return daJobOrder.GetTally(id,column,EnumReader.GetDescription(direction));
        }
        /// <summary>
        /// Retrieve the Records for ReleaseReport
        /// </summary>
        /// <param name="JONumber">Job Order number</param>
        /// <returns>Job order in Generic List</returns>
        public static List<PhotoStore.Entity.ActualJO> GetReleaseReport(string JONumber)
        {
            //perform the return
            return DataAccess.daJobOrder.GetActualJO(DataAccess.daJobOrder.ActualJOType.ReleaseReport, JONumber);
            
        }

        public static List<ReleaseReport> GetReleaseReport(long id)
        {
            return daJobOrder.GetReleaseReport(id);
        }
        public static List<JobOrderReport> GetJobOrderReport(long id)
        {
            return daJobOrder.GetJobOrderReport(id);
        }
        /// <summary>
        /// Get the Search Categories for Search Order
        /// </summary>
        /// <returns>SearchCategory collection</returns>
        public static List<PhotoStore.Entity.SearchCategory> SearchTypes()
        {
            //perform the return
            return DataAccess.daJobOrder.SearchCategories();

        }
        /// <summary>
        /// Get the SearchOrder by categories
        /// </summary>
        /// <param name="mode">0=All,1=Order Number, etc</param>
        /// <param name="filtervalue">filter value</param>
        /// <returns>SearchJO collection</returns>
        public static List<PhotoStore.Entity.SearchJO> SearchOrderByCategory(int mode, string filtervalue)
        {
            //perform the return
            return DataAccess.daJobOrder.SearchByCategory(mode, filtervalue);
        }
        /// <summary>
        /// Check if there's still JobOrder which are yet to be DONE
        /// </summary>
        /// <returns>true if found otherwise false</returns>
        public static bool IsPendingJobOrderExist()
        {
            return DataAccess.daJobOrder.IsPendingJobOrderExist();
        }

        ///// <summary>
        ///// get the joborder records
        ///// </summary>
        ///// <returns>joborder collection</returns>
        //public static List<PhotoStore.Entity.CreateJO> retrieveJOs()
        //{
        //    //perform the return
        //    return DataAccess.daJobOrder.spGetJO();
        //}
        public static List<PhotoStore.Entity.JobOrderByType> GetJoByType(int jobordertype)
        {
            return DataAccess.daJobOrder.GetJobOrderByType(jobordertype);
        }

        public static JobOrder GetPendingJobOrder()
        {
            return daJobOrder.GetNotDoneJobOrder();
        }
        public static int GetOrderCount()
        {
            return daJobOrder.GetOrderDetailsCount();
        }
        public static List<JobOrderGrid> GetJobOrderItems(bool hasjoborder,string column,Direction direction)
        {
            List<JobOrderGrid> jobOrderGrids = new List<JobOrderGrid>();
            using (DataSet ds = daJobOrder.ExecSpGetJobOrderItems(hasjoborder))
            {
                if (ds != null)
                {
                    using (DataView dv = ds.Tables[0].DefaultView)
                    {
                        dv.Sort = string.Format("{0} {1}", column
                                                        , EnumReader.GetDescription(direction));
                        for (int i = 0; i < dv.Count; i++)
                        {
                            JobOrderGrid jog = new JobOrderGrid(dv[i].Row);
                            //if(Convert.ToInt32(dr["SUPPLIERID"])!=-1)
                            //    jog.Supplier = blSupplier.retrieve(Convert.ToInt32(dr["SUPPLIERID"]));
                            jobOrderGrids.Add(jog);
                        }
                    }
                    //foreach (DataRow dr in ds.Tables[0].Rows)
                    //{
                    //    JobOrderGrid jog = new JobOrderGrid(dr);
                    //    //if(Convert.ToInt32(dr["SUPPLIERID"])!=-1)
                    //    //    jog.Supplier = blSupplier.retrieve(Convert.ToInt32(dr["SUPPLIERID"]));
                    //    jobOrderGrids.Add(jog);
                    //}
                }
            }
            return jobOrderGrids;
        }

        public static void AttachChild(int pointer, List<vwJobOrderItems> joborderitems)
        {
            if (pointer < joborderitems.Count)
            {
                joborderitems[pointer].OrderTransactionDetailEntity = blOrderTransactionDetail.retrieve(
                    joborderitems[pointer].OrderDetailsId);
                if (joborderitems[pointer].JobOrderId > 0)
                {
                    joborderitems[pointer].JobOrderEntity = blJobOrder.retrieve(
                        joborderitems[pointer].JobOrderId);
                }
                AttachChild(++pointer, joborderitems);

            }
        }
        
        public static List<vwJobOrderItems> GetJobOrderItems(
            string column,
            Direction direction,
            DateTime dtFrom,
            DateTime dtTo,
            string code,
            string customerName
            )
        {
            List<vwJobOrderItems> retValue = daJobOrder.GetJobOrderItem(
                column, (direction == Direction.ASC) ? "ASC" : "DESC",
                Convert.ToDateTime(string.Concat(dtFrom.ToShortDateString()," 12:00:00 AM")),
                Convert.ToDateTime(string.Concat(dtTo.ToShortDateString()," 11:59:59 PM")),
                code,
                customerName);

            AttachChild(0, retValue);
            
            
            return retValue;


        }
        
        public static JobOrder GetUnsavedJobOrder()
        {
            List<vwJobOrderItems> retValue = daJobOrder.GetUnsavedJobOrders();
            AttachChild(0, retValue);
            JobOrder ret = new JobOrder();
            if (retValue.Count > 0)
            {
                ret = retValue[0].JobOrderEntity;
            }
            return ret;

        }
        public static int GetUnsavedOrder()
        {
            return DataAccess.daJobOrder.GetUnsavedJobOrdersCount();
        }

        #endregion

        #region Update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.JobOrder update(Entity.JobOrder JobOrderObject)
        {
            //Do business processing here if necessary.

            //Call data access.
            DataAccess.daJobOrder.update(JobOrderObject);

            //get the saved data
            return JobOrderObject;
        }
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static List<Entity.JobOrder> updateList(List<Entity.JobOrder> JobOrderList)
        {
            #region update the list
            //look for any removed records and update the existing ones
            List<Entity.JobOrder> oldList = retrieve();
            bool IsRecordExist = false;
            foreach (Entity.JobOrder oldRecord in oldList)
            {
                IsRecordExist = false;
                foreach (Entity.JobOrder newRecord in JobOrderList)
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

            //create the newly added records
            foreach (Entity.JobOrder newRecord in JobOrderList)
            {
                IsRecordExist = false;
                foreach (Entity.JobOrder oldRecord in oldList)
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

            //Call data access.
            DataAccess.daJobOrder.delete(Id);
        }
        #endregion

       public static JobOrder SaveParentJobOrder(JobOrder joborder)
       {
           if (joborder.Id == 0 || joborder.Id==-1)
                return daJobOrder.create(joborder);
            else
            {
                daJobOrder.update(joborder);
                return joborder;
            }
           
             
       }

        public static void SaveJobOrderDetails(long id,
            long ordertransactiondetailid,long supplierid,int consumedquantity,long joborderid,long orderpackagedetailsid
            ,byte isdone,bool isselected)
        {
            if (isselected)
            {
                if (id == 0)
                {
                    //daJobOrder.CreateJobOrderDetails(
                    //    ordertransactiondetailid, supplierid, consumedquantity, joborderid,orderpackagedetailsid,isdone);
                    daJobOrderDetail.create(ordertransactiondetailid, supplierid, consumedquantity, joborderid, orderpackagedetailsid, isdone);
                }
                else
                {
                    //daJobOrder.UpdateJobOrderDetails(id, supplierid, consumedquantity,isdone);
                    daJobOrderDetail.update(id, supplierid, consumedquantity, isdone);
                }
            }
            else
            {
                if (id > 0)
                {
                    daJobOrderDetail.delete(id);
                }
            }
        }

        public static void SaveJobOrderDetails(long id,
                string suppliercode, int consumedquantity, long joborderid
            , byte isdone,bool isselected)
        {
            daJobOrderDetail.updateJobOrderItems(
                id,
                suppliercode,
                consumedquantity,
                joborderid,
                isdone,
               // issave,
                isselected);

        }

       

    }
}
