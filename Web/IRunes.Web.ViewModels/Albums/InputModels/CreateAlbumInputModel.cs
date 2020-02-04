namespace IRunes.Web.ViewModels.Albums.InputModels
{
    using IRunes.Data.Models;
    using IRunes.Services.Mapping;

    public class CreateAlbumInputModel : IMapFrom<Album>
    {
        public string Name { get; set; }

        public string Cover { get; set; }
    }
}
