using BE.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BE.Data.DbCtx

{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<CartItem>Cart { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
