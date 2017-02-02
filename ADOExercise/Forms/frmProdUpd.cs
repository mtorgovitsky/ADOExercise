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

        public frmProdUpd()
        {
            InitializeComponent();
            DataTable dtProducts = MyDBInstanceClass.GetAllProducts();
            List<string> comboProducts = new List<string>();
            foreach (DataRow row in dtProducts.Rows)
            {
                comboProducts.Add(row["ProductName"].ToString());
            }
            cmbFind.DataSource = comboProducts;
        }

        private void frmProdUpd_Load(object sender, EventArgs e)
        {

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
            DataTable dtProducts = MyDBInstanceClass.GetAllProducts();
        }

        private void FillProductDetails(int prodID, NorthwindDAL nwd)
        {
            //SqlDataReader sdr = nwd.GetProductReader(prodID);
            //txtID.Text = sdr["ID"].ToString();
            DataTable dt = nwd.GetProductByID(prodID);
            //dt.Rows[0][]
        }
    }
}
