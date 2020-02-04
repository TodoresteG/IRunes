namespace IRunes.Services.Data
{
    using System.Threading.Tasks;

    using IRunes.Data.Common.Repositories;
    using IRunes.Data.Models;
    using Microsoft.AspNetCore.Identity;

    public class UserService : IUserService
    {
        private readonly IUserRepository<ApplicationUser> userRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(IUserRepository<ApplicationUser> userRepository, UserManager<ApplicationUser> userManager)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
        }

        public async Task CreateUserAsync(ApplicationUser user)
        {
            await this.userManager.CreateAsync(user);
        }

        public ApplicationUser GetUserByUsernameAndPassword(string username, string password)
        {
            return this.userRepository.GetUserByUsernameAndPassword(username, password);
        }
    }
}
