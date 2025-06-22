using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_poprawa.Models;

[Table("Exhibition_Artwork")]
[PrimaryKey(nameof(ExhibitionId), nameof(ArtworkId))]
public class ExhibitionArtwork
{
    [Required]
    public int ExhibitionId { get; set; }
    
    [Required]
    public int ArtworkId { get; set; }
    [Required]
    [Column(TypeName = "decimal")]
    [Precision(10, 2)]
    public float InsuranceValue { get; set; }
    
    [ForeignKey(nameof(ExhibitionId))]
    public Exhibition Exhibition { get; set; }
    [ForeignKey(nameof(ArtworkId))]
    public Artwork Artwork { get; set; }
}