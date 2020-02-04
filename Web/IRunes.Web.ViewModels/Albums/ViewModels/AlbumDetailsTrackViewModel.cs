namespace IRunes.Web.ViewModels.Albums.ViewModels
{
    using IRunes.Data.Models;
    using IRunes.Services.Mapping;

    public class AlbumDetailsTrackViewModel : IMapFrom<Track>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
