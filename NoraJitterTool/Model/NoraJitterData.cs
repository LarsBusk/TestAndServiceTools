using System.Data.Entity;

namespace NoraJitterTool.Model
{
    public partial class NoraJitterData : DbContext
    {
        public NoraJitterData()
            : base("name=NoraJitterData")
        {
        }

        public virtual DbSet<Delays> Delays { get; set; }
        public virtual DbSet<TestSetup> TestSetup { get; set; }
        public virtual DbSet<TestSystem> TestSystem { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestSystem>()
                .Property(e => e.ChassisId)
                .HasPrecision(20, 0);
        }
    }
}
