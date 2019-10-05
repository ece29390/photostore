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
            this.checkBoxIncludeBirthday = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboPriviledgeCard
            // 
            this.cboPriviledgeCard.FormattingEnabled = true;
            this.cboPriviledgeCard.Location = new System.Drawing.Point(144, 4);
            this.cboPriviledgeCard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboPriviledgeCard.Name = "cboPriviledgeCard";
            this.cboPriviledgeCard.Size = new System.Drawing.Size(237, 24);
            this.cboPriviledgeCard.TabIndex = 0;
            this.cboPriviledgeCard.SelectedIndexChanged += new System.EventHandler(this.cboPriviledgeCard_SelectedIndexChanged);
            // 
            // txtMothersName
            // 
            this.txtMothersName.Location = new System.Drawing.Point(144, 37);
            this.txtMothersName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMothersName.Name = "txtMothersName";
            this.txtMothersName.Size = new System.Drawing.Size(237, 22);
            this.txtMothersName.TabIndex = 2;
            // 
            // txtFathersName
            // 
            this.txtFathersName.Location = new System.Drawing.Point(144, 73);
            this.txtFathersName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFathersName.Name = "txtFathersName";
            this.txtFathersName.Size = new System.Drawing.Size(237, 22);
            this.txtFathersName.TabIndex = 4;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(144, 105);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(237, 79);
            this.txtAddress.TabIndex = 5;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(9, 112);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(64, 17);
            this.lblAddress.TabIndex = 44;
            this.lblAddress.Text = "Address:";
            // 
            // lblFathersName
            // 
            this.lblFathersName.AutoSize = true;
            this.lblFathersName.Location = new System.Drawing.Point(8, 76);
            this.lblFathersName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFathersName.Name = "lblFathersName";
            this.lblFathersName.Size = new System.Drawing.Size(104, 17);
            this.lblFathersName.TabIndex = 42;
            this.lblFathersName.Text = "Daddy\'s Name:";
            // 
            // lblMothersName
            // 
            this.lblMothersName.AutoSize = true;
            this.lblMothersName.Location = new System.Drawing.Point(8, 41);
            this.lblMothersName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMothersName.Name = "lblMothersName";
            this.lblMothersName.Size = new System.Drawing.Size(115, 17);
            this.lblMothersName.TabIndex = 40;
            this.lblMothersName.Text = "Mommy\'s  Name:";
            // 
            // lblPrivilegeCardCode
            // 
            this.lblPrivilegeCardCode.AutoSize = true;
            this.lblPrivilegeCardCode.Location = new System.Drawing.Point(8, 9);
            this.lblPrivilegeCardCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrivilegeCardCode.Name = "lblPrivilegeCardCode";
            this.lblPrivilegeCardCode.Size = new System.Drawing.Size(112, 17);
            this.lblPrivilegeCardCode.TabIndex = 39;
            this.lblPrivilegeCardCode.Text = "Privilege Card #:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxIncludeBirthday);
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
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 196);
            this.panel1.TabIndex = 47;
            // 
            // dtpBirthDay
            // 
            this.dtpBirthDay.CustomFormat = "";
            this.dtpBirthDay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDay.Location = new System.Drawing.Point(474, 62);
            this.dtpBirthDay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpBirthDay.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpBirthDay.Name = "dtpBirthDay";
            this.dtpBirthDay.Size = new System.Drawing.Size(192, 22);
            this.dtpBirthDay.TabIndex = 3;
            this.dtpBirthDay.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpBirthDay.Visible = false;
            // 
            // lblBirthDay
            // 
            this.lblBirthDay.AutoSize = true;
            this.lblBirthDay.Location = new System.Drawing.Point(404, 67);
            this.lblBirthDay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBirthDay.Name = "lblBirthDay";
            this.lblBirthDay.Size = new System.Drawing.Size(66, 17);
            this.lblBirthDay.TabIndex = 49;
            this.lblBirthDay.Text = "BirthDay:";
            this.lblBirthDay.Visible = false;
            // 
            // txtCellNumber
            // 
            this.txtCellNumber.Location = new System.Drawing.Point(461, 5);
            this.txtCellNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCellNumber.MaxLength = 15;
            this.txtCellNumber.Name = "txtCellNumber";
            this.txtCellNumber.Size = new System.Drawing.Size(192, 22);
            this.txtCellNumber.TabIndex = 1;
            // 
            // lblCellNumber
            // 
            this.lblCellNumber.AutoSize = true;
            this.lblCellNumber.Location = new System.Drawing.Point(404, 7);
            this.lblCellNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCellNumber.Name = "lblCellNumber";
            this.lblCellNumber.Size = new System.Drawing.Size(47, 17);
            this.lblCellNumber.TabIndex = 47;
            this.lblCellNumber.Text = "Cell #:";
            // 
            // checkBoxIncludeBirthday
            // 
            this.checkBoxIncludeBirthday.AutoSize = true;
            this.checkBoxIncludeBirthday.Location = new System.Drawing.Point(407, 34);
            this.checkBoxIncludeBirthday.Name = "checkBoxIncludeBirthday";
            this.checkBoxIncludeBirthday.Size = new System.Drawing.Size(139, 21);
            this.checkBoxIncludeBirthday.TabIndex = 50;
            this.checkBoxIncludeBirthday.Text = "Include Birthday?";
            this.checkBoxIncludeBirthday.UseVisualStyleBackColor = true;
            this.checkBoxIncludeBirthday.CheckedChanged += new System.EventHandler(this.CheckBoxIncludeBirthday_CheckedChanged);
            // 
            // UCCustomerDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UCCustomerDetail";
            this.Size = new System.Drawing.Size(679, 196);
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
        private System.Windows.Forms.CheckBox checkBoxIncludeBirthday;
    }
}
