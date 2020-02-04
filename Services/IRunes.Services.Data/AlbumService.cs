namespace IRunes.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using IRunes.Data.Common.Repositories;
    using IRunes.Data.Models;
    using IRunes.Services.Mapping;
    using IRunes.Web.ViewModels.Albums.InputModels;
    using Microsoft.EntityFrameworkCore;

    public class AlbumService : IAlbumService
    {
        private readonly IDeletableEntityRepository<Album> albumRepository;

        public AlbumService(IDeletableEntityRepository<Album> albumRepository)
        {
            this.albumRepository = albumRepository;
        }

        public async Task<bool> AddTrackToAlbumAsync(string albumId, Track track)
        {
            Album albumFromDb = await this.GetAlbumByIdAsync(albumId);

            if (albumFromDb == null)
            {
                return false;
            }

            albumFromDb.Tracks.Add(track);

            albumFromDb.Price = (albumFromDb.Tracks.Select(track => track.Price).Sum() * 87) / 100;

            this.albumRepository.Update(albumFromDb);
            await this.albumRepository.SaveChangesAsync();

            return true;
        }

        public async Task CreateAlbumAsync(CreateAlbumInputModel createAlbum)
        {
            Album album = new Album
            {
                Id = Guid.NewGuid().ToString(),
                Name = createAlbum.Name,
                Cover = createAlbum.Cover,
            };

            await this.albumRepository.AddAsync(album);
            await this.albumRepository.SaveChangesAsync();
        }

        public async Task<Album> GetAlbumByIdAsync(string id)
        {
            return await this.albumRepository.All().Include(t => t.Tracks).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<ICollection<T>> GetAllAlbumsAsync<T>()
        {
            return await this.albumRepository
                .AllAsNoTracking()
                .To<T>()
                .ToArrayAsync();
        }
    }
}
