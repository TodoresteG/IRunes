namespace IRunes.Data.Repositories
{
    using System.Linq;

    using IRunes.Data.Common.Repositories;
    using IRunes.Data.Models;

    public class UserRepository<T> : EfDeletableEntityRepository<ApplicationUser>, IUserRepository<ApplicationUser>
    {
        public UserRepository(RunesDbContext context)
            : base(context)
        {
        }

        public ApplicationUser GetUserByUsernameAndPassword(string username, string password)
        {
            return this.Context.Users
                .SingleOrDefault(user => (user.UserName == username || user.Email == username)
                                            && user.PasswordHash == password);
        }
    }
}
