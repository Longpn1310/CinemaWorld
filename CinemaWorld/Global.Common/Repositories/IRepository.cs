namespace CinemaWorld.Global.Common.Repositories
{
    //TEntity tham so kieu generic, cho phep lam viec voi voi object ma khong can tao
    //Idisposable Cung cap 1 co che giai phong tai nguyen khong quan trong
    //where TENtity chi chap nhan kieu class. Dam bao doi tuong duoc anh xa la mot bang trong csdl
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        IQueryable<TEntity> All();
        IQueryable<TEntity> AllAsNoTracking();
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<int> SaveChangesAsync();

    }
}
