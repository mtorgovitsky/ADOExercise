using ADOExercise.DAL;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ADOExercise
{
    public class NorthwindDAL
    {
        public Product Product = new Product();

        //Constant with connection string

        const string connectionStr =
            @"Data Source=.\MSSQLSERVER16;Initial Catalog=Northwind;Integrated Security=True;
            Pooling=true";

        public DataTable GetTableFromStoredProcedure(string storedProcedure)
        {
            DataTable dataTable = new DataTable();
            //Using connection
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(storedProcedure, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);

                conn.Close();
            }
            return dataTable;
        }

        public DataTable GetTableFromStoredProcedureByString(string storedProcedure, string columnName, string command)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(storedProcedure, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter(command, columnName);
                cmd.Parameters.Add(param);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);

                conn.Close();
            }
            return dataTable;
        }

        public DataTable GetTableFromStoredProcedureByInt(string storedProcedure, int intValue, string command)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(storedProcedure, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter(command, intValue);
                cmd.Parameters.Add(param);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);

                conn.Close();
            }
            return dataTable;
        }


        //List filler for comboboxs's data source
        public List<string> FillListFromColumn(DataTable dtSourceDT, string sColumnName)
        {
            List<string> lResult = new List<string>();
            foreach (DataRow row in dtSourceDT.Rows)
            {
                lResult.Add(row[sColumnName].ToString());
            }
            lResult.Sort();
            return lResult;
        }

        /// <summary>
        /// Stored Procedure for Annual report.
        /// </summary>
        /// <returns>DataTable filled with results</returns>
        public DataTable GetAnnualReport()
        {
            return GetTableFromStoredProcedure("GetAnnualReport");
        }

        public DataTable GetOrdersByYear(int currentYear)
        {
            return GetTableFromStoredProcedureByInt("GetCurrentYear", currentYear, "@currYear");
        }

        public DataTable GetOrderDetails(int orderID)
        {
            return GetTableFromStoredProcedureByInt("GetOrderItems", orderID, "@OrderID");
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

        public int GetSupplierIDByName(string supName)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"select SupplierID from Suppliers where ContactName = '{supName}'", conn);
                int prodCount = (int)cmd.ExecuteScalar();
                conn.Close();
                return prodCount;
            }
        }

        public string GetCategoryNameByID(int catID)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"select CategoryName from Categories where CategoryID = {catID}", conn);
                string supName = cmd.ExecuteScalar().ToString();
                conn.Close();
                return supName;
            }
        }


        public int GetCategoryIDByName(string catName)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"select CategoryID from Categories where CategoryName = '{catName}'", conn);
                int prodCount = (int)cmd.ExecuteScalar();
                conn.Close();
                return prodCount;
            }
        }

        public string GetSupplierNameByID(int supID)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"select ContactName from Suppliers where SupplierID = {supID}", conn);
                string supName = cmd.ExecuteScalar().ToString();
                conn.Close();
                return supName;
            }
        }

        public DataTable GetSuppliers()
        {
            return GetTableFromStoredProcedure("GetSuppliers");
        }

        public DataTable GetProducts()
        {
            return GetTableFromStoredProcedure("GetProducts");
        }

        public DataTable GetProductByID(int prodID)
        {
            return GetTableFromStoredProcedureByInt("GetProductByID", prodID, "@ProductID");
        }

        public DataTable GetProductByName(string prodName)
        {
            return GetTableFromStoredProcedureByString("GetProductByName", prodName, "@ProductName");
        }


        public DataTable GetCategories()
        {
            return GetTableFromStoredProcedure("GetCategories");
        }

        //public SqlDataReader GetProductReader(int prodID)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionStr))
        //    {
        //        conn.Open();

        //        SqlCommand cmd = new SqlCommand("GetProductByID", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlParameter param = new SqlParameter("@ProductID", prodID);
        //        cmd.Parameters.Add(param);
        //        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
        //        SqlDataReader sdr = cmd.ExecuteReader();
        //        conn.Close();
        //        return sdr;
        //    }
        //}
        public void UpdateProduct(Product prod)
        {
            DataTable id = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UpdateProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pProductName = new SqlParameter("@productName", prod.ProductName);
                cmd.Parameters.Add(pProductName);
                SqlParameter pSupplierID = new SqlParameter("@supplierID", prod.SupplierID);
                cmd.Parameters.Add(pSupplierID);
                SqlParameter pCategoryID = new SqlParameter("@categoryID", prod.CategoryID);
                cmd.Parameters.Add(pCategoryID);
                SqlParameter pQuantityPerUnit = new SqlParameter("@quantityPerUnit", prod.QuantityPerUnit);
                cmd.Parameters.Add(pQuantityPerUnit);
                SqlParameter pUnitPrice = new SqlParameter("@unitPrice", prod.UnitPrice);
                cmd.Parameters.Add(pUnitPrice);
                SqlParameter pUnitsInStock = new SqlParameter("@unitsInStock", prod.UnitsInStock);
                cmd.Parameters.Add(pUnitsInStock);
                SqlParameter pUnitsOnOrder = new SqlParameter("@unitsOnOrder", prod.UnitsOnOrder);
                cmd.Parameters.Add(pUnitsOnOrder);
                SqlParameter pReorderLevel = new SqlParameter("@reorderLevel", prod.ReorderLevel);
                cmd.Parameters.Add(pReorderLevel);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                // Execute the command
                dataAdapter.Fill(id);
            }
        }
    }
}
