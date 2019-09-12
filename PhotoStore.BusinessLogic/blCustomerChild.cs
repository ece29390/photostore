using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.BusinessLogic
{
    public class blCustomerChild
    {
        /// <summary>Populate The CustomerChild Extention Entities.</summary>
        /// <param name="entityObject">source entity.</param>
        /// <returns>Return the entity object.</returns>
        public static Entity.CustomerChild populateExtentions(Entity.CustomerChild entityObject)
        {
            entityObject.CustomerEntity = DataAccess.daCustomer.retrieve(entityObject.CustomerId);
            return entityObject;
        }

        /// <summary>Populate The CustomerChild Extention Entities.</summary>
        /// <param name="entityList">source entity List.</param>
        /// <returns>Return the entity object list.</returns>
        public static List<Entity.CustomerChild> populateExtentions(List<Entity.CustomerChild> entityList)
        {
            List<Entity.CustomerChild> retCol = new List<Entity.CustomerChild>();

            //populate the list
            foreach (Entity.CustomerChild entityObject in entityList)
            {
                retCol.Add(populateExtentions(entityObject));
            }

            return retCol;
        }


        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.CustomerChild create(Entity.CustomerChild CustomerChildObject)
        {
            //Call data access.
            Entity.CustomerChild ret = DataAccess.daCustomerChild.create(CustomerChildObject);
            return populateExtentions(ret);
        }

        /// <summary>Create an item entry in the database.</summary>
        /// <param name="CustomerChildList">CustomerChild List.</param>
        public static List<Entity.CustomerChild> create(List<Entity.CustomerChild> CustomerChildList)
        {
            if (CustomerChildList.Count == 0) return null;
            //Call data access.
            foreach (Entity.CustomerChild CustomerChildObject in CustomerChildList)
            {
                create(CustomerChildObject);
            }
            
            return retrieveByCustomerId(CustomerChildList[0].CustomerId);
        }

        #endregion

        #region Retrieve
        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.CustomerChild retrieve(int Id)
        {
            //call the retrieval
            Entity.CustomerChild ret = DataAccess.daCustomerChild.retrieve(Id);
            if (ret == null) return null;
            return populateExtentions(ret);

        }

        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.CustomerChild> retrieveByCustomerId(long CustomerId)
        {
            //perform the return
            List<Entity.CustomerChild> retList = DataAccess.daCustomerChild.retrieveByCustomerId(CustomerId);
            if (retList == null) return null;
            return populateExtentions(retList);
        }

        /// <summary>Retrieve a single entity by Name.</summary>
        /// <param name="CustomerId">Customer Id.</param>
        /// <param name="Name">Customer Name.</param>
        /// <returns>Return Entity object.</returns>
        public static List<Entity.CustomerChild> retrieveByCustomerIdAndName(int CustomerId, string Name)
        {
            //perform the return
            List<Entity.CustomerChild> retList = DataAccess.daCustomerChild.retrieveByCustomerIdAndName(CustomerId, Name);
            if (retList == null) return null;
            return populateExtentions(retList);

        }

        #endregion

        #region Update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.CustomerChild update(Entity.CustomerChild CustomerChildObject)
        {
            //Do business processing here if necessary.
            DataAccess.daCustomerChild.update(CustomerChildObject);

            //get the saved data
            return CustomerChildObject;
        }
        /// <summary>Update the details of a particular transaction.</summary>
        /// <param name="CustomerObject">Order Transaction object.</param>
        public static List<Entity.CustomerChild> updateListByCustomerId(long CustomerId, List<Entity.CustomerChild> CustomerChildList)
        {
            //look for any removed details and update the existing ones
            List<Entity.CustomerChild> oldItems = retrieveByCustomerId(CustomerId);
            bool IsdetailExist = false;
            foreach (Entity.CustomerChild oldItem in oldItems)
            {
                IsdetailExist = false;
                foreach (Entity.CustomerChild newItem in CustomerChildList)
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
            foreach (Entity.CustomerChild newItem in CustomerChildList)
            {
                IsdetailExist = false;
                foreach (Entity.CustomerChild oldItem in oldItems)
                {
                    if (newItem.Id == oldItem.Id)
                    {
                        IsdetailExist = true;
                        break;
                    }
                }
                if (!IsdetailExist)
                {
                    newItem.CustomerId = CustomerId;
                    create(newItem);
                }
            }

            return retrieveByCustomerId(CustomerId);
        }
        #endregion

        #region Delete
        /// <summary>delete an item entry from the database.</summary>
        /// <param name="CustomerId">Item to delete.</param>
        public static void delete(long CustomerId)
        {
            //Call data access.
            DataAccess.daCustomerChild.delete(CustomerId);
        }
        #endregion
    }
}
