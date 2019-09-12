namespace PhotoStore
{
    partial class Startup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Startup));
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnTransactions = new System.Windows.Forms.Button();
            this.btnJobOrder = new System.Windows.Forms.Button();
            this.btnCustomerDatabase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdmin
            // 
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdmin.Image = global::PhotoStore.Properties.Resources.User_Group_2_48_h_g;
            this.btnAdmin.Location = new System.Drawing.Point(305, 150);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(128, 89);
            this.btnAdmin.TabIndex = 40;
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnTransactions
            // 
            this.btnTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTransactions.Image = global::PhotoStore.Properties.Resources.Invoice_48_n_g;
            this.btnTransactions.Location = new System.Drawing.Point(305, 41);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Size = new System.Drawing.Size(128, 89);
            this.btnTransactions.TabIndex = 40;
            this.btnTransactions.Text = "Transactions";
            this.btnTransactions.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTransactions.UseVisualStyleBackColor = true;
            this.btnTransactions.Click += new System.EventHandler(this.btnTransactions_Click);
            // 
            // btnJobOrder
            // 
            this.btnJobOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnJobOrder.Image = global::PhotoStore.Properties.Resources.Invoice_Stamped_48_n_g;
            this.btnJobOrder.Location = new System.Drawing.Point(116, 150);
            this.btnJobOrder.Name = "btnJobOrder";
            this.btnJobOrder.Size = new System.Drawing.Size(129, 89);
            this.btnJobOrder.TabIndex = 39;
            this.btnJobOrder.Text = "Job Order";
            this.btnJobOrder.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnJobOrder.UseVisualStyleBackColor = true;
            this.btnJobOrder.Click += new System.EventHandler(this.btnJobOrder_Click);
            // 
            // btnCustomerDatabase
            // 
            this.btnCustomerDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCustomerDatabase.Image = global::PhotoStore.Properties.Resources.Handshake_48_n_g;
            this.btnCustomerDatabase.Location = new System.Drawing.Point(118, 41);
            this.btnCustomerDatabase.Name = "btnCustomerDatabase";
            this.btnCustomerDatabase.Size = new System.Drawing.Size(127, 89);
            this.btnCustomerDatabase.TabIndex = 39;
            this.btnCustomerDatabase.Text = "Customer Database";
            this.btnCustomerDatabase.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCustomerDatabase.UseVisualStyleBackColor = true;
            this.btnCustomerDatabase.Click += new System.EventHandler(this.btnCustomerDatabase_Click);
            // 
            // Startup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PhotoStore.Properties.Resources.logo_outline;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(549, 285);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnTransactions);
            this.Controls.Add(this.btnJobOrder);
            this.Controls.Add(this.btnCustomerDatabase);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Startup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Photo Store";
            this.Load += new System.EventHandler(this.Startup_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Startup_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTransactions;
        private System.Windows.Forms.Button btnCustomerDatabase;
        private System.Windows.Forms.Button btnJobOrder;
        private System.Windows.Forms.Button btnAdmin;
    }
}