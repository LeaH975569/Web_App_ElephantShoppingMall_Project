using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.IO.Pipelines;
namespace A22nd.Models
{
    public class MallStoreDbContext : IdentityDbContext
    {
        public MallStoreDbContext(DbContextOptions<MallStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Store> Stores { get; set; }

        public DbSet<GiftCard> GiftCards { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
