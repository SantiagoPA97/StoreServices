using Microsoft.EntityFrameworkCore;

namespace StoreServices.API.ShoppingCart.Persistency
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options) : base(options){}

        public DbSet<Models.ShoppingCart> ShoppingCart { get; set; }
        public DbSet<Models.ShoppingCartDetails> ShoppingCartDetails { get; set; }
    }
}
