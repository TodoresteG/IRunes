namespace IRunes.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using IRunes.Data.Models;
    using IRunes.Services.Data;
    using IRunes.Web.ViewModels.Albums.InputModels;
    using IRunes.Web.ViewModels.Albums.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class AlbumsController : BaseController
    {
        private readonly IAlbumService albumService;

        public AlbumsController(IAlbumService albumService)
        {
            this.albumService = albumService;
        }

        [Authorize]
        public async Task<IActionResult> All()
        {
            ICollection<AlbumAllViewModel> allAlbums = await this.albumService.GetAllAlbumsAsync<AlbumAllViewModel>();

            // Presentation logic not bussiness logic
            if (allAlbums.Count != 0)
            {
                return this.View(allAlbums.ToList());
            }

            return this.View(new List<AlbumAllViewModel>());
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateAlbumInputModel createAlbum)
        {
            await this.albumService.CreateAlbumAsync(createAlbum);

            return this.Redirect("/Albums/All");
        }

        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            var albumFromDb = await this.albumService.GetAlbumByIdAsync(id);

            AlbumDetailsViewModel albumDetailsViewModel = new AlbumDetailsViewModel
            {
                Id = albumFromDb.Id,
                Cover = albumFromDb.Cover,
                Name = albumFromDb.Name,
                Price = albumFromDb.Price.ToString(),
                Tracks = albumFromDb.Tracks.Select(t => new AlbumDetailsTrackViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                }).ToList(),
            };

            if (albumFromDb == null)
            {
                return this.Redirect("/Albums/All");
            }

            return this.View(albumDetailsViewModel);
        }
    }
}
