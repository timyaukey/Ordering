namespace Willowsoft.Ordering.UI
{
    partial class PurOrderForm
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
            this.grdOrders = new System.Windows.Forms.DataGridView();
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lstCategories = new System.Windows.Forms.ListBox();
            this.btnSetCategories = new System.Windows.Forms.Button();
            this.lblCurrentCategories = new System.Windows.Forms.Label();
            this.btnShowOrder = new System.Windows.Forms.Button();
            this.chkIncludeInactive = new System.Windows.Forms.CheckBox();
            this.lblVendor = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.cboVendor = new System.Windows.Forms.ComboBox();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.btnOrderSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grdOrders
            // 
            this.grdOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdOrders.Location = new System.Drawing.Point(12, 12);
            this.grdOrders.Name = "grdOrders";
            this.grdOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdOrders.Size = new System.Drawing.Size(677, 508);
            this.grdOrders.TabIndex = 0;
            // 
            // lstCategories
            // 
            this.lstCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCategories.FormattingEnabled = true;
            this.lstCategories.IntegralHeight = false;
            this.lstCategories.Location = new System.Drawing.Point(695, 150);
            this.lstCategories.Name = "lstCategories";
            this.lstCategories.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstCategories.Size = new System.Drawing.Size(201, 289);
            this.lstCategories.TabIndex = 9;
            // 
            // btnSetCategories
            // 
            this.btnSetCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetCategories.Location = new System.Drawing.Point(695, 468);
            this.btnSetCategories.Name = "btnSetCategories";
            this.btnSetCategories.Size = new System.Drawing.Size(200, 23);
            this.btnSetCategories.TabIndex = 11;
            this.btnSetCategories.Text = "Set Order Categories";
            this.btnSetCategories.UseVisualStyleBackColor = true;
            this.btnSetCategories.Click += new System.EventHandler(this.btnSetCategories_Click);
            // 
            // lblCurrentCategories
            // 
            this.lblCurrentCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentCategories.AutoSize = true;
            this.lblCurrentCategories.Location = new System.Drawing.Point(695, 134);
            this.lblCurrentCategories.Name = "lblCurrentCategories";
            this.lblCurrentCategories.Size = new System.Drawing.Size(138, 13);
            this.lblCurrentCategories.TabIndex = 8;
            this.lblCurrentCategories.Text = "Categories In Current Order:";
            // 
            // btnShowOrder
            // 
            this.btnShowOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowOrder.Location = new System.Drawing.Point(695, 497);
            this.btnShowOrder.Name = "btnShowOrder";
            this.btnShowOrder.Size = new System.Drawing.Size(200, 23);
            this.btnShowOrder.TabIndex = 12;
            this.btnShowOrder.Text = "Show Order Details";
            this.btnShowOrder.UseVisualStyleBackColor = true;
            this.btnShowOrder.Click += new System.EventHandler(this.btnShowOrder_Click);
            // 
            // chkIncludeInactive
            // 
            this.chkIncludeInactive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIncludeInactive.AutoSize = true;
            this.chkIncludeInactive.Location = new System.Drawing.Point(695, 445);
            this.chkIncludeInactive.Name = "chkIncludeInactive";
            this.chkIncludeInactive.Size = new System.Drawing.Size(147, 17);
            this.chkIncludeInactive.TabIndex = 10;
            this.chkIncludeInactive.Text = "Include Inactive Products";
            this.chkIncludeInactive.UseVisualStyleBackColor = true;
            // 
            // lblVendor
            // 
            this.lblVendor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(695, 15);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(44, 13);
            this.lblVendor.TabIndex = 1;
            this.lblVendor.Text = "Vendor:";
            // 
            // lblStartDate
            // 
            this.lblStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(695, 42);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(58, 13);
            this.lblStartDate.TabIndex = 3;
            this.lblStartDate.Text = "Start Date:";
            // 
            // lblEndDate
            // 
            this.lblEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(695, 68);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(55, 13);
            this.lblEndDate.TabIndex = 5;
            this.lblEndDate.Text = "End Date:";
            // 
            // cboVendor
            // 
            this.cboVendor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboVendor.FormattingEnabled = true;
            this.cboVendor.Location = new System.Drawing.Point(759, 12);
            this.cboVendor.Name = "cboVendor";
            this.cboVendor.Size = new System.Drawing.Size(137, 21);
            this.cboVendor.TabIndex = 2;
            // 
            // txtStartDate
            // 
            this.txtStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartDate.Location = new System.Drawing.Point(759, 39);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(83, 20);
            this.txtStartDate.TabIndex = 4;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndDate.Location = new System.Drawing.Point(759, 65);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(83, 20);
            this.txtEndDate.TabIndex = 6;
            // 
            // btnOrderSearch
            // 
            this.btnOrderSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrderSearch.Location = new System.Drawing.Point(695, 91);
            this.btnOrderSearch.Name = "btnOrderSearch";
            this.btnOrderSearch.Size = new System.Drawing.Size(200, 23);
            this.btnOrderSearch.TabIndex = 7;
            this.btnOrderSearch.Text = "Search For Orders";
            this.btnOrderSearch.UseVisualStyleBackColor = true;
            this.btnOrderSearch.Click += new System.EventHandler(this.btnOrderSearch_Click);
            // 
            // PurOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 532);
            this.Controls.Add(this.btnOrderSearch);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.cboVendor);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblVendor);
            this.Controls.Add(this.chkIncludeInactive);
            this.Controls.Add(this.btnShowOrder);
            this.Controls.Add(this.lblCurrentCategories);
            this.Controls.Add(this.btnSetCategories);
            this.Controls.Add(this.lstCategories);
            this.Controls.Add(this.grdOrders);
            this.Name = "PurOrderForm";
            this.Text = "Order List";
            this.Load += new System.EventHandler(this.PurOrderForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PurOrderForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdOrders;
        private System.Windows.Forms.BindingSource orderBindingSource;
        private System.Windows.Forms.ListBox lstCategories;
        private System.Windows.Forms.Button btnSetCategories;
        private System.Windows.Forms.Label lblCurrentCategories;
        private System.Windows.Forms.Button btnShowOrder;
        private System.Windows.Forms.CheckBox chkIncludeInactive;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.ComboBox cboVendor;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.Button btnOrderSearch;
    }
}