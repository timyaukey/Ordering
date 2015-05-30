using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
//using Willowsoft.WillowLib.Data.Misc;
//using Willowsoft.WillowLib.Data.Sql;
using Willowsoft.Ordering.Core.Entities;

namespace JoinWrapperGenerators
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnGenJoinVpToProd_Click(object sender, EventArgs e)
        {
            Willowsoft.WillowLib.CodeGenUI.PersistableWrapperGenerator gen =
                new Willowsoft.WillowLib.CodeGenUI.PersistableWrapperGenerator("JoinVpToProd");
            gen.Add(typeof(VendorProduct));
            gen.Add(typeof(Product));
            gen.GenerateToClipboard();
            MessageBox.Show("JoinVpToProd source code saved to clipboard.");
        }

        private void btnGenJoinPlToVpToProd_Click(object sender, EventArgs e)
        {
            Willowsoft.WillowLib.CodeGenUI.PersistableWrapperGenerator gen =
                new Willowsoft.WillowLib.CodeGenUI.PersistableWrapperGenerator("JoinPlToVpToProd");
            gen.Add(typeof(PurLine));
            gen.Add(typeof(VendorProduct));
            gen.Add(typeof(Product));
            gen.GenerateToClipboard();
            MessageBox.Show("JoinPlToVpToProd source code saved to clipboard.");
        }
    }
}
