﻿// Generated by Willowsoft.WillowLib.CodeGen.ClassCreator at 9/2/2008 5:24:02 PM
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data.SqlClient;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.WillowLib.Data.Sql;
using Willowsoft.Ordering.Core.Entities;

namespace Willowsoft.Ordering.Core.Entities
{
    [DebuggerStepThrough]
    public class ProductBrandId : EntityId
    {
        public ProductBrandId() { }
        public ProductBrandId(int value) : base(value) { }
    }

    public partial class ProductBrand : Entity<ProductBrandId>
    {
        #region Private property fields

        private string mBrandName;
        private string mNotes;
        private bool mIsActive;

        #endregion

        #region Constructors

        [DebuggerStepThrough]
        public ProductBrand(ProductBrandId Id_,
            string BrandName_,
            string Notes_,
            bool IsActive_,
            DateTime CreateDate_,
            DateTime ModifyDate_)
            : base(Id_, CreateDate_, ModifyDate_)
        {
            mBrandName = BrandName_;
            mNotes = Notes_;
            mIsActive = IsActive_;
        }

        [DebuggerStepThrough]
        public ProductBrand()
            : this(new ProductBrandId(),
            string.Empty,
            string.Empty,
            true,
            DateTime.Now, DateTime.Now)
        {
        }

        #endregion

        #region Encapsulated fields

        public string BrandName
        {
            [DebuggerStepThrough]
            get { return mBrandName; }
            [DebuggerStepThrough]
            set { PropertySet(ref mBrandName, value); }
        }

        public string Notes
        {
            [DebuggerStepThrough]
            get { return mNotes; }
            [DebuggerStepThrough]
            set { PropertySet(ref mNotes, value); }
        }

        public bool IsActive
        {
            [DebuggerStepThrough]
            get { return mIsActive; }
            [DebuggerStepThrough]
            set { PropertySet(ref mIsActive, value); }
        }

        #endregion
    }
}

namespace Willowsoft.Ordering.Core.Repositories
{
    public partial class SqlProductBrandRepository
        : SqlEntityRepository<ProductBrand, ProductBrandId, OrderingDataSet.ProductBrandRow>,
        IProductBrandRepository
    {
        #region SqlEntityRepository Members

        [DebuggerStepThrough]
        protected override ProductBrand CreateEntity(OrderingDataSet.ProductBrandRow dataRow)
        {
            ProductBrand entity = new ProductBrand(new ProductBrandId(dataRow.ProductBrandId),
                dataRow.BrandName,
                dataRow.Notes,
                dataRow.IsActive > 0 ? true : false,
                dataRow.CreateDate, dataRow.ModifyDate);
            return entity;
        }

        [DebuggerStepThrough]
        public override List<ProductBrand> CreateEntities(SqlDataAdapter adapter)
        {
            OrderingDataSet dataSet = new OrderingDataSet();
            adapter.Fill(dataSet.ProductBrand);
            return CreateEntities(dataSet.ProductBrand);
        }

        [DebuggerStepThrough]
        protected override void AddInsertUpdateParams(SqlCommand cmd, ProductBrand entity)
        {
            SqlHelper.AddParamVarchar(cmd, "@BrandName", entity.BrandName ?? string.Empty);
            SqlHelper.AddParamVarchar(cmd, "@Notes", entity.Notes ?? string.Empty);
            SqlHelper.AddParamTinyint(cmd, "@IsActive", entity.IsActive);
        }

        protected override string EntityName
        {
            [DebuggerStepThrough]
            get { return "ProductBrand"; }
        }

        #endregion
    }
}