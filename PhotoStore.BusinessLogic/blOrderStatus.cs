using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.BusinessLogic
{
    public class blOrderStatus
    {
        /// <summary>Populate The OrderStatus Extention Entities.</summary>
        /// <param name="entityObject">source entity.</param>
        /// <returns>Return the entity object.</returns>
        public static Entity.OrderStatus populateExtentions(Entity.OrderStatus entityObject)
        {
            return entityObject;
        }

        /// <summary>Populate The OrderStatus Extention Entities.</summary>
        /// <param name="entityList">source entity List.</param>
        /// <returns>Return the entity object list.</returns>
        public static List<Entity.OrderStatus> populateExtentions(List<Entity.OrderStatus> entityList)
        {
            List<Entity.OrderStatus> retCol = new List<Entity.OrderStatus>();

            //populate the list
            foreach (Entity.OrderStatus entityObject in entityList)
            {
                retCol.Add(populateExtentions(entityObject));
            }

            return retCol;
        }


        #region Create

        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.OrderStatus create(Entity.OrderStatus OrderStatusObject)
        {
            //Call data access.
            Entity.OrderStatus ret = DataAccess.daOrderStatus.create(OrderStatusObject);
            return populateExtentions(ret);
        }

        #endregion

        #region Retrieve
        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.OrderStatus retrieve(int Id)
        {
            //call the retrieval
            Entity.OrderStatus ret = DataAccess.daOrderStatus.retrieve(Id);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Code">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.OrderStatus retrieve(string Code)
        {
            //create the data layer
            Entity.OrderStatus ret = DataAccess.daOrderStatus.retrieve(Code);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.OrderStatus> retrieve()
        {
            //call the retrieval
            List<Entity.OrderStatus> retList = DataAccess.daOrderStatus.retrieve();
            if (retList == null) return null;
            return populateExtentions(retList);
        }
        #endregion

    }
}
