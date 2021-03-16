using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.WillowLib.Data.Misc;
using Willowsoft.Ordering.Core.Entities;
using Willowsoft.Ordering.Core.Repositories;
using Willowsoft.Ordering.UI.Helpers;

namespace Willowsoft.Ordering.UI.Reports
{
    public class VendorProductReport : HTMLReport
    {
        private Vendor mVendor;
        private ProductCategory mCat;
        private Dictionary<int, ProductSubCategory> mSubCategories;
        private Dictionary<int, ProductBrand> mBrands;

        public void Run(Vendor vendor, ProductCategory cat, Form mdiParent)
        {
            mVendor = vendor;
            mCat = cat;
            this.Text = "Products for " + mVendor.VendorName + ", Category " + mCat.CategoryName;
            Run(mdiParent);
        }

        protected override void LoadData()
        {
            using (Ambient.DbSession.Activate())
            {
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
            ReportWriterBase report = new ReportWriterBase();
            report.Init(textWriter);
            report.WriteLine("<html>");
            report.WriteLine("<head>");
            textWriter.WriteLine("<style>");
            textWriter.WriteLine("td, th, p, h1, h2, h3, h4 { font-family: sans-serif; }");
            report.AddToStylesheet();
            textWriter.WriteLine("</style>");
            report.WriteLine("</head>");
            report.WriteLine("<body>");
            report.WriteLine("<h2>" + mVendor.VendorName + " / " + mCat.CategoryName + "</h2>");

            textWriter.WriteLine("<table border='0' class='TableBorder' cellpadding='3'>");
            textWriter.WriteLine("<tr>");
            report.TableHeader("Subcategory");
            report.TableHeader("Part Num");
            report.TableHeader("Product Name");
            report.TableHeader("Size");
            report.TableHeader("Brand");
            report.TableHeader("Retail");
            report.TableHeader("Each Cost");
            report.TableHeader("Case Cost");
            report.TableHeader("Case Size");
            textWriter.WriteLine("</tr>");

            List<JoinVpToProd> vendorProducts = GetVendorProducts(mVendor.Id, mCat.Id);
            foreach (JoinVpToProd vendorProduct in vendorProducts)
            {
                if (vendorProduct.InnerProduct.IsActive && vendorProduct.InnerVendorProduct.IsActive)
                {
                    report.WriteLine("<tr>");
                    int subCatIdValue = vendorProduct.InnerProduct.ProductSubCategoryId.Value;
                    string subCatName = mSubCategories[subCatIdValue].SubCategoryName;
                    report.TableCellLeft(subCatName);
                    report.TableCellLeft(vendorProduct.InnerVendorProduct.VendorPartNum);
                    report.TableCellLeft(vendorProduct.InnerProduct.ProductName);
                    report.TableCellLeft(vendorProduct.InnerProduct.Size);
                    int brandIdValue = vendorProduct.InnerProduct.ProductBrandId.Value;
                    string brandName = mBrands[brandIdValue].BrandName;
                    report.TableCellLeft(brandName);
                    report.TableCellRight(vendorProduct.InnerProduct.RetailPrice.ToString("c"));
                    report.TableCellRight(vendorProduct.InnerVendorProduct.EachCost.ToString("c"));
                    report.TableCellRight(vendorProduct.InnerVendorProduct.CaseCost.ToString("c"));
                    report.TableCellRight(vendorProduct.InnerVendorProduct.CountInCase.ToString());
                    report.WriteLine("</tr>");
                }
            }

            report.WriteLine("</table>");

            report.WriteLine("</body>");
            report.WriteLine("</html>");
        }

        private List<JoinVpToProd> GetVendorProducts(VendorId vendorId, ProductCategoryId catId)
        {
            List<JoinVpToProd> result = new List<JoinVpToProd>();
            using (Ambient.DbSession.Activate())
            {
                Dictionary<int, Product> productDict;
                List<VendorProduct> venprodList;
                if (catId.Value == VendorProductHelper.AllCategoriesId)
                    VendorProductHelper.LoadForAllCategories(vendorId, out productDict, out venprodList);
                else
                    VendorProductHelper.LoadForCategory(vendorId, catId, out productDict, out venprodList);
                foreach (VendorProduct venprod in venprodList)
                {
                    Product product = productDict[venprod.ProductId.Value];
                    JoinVpToProd join = new JoinVpToProd(venprod, product);
                    join.SetExternalData(new ZeroFreightProvider());
                    result.Add(join);
                }
            }
            return result;
        }
    }

    public class ZeroFreightProvider : JoinVpToProd.IFreightProvider
    {
        public double FreightPercent
        {
            get { return 0.0D; }
        }
    }
}
