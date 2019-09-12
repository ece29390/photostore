using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.BusinessLogic
{
    public class blGiftCertificateStatus
    {
        /// <summary>Populate The GiftCertificateStatus Extention Entities.</summary>
        /// <param name="entityObject">source entity.</param>
        /// <returns>Return the entity object.</returns>
        public static Entity.GiftCertificateStatus populateExtentions(Entity.GiftCertificateStatus entityObject)
        {
            return entityObject;
        }

        /// <summary>Populate The GiftCertificateStatus Extention Entities.</summary>
        /// <param name="entityList">source entity List.</param>
        /// <returns>Return the entity object list.</returns>
        public static List<Entity.GiftCertificateStatus> populateExtentions(List<Entity.GiftCertificateStatus> entityList)
        {
            List<Entity.GiftCertificateStatus> retCol = new  List<Entity.GiftCertificateStatus>();

            //populate the list
            foreach (Entity.GiftCertificateStatus entityObject in entityList)
            {
                retCol.Add(populateExtentions(entityObject));
            }

            return retCol;
        }


        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.GiftCertificateStatus create(Entity.GiftCertificateStatus GiftCertificateStatusObject)
        {
            //Call data access.
            Entity.GiftCertificateStatus ret = DataAccess.daGiftCertificateStatus.create(GiftCertificateStatusObject);
            return populateExtentions(ret);
        }

        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.GiftCertificateStatus> retrieve()
        {
            //perform the return
            return populateExtentions(DataAccess.daGiftCertificateStatus.retrieve());
        }

        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.GiftCertificateStatus retrieve(long Id)
        {
            //perform the return
            Entity.GiftCertificateStatus ret = DataAccess.daGiftCertificateStatus.retrieve(Id);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Code">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.GiftCertificateStatus retrieve(string Code)
        {
            //perform the return
            Entity.GiftCertificateStatus ret = DataAccess.daGiftCertificateStatus.retrieve(Code);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve all entities for a combobox.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.GiftCertificateStatus> retrieveForComboBox()
        {
            //create the list
            List<Entity.GiftCertificateStatus> ret = retrieve();

            if (ret == null) ret = new List<PhotoStore.Entity.GiftCertificateStatus>();

            //insert a default - for -1 value
            Entity.GiftCertificateStatus EmptyRow = new PhotoStore.Entity.GiftCertificateStatus();
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
        public static Entity.GiftCertificateStatus update(Entity.GiftCertificateStatus GiftCertificateStatusObject)
        {
            //Do business processing here if necessary.
            DataAccess.daGiftCertificateStatus.update(GiftCertificateStatusObject);

            //get the saved data
            return GiftCertificateStatusObject;
        }

        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static List<Entity.GiftCertificateStatus> updateList(List<Entity.GiftCertificateStatus> GiftCertificateStatusList)
        {
            #region update the list
            //look for any removed records and update the existing ones
            List<Entity.GiftCertificateStatus> oldList = retrieve();
            bool IsRecordExist = false;
            foreach (Entity.GiftCertificateStatus oldRecord in oldList)
            {
                IsRecordExist = false;
                foreach (Entity.GiftCertificateStatus newRecord in GiftCertificateStatusList)
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
            foreach (Entity.GiftCertificateStatus newRecord in GiftCertificateStatusList)
            {
                IsRecordExist = false;
                foreach (Entity.GiftCertificateStatus oldRecord in oldList)
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
            DataAccess.daGiftCertificateStatus.delete(Id);
        }
        #endregion
    }
}
