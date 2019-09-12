namespace PhotoStore
{
    partial class RejectOrderTransaction
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gvRejectItems = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReject = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gvOrderTransactionDetail = new System.Windows.Forms.DataGridView();
            this.colChkDel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecordId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lnkRemoveItems = new System.Windows.Forms.LinkLabel();
            this.lnkCancel = new System.Windows.Forms.LinkLabel();
            this.lnkAddItem = new System.Windows.Forms.LinkLabel();
            this.cboProductItem = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboProductDescription = new System.Windows.Forms.ComboBox();
            this.cboParticularType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOrderStatus = new System.Windows.Forms.TextBox();
            this.txtDateCreated = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.colChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colJobOrdersId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaxQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParticularTypeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParticularCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParticulars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderDetailsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvRejectItems)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrderTransactionDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // gvRejectItems
            // 
            this.gvRejectItems.AllowUserToAddRows = false;
            this.gvRejectItems.AllowUserToDeleteRows = false;
            this.gvRejectItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRejectItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChk,
            this.colJobOrdersId,
            this.colQuantity,
            this.colMaxQuantity,
            this.colParticularTypeCode,
            this.colParticularCode,
            this.colParticulars,
            this.colAmount,
            this.colOrderDetailsId});
            this.gvRejectItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gvRejectItems.Location = new System.Drawing.Point(9, 19);
            this.gvRejectItems.Name = "gvRejectItems";
            this.gvRejectItems.RowHeadersVisible = false;
            this.gvRejectItems.Size = new System.Drawing.Size(780, 224);
            this.gvRejectItems.TabIndex = 16;
            this.gvRejectItems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gvRejectItems_DataError);
            this.gvRejectItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvRejectItems_CellContentClick);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Image = global::PhotoStore.Properties.Resources.Eraser_2_32_h_g;
            this.btnCancel.Location = new System.Drawing.Point(701, 695);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 37);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Image = global::PhotoStore.Properties.Resources.Save_All_32_h_g;
            this.btnSave.Location = new System.Drawing.Point(590, 695);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 37);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "&Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReject);
            this.groupBox1.Controls.Add(this.gvRejectItems);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(795, 288);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rejected Items";
            // 
            // btnReject
            // 
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReject.Image = global::PhotoStore.Properties.Resources.reject;
            this.btnReject.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReject.Location = new System.Drawing.Point(717, 245);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(72, 37);
            this.btnReject.TabIndex = 37;
            this.btnReject.Text = "&Reject";
            this.btnReject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtQuantity);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.gvOrderTransactionDetail);
            this.groupBox2.Controls.Add(this.lnkRemoveItems);
            this.groupBox2.Controls.Add(this.lnkCancel);
            this.groupBox2.Controls.Add(this.lnkAddItem);
            this.groupBox2.Controls.Add(this.cboProductItem);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cboProductDescription);
            this.groupBox2.Controls.Add(this.cboParticularType);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(3, 345);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(795, 344);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "New Items";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(689, 18);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtQuantity.TabIndex = 52;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(637, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "Quantity";
            // 
            // gvOrderTransactionDetail
            // 
            this.gvOrderTransactionDetail.AllowUserToAddRows = false;
            this.gvOrderTransactionDetail.AllowUserToDeleteRows = false;
            this.gvOrderTransactionDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvOrderTransactionDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChkDel,
            this.colId,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.colUnitPrice,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.colRecordId});
            this.gvOrderTransactionDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gvOrderTransactionDetail.Location = new System.Drawing.Point(15, 96);
            this.gvOrderTransactionDetail.Name = "gvOrderTransactionDetail";
            this.gvOrderTransactionDetail.RowHeadersVisible = false;
            this.gvOrderTransactionDetail.Size = new System.Drawing.Size(774, 229);
            this.gvOrderTransactionDetail.TabIndex = 50;
            this.gvOrderTransactionDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvOrderTransactionDetail_CellContentClick);
            // 
            // colChkDel
            // 
            this.colChkDel.HeaderText = "";
            this.colChkDel.Name = "colChkDel";
            this.colChkDel.Width = 50;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Quantity";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn2.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ParticularTypeCode";
            this.dataGridViewTextBoxColumn3.HeaderText = "Type";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ParticularCode";
            this.dataGridViewTextBoxColumn4.HeaderText = "Particular Code";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 110;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Particulars";
            this.dataGridViewTextBoxColumn5.HeaderText = "Particulars";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.Width = 210;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.DataPropertyName = "UnitPrice";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.colUnitPrice.DefaultCellStyle = dataGridViewCellStyle6;
            this.colUnitPrice.HeaderText = "Unit Price";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ParticularTypeId";
            this.dataGridViewTextBoxColumn7.HeaderText = "ParticularTypeId";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "ProductListId";
            this.dataGridViewTextBoxColumn8.HeaderText = "ProductListId";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // colRecordId
            // 
            this.colRecordId.DataPropertyName = "RecordId";
            this.colRecordId.HeaderText = "RecordId";
            this.colRecordId.Name = "colRecordId";
            this.colRecordId.Visible = false;
            // 
            // lnkRemoveItems
            // 
            this.lnkRemoveItems.AutoSize = true;
            this.lnkRemoveItems.Enabled = false;
            this.lnkRemoveItems.Location = new System.Drawing.Point(708, 328);
            this.lnkRemoveItems.Name = "lnkRemoveItems";
            this.lnkRemoveItems.Size = new System.Drawing.Size(81, 13);
            this.lnkRemoveItems.TabIndex = 42;
            this.lnkRemoveItems.TabStop = true;
            this.lnkRemoveItems.Text = "Remove Item(s)";
            this.lnkRemoveItems.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRemoveItems_LinkClicked);
            // 
            // lnkCancel
            // 
            this.lnkCancel.AutoSize = true;
            this.lnkCancel.Location = new System.Drawing.Point(749, 77);
            this.lnkCancel.Name = "lnkCancel";
            this.lnkCancel.Size = new System.Drawing.Size(40, 13);
            this.lnkCancel.TabIndex = 41;
            this.lnkCancel.TabStop = true;
            this.lnkCancel.Text = "Cancel";
            this.lnkCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCancel_LinkClicked);
            // 
            // lnkAddItem
            // 
            this.lnkAddItem.AutoSize = true;
            this.lnkAddItem.Enabled = false;
            this.lnkAddItem.Location = new System.Drawing.Point(671, 77);
            this.lnkAddItem.Name = "lnkAddItem";
            this.lnkAddItem.Size = new System.Drawing.Size(72, 13);
            this.lnkAddItem.TabIndex = 40;
            this.lnkAddItem.TabStop = true;
            this.lnkAddItem.Text = "Add/Edit Item";
            this.lnkAddItem.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddItem_LinkClicked);
            // 
            // cboProductItem
            // 
            this.cboProductItem.FormattingEnabled = true;
            this.cboProductItem.Location = new System.Drawing.Point(115, 69);
            this.cboProductItem.Name = "cboProductItem";
            this.cboProductItem.Size = new System.Drawing.Size(172, 21);
            this.cboProductItem.TabIndex = 14;
            this.cboProductItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboProductItem_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Product Item";
            // 
            // cboProductDescription
            // 
            this.cboProductDescription.FormattingEnabled = true;
            this.cboProductDescription.Location = new System.Drawing.Point(115, 45);
            this.cboProductDescription.Name = "cboProductDescription";
            this.cboProductDescription.Size = new System.Drawing.Size(172, 21);
            this.cboProductDescription.TabIndex = 12;
            this.cboProductDescription.SelectedIndexChanged += new System.EventHandler(this.cboProductDescription_SelectedIndexChanged);
            this.cboProductDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboProductDescription_KeyPress);
            // 
            // cboParticularType
            // 
            this.cboParticularType.FormattingEnabled = true;
            this.cboParticularType.Location = new System.Drawing.Point(115, 21);
            this.cboParticularType.Name = "cboParticularType";
            this.cboParticularType.Size = new System.Drawing.Size(172, 21);
            this.cboParticularType.TabIndex = 11;
            this.cboParticularType.SelectedIndexChanged += new System.EventHandler(this.cboProductType_SelectedIndexChanged);
            this.cboParticularType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboParticularType_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Product Description";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Particular Type";
            // 
            // txtOrderStatus
            // 
            this.txtOrderStatus.Location = new System.Drawing.Point(626, 304);
            this.txtOrderStatus.Name = "txtOrderStatus";
            this.txtOrderStatus.ReadOnly = true;
            this.txtOrderStatus.Size = new System.Drawing.Size(172, 20);
            this.txtOrderStatus.TabIndex = 49;
            // 
            // txtDateCreated
            // 
            this.txtDateCreated.Location = new System.Drawing.Point(118, 297);
            this.txtDateCreated.Name = "txtDateCreated";
            this.txtDateCreated.ReadOnly = true;
            this.txtDateCreated.Size = new System.Drawing.Size(172, 20);
            this.txtDateCreated.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(551, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "Order Status:";
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(118, 323);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(172, 20);
            this.txtCode.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Order #:";
            // 
            // colChk
            // 
            this.colChk.DataPropertyName = "IsRejected";
            this.colChk.FalseValue = "False";
            this.colChk.HeaderText = "";
            this.colChk.Name = "colChk";
            this.colChk.TrueValue = "True";
            this.colChk.Width = 50;
            // 
            // colJobOrdersId
            // 
            this.colJobOrdersId.DataPropertyName = "Id";
            this.colJobOrdersId.HeaderText = "Id";
            this.colJobOrdersId.Name = "colJobOrdersId";
            this.colJobOrdersId.ReadOnly = true;
            this.colJobOrdersId.Visible = false;
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "RejectedQuantity";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colQuantity.DefaultCellStyle = dataGridViewCellStyle4;
            this.colQuantity.HeaderText = "Rejected Quantity ";
            this.colQuantity.Name = "colQuantity";
            // 
            // colMaxQuantity
            // 
            this.colMaxQuantity.DataPropertyName = "ConsumedQuantity";
            this.colMaxQuantity.HeaderText = "Consumed Quantity";
            this.colMaxQuantity.Name = "colMaxQuantity";
            this.colMaxQuantity.ReadOnly = true;
            // 
            // colParticularTypeCode
            // 
            this.colParticularTypeCode.DataPropertyName = "ParticularTypeCode";
            this.colParticularTypeCode.HeaderText = "Type";
            this.colParticularTypeCode.Name = "colParticularTypeCode";
            this.colParticularTypeCode.ReadOnly = true;
            this.colParticularTypeCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colParticularTypeCode.Width = 80;
            // 
            // colParticularCode
            // 
            this.colParticularCode.DataPropertyName = "ParticularCode";
            this.colParticularCode.HeaderText = "Particular Code";
            this.colParticularCode.Name = "colParticularCode";
            this.colParticularCode.ReadOnly = true;
            this.colParticularCode.Width = 110;
            // 
            // colParticulars
            // 
            this.colParticulars.DataPropertyName = "Particulars";
            this.colParticulars.HeaderText = "Particulars";
            this.colParticulars.Name = "colParticulars";
            this.colParticulars.ReadOnly = true;
            this.colParticulars.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colParticulars.Width = 210;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colOrderDetailsId
            // 
            this.colOrderDetailsId.DataPropertyName = "OrderDetailsId";
            this.colOrderDetailsId.HeaderText = "OrderDetailsId";
            this.colOrderDetailsId.Name = "colOrderDetailsId";
            this.colOrderDetailsId.ReadOnly = true;
            this.colOrderDetailsId.Visible = false;
            // 
            // RejectOrderTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(30, 10);
            this.ClientSize = new System.Drawing.Size(820, 735);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtOrderStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtDateCreated);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label5);
            this.Name = "RejectOrderTransaction";
            this.Text = "Reject Order Transaction";
            this.Load += new System.EventHandler(this.RejectOrderTransaction_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RejectOrderTransaction_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gvRejectItems)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrderTransactionDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvRejectItems;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboProductItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboProductDescription;
        private System.Windows.Forms.ComboBox cboParticularType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel lnkRemoveItems;
        private System.Windows.Forms.LinkLabel lnkCancel;
        private System.Windows.Forms.LinkLabel lnkAddItem;
        private System.Windows.Forms.TextBox txtOrderStatus;
        private System.Windows.Forms.TextBox txtDateCreated;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView gvOrderTransactionDetail;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChkDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecordId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJobOrdersId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaxQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParticularTypeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParticularCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParticulars;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderDetailsId;
    }
}