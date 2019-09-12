namespace PhotoStore
{
    partial class MultipleRejection
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
            this.label1 = new System.Windows.Forms.Label();
            this.gvJobOrderDetail = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.colJobOrderDetailId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colJobOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParticulars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvJobOrderDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rejection Item from Job Orders:";
            // 
            // gvJobOrderDetail
            // 
            this.gvJobOrderDetail.AccessibleDescription = "";
            this.gvJobOrderDetail.AllowUserToAddRows = false;
            this.gvJobOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvJobOrderDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colJobOrderDetailId,
            this.colChk,
            this.colJobOrderNumber,
            this.colParticulars});
            this.gvJobOrderDetail.Location = new System.Drawing.Point(12, 26);
            this.gvJobOrderDetail.Name = "gvJobOrderDetail";
            this.gvJobOrderDetail.RowHeadersVisible = false;
            this.gvJobOrderDetail.Size = new System.Drawing.Size(315, 145);
            this.gvJobOrderDetail.TabIndex = 1;
            this.gvJobOrderDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvJobOrderDetail_CellContentClick);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Image = global::PhotoStore.Properties.Resources._001_03;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.Location = new System.Drawing.Point(263, 177);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(64, 31);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // colJobOrderDetailId
            // 
            this.colJobOrderDetailId.HeaderText = "Id";
            this.colJobOrderDetailId.Name = "colJobOrderDetailId";
            this.colJobOrderDetailId.Visible = false;
            // 
            // colChk
            // 
            this.colChk.HeaderText = "";
            this.colChk.Name = "colChk";
            this.colChk.Width = 20;
            // 
            // colJobOrderNumber
            // 
            this.colJobOrderNumber.HeaderText = "Job Order Number";
            this.colJobOrderNumber.Name = "colJobOrderNumber";
            this.colJobOrderNumber.ReadOnly = true;
            this.colJobOrderNumber.Width = 120;
            // 
            // colParticulars
            // 
            this.colParticulars.HeaderText = "Particulars";
            this.colParticulars.Name = "colParticulars";
            this.colParticulars.Width = 120;
            // 
            // MultipleRejection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 221);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gvJobOrderDetail);
            this.Controls.Add(this.label1);
            this.Name = "MultipleRejection";
            this.Text = "Please Select";
            this.Load += new System.EventHandler(this.MultipleRejection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvJobOrderDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvJobOrderDetail;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJobOrderDetailId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJobOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParticulars;
    }
}