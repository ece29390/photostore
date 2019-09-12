namespace PhotoStore
{
    partial class AdminCoupon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminCoupon));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gvDataEntry = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCouponStatusCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCouponStatusId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpirationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssuedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssuedTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRedeemedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRedeemedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ucImportExport1 = new PhotoStore.BusinessLogic.UserControls.UCImportExport();
            this.pageControl1 = new PhotoStore.BusinessLogic.UserControls.PageControl();
            this.ucSearch1 = new PhotoStore.BusinessLogic.UserControls.UcSearch();
            this.btnPrintPage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvDataEntry)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Image = global::PhotoStore.Properties.Resources.Eraser_2_32_h_g;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(575, 376);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 37);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Image = global::PhotoStore.Properties.Resources.Save_All_32_h_g;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.Location = new System.Drawing.Point(491, 376);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(78, 37);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.gvDataEntry.ColumnHeadersHeight = 25;
            this.gvDataEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvDataEntry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colProductListId,
            this.colCode,
            this.colDescription,
            this.colUnitPrice,
            this.colCouponStatusCode,
            this.colCouponStatusId,
            this.colExpirationDate,
            this.colIssuedDate,
            this.colIssuedTo,
            this.colRedeemedDate,
            this.colRedeemedBy});
            this.gvDataEntry.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gvDataEntry.Location = new System.Drawing.Point(12, 70);
            this.gvDataEntry.MultiSelect = false;
            this.gvDataEntry.Name = "gvDataEntry";
            this.gvDataEntry.RowHeadersVisible = false;
            this.gvDataEntry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDataEntry.Size = new System.Drawing.Size(636, 264);
            this.gvDataEntry.TabIndex = 10;
            this.gvDataEntry.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gvDataEntry_CellBeginEdit);
            this.gvDataEntry.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvDataEntry_ColumnHeaderMouseClick);
            this.gvDataEntry.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDataEntry_CellContentClick);
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
            this.colCode.HeaderText = "Coupon Code";
            this.colCode.Name = "colCode";
            this.colCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            this.colUnitPrice.Visible = false;
            // 
            // colCouponStatusCode
            // 
            this.colCouponStatusCode.DataPropertyName = "CouponStatusCode";
            this.colCouponStatusCode.HeaderText = "Status";
            this.colCouponStatusCode.Name = "colCouponStatusCode";
            this.colCouponStatusCode.ReadOnly = true;
            this.colCouponStatusCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCouponStatusCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colCouponStatusId
            // 
            this.colCouponStatusId.DataPropertyName = "CouponStatusId";
            this.colCouponStatusId.HeaderText = "CouponStatusId";
            this.colCouponStatusId.Name = "colCouponStatusId";
            this.colCouponStatusId.Visible = false;
            // 
            // colExpirationDate
            // 
            this.colExpirationDate.DataPropertyName = "ExpirationDate";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.colExpirationDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colExpirationDate.HeaderText = "Expiration Date";
            this.colExpirationDate.Name = "colExpirationDate";
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
            // ucImportExport1
            // 
            this.ucImportExport1.Location = new System.Drawing.Point(12, -6);
            this.ucImportExport1.Name = "ucImportExport1";
            this.ucImportExport1.Size = new System.Drawing.Size(200, 44);
            this.ucImportExport1.TabIndex = 12;
            this.ucImportExport1.Type = null;
            // 
            // pageControl1
            // 
            this.pageControl1.ColumnToBeSelected = null;
            this.pageControl1.ColumnToBeSorted = null;
            this.pageControl1.DelegatedRetrieveData = null;
            this.pageControl1.DelegatedTotalCount = null;
            this.pageControl1.Location = new System.Drawing.Point(517, 340);
            this.pageControl1.Name = "pageControl1";
            this.pageControl1.ParamDic = ((System.Collections.Generic.Dictionary<string, object>)(resources.GetObject("pageControl1.ParamDic")));
            this.pageControl1.Size = new System.Drawing.Size(131, 25);
            this.pageControl1.SortedDirection = PhotoStore.BusinessLogic.Direction.ASC;
            this.pageControl1.TabIndex = 13;
            this.pageControl1.OnDataLoad += new PhotoStore.BusinessLogic.UserControls.OnDataLoading(this.pageControl1_OnDataLoad);
            // 
            // ucSearch1
            // 
            this.ucSearch1.Location = new System.Drawing.Point(12, 34);
            this.ucSearch1.Name = "ucSearch1";
            this.ucSearch1.Size = new System.Drawing.Size(336, 30);
            this.ucSearch1.TabIndex = 14;
            // 
            // btnPrintPage
            // 
            this.btnPrintPage.Location = new System.Drawing.Point(508, 34);
            this.btnPrintPage.Name = "btnPrintPage";
            this.btnPrintPage.Size = new System.Drawing.Size(140, 23);
            this.btnPrintPage.TabIndex = 24;
            this.btnPrintPage.Text = "Print Per Page";
            this.btnPrintPage.UseVisualStyleBackColor = true;
            this.btnPrintPage.Click += new System.EventHandler(this.btnPrintPage_Click);
            // 
            // AdminCoupon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(660, 425);
            this.Controls.Add(this.btnPrintPage);
            this.Controls.Add(this.ucSearch1);
            this.Controls.Add(this.pageControl1);
            this.Controls.Add(this.ucImportExport1);
            this.Controls.Add(this.gvDataEntry);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminCoupon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coupon Management";
            this.Load += new System.EventHandler(this.CouponManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvDataEntry)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView gvDataEntry;
        private PhotoStore.BusinessLogic.UserControls.UCImportExport ucImportExport1;
        private PhotoStore.BusinessLogic.UserControls.PageControl pageControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductListId;
        private System.Windows.Forms.DataGridViewLinkColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCouponStatusCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCouponStatusId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpirationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssuedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssuedTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRedeemedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRedeemedBy;
        private PhotoStore.BusinessLogic.UserControls.UcSearch ucSearch1;
        private System.Windows.Forms.Button btnPrintPage;
    }
}