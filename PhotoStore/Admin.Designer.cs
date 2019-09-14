namespace PhotoStore
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnJobs = new System.Windows.Forms.Button();
            this.btnPackages = new System.Windows.Forms.Button();
            this.btnFreebies = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.mnuUtility = new System.Windows.Forms.MenuStrip();
            this.dBUtilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonPrivilegeCard = new System.Windows.Forms.Button();
            this.btnParticularType = new System.Windows.Forms.Button();
            this.btnPriceList = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnUserManagement = new System.Windows.Forms.Button();
            this.btnCouponDatabase = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.btnGCDatabase = new System.Windows.Forms.Button();
            this.btnBalances = new System.Windows.Forms.Button();
            this.mnuUtility.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProducts
            // 
            this.btnProducts.Location = new System.Drawing.Point(340, 553);
            this.btnProducts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(129, 46);
            this.btnProducts.TabIndex = 40;
            this.btnProducts.Text = "Products";
            this.btnProducts.UseVisualStyleBackColor = true;
            this.btnProducts.Visible = false;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnJobs
            // 
            this.btnJobs.Enabled = false;
            this.btnJobs.Location = new System.Drawing.Point(203, 553);
            this.btnJobs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnJobs.Name = "btnJobs";
            this.btnJobs.Size = new System.Drawing.Size(129, 46);
            this.btnJobs.TabIndex = 40;
            this.btnJobs.Text = "Jobs";
            this.btnJobs.UseVisualStyleBackColor = true;
            this.btnJobs.Visible = false;
            // 
            // btnPackages
            // 
            this.btnPackages.Location = new System.Drawing.Point(489, 553);
            this.btnPackages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPackages.Name = "btnPackages";
            this.btnPackages.Size = new System.Drawing.Size(129, 46);
            this.btnPackages.TabIndex = 40;
            this.btnPackages.Text = "Packages";
            this.btnPackages.UseVisualStyleBackColor = true;
            this.btnPackages.Visible = false;
            this.btnPackages.Click += new System.EventHandler(this.btnPackages_Click);
            // 
            // btnFreebies
            // 
            this.btnFreebies.Location = new System.Drawing.Point(45, 553);
            this.btnFreebies.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFreebies.Name = "btnFreebies";
            this.btnFreebies.Size = new System.Drawing.Size(129, 46);
            this.btnFreebies.TabIndex = 41;
            this.btnFreebies.Text = "Freebies";
            this.btnFreebies.UseVisualStyleBackColor = true;
            this.btnFreebies.Visible = false;
            this.btnFreebies.Click += new System.EventHandler(this.btnFreebies_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExecute.Location = new System.Drawing.Point(301, 182);
            this.btnExecute.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(129, 106);
            this.btnExecute.TabIndex = 45;
            this.btnExecute.Text = "Execute Scripts";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Visible = false;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // mnuUtility
            // 
            this.mnuUtility.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuUtility.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dBUtilityToolStripMenuItem});
            this.mnuUtility.Location = new System.Drawing.Point(0, 0);
            this.mnuUtility.Name = "mnuUtility";
            this.mnuUtility.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mnuUtility.Size = new System.Drawing.Size(737, 28);
            this.mnuUtility.TabIndex = 46;
            this.mnuUtility.Text = "DBUtility";
            // 
            // dBUtilityToolStripMenuItem
            // 
            this.dBUtilityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backUpToolStripMenuItem,
            this.restoreToolStripMenuItem});
            this.dBUtilityToolStripMenuItem.Name = "dBUtilityToolStripMenuItem";
            this.dBUtilityToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.dBUtilityToolStripMenuItem.Text = "DB Utility";
            // 
            // backUpToolStripMenuItem
            // 
            this.backUpToolStripMenuItem.Name = "backUpToolStripMenuItem";
            this.backUpToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.backUpToolStripMenuItem.Text = "BackUp";
            this.backUpToolStripMenuItem.Click += new System.EventHandler(this.backUpToolStripMenuItem_Click);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.restoreToolStripMenuItem.Text = "Restore";
            this.restoreToolStripMenuItem.Visible = false;
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoreToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonPrivilegeCard
            // 
            this.buttonPrivilegeCard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPrivilegeCard.Image = global::PhotoStore.Properties.Resources.icons8_membership_card_64;
            this.buttonPrivilegeCard.Location = new System.Drawing.Point(301, 439);
            this.buttonPrivilegeCard.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPrivilegeCard.Name = "buttonPrivilegeCard";
            this.buttonPrivilegeCard.Size = new System.Drawing.Size(129, 106);
            this.buttonPrivilegeCard.TabIndex = 47;
            this.buttonPrivilegeCard.Text = "Privilege Card";
            this.buttonPrivilegeCard.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonPrivilegeCard.UseVisualStyleBackColor = true;
            this.buttonPrivilegeCard.Click += new System.EventHandler(this.ButtonPrivilegeCard_Click);
            // 
            // btnParticularType
            // 
            this.btnParticularType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnParticularType.Image = global::PhotoStore.Properties.Resources.Note_48_h_g;
            this.btnParticularType.Location = new System.Drawing.Point(509, 182);
            this.btnParticularType.Margin = new System.Windows.Forms.Padding(4);
            this.btnParticularType.Name = "btnParticularType";
            this.btnParticularType.Size = new System.Drawing.Size(129, 106);
            this.btnParticularType.TabIndex = 44;
            this.btnParticularType.Text = "Particular Type";
            this.btnParticularType.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnParticularType.UseVisualStyleBackColor = true;
            this.btnParticularType.Click += new System.EventHandler(this.btnParticularType_Click);
            // 
            // btnPriceList
            // 
            this.btnPriceList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPriceList.Image = global::PhotoStore.Properties.Resources.Task_List_48_n_g;
            this.btnPriceList.Location = new System.Drawing.Point(92, 58);
            this.btnPriceList.Margin = new System.Windows.Forms.Padding(4);
            this.btnPriceList.Name = "btnPriceList";
            this.btnPriceList.Size = new System.Drawing.Size(129, 106);
            this.btnPriceList.TabIndex = 43;
            this.btnPriceList.Text = "Price List";
            this.btnPriceList.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPriceList.UseVisualStyleBackColor = true;
            this.btnPriceList.Click += new System.EventHandler(this.btnPriceList_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSupplier.Image = global::PhotoStore.Properties.Resources.User_Group_1_48_n_g;
            this.btnSupplier.Location = new System.Drawing.Point(301, 309);
            this.btnSupplier.Margin = new System.Windows.Forms.Padding(4);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(129, 106);
            this.btnSupplier.TabIndex = 42;
            this.btnSupplier.Text = "Supplier";
            this.btnSupplier.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUserManagement.Image = global::PhotoStore.Properties.Resources.User_2_48_n_g;
            this.btnUserManagement.Location = new System.Drawing.Point(92, 182);
            this.btnUserManagement.Margin = new System.Windows.Forms.Padding(4);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Size = new System.Drawing.Size(129, 106);
            this.btnUserManagement.TabIndex = 40;
            this.btnUserManagement.Text = "User Management";
            this.btnUserManagement.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUserManagement.UseVisualStyleBackColor = true;
            this.btnUserManagement.Click += new System.EventHandler(this.btnUserManagement_Click);
            // 
            // btnCouponDatabase
            // 
            this.btnCouponDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCouponDatabase.Image = global::PhotoStore.Properties.Resources.Database_Record_48_n_g;
            this.btnCouponDatabase.Location = new System.Drawing.Point(509, 309);
            this.btnCouponDatabase.Margin = new System.Windows.Forms.Padding(4);
            this.btnCouponDatabase.Name = "btnCouponDatabase";
            this.btnCouponDatabase.Size = new System.Drawing.Size(129, 106);
            this.btnCouponDatabase.TabIndex = 40;
            this.btnCouponDatabase.Text = "Coupon Database";
            this.btnCouponDatabase.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCouponDatabase.UseVisualStyleBackColor = true;
            this.btnCouponDatabase.Click += new System.EventHandler(this.btnCouponDatabase_Click);
            // 
            // btnSales
            // 
            this.btnSales.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSales.Image = global::PhotoStore.Properties.Resources.Report___Histogram_48_h_g;
            this.btnSales.Location = new System.Drawing.Point(92, 309);
            this.btnSales.Margin = new System.Windows.Forms.Padding(4);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(129, 106);
            this.btnSales.TabIndex = 40;
            this.btnSales.Text = "Reports";
            this.btnSales.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSales.UseVisualStyleBackColor = true;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // btnGCDatabase
            // 
            this.btnGCDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGCDatabase.Image = global::PhotoStore.Properties.Resources.Certificate_48_n_g;
            this.btnGCDatabase.Location = new System.Drawing.Point(509, 58);
            this.btnGCDatabase.Margin = new System.Windows.Forms.Padding(4);
            this.btnGCDatabase.Name = "btnGCDatabase";
            this.btnGCDatabase.Size = new System.Drawing.Size(129, 106);
            this.btnGCDatabase.TabIndex = 40;
            this.btnGCDatabase.Text = "GC Database";
            this.btnGCDatabase.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGCDatabase.UseVisualStyleBackColor = true;
            this.btnGCDatabase.Click += new System.EventHandler(this.btnGCDatabase_Click);
            // 
            // btnBalances
            // 
            this.btnBalances.Enabled = false;
            this.btnBalances.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBalances.Image = global::PhotoStore.Properties.Resources.Coins_48_n_g;
            this.btnBalances.Location = new System.Drawing.Point(301, 58);
            this.btnBalances.Margin = new System.Windows.Forms.Padding(4);
            this.btnBalances.Name = "btnBalances";
            this.btnBalances.Size = new System.Drawing.Size(129, 106);
            this.btnBalances.TabIndex = 40;
            this.btnBalances.Text = "Balances";
            this.btnBalances.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBalances.UseVisualStyleBackColor = true;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 603);
            this.Controls.Add(this.buttonPrivilegeCard);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.btnParticularType);
            this.Controls.Add(this.btnPriceList);
            this.Controls.Add(this.btnSupplier);
            this.Controls.Add(this.btnFreebies);
            this.Controls.Add(this.btnUserManagement);
            this.Controls.Add(this.btnCouponDatabase);
            this.Controls.Add(this.btnJobs);
            this.Controls.Add(this.btnSales);
            this.Controls.Add(this.btnGCDatabase);
            this.Controls.Add(this.btnPackages);
            this.Controls.Add(this.btnBalances);
            this.Controls.Add(this.btnProducts);
            this.Controls.Add(this.mnuUtility);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuUtility;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Menu";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.mnuUtility.ResumeLayout(false);
            this.mnuUtility.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnBalances;
        private System.Windows.Forms.Button btnGCDatabase;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Button btnJobs;
        private System.Windows.Forms.Button btnCouponDatabase;
        private System.Windows.Forms.Button btnUserManagement;
        private System.Windows.Forms.Button btnPackages;
        private System.Windows.Forms.Button btnFreebies;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Button btnPriceList;
        private System.Windows.Forms.Button btnParticularType;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.MenuStrip mnuUtility;
        private System.Windows.Forms.ToolStripMenuItem dBUtilityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonPrivilegeCard;
    }
}