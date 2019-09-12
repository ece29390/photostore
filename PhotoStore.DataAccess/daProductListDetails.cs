using System;
using System.Collections.Generic;
using System.Text;
using PhotoStore.Entity;
using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.DataAccess
{
    public class daProductListDetails
    {
        static string _TableName = "ProductListDetails";
        public static List<ProductListDetails> retreiveByProductListId(long Id)
        {
            List<ProductListDetails> retValue = new List<ProductListDetails>();

            using (DataSet ds = daHelper.executeSelect(string.Format(
                "SELECT * FROM {0} WHERE ProductList_Id={1} AND MarkAsDeleted=0",
                _TableName, Id)))
            {

                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        retValue.Add(new ProductListDetails(dr));
                    }
                }
            }
            return retValue;
        }
        public static ProductListDetails retrieve(long Id)
        {
            DataRow dr = daHelper.executeSelectById<long>(_TableName, Id);
            return new ProductListDetails(dr);
        }
        public static List<ProductListDetails> retrieveByWhereStatement(string wherestatement)
        {
            List<ProductListDetails> retValues = new List<ProductListDetails>();
            using (DataSet ds = daHelper.executeSelect(string.Format("SELECT * FROM {0} {1}",
                                                            _TableName
                                                            , wherestatement)))
            {
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ProductListDetails productListDetail = new ProductListDetails(dr);
                        retValues.Add(productListDetail);
                        productListDetail = null;
                    }
                }
            }
            return retValues;
        }
    
    

        public static ProductListDetails create(ProductListDetails itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuProductListDetails";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;

            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "CREATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, DBNull.Value);
            daHelper.addInParameter(sqlCmd, "@ProductList_Id", SqlDbType.BigInt, itemObject.ProductList_Id);
            daHelper.addInParameter(sqlCmd, "@Quantity", SqlDbType.Int, itemObject.Quantity);
            daHelper.addInParameter(sqlCmd, "@Particulars", SqlDbType.NVarChar, itemObject.Particulars);
           // daHelper.addInParameter(sqlCmd, "@UnitPrice", SqlDbType.Decimal, itemObject.UnitPrice);
            



            //Execute the command
            DataSet ds = daHelper.executeProcedure(sqlCmd);

            return new ProductListDetails(ds.Tables[0].Rows[0]);
        }
        public static void update(ProductListDetails itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuProductListDetails";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;

            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "UPDATE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, itemObject.Id);
            daHelper.addInParameter(sqlCmd, "@ProductList_Id", SqlDbType.BigInt, itemObject.ProductList_Id);
            daHelper.addInParameter(sqlCmd, "@Quantity", SqlDbType.Int, itemObject.Quantity);
            daHelper.addInParameter(sqlCmd, "@Particulars", SqlDbType.NVarChar, itemObject.Particulars);
           // daHelper.addInParameter(sqlCmd, "@UnitPrice", SqlDbType.Decimal, itemObject.UnitPrice);

            //Execute the command
            daHelper.executeProcedure(sqlCmd);

        }
        public static void delete(ProductListDetails itemObject)
        {
            //Initialize command.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "spuProductListDetails";
            sqlCmd.CommandTimeout = daHelper.commandTimeout;

            //Initialize sql database and assign parameters;

            daHelper.addInParameter(sqlCmd, "@Mode", SqlDbType.VarChar, "DELETE");
            daHelper.addInParameter(sqlCmd, "@Id", SqlDbType.BigInt, itemObject.Id);
            
            //Execute the command
            daHelper.executeProcedure(sqlCmd);
        }


    }
}
