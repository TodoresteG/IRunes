namespace IRunes.Services.Data
{
    using System.Threading.Tasks;

    using IRunes.Data.Models;
    using IRunes.Web.ViewModels.Tracks.InputModels;

    public interface ITrackService
    {
        Task<Track> GetTrackByIdAsync(string trackId);

        Task<Track> CreateTrackAsync(CreateTrackInputModel trackInputModel);
    }
}
