using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                     new Movie
                     {
                         title = "When Harry Met Sally",
                         releaseDate = DateTime.Parse("1989-1-11"),
                         genre = "Romantic Comedy",
                         rating = "R",
                         price = 7.99M
                     },

                     new Movie
                     {
                         title = "Ghostbusters ",
                         releaseDate = DateTime.Parse("1984-3-13"),
                         genre = "Comedy",
                         rating = "R",
                         price = 8.99M
                     },

                     new Movie
                     {
                         title = "Ghostbusters 2",
                         releaseDate = DateTime.Parse("1986-2-23"),
                         genre = "Comedy",
                         rating = "R",
                         price = 9.99M
                     },

                   new Movie
                   {
                       title = "Rio Bravo",
                       releaseDate = DateTime.Parse("1959-4-15"),
                       genre = "Western",
                       rating = "R",
                       price = 3.99M
                   }
                );
                context.SaveChanges();
            }
        }
    }
}