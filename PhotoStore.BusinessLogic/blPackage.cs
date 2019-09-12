using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.BusinessLogic
{
    public class blPackage
    {
        /// <summary>Populate The Package Extention Entities.</summary>
        /// <param name="entityObject">source entity.</param>
        /// <returns>Return the entity object.</returns>
        public static Entity.Package populateExtentions(Entity.Package entityObject)
        {
            return entityObject;
        }

        /// <summary>Populate The Package Extention Entities.</summary>
        /// <param name="entityList">source entity List.</param>
        /// <returns>Return the entity object list.</returns>
        public static List<Entity.Package> populateExtentions(List<Entity.Package> entityList)
        {
            List<Entity.Package> retCol = new List<Entity.Package>();

            //populate the list
            foreach (Entity.Package entityObject in entityList)
            {
                retCol.Add(populateExtentions(entityObject));
            }

            return retCol;
        }


        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.Package create(Entity.Package PackageObject)
        {
            //Call data access.
            Entity.Package ret = DataAccess.daPackage.create(PackageObject);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.Package> retrieve()
        {
            //perform the return

            return populateExtentions(DataAccess.daPackage.retrieve());
        }

        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.Package retrieve(int Id)
        {
            //perform the return
            Entity.Package ret = DataAccess.daPackage.retrieve(Id);
            return populateExtentions(ret);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Code">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.Package retrieve(string Code)
        {
            //perform the return
            Entity.Package ret = DataAccess.daPackage.retrieve(Code);
            return populateExtentions(ret);
        }

        /// <summary>Retrieve all entities for a combobox.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.Package> retrieveForComboBox()
        {
            //create the list
            List<Entity.Package> ret = retrieve();

            if (ret == null) ret = new List<PhotoStore.Entity.Package>();

            //insert a default - for -1 value
            Entity.Package EmptyRow = new PhotoStore.Entity.Package();
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
        public static Entity.Package update(Entity.Package PackageObject)
        {
            //Do business processing here if necessary.
            DataAccess.daPackage.update(PackageObject);

            //get the saved data
            return PackageObject;
        }

        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static List<Entity.Package> updateList(List<Entity.Package> PackageList)
        {
            #region update the list
            //look for any removed records and update the existing ones
            List<Entity.Package> oldList = retrieve();
            bool IsRecordExist = false;
            foreach (Entity.Package oldRecord in oldList)
            {
                IsRecordExist = false;
                foreach (Entity.Package newRecord in PackageList)
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
            foreach (Entity.Package newRecord in PackageList)
            {
                IsRecordExist = false;
                foreach (Entity.Package oldRecord in oldList)
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
            DataAccess.daPackage.delete(Id);
        }
        #endregion
    }
}
