using HMZ.Data.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HMZ.Data.Data
{
    public static class Seed
    {
        public async static Task<int> SeedCategory(Category category, HMZDbContext context)
        {
            if (!context.Categories.Any())
            {
                var categories = new List<Category>()
                {
                    new Category { Name = "Moblie" },
                    new Category { Name = "PC"},
                    new Category { Name = "Apple"},
                };
                foreach (var item in categories)
                {
                    context.Categories.Add(item);
                }
                return await context.SaveChangesAsync();
            }
            return 0;
        }

    }
}
