namespace PhotoStore
{
    partial class JobOrderMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobOrderMain));
            this.txtJONumber = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.gvDataEntry = new System.Windows.Forms.DataGridView();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnShowTally = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lnkMissingItems = new System.Windows.Forms.LinkLabel();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.colchkbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderDetailsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParticulars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplierCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplierId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaxQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lnkSupplier = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gvDataEntry)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtJONumber
            // 
            this.txtJONumber.Location = new System.Drawing.Point(754, 12);
            this.txtJONumber.Name = "txtJONumber";
            this.txtJONumber.ReadOnly = true;
            this.txtJONumber.Size = new System.Drawing.Size(111, 20);
            this.txtJONumber.TabIndex = 31;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(50, 12);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(141, 20);
            this.txtDate.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Date:";
            // 
            // btnPrint
            // 
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.Location = new System.Drawing.Point(791, 553);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(74, 37);
            this.btnPrint.TabIndex = 28;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // gvDataEntry
            // 
            this.gvDataEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDataEntry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colchkbox,
            this.colId,
            this.colDateCreated,
            this.colCode,
            this.colCustomerName,
            this.colQuantity,
            this.colOrderDetailsId,
            this.colParticulars,
            this.colSupplierCode,
            this.colSupplierId,
            this.colMaxQuantity});
            this.gvDataEntry.Location = new System.Drawing.Point(15, 115);
            this.gvDataEntry.Name = "gvDataEntry";
            this.gvDataEntry.RowHeadersVisible = false;
            this.gvDataEntry.Size = new System.Drawing.Size(850, 432);
            this.gvDataEntry.TabIndex = 32;
            this.gvDataEntry.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvDataEntry_ColumnHeaderMouseClick);
            this.gvDataEntry.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gvDataEntry_DataError);
            this.gvDataEntry.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDataEntry_CellContentClick);
            // 
            // btnDone
            // 
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDone.Image = ((System.Drawing.Image)(resources.GetObject("btnDone.Image")));
            this.btnDone.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDone.Location = new System.Drawing.Point(712, 553);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(73, 37);
            this.btnDone.TabIndex = 26;
            this.btnDone.Text = "Done";
            this.btnDone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnShowTally
            // 
            this.btnShowTally.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowTally.Image = ((System.Drawing.Image)(resources.GetObject("btnShowTally.Image")));
            this.btnShowTally.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowTally.Location = new System.Drawing.Point(532, 553);
            this.btnShowTally.Name = "btnShowTally";
            this.btnShowTally.Size = new System.Drawing.Size(95, 37);
            this.btnShowTally.TabIndex = 25;
            this.btnShowTally.Text = "Show Tally";
            this.btnShowTally.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowTally.UseVisualStyleBackColor = true;
            this.btnShowTally.Click += new System.EventHandler(this.btnShowTally_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(633, 553);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 37);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(655, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Job Order Number";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lnkSupplier);
            this.groupBox1.Controls.Add(this.lnkMissingItems);
            this.groupBox1.Controls.Add(this.txtCustomerName);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtOrderNumber);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpTo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpFrom);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(853, 71);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Details";
            // 
            // lnkMissingItems
            // 
            this.lnkMissingItems.AutoSize = true;
            this.lnkMissingItems.Location = new System.Drawing.Point(676, 15);
            this.lnkMissingItems.Name = "lnkMissingItems";
            this.lnkMissingItems.Size = new System.Drawing.Size(171, 13);
            this.lnkMissingItems.TabIndex = 10;
            this.lnkMissingItems.TabStop = true;
            this.lnkMissingItems.Text = "View Missing Item(s) for Job Orders";
            this.lnkMissingItems.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMissingItems_LinkClicked);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(310, 15);
            this.txtCustomerName.MaxLength = 30;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(207, 20);
            this.txtCustomerName.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Image = global::PhotoStore.Properties.Resources.Lookup;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.Location = new System.Drawing.Point(523, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 38);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(219, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Customer Name:";
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(310, 38);
            this.txtOrderNumber.MaxLength = 20;
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(207, 20);
            this.txtOrderNumber.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(228, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Order Number:";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(112, 41);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(96, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Date Created To:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(112, 16);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(96, 20);
            this.dtpFrom.TabIndex = 1;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Date Created From:";
            // 
            // colchkbox
            // 
            this.colchkbox.DataPropertyName = "Selected";
            this.colchkbox.FalseValue = "False";
            this.colchkbox.HeaderText = "";
            this.colchkbox.Name = "colchkbox";
            this.colchkbox.TrueValue = "True";
            this.colchkbox.Width = 50;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "JOId";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colDateCreated
            // 
            this.colDateCreated.DataPropertyName = "DateCreated";
            this.colDateCreated.HeaderText = "Date Created";
            this.colDateCreated.Name = "colDateCreated";
            this.colDateCreated.ReadOnly = true;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.HeaderText = "Order #";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            // 
            // colCustomerName
            // 
            this.colCustomerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colCustomerName.DataPropertyName = "CustomerName";
            this.colCustomerName.HeaderText = "Customer Name";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.ReadOnly = true;
            this.colCustomerName.Width = 98;
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "Quantity";
            this.colQuantity.HeaderText = "Qty";
            this.colQuantity.Name = "colQuantity";
            // 
            // colOrderDetailsId
            // 
            this.colOrderDetailsId.DataPropertyName = "OrderDetailsId";
            this.colOrderDetailsId.HeaderText = "ODId";
            this.colOrderDetailsId.Name = "colOrderDetailsId";
            this.colOrderDetailsId.ReadOnly = true;
            this.colOrderDetailsId.Visible = false;
            // 
            // colParticulars
            // 
            this.colParticulars.DataPropertyName = "Particulars";
            this.colParticulars.HeaderText = "Particulars";
            this.colParticulars.Name = "colParticulars";
            this.colParticulars.ReadOnly = true;
            // 
            // colSupplierCode
            // 
            this.colSupplierCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.colSupplierCode.DataPropertyName = "SupplierCode";
            this.colSupplierCode.HeaderText = "Supplier";
            this.colSupplierCode.Name = "colSupplierCode";
            this.colSupplierCode.ReadOnly = true;
            this.colSupplierCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSupplierCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSupplierCode.Width = 21;
            // 
            // colSupplierId
            // 
            this.colSupplierId.DataPropertyName = "SupplierId";
            this.colSupplierId.HeaderText = "";
            this.colSupplierId.Name = "colSupplierId";
            this.colSupplierId.Visible = false;
            // 
            // colMaxQuantity
            // 
            this.colMaxQuantity.DataPropertyName = "MaxQuantity";
            this.colMaxQuantity.HeaderText = "";
            this.colMaxQuantity.Name = "colMaxQuantity";
            this.colMaxQuantity.ReadOnly = true;
            this.colMaxQuantity.Visible = false;
            // 
            // lnkSupplier
            // 
            this.lnkSupplier.AutoSize = true;
            this.lnkSupplier.Enabled = false;
            this.lnkSupplier.Location = new System.Drawing.Point(676, 38);
            this.lnkSupplier.Name = "lnkSupplier";
            this.lnkSupplier.Size = new System.Drawing.Size(113, 13);
            this.lnkSupplier.TabIndex = 11;
            this.lnkSupplier.TabStop = true;
            this.lnkSupplier.Text = "Please Select Supplier";
            this.lnkSupplier.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSupplier_LinkClicked);
            // 
            // JobOrderMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 592);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gvDataEntry);
            this.Controls.Add(this.txtJONumber);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnShowTally);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "JobOrderMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Job Order Main";
            this.Load += new System.EventHandler(this.JobOrderMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvDataEntry)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewCheckBoxColumn colChk;
        private System.Windows.Forms.TextBox txtJONumber;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnShowTally;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView gvDataEntry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.LinkLabel lnkMissingItems;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colchkbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderDetailsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParticulars;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplierCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplierId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaxQuantity;
        private System.Windows.Forms.LinkLabel lnkSupplier;
    }
}