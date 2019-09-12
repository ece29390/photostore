using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.BusinessLogic
{
    public class blCustomer
    {

        /// <summary>Populate The Customer Extention Entities.</summary>
        /// <param name="entityObject">source entity.</param>
        /// <returns>Return the entity object.</returns>
        public static Entity.Customer populateExtentions(Entity.Customer entityObject)
        {
            //when populating an extension make sure that the extension is a child to avoid circular references
            entityObject.CustomerChildList = blCustomerChild.retrieveByCustomerId(entityObject.Id);
            return entityObject;
        }

        /// <summary>Populate The Customer Extention Entities.</summary>
        /// <param name="entityList">source entity List.</param>
        /// <returns>Return the entity object list.</returns>
        public static List<Entity.Customer> populateExtentions(List<Entity.Customer> entityList)
        {
            List<Entity.Customer> retCol = new List<Entity.Customer>();

            //populate the list
            foreach (Entity.Customer entityObject in entityList)
            {
                retCol.Add(populateExtentions(entityObject));
            }

            return retCol;
        }


        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.Customer create(Entity.Customer CustomerObject)
        {
            //Call data access.
            Entity.Customer ret = DataAccess.daCustomer.create(CustomerObject);

            if (ret == null) return null;

            for (int i = 0; i < CustomerObject.CustomerChildList.Count; i++)
            {
                CustomerObject.CustomerChildList[i].CustomerEntity = ret;
            }

            #region create the children
            blCustomerChild.create(CustomerObject.CustomerChildList);
            #endregion
            
            return populateExtentions(ret);
        }

        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.Customer> retrieve()
        {
            //perform the return

            return populateExtentions(DataAccess.daCustomer.retrieve());
        }

        public static List<Entity.Customer> retrieveForComboBox()
        {
            return populateExtentions(DataAccess.daCustomer.retrieveBySQL(
                "SELECT * FROM Customer ORDER BY MothersName ASC"));
        }

        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.Customer retrieve(long Id)
        {
            //perform the return
            Entity.Customer ret = DataAccess.daCustomer.retrieve(Id);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Code">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.Customer retrieve(string Code)
        {
            //perform the return
            Entity.Customer ret = DataAccess.daCustomer.retrieve(Code);
            if (ret == null) return null;
            return populateExtentions(ret);
        }
        
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static List<Entity.Customer> retrieveByEntity(Entity.Customer CustomerObject)
        {
            //return the result set
            return DataAccess.daCustomer.retrieveByEntity(CustomerObject);
        }
        public static bool PriviledgeCardExpired(string priviledgeCard)
        {
            bool retValue = false;
            using (DataSet ds = DataAccess.daCustomer.executeSelect(
                string.Format("SELECT ExpirationDate FROM PrivilegeCard WHERE Code='{0}'",
                priviledgeCard)))
            {
                if (ds != null)
                {
                    DateTime dt = Convert.ToDateTime(ds.Tables[0].Rows[0]["ExpirationDate"]);
                    if (dt < DateTime.Now)
                        retValue = true;

                }
            }
            return retValue;
        }
        /// <summary>Retrieve the next Code.</summary>
        /// <returns>Return the next code.</returns>
        public static string retrieveNextCode()
        {
            //perform the return
            return DataAccess.daCustomer.retrieveNextCode();
        }
        /// <summary>
        /// retrieve the ordertransaction by customer
        /// </summary>
        /// <param name="customerId">record id of the customer</param>
        /// <returns>collection of CustomerOrderTransaction entity</returns>
        public static List<Entity.CustomerOrderTransaction> retrieveOrderByCustomerId(long customerId)
        {
             
            DataSet ds = DataAccess.daCustomer.retrieveOrderByCustomer(customerId);
            List<Entity.CustomerOrderTransaction> retValue = new List<Entity.CustomerOrderTransaction>();
            Dictionary<string, int> idIndex = new Dictionary<string, int>();//this variable holds the id and the index in order to return only one identical record
            if (ds != null)
            {
                int counter=0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (!idIndex.ContainsKey(dr["Code"].ToString()))
                    {
                        
                            idIndex.Add(dr["Code"].ToString(),counter);
                        
                        Entity.CustomerOrderTransaction cot = new PhotoStore.Entity.CustomerOrderTransaction(dr);
                        retValue.Add(cot);
                        cot = null;
                        counter++;
                    }
                    else
                    {
                         //Concat particulars
                        int index=idIndex[dr["Code"].ToString()];
                        retValue[index].Particulars = (dr["Particulars"].ToString().Length == 0) ?
                            retValue[index].Particulars : string.Concat(retValue[index].Particulars, ",", dr["Particulars"].ToString());
                        //Sum the amount in decimal
                        decimal previousAmount = retValue[index].Amount;
                        decimal currentAmount = Convert.ToDecimal(dr["Amount"]);
                        retValue[index].Amount = previousAmount + currentAmount;


                    }   
                }
            }
            return retValue;
        }
        public static List<Entity.Customer> customerForComboBox(bool insertDefaultValue)
        {
            List<Entity.Customer> customers = new List<PhotoStore.Entity.Customer>();
            if (insertDefaultValue)
            {
                Entity.Customer customer=new PhotoStore.Entity.Customer();
                customer.Id=-1;
                customer.MothersName="";
                customers.Add(customer);
                customer = null;
            }
            customers.InsertRange(1, blCustomer.retrieveForComboBox());
            return customers;
        }
        public static List<Entity.PriviledgeCardCombo> getPriviledgedCard(bool insertBlank)
        {
            List<Entity.PriviledgeCardCombo> cards = DataAccess.daCustomer.retrievePriviledgeCard();
            cards.Insert(0, new Entity.PriviledgeCardCombo(-1, "-Please Select-"));
            return cards;
        }
        #endregion

        #region Update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.Customer update(Entity.Customer CustomerObject)
        {
            //Do business processing here if necessary.
            DataAccess.daCustomer.update(CustomerObject);

            #region update the list
            //look for any removed children and update the existing ones
            blCustomerChild.updateListByCustomerId(CustomerObject.Id, CustomerObject.CustomerChildList);

            #endregion
            //get the saved data
            return retrieve(CustomerObject.Id);
        }
        #endregion
    
        #region Delete
        /// <summary>delete an item entry from the database.</summary>
        /// <param name="Id">Item to delete.</param>
        public static void delete(long Id)
        {
            //Do business processing here if necessary.
           
            DataAccess.daCustomer.delete(Id);
        }
        #endregion

        #region Others
        #endregion
    }
}
