namespace IRunes.Data.Models
{
    using System.Collections.Generic;

    using IRunes.Data.Common.Models;

    public class Album : BaseDeletableModel<string>
    {
        public Album()
        {
            this.Tracks = new HashSet<Track>();
        }

        public string Name { get; set; }

        // link to an image
        public string Cover { get; set; }

        // sum of all Tracks’ prices, reduced by 13%
        public decimal Price { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}
