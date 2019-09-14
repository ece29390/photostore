namespace PhotoStore
{
    partial class AdminPrivilegeCard
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewPrivilegeCard = new System.Windows.Forms.DataGridView();
            this.bindingSourcePrivilegeCard = new System.Windows.Forms.BindingSource(this.components);
            this.ucSearchPrivilegeCard = new PhotoStore.BusinessLogic.UserControls.UcSearch();
            this.colRecordId = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpirationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lookupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entityDataRowDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.issueDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expirationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarksDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateLastModifiedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerEntityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsExpired = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recordIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrivilegeCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePrivilegeCard)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucSearchPrivilegeCard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 51);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewPrivilegeCard);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 399);
            this.panel2.TabIndex = 1;
            // 
            // dataGridViewPrivilegeCard
            // 
            this.dataGridViewPrivilegeCard.AllowUserToAddRows = false;
            this.dataGridViewPrivilegeCard.AutoGenerateColumns = false;
            this.dataGridViewPrivilegeCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPrivilegeCard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRecordId,
            this.colCode,
            this.colIssueDate,
            this.colExpirationDate,
            this.lookupDataGridViewTextBoxColumn,
            this.entityDataRowDataGridViewTextBoxColumn,
            this.colCustomerId,
            this.codeDataGridViewTextBoxColumn,
            this.issueDateDataGridViewTextBoxColumn,
            this.expirationDateDataGridViewTextBoxColumn,
            this.remarksDataGridViewTextBoxColumn,
            this.dateLastModifiedDataGridViewTextBoxColumn,
            this.customerEntityDataGridViewTextBoxColumn,
            this.colIsExpired,
            this.colId,
            this.recordIdDataGridViewTextBoxColumn});
            this.dataGridViewPrivilegeCard.DataSource = this.bindingSourcePrivilegeCard;
            this.dataGridViewPrivilegeCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPrivilegeCard.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewPrivilegeCard.Name = "dataGridViewPrivilegeCard";
            this.dataGridViewPrivilegeCard.RowHeadersVisible = false;
            this.dataGridViewPrivilegeCard.RowTemplate.Height = 24;
            this.dataGridViewPrivilegeCard.Size = new System.Drawing.Size(800, 399);
            this.dataGridViewPrivilegeCard.TabIndex = 0;
            this.dataGridViewPrivilegeCard.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewPrivilegeCard_CellContentClick);
            // 
            // bindingSourcePrivilegeCard
            // 
            this.bindingSourcePrivilegeCard.DataSource = typeof(PhotoStore.Entity.PrivilegeCard);
            // 
            // ucSearchPrivilegeCard
            // 
            this.ucSearchPrivilegeCard.Location = new System.Drawing.Point(4, 4);
            this.ucSearchPrivilegeCard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucSearchPrivilegeCard.Name = "ucSearchPrivilegeCard";
            this.ucSearchPrivilegeCard.Size = new System.Drawing.Size(448, 37);
            this.ucSearchPrivilegeCard.TabIndex = 0;
            // 
            // colRecordId
            // 
            this.colRecordId.HeaderText = "";
            this.colRecordId.Name = "colRecordId";
            this.colRecordId.ReadOnly = true;
            this.colRecordId.Text = "Delete";
            this.colRecordId.UseColumnTextForButtonValue = true;
            this.colRecordId.Width = 75;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.HeaderText = "Card Number";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            this.colCode.Width = 200;
            // 
            // colIssueDate
            // 
            this.colIssueDate.DataPropertyName = "IssueDate";
            this.colIssueDate.HeaderText = "Issued Date";
            this.colIssueDate.Name = "colIssueDate";
            this.colIssueDate.ReadOnly = true;
            this.colIssueDate.Width = 200;
            // 
            // colExpirationDate
            // 
            this.colExpirationDate.DataPropertyName = "ExpirationDate";
            this.colExpirationDate.HeaderText = "Expiration Date";
            this.colExpirationDate.Name = "colExpirationDate";
            this.colExpirationDate.ReadOnly = true;
            this.colExpirationDate.Width = 200;
            // 
            // lookupDataGridViewTextBoxColumn
            // 
            this.lookupDataGridViewTextBoxColumn.DataPropertyName = "Lookup";
            this.lookupDataGridViewTextBoxColumn.HeaderText = "Lookup";
            this.lookupDataGridViewTextBoxColumn.Name = "lookupDataGridViewTextBoxColumn";
            this.lookupDataGridViewTextBoxColumn.ReadOnly = true;
            this.lookupDataGridViewTextBoxColumn.Visible = false;
            // 
            // entityDataRowDataGridViewTextBoxColumn
            // 
            this.entityDataRowDataGridViewTextBoxColumn.DataPropertyName = "EntityDataRow";
            this.entityDataRowDataGridViewTextBoxColumn.HeaderText = "EntityDataRow";
            this.entityDataRowDataGridViewTextBoxColumn.Name = "entityDataRowDataGridViewTextBoxColumn";
            this.entityDataRowDataGridViewTextBoxColumn.Visible = false;
            // 
            // colCustomerId
            // 
            this.colCustomerId.DataPropertyName = "CustomerId";
            this.colCustomerId.HeaderText = "CustomerId";
            this.colCustomerId.Name = "colCustomerId";
            this.colCustomerId.Visible = false;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.Visible = false;
            // 
            // issueDateDataGridViewTextBoxColumn
            // 
            this.issueDateDataGridViewTextBoxColumn.DataPropertyName = "IssueDate";
            this.issueDateDataGridViewTextBoxColumn.HeaderText = "IssueDate";
            this.issueDateDataGridViewTextBoxColumn.Name = "issueDateDataGridViewTextBoxColumn";
            this.issueDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // expirationDateDataGridViewTextBoxColumn
            // 
            this.expirationDateDataGridViewTextBoxColumn.DataPropertyName = "ExpirationDate";
            this.expirationDateDataGridViewTextBoxColumn.HeaderText = "ExpirationDate";
            this.expirationDateDataGridViewTextBoxColumn.Name = "expirationDateDataGridViewTextBoxColumn";
            this.expirationDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // remarksDataGridViewTextBoxColumn
            // 
            this.remarksDataGridViewTextBoxColumn.DataPropertyName = "Remarks";
            this.remarksDataGridViewTextBoxColumn.HeaderText = "Remarks";
            this.remarksDataGridViewTextBoxColumn.Name = "remarksDataGridViewTextBoxColumn";
            this.remarksDataGridViewTextBoxColumn.Visible = false;
            // 
            // dateLastModifiedDataGridViewTextBoxColumn
            // 
            this.dateLastModifiedDataGridViewTextBoxColumn.DataPropertyName = "DateLastModified";
            this.dateLastModifiedDataGridViewTextBoxColumn.HeaderText = "DateLastModified";
            this.dateLastModifiedDataGridViewTextBoxColumn.Name = "dateLastModifiedDataGridViewTextBoxColumn";
            this.dateLastModifiedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateLastModifiedDataGridViewTextBoxColumn.Visible = false;
            // 
            // customerEntityDataGridViewTextBoxColumn
            // 
            this.customerEntityDataGridViewTextBoxColumn.DataPropertyName = "CustomerEntity";
            this.customerEntityDataGridViewTextBoxColumn.HeaderText = "CustomerEntity";
            this.customerEntityDataGridViewTextBoxColumn.Name = "customerEntityDataGridViewTextBoxColumn";
            this.customerEntityDataGridViewTextBoxColumn.Visible = false;
            // 
            // colIsExpired
            // 
            this.colIsExpired.DataPropertyName = "isExpired";
            this.colIsExpired.HeaderText = "isExpired";
            this.colIsExpired.Name = "colIsExpired";
            this.colIsExpired.ReadOnly = true;
            this.colIsExpired.Visible = false;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // recordIdDataGridViewTextBoxColumn
            // 
            this.recordIdDataGridViewTextBoxColumn.DataPropertyName = "RecordId";
            this.recordIdDataGridViewTextBoxColumn.HeaderText = "RecordId";
            this.recordIdDataGridViewTextBoxColumn.Name = "recordIdDataGridViewTextBoxColumn";
            this.recordIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.recordIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // AdminPrivilegeCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AdminPrivilegeCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminPrivilegeCard";
            this.Load += new System.EventHandler(this.AdminPrivilegeCard_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrivilegeCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePrivilegeCard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private BusinessLogic.UserControls.UcSearch ucSearchPrivilegeCard;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewPrivilegeCard;
        private System.Windows.Forms.BindingSource bindingSourcePrivilegeCard;
        private System.Windows.Forms.DataGridViewButtonColumn colRecordId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpirationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn lookupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entityDataRowDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn issueDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expirationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarksDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateLastModifiedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerEntityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsExpired;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordIdDataGridViewTextBoxColumn;
    }
}