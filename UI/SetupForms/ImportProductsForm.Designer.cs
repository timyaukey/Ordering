namespace Willowsoft.Ordering.UI.SetupForms
{
    partial class ImportProductsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportProductsForm));
            this.lblVendor = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblExplain = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.lvwNewProducts = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVendorCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRetail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCsCost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCsSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEaCost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBrand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubCat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBarcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnReadClipboard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(12, 9);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(75, 13);
            this.lblVendor.TabIndex = 0;
            this.lblVendor.Text = "(vendor name)";
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(837, 484);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(166, 23);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "Create/Update Products";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblExplain
            // 
            this.lblExplain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExplain.Location = new System.Drawing.Point(490, 13);
            this.lblExplain.Name = "lblExplain";
            this.lblExplain.Size = new System.Drawing.Size(513, 84);
            this.lblExplain.TabIndex = 1;
            this.lblExplain.Text = resources.GetString("lblExplain.Text");
            // 
            // btnEnter
            // 
            this.btnEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnter.Location = new System.Drawing.Point(654, 484);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(177, 23);
            this.btnEnter.TabIndex = 4;
            this.btnEnter.Text = "Enter Product Information";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // lvwNewProducts
            // 
            this.lvwNewProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwNewProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colSize,
            this.colVendorCode,
            this.colRetail,
            this.colCsCost,
            this.colCsSize,
            this.colEaCost,
            this.colBrand,
            this.colSubCat,
            this.colIsActive,
            this.colBarcode,
            this.colModel});
            this.lvwNewProducts.FullRowSelect = true;
            this.lvwNewProducts.GridLines = true;
            this.lvwNewProducts.HideSelection = false;
            this.lvwNewProducts.Location = new System.Drawing.Point(15, 118);
            this.lvwNewProducts.Name = "lvwNewProducts";
            this.lvwNewProducts.Size = new System.Drawing.Size(988, 360);
            this.lvwNewProducts.TabIndex = 2;
            this.lvwNewProducts.UseCompatibleStateImageBehavior = false;
            this.lvwNewProducts.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 200;
            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            // 
            // colVendorCode
            // 
            this.colVendorCode.Text = "Vendor Code";
            this.colVendorCode.Width = 80;
            // 
            // colRetail
            // 
            this.colRetail.Text = "Retail";
            this.colRetail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colRetail.Width = 50;
            // 
            // colCsCost
            // 
            this.colCsCost.Text = "Cs Cost";
            this.colCsCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCsCost.Width = 50;
            // 
            // colCsSize
            // 
            this.colCsSize.Text = "Cs Size";
            this.colCsSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCsSize.Width = 50;
            // 
            // colEaCost
            // 
            this.colEaCost.Text = "Ea Cost";
            this.colEaCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colEaCost.Width = 50;
            // 
            // colBrand
            // 
            this.colBrand.Text = "Brand";
            this.colBrand.Width = 100;
            // 
            // colSubCat
            // 
            this.colSubCat.Text = "Subcategory";
            this.colSubCat.Width = 100;
            // 
            // colBarcode
            // 
            this.colBarcode.Text = "Barcode";
            this.colBarcode.Width = 100;
            // 
            // colModel
            // 
            this.colModel.Text = "Model";
            // 
            // colIsActive
            // 
            this.colIsActive.Text = "Is Active";
            // 
            // btnReadClipboard
            // 
            this.btnReadClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadClipboard.Location = new System.Drawing.Point(480, 484);
            this.btnReadClipboard.Name = "btnReadClipboard";
            this.btnReadClipboard.Size = new System.Drawing.Size(168, 23);
            this.btnReadClipboard.TabIndex = 3;
            this.btnReadClipboard.Text = "Read From Clipboard";
            this.btnReadClipboard.UseVisualStyleBackColor = true;
            this.btnReadClipboard.Click += new System.EventHandler(this.btnReadClipboard_Click);
            // 
            // ImportProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 519);
            this.Controls.Add(this.btnReadClipboard);
            this.Controls.Add(this.lvwNewProducts);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.lblExplain);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lblVendor);
            this.Name = "ImportProductsForm";
            this.Text = "Import Products";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblExplain;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.ListView lvwNewProducts;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ColumnHeader colVendorCode;
        private System.Windows.Forms.ColumnHeader colRetail;
        private System.Windows.Forms.ColumnHeader colCsCost;
        private System.Windows.Forms.ColumnHeader colCsSize;
        private System.Windows.Forms.ColumnHeader colEaCost;
        private System.Windows.Forms.ColumnHeader colBrand;
        private System.Windows.Forms.ColumnHeader colSubCat;
        private System.Windows.Forms.ColumnHeader colIsActive;
        private System.Windows.Forms.Button btnReadClipboard;
        private System.Windows.Forms.ColumnHeader colBarcode;
        private System.Windows.Forms.ColumnHeader colModel;
    }
}