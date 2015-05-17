namespace Willowsoft.Ordering.UI
{
    partial class MDIMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIMain));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportProductsForVendorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportVendorsForProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsForCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendorProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webHarvestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productCategoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productSubcategoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productBrandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.orderingToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.listsToolStripMenuItem,
            this.windowsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.MdiWindowListItem = this.windowsToolStripMenuItem;
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(754, 24);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.importToolStripMenuItem.Text = "Import Products";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // orderingToolStripMenuItem
            // 
            this.orderingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderListToolStripMenuItem});
            this.orderingToolStripMenuItem.Name = "orderingToolStripMenuItem";
            this.orderingToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.orderingToolStripMenuItem.Text = "Ordering";
            // 
            // orderListToolStripMenuItem
            // 
            this.orderListToolStripMenuItem.Name = "orderListToolStripMenuItem";
            this.orderListToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.orderListToolStripMenuItem.Text = "Order List";
            this.orderListToolStripMenuItem.Click += new System.EventHandler(this.orderListToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportProductsForVendorToolStripMenuItem,
            this.reportVendorsForProductToolStripMenuItem,
            this.productsForCategoryToolStripMenuItem,
            this.openOrdersToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // reportProductsForVendorToolStripMenuItem
            // 
            this.reportProductsForVendorToolStripMenuItem.Name = "reportProductsForVendorToolStripMenuItem";
            this.reportProductsForVendorToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.reportProductsForVendorToolStripMenuItem.Text = "Products For Vendor";
            // 
            // reportVendorsForProductToolStripMenuItem
            // 
            this.reportVendorsForProductToolStripMenuItem.Name = "reportVendorsForProductToolStripMenuItem";
            this.reportVendorsForProductToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.reportVendorsForProductToolStripMenuItem.Text = "Vendors For Product";
            // 
            // productsForCategoryToolStripMenuItem
            // 
            this.productsForCategoryToolStripMenuItem.Name = "productsForCategoryToolStripMenuItem";
            this.productsForCategoryToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.productsForCategoryToolStripMenuItem.Text = "Products For Category";
            // 
            // openOrdersToolStripMenuItem
            // 
            this.openOrdersToolStripMenuItem.Name = "openOrdersToolStripMenuItem";
            this.openOrdersToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.openOrdersToolStripMenuItem.Text = "Open Orders";
            // 
            // listsToolStripMenuItem
            // 
            this.listsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contactsToolStripMenuItem,
            this.vendorsToolStripMenuItem,
            this.vendorProductsToolStripMenuItem,
            this.webHarvestToolStripMenuItem,
            this.productCategoriesToolStripMenuItem,
            this.productSubcategoriesToolStripMenuItem,
            this.productBrandsToolStripMenuItem});
            this.listsToolStripMenuItem.Name = "listsToolStripMenuItem";
            this.listsToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.listsToolStripMenuItem.Text = "Setup";
            // 
            // contactsToolStripMenuItem
            // 
            this.contactsToolStripMenuItem.Name = "contactsToolStripMenuItem";
            this.contactsToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.contactsToolStripMenuItem.Text = "Contacts";
            this.contactsToolStripMenuItem.Click += new System.EventHandler(this.contactsToolStripMenuItem_Click);
            // 
            // vendorsToolStripMenuItem
            // 
            this.vendorsToolStripMenuItem.Name = "vendorsToolStripMenuItem";
            this.vendorsToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.vendorsToolStripMenuItem.Text = "Vendors";
            this.vendorsToolStripMenuItem.Click += new System.EventHandler(this.vendorsToolStripMenuItem_Click);
            // 
            // vendorProductsToolStripMenuItem
            // 
            this.vendorProductsToolStripMenuItem.Name = "vendorProductsToolStripMenuItem";
            this.vendorProductsToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.vendorProductsToolStripMenuItem.Text = "Vendor Products";
            this.vendorProductsToolStripMenuItem.Click += new System.EventHandler(this.vendorProductsToolStripMenuItem_Click);
            // 
            // webHarvestToolStripMenuItem
            // 
            this.webHarvestToolStripMenuItem.Name = "webHarvestToolStripMenuItem";
            this.webHarvestToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.webHarvestToolStripMenuItem.Text = "Extract Vendor Products From Web";
            this.webHarvestToolStripMenuItem.Click += new System.EventHandler(this.webHarvestToolStripMenuItem_Click);
            // 
            // productCategoriesToolStripMenuItem
            // 
            this.productCategoriesToolStripMenuItem.Name = "productCategoriesToolStripMenuItem";
            this.productCategoriesToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.productCategoriesToolStripMenuItem.Text = "Product Categories";
            this.productCategoriesToolStripMenuItem.Click += new System.EventHandler(this.productCategoriesToolStripMenuItem_Click);
            // 
            // productSubcategoriesToolStripMenuItem
            // 
            this.productSubcategoriesToolStripMenuItem.Name = "productSubcategoriesToolStripMenuItem";
            this.productSubcategoriesToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.productSubcategoriesToolStripMenuItem.Text = "Product Subcategories";
            this.productSubcategoriesToolStripMenuItem.Click += new System.EventHandler(this.productSubcategoriesToolStripMenuItem_Click);
            // 
            // productBrandsToolStripMenuItem
            // 
            this.productBrandsToolStripMenuItem.Name = "productBrandsToolStripMenuItem";
            this.productBrandsToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.productBrandsToolStripMenuItem.Text = "Product Brands";
            this.productBrandsToolStripMenuItem.Click += new System.EventHandler(this.productBrandsToolStripMenuItem_Click);
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.windowsToolStripMenuItem.Text = "Windows";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // MDIMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 500);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "MDIMain";
            this.Text = "Product Ordering System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportProductsForVendorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productCategoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productSubcategoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productBrandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportVendorsForProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsForCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendorProductsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webHarvestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}

