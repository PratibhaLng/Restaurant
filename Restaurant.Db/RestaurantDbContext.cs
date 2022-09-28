using Microsoft.EntityFrameworkCore;
using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Db
{
    public class RestaurantDbContext:DbContext

    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {



        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
