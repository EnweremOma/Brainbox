using Brainbox.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Brainbox.Domain.Data
{
    public class BrainboxDBContext :DbContext
    {
        public BrainboxDBContext(DbContextOptions<BrainboxDBContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
