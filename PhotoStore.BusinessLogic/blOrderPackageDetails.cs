using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.BusinessLogic
{
    public class blOrderPackageDetails
    {

        /// <summary>Populate The OrderPackageDetails Extention Entities.</summary>
        /// <param name="entityObject">source entity.</param>
        /// <returns>Return the entity object.</returns>
        public static Entity.OrderPackageDetails populateExtentions(Entity.OrderPackageDetails entityObject)
        {
            entityObject.OrderTransactionDetail = DataAccess.daOrderTransactionDetail.retrieve(entityObject.OrderTransactionDetailId);
            
            return entityObject;
        }

        /// <summary>Populate The OrderPackageDetails Extention Entities.</summary>
        /// <param name="entityList">source entity List.</param>
        /// <returns>Return the entity object list.</returns>
        public static List<Entity.OrderPackageDetails> populateExtentions(List<Entity.OrderPackageDetails> entityList)
        {
            List<Entity.OrderPackageDetails> retCol = new List<Entity.OrderPackageDetails>();

            //populate the list
            foreach (Entity.OrderPackageDetails entityObject in entityList)
            {
                retCol.Add(populateExtentions(entityObject));
            }

            return retCol;
        }


        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.OrderPackageDetails create(Entity.OrderPackageDetails OrderPackageDetailsObject)
        {
            //Call data access.
            Entity.OrderPackageDetails ret = DataAccess.daOrderPackageDetails.create(OrderPackageDetailsObject);
            if (ret == null) return null;
            return populateExtentions(ret);
        }
        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.OrderPackageDetails> retrieve()
        {
            //perform the return
            return populateExtentions(DataAccess.daOrderPackageDetails.retrieve());
        }
        public static List<Entity.OrderPackageDetails> retrieveByStatusId(long statusid)
        {
            return populateExtentions(DataAccess.daOrderPackageDetails.retrieveByWhereStatement(
                string.Format("WHERE OrderPackageDetailsStatusId={0} AND (ExpirationDate IS NULL OR ExpirationDate>=GETDATE())",
                statusid)));
        }

        public static List<Entity.OrderPackageDetails> GetDoneOrderPackage(
            long orderdetailsid)
        {
            return DataAccess.daOrderPackageDetails.retrievePrintedItems(orderdetailsid);
        }
        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.OrderPackageDetails retrieve(int Id)
        {
            //perform the return
            Entity.OrderPackageDetails ret = DataAccess.daOrderPackageDetails.retrieve(Id);
            return populateExtentions(ret);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Code">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.OrderPackageDetails retrieve(string Code)
        {
            //perform the return
            Entity.OrderPackageDetails ret = DataAccess.daOrderPackageDetails.retrieve(Code);
            return populateExtentions(ret);
        }


        public static List<PhotoStore.Entity.OrderPackageDetails> retrieveByOrderTransactionDetail(long orderdetailid)
        {
            List<PhotoStore.Entity.OrderPackageDetails> retValue= DataAccess.daOrderPackageDetails.retrieveByWhereStatement(
                string.Format("WHERE OrderDetails_Id={0}", orderdetailid));
            populateExtentions(retValue);
            return retValue;
               
        }

        #endregion

        #region Update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.OrderPackageDetails update(Entity.OrderPackageDetails OrderPackageDetailsObject)
        {
            //Do business processing here if necessary.
            DataAccess.daOrderPackageDetails.update(OrderPackageDetailsObject);

            //get the saved data
            return OrderPackageDetailsObject;
        }

        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static List<Entity.OrderPackageDetails> updateList(List<Entity.OrderPackageDetails> OrderPackageDetailsList)
        {
            #region update the List
            //look for any removed records and update the existing ones
            List<Entity.OrderPackageDetails> oldList = retrieve();
            bool IsRecordExist = false;
            foreach (Entity.OrderPackageDetails oldRecord in oldList)
            {
                IsRecordExist = false;
                foreach (Entity.OrderPackageDetails newRecord in OrderPackageDetailsList)
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
            foreach (Entity.OrderPackageDetails newRecord in OrderPackageDetailsList)
            {
                IsRecordExist = false;
                foreach (Entity.OrderPackageDetails oldRecord in oldList)
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
            DataAccess.daOrderPackageDetails.delete(Id);
        }
        #endregion
    }
}
