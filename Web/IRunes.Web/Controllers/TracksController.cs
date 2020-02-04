namespace IRunes.Web.Controllers
{
    using IRunes.Data.Models;
    using IRunes.Services.Data;
    using IRunes.Web.ViewModels.Tracks.InputModels;
    using IRunes.Web.ViewModels.Tracks.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class TracksController : BaseController
    {
        private readonly ITrackService trackService;
        private readonly IAlbumService albumService;

        public TracksController(ITrackService trackService, IAlbumService albumService)
        {
            this.trackService = trackService;
            this.albumService = albumService;
        }

        [Authorize]
        public ActionResult Create(string albumId)
        {
            return this.View(new TrackCreateViewModel { AlbumId = albumId });
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(CreateTrackInputModel trackInputModel)
        {
            var trackForDb = await this.trackService.CreateTrackAsync(trackInputModel);
            var isTrackAddedSuccessfuly = await this.albumService.AddTrackToAlbumAsync(trackInputModel.AlbumId, trackForDb);

            if (!isTrackAddedSuccessfuly)
            {
                return this.Redirect("/Albums/All");
            }

            return this.Redirect($"/Albums/Details?id={trackInputModel.AlbumId}");
        }

        [Authorize]
        public async Task<ActionResult> Details(string trackId, string albumId)
        {
            Track trackFromDb = await this.trackService.GetTrackByIdAsync(trackId);

            if (trackFromDb == null)
            {
                return this.Redirect($"/Albums/Details?id={albumId}");
            }

            TrackDetailsViewModel trackDetailsViewModel = new TrackDetailsViewModel
            {
                Name = trackFromDb.Name,
                Link = trackFromDb.Link,
                Price = trackFromDb.Price.ToString(),
                AlbumId = trackFromDb.AlbumId,
            };

            return this.View(trackDetailsViewModel);
        }
    }
}
