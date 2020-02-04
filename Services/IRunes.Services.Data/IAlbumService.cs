namespace IRunes.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using IRunes.Data.Models;
    using IRunes.Web.ViewModels.Albums.InputModels;

    public interface IAlbumService
    {
        Task CreateAlbumAsync(CreateAlbumInputModel createAlbum);

        Task<bool> AddTrackToAlbum(string albumId, Track track);

        Task<ICollection<T>> GetAllAlbums<T>();

        Task<Album> GetAlbumByIdAsync(string id);

        Task<T> GetAlbumDetailsAsync<T>(string id);
    }
}
