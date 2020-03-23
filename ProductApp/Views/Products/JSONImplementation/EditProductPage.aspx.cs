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
    public partial class EditProductPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.TryParse(Request.QueryString["Id"], out int result) ? result : 0;

                JSONReadWrite readWrite = new JSONReadWrite();
                string jsonString = readWrite.Read("products.json", "Data");
                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(jsonString);

                Product product = products.Where(p => p.ProductId == id).FirstOrDefault();

                if (product == null)
                {
                    Response.Redirect("/Views/Products/ProductsPage.aspx");
                }

                ProductIdField.Value = product.ProductId.ToString();
                ProductNameTextBox.Text = product.Title;
                ProductDescriptionTextBox.Text = product.Description;
                PriceTextBox.Text = product.Price.ToString();

                var categories = products.GroupBy(g => g.Category.CategoryId).Select(s => s.FirstOrDefault().Category).ToList();
                var suppliers = products.GroupBy(g => g.Supplier.SupplierId).Select(s => s.FirstOrDefault().Supplier).ToList();
                var manufacturers = products.GroupBy(g => g.Manufacturer.ManufacturerId).Select(s => s.FirstOrDefault().Manufacturer).ToList();

                CategoryDropDownList.DataSource = categories;
                CategoryDropDownList.SelectedValue = product.Category.CategoryName;
                CategoryDropDownList.DataTextField = "CategoryName";
                CategoryDropDownList.DataBind();

                SupplierDropDownList.Items.Add(" ");
                SupplierDropDownList.DataSource = suppliers;
                SupplierDropDownList.SelectedValue = product.Supplier.SupplierName;
                SupplierDropDownList.DataTextField = "SupplierName";
                SupplierDropDownList.DataBind();

                ManufacturerDropDownList.DataSource = manufacturers;
                ManufacturerDropDownList.SelectedValue = product.Manufacturer.ManufacturerName;
                ManufacturerDropDownList.DataTextField = "ManufacturerName";
                ManufacturerDropDownList.DataBind();
            }
        }

        protected void EditProductButtonClick(object sender, EventArgs e)
        {
            int id = int.TryParse(ProductIdField.Value, out int result) ? result : 0;

            JSONReadWrite readWrite = new JSONReadWrite();
            string jsonString = readWrite.Read("products.json", "Data");
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(jsonString);

            Product product = products.Where(p => p.ProductId == id).FirstOrDefault();

            if (product == null)
            {
                Response.Redirect("/Views/Products/ProductsPage.aspx");
            }

            product.Title = ProductNameTextBox.Text;
            product.Description = ProductDescriptionTextBox.Text;
            product.Category = products.Select(s => s.Category).Where(c => c.CategoryName == CategoryDropDownList.SelectedValue).FirstOrDefault();
            product.Supplier = products.Select(s => s.Supplier).Where(s => s.SupplierName == SupplierDropDownList.SelectedValue).FirstOrDefault();
            product.Manufacturer = products.Select(s => s.Manufacturer).Where(m => m.ManufacturerName == ManufacturerDropDownList.SelectedValue).FirstOrDefault();
            product.Price = decimal.TryParse(PriceTextBox.Text, out decimal priceResult) ? priceResult : 0;

            int index = products.FindIndex(f => f.ProductId == id);
            products[index] = product;

            string jsonWriteString = JsonConvert.SerializeObject(products);
            readWrite.Write("products.json", "Data", jsonWriteString);

            Response.Redirect("/Views/Products/ProductsPage.aspx");
        }
        
    }
}