namespace PhotoStore
{
    partial class PreJobOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreJobOrder));
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCreateAmend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Image = global::PhotoStore.Properties.Resources.Search_48_h_g;
            this.btnSearch.Location = new System.Drawing.Point(238, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(142, 80);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search Job Order";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCreateAmend
            // 
            this.btnCreateAmend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreateAmend.Image = global::PhotoStore.Properties.Resources.Add_Document_2_48_h_g;
            this.btnCreateAmend.Location = new System.Drawing.Point(65, 12);
            this.btnCreateAmend.Name = "btnCreateAmend";
            this.btnCreateAmend.Size = new System.Drawing.Size(142, 80);
            this.btnCreateAmend.TabIndex = 0;
            this.btnCreateAmend.Text = "Create /Amend Job Order";
            this.btnCreateAmend.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCreateAmend.UseVisualStyleBackColor = true;
            this.btnCreateAmend.Click += new System.EventHandler(this.btnCreateAmend_Click);
            // 
            // PreJobOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 104);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnCreateAmend);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PreJobOrder";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pre Job Order";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateAmend;
        private System.Windows.Forms.Button btnSearch;
    }
}