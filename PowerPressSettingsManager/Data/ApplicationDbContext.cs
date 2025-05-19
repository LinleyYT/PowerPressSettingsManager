using Microsoft.EntityFrameworkCore;
using PowerPressSettingsManager.Moduls;

namespace PowerPressSettingsManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<PressSetting> PressSettings => Set<PressSetting>();
        public DbSet<CoilSetting> CoulSettings => Set<CoilSetting>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PressSetting>()
        .HasOne(p => p.CoilSetting)
        .WithOne(c => c.PressSetting)
        .HasForeignKey<CoilSetting>(c => c.PressSettingId)
        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
