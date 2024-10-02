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
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Verification> Verification { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}
