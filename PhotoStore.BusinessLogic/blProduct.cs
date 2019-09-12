using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.BusinessLogic
{
    public class blProduct
    {
        /// <summary>Populate The Product Extention Entities.</summary>
        /// <param name="entityObject">source entity.</param>
        /// <returns>Return the entity object.</returns>
        public static Entity.Product populateExtentions(Entity.Product entityObject)
        {
            return entityObject;
        }

        /// <summary>Populate The Product Extention Entities.</summary>
        /// <param name="entityList">source entity List.</param>
        /// <returns>Return the entity object list.</returns>
        public static List<Entity.Product> populateExtentions(List<Entity.Product> entityList)
        {
            List<Entity.Product> retCol = new List<PhotoStore.Entity.Product>();

            //populate the list
            foreach (Entity.Product entityObject in entityList)
            {
                retCol.Add(populateExtentions(entityObject));
            }

            return retCol;
        }


        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.Product create(Entity.Product ProductObject)
        {
            //Call data access.
            Entity.Product ret = DataAccess.daProduct.create(ProductObject);
            return populateExtentions(ret);
        }

        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.Product> retrieve()
        {
            //perform the return

            return populateExtentions(DataAccess.daProduct.retrieve());
        }

        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.Product retrieve(int Id)
        {
            //perform the return
            Entity.Product ret = DataAccess.daProduct.retrieve(Id);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Code">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.Product retrieve(string Code)
        {
            //perform the return
            Entity.Product ret = DataAccess.daProduct.retrieve(Code);
            if (ret == null) return null;
            return populateExtentions(ret);
        }


        /// <summary>Retrieve all entities for a combobox.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.Product> retrieveForComboBox()
        {
            //create the list
            List<Entity.Product> ret = retrieve();

            if (ret == null) ret = new List<PhotoStore.Entity.Product>();

            //insert a default - for -1 value
            Entity.Product EmptyRow = new PhotoStore.Entity.Product();
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
        public static Entity.Product update(Entity.Product ProductObject)
        {
            //Do business processing here if necessary.
            DataAccess.daProduct.update(ProductObject);

            //get the saved data
            return ProductObject;
        }

        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static List<Entity.Product> updateList(List<Entity.Product> ProductList)
        {
            #region update the list
            //look for any removed records and update the existing ones
            List<Entity.Product> oldList = retrieve();
            bool IsRecordExist = false;
            foreach (Entity.Product oldRecord in oldList)
            {
                IsRecordExist = false;
                foreach (Entity.Product newRecord in ProductList)
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
            foreach (Entity.Product newRecord in ProductList)
            {
                IsRecordExist = false;
                foreach (Entity.Product oldRecord in oldList)
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
            DataAccess.daProduct.delete(Id);
        }
        #endregion
    }
}
