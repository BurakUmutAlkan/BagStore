using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public static class BagStoreContextSeed
    {
        public static async Task SeedAsync(BagStoreContext db)
        {
            if (await db.Categories.AnyAsync() || await db.Products.AnyAsync() || await db.Brands.AnyAsync())
                return;

            var shoulder = new Category() { Name = "Shoulder Bags" };
            var back = new Category() { Name = "Backpacks" };
            var hand = new Category() { Name = "Handbags" };
            var sport = new Category() { Name = "Sports Bags" };

            await db.Categories.AddRangeAsync(shoulder, back, hand, sport);

            var nike = new Brand() { Name = "Nike" };
            var adidas = new Brand() { Name = "Adidas" };
            var bershka = new Brand() { Name = "Bershka" };
            var mango = new Brand() { Name = "Mango" };
            var tommy = new Brand() { Name = "Tommy Hilfiger" };

            await db.Brands.AddRangeAsync(nike, adidas, bershka, mango, tommy);

            await db.Products.AddRangeAsync(
                 new Product() { Category = back, Brand = nike, Price = 569m, PictureUri = "01.jpg", Name = "Nike Y Nk Elmntl Fa19 Backpack" },
                 new Product() { Category = back, Brand = nike, Price = 609.90m, PictureUri = "02.jpg", Name = "Nike Unisex Backpack" },
                 new Product() { Category = sport, Brand = nike, Price = 629m, PictureUri = "03.jpg", Name = "Nike Nk Acdmy Team M Duff Black Football Sports Bag" },
                 new Product() { Category = back, Brand = adidas, Price = 729m, PictureUri = "04.jpg", Name = "adidas Unisex Backpack Power Vi" },
                 new Product() { Category = hand, Brand = adidas, Price = 677.97m, PictureUri = "05.jpg", Name = "adidas Women's Daily Hand Bag W Mm Tote" },
                 new Product() { Category = sport, Brand = adidas, Price = 492.81m, PictureUri = "06.jpg", Name = "adidas Unisex Blue Black White Sports Bag 45x23x20cm" },
                 new Product() { Category = hand, Brand = bershka, Price = 429.95m, PictureUri = "07.jpg", Name = "Bershka Basic Tote Bag" },
                 new Product() { Category = hand, Brand = mango, Price = 389.99m, PictureUri = "08.jpg", Name = "Mango Dark Yellow Bucket Bag" },
                 new Product() { Category = shoulder, Brand = mango, Price = 379.99m, PictureUri = "09.jpg", Name = "Mango Crossbody Bag" },
                 new Product() { Category = shoulder, Brand = tommy, Price = 1129m, PictureUri = "10.jpg", Name = "Tommy Hilfiger Polyester Navy Women Crossbody Bag" },
                 new Product() { Category = sport, Brand = tommy, Price = 3325.26m, PictureUri = "11.jpg", Name = "Tommy Hilfiger Men Sports Bag" },
                 new Product() { Category = back, Brand = adidas, Price = 389.67m, PictureUri = "12.jpg", Name = "adidas Bag" }
                );

            await db.SaveChangesAsync();
        }
    }
}
