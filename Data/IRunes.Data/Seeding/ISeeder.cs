namespace IRunes.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(RunesDbContext dbContext, IServiceProvider serviceProvider);
    }
}
