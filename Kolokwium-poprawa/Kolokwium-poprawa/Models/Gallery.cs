using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium_poprawa.Models;

public class Gallery
{
    [Key]
    public int GalleryId { get; set; }
    [MaxLength(50)]
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public DateTime EstablishedDate { get; set; }
    
    [ForeignKey(nameof(Exhibition))]
    public ICollection<Exhibition> Exhibitions { get; set; } = new HashSet<Exhibition>();
}