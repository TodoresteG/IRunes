namespace IRunes.Data.Models
{
    using IRunes.Data.Common.Models;

    public class Track : BaseDeletableModel<string>
    {
        public string Name { get; set; }

        // link to a video
        public string Link { get; set; }

        public decimal Price { get; set; }

        public string AlbumId { get; set; }

        public Album Album { get; set; }
    }
}
