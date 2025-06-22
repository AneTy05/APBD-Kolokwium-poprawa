using APBD_Kolokwium.Services;
using Kolokwium_poprawa.Data;
using Kolokwium_poprawa.DTOs;
using Kolokwium_poprawa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_poprawa.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GalleriesController : ControllerBase
{
    private readonly DatabaseContext _context;
    private readonly IDbService _dbService;

    public GalleriesController(DatabaseContext context, IDbService dbService)
    {
        _context = context;
        _dbService = dbService;
    }

    [HttpGet("{id}/exhibitions")]
    public async Task<IActionResult> GetExhibitionsForGallery(int id)
    {
        var gallery = await _context.Galleries
            .Include(g => g.Exhibitions)
            .ThenInclude(e => e.ExhibitionArtworks)
            .ThenInclude(ea => ea.Artwork)
            .ThenInclude(a => a.Artist)
            .FirstOrDefaultAsync(g => g.GalleryId == id);

        if (gallery == null)
            return NotFound("Galeria nie istnieje");

        var result = new
        {
            galleryId = gallery.GalleryId,
            name = gallery.Name,
            establishedDate = gallery.EstablishedDate,
            exhibitions = gallery.Exhibitions.Select(e => new
            {
                title = e.Title,
                startDate = e.StartDate,
                endDate = e.EndDate,
                numberOfArtworks = e.ExhibitionArtworks.Count,
                artworks = e.ExhibitionArtworks.Select(ea => new
                {
                    title = ea.Artwork.Title,
                    yearCreated = ea.Artwork.YearCreated,
                    insuranceValue = ea.InsuranceValue,
                    artist = new
                    {
                        firstName = ea.Artwork.Artist.FirstName,
                        lastName = ea.Artwork.Artist.LastName,
                        birthDate = ea.Artwork.Artist.BirthDate
                    }
                })
            })
        };

        return Ok(result);
    }

    [HttpPost("/api/exhibitions")]
    public async Task<IActionResult> AddExhibition([FromBody] NewExhibitionDto request)
    {
        var gallery = await _context.Galleries
            .FirstOrDefaultAsync(g => g.Name == request.Gallery);

        if (gallery == null)
            return NotFound("Galeria o podanej nazwie nie istnieje.");

        var artworkIds = request.Artworks.Select(a => a.ArtworkId).ToList();
        var artworks = await _context.Artworks
            .Where(a => artworkIds.Contains(a.ArtworkId))
            .ToListAsync();

        if (artworks.Count != request.Artworks.Count)
            return BadRequest("Jedno lub więcej dzieł nie istnieje.");

        var exhibition = new Exhibition
        {
            Title = request.Title,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            GalleryId = gallery.GalleryId,
            ExhibitionArtworks = request.Artworks.Select(a => new ExhibitionArtwork
            {
                ArtworkId = a.ArtworkId,
            }).ToList()
        };

        await _context.Exhibitions.AddAsync(exhibition);
        await _context.SaveChangesAsync();

        return Ok("Wystawa została dodana.");
    }
}
