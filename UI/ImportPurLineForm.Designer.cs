namespace Willowsoft.Ordering.UI
{
    partial class ImportPurLineForm
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
            this.btnCreateOrderLines = new System.Windows.Forms.Button();
            this.btnReadClipboard = new System.Windows.Forms.Button();
            this.lvwImportLines = new System.Windows.Forms.ListView();
            this.colOnHand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBrand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVendorCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOrdered = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOrderEaches = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEachCost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCaseCost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCaseSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnCreateOrderLines
            // 
            this.btnCreateOrderLines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateOrderLines.Location = new System.Drawing.Point(1074, 493);
            this.btnCreateOrderLines.Name = "btnCreateOrderLines";
            this.btnCreateOrderLines.Size = new System.Drawing.Size(117, 23);
            this.btnCreateOrderLines.TabIndex = 8;
            this.btnCreateOrderLines.Text = "Create Order Lines";
            this.btnCreateOrderLines.UseVisualStyleBackColor = true;
            this.btnCreateOrderLines.Click += new System.EventHandler(this.btnCreateOrderLines_Click);
            // 
            // btnReadClipboard
            // 
            this.btnReadClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadClipboard.Location = new System.Drawing.Point(951, 493);
            this.btnReadClipboard.Name = "btnReadClipboard";
            this.btnReadClipboard.Size = new System.Drawing.Size(117, 23);
            this.btnReadClipboard.TabIndex = 9;
            this.btnReadClipboard.Text = "Read Clipboard";
            this.btnReadClipboard.UseVisualStyleBackColor = true;
            this.btnReadClipboard.Click += new System.EventHandler(this.btnReadClipboard_Click);
            // 
            // lvwImportLines
            // 
            this.lvwImportLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwImportLines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOnHand,
            this.colSubCategory,
            this.colBrand,
            this.colProductName,
            this.colSize,
            this.colModel,
            this.colVendorCode,
            this.colOrdered,
            this.colOrderEaches,
            this.colEachCost,
            this.colCaseCost,
            this.colCaseSize});
            this.lvwImportLines.FullRowSelect = true;
            this.lvwImportLines.HideSelection = false;
            this.lvwImportLines.Location = new System.Drawing.Point(12, 12);
            this.lvwImportLines.Name = "lvwImportLines";
            this.lvwImportLines.Size = new System.Drawing.Size(1179, 475);
            this.lvwImportLines.TabIndex = 10;
            this.lvwImportLines.UseCompatibleStateImageBehavior = false;
            this.lvwImportLines.View = System.Windows.Forms.View.Details;
            // 
            // colOnHand
            // 
            this.colOnHand.Text = "Onh";
            // 
            // colSubCategory
            // 
            this.colSubCategory.Text = "Subcat";
            this.colSubCategory.Width = 120;
            // 
            // colBrand
            // 
            this.colBrand.Text = "Brd";
            this.colBrand.Width = 120;
            // 
            // colProductName
            // 
            this.colProductName.Text = "ProdName";
            this.colProductName.Width = 300;
            // 
            // colSize
            // 
            this.colSize.Text = "Siz";
            // 
            // colModel
            // 
            this.colModel.Text = "Ndl";
            // 
            // colVendorCode
            // 
            this.colVendorCode.Text = "VC";
            this.colVendorCode.Width = 80;
            // 
            // colOrdered
            // 
            this.colOrdered.Text = "Ord";
            this.colOrdered.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colOrderEaches
            // 
            this.colOrderEaches.Text = "OE";
            this.colOrderEaches.Width = 80;
            // 
            // colEachCost
            // 
            this.colEachCost.Text = "EaCs";
            this.colEachCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colEachCost.Width = 70;
            // 
            // colCaseCost
            // 
            this.colCaseCost.Text = "CsCst";
            this.colCaseCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCaseCost.Width = 70;
            // 
            // colCaseSize
            // 
            this.colCaseSize.Text = "CsSz";
            this.colCaseSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCaseSize.Width = 70;
            // 
            // ImportPurLineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 528);
            this.Controls.Add(this.lvwImportLines);
            this.Controls.Add(this.btnReadClipboard);
            this.Controls.Add(this.btnCreateOrderLines);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportPurLineForm";
            this.Text = "Import Order Lines";
            this.Load += new System.EventHandler(this.ImportPurLineForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCreateOrderLines;
        private System.Windows.Forms.Button btnReadClipboard;
        private System.Windows.Forms.ListView lvwImportLines;
        private System.Windows.Forms.ColumnHeader colOnHand;
        private System.Windows.Forms.ColumnHeader colSubCategory;
        private System.Windows.Forms.ColumnHeader colBrand;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ColumnHeader colModel;
        private System.Windows.Forms.ColumnHeader colOrdered;
        private System.Windows.Forms.ColumnHeader colOrderEaches;
        private System.Windows.Forms.ColumnHeader colVendorCode;
        private System.Windows.Forms.ColumnHeader colEachCost;
        private System.Windows.Forms.ColumnHeader colCaseCost;
        private System.Windows.Forms.ColumnHeader colCaseSize;
    }
}