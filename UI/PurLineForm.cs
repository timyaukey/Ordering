﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.WillowLib.Data.Misc;
using Willowsoft.WillowLib.Data.Sql;
using Willowsoft.WillowLib.WinForm;
using Willowsoft.Ordering.Core.Entities;
using Willowsoft.Ordering.Core.Repositories;
using Willowsoft.Ordering.UI.Helpers;
using Willowsoft.Ordering.UI.Reports;
using Willowsoft.Ordering.UI.SetupForms;

namespace Willowsoft.Ordering.UI
{
    public partial class PurLineForm : Form
    {
        private static List<PurLineForm> mInstances = new List<PurLineForm>();

        private PurOrderId mOrderId;
        private PurOrder mOrder;
        private VendorId mVendorId;
        private PurLineJoinGridHelper mHelper;
        private List<ProductCategory> mCategories;
        private Dictionary<int, ProductSubCategory> mSubCategories;
        private Dictionary<int, ProductBrand> mBrands;

        public PurLineForm()
        {
            InitializeComponent();
            mHelper = new PurLineJoinGridHelper(lineBindingSource, grdLines, this);
            mHelper.CurrentChanged += CurrentPurLineChanged;
        }

        public PurOrder Order
        {
            get { return mOrder; }
            set { mOrder = value; }
        }

        public PurOrderId OrderId
        {
            get { return mOrderId; }
            set { mOrderId = value; }
        }

        public VendorId VendorId
        {
            get { return mVendorId; }
            set { mVendorId = value; }
        }

        public static void Show(Form mdiParent, PurOrderId orderId)
        {
            PurLineForm existingForm = FindOrder(orderId);
            if (existingForm != null)
            {
                existingForm.Activate();
                if (existingForm.WindowState == FormWindowState.Minimized)
                    existingForm.WindowState = FormWindowState.Normal;
                return;
            }
            PurLineForm newForm = new PurLineForm();
            PurOrder order;
            using (Ambient.DbSession.Activate())
            {
                order = OrderingRepositories.PurOrder.Get(orderId);
                newForm.VendorId = order.VendorId;
                Vendor vendor = OrderingRepositories.Vendor.Get(order.VendorId);
                newForm.Text = "Order: " + vendor.VendorName + " " + order.OrderDate.ToString("MM/dd/yyyy");
            }
            newForm.OrderId = orderId;
            newForm.Order = order;
            newForm.MdiParent = mdiParent;
            mInstances.Add(newForm);
            newForm.Show();
        }

        public static PurLineForm FindOrder(PurOrderId orderId)
        {
            foreach (PurLineForm form in mInstances)
            {
                if (form.OrderId == orderId)
                {
                    return form;
                }
            }
            return null;
        }

        private void CurrentPurLineChanged(object sender, BindingSourceEntityEventArgs<JoinPlToVpToProd> e)
        {
            if (mHelper.UpdateTotalCost)
            {
                ShowTotalCost();
                mHelper.UpdateTotalCost = false;
            }
        }

        private void ShowTotalCost()
        {
            decimal totalCost = 0m;
            decimal totalRetail = 0m;
            foreach (JoinPlToVpToProd join in mHelper.DataSource)
            {
                totalCost += join.ExtendedCost;
                decimal retailPrice = join.PurLine_RetailPrice;
                if (join.PurLine_RetailPriceOverride > 0)
                    retailPrice = join.PurLine_RetailPriceOverride;
                int eachQuantity = join.PurLine_QtyOrdered;
                if (!join.PurLine_OrderedEaches)
                    eachQuantity *= join.PurLine_CountInCase;
                totalRetail += (eachQuantity * retailPrice);
            }
            mOrder.UnpersistedTotal = totalCost + mOrder.Freight;
            double freightPercent = 0.0;
            if (totalCost > 0m)
                freightPercent = (double)(mOrder.Freight / totalCost);
            lblTotalCost.Text = "Total Cost With Freight: " + mOrder.UnpersistedTotal.ToString("c") +
                "   Total Retail: " + totalRetail.ToString("c") +
                "   Margin: " + VendorProduct.ComputeMargin(totalRetail, totalCost, freightPercent
                ).ToString(VendorProduct.MarginFormat);
        }

        private void PurLineForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mInstances.Remove(this);
        }

        private void PurLineForm_Load(object sender, EventArgs e)
        {
            ProductSubCategoryBindingList subCatBindingList = new ProductSubCategoryBindingList();
            ProductBrandBindingList brandBindingList = new ProductBrandBindingList();
            using (Ambient.DbSession.Activate())
            {
                mCategories = OrderingRepositories.ProductCategory.GetAll();
                mSubCategories = new Dictionary<int, ProductSubCategory>();
                subCatBindingList.AddNew();
                foreach (ProductSubCategory subCat in OrderingRepositories.ProductSubCategory.GetAll())
                {
                    mSubCategories.Add(subCat.Id.Value, subCat);
                    subCatBindingList.Add(subCat);
                }
                mBrands = new Dictionary<int, ProductBrand>();
                brandBindingList.AddNew();
                foreach (ProductBrand brand in OrderingRepositories.ProductBrand.GetAll())
                {
                    mBrands.Add(brand.Id.Value, brand);
                    brandBindingList.Add(brand);
                }
            }
            mHelper.Init(mOrder, mSubCategories, mBrands);
            mHelper.AddAllColumns(subCatBindingList, brandBindingList);
            (new ToolTip()).SetToolTip(btnSetBrands, "Set brand of all selected rows that are manually entered or imported, to the brand of the first selected row.");
            (new ToolTip()).SetToolTip(btnSetSubcategories, "Set subcategory of all selected rows that are manually entered or imported, to the subcategory of the first selected row.");
            (new ToolTip()).SetToolTip(btnCreateProducts, "Create new vendor products for all rows that are manually entered or imported.");
            ShowLines();
            ShowTotalCost();
        }

        public void ShowLines()
        {
            JoinPlToVpToProdBindingList data = JoinPlToVpToProdBindingList.GetOrderLines(
                mOrderId, false, mCategories, mSubCategories, mBrands, out mOrder);
            mHelper.DataSource = data;
        }

        private void btnFindVendor_Click(object sender, EventArgs e)
        {
            FindVendorPartNumber();
        }

        private void txtVendorPart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                FindVendorPartNumber();
            }
        }

        private void FindVendorPartNumber()
        {
            string vendorPartNumber = txtVendorCode.Text.Trim();
            if (vendorPartNumber.Length == 0)
            {
                MessageBox.Show("Please enter a vendor code first.");
                return;
            }
            JoinPlToVpToProdBindingList data = (JoinPlToVpToProdBindingList)mHelper.DataSource;
            foreach (JoinPlToVpToProd row in data)
            {
                if (row.VendorProduct_VendorPartNum == vendorPartNumber)
                {
                    mHelper.CurrentEntity = row;
                    return;
                }
            }
            MessageBox.Show("Vendor code not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnPurchaseHistory_Click(object sender, EventArgs e)
        {
            if (mHelper.CurrentEntity == null)
            {
                MessageBox.Show("Select the row with the product whose orders you want to see.");
                return;
            }
            VendorProductId vpId = mHelper.CurrentEntity.PurLine_VendorProductId;
            using (PurOrderSummaryForm frm = new PurOrderSummaryForm())
            {
                List<PurOrderSummary> orders;
                using (Ambient.DbSession.Activate())
                {
                    orders = OrderingRepositories.PurOrder.GetByVendorProduct(vpId);
                }
                frm.Show(orders, mHelper.CurrentEntity.Product_ProductName);
            }
        }

        private void btnPOFaxReport_Click(object sender, EventArgs e)
        {
            HTMLOrderReport report = new HTMLOrderReport();
            report.Run(OrderId,
                new FaxOrderWriter(),
                new FilterOrderedOnly(),
                false,
                "Purchase Order",
                this.MdiParent);
        }

        private void btnWorksheetReport_Click(object sender, EventArgs e)
        {
            HTMLOrderReport report = new HTMLOrderReport();
            report.Run(OrderId,
                new WorksheetWriter(),
                new FilterAll(),
                true,
                "Order Worksheet",
                this.MdiParent);
        }

        private void btnCheckInReport_Click(object sender, EventArgs e)
        {
            HTMLOrderReport report = new HTMLOrderReport();
            report.Run(OrderId,
                new CheckInWriter(),
                new FilterOrderedOnly(),
                false,
                "Order Check-In Report",
                this.MdiParent);
        }

        private void btnCreateProducts_Click(object sender, EventArgs e)
        {
            JoinPlToVpToProdBindingList data = (JoinPlToVpToProdBindingList)mHelper.DataSource;
            List<JoinPlToVpToProd> skippedDupes = new List<JoinPlToVpToProd>();
            int numberToCreate = data.Count(p => p.PurLine_VendorProductId.IsNull);
            int numberCreated = 0;
            bool confirmIndividually = (numberToCreate < 5);
            if (!confirmIndividually)
            {
                string prompt = "Found " + numberToCreate.ToString() + " products to create. Okay to proceed?";
                if (MessageBox.Show(prompt, "Confirm", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;
            }
            foreach(JoinPlToVpToProd purLine in data)
            {
                if (purLine.PurLine_VendorProductId.IsNull)
                {
                    if (confirmIndividually)
                    {
                        string prompt = "Create product \"" + (purLine.PurLine_ProductName + " " + purLine.PurLine_Size).TrimEnd() + "\"?";
                        if (MessageBox.Show(prompt, "Confirm", MessageBoxButtons.OKCancel) != DialogResult.OK)
                            continue;
                    }
                    using (ITranScope trans = Ambient.DbSession.CreateTranScope())
                    {
                        using (Ambient.DbSession.Activate())
                        {
                            List<VendorProduct> dupeVendorProducts = OrderingRepositories.VendorProduct.Get(mVendorId, purLine.PurLine_VendorPartNum);
                            if (dupeVendorProducts.Count > 0)
                            {
                                skippedDupes.Add(purLine);
                            }
                            else
                            {
                                Product newProduct = new Product();
                                newProduct.IsActive = true;
                                newProduct.ManufacturerBarcode = purLine.PurLine_ManufacturerBarcode;
                                newProduct.ManufacturerPartNum = purLine.PurLine_ManufacturerPartNum;
                                newProduct.ProductBrandId = purLine.PurLine_ProductBrandId;
                                newProduct.ProductSubCategoryId = purLine.PurLine_ProductSubCategoryId;
                                newProduct.ProductName = purLine.PurLine_ProductName;
                                newProduct.Size = purLine.PurLine_Size;
                                newProduct.RetailPrice = purLine.PurLine_RetailPrice;
                                OrderingRepositories.Product.Insert(newProduct);

                                VendorProduct newVendorProduct = new VendorProduct();
                                newVendorProduct.VendorId = mVendorId;
                                newVendorProduct.ProductId = newProduct.Id;
                                newVendorProduct.CaseCost = purLine.PurLine_CaseCost;
                                newVendorProduct.CountInCase = purLine.PurLine_CountInCase;
                                newVendorProduct.EachCost = purLine.PurLine_EachCost;
                                newVendorProduct.PreferredSource = purLine.PurLine_PreferredSource;
                                newVendorProduct.RetailPriceOverride = purLine.PurLine_RetailPriceOverride;
                                newVendorProduct.ShelfOrder = purLine.PurLine_ShelfOrder;
                                newVendorProduct.VendorPartNum = purLine.PurLine_VendorPartNum;
                                newVendorProduct.WholeCasesOnly = purLine.PurLine_WholeCasesOnly;
                                OrderingRepositories.VendorProduct.Insert(newVendorProduct);

                                purLine.PurLine_VendorProductId = newVendorProduct.Id;
                                OrderingRepositories.PurLine.Update(purLine.InnerPurLine);

                                numberCreated++;
                            }
                        }
                        trans.Complete();
                    }
                }
            }
            ShowLines();
            ShowTotalCost();
            if (numberCreated > 0)
                MessageBox.Show("Created " + numberCreated.ToString() + " products.");
            else
                MessageBox.Show("No products created.");
            if (skippedDupes.Count > 0)
            {
                MessageBox.Show("Skipped the following products because they would have created duplicate vendor codes.");
                foreach (JoinPlToVpToProd purLine in skippedDupes)
                {
                    MessageBox.Show("Skipped \"" + purLine.InnerPurLine.ProductName + "\"");
                }
            }
        }

        private void grdLines_SelectionChanged(object sender, EventArgs e)
        {
            btnSetBrands.Enabled = (grdLines.SelectedRows.Count > 1);
            btnSetSubcategories.Enabled = (grdLines.SelectedRows.Count > 1);
        }

        private void btnSetSubcategories_Click(object sender, EventArgs e)
        {
            bool onFirstRow = true;
            ProductSubCategoryId subCatId = null;
            int numberSet = 0;
            int numberSkipped = 0;
            List<DataGridViewRow> sortedRows = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in grdLines.SelectedRows)
            {
                sortedRows.Add(row);
            }
            sortedRows.Sort((r1, r2) => r1.Index.CompareTo(r2.Index));
            foreach (DataGridViewRow row in sortedRows)
            {
                JoinPlToVpToProd purLine = (JoinPlToVpToProd)row.DataBoundItem;
                if (onFirstRow)
                {
                    subCatId = purLine.PurLine_ProductSubCategoryId;
                    ProductSubCategory subCat = mSubCategories[subCatId.Value];
                    string prompt = "Use subcategory \"" + subCat.SubCategoryName + "\"?";
                    if (MessageBox.Show(prompt, "Confirm", MessageBoxButtons.OKCancel) != DialogResult.OK)
                        return;
                    onFirstRow = false;
                }
                else
                {
                    if (purLine.PurLine_VendorProductId.IsNull)
                    {
                        purLine.PurLine_ProductSubCategoryId = subCatId;
                        using (Ambient.DbSession.Activate())
                        {
                            OrderingRepositories.PurLine.Update(purLine.InnerPurLine);
                            numberSet++;
                        }
                    }
                    else
                        numberSkipped++;
                }
            }
            MessageBox.Show("Set subcategory for " + numberSet.ToString() + " rows.");
            MessageBox.Show("Skipped " + numberSkipped.ToString() + " rows because they were not manually added or imported to this order.");
            ShowLines();
            ShowTotalCost();
        }

        private void btnSetBrands_Click(object sender, EventArgs e)
        {
            bool onFirstRow = true;
            ProductBrandId brandId = null;
            int numberSet = 0;
            int numberSkipped = 0;
            List<DataGridViewRow> sortedRows = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in grdLines.SelectedRows)
            {
                sortedRows.Add(row);
            }
            sortedRows.Sort((r1, r2) => r1.Index.CompareTo(r2.Index));
            foreach (DataGridViewRow row in sortedRows)
            {
                JoinPlToVpToProd purLine = (JoinPlToVpToProd)row.DataBoundItem;
                if (onFirstRow)
                {
                    brandId = purLine.PurLine_ProductBrandId;
                    ProductBrand brand = mBrands[brandId.Value];
                    string prompt = "Use brand \"" + brand.BrandName + "\"?";
                    if (MessageBox.Show(prompt, "Confirm", MessageBoxButtons.OKCancel) != DialogResult.OK)
                        return;
                    onFirstRow = false;
                }
                else
                {
                    if (purLine.PurLine_VendorProductId.IsNull)
                    {
                        purLine.PurLine_ProductBrandId = brandId;
                        using (Ambient.DbSession.Activate())
                        {
                            OrderingRepositories.PurLine.Update(purLine.InnerPurLine);
                            numberSet++;
                        }
                    }
                    else
                        numberSkipped++;
                }
            }
            MessageBox.Show("Set brand for " + numberSet.ToString() + " rows.");
            MessageBox.Show("Skipped " + numberSkipped.ToString() + " rows because they were not manually added or imported to this order.");
            ShowLines();
            ShowTotalCost();
        }

        private void btnImportOrder_Click(object sender, EventArgs e)
        {
            using (ImportPurLineForm frm = new ImportPurLineForm())
            {
                frm.Show(mOrder.VendorId, mOrderId);
                ShowLines();
                ShowTotalCost();
            }
        }
    }
}
