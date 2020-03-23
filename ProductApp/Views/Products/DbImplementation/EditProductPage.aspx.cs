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
    public partial class EditProductPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.TryParse(Request.QueryString["Id"], out int result) ? result : 0;

                using (ProductContext context = new ProductContext())
                {
                    Product product = context.Products.Where(w => w.ProductId == id).FirstOrDefault();

                    if (product == null)
                    {
                        Response.Redirect("/Views/Products/ProductsPage.aspx");
                    }

                    ProductIdField.Value = product.ProductId.ToString();
                    ProductIdField.DataBind();
                    ProductNameTextBox.Text = product.Title;
                    ProductNameTextBox.DataBind();
                    ProductDescriptionTextBox.Text = product.Description;
                    ProductDescriptionTextBox.DataBind();
                    PriceTextBox.Text = product.Price.ToString();
                    PriceTextBox.DataBind();

                    var categories = context.Categories.ToList();
                    var suppliers = context.Suppliers.ToList();
                    var manufacturers = context.Manufacturers.ToList();

                    CategoryDropDownList.DataSource = categories;
                    CategoryDropDownList.SelectedValue = categories.Where(w => w.CategoryId == product.CategoryId).Select(s => s.CategoryName).FirstOrDefault();
                    CategoryDropDownList.DataTextField = "CategoryName";
                    CategoryDropDownList.DataBind();

                    SupplierDropDownList.Items.Add(" ");
                    SupplierDropDownList.DataSource = suppliers;
                    SupplierDropDownList.SelectedValue = suppliers.Where(w => w.SupplierId == product.SupplierId).Select(s => s.SupplierName).FirstOrDefault();
                    SupplierDropDownList.DataTextField = "SupplierName";
                    SupplierDropDownList.DataBind();

                    ManufacturerDropDownList.DataSource = manufacturers;
                    ManufacturerDropDownList.SelectedValue = manufacturers.Where(w => w.ManufacturerId == product.ManufacturerId).Select(s => s.ManufacturerName).FirstOrDefault();
                    ManufacturerDropDownList.DataTextField = "ManufacturerName";
                    ManufacturerDropDownList.DataBind();
                }
            }
        }

        protected void EditProductButtonClick(object sender, EventArgs e)
        {
            using (ProductContext context = new ProductContext())
            {
                int id = int.TryParse(ProductIdField.Value, out int result) ? result : 0;

                Product product = context.Products.Where(w => w.ProductId == id).FirstOrDefault();

                if (product == null)
                {
                    Response.Redirect("/Views/Products/ProductsPage.aspx");
                }

                product.Title = ProductNameTextBox.Text;
                product.Description = ProductDescriptionTextBox.Text;
                product.Category = context.Categories.Where(c => c.CategoryName == CategoryDropDownList.SelectedValue).FirstOrDefault();
                product.Supplier = context.Suppliers.Where(s => s.SupplierName == SupplierDropDownList.SelectedValue).FirstOrDefault();
                product.Manufacturer = context.Manufacturers.Where(m => m.ManufacturerName == ManufacturerDropDownList.SelectedValue).FirstOrDefault();
                product.Price = decimal.TryParse(PriceTextBox.Text, out decimal priceResult) ? priceResult : 0;

                context.SaveChanges();
                Response.Redirect("/Views/Products/ProductsPage.aspx");
            }
        }
    }
}