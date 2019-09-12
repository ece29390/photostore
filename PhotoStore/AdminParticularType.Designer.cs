namespace PhotoStore
{
    partial class AdminParticularType
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
            this.gvParticularType = new System.Windows.Forms.DataGridView();
            this.colCode = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMultipleItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsPrintable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbPrintable = new System.Windows.Forms.GroupBox();
            this.chkPrintable = new System.Windows.Forms.CheckBox();
            this.chkParent = new System.Windows.Forms.CheckBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkMultipleItems = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvParticularType)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbPrintable.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvParticularType
            // 
            this.gvParticularType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvParticularType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCode,
            this.colId,
            this.colDescription,
            this.colMultipleItem,
            this.colParent,
            this.colIsPrintable});
            this.gvParticularType.Location = new System.Drawing.Point(12, 181);
            this.gvParticularType.Name = "gvParticularType";
            this.gvParticularType.RowHeadersVisible = false;
            this.gvParticularType.Size = new System.Drawing.Size(636, 232);
            this.gvParticularType.TabIndex = 0;
            this.gvParticularType.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvParticularType_CellContentClick);
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.HeaderText = "Code";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            this.colCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // colMultipleItem
            // 
            this.colMultipleItem.DataPropertyName = "MultipleItemDescription";
            this.colMultipleItem.HeaderText = "Multiple Item";
            this.colMultipleItem.Name = "colMultipleItem";
            this.colMultipleItem.ReadOnly = true;
            // 
            // colParent
            // 
            this.colParent.DataPropertyName = "IsParent";
            this.colParent.HeaderText = "Parent";
            this.colParent.Name = "colParent";
            this.colParent.ReadOnly = true;
            // 
            // colIsPrintable
            // 
            this.colIsPrintable.DataPropertyName = "IsPrintable";
            this.colIsPrintable.HeaderText = "Printable";
            this.colIsPrintable.Name = "colIsPrintable";
            this.colIsPrintable.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbPrintable);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.chkMultipleItems);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblId);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 163);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Particular Type ";
            // 
            // gbPrintable
            // 
            this.gbPrintable.Controls.Add(this.chkPrintable);
            this.gbPrintable.Controls.Add(this.chkParent);
            this.gbPrintable.Location = new System.Drawing.Point(273, 28);
            this.gbPrintable.Name = "gbPrintable";
            this.gbPrintable.Size = new System.Drawing.Size(200, 83);
            this.gbPrintable.TabIndex = 11;
            this.gbPrintable.TabStop = false;
            this.gbPrintable.Text = "The info is to identify if the particular type is GC/Coupon or Actual product";
            // 
            // chkPrintable
            // 
            this.chkPrintable.AutoSize = true;
            this.chkPrintable.Location = new System.Drawing.Point(6, 37);
            this.chkPrintable.Name = "chkPrintable";
            this.chkPrintable.Size = new System.Drawing.Size(67, 17);
            this.chkPrintable.TabIndex = 9;
            this.chkPrintable.Text = "Printable";
            this.chkPrintable.UseVisualStyleBackColor = true;
            this.chkPrintable.CheckedChanged += new System.EventHandler(this.chkPrintable_CheckedChanged);
            // 
            // chkParent
            // 
            this.chkParent.AutoSize = true;
            this.chkParent.Location = new System.Drawing.Point(6, 60);
            this.chkParent.Name = "chkParent";
            this.chkParent.Size = new System.Drawing.Size(57, 17);
            this.chkParent.TabIndex = 10;
            this.chkParent.Text = "Parent";
            this.chkParent.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(554, 130);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(473, 130);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(392, 130);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkMultipleItems
            // 
            this.chkMultipleItems.AutoSize = true;
            this.chkMultipleItems.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMultipleItems.Location = new System.Drawing.Point(6, 121);
            this.chkMultipleItems.Name = "chkMultipleItems";
            this.chkMultipleItems.Size = new System.Drawing.Size(90, 17);
            this.chkMultipleItems.TabIndex = 5;
            this.chkMultipleItems.Text = "Multiple Items";
            this.chkMultipleItems.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkMultipleItems.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(81, 54);
            this.txtDescription.MaxLength = 500;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(186, 61);
            this.txtDescription.TabIndex = 4;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(81, 28);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(186, 20);
            this.txtCode.TabIndex = 2;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Code:";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(594, 16);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "-1";
            this.lblId.Visible = false;
            // 
            // AdminParticularType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 425);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gvParticularType);
            this.MaximizeBox = false;
            this.Name = "AdminParticularType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminParticularType";
            this.Load += new System.EventHandler(this.AdminParticularType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvParticularType)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbPrintable.ResumeLayout(false);
            this.gbPrintable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvParticularType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkMultipleItems;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox gbPrintable;
        private System.Windows.Forms.CheckBox chkParent;
        private System.Windows.Forms.CheckBox chkPrintable;
        private System.Windows.Forms.DataGridViewLinkColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMultipleItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsPrintable;
    }
}