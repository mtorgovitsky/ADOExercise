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
        public NorthwindDAL MyDBInstanceClass = new NorthwindDAL();
        public DataTable AllProducts;
        public DataTable AllSuppliers;
        public DataTable AllCategories;

        ////List filler for comboboxs's data source
        //List<string> FillComboList(string sColumnName, DataTable dtSourceDT)
        //{
        //    List<string> lSresult = new List<string>();
        //    foreach (DataRow row in dtSourceDT.Rows)
        //    {
        //        lSresult.Add(row[sColumnName].ToString());
        //    }
        //    return lSresult;
        //}

        public frmProdUpd()
        {
            InitializeComponent();

            //Fill the find products combo box
            AllProducts = MyDBInstanceClass.GetAllProducts();
            AllSuppliers = MyDBInstanceClass.GetAllSuppliersID();
            AllCategories = MyDBInstanceClass.GetAllCategoriesID();
            cmbFind.DataSource = MyDBInstanceClass.FillListFromColumn("productName", AllProducts);

            //Make Comboboxes of the supplierID and the CategoryID
            //Dropdown List to prevent incorrect input
            cmbSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        }

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

            FillAllFields();
        }



        private void FillAllFields()
        {
            DataTable dtCurrentProduct = MyDBInstanceClass.GetProductByName(cmbFind.Text);
            if (dtCurrentProduct.Rows.Count > 0)
            {
                txtID.Text = dtCurrentProduct.Rows[0]["ProductID"].ToString();
                txtName.Text = dtCurrentProduct.Rows[0]["ProductName"].ToString();
                cmbSupplier.DataSource = MyDBInstanceClass.FillListFromColumn("SupplierID", AllSuppliers);
                cmbSupplier.Text = dtCurrentProduct.Rows[0]["SupplierID"].ToString();
                cmbCategory.DataSource = MyDBInstanceClass.FillListFromColumn("CategoryID", AllCategories);
                cmbCategory.Text = dtCurrentProduct.Rows[0]["CategoryID"].ToString();
                txtQuantity.Text = dtCurrentProduct.Rows[0]["QuantityPerUnit"].ToString();
                txtUnitPrice.Text = dtCurrentProduct.Rows[0]["UnitPrice"].ToString();
                txtUnitsInStock.Text = dtCurrentProduct.Rows[0]["UnitsInStock"].ToString();
                txtUnitsInOrder.Text = dtCurrentProduct.Rows[0]["UnitsOnOrder"].ToString();
                txtReorderLevel.Text = dtCurrentProduct.Rows[0]["ReorderLevel"].ToString();
            }
            else
            {
                MessageBox.Show("Not found n the DB");
                cmbFind.Text = "Chai";
            }
        }

        private void FillProductDetails(int prodID, NorthwindDAL nwd)
        {
            //SqlDataReader sdr = nwd.GetProductReader(prodID);
            //txtID.Text = sdr["ID"].ToString();
            DataTable dt = nwd.GetProductByID(prodID);
            //dt.Rows[0][]
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            //frmProdUpd tmpFormUpd = new Forms.frmProdUpd();
            //tmpFormUpd.Close();
            this.Close();
        }


        private void cmbFind_SelectedValueChanged_1(object sender, EventArgs e)
        {
            FillAllFields();
        }
    }
}
