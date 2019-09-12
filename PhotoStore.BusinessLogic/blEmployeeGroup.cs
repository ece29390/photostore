using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.BusinessLogic
{
    public class blEmployeeGroup
    {
        /// <summary>Populate The EmployeeGroup Extention Entities.</summary>
        /// <param name="entityObject">source entity.</param>
        /// <returns>Return the entity object.</returns>
        public static Entity.EmployeeGroup populateExtentions(Entity.EmployeeGroup entityObject)
        {
            return entityObject;
        }

        /// <summary>Populate The EmployeeGroup Extention Entities.</summary>
        /// <param name="entityList">source entity List.</param>
        /// <returns>Return the entity object list.</returns>
        public static List<Entity.EmployeeGroup> populateExtentions(List<Entity.EmployeeGroup> entityList)
        {
            List<Entity.EmployeeGroup> retCol = new List<Entity.EmployeeGroup>();

            //populate the list
            foreach (Entity.EmployeeGroup entityObject in entityList)
            {
                retCol.Add(populateExtentions(entityObject));
            }

            return retCol;
        }


        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.EmployeeGroup create(Entity.EmployeeGroup EmployeeGroupObject)
        {
            //Call data access.
            Entity.EmployeeGroup ret = DataAccess.daEmployeeGroup.create(EmployeeGroupObject);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.EmployeeGroup> retrieve()
        {
            //perform the return
            return populateExtentions(DataAccess.daEmployeeGroup.retrieve());
        }

        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.EmployeeGroup retrieve(int Id)
        {
            //perform the return
            Entity.EmployeeGroup ret = DataAccess.daEmployeeGroup.retrieve(Id);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Code">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.EmployeeGroup retrieve(string Code)
        {
            //perform the return
            Entity.EmployeeGroup ret = DataAccess.daEmployeeGroup.retrieve(Code);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve all entities for a combobox.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.EmployeeGroup> retrieveForComboBox(bool insertdefault)
        {
            //create the list
            List<Entity.EmployeeGroup> ret = retrieve();

            if (ret == null) ret = new List<PhotoStore.Entity.EmployeeGroup>();

            if (insertdefault)
            {
                //insert a default - for -1 value
                Entity.EmployeeGroup EmptyRow = new PhotoStore.Entity.EmployeeGroup();
                EmptyRow.Id = -1;
                EmptyRow.Code = "--";
                EmptyRow.Description = "-Select-";

                ret.Insert(0, EmptyRow);
            }

            //perform the return
            return ret;
        }
        /// <summary>Provides an empty combobox</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.EmployeeGroup> retrieveEmptyComboBox()
        {
            //create the list
            List<Entity.EmployeeGroup> ret = new List<PhotoStore.Entity.EmployeeGroup>();

            //insert a default - for -1 value
            Entity.EmployeeGroup EmptyRow = new PhotoStore.Entity.EmployeeGroup();
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
        public static Entity.EmployeeGroup update(Entity.EmployeeGroup EmployeeGroupObject)
        {
            //Do business processing here if necessary.
            DataAccess.daEmployeeGroup.update(EmployeeGroupObject);

            //get the saved data
            return EmployeeGroupObject;
        }

        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static List<Entity.EmployeeGroup> updateList(List<Entity.EmployeeGroup> EmployeeGroupList)
        {
            #region update the list
            //look for any removed records and update the existing ones
            List<Entity.EmployeeGroup> oldList = retrieve();
            bool IsRecordExist = false;
            foreach (Entity.EmployeeGroup oldRecord in oldList)
            {
                IsRecordExist = false;
                foreach (Entity.EmployeeGroup newRecord in EmployeeGroupList)
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
            foreach (Entity.EmployeeGroup newRecord in EmployeeGroupList)
            {
                IsRecordExist = false;
                foreach (Entity.EmployeeGroup oldRecord in oldList)
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
            DataAccess.daEmployeeGroup.delete(Id);
        }
        #endregion
    }
}
