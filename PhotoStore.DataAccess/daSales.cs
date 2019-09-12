using System;
using System.Collections.Generic;
using System.Text;
using PhotoStore.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace PhotoStore.DataAccess
{
    public class daSales
    {
        public static List<GiftCertificateReport> GetGiftCertificateReport(params object[] paramvalues)
        {
            List<GiftCertificateReport> retValues = new List<GiftCertificateReport>();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spReports";
                daHelper.addInParameter(cmd, "@Mode", SqlDbType.VarChar, "GiftCertificate Report");
                daHelper.addInParameter(cmd, "@StartDate", SqlDbType.DateTime, paramvalues[0]);
                daHelper.addInParameter(cmd, "@EndDate", SqlDbType.DateTime, paramvalues[1]);

              

                using (DataSet ds = daHelper.executeProcedure(cmd))
                {
                    if (ds != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            GiftCertificateReport giftCertificateReport = new GiftCertificateReport(dr);
                            retValues.Add(giftCertificateReport);
                            giftCertificateReport = null;
                        }
                    }
                }
            }
            return retValues;
        }
        public static List<GiftCertificateReport> GetGiftCertificateReportRedeemed(params object[] paramvalues)
        {
            List<GiftCertificateReport> retValues = new List<GiftCertificateReport>();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spReports";
                daHelper.addInParameter(cmd, "@Mode", SqlDbType.VarChar, "Redeemed GC Report");
                daHelper.addInParameter(cmd, "@StartDate", SqlDbType.DateTime, paramvalues[0]);
                daHelper.addInParameter(cmd, "@EndDate", SqlDbType.DateTime, paramvalues[1]);
                daHelper.addInParameter(cmd, "Branch", SqlDbType.VarChar, 
                    string.Concat(ConfigurationManager.AppSettings["BranchCodeGC"],"%"));


                using (DataSet ds = daHelper.executeProcedure(cmd))
                {
                    if (ds != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            GiftCertificateReport giftCertificateReport = new GiftCertificateReport(dr);
                            retValues.Add(giftCertificateReport);
                            giftCertificateReport = null;
                        }
                    }
                }
            }
            return retValues;
        }
        public static List<CouponReport> GetCouponReport(params object[] paramvalues)
        {
            List<CouponReport> retValues = new List<CouponReport>();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spReports";
                daHelper.addInParameter(cmd, "@Mode", SqlDbType.VarChar, "Coupon Report");
                daHelper.addInParameter(cmd, "@StartDate", SqlDbType.DateTime, paramvalues[0]);
                daHelper.addInParameter(cmd, "@EndDate", SqlDbType.DateTime, paramvalues[1]);                
                using (DataSet ds = daHelper.executeProcedure(cmd))
                {
                    if (ds != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            CouponReport couponReport = new CouponReport(dr);
                            retValues.Add(couponReport);
                            couponReport = null;
                        }
                    }
                }
            }
            return retValues;
        }
        public static List<CouponReport> GetCouponReportRedeemed(params object[] paramvalues)
        {
            List<CouponReport> retValues = new List<CouponReport>();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spReports";
                daHelper.addInParameter(cmd, "@Mode", SqlDbType.VarChar, "Redeemed Coupon Report");
                daHelper.addInParameter(cmd, "@StartDate", SqlDbType.DateTime, paramvalues[0]);
                daHelper.addInParameter(cmd, "@EndDate", SqlDbType.DateTime, paramvalues[1]);
                daHelper.addInParameter(cmd, "@Branch", SqlDbType.VarChar,
                  string.Concat(ConfigurationManager.AppSettings["BranchCodeCP"], "%"));
                using (DataSet ds = daHelper.executeProcedure(cmd))
                {
                    if (ds != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            CouponReport couponReport = new CouponReport(dr);
                            retValues.Add(couponReport);
                            couponReport = null;
                        }
                    }
                }
            }
            return retValues;
        }

        public static List<BalanceReport> GetBalanceReport(params object[] paramvalues)
        {
            List<BalanceReport> retValues = new List<BalanceReport>();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spReports";
                daHelper.addInParameter(cmd, "@Mode", SqlDbType.VarChar, "Balances Report");
                daHelper.addInParameter(cmd, "@StartDate", SqlDbType.DateTime, paramvalues[0]);
                daHelper.addInParameter(cmd, "@EndDate", SqlDbType.DateTime, paramvalues[1]);
                daHelper.addInParameter(cmd, "@Direction", SqlDbType.Char, paramvalues[3]);
                daHelper.addInParameter(cmd, "@ColumnToBeSorted", SqlDbType.VarChar, paramvalues[4]);
                if (!string.IsNullOrEmpty(paramvalues[2].ToString()))//paramvalues[2] != null)
                {
                    //long customerId = -1;
                    //long.TryParse(paramvalues[2].ToString(), out customerId);
                    //if(customerId>0)
                    daHelper.addInParameter(cmd, "@CustomerName", SqlDbType.VarChar, paramvalues[2].ToString());
                }

                using (DataSet ds = daHelper.executeProcedure(cmd))
                {
                    if (ds != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            BalanceReport balanceReport = new BalanceReport(dr);
                            retValues.Add(balanceReport);
                            balanceReport = null;
                        }
                    }
                }
            }
            return retValues;
        }
        public static List<ProductTypeReport> GetProductType(params object[] paramvalues)
        {
            List<ProductTypeReport> retValues = new List<ProductTypeReport>();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spReports";
                daHelper.addInParameter(cmd, "@Mode", SqlDbType.VarChar, "ProductType Report");
                daHelper.addInParameter(cmd, "@StartDate", SqlDbType.DateTime, paramvalues[0]);
                daHelper.addInParameter(cmd, "@EndDate", SqlDbType.DateTime, paramvalues[1]);
                daHelper.addInParameter(cmd, "@ParticularTypeId", SqlDbType.BigInt, paramvalues[2]);
                using (DataSet ds = daHelper.executeProcedure(cmd))
                {
                    if (ds != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            ProductTypeReport productTypeReport = new ProductTypeReport(dr);
                            retValues.Add(productTypeReport);
                            productTypeReport = null;
                        }
                    }
                }
            }
            return retValues;
        }
        public static List<RejectedReport> GetRejectedReport(params object[] paramvalues)
        {
            List<RejectedReport> retValues = new List<RejectedReport>();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spReports";
                daHelper.addInParameter(cmd, "@Mode", SqlDbType.VarChar, "Rejected Report");
                daHelper.addInParameter(cmd, "@StartDate", SqlDbType.DateTime, paramvalues[0]);
                daHelper.addInParameter(cmd, "@EndDate", SqlDbType.DateTime, paramvalues[1]);
                using (DataSet ds = daHelper.executeProcedure(cmd))
                {
                    if (ds != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            RejectedReport rejectedReport = new RejectedReport(dr);
                            retValues.Add(rejectedReport);
                            rejectedReport = null;
                        }
                    }
                }
            }
            return retValues;
        }

        public static List<SalesReport> GetSalesReport(params object[] paramvalues)
        {
            List<SalesReport> salesReports = new List<SalesReport>();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spReports";
                daHelper.addInParameter(cmd, "@Mode", SqlDbType.VarChar, "Sales Report");
                daHelper.addInParameter(cmd, "@StartDate", SqlDbType.DateTime, paramvalues[0]);
                daHelper.addInParameter(cmd, "@EndDate", SqlDbType.DateTime, paramvalues[1]);
                using (DataSet ds = daHelper.executeProcedure(cmd))
                {
                    if (ds != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            SalesReport salesReport = new SalesReport(dr);
                            salesReports.Add(salesReport);
                            salesReport = null;
                        }
                    }
                }
            }
            return salesReports;
        }
        public static List<DetailedSalesReport> GetDetailedSalesReport(params object[] paramvalues)
        {
            List<DetailedSalesReport> salesReports = new List<DetailedSalesReport>();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spReports";
                daHelper.addInParameter(cmd, "@Mode", SqlDbType.VarChar, "Detailed Sales Report");
                daHelper.addInParameter(cmd, "@StartDate", SqlDbType.DateTime, paramvalues[0]);
                daHelper.addInParameter(cmd, "@EndDate", SqlDbType.DateTime, paramvalues[1]);
                using (DataSet ds = daHelper.executeProcedure(cmd))
                {
                    if (ds != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            DetailedSalesReport salesReport = new DetailedSalesReport(dr);
                            salesReports.Add(salesReport);
                            salesReport = null;
                        }
                    }
                }
            }
            return salesReports;
        }
    }
}
