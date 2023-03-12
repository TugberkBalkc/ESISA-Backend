using ESISA.Core.Domain.Entities.Common;

namespace ESISA.Core.Application.Interfaces.Repositories.Common
{
    public interface ICommandRepository<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase
    {
        Task<bool> AddAsync(TEntity entity);
        Task<bool> AddRangeAsync(List<TEntity> entities);

        Task<bool> DeleteRangeAsync(Guid[] ids);
        Task<bool> DeleteAsync(Guid id);
        bool Delete(TEntity entity);
        bool DeleteRange(List<TEntity> entities);

        bool Update(TEntity entity);

        Task<int> SaveChangesAsync();
    }
}
