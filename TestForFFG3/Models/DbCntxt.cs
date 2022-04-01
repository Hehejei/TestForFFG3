using Microsoft.EntityFrameworkCore;

namespace TestForFFG3.Models
{
    public class DbCntxt : DbContext
    {
        public DbCntxt(DbContextOptions<DbCntxt> options) : base(options)
        {}
        public DbSet<Dates> dates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dates>()
                .HasNoKey();
        }
    }
}
