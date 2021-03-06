﻿using ADOExercise.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOExercise
{
    public partial class frmMain : Form
    {
        public NorthwindDAL MyDALClass = new NorthwindDAL();

        public frmMain()
        {
            InitializeComponent();
        }

        private void MainLoad(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet.GetAnnualReport' table. You can move, or remove it, as needed.
            ////this.getAnnualReportTableAdapter.Fill(this.northwindDataSet.GetAnnualReport);

            /*  WORKS WITHOUT DAL
            dataAnnualReport.DataSource = getAnnualReportBindingSource;
            getAnnualReportTableAdapter.Fill(nrtwAnnualReport.GetAnnualReport);
            */

            //this.getCurrentYearTableAdapter.Fill(this.northwindDataSet3.GetCurrentYear
            FillDataViews();
        }

        /// <summary>
        /// Fills the DataViews of the main window
        /// </summary>
        private void FillDataViews()
        {
            //NorthwindDAL dalClass = new NorthwindDAL();
            DataTable annualReports = MyDALClass.GetAnnualReport();
            //getOrderItemsBindingSource.DataSource = annualReports;
            dataAnnualReport.DataSource = annualReports;

            DataTable yearReport = new DataTable();
            var row = dataAnnualReport.Rows[0];
            yearReport = MyDALClass.GetOrdersByYear((int)row.Cells[0].Value);
            dataOrdersByYear.DataSource = yearReport;

            DataTable orderDetails = new DataTable();
            row = dataOrdersByYear.Rows[0];
            orderDetails = MyDALClass.GetOrderDetails((int)row.Cells[0].Value);
            dataOrderItem.DataSource = orderDetails;

        }

        //public void FillOrders()
        //{
        //    dataOrderItem.DataSource = getCurrentYearBindingSource;
        //    //getOrderItemsTableAdapter.Fill(nrtwOrdersByYear.GetCurrentYear);
        //}


        /// <summary>
        /// On Mouse click updates the Year orders View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateYearTable(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            //Check if the index is in valid range,
            //(when user clicks on empty row and not on the data rows).
            if (ValidateRowIndex(e, dataAnnualReport))
            {
                var row = dataAnnualReport.Rows[rowIndex];

                int currentYear;

                currentYear = (int)row.Cells[0].Value;

                DataTable yearReport = new DataTable();

                yearReport = MyDALClass.GetOrdersByYear(currentYear);
                dataOrdersByYear.DataSource = yearReport;
            }
        }

        /// <summary>
        /// On mouse click updates the Products View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateProductsTable(object sender, DataGridViewCellEventArgs e)
        {
            //Check if the index is in valid range,
            //(when user clicks on empty row and not on the data rows).
            if (ValidateRowIndex(e, dataOrdersByYear))
            {
                var row = dataOrdersByYear.Rows[e.RowIndex];

                int orderID;

                orderID = (int)row.Cells[0].Value;

                DataTable orderDetails = new DataTable();

                orderDetails = MyDALClass.GetOrderDetails(orderID);
                dataOrderItem.DataSource = orderDetails;
            }
        }

        /// <summary>
        /// Validate if row Index is in range of current DataGridView
        /// </summary>
        /// <param name="e">Event parameter</param>
        /// <param name="gridViewSource">DataGridView Component</param>
        /// <returns>TRUE if the index is in the range and FALSE if not</returns>
        bool ValidateRowIndex(DataGridViewCellEventArgs e, DataGridView gridViewSource)
        {
            //Check if the index is in valued range.
            if (e.RowIndex == gridViewSource.RowCount - 1 || e.RowIndex < 0)
                return false;
            else
                return true;
        }


        private void btnFillDataViews_Click(object sender, EventArgs e)
        {
            FillDataViews();
        }

        private void btnShowProductWindow_Click(object sender, EventArgs e)
        {
            //Form update = Application.OpenForms["frmProdUpd"];
            //if (update == null)
            //{
            //    frmProdUpd updForm = new Forms.frmProdUpd();
            //    updForm.Show();
            //}

            Form openFrmUpdate = new frmProdUpd();
            openFrmUpdate.ShowDialog();
        }

        private void tnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
