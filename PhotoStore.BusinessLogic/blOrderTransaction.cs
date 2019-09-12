using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
namespace PhotoStore.BusinessLogic
{
    public class blOrderTransaction
    {
        /// <summary>Populate The OrderTransaction Extention Entities.</summary>
        /// <param name="entityObject">source entity.</param>
        /// <returns>Return the entity object.</returns>
        public  static Entity.OrderTransaction populateExtentions(Entity.OrderTransaction entityObject)
        {
            //when populating an extension make sure that the extension is a child to avoid circular references

            entityObject.CustomerEntity = DataAccess.daCustomer.retrieve(entityObject.CustomerId);

            entityObject.PreparedByEmployeeEntity = DataAccess.daEmployee.retrieve(entityObject.PreparedByEmployeeId);

            entityObject.OrderStatusEntity = DataAccess.daOrderStatus.retrieve(entityObject.OrderStatusId);

            entityObject.OrderTransactionDetailList = DataAccess.daOrderTransactionDetail.retrieveByOrderTransactionId(entityObject.Id);

            entityObject.OrderTransactionPaymentList = DataAccess.daOrderTransactionPayment.retrieveByOrderTransactionId(entityObject.Id);

            entityObject.OrderTransactionModifiedByList = blOrderTransactionModifiedBy.retrieveByOrderTransactionId(entityObject.Id);
            return entityObject;
        }

        /// <summary>Populate The OrderTransaction Extention Entities.</summary>
        /// <param name="entityList">source entity List.</param>
        /// <returns>Return the entity object list.</returns>
        public  static List<Entity.OrderTransaction> populateExtentions(List<Entity.OrderTransaction> entityList)
        {
            List<Entity.OrderTransaction> retCol = new List<Entity.OrderTransaction>();

            //populate the list
            foreach (Entity.OrderTransaction entityObject in entityList)
            {
                retCol.Add(populateExtentions(entityObject));
            }

            return retCol;
        }


        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.OrderTransaction create(Entity.OrderTransaction OrderTransactionObject)
        {
            //Call data access.
            Entity.OrderTransaction ret = DataAccess.daOrderTransaction.create(OrderTransactionObject);

            if (ret == null) return null;

            #region create the children
            foreach (Entity.OrderTransactionDetail entityObject in OrderTransactionObject.OrderTransactionDetailList)
            {
                entityObject.OrderTransactionId = ret.Id;
               
            }
            
            blOrderTransactionDetail.create(OrderTransactionObject.OrderTransactionDetailList);
            foreach (Entity.OrderTransactionPayment entityObject in OrderTransactionObject.OrderTransactionPaymentList)
            {
                entityObject.OrderTransactionId = ret.Id;
            }

            blOrderTransactionPayment.create(OrderTransactionObject.OrderTransactionPaymentList);
            foreach (Entity.OrderTransactionModifiedBy entityObject in OrderTransactionObject.OrderTransactionModifiedByList)
            {
                entityObject.OrderTransactionId = ret.Id;
            }
            blOrderTransactionModifiedBy.create(OrderTransactionObject.OrderTransactionModifiedByList);
            #endregion

            return populateExtentions(ret);
        }

        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.OrderTransaction> retrieve()
        {
            //create the list
            List<Entity.OrderTransaction> retList = DataAccess.daOrderTransaction.retrieve();
            if (retList == null) return null;
            return populateExtentions(retList);

        }

        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.OrderTransaction retrieve(long Id)
        {
            //call the retrieval
            Entity.OrderTransaction ret = DataAccess.daOrderTransaction.retrieve(Id);
            if (ret == null) return null;
            return populateExtentions(ret);

        }

        public static Entity.OrderTransaction retrieveByRejectCode(string refcode)
        {
            Entity.OrderTransaction ret = DataAccess.daOrderTransaction.GetRejectedTransaction(refcode);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve a single entity by Name.</summary>
        /// <param name="Code">Entity Name.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.OrderTransaction retrieve(string Code)
        {
            //create the data layer
            Entity.OrderTransaction ret = DataAccess.daOrderTransaction.retrieve(Code);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve the next Code.</summary>
        /// <returns>Return the next code.</returns>
        public static string retrieveNextCode()
        {
            //call the retrieval
            string ret = DataAccess.daOrderTransaction.retrieveNextCode();
            return ret;
        }

        public static List<PhotoStore.Entity.OrderTransaction> retrieveSearchTransaction(
            string ordernumber,
            string priviledgecardcode
            , string fathername
            , string mothername
            , string address)
        {
            return DataAccess.daOrderTransaction.GetOrderTransaction(
                ordernumber, priviledgecardcode, fathername, mothername, address);
        }
        public static List<PhotoStore.Entity.OrderTransactionView> retrieveSearchTransactionView(
            string ordernumber,
            string priviledgecardcode
            , string fathername
            , string mothername
            , string address
            ,DateTime? dtFrom
            ,DateTime? dtTo
             , string sortedcolumn
             , ListSortDirection sortdirection)
        {
            List<PhotoStore.Entity.OrderTransactionView> orderTransactionViews = DataAccess.daOrderTransaction.GetOrderTransactionView(
                ordernumber, priviledgecardcode, fathername, mothername, address,dtFrom,dtTo,sortedcolumn,sortdirection);
            foreach (PhotoStore.Entity.OrderTransactionView orderTransactionView in orderTransactionViews)
            {
                orderTransactionView.CustomerEntity = DataAccess.daCustomer.retrieve(orderTransactionView.CustomerId);
            }
            return orderTransactionViews;
        }
        #endregion

        #region Update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.OrderTransaction update(Entity.OrderTransaction OrderTransactionObject)
        {
            //Do business processing here if necessary.

            //Call data access.
            DataAccess.daOrderTransaction.update(OrderTransactionObject);

            #region update the child lists
            BusinessLogic.blOrderTransactionDetail.updateListByOrderTransactionId(OrderTransactionObject.Id, OrderTransactionObject.OrderTransactionDetailList);
            BusinessLogic.blOrderTransactionPayment.updateListByOrderTransactionId(OrderTransactionObject.Id, OrderTransactionObject.OrderTransactionPaymentList);
            BusinessLogic.blOrderTransactionModifiedBy.updateListByOrderTransactionId(OrderTransactionObject.Id, OrderTransactionObject.OrderTransactionModifiedByList);
            #endregion


            //get the saved data
            return retrieve(OrderTransactionObject.Id);
        }

       
        

        #endregion

        #region Delete
        /// <summary>delete an item entry from the database.</summary>
        /// <param name="OrderTransactionId">Item to delete.</param>
        public static void delete(int OrderTransactionId)
        {
            //Do business processing here if necessary.

            //Call data access.
            DataAccess.daOrderTransaction.delete(OrderTransactionId);
        }
        #endregion

        #region Others
        /// <summary>Revise a cancelled transaction.</summary>
        /// <param name="OrderTransactionId"></param>
        /// <returns></returns>
        public static long revise(long OrderTransactionId)
        {
            //create the item
            return DataAccess.daOrderTransaction.revise(OrderTransactionId);

        }

        /// <summary>Reject a cancelled transaction.</summary>
        /// <param name="OrderTransactionId"></param>
        /// <returns></returns>
        public static int rejectOrder(long OrderTransactionId)
        {
            //create the item
            return DataAccess.daOrderTransaction.rejectOrder(OrderTransactionId);

        }
        #endregion
    }
}
