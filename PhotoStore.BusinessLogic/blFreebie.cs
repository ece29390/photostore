using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.BusinessLogic
{
    public class blFreebie
    {
        /// <summary>Populate The Freebie Extention Entities.</summary>
        /// <param name="entityObject">source entity.</param>
        /// <returns>Return the entity object.</returns>
        public static Entity.Freebie populateExtentions(Entity.Freebie entityObject)
        {
            return entityObject;
        }

        /// <summary>Populate The Freebie Extention Entities.</summary>
        /// <param name="entityList">source entity List.</param>
        /// <returns>Return the entity object list.</returns>
        public static List<Entity.Freebie> populateExtentions(List<Entity.Freebie> entityList)
        {
            List<Entity.Freebie> retCol = new List<Entity.Freebie>();

            //populate the list
            foreach (Entity.Freebie entityObject in entityList)
            {
                retCol.Add(populateExtentions(entityObject));
            }

            return retCol;
        }


        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.Freebie create(Entity.Freebie FreebieObject)
        {
            //Call data access.
            Entity.Freebie ret = DataAccess.daFreebie.create(FreebieObject);
            return populateExtentions(ret);
        }

        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.Freebie> retrieve()
        {
            //perform the return
            return populateExtentions(DataAccess.daFreebie.retrieve());
        }

        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.Freebie retrieve(int Id)
        {
            //perform the return
            Entity.Freebie ret = DataAccess.daFreebie.retrieve(Id);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Code">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.Freebie retrieve(string Code)
        {
            //perform the return
            Entity.Freebie ret = DataAccess.daFreebie.retrieve(Code);
            if (ret == null) return null;
            return populateExtentions(ret);
        }
        #endregion

        #region Update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.Freebie update(Entity.Freebie FreebieObject)
        {
            //Do business processing here if necessary.
            DataAccess.daFreebie.update(FreebieObject);

            //get the saved data
            return FreebieObject;
        }

        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static List<Entity.Freebie> updateList(List<Entity.Freebie> FreebieList)
        {
            #region update the list
            //look for any removed records and update the existing ones
            List<Entity.Freebie> oldList = retrieve();
            bool IsRecordExist = false;
            foreach (Entity.Freebie oldRecord in oldList)
            {
                IsRecordExist = false;
                foreach (Entity.Freebie newRecord in FreebieList)
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
            foreach (Entity.Freebie newRecord in FreebieList)
            {
                IsRecordExist = false;
                foreach (Entity.Freebie oldRecord in oldList)
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
            DataAccess.daFreebie.delete(Id);
        }
        #endregion
    }
}
