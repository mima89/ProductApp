using ProductApp.Data;
using ProductApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductApp.Views.Products.DbImplementation
{
    public partial class CreateProductPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (ProductContext context = new ProductContext())
            {
                var categories = context.Categories.ToList();
                var suppliers = context.Suppliers.ToList();
                var manufacturers = context.Manufacturers.ToList();

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
        }

        protected void AddProductButtonClick(object sender, EventArgs e)
        {
            using (ProductContext context = new ProductContext())
            {
                Product product = new Product();
                product.Title = ProductNameTextBox.Text;
                product.Description = ProductDescriptionTextBox.Text;
                product.Category = context.Categories.Where(c => c.CategoryName == CategoryDropDownList.SelectedValue).FirstOrDefault();
                product.Supplier = context.Suppliers.Where(s => s.SupplierName == SupplierDropDownList.SelectedValue).FirstOrDefault();
                product.Manufacturer = context.Manufacturers.Where(m => m.ManufacturerName == ManufacturerDropDownList.SelectedValue).FirstOrDefault();
                product.Price = decimal.TryParse(PriceTextBox.Text, out decimal result) ?  result : 0;

                context.Products.Add(product);
                context.SaveChanges();

                Response.Redirect("/Views/Products/ProductsPage.aspx");
            }
        }
    }
}