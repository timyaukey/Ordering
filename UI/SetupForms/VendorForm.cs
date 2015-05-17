using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Willowsoft.WillowLib.Data.Misc;
using Willowsoft.WillowLib.Data.Sql;
using Willowsoft.Ordering.Core.Entities;
using Willowsoft.Ordering.Core.Repositories;
using Willowsoft.Ordering.UI.Helpers;

namespace Willowsoft.Ordering.UI.SetupForms
{
    public partial class VendorForm : Form
    {
        private static Form mSingleton;
        private VendorGridHelper mHelper;

        public VendorForm()
        {
            InitializeComponent();
            mHelper = new VendorGridHelper(vendorBindingSource, grdVendors, this);
        }

        public static void Show(Form mdiParent)
        {
            if (mSingleton == null)
            {
                mSingleton = new VendorForm();
                mSingleton.MdiParent = mdiParent;
                mSingleton.Show();
            }
            else
            {
                mSingleton.Activate();
            }
        }

        private void VendorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mSingleton = null;
        }

        private void VendorForm_Load(object sender, EventArgs e)
        {
            VendorBindingList vendorList = new VendorBindingList();
            ContactBindingList contactList = new ContactBindingList();
            contactList.AddNew();
            using (Ambient.DbSession.Activate())
            {
                vendorList.Add(OrderingRepositories.Vendor.GetAll());
                contactList.Add(OrderingRepositories.Contact.GetAll());
            }
            mHelper.AddAllColumns(contactList);
            mHelper.DataSource = vendorList;
        }
    }
}
