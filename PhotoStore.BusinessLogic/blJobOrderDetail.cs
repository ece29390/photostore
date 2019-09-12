using System;
using System.Collections.Generic;
using System.Text;
using PhotoStore.Entity;
using PhotoStore.DataAccess;
namespace PhotoStore.BusinessLogic
{
    public class blJobOrderDetail
    {
        /// <summary>Populate The JobOrderDetail Extention Entities.</summary>
        /// <param name="entityObject">source entity.</param>
        /// <returns>Return the entity object.</returns>
        public static Entity.JobOrderDetail populateExtentions(Entity.JobOrderDetail entityObject)
        {                   
            entityObject.Supplier=daSupplier.retrieve(entityObject.SupplierId);
            entityObject.JobOrder=daJobOrder.retrieve(entityObject.JobOrderId);
            entityObject.OrderDetail = daOrderTransactionDetail.retrieve(entityObject.OrderDetailsId);
            return entityObject;
        }

        /// <summary>Populate The JobOrderDetail Extention Entities.</summary>
        /// <param name="entityList">source entity List.</param>
        /// <returns>Return the entity object list.</returns>
        public static List<Entity.JobOrderDetail> populateExtentions(List<Entity.JobOrderDetail> entityList)
        {
            List<Entity.JobOrderDetail> retCol = new List<Entity.JobOrderDetail>();

            //populate the list
            foreach (Entity.JobOrderDetail entityObject in entityList)
            {
                retCol.Add(populateExtentions(entityObject));
            }

            return retCol;
        }
        public static List<Entity.RejectedPackage> GetPrintedJobOrders(long orderdetailid)
        {
            return daJobOrderDetail.retrieveDoneJobOrder(orderdetailid);
        }

     

        public static bool AllowRejectOrDelete(long orderdetailid)
        {
            List<JobOrders> jobOrderDetailId = new List<JobOrders>();
            jobOrderDetailId = daJobOrderDetail.retrieveBySQL(
                string.Format("SELECT * FROM JobOrders WHERE OrderDetailsId={0} AND IsDone = 1",
                orderdetailid));

            return jobOrderDetailId.Count > 0 ? false : true;
        }
        public static long GetJobOrderDetailId(long orderpackagedetailid)
        {
            
            List<JobOrderDetail> jobOrderDetails = daJobOrderDetail.retrieveByWhereStatement(
                string.Concat("WHERE OrderPackageDetailsId=", orderpackagedetailid));
            return  jobOrderDetails.Count > 0 ? jobOrderDetails[0].Id : 0;
 
        }
        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.JobOrderDetail create(Entity.JobOrderDetail JobOrderDetailObject)
        {
            //Call data access.
            Entity.JobOrderDetail ret = DataAccess.daJobOrderDetail.create(JobOrderDetailObject);
            if (ret == null) return null;
            return populateExtentions(ret);
        }
        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.JobOrderDetail> retrieve()
        {
            //perform the return
            return populateExtentions(DataAccess.daJobOrderDetail.retrieve());
        }
    
        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.JobOrderDetail retrieve(int Id)
        {
            //perform the return
            Entity.JobOrderDetail ret = DataAccess.daJobOrderDetail.retrieve(Id);
            return populateExtentions(ret);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Code">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.JobOrderDetail retrieve(string Code)
        {
            //perform the return
            Entity.JobOrderDetail ret = DataAccess.daJobOrderDetail.retrieve(Code);
            return populateExtentions(ret);
        }

    

        #endregion

        #region Update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.JobOrderDetail update(Entity.JobOrderDetail JobOrderDetailObject)
        {
            //Do business processing here if necessary.
            DataAccess.daJobOrderDetail.update(JobOrderDetailObject);

            //get the saved data
            return JobOrderDetailObject;
        }

        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static List<Entity.JobOrderDetail> updateList(List<Entity.JobOrderDetail> JobOrderDetailList)
        {
            #region update the List
            //look for any removed records and update the existing ones
            List<Entity.JobOrderDetail> oldList = retrieve();
            bool IsRecordExist = false;
            foreach (Entity.JobOrderDetail oldRecord in oldList)
            {
                IsRecordExist = false;
                foreach (Entity.JobOrderDetail newRecord in JobOrderDetailList)
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
            foreach (Entity.JobOrderDetail newRecord in JobOrderDetailList)
            {
                IsRecordExist = false;
                foreach (Entity.JobOrderDetail oldRecord in oldList)
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
            DataAccess.daJobOrderDetail.delete(Id);
        }
        #endregion

        #region Common Methods
        public static List<PhotoStore.Entity.JobOrderDetail> GetPendingItems()
        {
            
            List<PhotoStore.Entity.JobOrderDetail> jobOrderDetails =
                daJobOrderDetail.retrieveByWhereStatement("WHERE IsDone=0 ORDER BY JobOrder_Id ASC");
            populateExtentions(jobOrderDetails);
            return jobOrderDetails;
        }

        public static List<PhotoStore.Entity.JobOrders> GetJobOrders()
        {
            List<PhotoStore.Entity.JobOrders> retValue = daJobOrderDetail.retrieveJobOrders(
                "SELECT * FROM JobOrders WHERE IsDone={0}");

            return retValue;
        }

        public static List<PhotoStore.Entity.JobOrderDetail> GetPrintedJobOrder(
            long orderdetailid, long orderpackagedetailid)
        {
            List<PhotoStore.Entity.JobOrderDetail> jobOrderDetails =
                daJobOrderDetail.retrieveByWhereStatement(
                string.Format("WHERE OrderDetails_Id={0} AND OrderPackageDetailsId={1} ORDER BY JobOrder_Id ASC",
                orderdetailid,orderpackagedetailid));
            populateExtentions(jobOrderDetails);
            return jobOrderDetails;
        }
        public static List<PhotoStore.Entity.JobOrderDetail> GetPrintedJobOrder(
           long orderdetailid)
        {
            List<PhotoStore.Entity.JobOrderDetail> jobOrderDetails =
                daJobOrderDetail.retrieveByWhereStatement(
                string.Format("WHERE OrderDetails_Id={0} AND IsDone=1  ORDER BY JobOrder_Id ASC",
                orderdetailid));
            populateExtentions(jobOrderDetails);
            return jobOrderDetails;
        }
        #endregion
    }
}
