namespace PhotoStore
{
    partial class Customer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Customer));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Infos = new System.Windows.Forms.TabPage();
            this.gvChildren = new System.Windows.Forms.DataGridView();
            this.lblFathersCellNumber = new System.Windows.Forms.Label();
            this.txtFathersCellNumber = new System.Windows.Forms.TextBox();
            this.lblFathersBirthDate = new System.Windows.Forms.Label();
            this.txtFathersBirthDate = new System.Windows.Forms.TextBox();
            this.lblMothersCellNumber = new System.Windows.Forms.Label();
            this.txtMothersCellNumber = new System.Windows.Forms.TextBox();
            this.lblMothersBirthDate = new System.Windows.Forms.Label();
            this.txtMothersBirthDate = new System.Windows.Forms.TextBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.lblCDNumbers = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtFathersLandLine = new System.Windows.Forms.TextBox();
            this.txtMothersName = new System.Windows.Forms.TextBox();
            this.txtFathersName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtMothersLandLine = new System.Windows.Forms.TextBox();
            this.txtPrivilegeCardCode = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtCDNumbers = new System.Windows.Forms.TextBox();
            this.lblEMail = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblFathersName = new System.Windows.Forms.Label();
            this.lblFathersLandLine = new System.Windows.Forms.Label();
            this.lblMothersLandLine = new System.Windows.Forms.Label();
            this.lblMothersName = new System.Windows.Forms.Label();
            this.lblPrivilegeCardCode = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.Transactions = new System.Windows.Forms.TabPage();
            this.gvTransaction = new System.Windows.Forms.DataGridView();
            this.ColDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderTransactionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOrderNumber = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColParticular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDeleteChild = new System.Windows.Forms.Button();
            this.btnPrivilegeCard = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddChild = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAddAnother = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.colChildDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colSequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChildsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.Infos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvChildren)).BeginInit();
            this.Transactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTransaction)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Infos);
            this.tabControl1.Controls.Add(this.Transactions);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(625, 518);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Infos
            // 
            this.Infos.Controls.Add(this.btnDeleteChild);
            this.Infos.Controls.Add(this.btnPrivilegeCard);
            this.Infos.Controls.Add(this.btnDelete);
            this.Infos.Controls.Add(this.gvChildren);
            this.Infos.Controls.Add(this.btnAddChild);
            this.Infos.Controls.Add(this.btnMainMenu);
            this.Infos.Controls.Add(this.btnSearch);
            this.Infos.Controls.Add(this.btnAddAnother);
            this.Infos.Controls.Add(this.btnSave);
            this.Infos.Controls.Add(this.lblFathersCellNumber);
            this.Infos.Controls.Add(this.txtFathersCellNumber);
            this.Infos.Controls.Add(this.lblFathersBirthDate);
            this.Infos.Controls.Add(this.txtFathersBirthDate);
            this.Infos.Controls.Add(this.lblMothersCellNumber);
            this.Infos.Controls.Add(this.txtMothersCellNumber);
            this.Infos.Controls.Add(this.lblMothersBirthDate);
            this.Infos.Controls.Add(this.txtMothersBirthDate);
            this.Infos.Controls.Add(this.lblArea);
            this.Infos.Controls.Add(this.txtArea);
            this.Infos.Controls.Add(this.lblCDNumbers);
            this.Infos.Controls.Add(this.txtEmail);
            this.Infos.Controls.Add(this.txtFathersLandLine);
            this.Infos.Controls.Add(this.txtMothersName);
            this.Infos.Controls.Add(this.txtFathersName);
            this.Infos.Controls.Add(this.txtAddress);
            this.Infos.Controls.Add(this.txtMothersLandLine);
            this.Infos.Controls.Add(this.txtPrivilegeCardCode);
            this.Infos.Controls.Add(this.txtCode);
            this.Infos.Controls.Add(this.txtCDNumbers);
            this.Infos.Controls.Add(this.lblEMail);
            this.Infos.Controls.Add(this.lblAddress);
            this.Infos.Controls.Add(this.lblFathersName);
            this.Infos.Controls.Add(this.lblFathersLandLine);
            this.Infos.Controls.Add(this.lblMothersLandLine);
            this.Infos.Controls.Add(this.lblMothersName);
            this.Infos.Controls.Add(this.lblPrivilegeCardCode);
            this.Infos.Controls.Add(this.lblCode);
            this.Infos.Location = new System.Drawing.Point(4, 22);
            this.Infos.Name = "Infos";
            this.Infos.Padding = new System.Windows.Forms.Padding(3);
            this.Infos.Size = new System.Drawing.Size(617, 492);
            this.Infos.TabIndex = 0;
            this.Infos.Text = "Infos:";
            this.Infos.UseVisualStyleBackColor = true;
            // 
            // gvChildren
            // 
            this.gvChildren.AllowUserToAddRows = false;
            this.gvChildren.AllowUserToDeleteRows = false;
            this.gvChildren.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvChildren.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChildDelete,
            this.colSequence,
            this.colId,
            this.colCustomerId,
            this.colChildsName,
            this.colBirthDate});
            this.gvChildren.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gvChildren.Location = new System.Drawing.Point(25, 261);
            this.gvChildren.Name = "gvChildren";
            this.gvChildren.RowHeadersVisible = false;
            this.gvChildren.Size = new System.Drawing.Size(380, 184);
            this.gvChildren.TabIndex = 22;
            this.gvChildren.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gvChildren_DataError);
            this.gvChildren.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvChildren_KeyDown);
            this.gvChildren.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gvChildren_DataBindingComplete);
            this.gvChildren.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvChildren_CellContentClick);
            // 
            // lblFathersCellNumber
            // 
            this.lblFathersCellNumber.AutoSize = true;
            this.lblFathersCellNumber.Location = new System.Drawing.Point(323, 164);
            this.lblFathersCellNumber.Name = "lblFathersCellNumber";
            this.lblFathersCellNumber.Size = new System.Drawing.Size(67, 13);
            this.lblFathersCellNumber.TabIndex = 20;
            this.lblFathersCellNumber.Text = "Cellphone #:";
            // 
            // txtFathersCellNumber
            // 
            this.txtFathersCellNumber.Location = new System.Drawing.Point(396, 160);
            this.txtFathersCellNumber.Name = "txtFathersCellNumber";
            this.txtFathersCellNumber.Size = new System.Drawing.Size(179, 20);
            this.txtFathersCellNumber.TabIndex = 12;
            // 
            // lblFathersBirthDate
            // 
            this.lblFathersBirthDate.AutoSize = true;
            this.lblFathersBirthDate.Location = new System.Drawing.Point(323, 136);
            this.lblFathersBirthDate.Name = "lblFathersBirthDate";
            this.lblFathersBirthDate.Size = new System.Drawing.Size(48, 13);
            this.lblFathersBirthDate.TabIndex = 16;
            this.lblFathersBirthDate.Text = "Birthday:";
            // 
            // txtFathersBirthDate
            // 
            this.txtFathersBirthDate.Location = new System.Drawing.Point(396, 133);
            this.txtFathersBirthDate.Name = "txtFathersBirthDate";
            this.txtFathersBirthDate.Size = new System.Drawing.Size(179, 20);
            this.txtFathersBirthDate.TabIndex = 10;
            // 
            // lblMothersCellNumber
            // 
            this.lblMothersCellNumber.AutoSize = true;
            this.lblMothersCellNumber.Location = new System.Drawing.Point(323, 110);
            this.lblMothersCellNumber.Name = "lblMothersCellNumber";
            this.lblMothersCellNumber.Size = new System.Drawing.Size(67, 13);
            this.lblMothersCellNumber.TabIndex = 12;
            this.lblMothersCellNumber.Text = "Cellphone #:";
            // 
            // txtMothersCellNumber
            // 
            this.txtMothersCellNumber.Location = new System.Drawing.Point(396, 107);
            this.txtMothersCellNumber.Name = "txtMothersCellNumber";
            this.txtMothersCellNumber.Size = new System.Drawing.Size(179, 20);
            this.txtMothersCellNumber.TabIndex = 8;
            // 
            // lblMothersBirthDate
            // 
            this.lblMothersBirthDate.AutoSize = true;
            this.lblMothersBirthDate.Location = new System.Drawing.Point(323, 84);
            this.lblMothersBirthDate.Name = "lblMothersBirthDate";
            this.lblMothersBirthDate.Size = new System.Drawing.Size(48, 13);
            this.lblMothersBirthDate.TabIndex = 8;
            this.lblMothersBirthDate.Text = "Birthday:";
            // 
            // txtMothersBirthDate
            // 
            this.txtMothersBirthDate.Location = new System.Drawing.Point(396, 81);
            this.txtMothersBirthDate.Name = "txtMothersBirthDate";
            this.txtMothersBirthDate.Size = new System.Drawing.Size(179, 20);
            this.txtMothersBirthDate.TabIndex = 6;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(323, 189);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(32, 13);
            this.lblArea.TabIndex = 24;
            this.lblArea.Text = "Area:";
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(396, 186);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(179, 20);
            this.txtArea.TabIndex = 14;
            // 
            // lblCDNumbers
            // 
            this.lblCDNumbers.AutoSize = true;
            this.lblCDNumbers.Location = new System.Drawing.Point(323, 58);
            this.lblCDNumbers.Name = "lblCDNumbers";
            this.lblCDNumbers.Size = new System.Drawing.Size(43, 13);
            this.lblCDNumbers.TabIndex = 4;
            this.lblCDNumbers.Text = "CD #s :";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(123, 209);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(179, 20);
            this.txtEmail.TabIndex = 15;
            // 
            // txtFathersLandLine
            // 
            this.txtFathersLandLine.Location = new System.Drawing.Point(123, 159);
            this.txtFathersLandLine.Name = "txtFathersLandLine";
            this.txtFathersLandLine.Size = new System.Drawing.Size(179, 20);
            this.txtFathersLandLine.TabIndex = 11;
            // 
            // txtMothersName
            // 
            this.txtMothersName.Location = new System.Drawing.Point(123, 81);
            this.txtMothersName.Name = "txtMothersName";
            this.txtMothersName.Size = new System.Drawing.Size(179, 20);
            this.txtMothersName.TabIndex = 5;
            // 
            // txtFathersName
            // 
            this.txtFathersName.Location = new System.Drawing.Point(123, 133);
            this.txtFathersName.Name = "txtFathersName";
            this.txtFathersName.Size = new System.Drawing.Size(179, 20);
            this.txtFathersName.TabIndex = 9;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(123, 183);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(179, 20);
            this.txtAddress.TabIndex = 13;
            // 
            // txtMothersLandLine
            // 
            this.txtMothersLandLine.Location = new System.Drawing.Point(123, 107);
            this.txtMothersLandLine.Name = "txtMothersLandLine";
            this.txtMothersLandLine.Size = new System.Drawing.Size(179, 20);
            this.txtMothersLandLine.TabIndex = 7;
            // 
            // txtPrivilegeCardCode
            // 
            this.txtPrivilegeCardCode.Location = new System.Drawing.Point(123, 55);
            this.txtPrivilegeCardCode.Name = "txtPrivilegeCardCode";
            this.txtPrivilegeCardCode.ReadOnly = true;
            this.txtPrivilegeCardCode.Size = new System.Drawing.Size(153, 20);
            this.txtPrivilegeCardCode.TabIndex = 2;
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(123, 26);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(179, 20);
            this.txtCode.TabIndex = 1;
            // 
            // txtCDNumbers
            // 
            this.txtCDNumbers.Location = new System.Drawing.Point(396, 55);
            this.txtCDNumbers.Name = "txtCDNumbers";
            this.txtCDNumbers.Size = new System.Drawing.Size(179, 20);
            this.txtCDNumbers.TabIndex = 4;
            // 
            // lblEMail
            // 
            this.lblEMail.AutoSize = true;
            this.lblEMail.Location = new System.Drawing.Point(22, 209);
            this.lblEMail.Name = "lblEMail";
            this.lblEMail.Size = new System.Drawing.Size(39, 13);
            this.lblEMail.TabIndex = 26;
            this.lblEMail.Text = "E-Mail:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(22, 189);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 13);
            this.lblAddress.TabIndex = 22;
            this.lblAddress.Text = "Address:";
            // 
            // lblFathersName
            // 
            this.lblFathersName.AutoSize = true;
            this.lblFathersName.Location = new System.Drawing.Point(21, 136);
            this.lblFathersName.Name = "lblFathersName";
            this.lblFathersName.Size = new System.Drawing.Size(79, 13);
            this.lblFathersName.TabIndex = 14;
            this.lblFathersName.Text = "Daddy\'s Name:";
            // 
            // lblFathersLandLine
            // 
            this.lblFathersLandLine.AutoSize = true;
            this.lblFathersLandLine.Location = new System.Drawing.Point(22, 163);
            this.lblFathersLandLine.Name = "lblFathersLandLine";
            this.lblFathersLandLine.Size = new System.Drawing.Size(50, 13);
            this.lblFathersLandLine.TabIndex = 18;
            this.lblFathersLandLine.Text = "Landline:";
            // 
            // lblMothersLandLine
            // 
            this.lblMothersLandLine.AutoSize = true;
            this.lblMothersLandLine.Location = new System.Drawing.Point(22, 110);
            this.lblMothersLandLine.Name = "lblMothersLandLine";
            this.lblMothersLandLine.Size = new System.Drawing.Size(50, 13);
            this.lblMothersLandLine.TabIndex = 10;
            this.lblMothersLandLine.Text = "Landline:";
            // 
            // lblMothersName
            // 
            this.lblMothersName.AutoSize = true;
            this.lblMothersName.Location = new System.Drawing.Point(21, 84);
            this.lblMothersName.Name = "lblMothersName";
            this.lblMothersName.Size = new System.Drawing.Size(84, 13);
            this.lblMothersName.TabIndex = 6;
            this.lblMothersName.Text = "Mommy\'s Name:";
            // 
            // lblPrivilegeCardCode
            // 
            this.lblPrivilegeCardCode.AutoSize = true;
            this.lblPrivilegeCardCode.Location = new System.Drawing.Point(21, 58);
            this.lblPrivilegeCardCode.Name = "lblPrivilegeCardCode";
            this.lblPrivilegeCardCode.Size = new System.Drawing.Size(85, 13);
            this.lblPrivilegeCardCode.TabIndex = 2;
            this.lblPrivilegeCardCode.Text = "Privilege Card #:";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(22, 29);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(78, 13);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Customer ID #:";
            // 
            // Transactions
            // 
            this.Transactions.Controls.Add(this.gvTransaction);
            this.Transactions.Location = new System.Drawing.Point(4, 22);
            this.Transactions.Name = "Transactions";
            this.Transactions.Padding = new System.Windows.Forms.Padding(3);
            this.Transactions.Size = new System.Drawing.Size(617, 492);
            this.Transactions.TabIndex = 1;
            this.Transactions.Text = "Transactions";
            this.Transactions.UseVisualStyleBackColor = true;
            // 
            // gvTransaction
            // 
            this.gvTransaction.AllowUserToAddRows = false;
            this.gvTransaction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvTransaction.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gvTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTransaction.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColDate,
            this.colOrderTransactionId,
            this.ColOrderNumber,
            this.ColParticular,
            this.ColAmount});
            this.gvTransaction.Location = new System.Drawing.Point(6, 6);
            this.gvTransaction.Name = "gvTransaction";
            this.gvTransaction.Size = new System.Drawing.Size(605, 480);
            this.gvTransaction.TabIndex = 57;
            this.gvTransaction.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvTransaction_CellContentClick);
            // 
            // ColDate
            // 
            this.ColDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColDate.DataPropertyName = "DateCreated";
            this.ColDate.HeaderText = "Date";
            this.ColDate.Name = "ColDate";
            // 
            // colOrderTransactionId
            // 
            this.colOrderTransactionId.DataPropertyName = "OrderTransactionId";
            this.colOrderTransactionId.HeaderText = "OrderTransactionId";
            this.colOrderTransactionId.Name = "colOrderTransactionId";
            this.colOrderTransactionId.ReadOnly = true;
            this.colOrderTransactionId.Visible = false;
            // 
            // ColOrderNumber
            // 
            this.ColOrderNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColOrderNumber.DataPropertyName = "OrderNumber";
            this.ColOrderNumber.HeaderText = "Order Number";
            this.ColOrderNumber.Name = "ColOrderNumber";
            this.ColOrderNumber.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColOrderNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColParticular
            // 
            this.ColParticular.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColParticular.DataPropertyName = "Particulars";
            this.ColParticular.HeaderText = "Particular";
            this.ColParticular.Name = "ColParticular";
            // 
            // ColAmount
            // 
            this.ColAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColAmount.DataPropertyName = "Amount";
            this.ColAmount.HeaderText = "Amount";
            this.ColAmount.Name = "ColAmount";
            // 
            // btnDeleteChild
            // 
            this.btnDeleteChild.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteChild.Image = global::PhotoStore.Properties.Resources.Delete_User_2_24_n_t;
            this.btnDeleteChild.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteChild.Location = new System.Drawing.Point(326, 451);
            this.btnDeleteChild.Name = "btnDeleteChild";
            this.btnDeleteChild.Size = new System.Drawing.Size(79, 26);
            this.btnDeleteChild.TabIndex = 27;
            this.btnDeleteChild.Text = "De&lete Child";
            this.btnDeleteChild.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteChild.UseVisualStyleBackColor = true;
            this.btnDeleteChild.Click += new System.EventHandler(this.btnDeleteChild_Click);
            // 
            // btnPrivilegeCard
            // 
            this.btnPrivilegeCard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrivilegeCard.Image = global::PhotoStore.Properties.Resources.Lookup;
            this.btnPrivilegeCard.Location = new System.Drawing.Point(277, 53);
            this.btnPrivilegeCard.Name = "btnPrivilegeCard";
            this.btnPrivilegeCard.Size = new System.Drawing.Size(25, 23);
            this.btnPrivilegeCard.TabIndex = 3;
            this.btnPrivilegeCard.UseVisualStyleBackColor = true;
            this.btnPrivilegeCard.Click += new System.EventHandler(this.btnPrivilegeCard_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Image = global::PhotoStore.Properties.Resources.Delete_User_1_32_h_g;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.Location = new System.Drawing.Point(464, 433);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 37);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddChild
            // 
            this.btnAddChild.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddChild.Image = global::PhotoStore.Properties.Resources.Add_User_3_24_h_g;
            this.btnAddChild.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddChild.Location = new System.Drawing.Point(241, 451);
            this.btnAddChild.Name = "btnAddChild";
            this.btnAddChild.Size = new System.Drawing.Size(79, 26);
            this.btnAddChild.TabIndex = 21;
            this.btnAddChild.Text = "Add &Child";
            this.btnAddChild.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddChild.UseVisualStyleBackColor = true;
            this.btnAddChild.Click += new System.EventHandler(this.btnAddChild_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMainMenu.Image = global::PhotoStore.Properties.Resources.View_List_32_h_g;
            this.btnMainMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMainMenu.Location = new System.Drawing.Point(464, 390);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(97, 37);
            this.btnMainMenu.TabIndex = 19;
            this.btnMainMenu.Text = "&Main Menu";
            this.btnMainMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Image = global::PhotoStore.Properties.Resources.Search_32_h_g1;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.Location = new System.Drawing.Point(464, 347);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(97, 37);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "S&earch";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAddAnother
            // 
            this.btnAddAnother.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddAnother.Image = global::PhotoStore.Properties.Resources.Add_User_1_32_h_g;
            this.btnAddAnother.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddAnother.Location = new System.Drawing.Point(464, 304);
            this.btnAddAnother.Name = "btnAddAnother";
            this.btnAddAnother.Size = new System.Drawing.Size(97, 37);
            this.btnAddAnother.TabIndex = 17;
            this.btnAddAnother.Text = "&Add Another";
            this.btnAddAnother.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddAnother.UseVisualStyleBackColor = true;
            this.btnAddAnother.Click += new System.EventHandler(this.btnAddAnother_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Image = global::PhotoStore.Properties.Resources.Save_Blue_32_h_g;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(464, 261);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 37);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "&Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // colChildDelete
            // 
            this.colChildDelete.HeaderText = "";
            this.colChildDelete.Name = "colChildDelete";
            this.colChildDelete.Width = 50;
            // 
            // colSequence
            // 
            this.colSequence.HeaderText = "";
            this.colSequence.Name = "colSequence";
            this.colSequence.ReadOnly = true;
            this.colSequence.Visible = false;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colCustomerId
            // 
            this.colCustomerId.DataPropertyName = "CustomerId";
            this.colCustomerId.HeaderText = "CustomerId";
            this.colCustomerId.Name = "colCustomerId";
            this.colCustomerId.Visible = false;
            // 
            // colChildsName
            // 
            this.colChildsName.DataPropertyName = "Name";
            this.colChildsName.HeaderText = "Child\'s Name";
            this.colChildsName.Name = "colChildsName";
            // 
            // colBirthDate
            // 
            this.colBirthDate.DataPropertyName = "BirthDate";
            this.colBirthDate.HeaderText = "Birth Date";
            this.colBirthDate.Name = "colBirthDate";
            // 
            // Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 548);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Customer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Profile";
            this.Load += new System.EventHandler(this.CustomerProfile_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Customer_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.Infos.ResumeLayout(false);
            this.Infos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvChildren)).EndInit();
            this.Transactions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvTransaction)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddAnother;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Infos;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblFathersCellNumber;
        private System.Windows.Forms.TextBox txtFathersCellNumber;
        private System.Windows.Forms.Label lblFathersBirthDate;
        private System.Windows.Forms.TextBox txtFathersBirthDate;
        private System.Windows.Forms.Label lblMothersCellNumber;
        private System.Windows.Forms.TextBox txtMothersCellNumber;
        private System.Windows.Forms.Label lblMothersBirthDate;
        private System.Windows.Forms.TextBox txtMothersBirthDate;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Label lblCDNumbers;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtFathersLandLine;
        private System.Windows.Forms.TextBox txtMothersName;
        private System.Windows.Forms.TextBox txtFathersName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtMothersLandLine;
        private System.Windows.Forms.TextBox txtPrivilegeCardCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtCDNumbers;
        private System.Windows.Forms.Label lblEMail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblFathersName;
        private System.Windows.Forms.Label lblFathersLandLine;
        private System.Windows.Forms.Label lblMothersLandLine;
        private System.Windows.Forms.Label lblMothersName;
        private System.Windows.Forms.Label lblPrivilegeCardCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TabPage Transactions;
        private System.Windows.Forms.DataGridView gvTransaction;
        private System.Windows.Forms.Button btnAddChild;
        private System.Windows.Forms.DataGridView gvChildren;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPrivilegeCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderTransactionId;
        private System.Windows.Forms.DataGridViewLinkColumn ColOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColParticular;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmount;
        private System.Windows.Forms.Button btnDeleteChild;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChildDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSequence;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChildsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBirthDate;
    }
}