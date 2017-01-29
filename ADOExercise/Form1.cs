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

            NorthwindDAL dalClass = new NorthwindDAL();
            DataTable annualReports = dalClass.GetAnnualReport();
            //getOrderItemsBindingSource.DataSource = annualReports;
            dataAnnualReport.DataSource = annualReports;

            //this.getCurrentYearTableAdapter.Fill(this.northwindDataSet3.GetCurrentYear

        }

        public void FillOrders()
        {
            dataOrderItem.DataSource = getCurrentYearBindingSource;
            //getOrderItemsTableAdapter.Fill(nrtwOrdersByYear.GetCurrentYear);
        }

        private void UpdateYEarTable(object sender, DataGridViewCellEventArgs e)
        {
            UpdateDataView(e, dataAnnualReport, dataOrdersByYear);
        }

        private void UpdateDataView(
            DataGridViewCellEventArgs e,
            DataGridView viewSource,
            DataGridView viewDest)
        {
            //Check if the index is in valued range.
            //if not = don't do nothing
            int rowIndex = e.RowIndex;
            if (rowIndex == viewSource.RowCount - 1 || rowIndex == -1)
                return;

            var row = viewSource.Rows[rowIndex];

            int currentYear = 0;

            currentYear = (int)row.Cells[0].Value;

            NorthwindDAL dalClass = new NorthwindDAL();
            DataTable yearReport = new DataTable();

            yearReport = dalClass.GetOrdersByYear(currentYear);
            viewDest.DataSource = yearReport;
        }
    }
}
