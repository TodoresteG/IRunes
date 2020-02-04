namespace IRunes.Web.Controllers
{
    using System.Security.Cryptography;
    using System.Security.Claims;
    using System.Text;

    using IRunes.Services.Data;
    using Microsoft.AspNetCore.Mvc;
    using IRunes.Web.ViewModels.Users.InputModels;
    using IRunes.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;

    public class UsersController : BaseController
    {
        private readonly IUserService userService;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UsersController(IUserService userService, SignInManager<ApplicationUser> signInManager)
        {
            this.userService = userService;
            this.signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            // TODO validation for username and password
            var userFromDb = this.userService
                .GetUserByUsernameAndPassword(username, this.HashPassword(password));

            if (userFromDb == null)
            {
                return this.Redirect("Users/Login");
            }

            await this.signInManager.SignInAsync(userFromDb, false);

            // this.SignIn(userFromDb.Id, userFromDb.UserName, userFromDb.Email);
            return this.Redirect("/");
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterInputModel userRegister)
        {
            if (userRegister.Password != userRegister.ConfirmPassword)
            {
                return this.Redirect("Users/Register");
            }

            ApplicationUser user = new ApplicationUser
            {
                UserName = userRegister.Username,
                PasswordHash = this.HashPassword(userRegister.Password),
                Email = userRegister.Email,
            };

            await this.userService.CreateUserAsync(user);
            return this.Redirect("/Users/Login");
        }

        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();

            return this.Redirect("/");
        }

        [NonAction]
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
