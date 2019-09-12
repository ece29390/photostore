namespace PhotoStore
{
    partial class RejectionPackage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RejectionPackage));
            this.gvPackage = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.colChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colOrderPackageDetailsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParticulars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvPackage)).BeginInit();
            this.SuspendLayout();
            // 
            // gvPackage
            // 
            this.gvPackage.AllowUserToAddRows = false;
            this.gvPackage.AllowUserToDeleteRows = false;
            this.gvPackage.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gvPackage.ColumnHeadersHeight = 33;
            this.gvPackage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChk,
            this.colOrderPackageDetailsId,
            this.colDateCreated,
            this.colParticulars,
            this.colQuantity});
            this.gvPackage.Location = new System.Drawing.Point(13, 13);
            this.gvPackage.Name = "gvPackage";
            this.gvPackage.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gvPackage.RowHeadersVisible = false;
            this.gvPackage.Size = new System.Drawing.Size(557, 211);
            this.gvPackage.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Image = global::PhotoStore.Properties.Resources._001_03;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.Location = new System.Drawing.Point(506, 230);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(64, 31);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Save";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // colChk
            // 
            this.colChk.DataPropertyName = "IsRejected";
            this.colChk.FalseValue = "false";
            this.colChk.HeaderText = "";
            this.colChk.Name = "colChk";
            this.colChk.TrueValue = "true";
            this.colChk.Width = 50;
            // 
            // colOrderPackageDetailsId
            // 
            this.colOrderPackageDetailsId.DataPropertyName = "Id";
            this.colOrderPackageDetailsId.HeaderText = "OrderPackageDetailsId";
            this.colOrderPackageDetailsId.Name = "colOrderPackageDetailsId";
            this.colOrderPackageDetailsId.Visible = false;
            // 
            // colDateCreated
            // 
            this.colDateCreated.DataPropertyName = "DateLastModified";
            this.colDateCreated.HeaderText = "Date Created";
            this.colDateCreated.Name = "colDateCreated";
            // 
            // colParticulars
            // 
            this.colParticulars.DataPropertyName = "Particulars";
            this.colParticulars.HeaderText = "Particulars";
            this.colParticulars.Name = "colParticulars";
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "Quantity";
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            // 
            // RejectionPackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 266);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gvPackage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RejectionPackage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rejection Package Form";
            this.Load += new System.EventHandler(this.RejectionPackage_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RejectionPackage_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gvPackage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvPackage;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderPackageDetailsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParticulars;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
    }
}