using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.DataAccess
{
    public class daParticularType 
    {
        private static string _TableName = "ParticularType";

        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.ParticularType create(Entity.ParticularType itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuParticularType";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "CREATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, DBNull.Value);
            daHelper.addInParameter(sqlCmd, "@Code", SqlDbType.VarChar, itemObject.Code);
            daHelper.addInParameter(sqlCmd, "@Description", SqlDbType.VarChar, itemObject.Description);
            daHelper.addInParameter(sqlCmd, "@MultipleItems", SqlDbType.Bit, itemObject.MultipleItems ? 1 : 0);
            daHelper.addInParameter(sqlCmd, "@IsParent", SqlDbType.Bit, itemObject.IsParent ? 1 : 0);
            daHelper.addInParameter(sqlCmd, "@IsPrintable", SqlDbType.Bit, itemObject.IsPrintable ? 1 : 0);
            //Execute the command
            DataSet ds = daHelper.executeProcedure(sqlCmd);

            return new Entity.ParticularType(ds.Tables[0].Rows[0]);
        }
        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.ParticularType> retrieve()
        {
            DataSet ds = daHelper.executeSelect(string.Concat("Select * from ", _TableName, " WHERE MarkAsDeleted = 0 ORDER BY Description ASC"));

            List<Entity.ParticularType> entityList = new List<PhotoStore.Entity.ParticularType>();
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    entityList.Add(new Entity.ParticularType(dr));
                }
            }
            return entityList;
        }
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.ParticularTypeView> retrieveView()
        {
            DataSet ds = daHelper.executeSelect(string.Concat("Select * from ",_TableName," WHERE MarkAsDeleted = 0"));

            List<Entity.ParticularTypeView> entityList = new List<PhotoStore.Entity.ParticularTypeView>();
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    entityList.Add(new Entity.ParticularTypeView(dr));
                }
            }
            return entityList;
        }
        public static List<Entity.ParticularType> retrieveParticularLessGCCoupon()
        {
            List<Entity.ParticularType> retValue = new List<PhotoStore.Entity.ParticularType>();
            using (DataSet ds = daHelper.executeSelect("SELECT * FROM PARTICULARTYPE WHERE Id NOT IN (3,4,5,10,11,13,14,21,22,23) AND MarkAsDeleted=0 ORDER BY Description ASC"))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Entity.ParticularType particularType = new PhotoStore.Entity.ParticularType(dr);
                        retValue.Add(particularType);
                        particularType = null;
                    }
                }
            }
            return retValue;
        }
        
        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.ParticularType retrieve(long Id)
        {
            DataRow dr = daHelper.executeSelectById(_TableName, Id);
            return new Entity.ParticularType(dr);
        }

        public static Entity.ParticularType retreive<T>(T Id)
        {
            DataRow dr = daHelper.executeSelectById<T>(_TableName, Id);
            return new Entity.ParticularType(dr);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Id">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.ParticularType retrieve(string Code)
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName + " where Code='" + Code + "'");
            if (ds == null) return null;
            DataRowCollection drc = ds.Tables[0].Rows;
            return new Entity.ParticularType(drc[0]);
        }

        public static List<Entity.ParticularType> GetParticularsForSale()
        {
            string gcIdsNotForSaleStr = System.Configuration.ConfigurationManager.AppSettings["gcsnotforsale"].ToString();//Get the ids to be excluded in creating or modifying transaction
            string sqlStatement = "";
            if (string.IsNullOrEmpty(gcIdsNotForSaleStr))
            {
                sqlStatement = string.Format("SELECT * FROM {0} WHERE MarkAsDeleted=0 Order By Description ASC", _TableName);
            }
            else
            {
                sqlStatement = string.Format("SELECT * FROM {0} WHERE Id NOT IN({1}) AND MarkAsDeleted=0 Order By Description ASC",
                    _TableName, gcIdsNotForSaleStr);
                
            }

            List<Entity.ParticularType> particularTypes = new List<PhotoStore.Entity.ParticularType>();

            using (DataSet ds = daHelper.executeSelect(sqlStatement))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Entity.ParticularType particularType = new PhotoStore.Entity.ParticularType(dr);
                        particularTypes.Add(particularType);
                        particularType = null;
                    }
                }
            }


            return particularTypes;
            

        }
        public static List<Entity.ParticularType> GetParticularsForReject(string notinsql)
        {
           
               string sqlStatement = string.Format("SELECT * FROM {0} WHERE Id NOT IN({1})",
                    _TableName, notinsql);

         

            List<Entity.ParticularType> particularTypes = new List<PhotoStore.Entity.ParticularType>();

            using (DataSet ds = daHelper.executeSelect(sqlStatement))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Entity.ParticularType particularType = new PhotoStore.Entity.ParticularType(dr);
                        particularTypes.Add(particularType);
                        particularType = null;
                    }
                }
            }


            return particularTypes;


        }
        public static List<Entity.ParticularType> GetParentGCCouponParticulars()
        {
            //string parentGCCouponIds =
            //    System.Configuration.ConfigurationManager.AppSettings["ParentGCCouponIds"].ToString();
            List<Entity.ParticularType> retValue = new List<PhotoStore.Entity.ParticularType>();
            using (DataSet ds = daHelper.executeSelect(string.Format("SELECT * FROM {0} WHERE IsParent={1}"
                                                                                            ,_TableName
                                                                                            , 1)))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Entity.ParticularType particularType = new PhotoStore.Entity.ParticularType(dr);
                        retValue.Add(particularType);
                        particularType = null;
                    }
                }
            }
            return retValue;
                
        }

        #endregion

        #region update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static void update(Entity.ParticularType itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuParticularType";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "UPDATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, itemObject.Id);
            daHelper.addInParameter(sqlCmd, "@Code", SqlDbType.VarChar, itemObject.Code);
            daHelper.addInParameter(sqlCmd, "@Description", SqlDbType.VarChar, itemObject.Description);
            daHelper.addInParameter(sqlCmd, "@MultipleItems", SqlDbType.Bit, itemObject.MultipleItems ? 1 : 0);
            daHelper.addInParameter(sqlCmd, "@IsParent", SqlDbType.Bit, itemObject.IsParent ? 1 : 0);
            daHelper.addInParameter(sqlCmd, "@IsPrintable", SqlDbType.Bit, itemObject.IsPrintable ? 1 : 0);
            //Execute the command
            daHelper.executeNonQuery(sqlCmd);

        }
        #endregion

        #region delete
        /// <summary>Delete an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static void delete(long Id)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuParticularType";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "DELETE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.Int, Id);

            //Execute the command
            daHelper.executeNonQuery(sqlCmd);

        }
        #endregion
    }
}
