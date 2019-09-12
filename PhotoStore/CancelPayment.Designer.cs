namespace PhotoStore
{
    partial class CancelPayment
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAmountPaid = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBankFee = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDocumentNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDatePaid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAmountCancel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtModeOfPayment = new System.Windows.Forms.TextBox();
            this.btnRemoved = new System.Windows.Forms.Button();
            this.rdoCash = new System.Windows.Forms.RadioButton();
            this.rdo = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAmountPaid);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtBankFee);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDocumentNumber);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDatePaid);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 206);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Original Payment Detail";
            // 
            // txtAmountPaid
            // 
            this.txtAmountPaid.Location = new System.Drawing.Point(105, 150);
            this.txtAmountPaid.Name = "txtAmountPaid";
            this.txtAmountPaid.ReadOnly = true;
            this.txtAmountPaid.Size = new System.Drawing.Size(207, 20);
            this.txtAmountPaid.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Amount Paid:";
            // 
            // txtBankFee
            // 
            this.txtBankFee.Location = new System.Drawing.Point(105, 124);
            this.txtBankFee.Name = "txtBankFee";
            this.txtBankFee.ReadOnly = true;
            this.txtBankFee.Size = new System.Drawing.Size(207, 20);
            this.txtBankFee.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Bank Fee:";
            // 
            // txtDocumentNumber
            // 
            this.txtDocumentNumber.Location = new System.Drawing.Point(105, 71);
            this.txtDocumentNumber.Multiline = true;
            this.txtDocumentNumber.Name = "txtDocumentNumber";
            this.txtDocumentNumber.ReadOnly = true;
            this.txtDocumentNumber.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDocumentNumber.Size = new System.Drawing.Size(207, 47);
            this.txtDocumentNumber.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Document Number:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(105, 45);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(207, 20);
            this.txtAmount.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Amount Received:";
            // 
            // txtDatePaid
            // 
            this.txtDatePaid.Location = new System.Drawing.Point(105, 19);
            this.txtDatePaid.Name = "txtDatePaid";
            this.txtDatePaid.ReadOnly = true;
            this.txtDatePaid.Size = new System.Drawing.Size(207, 20);
            this.txtDatePaid.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Date Paid:";
            // 
            // btnOk
            // 
            this.btnOk.Enabled = false;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOk.Image = global::PhotoStore.Properties.Resources.Done;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.Location = new System.Drawing.Point(326, 305);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(57, 32);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Amount To Cancel:";
            // 
            // txtAmountCancel
            // 
            this.txtAmountCancel.Location = new System.Drawing.Point(117, 224);
            this.txtAmountCancel.Name = "txtAmountCancel";
            this.txtAmountCancel.Size = new System.Drawing.Size(207, 20);
            this.txtAmountCancel.TabIndex = 5;
            this.txtAmountCancel.TextChanged += new System.EventHandler(this.txtAmountCancel_TextChanged);
            this.txtAmountCancel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmountCancel_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Mode of Payment";
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.ForeColor = System.Drawing.Color.Red;
            this.lblRemarks.Location = new System.Drawing.Point(15, 277);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(35, 13);
            this.lblRemarks.TabIndex = 8;
            this.lblRemarks.Text = "label8";
            // 
            // txtModeOfPayment
            // 
            this.txtModeOfPayment.Location = new System.Drawing.Point(117, 249);
            this.txtModeOfPayment.Name = "txtModeOfPayment";
            this.txtModeOfPayment.ReadOnly = true;
            this.txtModeOfPayment.Size = new System.Drawing.Size(207, 20);
            this.txtModeOfPayment.TabIndex = 9;
            // 
            // btnRemoved
            // 
            this.btnRemoved.Enabled = false;
            this.btnRemoved.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoved.Image = global::PhotoStore.Properties.Resources._001_02;
            this.btnRemoved.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoved.Location = new System.Drawing.Point(389, 305);
            this.btnRemoved.Name = "btnRemoved";
            this.btnRemoved.Size = new System.Drawing.Size(85, 33);
            this.btnRemoved.TabIndex = 10;
            this.btnRemoved.Text = "Removed";
            this.btnRemoved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoved.UseVisualStyleBackColor = true;
            this.btnRemoved.Click += new System.EventHandler(this.btnRemoved_Click);
            // 
            // rdoCash
            // 
            this.rdoCash.AutoSize = true;
            this.rdoCash.Location = new System.Drawing.Point(331, 249);
            this.rdoCash.Name = "rdoCash";
            this.rdoCash.Size = new System.Drawing.Size(49, 17);
            this.rdoCash.TabIndex = 11;
            this.rdoCash.TabStop = true;
            this.rdoCash.Text = "Cash";
            this.rdoCash.UseVisualStyleBackColor = true;
            this.rdoCash.Visible = false;
            this.rdoCash.CheckedChanged += new System.EventHandler(this.rdoCash_CheckedChanged);
            // 
            // rdo
            // 
            this.rdo.AutoSize = true;
            this.rdo.Location = new System.Drawing.Point(389, 249);
            this.rdo.Name = "rdo";
            this.rdo.Size = new System.Drawing.Size(56, 17);
            this.rdo.TabIndex = 12;
            this.rdo.TabStop = true;
            this.rdo.Text = "Check";
            this.rdo.UseVisualStyleBackColor = true;
            this.rdo.Visible = false;
            this.rdo.CheckedChanged += new System.EventHandler(this.rdoCheck_CheckedChanged);
            // 
            // CancelPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 338);
            this.Controls.Add(this.rdo);
            this.Controls.Add(this.rdoCash);
            this.Controls.Add(this.btnRemoved);
            this.Controls.Add(this.txtModeOfPayment);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAmountCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "CancelPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancel Payment";
            this.Load += new System.EventHandler(this.CancelPayment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDatePaid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDocumentNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtAmountPaid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBankFee;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAmountCancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtModeOfPayment;
        private System.Windows.Forms.Button btnRemoved;
        private System.Windows.Forms.RadioButton rdoCash;
        private System.Windows.Forms.RadioButton rdo;
    }
}