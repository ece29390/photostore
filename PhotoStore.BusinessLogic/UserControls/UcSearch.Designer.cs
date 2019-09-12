namespace PhotoStore.BusinessLogic.UserControls
{
    partial class UcSearch
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchCode = new System.Windows.Forms.TextBox();
            this.btnSeaarch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // txtSearchCode
            // 
            this.txtSearchCode.Location = new System.Drawing.Point(94, 4);
            this.txtSearchCode.MaxLength = 20;
            this.txtSearchCode.Name = "txtSearchCode";
            this.txtSearchCode.Size = new System.Drawing.Size(128, 20);
            this.txtSearchCode.TabIndex = 1;
            // 
            // btnSeaarch
            // 
            this.btnSeaarch.Location = new System.Drawing.Point(245, 4);
            this.btnSeaarch.Name = "btnSeaarch";
            this.btnSeaarch.Size = new System.Drawing.Size(75, 23);
            this.btnSeaarch.TabIndex = 2;
            this.btnSeaarch.Text = "Search";
            this.btnSeaarch.UseVisualStyleBackColor = true;
            this.btnSeaarch.Click += new System.EventHandler(this.btnSeaarch_Click);
            // 
            // UcSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSeaarch);
            this.Controls.Add(this.txtSearchCode);
            this.Controls.Add(this.label1);
            this.Name = "UcSearch";
            this.Size = new System.Drawing.Size(336, 30);
            this.Load += new System.EventHandler(this.UcSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchCode;
        private System.Windows.Forms.Button btnSeaarch;
    }
}
