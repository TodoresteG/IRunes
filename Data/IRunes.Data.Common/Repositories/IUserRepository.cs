namespace IRunes.Data.Common.Repositories
{
    using IRunes.Data.Common.Models;

    public interface IUserRepository<T> : IDeletableEntityRepository<T>
        where T : class, IDeletableEntity
    {
        T GetUserByUsernameAndPassword(string username, string password);
    }
}
