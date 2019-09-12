using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.BusinessLogic
{
    public class blCouponStatus
    {

        /// <summary>Populate The CouponStatus Extention Entities.</summary>
        /// <param name="entityObject">source entity.</param>
        /// <returns>Return the entity object.</returns>
        public static Entity.CouponStatus populateExtentions(Entity.CouponStatus entityObject)
        {
            return entityObject;
        }

        /// <summary>Populate The CouponStatus Extention Entities.</summary>
        /// <param name="entityList">source entity List.</param>
        /// <returns>Return the entity object list.</returns>
        public static List<Entity.CouponStatus> populateExtentions(List<Entity.CouponStatus> entityList)
        {
            List<Entity.CouponStatus> retCol = new List<Entity.CouponStatus>();

            //populate the list
            foreach (Entity.CouponStatus entityObject in entityList)
            {
                retCol.Add(populateExtentions(entityObject));
            }

            return retCol;
        }


        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.CouponStatus create(Entity.CouponStatus CouponStatusObject)
        {
            //Call data access.
            Entity.CouponStatus ret = DataAccess.daCouponStatus.create(CouponStatusObject);
            return populateExtentions(ret);
        }
        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.CouponStatus> retrieve()
        {
            //perform the return
            return populateExtentions(DataAccess.daCouponStatus.retrieve());
        }

        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.CouponStatus retrieve(int Id)
        {
            //perform the return
            Entity.CouponStatus ret = DataAccess.daCouponStatus.retrieve(Id);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Code">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.CouponStatus retrieve(string Code)
        {
            //perform the return
            Entity.CouponStatus ret = DataAccess.daCouponStatus.retrieve(Code);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve all entities for a combobox.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.CouponStatus> retrieveForComboBox()
        {
            //create the list
            List<Entity.CouponStatus> ret = retrieve();

            if (ret == null) ret = new List<PhotoStore.Entity.CouponStatus>();

            //insert a default - for -1 value
            Entity.CouponStatus EmptyRow = new PhotoStore.Entity.CouponStatus();
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
        public static Entity.CouponStatus update(Entity.CouponStatus CouponStatusObject)
        {
            //Do business processing here if necessary.
            DataAccess.daCouponStatus.update(CouponStatusObject);

            //get the saved data
            return CouponStatusObject;
        }

        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static List<Entity.CouponStatus> updateList(List<Entity.CouponStatus> CouponStatusList)
        {
            #region update the list
            //look for any removed records and update the existing ones
            List<Entity.CouponStatus> oldList = retrieve();
            bool IsRecordExist = false;
            foreach (Entity.CouponStatus oldRecord in oldList)
            {
                IsRecordExist = false;
                foreach (Entity.CouponStatus newRecord in CouponStatusList)
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
            foreach (Entity.CouponStatus newRecord in CouponStatusList)
            {
                IsRecordExist = false;
                foreach (Entity.CouponStatus oldRecord in oldList)
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
            DataAccess.daCouponStatus.delete(Id);
        }
        #endregion
    }
}
