namespace IRunes.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using IRunes.Data.Models;
    using IRunes.Web.ViewModels.Albums.InputModels;

    public interface IAlbumService
    {
        Task CreateAlbumAsync(CreateAlbumInputModel createAlbum);

        Task<bool> AddTrackToAlbumAsync(string albumId, Track track);

        Task<ICollection<T>> GetAllAlbumsAsync<T>();

        Task<Album> GetAlbumByIdAsync(string id);
    }
}
