namespace IRunes.Data
{
    using System;
    using System.Threading.Tasks;

    using IRunes.Data.Common;

    using Microsoft.EntityFrameworkCore;

    public class DbQueryRunner : IDbQueryRunner
    {
        public DbQueryRunner(RunesDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public RunesDbContext Context { get; set; }

        public Task RunQueryAsync(string query, params object[] parameters)
        {
            return this.Context.Database.ExecuteSqlRawAsync(query, parameters);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Context?.Dispose();
            }
        }
    }
}
