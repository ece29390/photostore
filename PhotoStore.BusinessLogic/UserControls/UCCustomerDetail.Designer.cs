namespace PhotoStore.BusinessLogic.UserControls
{
    partial class UCCustomerDetail
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboPriviledgeCard = new System.Windows.Forms.ComboBox();
            this.txtMothersName = new System.Windows.Forms.TextBox();
            this.txtFathersName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblFathersName = new System.Windows.Forms.Label();
            this.lblMothersName = new System.Windows.Forms.Label();
            this.lblPrivilegeCardCode = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpBirthDay = new System.Windows.Forms.DateTimePicker();
            this.lblBirthDay = new System.Windows.Forms.Label();
            this.txtCellNumber = new System.Windows.Forms.TextBox();
            this.lblCellNumber = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboPriviledgeCard
            // 
            this.cboPriviledgeCard.FormattingEnabled = true;
            this.cboPriviledgeCard.Location = new System.Drawing.Point(108, 3);
            this.cboPriviledgeCard.Name = "cboPriviledgeCard";
            this.cboPriviledgeCard.Size = new System.Drawing.Size(179, 21);
            this.cboPriviledgeCard.TabIndex = 0;
            this.cboPriviledgeCard.SelectedIndexChanged += new System.EventHandler(this.cboPriviledgeCard_SelectedIndexChanged);
            // 
            // txtMothersName
            // 
            this.txtMothersName.Location = new System.Drawing.Point(108, 30);
            this.txtMothersName.Name = "txtMothersName";
            this.txtMothersName.Size = new System.Drawing.Size(179, 20);
            this.txtMothersName.TabIndex = 2;
            // 
            // txtFathersName
            // 
            this.txtFathersName.Location = new System.Drawing.Point(108, 59);
            this.txtFathersName.Name = "txtFathersName";
            this.txtFathersName.Size = new System.Drawing.Size(179, 20);
            this.txtFathersName.TabIndex = 4;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(108, 85);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(179, 65);
            this.txtAddress.TabIndex = 5;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(7, 91);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 13);
            this.lblAddress.TabIndex = 44;
            this.lblAddress.Text = "Address:";
            // 
            // lblFathersName
            // 
            this.lblFathersName.AutoSize = true;
            this.lblFathersName.Location = new System.Drawing.Point(6, 62);
            this.lblFathersName.Name = "lblFathersName";
            this.lblFathersName.Size = new System.Drawing.Size(79, 13);
            this.lblFathersName.TabIndex = 42;
            this.lblFathersName.Text = "Daddy\'s Name:";
            // 
            // lblMothersName
            // 
            this.lblMothersName.AutoSize = true;
            this.lblMothersName.Location = new System.Drawing.Point(6, 33);
            this.lblMothersName.Name = "lblMothersName";
            this.lblMothersName.Size = new System.Drawing.Size(87, 13);
            this.lblMothersName.TabIndex = 40;
            this.lblMothersName.Text = "Mommy\'s  Name:";
            // 
            // lblPrivilegeCardCode
            // 
            this.lblPrivilegeCardCode.AutoSize = true;
            this.lblPrivilegeCardCode.Location = new System.Drawing.Point(6, 7);
            this.lblPrivilegeCardCode.Name = "lblPrivilegeCardCode";
            this.lblPrivilegeCardCode.Size = new System.Drawing.Size(85, 13);
            this.lblPrivilegeCardCode.TabIndex = 39;
            this.lblPrivilegeCardCode.Text = "Privilege Card #:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpBirthDay);
            this.panel1.Controls.Add(this.lblBirthDay);
            this.panel1.Controls.Add(this.txtCellNumber);
            this.panel1.Controls.Add(this.lblCellNumber);
            this.panel1.Controls.Add(this.cboPriviledgeCard);
            this.panel1.Controls.Add(this.lblPrivilegeCardCode);
            this.panel1.Controls.Add(this.txtMothersName);
            this.panel1.Controls.Add(this.lblMothersName);
            this.panel1.Controls.Add(this.txtFathersName);
            this.panel1.Controls.Add(this.lblFathersName);
            this.panel1.Controls.Add(this.txtAddress);
            this.panel1.Controls.Add(this.lblAddress);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 159);
            this.panel1.TabIndex = 47;
            // 
            // dtpBirthDay
            // 
            this.dtpBirthDay.CustomFormat = "";
            this.dtpBirthDay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDay.Location = new System.Drawing.Point(346, 29);
            this.dtpBirthDay.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpBirthDay.Name = "dtpBirthDay";
            this.dtpBirthDay.Size = new System.Drawing.Size(145, 20);
            this.dtpBirthDay.TabIndex = 3;
            this.dtpBirthDay.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // lblBirthDay
            // 
            this.lblBirthDay.AutoSize = true;
            this.lblBirthDay.Location = new System.Drawing.Point(293, 33);
            this.lblBirthDay.Name = "lblBirthDay";
            this.lblBirthDay.Size = new System.Drawing.Size(50, 13);
            this.lblBirthDay.TabIndex = 49;
            this.lblBirthDay.Text = "BirthDay:";
            // 
            // txtCellNumber
            // 
            this.txtCellNumber.Location = new System.Drawing.Point(346, 4);
            this.txtCellNumber.MaxLength = 15;
            this.txtCellNumber.Name = "txtCellNumber";
            this.txtCellNumber.Size = new System.Drawing.Size(145, 20);
            this.txtCellNumber.TabIndex = 1;
            // 
            // lblCellNumber
            // 
            this.lblCellNumber.AutoSize = true;
            this.lblCellNumber.Location = new System.Drawing.Point(303, 6);
            this.lblCellNumber.Name = "lblCellNumber";
            this.lblCellNumber.Size = new System.Drawing.Size(37, 13);
            this.lblCellNumber.TabIndex = 47;
            this.lblCellNumber.Text = "Cell #:";
            // 
            // UCCustomerDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UCCustomerDetail";
            this.Size = new System.Drawing.Size(509, 159);
            this.Load += new System.EventHandler(this.UCCustomerDetail_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPriviledgeCard;
        private System.Windows.Forms.TextBox txtMothersName;
        private System.Windows.Forms.TextBox txtFathersName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblFathersName;
        private System.Windows.Forms.Label lblMothersName;
        private System.Windows.Forms.Label lblPrivilegeCardCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpBirthDay;
        private System.Windows.Forms.Label lblBirthDay;
        private System.Windows.Forms.TextBox txtCellNumber;
        private System.Windows.Forms.Label lblCellNumber;
    }
}
