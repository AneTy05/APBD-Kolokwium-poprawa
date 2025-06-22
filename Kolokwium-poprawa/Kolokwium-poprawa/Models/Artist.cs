using System.ComponentModel.DataAnnotations;

namespace Kolokwium_poprawa.Models;

public class Artist
{
    [Key]
    public int ArtistId { get; set; }
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
    [Required]
    public DateTime BirthDate { get; set; }
}