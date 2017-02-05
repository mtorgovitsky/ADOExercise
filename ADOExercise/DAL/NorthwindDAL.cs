using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ADOExercise
{
    public class NorthwindDAL
    {

        const string connectionStr =
            @"Data Source=.\SQLSRV2014;Initial Catalog=Northwind;Integrated Security=True;
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
                SqlDataReader sdr = cmd.ExecuteReader();
                conn.Close();
                return sdr;
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

            }

            return dataTable;
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

                dataAdapter.Fill(dataTable);


                conn.Close();

            }
            return dataTable;
        }
        public DataTable GetProductByName(string prodName)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetProductByName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@ProductName", prodName);
                cmd.Parameters.Add(param);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);


                conn.Close();

            }
            return dataTable;
        }

        public DataTable GetAllSuppliersID()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetSuppliersID", conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);

                conn.Close();

            }

            return dataTable;
        }
        public DataTable GetAllCategoriesID()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetCategoriesID", conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);

                conn.Close();

            }

            return dataTable;
        }

        //List filler for comboboxs's data source
        public List<string> FillListFromColumn(string sColumnName, DataTable dtSourceDT)
        {
            List<string> lSresult = new List<string>();
            foreach (DataRow row in dtSourceDT.Rows)
            {
                lSresult.Add(row[sColumnName].ToString());
            }
            return lSresult;
        }

    }
}
