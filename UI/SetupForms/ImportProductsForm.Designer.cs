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
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblVendor = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblExplain = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.txtColumnHeaders = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.AcceptsTab = true;
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.HideSelection = false;
            this.txtInput.Location = new System.Drawing.Point(12, 118);
            this.txtInput.MaxLength = 1000000;
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInput.Size = new System.Drawing.Size(892, 360);
            this.txtInput.TabIndex = 1;
            this.txtInput.WordWrap = false;
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(12, 9);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(75, 13);
            this.lblVendor.TabIndex = 2;
            this.lblVendor.Text = "(vendor name)";
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(738, 484);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(166, 23);
            this.btnCreate.TabIndex = 10;
            this.btnCreate.Text = "Create Products";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblExplain
            // 
            this.lblExplain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExplain.Location = new System.Drawing.Point(391, 13);
            this.lblExplain.Name = "lblExplain";
            this.lblExplain.Size = new System.Drawing.Size(513, 76);
            this.lblExplain.TabIndex = 7;
            this.lblExplain.Text = resources.GetString("lblExplain.Text");
            // 
            // btnEnter
            // 
            this.btnEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnter.Location = new System.Drawing.Point(534, 484);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(198, 23);
            this.btnEnter.TabIndex = 9;
            this.btnEnter.Text = "Enter Product Information";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // txtColumnHeaders
            // 
            this.txtColumnHeaders.AcceptsTab = true;
            this.txtColumnHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtColumnHeaders.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtColumnHeaders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtColumnHeaders.Location = new System.Drawing.Point(15, 92);
            this.txtColumnHeaders.Multiline = true;
            this.txtColumnHeaders.Name = "txtColumnHeaders";
            this.txtColumnHeaders.Size = new System.Drawing.Size(892, 20);
            this.txtColumnHeaders.TabIndex = 12;
            this.txtColumnHeaders.Text = "(column headers)";
            this.txtColumnHeaders.WordWrap = false;
            // 
            // ImportProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 519);
            this.Controls.Add(this.txtColumnHeaders);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.lblExplain);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lblVendor);
            this.Controls.Add(this.txtInput);
            this.Name = "ImportProductsForm";
            this.Text = "Import Products";
            this.Load += new System.EventHandler(this.ImportProductsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblExplain;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.TextBox txtColumnHeaders;
    }
}