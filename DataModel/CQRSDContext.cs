using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace DataModel
{
    public interface ICQRSDContext
    {

    }
    public class CQRSDContext: DbContext, ICQRSDContext
    {
        public CQRSDContext(DbContextOptions<CQRSDContext> options)
        : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conStr = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString; 
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(conStr);
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
