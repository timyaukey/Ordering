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
    public partial class ContactForm : Form
    {
        private static Form mSingleton;
        private ContactGridHelper mHelper;

        public ContactForm()
        {
            InitializeComponent();
            mHelper = new ContactGridHelper(contactBindingSource, grdContacts, this);
        }

        public static void Show(Form mdiParent)
        {
            if (mSingleton == null)
            {
                mSingleton = new ContactForm();
                mSingleton.MdiParent = mdiParent;
                mSingleton.Show();
            }
            else
            {
                mSingleton.Activate();
            }
        }

        private void ContactForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mSingleton = null;
        }

        private void ContactForm_Load(object sender, EventArgs e)
        {
            ContactBindingList contactList = new ContactBindingList();
            using (Ambient.DbSession.Activate())
            {
                contactList.Add(OrderingRepositories.Contact.GetAll());
            }
            mHelper.AddAllColumns();
            mHelper.DataSource = contactList;
        }
    }
}
