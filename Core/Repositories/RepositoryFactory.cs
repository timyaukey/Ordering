using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using Willowsoft.WillowLib.Data.Misc;
using Willowsoft.WillowLib.Data.Sql;

namespace Willowsoft.Ordering.Core.Repositories
{
    // Interface used by application to obtain repository interfaces.
    public interface IOrderingRepositories
    {
        IContactRepository Contact { get; }
        IVendorRepository Vendor { get; }
        IProductBrandRepository ProductBrand { get; }
        IProductCategoryRepository ProductCategory { get; }
        IProductSubCategoryRepository ProductSubCategory { get; }
        IProductRepository Product { get; }
        IVendorProductRepository VendorProduct { get; }
        IPurOrderRepository PurOrder { get; }
        IPurLineRepository PurLine { get; }
    }

    public static class OrderingRepositories
    {
        private static string mRepositoryKey = "OrderingRepositories";

        // Called at application startup.
        public static void Configure(IOrderingRepositories rep)
        {
            Ambient.Data[mRepositoryKey] = rep;
        }

        private static IOrderingRepositories Rep
        {
            get { return (IOrderingRepositories)Ambient.Data[mRepositoryKey]; }
        }

        public static IContactRepository Contact
        {
            [DebuggerStepThrough]
            get { return Rep.Contact; }
        }

        public static IVendorRepository Vendor
        {
            [DebuggerStepThrough]
            get { return Rep.Vendor; }
        }

        public static IProductBrandRepository ProductBrand
        {
            [DebuggerStepThrough]
            get { return Rep.ProductBrand; }
        }

        public static IProductCategoryRepository ProductCategory
        {
            [DebuggerStepThrough]
            get { return Rep.ProductCategory; }
        }

        public static IProductSubCategoryRepository ProductSubCategory
        {
            [DebuggerStepThrough]
            get { return Rep.ProductSubCategory; }
        }

        public static IProductRepository Product
        {
            [DebuggerStepThrough]
            get { return Rep.Product; }
        }

        public static IVendorProductRepository VendorProduct
        {
            [DebuggerStepThrough]
            get { return Rep.VendorProduct; }
        }

        public static IPurOrderRepository PurOrder
        {
            [DebuggerStepThrough]
            get { return Rep.PurOrder; }
        }

        public static IPurLineRepository PurLine
        {
            [DebuggerStepThrough]
            get { return Rep.PurLine; }
        }
    }

    public class SqlOrderingRepositories : IOrderingRepositories
    {
        private SqlContactRepository mContactRepository;
        private SqlVendorRepository mVendorRepository;
        private SqlProductBrandRepository mProductBrandRepository;
        private SqlProductCategoryRepository mProductCategoryRepository;
        private SqlProductSubCategoryRepository mProductSubCategoryRepository;
        private SqlProductRepository mProductRepository;
        private SqlVendorProductRepository mVendorProductRepository;
        private SqlPurOrderRepository mPurOrderRepository;
        private SqlPurLineRepository mPurLineRepository;

        public SqlOrderingRepositories(SqlDbSession session)
        {
            mContactRepository = new SqlContactRepository(session);
            mVendorRepository = new SqlVendorRepository(session);
            mProductBrandRepository = new SqlProductBrandRepository(session);
            mProductCategoryRepository = new SqlProductCategoryRepository(session);
            mProductSubCategoryRepository = new SqlProductSubCategoryRepository(session);
            mProductRepository = new SqlProductRepository(session);
            mVendorProductRepository = new SqlVendorProductRepository(session);
            mPurOrderRepository = new SqlPurOrderRepository(session);
            mPurLineRepository = new SqlPurLineRepository(session, mProductCategoryRepository);
        }

        public IContactRepository Contact
        {
            [DebuggerStepThrough]
            get { return mContactRepository; }
        }

        public IVendorRepository Vendor
        {
            [DebuggerStepThrough]
            get { return mVendorRepository; }
        }

        public IProductBrandRepository ProductBrand
        {
            [DebuggerStepThrough]
            get { return mProductBrandRepository; }
        }

        public IProductCategoryRepository ProductCategory
        {
            [DebuggerStepThrough]
            get { return mProductCategoryRepository; }
        }

        public IProductSubCategoryRepository ProductSubCategory
        {
            [DebuggerStepThrough]
            get { return mProductSubCategoryRepository; }
        }

        public IProductRepository Product
        {
            [DebuggerStepThrough]
            get { return mProductRepository; }
        }

        public IVendorProductRepository VendorProduct
        {
            [DebuggerStepThrough]
            get { return mVendorProductRepository; }
        }

        public IPurOrderRepository PurOrder
        {
            [DebuggerStepThrough]
            get { return mPurOrderRepository; }
        }

        public IPurLineRepository PurLine
        {
            [DebuggerStepThrough]
            get { return mPurLineRepository; }
        }
    }
}
