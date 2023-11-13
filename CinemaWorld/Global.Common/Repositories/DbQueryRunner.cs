namespace CinemaWorld.Global.Common.Repositories
{
    using System;
    using System.Threading.Tasks;
    using CinemaWorld.Data;
    using CinemaWorld.Data.Common;
    using Microsoft.EntityFrameworkCore;
    //Thực thi truy vấn với csdl
    public class DbQueryRunner : IDbQueryRunner
    {
        public DbQueryRunner(CinemaWorldDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public CinemaWorldDbContext Context { get; set; }


        public Task RunQueryAsync(string query, params object[] parameters)
        {
            return Context.Database.ExecuteSqlRawAsync(query, parameters);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context?.Dispose();
            }
        }
    }
}
