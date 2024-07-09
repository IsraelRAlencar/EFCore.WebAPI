using EFCore.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.WebAPI.Data
{
    public class HeroContext : DbContext
    {
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<HeroBattle> HeroesBattles { get; set; }
        public DbSet<SecretIdentity> SecretIdentities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=******************;Persist Security Info=True;User ID=sa;Initial Catalog=HeroApp;Data Source=ISRAEL-DESKTOP;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroBattle>(entity => {
                entity.HasKey(e => new { e.BattleId, e.HeroId });
            });
        }
    }
}
