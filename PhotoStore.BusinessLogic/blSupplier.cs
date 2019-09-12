using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.BusinessLogic
{
    public class blSupplier
    {
        /// <summary>Populate The Supplier Extention Entities.</summary>
        /// <param name="entityObject">source entity.</param>
        /// <returns>Return the entity object.</returns>
        public static Entity.Supplier populateExtentions(Entity.Supplier entityObject)
        {
            return entityObject;
        }

        /// <summary>Populate The Supplier Extention Entities.</summary>
        /// <param name="entityList">source entity List.</param>
        /// <returns>Return the entity object list.</returns>
        public static List<Entity.Supplier> populateExtentions(List<Entity.Supplier> entityList)
        {
            List<Entity.Supplier> retCol = new List<Entity.Supplier>();

            //populate the list
            foreach (Entity.Supplier entityObject in entityList)
            {
                retCol.Add(populateExtentions(entityObject));
            }

            return retCol;
        }


        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.Supplier create(Entity.Supplier SupplierObject)
        {
            //Call data access.
            Entity.Supplier ret = DataAccess.daSupplier.create(SupplierObject);
            return populateExtentions(ret);
        }

        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.Supplier> retrieve()
        {
            //perform the return

            return populateExtentions(DataAccess.daSupplier.retrieve());
        }

        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.Supplier retrieve(int Id)
        {
            //perform the return
            Entity.Supplier ret = DataAccess.daSupplier.retrieve(Id);
            return populateExtentions(ret);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Code">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.Supplier retrieve(string Code)
        {
            //perform the return
            Entity.Supplier ret = DataAccess.daSupplier.retrieve(Code);
            return populateExtentions(ret);
        }

        /// <summary>Retrieve all entities for a combobox.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.Supplier> retrieveForComboBox()
        {
            //create the list
            List<Entity.Supplier> ret = retrieve();

            if (ret == null) ret = new List<PhotoStore.Entity.Supplier>();

            //insert a default - for -1 value
            Entity.Supplier EmptyRow = new PhotoStore.Entity.Supplier();
            EmptyRow.Id = -1;
            EmptyRow.Code = "-Select-";
            EmptyRow.Description = "-Select-";

            ret.Insert(0, EmptyRow);

            //perform the return
            return ret;
        }
        #endregion

        #region Update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.Supplier update(Entity.Supplier SupplierObject)
        {
            //Do business processing here if necessary.
            DataAccess.daSupplier.update(SupplierObject);

            //get the saved data
            return SupplierObject;
        }

        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static List<Entity.Supplier> updateList(List<Entity.Supplier> SupplierList)
        {
            #region update the list
            //look for any removed records and update the existing ones
            List<Entity.Supplier> oldList = retrieve();
            bool IsRecordExist = false;
            foreach (Entity.Supplier oldRecord in oldList)
            {
                IsRecordExist = false;
                foreach (Entity.Supplier newRecord in SupplierList)
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
            foreach (Entity.Supplier newRecord in SupplierList)
            {
                IsRecordExist = false;
                foreach (Entity.Supplier oldRecord in oldList)
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
            DataAccess.daSupplier.delete(Id);
        }
        #endregion
    }
}
