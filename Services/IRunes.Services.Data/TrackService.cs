namespace IRunes.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using IRunes.Data.Common.Repositories;
    using IRunes.Data.Models;
    using IRunes.Web.ViewModels.Tracks.InputModels;

    public class TrackService : ITrackService
    {
        private readonly IDeletableEntityRepository<Track> trackRepository;

        public TrackService(IDeletableEntityRepository<Track> trackRepository)
        {
            this.trackRepository = trackRepository;
        }

        public async Task<Track> CreateTrackAsync(CreateTrackInputModel trackInputModel)
        {
            Track trackForDb = new Track
            {
                Id = Guid.NewGuid().ToString(),
                Name = trackInputModel.Name,
                Link = trackInputModel.Link,
                Price = trackInputModel.Price,
                AlbumId = trackInputModel.AlbumId,
            };

            await this.trackRepository.AddAsync(trackForDb);
            await this.trackRepository.SaveChangesAsync();

            return trackForDb;
        }

        public async Task<Track> GetTrackByIdAsync(string trackId)
        {
            return await this.trackRepository.GetByIdWithDeletedAsync(trackId);
        }
    }
}
