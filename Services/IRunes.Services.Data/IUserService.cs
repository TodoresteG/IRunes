namespace IRunes.Services.Data
{
    using System.Threading.Tasks;

    using IRunes.Data.Models;

    public interface IUserService
    {
        Task CreateUserAsync(ApplicationUser user);

        ApplicationUser GetUserByUsernameAndPassword(string username, string password);
    }
}
