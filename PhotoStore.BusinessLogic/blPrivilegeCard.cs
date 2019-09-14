using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using PhotoStore.Entity;
using PhotoStore.DataAccess;

namespace PhotoStore.BusinessLogic
{
    public class blPrivilegeCard
    {

        /// <summary>Populate The PrivilegeCard Extention Entities.</summary>
        /// <param name="entityObject">source entity.</param>
        /// <returns>Return the entity object.</returns>
        public static Entity.PrivilegeCard populateExtentions(Entity.PrivilegeCard entityObject)
        {
            entityObject.CustomerEntity = DataAccess.daCustomer.retrieve(entityObject.CustomerId);
            return entityObject;
        }

        /// <summary>Populate The PrivilegeCard Extention Entities.</summary>
        /// <param name="entityList">source entity List.</param>
        /// <returns>Return the entity object list.</returns>
        public static List<Entity.PrivilegeCard> populateExtentions(List<Entity.PrivilegeCard> entityList)
        {
            List<Entity.PrivilegeCard> retCol = new List<Entity.PrivilegeCard>();

            //populate the list
            foreach (Entity.PrivilegeCard entityObject in entityList)
            {
                retCol.Add(populateExtentions(entityObject));
            }

            return retCol;
        }

        public static List<PrivilegeCard> retrieveByCardNumber(string searchCode)
        {
            List<PrivilegeCard> retValues = daPrivilegeCard.retrieveLike(searchCode);
            return retValues;
        }


        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.PrivilegeCard create(Entity.PrivilegeCard PrivilegeCardObject)
        {
            //Call data access.
            Entity.PrivilegeCard ret = DataAccess.daPrivilegeCard.create(PrivilegeCardObject);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

       

        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static List<Entity.PrivilegeCard> create(List<Entity.PrivilegeCard> PrivilegeCardList)
        {
            //Call data access.
            foreach (Entity.PrivilegeCard PrivilegeCardObject in PrivilegeCardList)
            {
                create(PrivilegeCardObject);
            }

            return retrieveByCustomerId(PrivilegeCardList[0].CustomerId);
        }

        public static void deactiveCardNumber(long id, long customerId,string cardNumber)
        {
            daPrivilegeCard.delete(id);
            daCustomer.executeNonQuery(new SqlCommand($"UPDATE Customer SET PrivilegeCardCode='' WHERE Id={customerId} AND PrivilegeCardCode='{cardNumber}'"));
        }


        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.PrivilegeCard> retrieve()
        {
            //create the list
            List<Entity.PrivilegeCard> retList = DataAccess.daPrivilegeCard.retrieve();
            if (retList == null) return null;
            return populateExtentions(retList);

        }

        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.PrivilegeCard retrieve(int Id)
        {
            //call the retrieval
            Entity.PrivilegeCard ret = DataAccess.daPrivilegeCard.retrieve(Id);
            if (ret == null) return null;
            return populateExtentions(ret);
        }
        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.PrivilegeCard retrieve(long Id)
        {
            //call the retrieval
            Entity.PrivilegeCard ret = new PhotoStore.Entity.PrivilegeCard(DataAccess.daPrivilegeCard.executeSelectById<long>("PrivilegeCard",Id));              
            if (ret == null) return null;
            return populateExtentions(ret);
        }
        /// <summary>Retrieve a single entity by Code.</summary>
        /// <param name="Id">Entity Code.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.PrivilegeCard retrieve(string Code)
        {
            //call the retrieval
            Entity.PrivilegeCard ret = DataAccess.daPrivilegeCard.retrieve(Code);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve all Active PrivilegeCard via CustomerId.</summary>
        /// <returns>a List of Active PrivilegeCards</returns>
        public static List<Entity.PrivilegeCard> retrieveActiveByCustomerId(long CustomerId)
        {
            //create the list
            List<Entity.PrivilegeCard> retList = DataAccess.daPrivilegeCard.retrieveActiveByCustomerId(CustomerId);
            if (retList == null) return null;
            return populateExtentions(retList);
        }

        /// <summary>Retrieve all PrivilegeCard via CustomerId.</summary>
        /// <returns>a List of PrivilegeCards</returns>
        public static List<Entity.PrivilegeCard> retrieveByCustomerId(long CustomerId)
        {
            //create the list
            List<Entity.PrivilegeCard> retList = DataAccess.daPrivilegeCard.retrieveByCustomerId(CustomerId);
            if (retList == null) return null;
            return populateExtentions(retList);
        }
        /// <summary>Retrieve all PrivilegeCard via CustomerId.</summary>
        /// <param name="CustomerId">primary id of the customer</param>
        /// <param name="code">the priviledge card number</param>
        /// <returns>a List of PrivilegeCards</returns>
        public static Entity.PrivilegeCard retrieveByCustomerIdAndCode(long CustomerId,string code)
        {
            //create the list
            Entity.PrivilegeCard retList = null;
            using (DataSet ds =DataAccess.daHelper.executeSelect(
                string.Format("SELECT * FROM PrivilegeCard WHERE CustomerId={0} AND Code='{1}'",
                CustomerId,code)))
            {
                if (ds != null)
                {
                    retList = new PhotoStore.Entity.PrivilegeCard(ds.Tables[0].Rows[0]);
                }
            }
           
            return populateExtentions(retList);
        }
        #endregion

        #region Update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.PrivilegeCard update(Entity.PrivilegeCard PrivilegeCardObject)
        {
            //Call data access.
            DataAccess.daPrivilegeCard.update(PrivilegeCardObject);

            //get the saved data
            return PrivilegeCardObject;
        }
        /// <summary>Update the details of a particular transaction.</summary>
        /// <param name="CustomerObject">Order Transaction object.</param>
        public static List<Entity.PrivilegeCard> updateListByCustomerId(long CustomerId, List<Entity.PrivilegeCard> PrivilegeCardList)
        {
            //look for any removed details and update the existing ones
            List<Entity.PrivilegeCard> oldItems = retrieveByCustomerId(CustomerId);
            bool IsdetailExist = false;
            foreach (Entity.PrivilegeCard oldItem in oldItems)
            {
                IsdetailExist = false;
                foreach (Entity.PrivilegeCard newItem in PrivilegeCardList)
                {
                    if (newItem.Id == oldItem.Id)
                    {
                        IsdetailExist = true;
                        newItem.CustomerId = CustomerId;
                        newItem.Code = string.Concat(
                            System.Configuration.ConfigurationManager.AppSettings["BranchCode"].ToString(),
                            newItem.Code);
                        update(newItem);
                        break;
                    }
                }
                if (!IsdetailExist) delete(oldItem.Id);
            }

            //create the newly added records
            foreach (Entity.PrivilegeCard newItem in PrivilegeCardList)
            {
                IsdetailExist = false;
                foreach (Entity.PrivilegeCard oldItem in oldItems)
                {
                    if (newItem.Id == oldItem.Id)
                    {
                        IsdetailExist = true;
                        break;
                    }
                }
                if (!IsdetailExist)
                {
                    newItem.CustomerId = CustomerId;
                    newItem.Code = string.Concat(
                           System.Configuration.ConfigurationManager.AppSettings["BranchCode"].ToString(),
                           newItem.Code);
                    create(newItem);
                }
            }

            return retrieveByCustomerId(CustomerId);
        }
        #endregion

        #region Delete
        /// <summary>delete an item entry from the database.</summary>
        /// <param name="CustomerId">Item to delete.</param>
        public static void delete(long CustomerId)
        {
            //Call data access.
            DataAccess.daPrivilegeCard.delete(CustomerId);
        }
        #endregion

        #region Others
        /// <summary>check if the privilege card specified is available</summary>
        /// <param name="PrivilegeCardCode">privilege card number</param>
        /// <returns></returns>
        public static bool isUsed(string PrivilegeCardCode)
        {
            Entity.PrivilegeCard ret = DataAccess.daPrivilegeCard.retrieve(PrivilegeCardCode);
            return (ret != null);
        }
        public static bool isCodeActivelyUsedByCustomer(string code)
        {
            bool retValue = false;
            using (DataSet ds = DataAccess.daCustomer.executeSelect(
                string.Format("SELECT Id FROM Customer WHERE PrivilegeCardCode='{0}'",
                code)))
            {
                if (ds != null)
                    retValue = ds.Tables[0].Rows.Count > 0 ? true : false;
            }
            return retValue;
        }
        /// <summary>check if the privilege card is already expired</summary>
        /// <param name="PrivilegeCardCode">privilege card number</param>
        /// <returns></returns>
        public static bool isExpired(string PrivilegeCardCode)
        {
            Entity.PrivilegeCard ret = DataAccess.daPrivilegeCard.retrieve(PrivilegeCardCode);
            if (ret == null) return false;
            return ret.isExpired;
        }

        /// <summary>check if the privilege card is owned by the specified customer id</summary>
        /// <param name="PrivilegeCardCode">privilege card number</param>
        /// <returns></returns>
        public static bool isOwned(string PrivilegeCardCode, long CustomerId)
        {
            Entity.PrivilegeCard ret = DataAccess.daPrivilegeCard.retrieve(PrivilegeCardCode);
            if (ret == null) return false;
            return (ret.CustomerId==CustomerId);
        }
        public static string RemovePrefix(string branchCode,string code)
        {
            return code.Replace(branchCode, "").Trim();
        }
        public static string AddPrefix(string prefixCode, string rawCode)
        {
            return string.Concat(prefixCode, blUtility.FormatCode(
                rawCode));
        }

        public static void BreakUpPrefixAndCode(ref string actualCode, string[] branchCodes,out string prefixCode)
        {
            prefixCode = "";
            foreach (string branchCode in branchCodes)
            {
                if(actualCode.StartsWith(branchCode))
                {
                    actualCode = RemovePrefix(branchCode, actualCode);
                    prefixCode = branchCode;
                    break;
                }
            }
            if (string.IsNullOrEmpty(prefixCode))
            {
                prefixCode = blUtility.GetSettingValue("BranchCode");
            }
        }
        public static void SetState(System.Windows.Forms.DataGridView gvDataEntry)
        {
            foreach (System.Windows.Forms.DataGridViewRow row in gvDataEntry.Rows)
            {
                //if (row.Cells["colId"].Value == null) continue;
                //if (Convert.ToInt32(row.Cells["colId"].Value) != -1)
                //{
                //    expirationDate = Convert.ToDateTime(row.Cells["colExpirationDate"].Value);
                //    foreach (DataGridViewCell cell in row.Cells)
                //    {
                //        cell.Style.BackColor = Color.LightGray;
                //        cell.ReadOnly = true;

                //    }
                //   // row.Cells["colPrefix"].Value = _branchCode;
                //}
                string code = row.Cells["colCode"].Value.ToString().Trim();
                if (blPrivilegeCard.isCodeActivelyUsedByCustomer(code))
                {
                    foreach (System.Windows.Forms.DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.BackColor =System.Drawing.Color.LightGray;
                        cell.ReadOnly = true;

                    }
                }
                if (row.Selected)
                    row.Selected = false;
            }
        }

        public static bool IsExpired(long customerId, string code)
        {
            bool retValue = false;
            using (DataSet ds = DataAccess.daHelper.executeSelect(
                string.Format("SELECT ExpirationDate FROM PrivilegeCard WHERE CustomerId={0} AND [Code]='{1}'",
                customerId, code)))
            {
                if (ds != null)
                {
                    if (Convert.ToDateTime(ds.Tables[0].Rows[0]["ExpirationDate"]) < DateTime.Now)
                    {
                        retValue = true;
                    }
                }
            }
            return retValue;
        }
        #endregion

    }
}
