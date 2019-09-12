using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.BusinessLogic
{
    public class blParticularType
    {
        /// <summary>Populate The ParticularType Extention Entities.</summary>
        /// <param name="entityObject">source entity.</param>
        /// <returns>Return the entity object.</returns>
        public static Entity.ParticularType populateExtentions(Entity.ParticularType entityObject)
        {
            return entityObject;
        }

        /// <summary>Populate The ParticularType Extention Entities.</summary>
        /// <param name="entityList">source entity List.</param>
        /// <returns>Return the entity object list.</returns>
        public static List<Entity.ParticularType> populateExtentions(List<Entity.ParticularType> entityList)
        {
            List<Entity.ParticularType> retCol = new List<Entity.ParticularType>();

            //populate the list
            foreach (Entity.ParticularType entityObject in entityList)
            {
                retCol.Add(populateExtentions(entityObject));
            }

            return retCol;
        }


        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.ParticularType create(Entity.ParticularType ParticularTypeObject)
        {
            //Call data access.
            Entity.ParticularType ret = DataAccess.daParticularType.create(ParticularTypeObject);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.ParticularType> retrieve()
        {
            //perform the return

            return populateExtentions(DataAccess.daParticularType.retrieve());
        }
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.ParticularTypeView> retrieveView()
        {
            //perform the return

            return DataAccess.daParticularType.retrieveView();
        }

        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.ParticularType retrieve(long Id)
        {
            //perform the return
            Entity.ParticularType ret = DataAccess.daParticularType.retrieve(Id);
            if (ret == null) return null;
            return populateExtentions(ret);
        }
        public static List<Entity.ParticularType> retrieveParticularLessGCCoupon()
        {
            return DataAccess.daParticularType.retrieveParticularLessGCCoupon();
        }
    
        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Code">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.ParticularType retrieve(string Code)
        {
            //perform the return
            Entity.ParticularType ret = DataAccess.daParticularType.retrieve(Code);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve all entities for a combobox.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.ParticularType> retrieveForComboBox()
        {
            //create the list
            List<Entity.ParticularType> ret = retrieve();

            if (ret == null) ret = new List<PhotoStore.Entity.ParticularType>();

            //insert a default - for -1 value
            Entity.ParticularType EmptyRow= new PhotoStore.Entity.ParticularType();
            EmptyRow.Id=-1;
            EmptyRow.Code="--";
            EmptyRow.Description="-Select-";

            ret.Insert(0, EmptyRow);

            //perform the return
            return ret;
        }
        public static List<Entity.ParticularType> retrieveAllForTransaction()
        {
            return DataAccess.daParticularType.GetParticularsForSale();
        }

        public static List<Entity.ParticularType> retrieveAllForReject()
        {
            string[] items = System.Configuration.ConfigurationManager.AppSettings["rejectidsnotincluded"].ToString().Split(
                new char[1] { ',' });
            string notInSql="";
            StringBuilder sb = new StringBuilder();
            foreach (string item in items)
            {
                //if (string.IsNullOrEmpty(sb.ToString()))
                //    sb.Append("(");

                sb.Append(string.Concat(item, ','));

                
            }
            notInSql = sb.ToString();
            notInSql = notInSql.Remove(notInSql.LastIndexOf(','), 1);
            return DataAccess.daParticularType.GetParticularsForReject(notInSql);
        }
        /// <summary>Provides an empty combobox</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.ParticularType> retrieveEmptyComboBox()
        {
            //create the list
            List<Entity.ParticularType> ret =new List<PhotoStore.Entity.ParticularType>();

            //insert a default - for -1 value
            Entity.ParticularType EmptyRow = new PhotoStore.Entity.ParticularType();
            EmptyRow.Id = -1;
            EmptyRow.Code = "--";
            EmptyRow.Description = "-Empty-";

            ret.Insert(0, EmptyRow);

            //perform the return
            return ret;
        }

        public static List<Entity.ParticularType> retrieveParentGCCoupon()
        {
            return DataAccess.daParticularType.GetParentGCCouponParticulars();
        }
        #endregion

        #region Update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.ParticularType update(Entity.ParticularType ParticularTypeObject)
        {
            //Do business processing here if necessary.
            DataAccess.daParticularType.update(ParticularTypeObject);

            //get the saved data
            return ParticularTypeObject;
        }

        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static List<Entity.ParticularType> updateList(List<Entity.ParticularType> ParticularTypeList)
        {
            #region update the list
            //look for any removed records and update the existing ones
            List<Entity.ParticularType> oldList = retrieve();
            bool IsRecordExist = false;
            foreach (Entity.ParticularType oldRecord in oldList)
            {
                IsRecordExist = false;
                foreach (Entity.ParticularType newRecord in ParticularTypeList)
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
            foreach (Entity.ParticularType newRecord in ParticularTypeList)
            {
                IsRecordExist = false;
                foreach (Entity.ParticularType oldRecord in oldList)
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
            DataAccess.daParticularType.delete(Id);
        }
        #endregion
    }
}
