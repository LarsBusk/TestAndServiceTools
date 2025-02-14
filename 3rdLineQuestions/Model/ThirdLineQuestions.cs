using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace _3rdLineQuestions.Model
{
    internal class ThirdLineQuestions : DbContext
    {
        public virtual DbSet<Enums> Enums { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }

        protected readonly IConfiguration Configuration;

        public ThirdLineQuestions(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ThirdLineQs"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enums>();
            modelBuilder.Entity<Questions>();
        }
    }
}
