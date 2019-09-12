using System;
using System.Collections.Generic;
using System.Text;
using PhotoStore.DataAccess;
using PhotoStore.Entity;
using System.Data.SqlClient;
using System.Data;
namespace PhotoStore.BusinessLogic
{
    public interface IReportProducts<T>
    {
        List<T> GetData(params object[] paramvalues);
    }

    public class SalesReportProducts:IReportProducts<SalesReport>
    {       
        public List<SalesReport> GetData(params object[] paramvalues)
        {
            return daSales.GetSalesReport(paramvalues);
        }     
    }

    
    public class RejectedReportProducts : IReportProducts<RejectedReport>
    {
        public List<RejectedReport> GetData(params object[] paramvalues)
        {
            return daSales.GetRejectedReport(paramvalues); 
        }

       
    }
    public class DetailedSalesReportProducts : IReportProducts<DetailedSalesReport>
    {

        #region IReportProducts<DetailedSalesReport> Members

        public List<DetailedSalesReport> GetData(params object[] paramvalues)
        {
            return daSales.GetDetailedSalesReport(paramvalues);
        }

        #endregion
    }
    public class ProductTypeReportProducts : IReportProducts<ProductTypeReport>
    {
        #region IReportProducts<ProductTypeReport> Members

        public List<ProductTypeReport> GetData(params object[] paramvalues)
        {
            return daSales.GetProductType(paramvalues);
        }

        #endregion
    }

    public class BalanceReportProducts : IReportProducts<BalanceReport>
    {
        #region IReportProducts<BalanceReport> Members

        public List<BalanceReport> GetData(params object[] paramvalues)
        {
            return daSales.GetBalanceReport(paramvalues);
        }

        #endregion
    }

    public class GiftCertificateReportProducts : IReportProducts<GiftCertificateReport>
    {

        #region IReportProducts<GiftCertificateReport> Members

        public List<GiftCertificateReport> GetData(params object[] paramvalues)
        {
            return daSales.GetGiftCertificateReport(paramvalues);
        }

        #endregion
    }
    public class CouponReportProducts : IReportProducts<CouponReport>
    {

        #region IReportProducts<CouponReport> Members

        public List<CouponReport> GetData(params object[] paramvalues)
        {
            return daSales.GetCouponReport(paramvalues);
        }

        #endregion
    }
    public class CouponReportRedeemedProducts : IReportProducts<CouponReport>
    {

        #region IReportProducts<CouponReport> Members

        public List<CouponReport> GetData(params object[] paramvalues)
        {
            return daSales.GetCouponReportRedeemed(paramvalues);
        }

        #endregion
    }

    public class GiftCertificateReportRedeemedProducts : IReportProducts<GiftCertificateReport>
    {

        #region IReportProducts<GiftCertificateReport> Members

        public List<GiftCertificateReport> GetData(params object[] paramvalues)
        {
           return daSales.GetGiftCertificateReportRedeemed(paramvalues);
        }

        #endregion
    }
}
