using GeekShopping.CartAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShoopping.CartAPI.Model.Context
{
    public class MySQLContext : DbContext
    {

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartDetail> cartDetails { get; set; }
        public DbSet<CartHeader> cartHeaders { get; set; }
    }
}
