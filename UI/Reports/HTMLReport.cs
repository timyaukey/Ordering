using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
//using Willowsoft.WillowLib.Data.Entity;
//using Willowsoft.WillowLib.Data.Misc;
//using Willowsoft.Ordering.Core.Entities;
//using Willowsoft.Ordering.Core.Repositories;

namespace Willowsoft.Ordering.UI.Reports
{
    public partial class HTMLReport : Form
    {
        public HTMLReport()
        {
            InitializeComponent();
        }

        public void Run(Form mdiParent)
        {
            this.MdiParent = mdiParent;
            this.Show();
        }

        private void HTMLOrderReport_Load(object sender, EventArgs e)
        {
            LoadData();
            StringWriter textWriter = new StringWriter();
            WriteContent(textWriter);
            webBrowser.DocumentText = textWriter.GetStringBuilder().ToString();
        }

        protected virtual void WriteContent(TextWriter textWriter)
        {
        }

        protected virtual void LoadData()
        {
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //webBrowser.ShowPrintDialog();
            webBrowser.ShowPrintPreviewDialog();
        }
    }
}
