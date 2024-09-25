using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShopEase.Entities;

namespace ClothingStore.Entities
{
    public class ShopEaseDbContext : DbContext
    {
        public ShopEaseDbContext(DbContextOptions<ShopEaseDbContext> options):base(options) 
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Roles> Roles { get; set; }
    }
}
