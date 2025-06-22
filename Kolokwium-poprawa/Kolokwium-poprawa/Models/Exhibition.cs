using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium_poprawa.Models;

public class Exhibition
{
    [Key]
    public int ExhibitionId { get; set; }
    [Required]
    public int GalleryId { get; set; }
    [MaxLength(100)]
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    [Required]
    public int NumberOfWorks { get; set; }
    
    [ForeignKey(nameof(GalleryId))]
    public Gallery Gallery { get; set; }
    
    public ICollection<ExhibitionArtwork> ExhibitionArtworks { get; set; } = new HashSet<ExhibitionArtwork>(); 
}