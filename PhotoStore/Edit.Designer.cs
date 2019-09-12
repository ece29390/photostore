namespace PhotoStore
{
    partial class Edit
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
            this.ucAddEdit1 = new PhotoStore.BusinessLogic.UserControls.UCAddEdit();
            this.SuspendLayout();
            // 
            // ucAddEdit1
            // 
            this.ucAddEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAddEdit1.Location = new System.Drawing.Point(0, 0);
            this.ucAddEdit1.Name = "ucAddEdit1";
            this.ucAddEdit1.Size = new System.Drawing.Size(352, 203);
            this.ucAddEdit1.TabIndex = 0;
            // 
            // Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 203);
            this.Controls.Add(this.ucAddEdit1);
            this.Name = "Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit";
            this.Load += new System.EventHandler(this.Edit_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private PhotoStore.BusinessLogic.UserControls.UCAddEdit ucAddEdit1;
    }
}