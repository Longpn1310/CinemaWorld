using CinemaWorld.Data.Common.Models;

namespace CinemaWorld.Global.Common.Repositories
{
    //WHERE TENTITY CLASS RANG BUOC VOI IDELE, IREPO
    public interface IDeletableEntityRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IDeletableEntity
    {
        IQueryable<TEntity> AllWithDeleted();
        IQueryable<TEntity> AllAsNoTrackingWithDeleted();

        Task<TEntity> GetByIdWithDeletedAsync(params object[] id);

        void HardDelete(TEntity entity);

        void Undelete(TEntity entity);
    }
}
