using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.BusinessLogic
{
    public class blOrderTransactionModifiedBy
    {
        /// <summary>Populate The OrderTransactionModifiedBy Extention Entities.</summary>
        /// <param name="entityObject">source entity.</param>
        /// <returns>Return the entity object.</returns>
        public static Entity.OrderTransactionModifiedBy populateExtentions(Entity.OrderTransactionModifiedBy entityObject)
        {
            entityObject.OrderTransactionEntity = DataAccess.daOrderTransaction.retrieve(entityObject.OrderTransactionId);
            entityObject.ModifiedByEmployee = DataAccess.daEmployee.retrieve(entityObject.ModifiedByEmployeeId);
            return entityObject;
        }

        /// <summary>Populate The OrderTransactionModifiedBy Extention Entities.</summary>
        /// <param name="entityList">source entity List.</param>
        /// <returns>Return the entity object list.</returns>
        public static List<Entity.OrderTransactionModifiedBy> populateExtentions(List<Entity.OrderTransactionModifiedBy> entityList)
        {
            List<Entity.OrderTransactionModifiedBy> retCol = new List<Entity.OrderTransactionModifiedBy>();

            //populate the list
            foreach (Entity.OrderTransactionModifiedBy entityObject in entityList)
            {
                retCol.Add(populateExtentions(entityObject));
            }

            return retCol;
        }


        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.OrderTransactionModifiedBy create(Entity.OrderTransactionModifiedBy OrderTransactionModifiedByObject)
        {
            //Call data access.
            Entity.OrderTransactionModifiedBy ret = DataAccess.daOrderTransactionModifiedBy.create(OrderTransactionModifiedByObject);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static List<Entity.OrderTransactionModifiedBy> create(List<Entity.OrderTransactionModifiedBy> OrderTransactionModifiedByList)
        {
            if (OrderTransactionModifiedByList.Count == 0) return null;
            //Call data access.
            foreach (Entity.OrderTransactionModifiedBy OrderTransactionModifiedByObject in OrderTransactionModifiedByList)
            {
                create(OrderTransactionModifiedByObject);
            }

            return retrieveByOrderTransactionId(OrderTransactionModifiedByList[0].OrderTransactionId);
        }

        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.OrderTransactionModifiedBy> retrieve()
        {
            //create the list
            List<Entity.OrderTransactionModifiedBy> retList = DataAccess.daOrderTransactionModifiedBy.retrieve();
            if (retList == null) return null;
            return populateExtentions(retList);

        }
        
        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.OrderTransactionModifiedBy retrieve(int Id)
        {
            //call the retrieval
            Entity.OrderTransactionModifiedBy ret = DataAccess.daOrderTransactionModifiedBy.retrieve(Id);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.OrderTransactionModifiedBy> retrieveByOrderTransactionId(long OrderTransactionId)
        {
            //create the list
            List<Entity.OrderTransactionModifiedBy> retList = DataAccess.daOrderTransactionModifiedBy.retrieveByOrderTransactionId(OrderTransactionId);
            if (retList == null) return null;
            return populateExtentions(retList);
        }

        /// <summary>Retrieve a single entity by Modified Employee Id.</summary>
        /// <param name="ModifiedByEmployeeId">Entity Modified Employee Id.</param>
        /// <returns>Return Entity object.</returns>
        public static List<Entity.OrderTransactionModifiedBy> retrieveByModifiedByEmployeeId(int OrderTransactionId, int ModifiedByEmployeeId)
        {
            //create the list
            List<Entity.OrderTransactionModifiedBy> retList = DataAccess.daOrderTransactionModifiedBy.retrieveByModifiedByEmployeeId(OrderTransactionId, ModifiedByEmployeeId);
            if (retList == null) return null;
            return populateExtentions(retList);
        }

        #endregion

        #region Update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.OrderTransactionModifiedBy update(Entity.OrderTransactionModifiedBy OrderTransactionModifiedByObject)
        {
            //Do business processing here if necessary.

            //Call data access.
            DataAccess.daOrderTransactionModifiedBy.update(OrderTransactionModifiedByObject);

            //get the saved data
            return OrderTransactionModifiedByObject;
        }
        /// <summary>Update the details of a particular transaction.</summary>
        /// <param name="OrderTransactionObject">Order Transaction object.</param>
        public static List<Entity.OrderTransactionModifiedBy> updateListByOrderTransactionId(long OrderTransactionId, List<Entity.OrderTransactionModifiedBy> OrderTransactionModifiedByList)
        {
            //look for any removed details and update the existing ones
            List<Entity.OrderTransactionModifiedBy> oldItems = retrieveByOrderTransactionId(OrderTransactionId);
            bool IsdetailExist = false;
            foreach (Entity.OrderTransactionModifiedBy oldItem in oldItems)
            {
                IsdetailExist = false;
                foreach (Entity.OrderTransactionModifiedBy newItem in OrderTransactionModifiedByList)
                {
                    if (newItem.Id == oldItem.Id)
                    {
                        IsdetailExist = true;
                        update(newItem);
                        break;
                    }
                }
                if (!IsdetailExist) delete(oldItem.Id);
            }

            //create the newly added records
            foreach (Entity.OrderTransactionModifiedBy newItem in OrderTransactionModifiedByList)
            {
                IsdetailExist = false;
                foreach (Entity.OrderTransactionModifiedBy oldItem in oldItems)
                {
                    if (newItem.Id == oldItem.Id)
                    {
                        IsdetailExist = true;
                        break;
                    }
                }
                if (!IsdetailExist)
                {
                    newItem.OrderTransactionId = OrderTransactionId;
                    create(newItem);
                }
            }

            return retrieveByOrderTransactionId(OrderTransactionId);
        }
        #endregion

        #region Delete
        /// <summary>delete an item entry from the database.</summary>
        /// <param name="OrderTransactionId">Item to delete.</param>
        public static void delete(long OrderTransactionId)
        {
            //Call data access.
            DataAccess.daOrderTransactionModifiedBy.delete(OrderTransactionId);
        }
        #endregion
    }
}
