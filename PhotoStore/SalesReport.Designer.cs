namespace PhotoStore
{
    partial class SalesReport
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
            this.tabPeriod = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabOrder = new System.Windows.Forms.TabPage();
            this.tabSalesProduct = new System.Windows.Forms.TabPage();
            this.tabFrameSales = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dgSales = new System.Windows.Forms.DataGridView();
            this.dgOrder = new System.Windows.Forms.DataGridView();
            this.dgProduct = new System.Windows.Forms.DataGridView();
            this.dgFrameSales = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantitySold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSearchAll = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.colFrameDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFrame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaleDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmountPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBankFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCBankFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCNet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPeriod.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabOrder.SuspendLayout();
            this.tabSalesProduct.SuspendLayout();
            this.tabFrameSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFrameSales)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPeriod
            // 
            this.tabPeriod.Controls.Add(this.tabPage1);
            this.tabPeriod.Controls.Add(this.tabOrder);
            this.tabPeriod.Controls.Add(this.tabSalesProduct);
            this.tabPeriod.Controls.Add(this.tabFrameSales);
            this.tabPeriod.Location = new System.Drawing.Point(12, 63);
            this.tabPeriod.Name = "tabPeriod";
            this.tabPeriod.SelectedIndex = 0;
            this.tabPeriod.Size = new System.Drawing.Size(636, 350);
            this.tabPeriod.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgSales);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(628, 324);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Totals By Period";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabOrder
            // 
            this.tabOrder.Controls.Add(this.dgOrder);
            this.tabOrder.Location = new System.Drawing.Point(4, 22);
            this.tabOrder.Name = "tabOrder";
            this.tabOrder.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrder.Size = new System.Drawing.Size(628, 324);
            this.tabOrder.TabIndex = 1;
            this.tabOrder.Text = "Totals by Order";
            this.tabOrder.UseVisualStyleBackColor = true;
            // 
            // tabSalesProduct
            // 
            this.tabSalesProduct.Controls.Add(this.label4);
            this.tabSalesProduct.Controls.Add(this.btnSearchAll);
            this.tabSalesProduct.Controls.Add(this.btnSearch);
            this.tabSalesProduct.Controls.Add(this.txtSearch);
            this.tabSalesProduct.Controls.Add(this.lblSearch);
            this.tabSalesProduct.Controls.Add(this.dgProduct);
            this.tabSalesProduct.Location = new System.Drawing.Point(4, 22);
            this.tabSalesProduct.Name = "tabSalesProduct";
            this.tabSalesProduct.Padding = new System.Windows.Forms.Padding(3);
            this.tabSalesProduct.Size = new System.Drawing.Size(628, 324);
            this.tabSalesProduct.TabIndex = 2;
            this.tabSalesProduct.Text = "Sales by Product";
            this.tabSalesProduct.UseVisualStyleBackColor = true;
            // 
            // tabFrameSales
            // 
            this.tabFrameSales.Controls.Add(this.dgFrameSales);
            this.tabFrameSales.Location = new System.Drawing.Point(4, 22);
            this.tabFrameSales.Name = "tabFrameSales";
            this.tabFrameSales.Padding = new System.Windows.Forms.Padding(3);
            this.tabFrameSales.Size = new System.Drawing.Size(628, 324);
            this.tabFrameSales.TabIndex = 3;
            this.tabFrameSales.Text = "tabFrameSales";
            this.tabFrameSales.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Period Covered:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Start Date:";
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(89, 32);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(189, 20);
            this.dtpStart.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "End Date:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(336, 32);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(189, 20);
            this.dtpEndDate.TabIndex = 5;
            // 
            // dgSales
            // 
            this.dgSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSaleDate,
            this.colCash,
            this.colAmountPaid,
            this.colBankFee,
            this.colNet,
            this.colDue,
            this.colCBankFee,
            this.colCNet});
            this.dgSales.Location = new System.Drawing.Point(6, 24);
            this.dgSales.Name = "dgSales";
            this.dgSales.Size = new System.Drawing.Size(598, 294);
            this.dgSales.TabIndex = 0;
            // 
            // dgOrder
            // 
            this.dgOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colOrderNumber,
            this.colTotalAmount});
            this.dgOrder.Location = new System.Drawing.Point(12, 15);
            this.dgOrder.Name = "dgOrder";
            this.dgOrder.Size = new System.Drawing.Size(598, 261);
            this.dgOrder.TabIndex = 1;
            // 
            // dgProduct
            // 
            this.dgProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductName,
            this.colQuantitySold});
            this.dgProduct.Location = new System.Drawing.Point(6, 33);
            this.dgProduct.Name = "dgProduct";
            this.dgProduct.Size = new System.Drawing.Size(598, 285);
            this.dgProduct.TabIndex = 1;
            // 
            // dgFrameSales
            // 
            this.dgFrameSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFrameSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFrameDate,
            this.colOrder,
            this.colFrame,
            this.colQuantity});
            this.dgFrameSales.Location = new System.Drawing.Point(12, 19);
            this.dgFrameSales.Name = "dgFrameSales";
            this.dgFrameSales.Size = new System.Drawing.Size(598, 261);
            this.dgFrameSales.TabIndex = 1;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            // 
            // colOrderNumber
            // 
            this.colOrderNumber.HeaderText = "Order Number";
            this.colOrderNumber.Name = "colOrderNumber";
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.HeaderText = "Total Amount";
            this.colTotalAmount.Name = "colTotalAmount";
            // 
            // colProductName
            // 
            this.colProductName.HeaderText = "Product Name";
            this.colProductName.Name = "colProductName";
            // 
            // colQuantitySold
            // 
            this.colQuantitySold.HeaderText = "Quantity Sold";
            this.colQuantitySold.Name = "colQuantitySold";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(9, 12);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(130, 13);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search By Product Name:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(145, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(194, 20);
            this.txtSearch.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(345, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnSearchAll
            // 
            this.btnSearchAll.Location = new System.Drawing.Point(448, 4);
            this.btnSearchAll.Name = "btnSearchAll";
            this.btnSearchAll.Size = new System.Drawing.Size(75, 23);
            this.btnSearchAll.TabIndex = 5;
            this.btnSearchAll.Text = "Search All";
            this.btnSearchAll.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(426, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "or";
            // 
            // colFrameDate
            // 
            this.colFrameDate.HeaderText = "Date";
            this.colFrameDate.Name = "colFrameDate";
            // 
            // colOrder
            // 
            this.colOrder.HeaderText = "Order";
            this.colOrder.Name = "colOrder";
            // 
            // colFrame
            // 
            this.colFrame.HeaderText = "Frame Type";
            this.colFrame.Name = "colFrame";
            // 
            // colQuantity
            // 
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.Name = "colQuantity";
            // 
            // colSaleDate
            // 
            this.colSaleDate.HeaderText = "Date";
            this.colSaleDate.Name = "colSaleDate";
            // 
            // colCash
            // 
            this.colCash.HeaderText = "Cash";
            this.colCash.Name = "colCash";
            // 
            // colAmountPaid
            // 
            this.colAmountPaid.HeaderText = "Amount Paid";
            this.colAmountPaid.Name = "colAmountPaid";
            // 
            // colBankFee
            // 
            this.colBankFee.HeaderText = "Bank Fee";
            this.colBankFee.Name = "colBankFee";
            // 
            // colNet
            // 
            this.colNet.HeaderText = "Net Rcvd";
            this.colNet.Name = "colNet";
            // 
            // colDue
            // 
            this.colDue.HeaderText = "Due";
            this.colDue.Name = "colDue";
            // 
            // colCBankFee
            // 
            this.colCBankFee.HeaderText = "Bank Fee";
            this.colCBankFee.Name = "colCBankFee";
            // 
            // colCNet
            // 
            this.colCNet.HeaderText = "Net Rcvd";
            this.colCNet.Name = "colCNet";
            // 
            // SalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 425);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabPeriod);
            this.Name = "SalesReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Report";
            this.tabPeriod.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabOrder.ResumeLayout(false);
            this.tabSalesProduct.ResumeLayout(false);
            this.tabSalesProduct.PerformLayout();
            this.tabFrameSales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFrameSales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabPeriod;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabOrder;
        private System.Windows.Forms.TabPage tabSalesProduct;
        private System.Windows.Forms.TabPage tabFrameSales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgSales;
        private System.Windows.Forms.DataGridView dgOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmount;
        private System.Windows.Forms.DataGridView dgProduct;
        private System.Windows.Forms.DataGridView dgFrameSales;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearchAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantitySold;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFrameDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFrame;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaleDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCash;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmountPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBankFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCBankFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCNet;
    }
}