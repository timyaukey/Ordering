namespace Willowsoft.Ordering.UI.SetupForms
{
    partial class VendorProductForm
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
            this.grdMain = new System.Windows.Forms.DataGridView();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblVendor = new System.Windows.Forms.Label();
            this.cboVendor = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.btnLoadProducts = new System.Windows.Forms.Button();
            this.btnUseExistingProduct = new System.Windows.Forms.Button();
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnShowOrdersUsedBy = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.txtFreightPercent = new System.Windows.Forms.TextBox();
            this.lblFreightPercent = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.chkShowInactive = new System.Windows.Forms.CheckBox();
            this.chkShowDeleted = new System.Windows.Forms.CheckBox();
            this.chkShowAllSubcats = new System.Windows.Forms.CheckBox();
            this.btnRefreshOrders = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grdMain
            // 
            this.grdMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMain.Location = new System.Drawing.Point(12, 56);
            this.grdMain.Name = "grdMain";
            this.grdMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdMain.Size = new System.Drawing.Size(1022, 337);
            this.grdMain.TabIndex = 11;
            this.grdMain.Visible = false;
            // 
            // bindingSource
            // 
            this.bindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.bindingSource_AddingNew);
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(12, 9);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(44, 13);
            this.lblVendor.TabIndex = 0;
            this.lblVendor.Text = "Vendor:";
            // 
            // cboVendor
            // 
            this.cboVendor.FormattingEnabled = true;
            this.cboVendor.Location = new System.Drawing.Point(62, 6);
            this.cboVendor.Name = "cboVendor";
            this.cboVendor.Size = new System.Drawing.Size(200, 21);
            this.cboVendor.TabIndex = 1;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(268, 9);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(92, 13);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Product Category:";
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(366, 6);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(169, 21);
            this.cboCategory.TabIndex = 3;
            // 
            // btnLoadProducts
            // 
            this.btnLoadProducts.Location = new System.Drawing.Point(541, 4);
            this.btnLoadProducts.Name = "btnLoadProducts";
            this.btnLoadProducts.Size = new System.Drawing.Size(115, 23);
            this.btnLoadProducts.TabIndex = 4;
            this.btnLoadProducts.Text = "Show Products";
            this.btnLoadProducts.UseVisualStyleBackColor = true;
            this.btnLoadProducts.Click += new System.EventHandler(this.btnLoadProducts_Click);
            // 
            // btnUseExistingProduct
            // 
            this.btnUseExistingProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUseExistingProduct.Location = new System.Drawing.Point(12, 429);
            this.btnUseExistingProduct.Name = "btnUseExistingProduct";
            this.btnUseExistingProduct.Size = new System.Drawing.Size(226, 23);
            this.btnUseExistingProduct.TabIndex = 14;
            this.btnUseExistingProduct.Text = "Use Existing Product Of This Brand";
            this.btnUseExistingProduct.UseVisualStyleBackColor = true;
            this.btnUseExistingProduct.Visible = false;
            this.btnUseExistingProduct.Click += new System.EventHandler(this.btnUseExistingProduct_Click);
            // 
            // cboBrand
            // 
            this.cboBrand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboBrand.FormattingEnabled = true;
            this.cboBrand.Location = new System.Drawing.Point(53, 401);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(185, 21);
            this.cboBrand.TabIndex = 13;
            this.cboBrand.Visible = false;
            // 
            // lblBrand
            // 
            this.lblBrand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(9, 404);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(38, 13);
            this.lblBrand.TabIndex = 12;
            this.lblBrand.Text = "Brand:";
            this.lblBrand.Visible = false;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(797, 429);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(115, 23);
            this.btnImport.TabIndex = 19;
            this.btnImport.Text = "Import For Vendor";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Visible = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnShowOrdersUsedBy
            // 
            this.btnShowOrdersUsedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowOrdersUsedBy.Location = new System.Drawing.Point(918, 399);
            this.btnShowOrdersUsedBy.Name = "btnShowOrdersUsedBy";
            this.btnShowOrdersUsedBy.Size = new System.Drawing.Size(116, 23);
            this.btnShowOrdersUsedBy.TabIndex = 18;
            this.btnShowOrdersUsedBy.Text = "Purchase History";
            this.btnShowOrdersUsedBy.UseVisualStyleBackColor = true;
            this.btnShowOrdersUsedBy.Visible = false;
            this.btnShowOrdersUsedBy.Click += new System.EventHandler(this.btnShowOrdersUsedBy_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(849, 4);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(72, 23);
            this.btnFilter.TabIndex = 6;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Visible = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Location = new System.Drawing.Point(927, 4);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(72, 23);
            this.btnClearFilter.TabIndex = 7;
            this.btnClearFilter.Text = "Clear Filter";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Visible = false;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(717, 6);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(126, 20);
            this.txtFilter.TabIndex = 5;
            this.txtFilter.Visible = false;
            // 
            // txtFreightPercent
            // 
            this.txtFreightPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFreightPercent.Location = new System.Drawing.Point(693, 401);
            this.txtFreightPercent.Name = "txtFreightPercent";
            this.txtFreightPercent.Size = new System.Drawing.Size(41, 20);
            this.txtFreightPercent.TabIndex = 16;
            this.txtFreightPercent.Text = "0.0";
            this.txtFreightPercent.Visible = false;
            this.txtFreightPercent.TextChanged += new System.EventHandler(this.txtFreightPercent_TextChanged);
            this.txtFreightPercent.Leave += new System.EventHandler(this.txtFreightPercent_Leave);
            // 
            // lblFreightPercent
            // 
            this.lblFreightPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFreightPercent.AutoSize = true;
            this.lblFreightPercent.Location = new System.Drawing.Point(605, 404);
            this.lblFreightPercent.Name = "lblFreightPercent";
            this.lblFreightPercent.Size = new System.Drawing.Size(82, 13);
            this.lblFreightPercent.TabIndex = 15;
            this.lblFreightPercent.Text = "Freight Percent:";
            this.lblFreightPercent.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(797, 399);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(115, 23);
            this.btnPrint.TabIndex = 17;
            this.btnPrint.Text = "Print Products";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // chkShowInactive
            // 
            this.chkShowInactive.AutoSize = true;
            this.chkShowInactive.Location = new System.Drawing.Point(62, 33);
            this.chkShowInactive.Name = "chkShowInactive";
            this.chkShowInactive.Size = new System.Drawing.Size(139, 17);
            this.chkShowInactive.TabIndex = 8;
            this.chkShowInactive.Text = "Show Inactive Products";
            this.chkShowInactive.UseVisualStyleBackColor = true;
            // 
            // chkShowDeleted
            // 
            this.chkShowDeleted.AutoSize = true;
            this.chkShowDeleted.Location = new System.Drawing.Point(366, 33);
            this.chkShowDeleted.Name = "chkShowDeleted";
            this.chkShowDeleted.Size = new System.Drawing.Size(138, 17);
            this.chkShowDeleted.TabIndex = 9;
            this.chkShowDeleted.Text = "Show Deleted Products";
            this.chkShowDeleted.UseVisualStyleBackColor = true;
            // 
            // chkShowAllSubcats
            // 
            this.chkShowAllSubcats.AutoSize = true;
            this.chkShowAllSubcats.Location = new System.Drawing.Point(717, 33);
            this.chkShowAllSubcats.Name = "chkShowAllSubcats";
            this.chkShowAllSubcats.Size = new System.Drawing.Size(136, 17);
            this.chkShowAllSubcats.TabIndex = 10;
            this.chkShowAllSubcats.Text = "Allow All Subcategories";
            this.chkShowAllSubcats.UseVisualStyleBackColor = true;
            // 
            // btnRefreshOrders
            // 
            this.btnRefreshOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshOrders.Location = new System.Drawing.Point(918, 429);
            this.btnRefreshOrders.Name = "btnRefreshOrders";
            this.btnRefreshOrders.Size = new System.Drawing.Size(116, 23);
            this.btnRefreshOrders.TabIndex = 20;
            this.btnRefreshOrders.Text = "Refresh Orders";
            this.btnRefreshOrders.UseVisualStyleBackColor = true;
            this.btnRefreshOrders.Visible = false;
            this.btnRefreshOrders.Click += new System.EventHandler(this.btnRefreshOrders_Click);
            // 
            // VendorProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 464);
            this.Controls.Add(this.btnRefreshOrders);
            this.Controls.Add(this.chkShowAllSubcats);
            this.Controls.Add(this.chkShowDeleted);
            this.Controls.Add(this.chkShowInactive);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblFreightPercent);
            this.Controls.Add(this.txtFreightPercent);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.btnClearFilter);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnShowOrdersUsedBy);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.cboBrand);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.btnUseExistingProduct);
            this.Controls.Add(this.btnLoadProducts);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cboVendor);
            this.Controls.Add(this.lblVendor);
            this.Controls.Add(this.grdMain);
            this.Name = "VendorProductForm";
            this.Text = "Products by Vendor and Category";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VendorProductForm_FormClosed);
            this.Load += new System.EventHandler(this.VendorProductForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdMain;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.ComboBox cboVendor;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Button btnLoadProducts;
        private System.Windows.Forms.Button btnUseExistingProduct;
        private System.Windows.Forms.ComboBox cboBrand;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnShowOrdersUsedBy;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.TextBox txtFreightPercent;
        private System.Windows.Forms.Label lblFreightPercent;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.CheckBox chkShowInactive;
        private System.Windows.Forms.CheckBox chkShowDeleted;
        private System.Windows.Forms.CheckBox chkShowAllSubcats;
        private System.Windows.Forms.Button btnRefreshOrders;
    }
}