namespace PhotoStore
{
    partial class MissingJobOrder
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgMissingItems = new System.Windows.Forms.DataGridView();
            this.btnExecuteAdjustment = new System.Windows.Forms.Button();
            this.colOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderedQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParticulars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMissingItems)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgMissingItems);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(708, 467);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExecuteAdjustment);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 413);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(708, 54);
            this.panel2.TabIndex = 1;
            // 
            // dgMissingItems
            // 
            this.dgMissingItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMissingItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderNumber,
            this.colOrderedQuantity,
            this.colParticulars,
            this.colDescription});
            this.dgMissingItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMissingItems.Location = new System.Drawing.Point(0, 0);
            this.dgMissingItems.Name = "dgMissingItems";
            this.dgMissingItems.RowHeadersVisible = false;
            this.dgMissingItems.Size = new System.Drawing.Size(708, 467);
            this.dgMissingItems.TabIndex = 0;
            // 
            // btnExecuteAdjustment
            // 
            this.btnExecuteAdjustment.Location = new System.Drawing.Point(621, 19);
            this.btnExecuteAdjustment.Name = "btnExecuteAdjustment";
            this.btnExecuteAdjustment.Size = new System.Drawing.Size(75, 23);
            this.btnExecuteAdjustment.TabIndex = 0;
            this.btnExecuteAdjustment.Text = "Execute Adjustment";
            this.btnExecuteAdjustment.UseVisualStyleBackColor = true;
            this.btnExecuteAdjustment.Click += new System.EventHandler(this.btnExecuteAdjustment_Click);
            // 
            // colOrderNumber
            // 
            this.colOrderNumber.DataPropertyName = "Code";
            this.colOrderNumber.HeaderText = "Order Number";
            this.colOrderNumber.Name = "colOrderNumber";
            this.colOrderNumber.ReadOnly = true;
            this.colOrderNumber.Width = 200;
            // 
            // colOrderedQuantity
            // 
            this.colOrderedQuantity.DataPropertyName = "OrderedQuantity";
            this.colOrderedQuantity.HeaderText = "Ordered Quantity";
            this.colOrderedQuantity.Name = "colOrderedQuantity";
            this.colOrderedQuantity.ReadOnly = true;
            // 
            // colParticulars
            // 
            this.colParticulars.DataPropertyName = "Particulars";
            this.colParticulars.HeaderText = "Particulars";
            this.colParticulars.Name = "colParticulars";
            this.colParticulars.ReadOnly = true;
            this.colParticulars.Width = 200;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 200;
            // 
            // MissingJobOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 467);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MissingJobOrder";
            this.Text = "View Missing Item(s)";
            this.Load += new System.EventHandler(this.MissingJobOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMissingItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgMissingItems;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExecuteAdjustment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderedQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParticulars;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
    }
}