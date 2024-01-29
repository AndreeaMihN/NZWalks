using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed data for Difficulties
            // Easy, Medium, Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("8a92bb87-047b-434c-9313-af3bf640d500"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("6ae2ebd0-18be-4814-aaf7-88a490c156d8"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("e9a0658e-3ad6-43f5-bf38-0b9c75d49742"),
                    Name = "Hard"
                },
            };

            // Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for Regions
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("4d153e35-3652-47f5-8bff-57bec623395b"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://somthig.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("86bfe4e4-8571-44aa-960e-377c22c752bb"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("977b4c76-42ad-4e23-b20f-617519f8d12c"),
                    Name = "Bay of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("aba7c750-d54d-4aa5-bb01-c4b6587d8b57"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://somthig.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("c22d158e-838c-42b9-916c-21b96f4e96ad"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://somthig.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("463d1d81-ba8e-41d6-b623-4991c0dd44e1"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
