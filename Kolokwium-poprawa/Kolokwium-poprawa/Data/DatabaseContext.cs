using Kolokwium_poprawa.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_poprawa.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
        {
        }
    
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Exhibition> Exhibitions { get; set; }
        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<ExhibitionArtwork> ExhibitionArtworks { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Artist>().HasData(new List<Artist>
            {
                new Artist {
                    ArtistId = 1,
                    FirstName = "Pablo",
                    LastName = "Picasso",
                    BirthDate = new DateTime(1881, 10, 25)
                },
                new Artist() {
                    ArtistId = 2,
                    FirstName = "Frida",
                    LastName = "Kahlo",
                    BirthDate = new DateTime(1907, 7, 6)
                }
            });

            modelBuilder.Entity<Artwork>().HasData(new List<Artwork>
            {
                new Artwork {
                    ArtworkId = 1,
                    Title = "Guernica",
                    YearCreated = 1937,
                    ArtistId = 1
                },
                new Artwork {
                    ArtworkId = 2,
                    Title = "The Two Fridas",
                    YearCreated = 1939,
                    ArtistId = 2
                }
            });

            modelBuilder.Entity<Gallery>().HasData(new List<Gallery>
            {
                new Gallery
                {
                    GalleryId = 1,
                    Name = "Modern Art Space",
                    EstablishedDate = new DateTime(2001, 9, 12)
                }
            });

            modelBuilder.Entity<Exhibition>().HasData(new List<Exhibition>
            {
                new Exhibition
                {
                    ExhibitionId = 1,
                    Title = "20th Century Giants",
                    StartDate = new DateTime(2024, 5, 1),
                    EndDate = new DateTime(2024, 9, 1),
                    GalleryId = 1
                },
                new Exhibition
                {
                    ExhibitionId = 2,
                    Title = "Best of Century",
                    StartDate = new DateTime(2024, 10, 1),
                    EndDate = new DateTime(2024, 12, 1),
                    GalleryId = 1
                }
            });

            modelBuilder.Entity<ExhibitionArtwork>().HasData(new List<ExhibitionArtwork>
            {
                new ExhibitionArtwork
                {
                    ExhibitionId = 1,
                    ArtworkId = 1,
                    InsuranceValue = (float)10000.00
                },
                new ExhibitionArtwork
                {
                    ExhibitionId = 1,
                    ArtworkId = 2,
                    InsuranceValue = (float)800000.00m
                }
            });
    }
        
}