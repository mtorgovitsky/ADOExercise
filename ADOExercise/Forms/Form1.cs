using ADOExercise.Forms;
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

        private void FillDataViews()
        {
            NorthwindDAL dalClass = new NorthwindDAL();
            DataTable annualReports = dalClass.GetAnnualReport();
            //getOrderItemsBindingSource.DataSource = annualReports;
            dataAnnualReport.DataSource = annualReports;

            DataTable yearReport = new DataTable();
            var row = dataAnnualReport.Rows[0];
            yearReport = dalClass.GetOrdersByYear((int)row.Cells[0].Value);
            dataOrdersByYear.DataSource = yearReport;

            DataTable orderDetails = new DataTable();
            row = dataOrdersByYear.Rows[0];
            orderDetails = dalClass.GetOrderDetails((int)row.Cells[0].Value);
            dataOrderItem.DataSource = orderDetails;

        }

        //public void FillOrders()
        //{
        //    dataOrderItem.DataSource = getCurrentYearBindingSource;
        //    //getOrderItemsTableAdapter.Fill(nrtwOrdersByYear.GetCurrentYear);
        //}

        private void UpdateYearTable(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            //Check if the index is in valued range.
            if (ValidateRowIndex(e, dataAnnualReport))
            {
                var row = dataAnnualReport.Rows[rowIndex];

                int currentYear;

                currentYear = (int)row.Cells[0].Value;

                NorthwindDAL dalClass = new NorthwindDAL();
                DataTable yearReport = new DataTable();

                yearReport = dalClass.GetOrdersByYear(currentYear);
                dataOrdersByYear.DataSource = yearReport;
            }
        }

        private void UpdateProductsTable(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            //Check if the index is in valued range.
            if (ValidateRowIndex(e, dataOrdersByYear))
            {
                var row = dataOrdersByYear.Rows[rowIndex];

                int orderID;

                orderID = (int)row.Cells[0].Value;

                NorthwindDAL dalClass = new NorthwindDAL();
                DataTable orderDetails = new DataTable();

                orderDetails = dalClass.GetOrderDetails(orderID);
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
            Form update = Application.OpenForms["frmProdUpd"];
            if (update == null)
            {
                frmProdUpd updForm = new Forms.frmProdUpd();
                updForm.Show();
            }
        }
    }
}
