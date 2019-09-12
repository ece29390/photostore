namespace PhotoStore
{
    partial class CustomerSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerSearch));
            this.gvSearch = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrivilegeCardCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMothersName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFathersName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSearchCount = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.ucCustomerDetail1 = new PhotoStore.BusinessLogic.UserControls.UCCustomerDetail();
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // gvSearch
            // 
            this.gvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colPrivilegeCardCode,
            this.colMothersName,
            this.colFathersName,
            this.colAddress});
            this.gvSearch.Location = new System.Drawing.Point(12, 230);
            this.gvSearch.MultiSelect = false;
            this.gvSearch.Name = "gvSearch";
            this.gvSearch.ReadOnly = true;
            this.gvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvSearch.Size = new System.Drawing.Size(579, 227);
            this.gvSearch.TabIndex = 34;
            this.gvSearch.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvSearch_CellDoubleClick);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            this.colId.Width = 150;
            // 
            // colPrivilegeCardCode
            // 
            this.colPrivilegeCardCode.DataPropertyName = "PrivilegeCardCode";
            this.colPrivilegeCardCode.HeaderText = "Privilege Card";
            this.colPrivilegeCardCode.Name = "colPrivilegeCardCode";
            this.colPrivilegeCardCode.ReadOnly = true;
            // 
            // colMothersName
            // 
            this.colMothersName.DataPropertyName = "MothersName";
            this.colMothersName.HeaderText = "Mother\'s Name";
            this.colMothersName.Name = "colMothersName";
            this.colMothersName.ReadOnly = true;
            this.colMothersName.Width = 200;
            // 
            // colFathersName
            // 
            this.colFathersName.DataPropertyName = "FathersName";
            this.colFathersName.HeaderText = "Father\'s Name";
            this.colFathersName.Name = "colFathersName";
            this.colFathersName.ReadOnly = true;
            this.colFathersName.Width = 200;
            // 
            // colAddress
            // 
            this.colAddress.DataPropertyName = "Address";
            this.colAddress.HeaderText = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.ReadOnly = true;
            this.colAddress.Width = 500;
            // 
            // lblSearchCount
            // 
            this.lblSearchCount.AutoSize = true;
            this.lblSearchCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchCount.Location = new System.Drawing.Point(169, 460);
            this.lblSearchCount.Name = "lblSearchCount";
            this.lblSearchCount.Size = new System.Drawing.Size(146, 13);
            this.lblSearchCount.TabIndex = 32;
            this.lblSearchCount.Text = "Search results count = 0";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Image = global::PhotoStore.Properties.Resources.Eraser_2_32_h_g;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(230, 476);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 37);
            this.btnCancel.TabIndex = 36;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Image = global::PhotoStore.Properties.Resources.Search_32_h_g;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.Location = new System.Drawing.Point(293, 187);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(74, 37);
            this.btnSearch.TabIndex = 37;
            this.btnSearch.Text = "&Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Image = global::PhotoStore.Properties.Resources.Done;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(155, 476);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(69, 37);
            this.btnOK.TabIndex = 35;
            this.btnOK.Text = "OK";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ucCustomerDetail1
            // 
            this.ucCustomerDetail1.Location = new System.Drawing.Point(53, 24);
            this.ucCustomerDetail1.Name = "ucCustomerDetail1";
            this.ucCustomerDetail1.Size = new System.Drawing.Size(497, 157);
            this.ucCustomerDetail1.TabIndex = 38;
            // 
            // CustomerSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(603, 525);
            this.Controls.Add(this.ucCustomerDetail1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gvSearch);
            this.Controls.Add(this.lblSearchCount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Profile Search";
            this.Load += new System.EventHandler(this.CustomerProfileSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblSearchCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrivilegeCardCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMothersName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFathersName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private PhotoStore.BusinessLogic.UserControls.UCCustomerDetail ucCustomerDetail1;
    }
}