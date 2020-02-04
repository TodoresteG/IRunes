namespace IRunes.Web.ViewModels.Tracks.InputModels
{
    using IRunes.Data.Models;
    using IRunes.Services.Mapping;

    public class CreateTrackInputModel : IMapFrom<Track>
    {
        public string Name { get; set; }

        public string Link { get; set; }

        public decimal Price { get; set; }

        public string AlbumId { get; set; }
    }
}
