using CinemaWorld.Data;
using CinemaWorld.Data.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaWorld.Global.Common.Repositories
{
    public class EfDeletableEntityRepository<TEntity> : EfRepository<TEntity>, IDeletableEntityRepository<TEntity>
        where TEntity : class, IDeletableEntity
    {
        public EfDeletableEntityRepository(CinemaWorldDbContext context) : base(context)
        { 
        }
        public override IQueryable<TEntity> All() => base.All().Where(x => !x.IsDeleted);
        public override IQueryable<TEntity> AllAsNoTracking() => base.AllAsNoTracking().Where(x => !x.IsDeleted);

        public IQueryable<TEntity> AllAsNoTrackingWithDeleted() => base.AllAsNoTracking().IgnoreQueryFilters();//Cho phép ẩn thực thể đã xoá

        public IQueryable<TEntity> AllWithDeleted() => base.All().IgnoreQueryFilters();

        public Task<TEntity> GetByIdWithDeletedAsync(params object[] id)
        {
            var getByIdPredicate = EfExpressionHelper.BuildByIdPredicate<TEntity>(this.Context, id);
            return this.AllWithDeleted().FirstOrDefaultAsync(getByIdPredicate);

        }
        public void HardDelete(TEntity entity) => base.Delete(entity);
        public void Undelete(TEntity entity)
        {
            entity.IsDeleted = false;
            entity.DeletedOn = null;
            this.Update(entity);
        }
    }
}
