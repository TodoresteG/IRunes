namespace IRunes.Web.ViewModels.Albums.ViewModels
{
    using System.Collections.Generic;

    using IRunes.Data.Models;
    using IRunes.Services.Mapping;

    public class AlbumDetailsViewModel : IMapFrom<Album>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Cover { get; set; }

        public string Price { get; set; }

        public ICollection<AlbumDetailsTrackViewModel> Tracks { get; set; }
    }
}
