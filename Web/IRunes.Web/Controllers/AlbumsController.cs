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
            ICollection<AlbumAllViewModel> allAlbums = await this.albumService.GetAllAlbums<AlbumAllViewModel>();

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
        public IActionResult Create(CreateAlbumInputModel createAlbum)
        {
            this.albumService.CreateAlbum(createAlbum);

            return this.Redirect("/Albums/All");
        }

        //[Authorize]
        //public IActionResult Details(string id)
        //{
        //    var albumFromDb = this.albumService.GetAlbumById(id);

        //    AlbumDetailsViewModel albumDetailsViewModel = ModelMapper.ProjectTo<AlbumDetailsViewModel>(albumFromDb);

        //    if (albumFromDb == null)
        //    {
        //        return this.Redirect("/Albums/All");
        //    }

        //    return this.View(albumDetailsViewModel);
        //}
    }
}
