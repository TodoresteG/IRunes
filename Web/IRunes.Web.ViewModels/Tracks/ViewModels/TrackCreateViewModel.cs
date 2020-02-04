namespace IRunes.Web.ViewModels.Tracks.ViewModels
{
    using IRunes.Data.Models;
    using IRunes.Services.Mapping;

    public class TrackCreateViewModel : IMapFrom<Track>
    {
        public string AlbumId { get; set; }
    }
}
