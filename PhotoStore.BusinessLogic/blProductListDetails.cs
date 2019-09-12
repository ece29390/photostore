using System;
using System.Collections.Generic;
using System.Text;
using PhotoStore.DataAccess;
using PhotoStore.Entity;
namespace PhotoStore.BusinessLogic
{
    public class blProductListDetails
    {

        public static List<ProductListDetails> retrieveByProductListId(long id)
        {
            return daProductListDetails.retreiveByProductListId(id);
        }
        public static ProductListDetails retreiveById(long Id)
        {
            return daProductListDetails.retrieve(Id);
        }
        public static ProductListDetails create(ProductListDetails itemObject)
        {
            return daProductListDetails.create(itemObject);
        }

        public static void update(ProductListDetails itemObject)
        {
            daProductListDetails.update(itemObject);
        }
        public static void delete(ProductListDetails itemObject)
        {
            daProductListDetails.delete(itemObject);
        }

        public static List<ProductListDetails> retrieveByDescription(string particulars)
        {
            return daProductListDetails.retrieveByWhereStatement(string.Format("WHERE Particulars='{0}'",
                                                    particulars));
        }
    }
}
