using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Willowsoft.WillowLib.Data.Misc;
using Willowsoft.Ordering.Core.Entities;
using Willowsoft.Ordering.Core.Repositories;

namespace Willowsoft.Ordering.UI.SetupForms
{
    public partial class PurOrderSummaryForm : Form
    {
        public PurOrderSummaryForm()
        {
            InitializeComponent();
        }

        public void Show(List<PurOrderSummary> orders, string productName)
        {
            this.Text = "Order History For [" + productName + "]";
            Dictionary<VendorId, Vendor> vendorDict = new Dictionary<VendorId, Vendor>();
            using (Ambient.DbSession.Activate())
            {
                List<Vendor> allVendors = OrderingRepositories.Vendor.GetAll();
                foreach (Vendor vendor in allVendors)
                {
                    vendorDict.Add(vendor.Id, vendor);
                }
            }
            lvwOrders.Items.Clear();
            foreach (PurOrderSummary sum in orders)
            {
                ListViewItem item = new ListViewItem(vendorDict[sum.VendorId].VendorName);
                item.SubItems.Add(sum.OrderDate.ToShortDateString());
                item.SubItems.Add(sum.EachesEquivalent.ToString());
                lvwOrders.Items.Add(item);
                if (lvwOrders.Items.Count > 200)
                {
                    break;
                }
            }
            ShowDialog();
        }
    }
}
