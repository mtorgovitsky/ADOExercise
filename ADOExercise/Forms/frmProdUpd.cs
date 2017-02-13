using ADOExercise.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOExercise.Forms
{
    public partial class frmProdUpd : Form
    {
        public NorthwindDAL MyDALClass = new NorthwindDAL();
        public DataTable Products;
        public DataTable Suppliers;
        public DataTable Categories;

        /// <summary>
        /// CTOR of the form, updates needed fields
        /// </summary>
        public frmProdUpd()
        {
            InitializeComponent();

            //Fill the find products combo box
            Products = MyDALClass.GetProducts();
            Suppliers = MyDALClass.GetSuppliers();
            Categories = MyDALClass.GetCategories();
            cmbFind.DataSource = MyDALClass.FillListFromColumn(Products, "productName");

            //Make Comboboxes of the supplierID and the CategoryID
            //Dropdown List to prevent incorrect input
            txtID.ReadOnly = true;
            txtName.ReadOnly = true;
            cmbSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Search for the Product name given 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            //if (txtFindProduct.Text != String.Empty)
            //{
            //    Regex onlyNum = new Regex(@"^\d+$");
            //    if (onlyNum.IsMatch(txtFindProduct.Text))
            //    {
            //        //No need to TryParse because it's only numbers (if is Match)
            //        int searchValue = int.Parse(txtFindProduct.Text);
            //        NorthwindDAL nwd = new NorthwindDAL();
            //        int prodCount = nwd.ProductsCount();
            //        if (searchValue > 0 && searchValue <= prodCount)
            //        {
            //            //DataTable prodDt = new DataTable();
            //            //prodDt = nwd.GetProductDetails(searchValue );
            //            FillProductDetails(searchValue, nwd);
            //        }
            //    }
            //}
            //DataTable dtCurrentProduct = MyDBInstanceClass.GetProductByName(cmbFind.Text);

            FillAllFields(cmbFind.Text);
        }

        /// <summary>
        /// Get object from DataTable by Row and ColumnName
        /// </summary>
        /// <param name="dTable">Data Table</param>
        /// <param name="row">Index of Row in the Rows array</param>
        /// <param name="columnName">The Name of the Column from given row</param>
        /// <returns>Returns object if found</returns>
        private string GetFromTableByRowAndColumnName(DataTable dTable, int row, string columnName)
        {
            return dTable.Rows[row][columnName].ToString();
        }

        /// <summary>
        /// Updates all the fields of the form with Given Product Name from
        /// the cmbFind Combo Box
        /// </summary>
        private void FillAllFields(string findProduct)
        {
            DataTable dtCurrentProduct = MyDALClass.GetProductByName(cmbFind.Text);
            if (dtCurrentProduct.Rows.Count > 0)
            {
                txtID.Text = GetFromTableByRowAndColumnName(dtCurrentProduct, 0, "ProductID");
                txtName.Text = GetFromTableByRowAndColumnName(dtCurrentProduct, 0, "ProductName");
                cmbSupplier.DataSource = MyDALClass.FillListFromColumn(Suppliers, "ContactName");
                cmbSupplier.Text =
                    MyDALClass.GetSupplierNameByID
                        (int.Parse(GetFromTableByRowAndColumnName(dtCurrentProduct, 0, "SupplierID")));
                cmbCategory.DataSource = MyDALClass.FillListFromColumn(Categories, "CategoryName");
                cmbCategory.Text =
                    MyDALClass.GetCategoryNameByID
                        (int.Parse(GetFromTableByRowAndColumnName(dtCurrentProduct, 0, "CategoryID")));
                txtQuantity.Text = GetFromTableByRowAndColumnName(dtCurrentProduct, 0, "QuantityPerUnit");
                txtUnitPrice.Text = GetFromTableByRowAndColumnName(dtCurrentProduct, 0, "UnitPrice");
                txtUnitsInStock.Text = GetFromTableByRowAndColumnName(dtCurrentProduct, 0, "UnitsInStock");
                txtUnitsOnOrder.Text = GetFromTableByRowAndColumnName(dtCurrentProduct, 0, "UnitsOnOrder");
                txtReorderLevel.Text = GetFromTableByRowAndColumnName(dtCurrentProduct, 0, "ReorderLevel");
            }
            //If User writes Product Name that is not in the DataBase
            else
            {
                MessageBox.Show(
                    "The product You've entered \nWas not found in the DataBase",
                    "NOT FOUND!",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbFind.DataSource = MyDALClass.FillListFromColumn(Products, "productName");
            }
        }

        /// <summary>
        /// Creates the Instance of the Product Class
        /// and updates its properties, then send Product to
        /// DAL layer for updating the DataBase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            //frmProdUpd tmpFormUpd = new Forms.frmProdUpd();
            //tmpFormUpd.Close();

            //Fill the product instance with the data from the form Fields
            Product prodForUpdate = new Product();
            int tmpInt;
            int.TryParse(txtID.Text, out tmpInt);
            prodForUpdate.PrductID = tmpInt;
            prodForUpdate.ProductName = txtName.Text;
            int.TryParse(cmbSupplier.Text, out tmpInt);
            prodForUpdate.SupplierID = MyDALClass.GetSupplierIDByName(cmbSupplier.Text);
            prodForUpdate.CategoryID = MyDALClass.GetCategoryIDByName(cmbCategory.Text);
            prodForUpdate.QuantityPerUnit = txtQuantity.Text;
            decimal tmpDec;
            decimal.TryParse(txtUnitPrice.Text, out tmpDec);
            prodForUpdate.UnitPrice = tmpDec;
            int.TryParse(txtUnitsInStock.Text, out tmpInt);
            prodForUpdate.UnitsInStock = tmpInt;
            int.TryParse(txtUnitsOnOrder.Text, out tmpInt);
            prodForUpdate.UnitsOnOrder = tmpInt;
            int.TryParse(txtReorderLevel.Text, out tmpInt);
            prodForUpdate.ReorderLevel = tmpInt;

            //Send to DAL
            MyDALClass.UpdateProduct(prodForUpdate);

            this.Close();
        }

        /// <summary>
        /// Updates all the fields on 'ValueChanged' event
        /// for Easy scrolling and clicking on products
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbFind_SelectedValueChanged_1(object sender, EventArgs e)
        {
            FillAllFields(cmbFind.Text);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
