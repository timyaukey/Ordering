using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using Willowsoft.Ordering.UI.SetupForms;
using Willowsoft.Ordering.UI.Reports;

namespace Willowsoft.Ordering.UI
{
    public partial class MDIMain : Form
    {
        public MDIMain()
        {
            InitializeComponent();
            Assembly asm = Assembly.GetExecutingAssembly();
            string version = asm.GetName().Version.ToString();
            this.Text = this.Text + "  " + version;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactForm.Show(this);
        }

        private void vendorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VendorForm.Show(this);
        }

        private void productBrandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductBrandForm.Show(this);
        }

        private void productCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductCategoryForm.Show(this);
        }

        private void productSubcategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductSubCategoryForm.Show(this);
        }

        private void vendorProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VendorProductForm.Show(this);
        }

        private void webHarvestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductWebHarvestForm.Show(this);
        }

        private void orderListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurOrderForm.Show(this);
        }

        private PurLineForm GetCurrentPurLineForm()
        {
            if (this.ActiveMdiChild is PurLineForm)
                return (this.ActiveMdiChild as PurLineForm);
            MessageBox.Show("This option is only available when the current window is an order detail window.",
                "Not An Order");
            return null;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(
                Path.Combine(Application.StartupPath, "Help.html"));
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
        }
    }
}
