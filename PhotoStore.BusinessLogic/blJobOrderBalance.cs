using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.BusinessLogic
{
    public class blJobOrderBalance
    {
        /// <summary>Populate The JobOrderBalance Extention Entities.</summary>
        /// <param name="entityObject">source entity.</param>
        /// <returns>Return the entity object.</returns>
        public static Entity.JobOrderBalance populateExtentions(Entity.JobOrderBalance entityObject)
        {
            entityObject.OrderTransaction = DataAccess.daOrderTransaction.retrieve(entityObject.OrderTransactionId);
            return entityObject;
        }

        /// <summary>Populate The JobOrderBalance Extention Entities.</summary>
        /// <param name="entityList">source entity List.</param>
        /// <returns>Return the entity object list.</returns>
        public static List<Entity.JobOrderBalance> populateExtentions(List<Entity.JobOrderBalance> entityList)
        {
            List<Entity.JobOrderBalance> retCol = new List<Entity.JobOrderBalance>();

            //populate the list
            foreach (Entity.JobOrderBalance entityObject in entityList)
            {
                retCol.Add(populateExtentions(entityObject));
            }

            return retCol;
        }


        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.JobOrderBalance create(Entity.JobOrderBalance JobOrderBalanceObject)
        {
            //Call data access.
            Entity.JobOrderBalance ret = DataAccess.daJobOrderBalance.create(JobOrderBalanceObject);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        #endregion

        #region Retrieve
        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.JobOrderBalance retrieve(int Id)
        {
            //call the retrieval
            Entity.JobOrderBalance ret = DataAccess.daJobOrderBalance.retrieve(Id);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Code">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.JobOrderBalance retrieve(string Code)
        {
            //call the retrieval
            Entity.JobOrderBalance ret = DataAccess.daJobOrderBalance.retrieve(Code);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.JobOrderBalance> retrieve()
        {
            //create the list
            List<Entity.JobOrderBalance> retList = DataAccess.daJobOrderBalance.retrieve();
            if (retList == null) return null;
            return populateExtentions(retList);
        }
        #endregion

        #region Update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.JobOrderBalance update(Entity.JobOrderBalance JobOrderBalanceObject)
        {
            //Do business processing here if necessary.

            //Call data access.
            DataAccess.daJobOrderBalance.update(JobOrderBalanceObject);

            //get the saved data
            return JobOrderBalanceObject;
        }

        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static List<Entity.JobOrderBalance> updateList(List<Entity.JobOrderBalance> JobOrderBalanceList)
        {
            #region update the list
            //look for any removed records and update the existing ones
            List<Entity.JobOrderBalance> oldList = retrieve();
            bool IsRecordExist = false;
            foreach (Entity.JobOrderBalance oldRecord in oldList)
            {
                IsRecordExist = false;
                foreach (Entity.JobOrderBalance newRecord in JobOrderBalanceList)
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
            foreach (Entity.JobOrderBalance newRecord in JobOrderBalanceList)
            {
                IsRecordExist = false;
                foreach (Entity.JobOrderBalance oldRecord in oldList)
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
            DataAccess.daJobOrderBalance.delete(Id);
        }
        #endregion
    }
}
