using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class DatabContext : DbContext
    {
        public DatabContext(DbContextOptions<DatabContext> options) : base(options) { }

        public DbSet<Generos> Generos { get; set; }
        public DbSet<Productora> Productora { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Series_Generos> Series_Generos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Generos>().ToTable("Generos");
            modelBuilder.Entity<Productora>().ToTable("Productora");
            modelBuilder.Entity<Series>().ToTable("Series");
            modelBuilder.Entity<Series_Generos>().ToTable("Series_Generos");

            modelBuilder.Entity<Generos>().HasKey(x => x.Id);
            modelBuilder.Entity<Productora>().HasKey(x => x.Id);
            modelBuilder.Entity<Series>().HasKey(x => x.Id);
            modelBuilder.Entity<Series_Generos>().HasKey(x => x.Id);

            modelBuilder.Entity<Series>().HasMany<Series_Generos>(x => x.Series_Generos)
                .WithOne(x => x.Series).HasForeignKey(x => x.IdSerie).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Generos>().HasMany<Series_Generos>(x => x.Series_Generos)
                .WithOne(x => x.Generos).HasForeignKey(x => x.IdGenero).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Productora>().HasMany<Series>(x => x.Series)
                .WithOne(x => x.Productora).HasForeignKey(x => x.IdProductora).OnDelete(DeleteBehavior.Cascade);
        }
    }
}