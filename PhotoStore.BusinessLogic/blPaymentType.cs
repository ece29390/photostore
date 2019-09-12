using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.BusinessLogic
{
    public class blPaymentType
    {
        /// <summary>Populate The PaymentType Extention Entities.</summary>
        /// <param name="entityObject">source entity.</param>
        /// <returns>Return the entity object.</returns>
        public static Entity.PaymentType populateExtentions(Entity.PaymentType entityObject)
        {
            return entityObject;
        }

        /// <summary>Populate The PaymentType Extention Entities.</summary>
        /// <param name="entityList">source entity List.</param>
        /// <returns>Return the entity object list.</returns>
        public static List<Entity.PaymentType> populateExtentions(List<Entity.PaymentType> entityList)
        {
            List<Entity.PaymentType> retCol = new List<Entity.PaymentType>();

            //populate the list
            foreach (Entity.PaymentType entityObject in entityList)
            {
                retCol.Add(populateExtentions(entityObject));
            }

            return retCol;
        }


        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.PaymentType create(Entity.PaymentType PaymentTypeObject)
        {
            //Call data access.
            Entity.PaymentType ret = DataAccess.daPaymentType.create(PaymentTypeObject);
            return populateExtentions(ret);
        }

        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.PaymentType> retrieve()
        {
            //perform the return

            return populateExtentions(DataAccess.daPaymentType.retrieve());
        }

        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.PaymentType retrieve(long Id)
        {
            //perform the return
            Entity.PaymentType ret = DataAccess.daPaymentType.retrieve(Id);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Code">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.PaymentType retrieve(string Code)
        {
            //perform the return
            Entity.PaymentType ret = DataAccess.daPaymentType.retrieve(Code);
            if (ret == null) return null;
            return populateExtentions(ret);
        }
        /// <summary>Retrieve a single entity by Description.</summary>
        /// <param name="Code">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.PaymentType retrieveByDescription(string description)
        {
            //perform the return
            Entity.PaymentType ret = DataAccess.daPaymentType.retrieveByDesription(description);
            if (ret == null) return null;
            return populateExtentions(ret);
        }
        /// <summary>Retrieve all entities for a combobox.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.PaymentType> retrieveForComboBox()
        {
            //create the list
            List<Entity.PaymentType> ret = retrieve();

            if (ret == null) ret = new List<PhotoStore.Entity.PaymentType>();

            //insert a default - for -1 value
            Entity.PaymentType EmptyRow = new PhotoStore.Entity.PaymentType();
            EmptyRow.Id = -1;
            EmptyRow.Code = "--";
            EmptyRow.Description = "-Select-";

            ret.Insert(0, EmptyRow);

            //perform the return
            return ret;
        }
        /// <summary>Provides an empty combobox</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.PaymentType> retrieveEmptyComboBox()
        {
            //create the list
            List<Entity.PaymentType> ret = new List<PhotoStore.Entity.PaymentType>();

            //insert a default - for -1 value
            Entity.PaymentType EmptyRow = new PhotoStore.Entity.PaymentType();
            EmptyRow.Id = -1;
            EmptyRow.Code = "--";
            EmptyRow.Description = "-Empty-";

            ret.Insert(0, EmptyRow);

            //perform the return
            return ret;
        }
        #endregion

        #region Update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.PaymentType update(Entity.PaymentType PaymentTypeObject)
        {
            //Do business processing here if necessary.
            DataAccess.daPaymentType.update(PaymentTypeObject);

            //get the saved data
            return PaymentTypeObject;
        }

        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static List<Entity.PaymentType> updateList(List<Entity.PaymentType> PaymentTypeList)
        {
            #region update the list
            //look for any removed records and update the existing ones
            List<Entity.PaymentType> oldList = retrieve();
            bool IsRecordExist = false;
            foreach (Entity.PaymentType oldRecord in oldList)
            {
                IsRecordExist = false;
                foreach (Entity.PaymentType newRecord in PaymentTypeList)
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
            foreach (Entity.PaymentType newRecord in PaymentTypeList)
            {
                IsRecordExist = false;
                foreach (Entity.PaymentType oldRecord in oldList)
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
            DataAccess.daPaymentType.delete(Id);
        }
        #endregion
    }
}
