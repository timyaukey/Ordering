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

namespace Willowsoft.Ordering.UI
{
    public partial class PurOrderForm : Form
    {
        private static Form mSingleton;
        private PurOrderGridHelper mHelper;
        private List<Vendor> mVendors;

        public PurOrderForm()
        {
            InitializeComponent();
            mHelper = new PurOrderGridHelper(orderBindingSource, grdOrders, this);
            mHelper.CurrentChanged += CurrentPurOrderChanged;
        }

        public static void Show(Form mdiParent)
        {
            if (mSingleton == null)
            {
                mSingleton = new PurOrderForm();
                mSingleton.MdiParent = mdiParent;
                mSingleton.Show();
            }
            else
            {
                mSingleton.Activate();
            }
        }

        private void CurrentPurOrderChanged(object sender, BindingSourceEntityEventArgs<PurOrder> e)
        {
            PurOrder purOrder = e.Entity;
            if (purOrder != null)
            {
                if (purOrder.IsPersisted)
                {
                    ShowOrderCategories(purOrder.Id);
                    mHelper.VendorReadOnly = true;
                }
                else
                {
                    lstCategories.ClearSelected();
                    mHelper.VendorReadOnly = false;
                }
            }

        }

        private void PurOrderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mSingleton = null;
        }

        private void PurOrderForm_Load(object sender, EventArgs e)
        {
            LoadSearch();
            LoadCategories();
            LoadOrders();
            //Willowsoft.WillowLib.CodeGenUI.PersistableWrapperGenerator gen =
            //    new Willowsoft.WillowLib.CodeGenUI.PersistableWrapperGenerator("JoinPlToVpToProd");
            //gen.Add(typeof(PurLine));
            //gen.Add(typeof(VendorProduct));
            //gen.Add(typeof(Product));
            //gen.GenerateToClipboard();
        }

        private void LoadSearch()
        {
            using (Ambient.DbSession.Activate())
            {
                mVendors = OrderingRepositories.Vendor.GetAll();
            }
            Vendor emptyVendor = new Vendor();
            emptyVendor.VendorName = "All Vendors";
            cboVendor.Items.Clear();
            cboVendor.Items.Add(emptyVendor);
            foreach (Vendor vendor in mVendors)
            {
                cboVendor.Items.Add(vendor);
            }
            cboVendor.SelectedIndex = 0;
            txtStartDate.Text = DateTime.Today.AddDays(-60.0D).ToShortDateString();
            txtEndDate.Text = DateTime.Today.AddDays(10.0D).ToShortDateString();
        }

        private void LoadCategories()
        {
            List<ProductCategory> categories;
            using (Ambient.DbSession.Activate())
            {
                categories = OrderingRepositories.ProductCategory.GetAll();
            }
            lstCategories.Items.Clear();
            foreach (ProductCategory cat in categories)
            {
                lstCategories.Items.Add(cat);
            }
        }

        private void LoadOrders()
        {
            PurOrderBindingList orderList = new PurOrderBindingList();
            VendorBindingList vendorList = new VendorBindingList();
            DateTime startDate;
            if (!DateTime.TryParse(txtStartDate.Text, out startDate))
            {
                MessageBox.Show("Invalid start date.");
                return;
            }
            DateTime endDate;
            if (!DateTime.TryParse(txtEndDate.Text, out endDate))
            {
                MessageBox.Show("Invalid end date.");
                return;
            }
            if (startDate > endDate)
            {
                MessageBox.Show("Start date may not be after end date.");
                return;
            }
            Vendor searchVendor = (Vendor)cboVendor.SelectedItem;
            using (Ambient.DbSession.Activate())
            {
                List<PurOrder> orders = OrderingRepositories.PurOrder.Get(startDate, endDate);
                foreach (PurOrder order in orders)
                {
                    if (searchVendor.Id.IsNull)
                        orderList.Add(order);
                    else if(searchVendor.Id == order.VendorId)
                        orderList.Add(order);
                }
                vendorList.AddNew();
                vendorList.Add(mVendors);
            }
            mHelper.AddAllColumns(vendorList);
            mHelper.DataSource = orderList;
        }

        private void btnOrderSearch_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void btnSetCategories_Click(object sender, EventArgs e)
        {
            PurOrder order = mHelper.CurrentEntity;
            int notRemoved = 0;
            if (order.IsPersisted)
            {
                using (ITranScope tran = Ambient.DbSession.CreateTranScope())
                {
                    using (Ambient.DbSession.Activate())
                    {
                        for (int index = 0; index < lstCategories.Items.Count; index++)
                        {
                            ProductCategory category = (ProductCategory)lstCategories.Items[index];
                            if (lstCategories.GetSelected(index))
                            {
                                OrderingRepositories.PurLine.AddCategory(order.Id, category.Id, chkIncludeInactive.Checked);
                            }
                            else
                            {
                                notRemoved += OrderingRepositories.PurLine.RemoveCategory(order.Id, category.Id);
                            }
                        }
                        tran.Complete();
                    }
                }
                ShowOrderCategories(order.Id);
                PurLineForm purLineForm = PurLineForm.FindOrder(order.Id);
                if (purLineForm != null)
                    purLineForm.ShowLines();
                if (notRemoved > 0)
                {
                    MessageBox.Show(string.Format(
                        "Unable to remove {0} lines from order because you have used those items.", notRemoved),
                        "Order Updated");
                }
                MessageBox.Show("Product categories updated for order.", "Order Updated");
            }
            else
            {
                MessageBox.Show("You cannot set categories on an order which has not been saved. " +
                    "Click on another line in the order list to save the current order.", "Order Not Updated");
            }
        }

        private void ShowOrderCategories(PurOrderId orderId)
        {
            List<ProductCategory> categories;
            using (Ambient.DbSession.Activate())
            {
                categories = OrderingRepositories.PurLine.GetCategories(orderId);
            }
            lstCategories.ClearSelected();
            foreach (ProductCategory selectedCat in categories)
            {
                for (int index = 0; index < lstCategories.Items.Count; index++)
                {
                    ProductCategory currentCat = (ProductCategory)lstCategories.Items[index];
                    if (currentCat.Id == selectedCat.Id)
                    {
                        lstCategories.SetSelected(index, true);
                        break;
                    }
                }
            }
        }

        private void btnShowOrder_Click(object sender, EventArgs e)
        {
            PurOrder order = mHelper.CurrentEntity;
            if (order.IsPersisted)
            {
                PurLineForm.Show(this.MdiParent, mHelper.CurrentEntity.Id);
            }
            else
            {
                MessageBox.Show("You cannot show order details for an order which has not been saved. " + 
                    "Click on another line in the order list to save the current order.", "Cannot Show Details");
            }
        }
    }
}
