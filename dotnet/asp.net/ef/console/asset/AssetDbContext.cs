using Microsoft.EntityFrameworkCore;

namespace asset
{
    class AssetDbContext
    {
        public class AssetgDbContext : DbContext
        {
            public DbSet<Office> Offices { get; set; }
            public DbSet<Laptop> Laptops { get; set; }
            public DbSet<Mobile> Mobiles { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=FPO-X240-WIN;"
                    + " Integrated Security=True;"
                    + " Connect Timeout=30;"
                    + " Encrypt=False;"
                    + " TrustServerCertificate=False;"
                    + " ApplicationIntent=ReadWrite;"
                    + " MultiSubnetFailover=False;"
                    + " Initial Catalog = AssetManagementDemo");
            }
        }
    }
}
