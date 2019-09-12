using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace PhotoStore.BusinessLogic
{
    public class blOrderTransactionDetail
    {
        /// <summary>Populate The OrderTransactionDetail Extention Entities.</summary>
        /// <param name="entityObject">source entity.</param>
        /// <returns>Return the entity object.</returns>
        public static Entity.OrderTransactionDetail populateExtentions(Entity.OrderTransactionDetail entityObject)
        {
            entityObject.OrderTransactionEntity = DataAccess.daOrderTransaction.retrieve(entityObject.OrderTransactionId);
            return entityObject;
        }

        /// <summary>Populate The OrderTransactionDetail Extention Entities.</summary>
        /// <param name="entityList">source entity List.</param>
        /// <returns>Return the entity object list.</returns>
        public static List<Entity.OrderTransactionDetail> populateExtentions(List<Entity.OrderTransactionDetail> entityList)
        {
            List<Entity.OrderTransactionDetail> retCol = new List<Entity.OrderTransactionDetail>();

            //populate the list
            foreach (Entity.OrderTransactionDetail entityObject in entityList)
            {
                retCol.Add(populateExtentions(entityObject));
            }

            return retCol;
        }


        #region Create
        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.OrderTransactionDetail create(Entity.OrderTransactionDetail OrderTransactionDetailObject)
        {
            //Call data access.
            Entity.OrderTransactionDetail ret = DataAccess.daOrderTransactionDetail.create(OrderTransactionDetailObject);
            if (ret == null) return null;

            

            return populateExtentions(ret);
        }

        /// <summary>Create an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static List<Entity.OrderTransactionDetail> create(List<Entity.OrderTransactionDetail> OrderTransactionDetailList)
        {
            if (OrderTransactionDetailList.Count == 0) return OrderTransactionDetailList;
            //Call data access.
            foreach (Entity.OrderTransactionDetail OrderTransactionDetailObject in OrderTransactionDetailList)
            {
                create(OrderTransactionDetailObject);
                
            }

            return retrieveByOrderTransactionId(OrderTransactionDetailList[0].OrderTransactionId);
        }


        #endregion

        #region Retrieve
        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.OrderTransactionDetail> retrieve()
        {
            //create the list
            List<Entity.OrderTransactionDetail> retList = DataAccess.daOrderTransactionDetail.retrieve();
            if (retList == null) return null;
            return populateExtentions(retList);

        }

        public static bool AllowModifiy(string code)
        {
           
            List<Entity.OrderTransactionDetail> orderDetails = DataAccess.daOrderTransactionDetail.retrieveBySQLStatement(
                string.Format("WHERE Particulars LIKE '%{0}%'", code));

            return orderDetails.Count>0?false:true;
        }
        /// <summary>Retrieve a single entity by id.</summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Return Entity object.</returns>
        public static Entity.OrderTransactionDetail retrieve(long Id)
        {
            //call the retrieval
            Entity.OrderTransactionDetail ret = DataAccess.daOrderTransactionDetail.retrieve(Id);
            if (ret == null) return null;
            return populateExtentions(ret);
        }

        /// <summary>Retrieve all entities.</summary>
        /// <returns>a List of Entities</returns>
        public static List<Entity.OrderTransactionDetail> retrieveByOrderTransactionId(long OrderTransactionId)
        {
            //create the list
            List<Entity.OrderTransactionDetail> retList = DataAccess.daOrderTransactionDetail.retrieveByOrderTransactionId(OrderTransactionId);
            if (retList == null) return null;
            return populateExtentions(retList);
        }
        public static List<Entity.RejectedOrder> retrieveOrderRejectedItems(
           string jodetailsid)
        {
            return DataAccess.daOrderTransactionDetail.retrieveRejectedItem(
                string.Format(@"SELECT				OPD.OrderDetails_Id AS OrderDetailsId
                                                                        ,OTD.ParticularTypeId
                                                                        ,OTD.ProductListId
                                                                        ,JOD.ConsumedQuantity AS Quantity
                                                                        ,OTD.ParticularTypeCode
                                                                        ,OPD.Particulars
                                                                        ,OTD.ParticularCode				                                                           
                                                    FROM				JobOrderDetails JOD
                                                    INNER JOIN			OrderPackageDetails OPD
                                                    ON					JOD.OrderPackageDetailsId=OPD.Id
                                                    INNER JOIN			OrderTransactionDetail OTD
                                                    ON					OPD.OrderDetails_Id=OTD.Id
                                                    WHERE               JOD.Id {0} AND JOD.IsDone=1", jodetailsid));
        }
        public static List<Entity.RejectedOrder> viewRejectedOrder(long ordertransactionid)
        {
            return DataAccess.daOrderTransactionDetail.retrieveRejectedItem(
                string.Format(@"SELECT				OTD.Id as OrderDetailsId
                                                    ,OTD.ParticularTypeId
                                                    ,OTD.ProductListId
                                                    ,ISNULL(OPD.Id,-1) AS OrderPackageDetailsId
                                                    ,CASE ISNULL(OPD.Id,'')
                                                     WHEN '' THEN OTD.RejectedQuantity
                                                     ELSE	 OPD.RejectedQuantity
                                                     END AS RejectedQuantity
                                                    ,0 AS Quantity
                                                    ,OTD.ParticularTypeCode
                                                    ,CASE ISNULL(OPD.Id,'')
                                                     WHEN '' THEN OTD.Particulars
                                                     ELSE	 OPD.Particulars
                                                     END     AS Particulars
                                                    ,OTD.ParticularCode
                                                   -- ,-1 AS JobOrderDetailId
                                                    ,CASE ISNULL(OPD.Id,'')
                                                     WHEN '' THEN 0
                                                     ELSE	 1
                                                     END AS IsPackage
                                FROM				OrderTransactionDetail OTD
                                LEFT JOIN			OrderPackageDetails OPD
                                ON					OTD.Id=OPD.OrderDetails_Id
                                WHERE	            OTD.OrderTransactionId={0} AND	
                                                    (CASE ISNULL(OPD.Id,'')
                                                     WHEN '' THEN OTD.IsRejectedOrder
                                                     ELSE OPD.IsRejectedOrder
                                                     END) = 1 ",
                                                        ordertransactionid));

        }
        

        public static List<Entity.RejectedOrder> retrieveOrderRejectedItems(
            string inorderdetailids, string packagedetailsid)
        {
            string concatFilters = string.Concat(
                string.IsNullOrEmpty(inorderdetailids) ? "0" : "1",
                string.IsNullOrEmpty(packagedetailsid) ? "0" : "1");
            string sqlStatement = "";
            switch (concatFilters)
            {
                case "01":
                    sqlStatement = string.Format(@"DECLARE		@tempTable TABLE (OrderDetailsId	BIGINT
							                                                        ,ParticularTypeId	BIGINT
							                                                        ,ProductListId		BIGINT
							                                                        ,RejectedQuantity	INT
							                                                        ,Quantity			INT
							                                                        ,ParticularTypeCode VARCHAR(50)
							                                                        ,Particulars		VARCHAR(500)
							                                                        ,ParticularCode     NVARCHAR(50)
																					,OrderPackageDetailsId	BIGINT
							                                                        --,JobOrderDetailId	BIGINT
							                                                        ,IsPackage			BIT)

	                                                        DECLARE @OrderPackageDetailsId BIGINT
	                                                        DECLARE @OrderDetails_Id	BIGINT
	                                                        DECLARE @Particulars		VARCHAR(500)	
	                                                        DECLARE @RejectedQuantity	INT
	                                                        DECLARE @ParticularTypeCode VARCHAR(50)
	                                                        DECLARE @ParticularCode		NVARCHAR(50)
	                                                        DECLARE @ParticularTypeId	BIGINT
	                                                        DECLARE @ProductListId		BIGINT

	                                                        DECLARE	Cur CURSOR FOR
					                                                        SELECT			OrderDetails_Id
									                                                        ,Particulars
							                                                        --		,Quantity
									                                                        ,Id
									                                                        ,RejectedQuantity
					                                                        FROM			OrderPackageDetails 
					                                                        where			Id {0}

		                                                        OPEN Cur
		                                                        FETCH NEXT FROM Cur INTO @OrderDetails_Id,@Particulars,@OrderPackageDetailsId,@RejectedQuantity
		                                                        WHILE @@Fetch_Status=0
		                                                        BEGIN
			                                                        SELECT			@ParticularTypeCode=ParticularTypeCode
							                                                        ,@ParticularCode=ParticularCode
							                                                        ,@ParticularTypeId=ParticularTypeId
							                                                        ,@ProductListId=ProductListId
			                                                        FROM			OrderTransactionDetail 
			                                                        WHERE			Id=@OrderDetails_Id
			                                                        DECLARE			@Quantity INT
                                                        		
			                                                        SELECT			@Quantity=SUM(ConsumedQuantity)			
			                                                        FROM			JobOrderDetails
			                                                        WHERE			OrderPackageDetailsId=@OrderPackageDetailsId
			                                                        AND				IsDone=1
                                                        	
			                                                        IF @Quantity>0
			                                                        BEGIN
			                                                        INSERT INTO @tempTable(OrderDetailsId	
									                                                        ,ParticularTypeId	
									                                                        ,ProductListId		
									                                                        ,RejectedQuantity	
									                                                        ,Quantity			
									                                                        ,ParticularTypeCode 
									                                                        ,Particulars		
									                                                        ,ParticularCode 
																							,OrderPackageDetailsId    						
									                                                        ,IsPackage)
			                                                        VALUES					(@OrderDetails_Id
									                                                        ,@ParticularTypeId
									                                                        ,@ProductListId
									                                                        ,@RejectedQuantity
									                                                        ,@Quantity
									                                                        ,@ParticularTypeCode
									                                                        ,@Particulars
									                                                        ,@ParticularCode
																							,@OrderPackageDetailsId
									                                                        ,1)
			                                                        END
			                                                        FETCH NEXT FROM Cur INTO @OrderDetails_Id,@Particulars,@OrderPackageDetailsId,@RejectedQuantity	
		                                                        END
		                                                        CLOSE Cur
		                                                        DEALLOCATE Cur

	                                                        SELECT * FROM @tempTable", packagedetailsid);
                    break;
                case "10":
                    sqlStatement = string.Format(@" SELECT			Id AS OrderDetailsId
															        ,ParticularTypeId
														            ,ProductListId						                                 
						                                            ,RejectedQuantity
															        ,Quantity
						                                            ,ParticularTypeCode
															        ,Particulars
						                                            ,ParticularCode
						                                             ,-1 AS OrderPackageDetailsId
		                                                            ,0	AS IsPackage							                                    															
		                                            FROM			OrderTransactionDetail 
		                                            WHERE			Id  {0}", inorderdetailids);
                    break;
                case "11":
                    sqlStatement = string.Format(@"DECLARE		@tempTable TABLE (OrderDetailsId	BIGINT
							                                    ,ParticularTypeId	BIGINT
							                                    ,ProductListId		BIGINT
							                                    ,RejectedQuantity	INT
							                                    ,Quantity			INT
							                                    ,ParticularTypeCode VARCHAR(50)
							                                    ,Particulars		VARCHAR(500)
							                                    ,ParticularCode     NVARCHAR(50)
																,OrderPackageDetailsId	BIGINT
							                                    --,JobOrderDetailId	BIGINT
							                                    ,IsPackage			BIT)

	                                    DECLARE @OrderPackageDetailsId BIGINT
	                                    DECLARE @OrderDetails_Id	BIGINT
	                                    DECLARE @Particulars		VARCHAR(500)	
	                                    DECLARE @RejectedQuantity	INT
	                                    DECLARE @ParticularTypeCode VARCHAR(50)
	                                    DECLARE @ParticularCode		NVARCHAR(50)
	                                    DECLARE @ParticularTypeId	BIGINT
	                                    DECLARE @ProductListId		BIGINT

	                                    DECLARE	Cur CURSOR FOR
					                                    SELECT			OrderDetails_Id
									                                    ,Particulars
							                                    --		,Quantity
									                                    ,Id
									                                    ,RejectedQuantity
					                                    FROM			OrderPackageDetails 
					                                    where			Id {0}

		                                    OPEN Cur
		                                    FETCH NEXT FROM Cur INTO @OrderDetails_Id,@Particulars,@OrderPackageDetailsId,@RejectedQuantity
		                                    WHILE @@Fetch_Status=0
		                                    BEGIN
			                                    SELECT			@ParticularTypeCode=ParticularTypeCode
							                                    ,@ParticularCode=ParticularCode
							                                    ,@ParticularTypeId=ParticularTypeId
							                                    ,@ProductListId=ProductListId
			                                    FROM			OrderTransactionDetail 
			                                    WHERE			Id=@OrderDetails_Id
			                                    DECLARE	@Quantity	INT
			                                    SELECT			@Quantity=SUM(ConsumedQuantity)
			                                    FROM			JobOrderDetails
			                                    WHERE			OrderPackageDetailsId=@OrderPackageDetailsId
			                                    AND				IsDone=1
			                                    IF @Quantity>0
			                                    BEGIN
			                                    INSERT INTO @tempTable(OrderDetailsId	
									                                    ,ParticularTypeId	
									                                    ,ProductListId		
									                                    ,RejectedQuantity	
									                                    ,Quantity			
									                                    ,ParticularTypeCode 
									                                    ,Particulars		
									                                    ,ParticularCode 
																		,OrderPackageDetailsId    						
									                                    ,IsPackage)
			                                    VALUES					(@OrderDetails_Id
									                                    ,@ParticularTypeId
									                                    ,@ProductListId
									                                    ,@RejectedQuantity
									                                    ,@Quantity
									                                    ,@ParticularTypeCode
									                                    ,@Particulars
									                                    ,@ParticularCode
																		,@OrderPackageDetailsId
									                                    ,1)
			                                    END
			                                    FETCH NEXT FROM Cur INTO @OrderDetails_Id,@Particulars,@OrderPackageDetailsId,@RejectedQuantity	
		                                    END
		                                    CLOSE Cur
		                                    DEALLOCATE Cur
                                    		
		                                     SELECT * FROM @tempTable
											UNION ALL
		                                    SELECT			Id
															,ParticularTypeId
														    ,ProductListId						                                 
						                                    ,RejectedQuantity
															,Quantity
						                                    ,ParticularTypeCode
															,Particulars
						                                    ,ParticularCode
						                                    ,-1
															,0						                                    															
		                                    FROM			OrderTransactionDetail 
		                                    WHERE			Id  {1}"
                                                    , packagedetailsid
                                                    , inorderdetailids);
                    break;
            }

            return DataAccess.daOrderTransactionDetail.retrieveRejectedItem(sqlStatement);

        }
        #endregion

        #region Update
        /// <summary>Update an item entry in the database.</summary>
        /// <param name="itemObject">Item object.</param>
        public static Entity.OrderTransactionDetail update(Entity.OrderTransactionDetail OrderTransactionDetailObject)
        {
            //Call data access.
            DataAccess.daOrderTransactionDetail.update(OrderTransactionDetailObject);

            //get the saved data
            return OrderTransactionDetailObject;
        }

        public static void RejectItems(List<Entity.RejectedOrder> rejectedorders,
            List<Entity.RejectedOrder> deletedrejectdorders)
        {

            foreach (Entity.RejectedOrder rejectedOrder in rejectedorders)
            {
                DataAccess.daOrderTransactionDetail.SetToReject(rejectedOrder);
            }

            foreach (Entity.RejectedOrder rejectedOrder in deletedrejectdorders)
            {
                DataAccess.daOrderTransactionDetail.UnSetToReject(rejectedOrder);
            }
        }
        /// <summary>Update the details of a particular transaction.</summary>
        /// <param name="OrderTransactionObject">Order Transaction object.</param>
        public static List<Entity.OrderTransactionDetail> updateListByOrderTransactionId(long OrderTransactionId, List<Entity.OrderTransactionDetail> OrderTransactionDetailList)
        {
            //look for any removed details and update the existing ones
            List<Entity.OrderTransactionDetail> oldItems = retrieveByOrderTransactionId(OrderTransactionId);
            bool IsdetailExist = false;
            foreach (Entity.OrderTransactionDetail oldItem in oldItems)
            {
                IsdetailExist = false;
                foreach (Entity.OrderTransactionDetail newItem in OrderTransactionDetailList)
                {
                    if (newItem.Id == oldItem.Id)
                    {
                        IsdetailExist = true;
                        update(newItem);
                        break;
                    }
                }
                if (!IsdetailExist) delete(oldItem.Id);
            }

            //create the newly added records
            foreach (Entity.OrderTransactionDetail newItem in OrderTransactionDetailList)
            {
                IsdetailExist = false;
                foreach (Entity.OrderTransactionDetail oldItem in oldItems)
                {
                    if (newItem.Id == oldItem.Id)
                    {
                        IsdetailExist = true;
                        break;
                    }
                }
                if (!IsdetailExist)
                {
                    newItem.OrderTransactionId = OrderTransactionId;
                    create(newItem);
                }
            }

            return retrieveByOrderTransactionId(OrderTransactionId);
        }
        #endregion

        #region Delete
        /// <summary>delete an item entry from the database.</summary>
        /// <param name="OrderTransactionId">Item to delete.</param>
        public static void delete(long OrderTransactionId)
        {
            //Call data access.
            DataAccess.daOrderTransactionDetail.delete(OrderTransactionId);
        }
        #endregion


    }
}
