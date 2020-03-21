using ProductApp.Data;
using ProductApp.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductApp.Views.Products
{
    public partial class ProductsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public List<ProductViewModel> GetProducts()
        {
            using (var context = new ProductContext())
            {
                var products = context.Products.ToList();
                return ProductViewModel.GetProductsViewModel(products);
            }           
        }
    }
}