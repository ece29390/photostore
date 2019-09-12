using System;
using System.Collections.Generic;
using System.Text;
using PhotoStore.Entity;
using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.DataAccess
{
    public class daProductList
    {
        private static string _TableName = "ProductList";

        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static ProductList create(ProductList itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuProductList";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;
           
            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "CREATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, DBNull.Value);
            daHelper.addInParameter(sqlCmd, "@Description", SqlDbType.VarChar, itemObject.Description);
            daHelper.addInParameter(sqlCmd, "@ParticularType_Id", SqlDbType.BigInt, itemObject.ParticularTypeId);
            daHelper.addInParameter(sqlCmd, "@Created_Employee_Id", SqlDbType.BigInt, itemObject.CreatedEmployeeId);
            daHelper.addInParameter(sqlCmd, "@Modified_Employee_Id", SqlDbType.BigInt, DBNull.Value);
            daHelper.addInParameter(sqlCmd, "@IsPackage", SqlDbType.Bit, itemObject.IsPackage);
            daHelper.addInParameter(sqlCmd, "@UnitPrice", SqlDbType.Money, itemObject.UnitPrice);


            //Execute the command
            DataSet ds = daHelper.executeProcedure(sqlCmd);

            return new ProductList(ds.Tables[0].Rows[0]);
        }
        #endregion

        #region Retrieve
        public static List<ProductList> retrieveByWhereStatement(string wherestatement)
        {
            List<ProductList> productLists = new List<ProductList>();
            using (DataSet ds = daHelper.executeSelect(string.Format("SELECT * FROM {0} {1}",
                _TableName, wherestatement)))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ProductList productList = new ProductList(dr);
                        productList.ProductListDetails = daProductListDetails.retreiveByProductListId(productList.Id);
                        productLists.Add(productList);
                        productList = null;
                    }
                }
            }
            return productLists;
        }
        public static List<ProductList> retrieveByParticularTypeId(long particulartypeid)
        {
            List<ProductList> productLists = new List<ProductList>();
            using (DataSet ds = daHelper.executeSelect(string.Format("SELECT * FROM {0} WHERE ParticularType_Id={1} AND MarkAsDeleted=0 Order By Description ASC",
                _TableName, particulartypeid)))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ProductList productList = new ProductList(dr);
                        productLists.Add(productList);
                        productList = null;
                    }
                }
            }
            return productLists;

        }
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<ProductList> retrieve()
        {
            DataSet ds = daHelper.executeSelect("Select * from " + _TableName);

            List<ProductList> entityList = new List<ProductList>();

            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ProductList pl = new ProductList(dr);
                    //pl.ProductType = daParticularType.retreive<long>(pl.ParticularTypeId);
                    //using (DataSet dsChild = daHelper.executeSelect(string.Format(
                    //    "SELECT * FROM ProductListDetails WHERE Id={0}", pl.Id)))
                    //{
                    //    if (dsChild != null)
                    //    {
                    //        foreach (DataRow dr in dsChild.Tables[0].Rows)
                    //        {
                    //            ProductListDetails pld = new ProductListDetails(dr);
                    //            pl.
                    //        }
                    //    }
                    //}
                    entityList.Add(pl);
                    
                    pl = null;

                }
            }

            return entityList;
        }

        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.ProductList retrieve(long Id)
        {
            DataRow dr = daHelper.executeSelectById<long>(_TableName, Id);
            ProductList pl = new ProductList(dr);
            pl.ProductType = daParticularType.retreive<long>(pl.ParticularTypeId);
            pl.ProductListDetails = daProductListDetails.retreiveByProductListId(pl.Id);
            return pl;
        }
        public static List<SearchPriceList> searchAllPriceList()
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuProductList";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;

            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "SEARCHALL");
            
            //Execute the command
            List<SearchPriceList> searchPriceLists = new List<SearchPriceList>();
            using (DataSet ds = daHelper.executeProcedure(sqlCmd))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        searchPriceLists.Add(new SearchPriceList(dr));
                    }
                }
            }

            return searchPriceLists;
        }
        public static List<SearchPriceList> searchPriceList(SearchPriceList itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuProductList";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;
            
            //Initialize sql database and assign parameters;

            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "CATEGORICALSEARCH");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, DBNull.Value);
            if(!string.IsNullOrEmpty(itemObject.ProductName))
                daHelper.addInParameter(sqlCmd, "@Description", SqlDbType.VarChar, itemObject.ProductName);
            if(itemObject.ParticularType_Id>-1)
                daHelper.addInParameter(sqlCmd, "@ParticularType_Id", SqlDbType.BigInt, itemObject.ParticularType_Id);
           
            //Execute the command
            List<SearchPriceList> searchPriceLists = new List<SearchPriceList>();
            using (DataSet ds = daHelper.executeProcedure(sqlCmd))
            {
                if (ds != null)
                {
                    //Dictionary<object, string> idItems = new Dictionary<object, string>();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                       
                            searchPriceLists.Add(new SearchPriceList(dr));
                      
                        
                        
                    }
                  
                }
            }
           
            return searchPriceLists;
        }


        #endregion

        #region update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static void update(ProductList itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuProductList";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;

            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "UPDATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, itemObject.Id);
            daHelper.addInParameter(sqlCmd, "@Description", SqlDbType.VarChar, itemObject.Description);
            daHelper.addInParameter(sqlCmd, "@ParticularType_Id", SqlDbType.BigInt, itemObject.ParticularTypeId);
            daHelper.addInParameter(sqlCmd, "@Created_Employee_Id", SqlDbType.BigInt, DBNull.Value);
            daHelper.addInParameter(sqlCmd, "@Modified_Employee_Id", SqlDbType.BigInt,itemObject.ModifiedEmployeeId);
            daHelper.addInParameter(sqlCmd, "@IsPackage", SqlDbType.Bit, itemObject.IsPackage);
            daHelper.addInParameter(sqlCmd, "@UnitPrice", SqlDbType.Money, itemObject.UnitPrice);


            daHelper.executeProcedure(sqlCmd);

           

        }

        public static List<RedemptionGCCoupon> GetParentProductListId(long childproductlistid)
        {
            List<RedemptionGCCoupon> retValue = new List<RedemptionGCCoupon>();
            using (DataSet ds = daHelper.executeSelect(
                string.Format("SELECT * FROM RedemptionGCCoupon WHERE ProductListId={0}"
                                , childproductlistid)))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        RedemptionGCCoupon redemptionCoupon = new RedemptionGCCoupon(dr);
                        retValue.Add(redemptionCoupon);
                        redemptionCoupon = null;
                    }
                }
            }
            return retValue;
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
            sqlCmd.CommandText = "spuProductList";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;

            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "DELETE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, Id);
           



            daHelper.executeProcedure(sqlCmd);

        }
        #endregion

        public static void SaveRedemptionGCCoupon(long childproductlistid,
            long parentproductlistid)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText="spRedemptionGCCoupon";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            daHelper.addInParameter(sqlCmd, "@CHILDPRODUCTLISTID", SqlDbType.BigInt, childproductlistid);
            daHelper.addInParameter(sqlCmd, "@PARENTPRODUCTLISTID", SqlDbType.BigInt, parentproductlistid);
            daHelper.executeProcedure(sqlCmd);
        }

    
    }
}
