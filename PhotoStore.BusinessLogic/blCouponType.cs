using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.BusinessLogic
{
    public class blCouponType
    {

        /// <summary>Populate The CouponType Extention Entities.</summary>
        /// <param name="entityObject">source entity.</param>
        /// <returns>Return the entity object.</returns>
        public static Entity.CouponType populateExtentions(Entity.CouponType entityObject)
        {
            return entityObject;
        }

        /// <summary>Populate The CouponType Extention Entities.</summary>
        /// <param name="entityList">source entity List.</param>
        /// <returns>Return the entity object list.</returns>
        public static List<Entity.CouponType> populateExtentions(List<Entity.CouponType> entityList)
        {
            List<Entity.CouponType> retCol = new List<Entity.CouponType>();

            //populate the list
            foreach (Entity.CouponType entityObject in entityList)
            {
                retCol.Add(populateExtentions(entityObject));
            }

            return retCol;
        }

        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.CouponType create(Entity.CouponType CouponTypeObject)
        {
            //Call data access.
            Entity.CouponType ret = DataAccess.daCouponType.create(CouponTypeObject);
            return populateExtentions(ret);
        }
        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.CouponType> retrieve()
        {
            //perform the return
            return populateExtentions(DataAccess.daCouponType.retrieve());
        }

        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.CouponType retrieve(int Id)
        {
            //perform the return
            Entity.CouponType ret = DataAccess.daCouponType.retrieve(Id);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Code">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.CouponType retrieve(string Code)
        {
            //perform the return
            Entity.CouponType ret = DataAccess.daCouponType.retrieve(Code);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve all entities for a combobox.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.CouponType> retrieveForComboBox()
        {
            //create the list
            List<Entity.CouponType> ret = retrieve();

            if (ret == null) ret = new List<PhotoStore.Entity.CouponType>();

            //insert a default - for -1 value
            Entity.CouponType EmptyRow = new PhotoStore.Entity.CouponType();
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
        public static Entity.CouponType update(Entity.CouponType CouponTypeObject)
        {
            //Do business processing here if necessary.
            //create the item
            DataAccess.daCouponType.update(CouponTypeObject);

            //get the saved data
            return CouponTypeObject;
        }

        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static List<Entity.CouponType> updateList(List<Entity.CouponType> CouponTypeList)
        {
            #region update the list
            //look for any removed records and update the existing ones
            List<Entity.CouponType> oldList = retrieve();
            bool IsRecordExist = false;
            foreach (Entity.CouponType oldRecord in oldList)
            {
                IsRecordExist = false;
                foreach (Entity.CouponType newRecord in CouponTypeList)
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
            foreach (Entity.CouponType newRecord in CouponTypeList)
            {
                IsRecordExist = false;
                foreach (Entity.CouponType oldRecord in oldList)
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
            DataAccess.daCouponType.delete(Id);
        }
        #endregion
    }
}
