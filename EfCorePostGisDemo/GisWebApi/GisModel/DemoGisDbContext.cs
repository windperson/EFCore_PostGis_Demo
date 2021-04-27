using GisWebApi.Dto;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace GisWebApi.GisModel
{
    public class DemoGisDbContext : DbContext
    {
        public DemoGisDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasPostgresExtension("postgis");

            #region seed data

            var id1Point = new GeographyPointEntity {Id = 1, Location = new Point(1, 1)};
            var id2Point = new GeographyPointEntity {Id = 2, Location = new Point(2, 2)};
            var id3Point = new GeographyPointEntity {Id = 3, Location = new Point(3, 3)};

            #endregion

            modelBuilder.Entity<GeographyPointEntity>().HasData(id1Point, id2Point, id3Point);
        }

        public DbSet<GeographyPointEntity> Points { get; set; }
    }
}