using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.BusinessLogic
{
    public class blEmployee
    {
        /// <summary>Populate The Employee Extention Entities.</summary>
        /// <param name="entityObject">source entity.</param>
        /// <returns>Return the entity object.</returns>
        public static Entity.Employee populateExtentions(Entity.Employee entityObject)
        {
            entityObject.EmployeeGroup = DataAccess.daEmployeeGroup.retrieve(entityObject.EmployeeGroupId);
            return entityObject;
        }

        /// <summary>Populate The Employee Extention Entities.</summary>
        /// <param name="entityList">source entity List.</param>
        /// <returns>Return the entity object list.</returns>
        public static List<Entity.Employee> populateExtentions(List<Entity.Employee> entityList)
        {
            List<Entity.Employee> retCol = new List<Entity.Employee>();

            //populate the list
            foreach (Entity.Employee entityObject in entityList)
            {
                retCol.Add(populateExtentions(entityObject));
            }

            return retCol;
        }


        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.Employee create(Entity.Employee EmployeeObject)
        {
            //Call data access.
            Entity.Employee ret = DataAccess.daEmployee.create(EmployeeObject);
            return populateExtentions(ret);
        }

        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.Employee> retrieve()
        {
            //perform the return
            return populateExtentions(DataAccess.daEmployee.retrieve());
        }

        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.Employee retrieve(int Id)
        {
            //perform the return
            Entity.Employee ret = DataAccess.daEmployee.retrieve(Id);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Code">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.Employee retrieve(string UserName)
        {
            //perform the return
            Entity.Employee ret = DataAccess.daEmployee.retrieve(UserName);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        
        #endregion
        
        #region Update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.Employee update(Entity.Employee EmployeeObject)
        {
            //Do business processing here if necessary.
            DataAccess.daEmployee.update(EmployeeObject);

            //get the saved data
            return EmployeeObject;
        }
        public static void SaveEmployee(Entity.Employee employee)
        {
            if (employee.Id > 0)
            {
                DataAccess.daEmployee.update(employee);
            }
            else
            {
                DataAccess.daEmployee.create(employee);
            }
        }
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static List<Entity.Employee> updateList(List<Entity.Employee> EmployeeList)
        {
            #region update the list
            //look for any removed records and update the existing ones
            List<Entity.Employee> oldList = retrieve();
            bool IsRecordExist = false;
            foreach (Entity.Employee oldRecord in oldList)
            {
                IsRecordExist = false;
                foreach (Entity.Employee newRecord in EmployeeList)
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
            foreach (Entity.Employee newRecord in EmployeeList)
            {
                IsRecordExist = false;
                foreach (Entity.Employee oldRecord in oldList)
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
            DataAccess.daEmployee.delete(Id);
        }
        #endregion
    }
}
