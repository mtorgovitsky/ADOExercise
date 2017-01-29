using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOExercise
{
    class NorthwindDAL
    {

        const string connectionStr = @"Data Source=.\sqlsrv2014;Initial Catalog=Northwind;Integrated Security=True;Pooling=true";


        public DataTable GetAnnualReports()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetAnnualReport", conn);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                dataAdapter.Fill(dataTable);

                return dataTable;
            }

        }
        public void GetOrdersByYear(int currentYear)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetCurrentYear", conn);

                SqlParameter param = new SqlParameter("@currYear", currentYear);
                cmd.Parameters.Add(param);

                cmd.ExecuteScalar();

                conn.Close();
            }

        }
    }
}
