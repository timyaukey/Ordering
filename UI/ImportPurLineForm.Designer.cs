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
            this.dlgSelectFile = new System.Windows.Forms.OpenFileDialog();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.lblSelectedFile = new System.Windows.Forms.Label();
            this.cboDefaultSubCat = new System.Windows.Forms.ComboBox();
            this.lblDefaultSubCat = new System.Windows.Forms.Label();
            this.lblDefaultBrand = new System.Windows.Forms.Label();
            this.cboDefaultBrand = new System.Windows.Forms.ComboBox();
            this.btnImportFile = new System.Windows.Forms.Button();
            this.lblFileFormat = new System.Windows.Forms.Label();
            this.cboFileFormat = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(12, 12);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(111, 23);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // lblSelectedFile
            // 
            this.lblSelectedFile.AutoSize = true;
            this.lblSelectedFile.Location = new System.Drawing.Point(13, 43);
            this.lblSelectedFile.Name = "lblSelectedFile";
            this.lblSelectedFile.Size = new System.Drawing.Size(69, 13);
            this.lblSelectedFile.TabIndex = 1;
            this.lblSelectedFile.Text = "(selected file)";
            // 
            // cboDefaultSubCat
            // 
            this.cboDefaultSubCat.DisplayMember = "ProductSubcategoryId";
            this.cboDefaultSubCat.FormattingEnabled = true;
            this.cboDefaultSubCat.Location = new System.Drawing.Point(146, 71);
            this.cboDefaultSubCat.Name = "cboDefaultSubCat";
            this.cboDefaultSubCat.Size = new System.Drawing.Size(256, 21);
            this.cboDefaultSubCat.TabIndex = 3;
            this.cboDefaultSubCat.ValueMember = "ProductSubCategoryId";
            // 
            // lblDefaultSubCat
            // 
            this.lblDefaultSubCat.AutoSize = true;
            this.lblDefaultSubCat.Location = new System.Drawing.Point(10, 74);
            this.lblDefaultSubCat.Name = "lblDefaultSubCat";
            this.lblDefaultSubCat.Size = new System.Drawing.Size(107, 13);
            this.lblDefaultSubCat.TabIndex = 2;
            this.lblDefaultSubCat.Text = "Default Subcategory:";
            // 
            // lblDefaultBrand
            // 
            this.lblDefaultBrand.AutoSize = true;
            this.lblDefaultBrand.Location = new System.Drawing.Point(10, 101);
            this.lblDefaultBrand.Name = "lblDefaultBrand";
            this.lblDefaultBrand.Size = new System.Drawing.Size(75, 13);
            this.lblDefaultBrand.TabIndex = 4;
            this.lblDefaultBrand.Text = "Default Brand:";
            // 
            // cboDefaultBrand
            // 
            this.cboDefaultBrand.DisplayMember = "ProductBrandId";
            this.cboDefaultBrand.FormattingEnabled = true;
            this.cboDefaultBrand.Location = new System.Drawing.Point(146, 98);
            this.cboDefaultBrand.Name = "cboDefaultBrand";
            this.cboDefaultBrand.Size = new System.Drawing.Size(256, 21);
            this.cboDefaultBrand.TabIndex = 5;
            this.cboDefaultBrand.ValueMember = "ProductBrandId";
            // 
            // btnImportFile
            // 
            this.btnImportFile.Location = new System.Drawing.Point(12, 181);
            this.btnImportFile.Name = "btnImportFile";
            this.btnImportFile.Size = new System.Drawing.Size(117, 23);
            this.btnImportFile.TabIndex = 8;
            this.btnImportFile.Text = "Import File";
            this.btnImportFile.UseVisualStyleBackColor = true;
            this.btnImportFile.Click += new System.EventHandler(this.btnImportFile_Click);
            // 
            // lblFileFormat
            // 
            this.lblFileFormat.AutoSize = true;
            this.lblFileFormat.Location = new System.Drawing.Point(10, 128);
            this.lblFileFormat.Name = "lblFileFormat";
            this.lblFileFormat.Size = new System.Drawing.Size(61, 13);
            this.lblFileFormat.TabIndex = 6;
            this.lblFileFormat.Text = "File Format:";
            // 
            // cboFileFormat
            // 
            this.cboFileFormat.FormattingEnabled = true;
            this.cboFileFormat.Location = new System.Drawing.Point(146, 125);
            this.cboFileFormat.Name = "cboFileFormat";
            this.cboFileFormat.Size = new System.Drawing.Size(256, 21);
            this.cboFileFormat.TabIndex = 7;
            // 
            // ImportPurLineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 216);
            this.Controls.Add(this.lblFileFormat);
            this.Controls.Add(this.cboFileFormat);
            this.Controls.Add(this.btnImportFile);
            this.Controls.Add(this.lblDefaultBrand);
            this.Controls.Add(this.cboDefaultBrand);
            this.Controls.Add(this.lblDefaultSubCat);
            this.Controls.Add(this.cboDefaultSubCat);
            this.Controls.Add(this.lblSelectedFile);
            this.Controls.Add(this.btnSelectFile);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportPurLineForm";
            this.Text = "Import Order Lines";
            this.Load += new System.EventHandler(this.ImportPurLineForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog dlgSelectFile;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label lblSelectedFile;
        private System.Windows.Forms.ComboBox cboDefaultSubCat;
        private System.Windows.Forms.Label lblDefaultSubCat;
        private System.Windows.Forms.Label lblDefaultBrand;
        private System.Windows.Forms.ComboBox cboDefaultBrand;
        private System.Windows.Forms.Button btnImportFile;
        private System.Windows.Forms.Label lblFileFormat;
        private System.Windows.Forms.ComboBox cboFileFormat;
    }
}