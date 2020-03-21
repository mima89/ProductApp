using ProductApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductApp.ViewModels.Products
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        public string ManufacturerName { get; set; }
        public decimal Price { get; set; }

        public ProductViewModel(Product product)
        {
            Id = product.ProductId;
            ProductName = product.Title;
            Description = product.Description;
            CategoryName = product.Category != null ? product.Category.CategoryName : "";
            SupplierName = product.Supplier != null ? product.Supplier.SupplierName : "";
            ManufacturerName = product.Manufacturer != null ? product.Manufacturer.ManufacturerName : "";
            Price = product.Price;
        }

        public static List<ProductViewModel> GetProductsViewModel(List<Product> products)
        {
            return products.Select(s => new ProductViewModel(s)).ToList();
        }
    }
}