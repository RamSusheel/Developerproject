using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace Sparcpoint.Models
{
    public class APIContext : DbContext
    {
        public APIContext (DbContextOptions<APIContext> options)
            : base(options)
        {
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<ProductAttributes> ProductAttributes { get; set; }
    }
}