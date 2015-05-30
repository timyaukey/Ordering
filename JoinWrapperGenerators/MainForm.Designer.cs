namespace JoinWrapperGenerators
{
    partial class MainForm
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
            this.btnGenJoinVpToProd = new System.Windows.Forms.Button();
            this.btnGenJoinPlToVpToProd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenJoinVpToProd
            // 
            this.btnGenJoinVpToProd.Location = new System.Drawing.Point(12, 12);
            this.btnGenJoinVpToProd.Name = "btnGenJoinVpToProd";
            this.btnGenJoinVpToProd.Size = new System.Drawing.Size(238, 23);
            this.btnGenJoinVpToProd.TabIndex = 0;
            this.btnGenJoinVpToProd.Text = "Generate JoinVpToProd";
            this.btnGenJoinVpToProd.UseVisualStyleBackColor = true;
            this.btnGenJoinVpToProd.Click += new System.EventHandler(this.btnGenJoinVpToProd_Click);
            // 
            // btnGenJoinPlToVpToProd
            // 
            this.btnGenJoinPlToVpToProd.Location = new System.Drawing.Point(12, 41);
            this.btnGenJoinPlToVpToProd.Name = "btnGenJoinPlToVpToProd";
            this.btnGenJoinPlToVpToProd.Size = new System.Drawing.Size(238, 23);
            this.btnGenJoinPlToVpToProd.TabIndex = 1;
            this.btnGenJoinPlToVpToProd.Text = "Generate JoinPlToVpToProd";
            this.btnGenJoinPlToVpToProd.UseVisualStyleBackColor = true;
            this.btnGenJoinPlToVpToProd.Click += new System.EventHandler(this.btnGenJoinPlToVpToProd_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 78);
            this.Controls.Add(this.btnGenJoinPlToVpToProd);
            this.Controls.Add(this.btnGenJoinVpToProd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Join Wrapper Generators";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenJoinVpToProd;
        private System.Windows.Forms.Button btnGenJoinPlToVpToProd;
    }
}

