namespace PhotoStore
{
    partial class SearchJobOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchJobOrder));
            this.gvSearch = new System.Windows.Forms.DataGridView();
            this.colDateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMothersName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParticulars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJobOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJobOrderNumber = new System.Windows.Forms.DataGridViewLinkColumn();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cboSearchBy = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnShowTally = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // gvSearch
            // 
            this.gvSearch.AllowUserToAddRows = false;
            this.gvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDateCreated,
            this.colOrderNumber,
            this.colMothersName,
            this.colQuantity,
            this.colParticulars,
            this.colJobOrderId,
            this.colJobOrderNumber});
            this.gvSearch.Location = new System.Drawing.Point(12, 59);
            this.gvSearch.Name = "gvSearch";
            this.gvSearch.RowHeadersVisible = false;
            this.gvSearch.Size = new System.Drawing.Size(636, 354);
            this.gvSearch.TabIndex = 0;
            this.gvSearch.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvSearch_CellContentClick);
            // 
            // colDateCreated
            // 
            this.colDateCreated.DataPropertyName = "DateCreated";
            this.colDateCreated.HeaderText = "Date";
            this.colDateCreated.Name = "colDateCreated";
            // 
            // colOrderNumber
            // 
            this.colOrderNumber.DataPropertyName = "OrderNumber";
            this.colOrderNumber.HeaderText = "Order Number";
            this.colOrderNumber.Name = "colOrderNumber";
            // 
            // colMothersName
            // 
            this.colMothersName.DataPropertyName = "MothersName";
            this.colMothersName.HeaderText = "Customer Name";
            this.colMothersName.Name = "colMothersName";
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "Quantity";
            this.colQuantity.HeaderText = "Qty";
            this.colQuantity.Name = "colQuantity";
            // 
            // colParticulars
            // 
            this.colParticulars.DataPropertyName = "Particulars";
            this.colParticulars.HeaderText = "Particulars";
            this.colParticulars.Name = "colParticulars";
            // 
            // colJobOrderId
            // 
            this.colJobOrderId.DataPropertyName = "JobOrderId";
            this.colJobOrderId.HeaderText = "";
            this.colJobOrderId.Name = "colJobOrderId";
            this.colJobOrderId.ReadOnly = true;
            this.colJobOrderId.Visible = false;
            // 
            // colJobOrderNumber
            // 
            this.colJobOrderNumber.DataPropertyName = "JobOrderNumber";
            this.colJobOrderNumber.HeaderText = "Job Order Number";
            this.colJobOrderNumber.Name = "colJobOrderNumber";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 21);
            this.txtSearch.MaxLength = 30;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(226, 20);
            this.txtSearch.TabIndex = 2;
            // 
            // cboSearchBy
            // 
            this.cboSearchBy.FormattingEnabled = true;
            this.cboSearchBy.Location = new System.Drawing.Point(244, 21);
            this.cboSearchBy.Name = "cboSearchBy";
            this.cboSearchBy.Size = new System.Drawing.Size(121, 21);
            this.cboSearchBy.TabIndex = 3;
            this.cboSearchBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboSearchBy_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(371, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnShowTally
            // 
            this.btnShowTally.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowTally.Image = ((System.Drawing.Image)(resources.GetObject("btnShowTally.Image")));
            this.btnShowTally.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowTally.Location = new System.Drawing.Point(553, 419);
            this.btnShowTally.Name = "btnShowTally";
            this.btnShowTally.Size = new System.Drawing.Size(95, 37);
            this.btnShowTally.TabIndex = 26;
            this.btnShowTally.Text = "Show Tally";
            this.btnShowTally.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowTally.UseVisualStyleBackColor = true;
            this.btnShowTally.Click += new System.EventHandler(this.btnShowTally_Click);
            // 
            // SearchJobOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 461);
            this.Controls.Add(this.btnShowTally);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cboSearchBy);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.gvSearch);
            this.Name = "SearchJobOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Order";
            this.Load += new System.EventHandler(this.SearchJobOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cboSearchBy;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMothersName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParticulars;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJobOrderId;
        private System.Windows.Forms.DataGridViewLinkColumn colJobOrderNumber;
        private System.Windows.Forms.Button btnShowTally;
    }
}