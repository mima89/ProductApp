using ProductApp.Data;
using ProductApp.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Newtonsoft.Json;
using ProductApp.Models;
using System.Threading.Tasks;

namespace ProductApp.Views.Products
{
    public partial class ProductsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public List<ProductViewModel> GetProductsFromDatabase()
        {
            using (var context = new ProductContext())
            {
                var products = context.Products
                    .Include(c => c.Category)
                    .Include(s => s.Supplier)
                    .Include(m => m.Manufacturer)
                    .ToList();

                return ProductViewModel.GetProductsViewModel(products);
            }           
        }

        public List<ProductViewModel> GetProductsFromJSON()
        {
            JSONReadWrite readWrite = new JSONReadWrite();
            string jsonString = readWrite.Read("products.json", "Data");
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(jsonString);
            return ProductViewModel.GetProductsViewModel(products);
        }

        protected void EditProductCommand(object sender, CommandEventArgs e)
        {
            string id = (string)e.CommandArgument;
            Response.Redirect("/Views/Products/DbImplementation/EditProductPage.aspx?Id=" + id);
        }
    }
}