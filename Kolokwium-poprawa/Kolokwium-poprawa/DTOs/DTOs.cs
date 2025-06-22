namespace Kolokwium_poprawa.DTOs;

public class GalleryExhibitionsDto
{
    public int GalleryId { get; set; }
    public string Name { get; set; }
    public DateTime EstablishedDate { get; set; }
    public List<ExhibitionDto> Exhibitions { get; set; }
}


public class ExhibitionDto
{
    public string Title { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int NumberOfArtworks { get; set; }
    public List<ArtworkDto> Artworks { get; set; }
}
public class ArtworkDto
{
    public string Title { get; set; }
    public int YearCreated { get; set; }
    public decimal InsuranceValue { get; set; }
    public ArtistDto Artist { get; set; }
}
public class ArtistDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}
public class NewExhibitionDto
{
    public string Title { get; set; }
    public string Gallery { get; set; } // Galeria po nazwie
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<ArtworkInsuranceDto> Artworks { get; set; }
}
public class ArtworkInsuranceDto
{
    public int ArtworkId { get; set; }
    public decimal InsuranceValue { get; set; }
}
