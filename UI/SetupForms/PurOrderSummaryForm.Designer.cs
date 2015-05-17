namespace Willowsoft.Ordering.UI.SetupForms
{
    partial class PurOrderSummaryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvwOrders = new System.Windows.Forms.ListView();
            this.vendorHeader = new System.Windows.Forms.ColumnHeader();
            this.dateHeader = new System.Windows.Forms.ColumnHeader();
            this.eachesEquivalent = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvwOrders
            // 
            this.lvwOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.vendorHeader,
            this.dateHeader,
            this.eachesEquivalent});
            this.lvwOrders.FullRowSelect = true;
            this.lvwOrders.GridLines = true;
            this.lvwOrders.Location = new System.Drawing.Point(12, 12);
            this.lvwOrders.Name = "lvwOrders";
            this.lvwOrders.Size = new System.Drawing.Size(463, 287);
            this.lvwOrders.TabIndex = 0;
            this.lvwOrders.UseCompatibleStateImageBehavior = false;
            this.lvwOrders.View = System.Windows.Forms.View.Details;
            // 
            // vendorHeader
            // 
            this.vendorHeader.Text = "Vendor";
            this.vendorHeader.Width = 250;
            // 
            // dateHeader
            // 
            this.dateHeader.Text = "Order Date";
            this.dateHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dateHeader.Width = 85;
            // 
            // eachesEquivalent
            // 
            this.eachesEquivalent.Text = "Eaches Ordered";
            this.eachesEquivalent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.eachesEquivalent.Width = 94;
            // 
            // PurOrderSummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 311);
            this.Controls.Add(this.lvwOrders);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PurOrderSummaryForm";
            this.ShowInTaskbar = false;
            this.Text = "PurOrderSummaryForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwOrders;
        private System.Windows.Forms.ColumnHeader vendorHeader;
        private System.Windows.Forms.ColumnHeader dateHeader;
        private System.Windows.Forms.ColumnHeader eachesEquivalent;
    }
}