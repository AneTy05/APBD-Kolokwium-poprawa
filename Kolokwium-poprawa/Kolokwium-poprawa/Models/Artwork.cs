using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium_poprawa.Models;

public class Artwork
{
    [Key]
    public int ArtworkId { get; set; }
    [Required]
    public int ArtistId { get; set; }
    [MaxLength(100)]
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public int YearCreated { get; set; }
    
    [ForeignKey(nameof(ExhibitionArtwork))]
    public ICollection<ExhibitionArtwork> ExhibitionArtworks { get; set; } = new HashSet<ExhibitionArtwork>();
    public Artist Artist { get; set; }
    
}