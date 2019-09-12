using System;
using System.Collections.Generic;
using System.Text;
using PhotoStore.Entity;
using PhotoStore.DataAccess;

namespace PhotoStore.BusinessLogic
{
    public class blProductList
    {
        public static List<ProductList> retrieveAll()
        {
            return daProductList.retrieve();
        }
        public static List<ProductList> retrieveByParticularTypeId(long particularTypeId)
        {
            return daProductList.retrieveByParticularTypeId(particularTypeId);
        }
        public static ProductList retreiveById(long Id)
        {
            return daProductList.retrieve(Id);
        }
        public static ProductList create(ProductList itemObject)
        {
            return daProductList.create(itemObject);
        }
        public static List<SearchPriceList> retrieve(SearchPriceList itemObject,string mode)
        {
            if (mode == "Search")
                return daProductList.searchPriceList(itemObject);
            else
                return daProductList.searchAllPriceList();
        }
        public static void update(ProductList itemObject)
        {
            daProductList.update(itemObject);
        }
        public static void delete(ProductList itemObject)
        {
            daProductList.delete(itemObject.Id);
        }

        public static List<ProductList> retrieveByIdAndParticularId(long productlistid, long particulartypeid)
        {
            return daProductList.retrieveByWhereStatement(string.Format(
                "WHERE Id={0} AND ParticularType_Id={1}", productlistid, particulartypeid));
        }
        /// <summary>Retrieve all entities for a combobox.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.ProductList> retrieveByParticularIdComboBox(long particulartypeid)
        {
            //create the list
            List<Entity.ProductList> ret = daProductList.retrieveByParticularTypeId(particulartypeid);
            if (ret == null) ret = new List<PhotoStore.Entity.ProductList>();

            //insert a default - for -1 value
            Entity.ProductList EmptyRow = new PhotoStore.Entity.ProductList();
            EmptyRow.Id = -1;           
            EmptyRow.Description = "-Select-";

            ret.Insert(0, EmptyRow);

            //perform the return
            return ret;
        }

        public static List<Entity.ProductList> retrieveByPhotoGCComboBox(bool insertvalue)
        {
            //create the list
            List<Entity.ProductList> ret = daProductList.retrieveByWhereStatement(
                "where particulartype_id IN (3,23)"); 
            if (ret == null) ret = new List<PhotoStore.Entity.ProductList>();
            if (insertvalue)
            {
                //insert a default - for -1 value
                Entity.ProductList EmptyRow = new PhotoStore.Entity.ProductList();
                EmptyRow.Id = -1;
                EmptyRow.Description = "-Select-";
                ret.Insert(0, EmptyRow);
            }



            //perform the return
            return ret;
        }

        public static List<RedemptionGCCoupon> GetRetrieveParentProductId(long childproductid)
        {
            return daProductList.GetParentProductListId(childproductid);
        }
        /// <summary>Retrieve all entities for a combobox.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.ProductList> retrieveByDenominationComboBox(bool insertvalues)
        {
            //create the list
            List<Entity.ProductList> ret = daProductList.retrieveByParticularTypeId(4);
            if (ret == null) ret = new List<PhotoStore.Entity.ProductList>();
            if (insertvalues)
            {
                //insert a default - for -1 value
                Entity.ProductList EmptyRow = new PhotoStore.Entity.ProductList();
                EmptyRow.Id = -1;
                EmptyRow.Description = "-Select-";
                ret.Insert(0, EmptyRow);
            }

           

            //perform the return
            return ret;
        }
        /// <summary>Retrieve all entities for a combobox.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.ProductList> retrieveByCouponComboBox(bool insertvalues)
        {
            //create the list
            List<Entity.ProductList> ret = daProductList.retrieveByParticularTypeId(5);
            if (ret == null) ret = new List<PhotoStore.Entity.ProductList>();
            if (insertvalues)
            {
                //insert a default - for -1 value
                Entity.ProductList EmptyRow = new PhotoStore.Entity.ProductList();
                EmptyRow.Id = -1;
                EmptyRow.Description = "-Select-";
                ret.Insert(0, EmptyRow);
            }



            //perform the return
            return ret;
        }
        public static List<Entity.ProductList> retrieveByDescription(string description)
        {
            List<Entity.ProductList> ret = daProductList.retrieveByWhereStatement(
                string.Format("WHERE Description='{0}' AND MarkAsDeleted=0", description));
            return ret;
        }
        public static List<Entity.ProductList> retrieveByDescriptionAndParticularType(string description, long particulartypeid)
        {
            List<Entity.ProductList> ret = daProductList.retrieveByWhereStatement(
                string.Format("WHERE Description='{0}' AND MarkAsDeleted=0 AND ParticularType_Id={1}", description,particulartypeid));
            return ret;
        }


        public static void SaveRedemptionGCCoupon(long childproductlistid,
            long parentproductlistid)
        {
            daProductList.SaveRedemptionGCCoupon(childproductlistid, parentproductlistid);
        }
    }
}
