using System;
using Catalog.API.Entities;

namespace Catalog.API.Data
{
    public class CatalogSeed
    {
        public static void PopulateDatabase(CatalogContext catalogContext)
        {
            Category cat1 = new Category
            {
                CategoryId = 1,
                Name = "Guitarras Electricas",
                CreatedDate = new DateTime(),
                ModifiedDate = new DateTime()
            };
            catalogContext.Categories.Add(cat1);


            Category cat2 = new Category
            {
                CategoryId = 2,
                Name = "Guitarras Acusticas",
                CreatedDate = new DateTime(),
                ModifiedDate = new DateTime()
            };
            catalogContext.Categories.Add(cat2);

            Product prod1 = new Product
            {
                ProductId = 1,
                Name = "Fender Stratocaster",
                Description = "Guitarra electrica Fender de 6 cuerdas",
                ImageUrl = "https://bankimages/guitar1",
                Stock = 10,
                PriceAmount = 120000000,
                Category = cat1,
                CreatedDate = new DateTime(),
                ModifiedDate = new DateTime()
            };
            catalogContext.Products.Add(prod1);

            Product prod2 = new Product
            {
                ProductId = 2,
                Name = "Gibson Les Paul Classic",
                Description = "Guitarra electrica Gibson de 6 cuerdas",
                ImageUrl = "https://bankimages/guitar2",
                Stock = 8,
                PriceAmount = 160000000,
                Category = cat1,
                CreatedDate = new DateTime(),
                ModifiedDate = new DateTime()
            };
            catalogContext.Products.Add(prod2);

            Product prod3 = new Product
            {
                ProductId = 3,
                Name = "Ibanez JBBM30",
                Description = "Guitarra electrica Ibanez de 6 cuerdas",
                ImageUrl = "https://bankimages/guitar3",
                Stock = 15,
                PriceAmount = 130000000,
                Category = cat1,
                CreatedDate = new DateTime(),
                ModifiedDate = new DateTime()
            };
            catalogContext.Products.Add(prod3);

            Product prod4 = new Product
            {
                ProductId = 4,
                Name = "Yamaha C40 II",
                Description = "Guitarra acustica Yamaha de 6 cuerdas",
                ImageUrl = "https://bankimages/guitar4",
                Stock = 20,
                PriceAmount = 600000,
                Category = cat2,
                CreatedDate = new DateTime(),
                ModifiedDate = new DateTime()
            };
            catalogContext.Products.Add(prod4);

            Product prod5 = new Product
            {
                ProductId = 5,
                Name = "Alhambra",
                Description = "Guitarra acustica Alhambra de 6 cuerdas",
                ImageUrl = "https://bankimages/guitar5",
                Stock = 25,
                PriceAmount = 800000,
                Category = cat2,
                CreatedDate = new DateTime(),
                ModifiedDate = new DateTime()
            };
            catalogContext.Products.Add(prod5);

            Product prod6 = new Product
            {
                ProductId = 6,
                Name = "Ortega",
                Description = "Guitarra acustica Ortega de 6 cuerdas",
                ImageUrl = "https://bankimages/guitar6",
                Stock = 5,
                PriceAmount = 750000,
                Category = cat2,
                CreatedDate = new DateTime(),
                ModifiedDate = new DateTime()
            };
            catalogContext.Products.Add(prod6);

            catalogContext.SaveChanges();
        }
    }
}
