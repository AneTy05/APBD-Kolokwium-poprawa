using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kolokwium_poprawa.Data;

namespace APBD_Kolokwium.Services
{
    public class DbService : IDbService
    {
        private readonly DatabaseContext _context;

        public DbService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> GalleryExistsAsync(string name)
        {
            return await _context.Galleries.AnyAsync(g => g.Name == name);
        }

        public async Task<bool> ArtworkExistsAsync(int artworkId)
        {
            return await _context.Artworks.AnyAsync(a => a.ArtworkId == artworkId);
        }

        public async Task<T?> GetByIdAsync<T>(int id) where T : class
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}