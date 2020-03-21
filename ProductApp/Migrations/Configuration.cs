namespace ProductApp.Migrations
{
    using ProductApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ProductApp.Data.ProductContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProductApp.Data.ProductContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            List<Category> categories = new List<Category>
            {
                new Category
                {
                    CategoryName = "Fruit"
                },
                new Category
                {
                    CategoryName = "Frozen Products"
                }
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            List<Supplier> suppliers = new List<Supplier>
            {
                new Supplier
                {
                    SupplierName = "Maxi"
                },
                new Supplier
                {
                    SupplierName = "Idea"
                }
            };

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            List<Manufacturer> manufacturers = new List<Manufacturer>()
            {
                new Manufacturer
                {
                    ManufacturerName = "Frikom"
                },
                new Manufacturer
                {
                    ManufacturerName = "Premia"
                }
            };

            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();

            List<Product> products = new List<Product>
            {
                new Product
                {
                    Title = "Croissants",
                    Category = context.Categories.Where(w => w.CategoryName == "Frozen Products").FirstOrDefault(),
                    Manufacturer = context.Manufacturers.Where(w => w.ManufacturerName == "Frikom").FirstOrDefault(),
                    Price = 150
                },
                new Product
                {
                    Title = "Puff buns",
                    Category = context.Categories.Where(w => w.CategoryName == "Frozen Products").FirstOrDefault(),
                    Manufacturer= context.Manufacturers.Where(w => w.ManufacturerName == "Premia").FirstOrDefault(),
                    Price = 150
                }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
