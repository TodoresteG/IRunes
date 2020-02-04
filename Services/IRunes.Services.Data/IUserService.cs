namespace IRunes.Services.Data
{
    using System.Threading.Tasks;

    using IRunes.Data.Models;

    public interface IUserService
    {
        Task<ApplicationUser> CreateUser(ApplicationUser user);

        ApplicationUser GetUserByUsernameAndPassword(string username, string password);
    }
}
