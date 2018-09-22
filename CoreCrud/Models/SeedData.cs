using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CoreCrud.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // GATTUSMP: SAMPLE OF A SEED FILE THAT FIRST LOOKS FOR A DATABASE WITH DATA
                //           IF NO DATA FOUND THEN DATA IS ADDED TO THE DATABASE
                // // Look for any movies.
                if (context.WatchContext.Any())
                {
                    return;   // DB has been seeded
                }

                context.WatchContext.AddRange(
                    new Watch
                    {
                        Brand = "Abc",
                        LaunchDate = DateTime.Parse("200-2-12"),
                        IsAnalog = false,
                        Price = 75100.99M,
                        Material = "Leather" ,
                        Quantity = 5

                    },

                    new Watch
                    {
                        Brand = "Fossil",
                        LaunchDate = DateTime.Parse("1900-2-12"),
                        IsAnalog = false,
                        Price = 80000.99M,
                        Material = "Steel" ,
                        Quantity = 5
                    },

                    new Watch
                    {
                        Brand = "Titan",
                        LaunchDate = DateTime.Parse("1950-2-09"),
                        IsAnalog = true,
                        Price = 5000.99M,
                        Material = "Leather" ,
                        Quantity = 15
                    },

                    new Watch
                    {
                        Brand = "Police",
                        LaunchDate = DateTime.Parse("2000-2-12"),
                        IsAnalog = false,
                        Price = 6000.99M,
                        Material = "steel" ,
                        Quantity = 30
                    }
                );
                context.SaveChanges();
            }
        }
    }
}