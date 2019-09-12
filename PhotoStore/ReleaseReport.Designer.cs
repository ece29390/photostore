namespace PhotoStore
{
    partial class ReleaseReport
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
            this.cboJobOrder = new System.Windows.Forms.ComboBox();
            this.btnReleaseReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboJobOrder
            // 
            this.cboJobOrder.FormattingEnabled = true;
            this.cboJobOrder.Location = new System.Drawing.Point(104, 5);
            this.cboJobOrder.Name = "cboJobOrder";
            this.cboJobOrder.Size = new System.Drawing.Size(121, 21);
            this.cboJobOrder.TabIndex = 1;
            this.cboJobOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboJobOrder_KeyPress);
            // 
            // btnReleaseReport
            // 
            this.btnReleaseReport.Location = new System.Drawing.Point(231, 3);
            this.btnReleaseReport.Name = "btnReleaseReport";
            this.btnReleaseReport.Size = new System.Drawing.Size(150, 23);
            this.btnReleaseReport.TabIndex = 2;
            this.btnReleaseReport.Text = "Generate Release Report";
            this.btnReleaseReport.UseVisualStyleBackColor = true;
            this.btnReleaseReport.Click += new System.EventHandler(this.btnReleaseReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Job Order Number:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReleaseReport);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboJobOrder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 35);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.reportViewer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(660, 390);
            this.panel2.TabIndex = 5;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(660, 390);
            this.reportViewer1.TabIndex = 1;
            // 
            // ReleaseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 425);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ReleaseReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReleaseReport";
            this.Load += new System.EventHandler(this.ReleaseReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboJobOrder;
        private System.Windows.Forms.Button btnReleaseReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}