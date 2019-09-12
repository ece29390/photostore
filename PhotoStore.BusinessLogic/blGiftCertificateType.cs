using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.BusinessLogic
{
    public class blGiftCertificateType
    {
        /// <summary>Populate The GiftCertificateType Extention Entities.</summary>
        /// <param name="entityObject">source entity.</param>
        /// <returns>Return the entity object.</returns>
        public static Entity.GiftCertificateType populateExtentions(Entity.GiftCertificateType entityObject)
        {
            return entityObject;
        }

        /// <summary>Populate The GiftCertificateType Extention Entities.</summary>
        /// <param name="entityList">source entity List.</param>
        /// <returns>Return the entity object list.</returns>
        public static List<Entity.GiftCertificateType> populateExtentions(List<Entity.GiftCertificateType> entityList)
        {
            List<Entity.GiftCertificateType> retCol = new List<Entity.GiftCertificateType>();

            //populate the list
            foreach (Entity.GiftCertificateType entityObject in entityList)
            {
                retCol.Add(populateExtentions(entityObject));
            }

            return retCol;
        }


        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.GiftCertificateType create(Entity.GiftCertificateType GiftCertificateTypeObject)
        {
            //Call data access.
            Entity.GiftCertificateType ret = DataAccess.daGiftCertificateType.create(GiftCertificateTypeObject);
            return populateExtentions(ret);
        }

        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.GiftCertificateType> retrieve()
        {
            //perform the return
            return populateExtentions(DataAccess.daGiftCertificateType.retrieve());
        }

        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.GiftCertificateType retrieve(long Id)
        {
            //perform the return
            Entity.GiftCertificateType ret = DataAccess.daGiftCertificateType.retrieve(Id);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Code">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.GiftCertificateType retrieve(string Code)
        {
            //perform the return
            Entity.GiftCertificateType ret = DataAccess.daGiftCertificateType.retrieve(Code);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve all entities for a combobox.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.GiftCertificateType> retrieveForComboBox()
        {
            //create the list
            List<Entity.GiftCertificateType> ret = retrieve();

            if (ret == null) ret = new List<PhotoStore.Entity.GiftCertificateType>();

            //insert a default - for -1 value
            Entity.GiftCertificateType EmptyRow = new PhotoStore.Entity.GiftCertificateType();
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
        public static Entity.GiftCertificateType update(Entity.GiftCertificateType GiftCertificateTypeObject)
        {
            //Do business processing here if necessary.
            DataAccess.daGiftCertificateType.update(GiftCertificateTypeObject);

            //get the saved data
            return GiftCertificateTypeObject;
        }

        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static List<Entity.GiftCertificateType> updateList(List<Entity.GiftCertificateType> GiftCertificateTypeList)
        {
            #region update the list
            //look for any removed records and update the existing ones
            List<Entity.GiftCertificateType> oldList = retrieve();
            bool IsRecordExist = false;
            foreach (Entity.GiftCertificateType oldRecord in oldList)
            {
                IsRecordExist = false;
                foreach (Entity.GiftCertificateType newRecord in GiftCertificateTypeList)
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
            foreach (Entity.GiftCertificateType newRecord in GiftCertificateTypeList)
            {
                IsRecordExist = false;
                foreach (Entity.GiftCertificateType oldRecord in oldList)
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
            DataAccess.daGiftCertificateType.delete(Id);
        }
        #endregion
    }
}
