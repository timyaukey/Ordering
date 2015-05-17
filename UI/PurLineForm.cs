using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            using (Ambient.DbSession.Activate())
            {
                PurOrder order = OrderingRepositories.PurOrder.Get(orderId);
                newForm.VendorId = order.VendorId;
                Vendor vendor = OrderingRepositories.Vendor.Get(order.VendorId);
                newForm.Text = "Order: " + vendor.VendorName + " " + order.OrderDate.ToString("MM/dd/yyyy");
            }
            newForm.OrderId = orderId;
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
                decimal retailPrice = join.Product_RetailPrice;
                if (join.VendorProduct_RetailPriceOverride > 0)
                    retailPrice = join.VendorProduct_RetailPriceOverride;
                int eachQuantity = join.PurLine_QtyOrdered;
                if (!join.PurLine_OrderedEaches)
                    eachQuantity *= join.VendorProduct_CountInCase;
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
            using (Ambient.DbSession.Activate())
            {
                mCategories = OrderingRepositories.ProductCategory.GetAll();
                mSubCategories = new Dictionary<int, ProductSubCategory>();
                foreach (ProductSubCategory subCat in OrderingRepositories.ProductSubCategory.GetAll())
                {
                    mSubCategories.Add(subCat.Id.Value, subCat);
                }
                mBrands = new Dictionary<int, ProductBrand>();
                foreach (ProductBrand brand in OrderingRepositories.ProductBrand.GetAll())
                {
                    mBrands.Add(brand.Id.Value, brand);
                }
            }
            mHelper.AddAllColumns();
            ShowLines();
            ShowTotalCost();
        }

        public void ShowLines()
        {
            JoinPlToVpToProdBindingList data = JoinPlToVpToProdBindingList.GetOrderLines(
                mOrderId, mCategories, mSubCategories, mBrands, out mOrder);
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
                "Purchase Order",
                this.MdiParent);
        }

        private void btnWorksheetReport_Click(object sender, EventArgs e)
        {
            HTMLOrderReport report = new HTMLOrderReport();
            report.Run(OrderId,
                new WorksheetWriter(),
                new FilterAll(),
                "Order Worksheet",
                this.MdiParent);
        }

        private void btnCheckInReport_Click(object sender, EventArgs e)
        {
            HTMLOrderReport report = new HTMLOrderReport();
            report.Run(OrderId,
                new CheckInWriter(),
                new FilterOrderedOnly(),
                "Order Check-In Report",
                this.MdiParent);
        }
    }
}
