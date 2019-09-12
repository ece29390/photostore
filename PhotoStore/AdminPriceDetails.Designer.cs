namespace PhotoStore
{
    partial class AdminPriceDetails
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
            this.txtPLDParticulars = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPLDQuantity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPCDAddItem = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPLDParticulars
            // 
            this.txtPLDParticulars.Location = new System.Drawing.Point(64, 58);
            this.txtPLDParticulars.MaxLength = 500;
            this.txtPLDParticulars.Multiline = true;
            this.txtPLDParticulars.Name = "txtPLDParticulars";
            this.txtPLDParticulars.Size = new System.Drawing.Size(244, 123);
            this.txtPLDParticulars.TabIndex = 3;
            this.txtPLDParticulars.TextChanged += new System.EventHandler(this.txtPLDParticulars_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quantity:";
            // 
            // txtPLDQuantity
            // 
            this.txtPLDQuantity.Location = new System.Drawing.Point(64, 32);
            this.txtPLDQuantity.MaxLength = 8;
            this.txtPLDQuantity.Name = "txtPLDQuantity";
            this.txtPLDQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtPLDQuantity.TabIndex = 1;
            this.txtPLDQuantity.TextChanged += new System.EventHandler(this.txtPLDQuantity_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Items:";
            // 
            // btnPCDAddItem
            // 
            this.btnPCDAddItem.Enabled = false;
            this.btnPCDAddItem.Location = new System.Drawing.Point(112, 187);
            this.btnPCDAddItem.Name = "btnPCDAddItem";
            this.btnPCDAddItem.Size = new System.Drawing.Size(196, 23);
            this.btnPCDAddItem.TabIndex = 6;
            this.btnPCDAddItem.Text = "Add/Edit Product List Details";
            this.btnPCDAddItem.UseVisualStyleBackColor = true;
            this.btnPCDAddItem.Click += new System.EventHandler(this.btnPCDAddItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "label4";
            // 
            // AdminPriceDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 213);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPCDAddItem);
            this.Controls.Add(this.txtPLDParticulars);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPLDQuantity);
            this.Controls.Add(this.label1);
            this.Name = "AdminPriceDetails";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Price List Details";
            this.Load += new System.EventHandler(this.AdminPriceDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPLDQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPCDAddItem;
        private System.Windows.Forms.TextBox txtPLDParticulars;
        private System.Windows.Forms.Label label4;
    }
}