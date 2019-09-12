namespace PhotoStore
{
    partial class Tally
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
            this.dgShowTally = new System.Windows.Forms.DataGridView();
            this.cboJobOrder = new System.Windows.Forms.ComboBox();
            this.btnShowTally = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.colSupplierDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParticularCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgShowTally)).BeginInit();
            this.SuspendLayout();
            // 
            // dgShowTally
            // 
            this.dgShowTally.AllowUserToAddRows = false;
            this.dgShowTally.AllowUserToDeleteRows = false;
            this.dgShowTally.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgShowTally.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSupplierDescription,
            this.colQuantity,
            this.colParticularCode});
            this.dgShowTally.Location = new System.Drawing.Point(12, 39);
            this.dgShowTally.Name = "dgShowTally";
            this.dgShowTally.ReadOnly = true;
            this.dgShowTally.Size = new System.Drawing.Size(636, 374);
            this.dgShowTally.TabIndex = 0;
            this.dgShowTally.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgShowTally_ColumnHeaderMouseClick);
            // 
            // cboJobOrder
            // 
            this.cboJobOrder.FormattingEnabled = true;
            this.cboJobOrder.Location = new System.Drawing.Point(106, 12);
            this.cboJobOrder.Name = "cboJobOrder";
            this.cboJobOrder.Size = new System.Drawing.Size(121, 21);
            this.cboJobOrder.TabIndex = 1;
            this.cboJobOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboJobOrder_KeyPress);
            // 
            // btnShowTally
            // 
            this.btnShowTally.Location = new System.Drawing.Point(233, 12);
            this.btnShowTally.Name = "btnShowTally";
            this.btnShowTally.Size = new System.Drawing.Size(75, 23);
            this.btnShowTally.TabIndex = 2;
            this.btnShowTally.Text = "Show Tally";
            this.btnShowTally.UseVisualStyleBackColor = true;
            this.btnShowTally.Click += new System.EventHandler(this.btnShowTally_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Job Order Number";
            // 
            // colSupplierDescription
            // 
            this.colSupplierDescription.DataPropertyName = "SupplierCode";
            this.colSupplierDescription.HeaderText = "Supplier";
            this.colSupplierDescription.Name = "colSupplierDescription";
            this.colSupplierDescription.ReadOnly = true;
            this.colSupplierDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "Qty";
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            // 
            // colParticularCode
            // 
            this.colParticularCode.DataPropertyName = "Particulars";
            this.colParticularCode.HeaderText = "Particulars";
            this.colParticularCode.Name = "colParticularCode";
            this.colParticularCode.ReadOnly = true;
            // 
            // Tally
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 425);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnShowTally);
            this.Controls.Add(this.cboJobOrder);
            this.Controls.Add(this.dgShowTally);
            this.Name = "Tally";
            this.RightToLeftLayout = true;
            this.Text = "Tally";
            this.Load += new System.EventHandler(this.Tally_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgShowTally)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgShowTally;
        private System.Windows.Forms.ComboBox cboJobOrder;
        private System.Windows.Forms.Button btnShowTally;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplierDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParticularCode;
    }
}