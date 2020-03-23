using Newtonsoft.Json;
using ProductApp.Data;
using ProductApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductApp.Views.Products.JSONImplementation
{
    public partial class CreateProductPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JSONReadWrite readWrite = new JSONReadWrite();
            string jsonString = readWrite.Read("products.json", "Data");
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(jsonString);

            var categories = products.GroupBy(g => g.Category.CategoryId).Select(s => s.FirstOrDefault().Category).ToList();
            var suppliers = products.GroupBy(g => g.Supplier.SupplierId).Select(s => s.FirstOrDefault().Supplier).ToList();
            var manufacturers = products.GroupBy(g => g.Manufacturer.ManufacturerId).Select(s => s.FirstOrDefault().Manufacturer).ToList();

            CategoryDropDownList.DataSource = categories;
            CategoryDropDownList.DataTextField = "CategoryName";
            CategoryDropDownList.ID = "CategoryId";
            CategoryDropDownList.DataBind();

            SupplierDropDownList.DataSource = suppliers;
            SupplierDropDownList.DataTextField = "SupplierName";
            SupplierDropDownList.ID = "SupplierId";
            SupplierDropDownList.DataBind();

            ManufacturerDropDownList.DataSource = manufacturers;
            ManufacturerDropDownList.DataTextField = "ManufacturerName";
            ManufacturerDropDownList.ID = "ManufacturerId";
            ManufacturerDropDownList.DataBind();
        }

        protected void AddProductButtonClick(object sender, EventArgs e)
        {
            JSONReadWrite readWrite = new JSONReadWrite();
            string jsonString = readWrite.Read("products.json", "Data");
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(jsonString);

            Product product = new Product();
            product.ProductId = products.Count + 1;
            product.Title = ProductNameTextBox.Text;
            product.Description = ProductDescriptionTextBox.Text;
            product.Category = products.Select(s => s.Category).Where(c => c.CategoryName == CategoryDropDownList.SelectedValue).FirstOrDefault();
            product.Supplier = products.Select(s => s.Supplier).Where(s => s.SupplierName == SupplierDropDownList.SelectedValue).FirstOrDefault();
            product.Manufacturer = products.Select(s => s.Manufacturer).Where(m => m.ManufacturerName == ManufacturerDropDownList.SelectedValue).FirstOrDefault();
            product.Price = decimal.TryParse(PriceTextBox.Text, out decimal result) ? result : 0;

            products.Add(product);

            string jsonWriteString = JsonConvert.SerializeObject(products);
            readWrite.Write("products.json", "Data", jsonWriteString);

            Response.Redirect("/Views/Products/ProductsPage.aspx");

        }
    }
}