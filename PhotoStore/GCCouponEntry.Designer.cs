namespace PhotoStore
{
    partial class GCCouponEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GCCouponEntry));
            this.lblCode = new System.Windows.Forms.Label();
            this.txtGCCouponCode = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtExpirationDate = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtProductDescription = new System.Windows.Forms.TextBox();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.chkComplementary = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(12, 20);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(32, 13);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Code";
            // 
            // txtGCCouponCode
            // 
            this.txtGCCouponCode.Location = new System.Drawing.Point(143, 17);
            this.txtGCCouponCode.MaxLength = 50;
            this.txtGCCouponCode.Name = "txtGCCouponCode";
            this.txtGCCouponCode.Size = new System.Drawing.Size(125, 20);
            this.txtGCCouponCode.TabIndex = 1;
            this.txtGCCouponCode.TextChanged += new System.EventHandler(this.txtGCCouponCode_TextChanged);
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(12, 49);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Expiration Date:";
            // 
            // txtExpirationDate
            // 
            this.txtExpirationDate.Location = new System.Drawing.Point(97, 96);
            this.txtExpirationDate.MaxLength = 50;
            this.txtExpirationDate.Name = "txtExpirationDate";
            this.txtExpirationDate.ReadOnly = true;
            this.txtExpirationDate.Size = new System.Drawing.Size(171, 20);
            this.txtExpirationDate.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Image = global::PhotoStore.Properties.Resources.CD_24_h_g;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(204, 134);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtProductDescription
            // 
            this.txtProductDescription.Location = new System.Drawing.Point(97, 46);
            this.txtProductDescription.MaxLength = 50;
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.ReadOnly = true;
            this.txtProductDescription.Size = new System.Drawing.Size(171, 20);
            this.txtProductDescription.TabIndex = 7;
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(97, 17);
            this.txtPrefix.MaxLength = 50;
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.ReadOnly = true;
            this.txtPrefix.Size = new System.Drawing.Size(39, 20);
            this.txtPrefix.TabIndex = 8;
            // 
            // chkComplementary
            // 
            this.chkComplementary.AutoSize = true;
            this.chkComplementary.Location = new System.Drawing.Point(97, 73);
            this.chkComplementary.Name = "chkComplementary";
            this.chkComplementary.Size = new System.Drawing.Size(109, 17);
            this.chkComplementary.TabIndex = 9;
            this.chkComplementary.Text = "Is Complementary";
            this.chkComplementary.UseVisualStyleBackColor = true;
            this.chkComplementary.CheckedChanged += new System.EventHandler(this.chkComplementary_CheckedChanged);
            // 
            // GCCouponEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 159);
            this.Controls.Add(this.chkComplementary);
            this.Controls.Add(this.txtPrefix);
            this.Controls.Add(this.txtProductDescription);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtExpirationDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtGCCouponCode);
            this.Controls.Add(this.lblCode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GCCouponEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New GC/Coupon Entry";
            this.Load += new System.EventHandler(this.GCCouponEntry_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtGCCouponCode;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExpirationDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtProductDescription;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.CheckBox chkComplementary;
    }
}