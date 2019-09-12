namespace PhotoStore
{
    partial class AdminProductList
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gvPriceList = new System.Windows.Forms.DataGridView();
            this.colProductType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearchAll = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboProductType = new System.Windows.Forms.ComboBox();
            this.tabRecord = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnRemovePriceDetails = new System.Windows.Forms.Button();
            this.btnAddPriceDetails = new System.Windows.Forms.Button();
            this.gvProductListDetails = new System.Windows.Forms.DataGridView();
            this.colChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colProductListDetailsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParticularsDE = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colQuantityDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pnlProductList = new System.Windows.Forms.Panel();
            this.gbParentGCCoupon = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboParentParticularType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboParentGCCoupon = new System.Windows.Forms.ComboBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboProductTypeDE = new System.Windows.Forms.ComboBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabSearch.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPriceList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabRecord.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProductListDetails)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.pnlProductList.SuspendLayout();
            this.gbParentGCCoupon.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSearch);
            this.tabControl1.Controls.Add(this.tabRecord);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(711, 430);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.groupBox2);
            this.tabSearch.Controls.Add(this.groupBox1);
            this.tabSearch.Location = new System.Drawing.Point(4, 22);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearch.Size = new System.Drawing.Size(703, 404);
            this.tabSearch.TabIndex = 0;
            this.tabSearch.Text = "Search Price List";
            this.tabSearch.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvPriceList);
            this.groupBox2.Location = new System.Drawing.Point(7, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(690, 329);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Result";
            // 
            // gvPriceList
            // 
            this.gvPriceList.AllowUserToAddRows = false;
            this.gvPriceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPriceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductType,
            this.colProductListId,
            this.colProductName,
            this.colQuantity,
            this.colItem,
            this.colUnitPrice});
            this.gvPriceList.Location = new System.Drawing.Point(9, 20);
            this.gvPriceList.Name = "gvPriceList";
            this.gvPriceList.Size = new System.Drawing.Size(675, 303);
            this.gvPriceList.TabIndex = 0;
            this.gvPriceList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPriceList_CellContentClick);
            // 
            // colProductType
            // 
            this.colProductType.DataPropertyName = "ProductType";
            this.colProductType.HeaderText = "Product Type";
            this.colProductType.Name = "colProductType";
            this.colProductType.ReadOnly = true;
            // 
            // colProductListId
            // 
            this.colProductListId.DataPropertyName = "ProductListId";
            this.colProductListId.HeaderText = "";
            this.colProductListId.Name = "colProductListId";
            this.colProductListId.ReadOnly = true;
            this.colProductListId.Visible = false;
            // 
            // colProductName
            // 
            this.colProductName.DataPropertyName = "ProductName";
            this.colProductName.HeaderText = "Product Name";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "Quantity";
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            this.colQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colItem
            // 
            this.colItem.DataPropertyName = "Particulars";
            this.colItem.HeaderText = "Item";
            this.colItem.Name = "colItem";
            this.colItem.ReadOnly = true;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.DataPropertyName = "UnitPrice";
            this.colUnitPrice.HeaderText = "U/Price";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearchAll);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboProductType);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(690, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Information";
            // 
            // btnSearchAll
            // 
            this.btnSearchAll.Location = new System.Drawing.Point(419, 19);
            this.btnSearchAll.Name = "btnSearchAll";
            this.btnSearchAll.Size = new System.Drawing.Size(75, 23);
            this.btnSearchAll.TabIndex = 6;
            this.btnSearchAll.Text = "Search All";
            this.btnSearchAll.UseVisualStyleBackColor = true;
            this.btnSearchAll.Click += new System.EventHandler(this.btnSearchAll_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(338, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Product Type:";
            // 
            // cboProductType
            // 
            this.cboProductType.FormattingEnabled = true;
            this.cboProductType.Location = new System.Drawing.Point(86, 19);
            this.cboProductType.Name = "cboProductType";
            this.cboProductType.Size = new System.Drawing.Size(246, 21);
            this.cboProductType.TabIndex = 0;
            // 
            // tabRecord
            // 
            this.tabRecord.Controls.Add(this.groupBox4);
            this.tabRecord.Controls.Add(this.groupBox3);
            this.tabRecord.Location = new System.Drawing.Point(4, 22);
            this.tabRecord.Name = "tabRecord";
            this.tabRecord.Padding = new System.Windows.Forms.Padding(3);
            this.tabRecord.Size = new System.Drawing.Size(703, 404);
            this.tabRecord.TabIndex = 1;
            this.tabRecord.Text = "Price List Record";
            this.tabRecord.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnRemovePriceDetails);
            this.groupBox4.Controls.Add(this.btnAddPriceDetails);
            this.groupBox4.Controls.Add(this.gvProductListDetails);
            this.groupBox4.Location = new System.Drawing.Point(7, 188);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(691, 210);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Product List Details";
            // 
            // btnRemovePriceDetails
            // 
            this.btnRemovePriceDetails.Enabled = false;
            this.btnRemovePriceDetails.Location = new System.Drawing.Point(545, 48);
            this.btnRemovePriceDetails.Name = "btnRemovePriceDetails";
            this.btnRemovePriceDetails.Size = new System.Drawing.Size(140, 23);
            this.btnRemovePriceDetails.TabIndex = 5;
            this.btnRemovePriceDetails.Text = "Remove Price List Details";
            this.btnRemovePriceDetails.UseVisualStyleBackColor = true;
            this.btnRemovePriceDetails.Click += new System.EventHandler(this.btnRemovePriceDetails_Click);
            // 
            // btnAddPriceDetails
            // 
            this.btnAddPriceDetails.Enabled = false;
            this.btnAddPriceDetails.Location = new System.Drawing.Point(545, 20);
            this.btnAddPriceDetails.Name = "btnAddPriceDetails";
            this.btnAddPriceDetails.Size = new System.Drawing.Size(139, 23);
            this.btnAddPriceDetails.TabIndex = 4;
            this.btnAddPriceDetails.Text = "Add Price List Details";
            this.btnAddPriceDetails.UseVisualStyleBackColor = true;
            this.btnAddPriceDetails.Click += new System.EventHandler(this.btnAddPriceDetails_Click);
            // 
            // gvProductListDetails
            // 
            this.gvProductListDetails.AllowUserToAddRows = false;
            this.gvProductListDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvProductListDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChk,
            this.colProductListDetailsId,
            this.colParticularsDE,
            this.colQuantityDetails});
            this.gvProductListDetails.Location = new System.Drawing.Point(9, 20);
            this.gvProductListDetails.Name = "gvProductListDetails";
            this.gvProductListDetails.Size = new System.Drawing.Size(530, 205);
            this.gvProductListDetails.TabIndex = 0;
            this.gvProductListDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvProductListDetails_CellContentClick);
            // 
            // colChk
            // 
            this.colChk.HeaderText = "";
            this.colChk.Name = "colChk";
            this.colChk.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colChk.Width = 50;
            // 
            // colProductListDetailsId
            // 
            this.colProductListDetailsId.DataPropertyName = "Id";
            this.colProductListDetailsId.HeaderText = "";
            this.colProductListDetailsId.Name = "colProductListDetailsId";
            this.colProductListDetailsId.ReadOnly = true;
            this.colProductListDetailsId.Visible = false;
            // 
            // colParticularsDE
            // 
            this.colParticularsDE.DataPropertyName = "Particulars";
            this.colParticularsDE.HeaderText = "Items";
            this.colParticularsDE.Name = "colParticularsDE";
            this.colParticularsDE.ReadOnly = true;
            // 
            // colQuantityDetails
            // 
            this.colQuantityDetails.DataPropertyName = "Quantity";
            this.colQuantityDetails.HeaderText = "Quantity";
            this.colQuantityDetails.Name = "colQuantityDetails";
            this.colQuantityDetails.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pnlProductList);
            this.groupBox3.Controls.Add(this.btnCreate);
            this.groupBox3.Controls.Add(this.btnDelete);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.btnCancel);
            this.groupBox3.Location = new System.Drawing.Point(7, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(690, 175);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Product List";
            // 
            // pnlProductList
            // 
            this.pnlProductList.Controls.Add(this.gbParentGCCoupon);
            this.pnlProductList.Controls.Add(this.txtUnitPrice);
            this.pnlProductList.Controls.Add(this.label2);
            this.pnlProductList.Controls.Add(this.txtProductName);
            this.pnlProductList.Controls.Add(this.label4);
            this.pnlProductList.Controls.Add(this.label3);
            this.pnlProductList.Controls.Add(this.cboProductTypeDE);
            this.pnlProductList.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProductList.Location = new System.Drawing.Point(3, 16);
            this.pnlProductList.Name = "pnlProductList";
            this.pnlProductList.Size = new System.Drawing.Size(684, 124);
            this.pnlProductList.TabIndex = 10;
            // 
            // gbParentGCCoupon
            // 
            this.gbParentGCCoupon.Controls.Add(this.label6);
            this.gbParentGCCoupon.Controls.Add(this.cboParentParticularType);
            this.gbParentGCCoupon.Controls.Add(this.label5);
            this.gbParentGCCoupon.Controls.Add(this.cboParentGCCoupon);
            this.gbParentGCCoupon.Enabled = false;
            this.gbParentGCCoupon.Location = new System.Drawing.Point(332, 10);
            this.gbParentGCCoupon.Name = "gbParentGCCoupon";
            this.gbParentGCCoupon.Size = new System.Drawing.Size(349, 107);
            this.gbParentGCCoupon.TabIndex = 11;
            this.gbParentGCCoupon.TabStop = false;
            this.gbParentGCCoupon.Text = "Parent Photo GC/Coupon Product";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "GC/Coupon Type:";
            // 
            // cboParentParticularType
            // 
            this.cboParentParticularType.FormattingEnabled = true;
            this.cboParentParticularType.Location = new System.Drawing.Point(127, 26);
            this.cboParentParticularType.MaxLength = 20;
            this.cboParentParticularType.Name = "cboParentParticularType";
            this.cboParentParticularType.Size = new System.Drawing.Size(216, 21);
            this.cboParentParticularType.TabIndex = 9;
            this.cboParentParticularType.SelectedIndexChanged += new System.EventHandler(this.cboParentParticularType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "GC/Coupon Products:";
            // 
            // cboParentGCCoupon
            // 
            this.cboParentGCCoupon.FormattingEnabled = true;
            this.cboParentGCCoupon.Location = new System.Drawing.Point(127, 61);
            this.cboParentGCCoupon.MaxLength = 20;
            this.cboParentGCCoupon.Name = "cboParentGCCoupon";
            this.cboParentGCCoupon.Size = new System.Drawing.Size(216, 21);
            this.cboParentGCCoupon.TabIndex = 7;
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Enabled = false;
            this.txtUnitPrice.Location = new System.Drawing.Point(83, 98);
            this.txtUnitPrice.MaxLength = 8;
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(100, 20);
            this.txtUnitPrice.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Unit Price:";
            // 
            // txtProductName
            // 
            this.txtProductName.Enabled = false;
            this.txtProductName.Location = new System.Drawing.Point(83, 36);
            this.txtProductName.MaxLength = 500;
            this.txtProductName.Multiline = true;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(233, 56);
            this.txtProductName.TabIndex = 8;
            this.txtProductName.TextChanged += new System.EventHandler(this.txtProductName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Product Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Description:";
            // 
            // cboProductTypeDE
            // 
            this.cboProductTypeDE.Enabled = false;
            this.cboProductTypeDE.FormattingEnabled = true;
            this.cboProductTypeDE.Location = new System.Drawing.Point(83, 10);
            this.cboProductTypeDE.MaxLength = 20;
            this.cboProductTypeDE.Name = "cboProductTypeDE";
            this.cboProductTypeDE.Size = new System.Drawing.Size(233, 21);
            this.cboProductTypeDE.TabIndex = 5;
            this.cboProductTypeDE.SelectedIndexChanged += new System.EventHandler(this.cboProductTypeDE_SelectedIndexChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(367, 146);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create New";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(610, 146);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(448, 146);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(529, 146);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AdminProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 435);
            this.Controls.Add(this.tabControl1);
            this.Name = "AdminProductList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Price List";
            this.Load += new System.EventHandler(this.AdminProductList_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminProductList_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabSearch.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvPriceList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabRecord.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvProductListDetails)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.pnlProductList.ResumeLayout(false);
            this.pnlProductList.PerformLayout();
            this.gbParentGCCoupon.ResumeLayout(false);
            this.gbParentGCCoupon.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabRecord;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSearchAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboProductType;
        private System.Windows.Forms.DataGridView gvPriceList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductListId;
        private System.Windows.Forms.DataGridViewLinkColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboProductTypeDE;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel pnlProductList;
        private System.Windows.Forms.DataGridView gvProductListDetails;
        private System.Windows.Forms.Button btnRemovePriceDetails;
        private System.Windows.Forms.Button btnAddPriceDetails;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductListDetailsId;
        private System.Windows.Forms.DataGridViewLinkColumn colParticularsDE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantityDetails;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbParentGCCoupon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboParentGCCoupon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboParentParticularType;
    }
}