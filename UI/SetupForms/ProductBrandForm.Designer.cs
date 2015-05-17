namespace Willowsoft.Ordering.UI.SetupForms
{
    partial class ProductBrandForm
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
            this.grdBrands = new System.Windows.Forms.DataGridView();
            this.brandBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnShowUsage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdBrands)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brandBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grdBrands
            // 
            this.grdBrands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBrands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBrands.Location = new System.Drawing.Point(12, 12);
            this.grdBrands.Name = "grdBrands";
            this.grdBrands.Size = new System.Drawing.Size(633, 369);
            this.grdBrands.TabIndex = 0;
            // 
            // btnShowUsage
            // 
            this.btnShowUsage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowUsage.Location = new System.Drawing.Point(457, 387);
            this.btnShowUsage.Name = "btnShowUsage";
            this.btnShowUsage.Size = new System.Drawing.Size(188, 23);
            this.btnShowUsage.TabIndex = 1;
            this.btnShowUsage.Text = "Show Brand Usage";
            this.btnShowUsage.UseVisualStyleBackColor = true;
            this.btnShowUsage.Click += new System.EventHandler(this.btnShowUsage_Click);
            // 
            // ProductBrandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 422);
            this.Controls.Add(this.btnShowUsage);
            this.Controls.Add(this.grdBrands);
            this.Name = "ProductBrandForm";
            this.Text = "Product Brands";
            this.Load += new System.EventHandler(this.ProductBrandForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProductBrandForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.grdBrands)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brandBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdBrands;
        private System.Windows.Forms.BindingSource brandBindingSource;
        private System.Windows.Forms.Button btnShowUsage;
    }
}