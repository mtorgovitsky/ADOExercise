using System.Data;
using System.Data.SqlClient;

namespace ADOExercise
{
    public class NorthwindDAL
    {

        const string connectionStr =
            @"Data Source=.;Initial Catalog=Northwind;Integrated Security=True;
            Pooling=true";

        /// <summary>
        /// Stored Procedure for Annual report.
        /// </summary>
        /// <returns>DataTable filled with results</returns>
        public DataTable GetAnnualReport()
        {
            DataTable dataTable = new DataTable();
            //Using connection
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetAnnualReport", conn);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                dataAdapter.Fill(dataTable);

                conn.Close();

                return dataTable;
            }

        }
        public DataTable GetOrdersByYear(int currentYear)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetCurrentYear", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@currYear", currentYear);
                cmd.Parameters.Add(param);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                //cmd.ExecuteScalar();

                dataAdapter.Fill(dataTable);


                conn.Close();

                return dataTable;
            }

        }
        public DataTable GetOrderDetails(int orderID)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetOrderItems", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@OrderID", orderID);
                cmd.Parameters.Add(param);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                //cmd.ExecuteScalar();

                dataAdapter.Fill(dataTable);


                conn.Close();

                return dataTable;
            }
        }

        /// <summary>
        /// How Many products there are in the Products table
        /// </summary>
        /// <returns>Returns int which is The count of Products, start from 1</returns>
        public int ProductsCount()
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select count(ProductID) from Products", conn);
                //Execute sql query command
                int prodCount = (int)cmd.ExecuteScalar();
                conn.Close();
                return prodCount;
            }
        }

        public SqlDataReader GetProductReader(int prodID)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetProductByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@ProductID", prodID);
                cmd.Parameters.Add(param);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                //cmd.ExecuteScalar();
                SqlDataReader sdr = cmd.ExecuteReader();
                conn.Close();
                return sdr;
            }
        }

        public DataTable GetProductByID(int prodID)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetProductByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@ProductID", prodID);
                cmd.Parameters.Add(param);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                //cmd.ExecuteScalar();

                dataAdapter.Fill(dataTable);


                conn.Close();

                return dataTable;
            }
        }

        public DataTable GetAllProducts()
        {
            DataTable dataTable = new DataTable();
            //Using connection
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetAllProducts", conn);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                dataAdapter.Fill(dataTable);

                conn.Close();

                return dataTable;
            }

        }

    }
}
