using ADOExercise.DAL;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ADOExercise
{
    public class NorthwindDAL
    {
        public Product Product = new Product();

        //The program Connection string - need to be changed when run
        //On different PC's
        const string connectionStr =
            @"Data Source=.\SQLSRV2014;Initial Catalog=Northwind;Integrated Security=True;
            Pooling=true";

        /// <summary>
        /// Main Method which runs Given Stored Procedure
        /// </summary>
        /// <param name="storedProcedure">Name of the Stored Procedure</param>
        /// <returns>DataTable variable</returns>
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

        /// <summary>
        /// Runs stored procedure by given Name of the Procedure,
        /// Passes to the procedure the Column variable and command string
        /// </summary>
        /// <param name="storedProcedure">Name of the Stored Procedure</param>
        /// <param name="columnName">Column Name</param>
        /// <param name="command">Command String</param>
        /// <returns></returns>
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

        /// <summary>
        /// Runs stored procedure by given Name of the Procedure,
        /// Passes to the procedure the Integer value and command string
        /// </summary>
        /// <param name="storedProcedure">Name of the Stored Procedure</param>
        /// <param name="intValue">Integer value to search for</param>
        /// <param name="command">Command string</param>
        /// <returns></returns>
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

        /// <summary>
        /// Fills the List<string> with given Column from Given DataTable
        /// </summary>
        /// <param name="dtSourceDT">DataTable to fill from</param>
        /// <param name="sColumnName">Column Name to fill from</param>
        /// <returns>List<string> filled with found values</returns>
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
        /// Gets the Annual report.
        /// </summary>
        /// <returns>DataTable filled with results</returns>
        public DataTable GetAnnualReport()
        {
            return GetTableFromStoredProcedure("GetAnnualReport");
        }

        /// <summary>
        /// Gets all the orders from Given Year
        /// </summary>
        /// <param name="currentYear"></param>
        /// <returns></returns>
        public DataTable GetOrdersByYear(int currentYear)
        {
            return GetTableFromStoredProcedureByInt("GetCurrentYear", currentYear, "@currYear");
        }

        /// <summary>
        /// Gets the order details from given order
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets Supplier ID by given Supplier Name
        /// </summary>
        /// <param name="supName"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets Supplier Name by given Supplier ID
        /// </summary>
        /// <param name="supID"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets Category Name by Given Category ID
        /// </summary>
        /// <param name="catID"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets Category ID by given Category Name
        /// </summary>
        /// <param name="catName"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets All Suppliers
        /// </summary>
        /// <returns></returns>
        public DataTable GetSuppliers()
        {
            return GetTableFromStoredProcedure("GetSuppliers");
        }

        /// <summary>
        /// Gets all Products
        /// </summary>
        /// <returns></returns>
        public DataTable GetProducts()
        {
            return GetTableFromStoredProcedure("GetProducts");
        }

        /// <summary>
        /// Gets Product by given Product ID
        /// </summary>
        /// <param name="prodID"></param>
        /// <returns></returns>
        public DataTable GetProductByID(int prodID)
        {
            return GetTableFromStoredProcedureByInt("GetProductByID", prodID, "@ProductID");
        }

        /// <summary>
        /// Gets Product by Given Product Name
        /// </summary>
        /// <param name="prodName"></param>
        /// <returns></returns>
        public DataTable GetProductByName(string prodName)
        {
            return GetTableFromStoredProcedureByString("GetProductByName", prodName, "@ProductName");
        }

        /// <summary>
        /// Gets All Categories
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// Updates Current Product
        /// </summary>
        /// <param name="prod">Product Object, filled with Value Data</param>
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
