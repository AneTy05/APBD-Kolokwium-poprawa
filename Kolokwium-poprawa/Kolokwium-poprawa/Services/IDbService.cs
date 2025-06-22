
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APBD_Kolokwium.Services
{
    public interface IDbService
    {
        Task<bool> GalleryExistsAsync(string name);
        Task<bool> ArtworkExistsAsync(int artworkId);
        Task<T?> GetByIdAsync<T>(int id) where T : class;
        Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
        Task AddAsync<T>(T entity) where T : class;
        Task SaveAsync();
    }
}