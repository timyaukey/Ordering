namespace Willowsoft.Ordering.UI.SetupForms
{
    partial class ProductWebHarvestForm
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
            this.ctlBrowser = new System.Windows.Forms.WebBrowser();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.chkExtractMode = new System.Windows.Forms.CheckBox();
            this.btnUndoSelect = new System.Windows.Forms.Button();
            this.txtVendorCode = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtBrandName = new System.Windows.Forms.TextBox();
            this.txtCasePrice = new System.Windows.Forms.TextBox();
            this.txtCaseSize = new System.Windows.Forms.TextBox();
            this.txtEachPrice = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkExtractSize = new System.Windows.Forms.CheckBox();
            this.chkExtractBrand = new System.Windows.Forms.CheckBox();
            this.lblProductCount = new System.Windows.Forms.Label();
            this.lblURL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctlBrowser
            // 
            this.ctlBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlBrowser.Location = new System.Drawing.Point(12, 38);
            this.ctlBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.ctlBrowser.Name = "ctlBrowser";
            this.ctlBrowser.ScriptErrorsSuppressed = true;
            this.ctlBrowser.Size = new System.Drawing.Size(856, 352);
            this.ctlBrowser.TabIndex = 5;
            this.ctlBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.ctlBrowser_Navigating);
            // 
            // txtURL
            // 
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.Location = new System.Drawing.Point(104, 12);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(597, 20);
            this.txtURL.TabIndex = 1;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(707, 10);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(788, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(37, 23);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "<<";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnForward
            // 
            this.btnForward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnForward.Location = new System.Drawing.Point(831, 10);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(37, 23);
            this.btnForward.TabIndex = 4;
            this.btnForward.Text = ">>";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // chkExtractMode
            // 
            this.chkExtractMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkExtractMode.AutoSize = true;
            this.chkExtractMode.Location = new System.Drawing.Point(12, 400);
            this.chkExtractMode.Name = "chkExtractMode";
            this.chkExtractMode.Size = new System.Drawing.Size(120, 17);
            this.chkExtractMode.TabIndex = 6;
            this.chkExtractMode.Text = "Extract Product Info";
            this.chkExtractMode.UseVisualStyleBackColor = true;
            this.chkExtractMode.CheckedChanged += new System.EventHandler(this.chkExtractMode_CheckedChanged);
            // 
            // btnUndoSelect
            // 
            this.btnUndoSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUndoSelect.Enabled = false;
            this.btnUndoSelect.Location = new System.Drawing.Point(161, 396);
            this.btnUndoSelect.Name = "btnUndoSelect";
            this.btnUndoSelect.Size = new System.Drawing.Size(103, 23);
            this.btnUndoSelect.TabIndex = 7;
            this.btnUndoSelect.Text = "&Undo Selection";
            this.btnUndoSelect.UseVisualStyleBackColor = true;
            this.btnUndoSelect.Click += new System.EventHandler(this.btnUndoSelect_Click);
            // 
            // txtVendorCode
            // 
            this.txtVendorCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtVendorCode.Location = new System.Drawing.Point(13, 424);
            this.txtVendorCode.Name = "txtVendorCode";
            this.txtVendorCode.Size = new System.Drawing.Size(96, 20);
            this.txtVendorCode.TabIndex = 12;
            this.txtVendorCode.Text = "Vendor Code";
            // 
            // txtProductName
            // 
            this.txtProductName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductName.Location = new System.Drawing.Point(115, 424);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(262, 20);
            this.txtProductName.TabIndex = 13;
            this.txtProductName.Text = "Product Name";
            // 
            // txtBrandName
            // 
            this.txtBrandName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBrandName.Location = new System.Drawing.Point(455, 424);
            this.txtBrandName.Name = "txtBrandName";
            this.txtBrandName.Size = new System.Drawing.Size(152, 20);
            this.txtBrandName.TabIndex = 15;
            this.txtBrandName.Text = "Brand Name";
            // 
            // txtCasePrice
            // 
            this.txtCasePrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCasePrice.Location = new System.Drawing.Point(613, 424);
            this.txtCasePrice.Name = "txtCasePrice";
            this.txtCasePrice.Size = new System.Drawing.Size(81, 20);
            this.txtCasePrice.TabIndex = 16;
            this.txtCasePrice.Text = "Case Price";
            // 
            // txtCaseSize
            // 
            this.txtCaseSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCaseSize.Location = new System.Drawing.Point(700, 424);
            this.txtCaseSize.Name = "txtCaseSize";
            this.txtCaseSize.Size = new System.Drawing.Size(81, 20);
            this.txtCaseSize.TabIndex = 17;
            this.txtCaseSize.Text = "Case Size";
            // 
            // txtEachPrice
            // 
            this.txtEachPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEachPrice.Location = new System.Drawing.Point(787, 424);
            this.txtEachPrice.Name = "txtEachPrice";
            this.txtEachPrice.Size = new System.Drawing.Size(81, 20);
            this.txtEachPrice.TabIndex = 18;
            this.txtEachPrice.Text = "Each Price";
            // 
            // txtSize
            // 
            this.txtSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSize.Location = new System.Drawing.Point(383, 424);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(66, 20);
            this.txtSize.TabIndex = 14;
            this.txtSize.Text = "Size";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(270, 396);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "&Save Product";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkExtractSize
            // 
            this.chkExtractSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkExtractSize.AutoSize = true;
            this.chkExtractSize.Location = new System.Drawing.Point(397, 400);
            this.chkExtractSize.Name = "chkExtractSize";
            this.chkExtractSize.Size = new System.Drawing.Size(82, 17);
            this.chkExtractSize.TabIndex = 9;
            this.chkExtractSize.Text = "Extract Size";
            this.chkExtractSize.UseVisualStyleBackColor = true;
            // 
            // chkExtractBrand
            // 
            this.chkExtractBrand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkExtractBrand.AutoSize = true;
            this.chkExtractBrand.Location = new System.Drawing.Point(489, 400);
            this.chkExtractBrand.Name = "chkExtractBrand";
            this.chkExtractBrand.Size = new System.Drawing.Size(121, 17);
            this.chkExtractBrand.TabIndex = 10;
            this.chkExtractBrand.Text = "Extract Brand Name";
            this.chkExtractBrand.UseVisualStyleBackColor = true;
            // 
            // lblProductCount
            // 
            this.lblProductCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProductCount.AutoSize = true;
            this.lblProductCount.Location = new System.Drawing.Point(644, 401);
            this.lblProductCount.Name = "lblProductCount";
            this.lblProductCount.Size = new System.Drawing.Size(79, 13);
            this.lblProductCount.TabIndex = 11;
            this.lblProductCount.Text = "(product count)";
            // 
            // lblURL
            // 
            this.lblURL.AutoSize = true;
            this.lblURL.Location = new System.Drawing.Point(12, 15);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(86, 13);
            this.lblURL.TabIndex = 0;
            this.lblURL.Text = "Web Page URL:";
            // 
            // ProductWebHarvestForm
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 456);
            this.Controls.Add(this.lblURL);
            this.Controls.Add(this.lblProductCount);
            this.Controls.Add(this.chkExtractBrand);
            this.Controls.Add(this.chkExtractSize);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.txtEachPrice);
            this.Controls.Add(this.txtCaseSize);
            this.Controls.Add(this.txtCasePrice);
            this.Controls.Add(this.txtBrandName);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtVendorCode);
            this.Controls.Add(this.btnUndoSelect);
            this.Controls.Add(this.chkExtractMode);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.ctlBrowser);
            this.Name = "ProductWebHarvestForm";
            this.Text = "Extract Vendor Products From Web Pages";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProductWebHarvestForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser ctlBrowser;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.CheckBox chkExtractMode;
        private System.Windows.Forms.Button btnUndoSelect;
        private System.Windows.Forms.TextBox txtVendorCode;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtBrandName;
        private System.Windows.Forms.TextBox txtCasePrice;
        private System.Windows.Forms.TextBox txtCaseSize;
        private System.Windows.Forms.TextBox txtEachPrice;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkExtractSize;
        private System.Windows.Forms.CheckBox chkExtractBrand;
        private System.Windows.Forms.Label lblProductCount;
        private System.Windows.Forms.Label lblURL;
    }
}