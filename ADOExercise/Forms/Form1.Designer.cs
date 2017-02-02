namespace ADOExercise
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.dataAnnualReport = new System.Windows.Forms.DataGridView();
            this.getAnnualReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataOrdersByYear = new System.Windows.Forms.DataGridView();
            this.dataOrderItem = new System.Windows.Forms.DataGridView();
            this.getCurrentYearBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.getOrderItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblAnnualReport = new System.Windows.Forms.Label();
            this.ibiOrders = new System.Windows.Forms.Label();
            this.lblOrderItems = new System.Windows.Forms.Label();
            this.btnShowProductWindow = new System.Windows.Forms.Button();
            this.tnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataAnnualReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getAnnualReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataOrdersByYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataOrderItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getCurrentYearBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getOrderItemsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataAnnualReport
            // 
            this.dataAnnualReport.AllowUserToOrderColumns = true;
            this.dataAnnualReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAnnualReport.Location = new System.Drawing.Point(11, 22);
            this.dataAnnualReport.Name = "dataAnnualReport";
            this.dataAnnualReport.Size = new System.Drawing.Size(346, 134);
            this.dataAnnualReport.TabIndex = 0;
            this.dataAnnualReport.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UpdateYearTable);
            // 
            // dataOrdersByYear
            // 
            this.dataOrdersByYear.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataOrdersByYear.Location = new System.Drawing.Point(11, 186);
            this.dataOrdersByYear.Name = "dataOrdersByYear";
            this.dataOrdersByYear.Size = new System.Drawing.Size(346, 277);
            this.dataOrdersByYear.TabIndex = 1;
            this.dataOrdersByYear.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UpdateProductsTable);
            // 
            // dataOrderItem
            // 
            this.dataOrderItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataOrderItem.Location = new System.Drawing.Point(375, 186);
            this.dataOrderItem.Name = "dataOrderItem";
            this.dataOrderItem.Size = new System.Drawing.Size(355, 277);
            this.dataOrderItem.TabIndex = 2;
            // 
            // lblAnnualReport
            // 
            this.lblAnnualReport.AutoSize = true;
            this.lblAnnualReport.Location = new System.Drawing.Point(12, 6);
            this.lblAnnualReport.Name = "lblAnnualReport";
            this.lblAnnualReport.Size = new System.Drawing.Size(75, 13);
            this.lblAnnualReport.TabIndex = 3;
            this.lblAnnualReport.Text = "Annual Report";
            // 
            // ibiOrders
            // 
            this.ibiOrders.AutoSize = true;
            this.ibiOrders.Location = new System.Drawing.Point(12, 170);
            this.ibiOrders.Name = "ibiOrders";
            this.ibiOrders.Size = new System.Drawing.Size(38, 13);
            this.ibiOrders.TabIndex = 4;
            this.ibiOrders.Text = "Orders";
            // 
            // lblOrderItems
            // 
            this.lblOrderItems.AutoSize = true;
            this.lblOrderItems.Location = new System.Drawing.Point(372, 170);
            this.lblOrderItems.Name = "lblOrderItems";
            this.lblOrderItems.Size = new System.Drawing.Size(61, 13);
            this.lblOrderItems.TabIndex = 5;
            this.lblOrderItems.Text = "Order Items";
            // 
            // btnShowProductWindow
            // 
            this.btnShowProductWindow.Location = new System.Drawing.Point(399, 29);
            this.btnShowProductWindow.Name = "btnShowProductWindow";
            this.btnShowProductWindow.Size = new System.Drawing.Size(314, 69);
            this.btnShowProductWindow.TabIndex = 6;
            this.btnShowProductWindow.Text = "Show Product Window";
            this.btnShowProductWindow.UseVisualStyleBackColor = true;
            this.btnShowProductWindow.Click += new System.EventHandler(this.btnShowProductWindow_Click);
            // 
            // tnExit
            // 
            this.tnExit.Location = new System.Drawing.Point(399, 124);
            this.tnExit.Name = "tnExit";
            this.tnExit.Size = new System.Drawing.Size(314, 32);
            this.tnExit.TabIndex = 7;
            this.tnExit.Text = "E&xit";
            this.tnExit.UseVisualStyleBackColor = true;
            this.tnExit.Click += new System.EventHandler(this.tnExit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 472);
            this.Controls.Add(this.tnExit);
            this.Controls.Add(this.btnShowProductWindow);
            this.Controls.Add(this.lblOrderItems);
            this.Controls.Add(this.ibiOrders);
            this.Controls.Add(this.lblAnnualReport);
            this.Controls.Add(this.dataOrderItem);
            this.Controls.Add(this.dataOrdersByYear);
            this.Controls.Add(this.dataAnnualReport);
            this.Name = "frmMain";
            this.Text = "ADO Exercise";
            this.Load += new System.EventHandler(this.MainLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dataAnnualReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getAnnualReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataOrdersByYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataOrderItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getCurrentYearBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getOrderItemsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataAnnualReport;
        private System.Windows.Forms.BindingSource getAnnualReportBindingSource;
        private System.Windows.Forms.DataGridView dataOrdersByYear;
        private System.Windows.Forms.DataGridView dataOrderItem;
        private System.Windows.Forms.BindingSource getCurrentYearBindingSource;
        private System.Windows.Forms.BindingSource getOrderItemsBindingSource;
        private System.Windows.Forms.Label lblAnnualReport;
        private System.Windows.Forms.Label ibiOrders;
        private System.Windows.Forms.Label lblOrderItems;
        private System.Windows.Forms.Button btnShowProductWindow;
        private System.Windows.Forms.Button tnExit;
    }
}

