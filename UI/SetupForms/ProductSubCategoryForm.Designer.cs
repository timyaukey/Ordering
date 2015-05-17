namespace Willowsoft.Ordering.UI.SetupForms
{
    partial class ProductSubCategoryForm
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
            this.grdSubCategories = new System.Windows.Forms.DataGridView();
            this.subcategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnShowUsages = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subcategoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSubCategories
            // 
            this.grdSubCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSubCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSubCategories.Location = new System.Drawing.Point(12, 12);
            this.grdSubCategories.Name = "grdSubCategories";
            this.grdSubCategories.Size = new System.Drawing.Size(780, 380);
            this.grdSubCategories.TabIndex = 0;
            // 
            // btnShowUsages
            // 
            this.btnShowUsages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowUsages.Location = new System.Drawing.Point(597, 398);
            this.btnShowUsages.Name = "btnShowUsages";
            this.btnShowUsages.Size = new System.Drawing.Size(195, 23);
            this.btnShowUsages.TabIndex = 1;
            this.btnShowUsages.Text = "Show Subcategory Usage";
            this.btnShowUsages.UseVisualStyleBackColor = true;
            this.btnShowUsages.Click += new System.EventHandler(this.btnShowUsages_Click);
            // 
            // ProductSubCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 433);
            this.Controls.Add(this.btnShowUsages);
            this.Controls.Add(this.grdSubCategories);
            this.Name = "ProductSubCategoryForm";
            this.Text = "Product Subcategories";
            this.Load += new System.EventHandler(this.ProductSubCategoryForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProductSubCategoryForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.grdSubCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subcategoryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdSubCategories;
        private System.Windows.Forms.BindingSource subcategoryBindingSource;
        private System.Windows.Forms.Button btnShowUsages;
    }
}