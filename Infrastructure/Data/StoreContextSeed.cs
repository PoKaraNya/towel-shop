﻿using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext context)
    {
        if (!context.Categories.Any())
        {
            var categoriesData = File.ReadAllText("../Infrastructure/Data/SeedData/categories.json");
            var categories = JsonSerializer.Deserialize<List<Category>>(categoriesData);
            context.Categories.AddRange(categories);
        }

        if (!context.Products.Any())
        {
            var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(productsData);
            context.Products.AddRange(products);
        }

        if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();

    }
}
