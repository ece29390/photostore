namespace PhotoStore
{
    partial class AdminGiftCertificate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminGiftCertificate));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gvDataEntry = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnPrintPage = new System.Windows.Forms.Button();
            this.ucSearch1 = new PhotoStore.BusinessLogic.UserControls.UcSearch();
            this.pageControl1 = new PhotoStore.BusinessLogic.UserControls.PageControl();
            this.ucImportExport1 = new PhotoStore.BusinessLogic.UserControls.UCImportExport();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colGiftCertificateType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiftCertificateStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpirationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiftCertificateStatusId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiftCertificateTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssuedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssuedTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRedeemedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRedeemedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsComplementary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvDataEntry)).BeginInit();
            this.SuspendLayout();
            // 
            // gvDataEntry
            // 
            this.gvDataEntry.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvDataEntry.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvDataEntry.ColumnHeadersHeight = 21;
            this.gvDataEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvDataEntry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colProductListId,
            this.colCode,
            this.colGiftCertificateType,
            this.colDescription,
            this.colUnitPrice,
            this.colGiftCertificateStatus,
            this.colExpirationDate,
            this.colGiftCertificateStatusId,
            this.colGiftCertificateTypeId,
            this.colIssuedDate,
            this.colIssuedTo,
            this.colRedeemedDate,
            this.colRedeemedBy,
            this.IsComplementary});
            this.gvDataEntry.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gvDataEntry.Location = new System.Drawing.Point(12, 71);
            this.gvDataEntry.MultiSelect = false;
            this.gvDataEntry.Name = "gvDataEntry";
            this.gvDataEntry.RowHeadersVisible = false;
            this.gvDataEntry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDataEntry.Size = new System.Drawing.Size(629, 299);
            this.gvDataEntry.TabIndex = 20;
            this.gvDataEntry.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gvDataEntry_CellBeginEdit);
            this.gvDataEntry.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvDataEntry_ColumnHeaderMouseClick);
            this.gvDataEntry.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gvDataEntry_DataError);
            this.gvDataEntry.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDataEntry_CellContentClick);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Image = global::PhotoStore.Properties.Resources.Eraser_2_32_h_g;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(568, 407);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 37);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Image = global::PhotoStore.Properties.Resources.Save_All_32_h_g;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.Location = new System.Drawing.Point(487, 407);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 37);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnPrintPage
            // 
            this.btnPrintPage.Location = new System.Drawing.Point(501, 42);
            this.btnPrintPage.Name = "btnPrintPage";
            this.btnPrintPage.Size = new System.Drawing.Size(140, 23);
            this.btnPrintPage.TabIndex = 23;
            this.btnPrintPage.Text = "Print Per Page";
            this.btnPrintPage.UseVisualStyleBackColor = true;
            this.btnPrintPage.Click += new System.EventHandler(this.btnPrintPage_Click);
            // 
            // ucSearch1
            // 
            this.ucSearch1.Location = new System.Drawing.Point(12, 35);
            this.ucSearch1.Name = "ucSearch1";
            this.ucSearch1.Size = new System.Drawing.Size(336, 30);
            this.ucSearch1.TabIndex = 22;
            // 
            // pageControl1
            // 
            this.pageControl1.ColumnToBeSelected = null;
            this.pageControl1.ColumnToBeSorted = null;
            this.pageControl1.DelegatedRetrieveData = null;
            this.pageControl1.DelegatedTotalCount = null;
            this.pageControl1.Location = new System.Drawing.Point(510, 376);
            this.pageControl1.Name = "pageControl1";
            this.pageControl1.ParamDic = ((System.Collections.Generic.Dictionary<string, object>)(resources.GetObject("pageControl1.ParamDic")));
            this.pageControl1.Size = new System.Drawing.Size(131, 25);
            this.pageControl1.SortedDirection = PhotoStore.BusinessLogic.Direction.ASC;
            this.pageControl1.TabIndex = 21;
            // 
            // ucImportExport1
            // 
            this.ucImportExport1.Location = new System.Drawing.Point(12, -6);
            this.ucImportExport1.Name = "ucImportExport1";
            this.ucImportExport1.Size = new System.Drawing.Size(200, 44);
            this.ucImportExport1.TabIndex = 11;
            this.ucImportExport1.Type = null;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colProductListId
            // 
            this.colProductListId.DataPropertyName = "ProductListId";
            this.colProductListId.HeaderText = "Product List Id";
            this.colProductListId.Name = "colProductListId";
            this.colProductListId.ReadOnly = true;
            this.colProductListId.Visible = false;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.colCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCode.HeaderText = "GC Code";
            this.colCode.Name = "colCode";
            this.colCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colGiftCertificateType
            // 
            this.colGiftCertificateType.DataPropertyName = "GiftCertificateTypeCode";
            this.colGiftCertificateType.HeaderText = "GC Type";
            this.colGiftCertificateType.Name = "colGiftCertificateType";
            this.colGiftCertificateType.ReadOnly = true;
            this.colGiftCertificateType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGiftCertificateType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDescription.Width = 190;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.DataPropertyName = "UnitPrice";
            this.colUnitPrice.HeaderText = "UnitPrice";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.ReadOnly = true;
            // 
            // colGiftCertificateStatus
            // 
            this.colGiftCertificateStatus.DataPropertyName = "GiftCertificateStatusCode";
            this.colGiftCertificateStatus.HeaderText = "Status";
            this.colGiftCertificateStatus.Name = "colGiftCertificateStatus";
            this.colGiftCertificateStatus.ReadOnly = true;
            this.colGiftCertificateStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGiftCertificateStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colExpirationDate
            // 
            this.colExpirationDate.DataPropertyName = "ExpirationDate";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.colExpirationDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colExpirationDate.HeaderText = "Expiration Date";
            this.colExpirationDate.Name = "colExpirationDate";
            this.colExpirationDate.ReadOnly = true;
            // 
            // colGiftCertificateStatusId
            // 
            this.colGiftCertificateStatusId.DataPropertyName = "GiftCertificateStatusId";
            this.colGiftCertificateStatusId.HeaderText = "GiftCertificateStatusId";
            this.colGiftCertificateStatusId.Name = "colGiftCertificateStatusId";
            this.colGiftCertificateStatusId.Visible = false;
            // 
            // colGiftCertificateTypeId
            // 
            this.colGiftCertificateTypeId.DataPropertyName = "GiftCertificateTypeId";
            this.colGiftCertificateTypeId.HeaderText = "GiftCertificateTypeId";
            this.colGiftCertificateTypeId.Name = "colGiftCertificateTypeId";
            this.colGiftCertificateTypeId.Visible = false;
            // 
            // colIssuedDate
            // 
            this.colIssuedDate.DataPropertyName = "IssuedDate";
            this.colIssuedDate.HeaderText = "Issued Date";
            this.colIssuedDate.Name = "colIssuedDate";
            this.colIssuedDate.ReadOnly = true;
            // 
            // colIssuedTo
            // 
            this.colIssuedTo.DataPropertyName = "IssuedTo";
            this.colIssuedTo.HeaderText = "Issued To";
            this.colIssuedTo.Name = "colIssuedTo";
            this.colIssuedTo.ReadOnly = true;
            // 
            // colRedeemedDate
            // 
            this.colRedeemedDate.DataPropertyName = "RedeemedDate";
            this.colRedeemedDate.HeaderText = "Redeemed Date";
            this.colRedeemedDate.Name = "colRedeemedDate";
            this.colRedeemedDate.ReadOnly = true;
            // 
            // colRedeemedBy
            // 
            this.colRedeemedBy.DataPropertyName = "RedeemedBy";
            this.colRedeemedBy.HeaderText = "Redeemed By";
            this.colRedeemedBy.Name = "colRedeemedBy";
            this.colRedeemedBy.ReadOnly = true;
            // 
            // IsComplementary
            // 
            this.IsComplementary.DataPropertyName = "IsComplementary";
            this.IsComplementary.HeaderText = "Is Complementary";
            this.IsComplementary.Name = "IsComplementary";
            this.IsComplementary.ReadOnly = true;
            // 
            // AdminGiftCertificate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(660, 449);
            this.Controls.Add(this.btnPrintPage);
            this.Controls.Add(this.ucSearch1);
            this.Controls.Add(this.pageControl1);
            this.Controls.Add(this.ucImportExport1);
            this.Controls.Add(this.gvDataEntry);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminGiftCertificate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gift Certificate Management";
            this.Load += new System.EventHandler(this.GiftCertificateManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvDataEntry)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView gvDataEntry;
        private PhotoStore.BusinessLogic.UserControls.UCImportExport ucImportExport1;
        private PhotoStore.BusinessLogic.UserControls.PageControl pageControl1;
        private PhotoStore.BusinessLogic.UserControls.UcSearch ucSearch1;
        private System.Windows.Forms.Button btnPrintPage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductListId;
        private System.Windows.Forms.DataGridViewLinkColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiftCertificateType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiftCertificateStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpirationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiftCertificateStatusId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiftCertificateTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssuedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssuedTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRedeemedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRedeemedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsComplementary;
    }
}