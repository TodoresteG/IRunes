namespace IRunes.Services.Data
{
    using System.Threading.Tasks;

    using IRunes.Data.Common.Repositories;
    using IRunes.Data.Models;

    public class UserService : IUserService
    {
        private readonly IUserRepository<ApplicationUser> userRepository;

        public UserService(IUserRepository<ApplicationUser> userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<ApplicationUser> CreateUser(ApplicationUser user)
        {
            await this.userRepository.AddAsync(user);
            await this.userRepository.SaveChangesAsync();

            return user;
        }

        public ApplicationUser GetUserByUsernameAndPassword(string username, string password)
        {
            return this.userRepository.GetUserByUsernameAndPassword(username, password);
        }
    }
}
