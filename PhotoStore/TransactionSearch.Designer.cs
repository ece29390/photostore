namespace PhotoStore
{
    partial class TransactionSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionSearch));
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbCustomerDetails = new System.Windows.Forms.GroupBox();
            this.ucCustomerDetail1 = new PhotoStore.BusinessLogic.UserControls.UCCustomerDetail();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gvResultList = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransactionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colMothersName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.chkSearchWithDates = new System.Windows.Forms.CheckBox();
            this.gbCustomerDetails.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvResultList)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(110, 12);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(179, 20);
            this.txtCode.TabIndex = 1;
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Location = new System.Drawing.Point(12, 15);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(76, 13);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "Order Number:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Image = global::PhotoStore.Properties.Resources.Cross;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(233, 302);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 42);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Image = global::PhotoStore.Properties.Resources.Check;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(177, 302);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(50, 42);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gbCustomerDetails
            // 
            this.gbCustomerDetails.Controls.Add(this.ucCustomerDetail1);
            this.gbCustomerDetails.Location = new System.Drawing.Point(3, 119);
            this.gbCustomerDetails.Name = "gbCustomerDetails";
            this.gbCustomerDetails.Size = new System.Drawing.Size(297, 177);
            this.gbCustomerDetails.TabIndex = 14;
            this.gbCustomerDetails.TabStop = false;
            this.gbCustomerDetails.Text = "Customer Details";
            // 
            // ucCustomerDetail1
            // 
            this.ucCustomerDetail1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCustomerDetail1.Location = new System.Drawing.Point(3, 16);
            this.ucCustomerDetail1.Name = "ucCustomerDetail1";
            this.ucCustomerDetail1.Size = new System.Drawing.Size(291, 158);
            this.ucCustomerDetail1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvResultList);
            this.groupBox2.Location = new System.Drawing.Point(306, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(571, 335);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result List";
            // 
            // gvResultList
            // 
            this.gvResultList.AllowUserToAddRows = false;
            this.gvResultList.AllowUserToDeleteRows = false;
            this.gvResultList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvResultList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colTransactionDate,
            this.colCode,
            this.colMothersName,
            this.colBalance,
            this.colTotalAmount,
            this.colFullName});
            this.gvResultList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvResultList.Location = new System.Drawing.Point(3, 16);
            this.gvResultList.Name = "gvResultList";
            this.gvResultList.RowHeadersVisible = false;
            this.gvResultList.Size = new System.Drawing.Size(565, 316);
            this.gvResultList.TabIndex = 0;
            this.gvResultList.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvResultList_ColumnHeaderMouseClick);
            this.gvResultList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvResultList_CellContentClick);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colTransactionDate
            // 
            this.colTransactionDate.DataPropertyName = "TransactionDate";
            this.colTransactionDate.HeaderText = "Transaction Date";
            this.colTransactionDate.Name = "colTransactionDate";
            this.colTransactionDate.ReadOnly = true;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.HeaderText = "Order Number";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            this.colCode.Width = 150;
            // 
            // colMothersName
            // 
            this.colMothersName.DataPropertyName = "MothersName";
            this.colMothersName.HeaderText = "Mommy\'s Name";
            this.colMothersName.Name = "colMothersName";
            this.colMothersName.ReadOnly = true;
            this.colMothersName.Width = 200;
            // 
            // colBalance
            // 
            this.colBalance.DataPropertyName = "TotalBalance";
            this.colBalance.HeaderText = "Balance";
            this.colBalance.Name = "colBalance";
            this.colBalance.ReadOnly = true;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.DataPropertyName = "TotalAmount";
            this.colTotalAmount.HeaderText = "Total Amount";
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.ReadOnly = true;
            // 
            // colFullName
            // 
            this.colFullName.DataPropertyName = "FullName";
            this.colFullName.HeaderText = "Created By";
            this.colFullName.Name = "colFullName";
            this.colFullName.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Date From:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Enabled = false;
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(110, 73);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(179, 20);
            this.dtpFrom.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Date To:";
            // 
            // dtpTo
            // 
            this.dtpTo.Enabled = false;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(110, 99);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(179, 20);
            this.dtpTo.TabIndex = 20;
            // 
            // chkSearchWithDates
            // 
            this.chkSearchWithDates.AutoSize = true;
            this.chkSearchWithDates.Location = new System.Drawing.Point(15, 38);
            this.chkSearchWithDates.Name = "chkSearchWithDates";
            this.chkSearchWithDates.Size = new System.Drawing.Size(116, 17);
            this.chkSearchWithDates.TabIndex = 21;
            this.chkSearchWithDates.Text = "Search With Dates";
            this.chkSearchWithDates.UseVisualStyleBackColor = true;
            this.chkSearchWithDates.CheckedChanged += new System.EventHandler(this.chkSearchWithDates_CheckedChanged);
            // 
            // TransactionSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(880, 376);
            this.Controls.Add(this.chkSearchWithDates);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbCustomerDetails);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblOrderNumber);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransactionSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TransactionSearch";
            this.Load += new System.EventHandler(this.TransactionSearch_Load);
            this.gbCustomerDetails.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvResultList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.GroupBox gbCustomerDetails;
        private System.Windows.Forms.GroupBox groupBox2;
        private PhotoStore.BusinessLogic.UserControls.UCCustomerDetail ucCustomerDetail1;
        private System.Windows.Forms.DataGridView gvResultList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.CheckBox chkSearchWithDates;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransactionDate;
        private System.Windows.Forms.DataGridViewLinkColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMothersName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;

    }
}