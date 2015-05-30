using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.WillowLib.Data.Misc;
using Willowsoft.Ordering.Core.Entities;
using Willowsoft.Ordering.Core.Repositories;

namespace Willowsoft.Ordering.UI.Reports
{
    public class HTMLOrderReport : HTMLReport
    {
        private string mTitle;
        private PurOrderId mOrderId;
        private Vendor mVendor;
        private IOrderReportWriter mWriter;
        private IOrderReportFilter mFilter;
        private bool mShelfOrder;

        private List<ProductCategory> mCategories;
        private Dictionary<int, ProductSubCategory> mSubCategories;
        private Dictionary<int, ProductBrand> mBrands;

        private PurOrder mOrder;

        public void Run(PurOrderId orderId, IOrderReportWriter writer, IOrderReportFilter filter,
            bool shelfOrder, string title, Form mdiParent)
        {
            mTitle = title;
            mOrderId = orderId;
            mWriter = writer;
            mFilter = filter;
            mShelfOrder = shelfOrder;
            using (Ambient.DbSession.Activate())
            {
                PurOrder order = OrderingRepositories.PurOrder.Get(orderId);
                mVendor = OrderingRepositories.Vendor.Get(order.VendorId);
                this.Text = title + " for " + mVendor.VendorName + " " + order.OrderDate.ToString("MM/dd/yyyy");
            }
            Run(mdiParent);
            //this.MdiParent = mdiParent;
            //this.Show();
        }

        /*
        private void HTMLOrderReport_Load(object sender, EventArgs e)
        {
            LoadData();
            StringWriter textWriter = new StringWriter();
            WriteContent(textWriter);
            webBrowser.DocumentText = textWriter.GetStringBuilder().ToString();
        }
        */

        protected override void LoadData()
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
        }

        protected override void WriteContent(TextWriter textWriter)
        {
            JoinPlToVpToProdBindingList sortedData = JoinPlToVpToProdBindingList.GetOrderLines(
                mOrderId, mShelfOrder, mCategories, mSubCategories, mBrands, out mOrder);
            decimal totalCost = 0m;
            foreach (JoinPlToVpToProd join in sortedData)
            {
                totalCost += join.ExtendedCost;
            }
            mOrder.UnpersistedTotal = totalCost + mOrder.Freight;

            mWriter.Init(mTitle, mOrder, mVendor, textWriter);
            textWriter.WriteLine("<html>");
            textWriter.WriteLine("<head>");
            textWriter.WriteLine("<style>");
            textWriter.WriteLine("td, th, p, h1, h2, h3, h4 { font-family: sans-serif; }");
            mWriter.AddToStylesheet();
            textWriter.WriteLine("</style>");
            textWriter.WriteLine("</head>");
            textWriter.WriteLine("<body>");
            mWriter.StartBody();
            textWriter.WriteLine("<table border='0' class='TableBorder' cellpadding='3'>");
            textWriter.WriteLine("<tr>");
            mWriter.OutputTableHeader();
            textWriter.WriteLine("</tr>");
            foreach (JoinPlToVpToProd line in sortedData)
            {
                if (mFilter.IncludeLine(line))
                {
                    textWriter.WriteLine("<tr>");
                    mWriter.OutputLine(line);
                    textWriter.WriteLine("</tr>");
                }
            }
            textWriter.WriteLine("</table>");
            textWriter.WriteLine("</body>");
            textWriter.WriteLine("</html>");
        }

        /*
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //webBrowser.ShowPrintDialog();
            webBrowser.ShowPrintPreviewDialog();
        }
        */
    }
}
