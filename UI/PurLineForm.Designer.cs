namespace Willowsoft.Ordering.UI
{
    partial class PurLineForm
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
            this.components = new System.ComponentModel.Container();
            this.lineBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grdLines = new System.Windows.Forms.DataGridView();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.btnFindVendor = new System.Windows.Forms.Button();
            this.txtVendorCode = new System.Windows.Forms.TextBox();
            this.lblVendorCode = new System.Windows.Forms.Label();
            this.btnPurchaseHistory = new System.Windows.Forms.Button();
            this.btnCheckInReport = new System.Windows.Forms.Button();
            this.btnWorksheetReport = new System.Windows.Forms.Button();
            this.btnPOFaxReport = new System.Windows.Forms.Button();
            this.btnCreateProducts = new System.Windows.Forms.Button();
            this.btnSetSubcategories = new System.Windows.Forms.Button();
            this.btnSetBrands = new System.Windows.Forms.Button();
            this.btnImportOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lineBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLines)).BeginInit();
            this.SuspendLayout();
            // 
            // grdLines
            // 
            this.grdLines.AllowUserToResizeRows = false;
            this.grdLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLines.Location = new System.Drawing.Point(12, 12);
            this.grdLines.Name = "grdLines";
            this.grdLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLines.Size = new System.Drawing.Size(952, 489);
            this.grdLines.TabIndex = 0;
            this.grdLines.SelectionChanged += new System.EventHandler(this.grdLines_SelectionChanged);
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Location = new System.Drawing.Point(12, 542);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(56, 13);
            this.lblTotalCost.TabIndex = 7;
            this.lblTotalCost.Text = "(total cost)";
            // 
            // btnFindVendor
            // 
            this.btnFindVendor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindVendor.Location = new System.Drawing.Point(889, 536);
            this.btnFindVendor.Name = "btnFindVendor";
            this.btnFindVendor.Size = new System.Drawing.Size(75, 23);
            this.btnFindVendor.TabIndex = 12;
            this.btnFindVendor.Text = "Find";
            this.btnFindVendor.UseVisualStyleBackColor = true;
            this.btnFindVendor.Click += new System.EventHandler(this.btnFindVendor_Click);
            // 
            // txtVendorCode
            // 
            this.txtVendorCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVendorCode.Location = new System.Drawing.Point(764, 539);
            this.txtVendorCode.Name = "txtVendorCode";
            this.txtVendorCode.Size = new System.Drawing.Size(119, 20);
            this.txtVendorCode.TabIndex = 11;
            this.txtVendorCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVendorPart_KeyPress);
            // 
            // lblVendorCode
            // 
            this.lblVendorCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVendorCode.AutoSize = true;
            this.lblVendorCode.Location = new System.Drawing.Point(686, 542);
            this.lblVendorCode.Name = "lblVendorCode";
            this.lblVendorCode.Size = new System.Drawing.Size(72, 13);
            this.lblVendorCode.TabIndex = 10;
            this.lblVendorCode.Text = "Vendor &Code:";
            // 
            // btnPurchaseHistory
            // 
            this.btnPurchaseHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPurchaseHistory.Location = new System.Drawing.Point(555, 537);
            this.btnPurchaseHistory.Name = "btnPurchaseHistory";
            this.btnPurchaseHistory.Size = new System.Drawing.Size(116, 23);
            this.btnPurchaseHistory.TabIndex = 9;
            this.btnPurchaseHistory.Text = "Purchase History";
            this.btnPurchaseHistory.UseVisualStyleBackColor = true;
            this.btnPurchaseHistory.Click += new System.EventHandler(this.btnPurchaseHistory_Click);
            // 
            // btnCheckInReport
            // 
            this.btnCheckInReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckInReport.Location = new System.Drawing.Point(848, 507);
            this.btnCheckInReport.Name = "btnCheckInReport";
            this.btnCheckInReport.Size = new System.Drawing.Size(116, 23);
            this.btnCheckInReport.TabIndex = 6;
            this.btnCheckInReport.Text = "Check-In Report";
            this.btnCheckInReport.UseVisualStyleBackColor = true;
            this.btnCheckInReport.Click += new System.EventHandler(this.btnCheckInReport_Click);
            // 
            // btnWorksheetReport
            // 
            this.btnWorksheetReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWorksheetReport.Location = new System.Drawing.Point(726, 507);
            this.btnWorksheetReport.Name = "btnWorksheetReport";
            this.btnWorksheetReport.Size = new System.Drawing.Size(116, 23);
            this.btnWorksheetReport.TabIndex = 5;
            this.btnWorksheetReport.Text = "Worksheet Report";
            this.btnWorksheetReport.UseVisualStyleBackColor = true;
            this.btnWorksheetReport.Click += new System.EventHandler(this.btnWorksheetReport_Click);
            // 
            // btnPOFaxReport
            // 
            this.btnPOFaxReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPOFaxReport.Location = new System.Drawing.Point(555, 507);
            this.btnPOFaxReport.Name = "btnPOFaxReport";
            this.btnPOFaxReport.Size = new System.Drawing.Size(165, 23);
            this.btnPOFaxReport.TabIndex = 4;
            this.btnPOFaxReport.Text = "Purchase Order Fax Report";
            this.btnPOFaxReport.UseVisualStyleBackColor = true;
            this.btnPOFaxReport.Click += new System.EventHandler(this.btnPOFaxReport_Click);
            // 
            // btnCreateProducts
            // 
            this.btnCreateProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateProducts.Location = new System.Drawing.Point(433, 537);
            this.btnCreateProducts.Name = "btnCreateProducts";
            this.btnCreateProducts.Size = new System.Drawing.Size(116, 23);
            this.btnCreateProducts.TabIndex = 8;
            this.btnCreateProducts.Text = "Create Products";
            this.btnCreateProducts.UseVisualStyleBackColor = true;
            this.btnCreateProducts.Click += new System.EventHandler(this.btnCreateProducts_Click);
            // 
            // btnSetSubcategories
            // 
            this.btnSetSubcategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetSubcategories.Location = new System.Drawing.Point(311, 507);
            this.btnSetSubcategories.Name = "btnSetSubcategories";
            this.btnSetSubcategories.Size = new System.Drawing.Size(116, 23);
            this.btnSetSubcategories.TabIndex = 2;
            this.btnSetSubcategories.Text = "Set Subcategories";
            this.btnSetSubcategories.UseVisualStyleBackColor = true;
            this.btnSetSubcategories.Click += new System.EventHandler(this.btnSetSubcategories_Click);
            // 
            // btnSetBrands
            // 
            this.btnSetBrands.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetBrands.Location = new System.Drawing.Point(433, 507);
            this.btnSetBrands.Name = "btnSetBrands";
            this.btnSetBrands.Size = new System.Drawing.Size(116, 23);
            this.btnSetBrands.TabIndex = 3;
            this.btnSetBrands.Text = "Set Brands";
            this.btnSetBrands.UseVisualStyleBackColor = true;
            this.btnSetBrands.Click += new System.EventHandler(this.btnSetBrands_Click);
            // 
            // btnImportOrder
            // 
            this.btnImportOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportOrder.Location = new System.Drawing.Point(189, 507);
            this.btnImportOrder.Name = "btnImportOrder";
            this.btnImportOrder.Size = new System.Drawing.Size(116, 23);
            this.btnImportOrder.TabIndex = 1;
            this.btnImportOrder.Text = "Import Order";
            this.btnImportOrder.UseVisualStyleBackColor = true;
            this.btnImportOrder.Click += new System.EventHandler(this.btnImportOrder_Click);
            // 
            // PurLineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 568);
            this.Controls.Add(this.btnImportOrder);
            this.Controls.Add(this.btnSetBrands);
            this.Controls.Add(this.btnSetSubcategories);
            this.Controls.Add(this.btnCreateProducts);
            this.Controls.Add(this.btnPOFaxReport);
            this.Controls.Add(this.btnWorksheetReport);
            this.Controls.Add(this.btnCheckInReport);
            this.Controls.Add(this.btnPurchaseHistory);
            this.Controls.Add(this.lblVendorCode);
            this.Controls.Add(this.txtVendorCode);
            this.Controls.Add(this.btnFindVendor);
            this.Controls.Add(this.lblTotalCost);
            this.Controls.Add(this.grdLines);
            this.Name = "PurLineForm";
            this.Text = "PurLineForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PurLineForm_FormClosed);
            this.Load += new System.EventHandler(this.PurLineForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lineBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource lineBindingSource;
        private System.Windows.Forms.DataGridView grdLines;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Button btnFindVendor;
        private System.Windows.Forms.TextBox txtVendorCode;
        private System.Windows.Forms.Label lblVendorCode;
        private System.Windows.Forms.Button btnPurchaseHistory;
        private System.Windows.Forms.Button btnCheckInReport;
        private System.Windows.Forms.Button btnWorksheetReport;
        private System.Windows.Forms.Button btnPOFaxReport;
        private System.Windows.Forms.Button btnCreateProducts;
        private System.Windows.Forms.Button btnSetSubcategories;
        private System.Windows.Forms.Button btnSetBrands;
        private System.Windows.Forms.Button btnImportOrder;
    }
}