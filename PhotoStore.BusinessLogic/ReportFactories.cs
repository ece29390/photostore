using System;
using System.Collections.Generic;
using System.Text;
using PhotoStore.Entity;
namespace PhotoStore.BusinessLogic
{
    public interface IReportFactories<T>
    {
        IReportProducts<T> CreateProduct();
    }

    public class SaleReportFactory : IReportFactories<SalesReport>
    {
        #region IReportFactories<SalesReport> Members

        public IReportProducts<SalesReport> CreateProduct()
        {
            return new SalesReportProducts();
        }

        #endregion
    }
    public class DetailedSalesReportFactory : IReportFactories<DetailedSalesReport>
    {
        #region IReportFactories<DetailedSalesReport> Members

        public IReportProducts<DetailedSalesReport> CreateProduct()
        {
            return new DetailedSalesReportProducts();
        }

        #endregion
    }
    public class RejectedReportFactory : IReportFactories<RejectedReport>
    {
        #region IReportFactories<RejectedReport> Members

        public IReportProducts<RejectedReport> CreateProduct()
        {
            return new RejectedReportProducts();
        }

        #endregion
    }
    public class ProductTypeReportFactory : IReportFactories<ProductTypeReport>
    {
        #region IReportFactories<ProductTypeReport> Members

        public IReportProducts<ProductTypeReport> CreateProduct()
        {
            return new ProductTypeReportProducts();
        }

        #endregion
    }

    public class BalanceReportFactory : IReportFactories<BalanceReport>
    {
        #region IReportFactories<BalanceReport> Members

        public IReportProducts<BalanceReport> CreateProduct()
        {
            return new BalanceReportProducts();
        }

        #endregion
    }

    public class GiftCertificateReportFactory : IReportFactories<GiftCertificateReport>
    {

        #region IReportFactories<GiftCertificateReport> Members

        public IReportProducts<GiftCertificateReport> CreateProduct()
        {
            return new GiftCertificateReportProducts();
        }

        #endregion
    }
    public class GiftCertificateReportRedeemedFactory : IReportFactories<GiftCertificateReport>
    {

        #region IReportFactories<GiftCertificateReport> Members

        public IReportProducts<GiftCertificateReport> CreateProduct()
        {
            return new GiftCertificateReportRedeemedProducts();
        }

        #endregion
    }
    public class CouponReportFactory : IReportFactories<CouponReport>
    {

        #region IReportFactories<CouponReport> Members

        public IReportProducts<CouponReport> CreateProduct()
        {
            return new CouponReportProducts();
        }

        #endregion
    }
    public class CouponReportRedeemedFactory : IReportFactories<CouponReport>
    {

        #region IReportFactories<CouponReport> Members

        public IReportProducts<CouponReport> CreateProduct()
        {
            return new CouponReportRedeemedProducts();
        }

        #endregion
    }
}
