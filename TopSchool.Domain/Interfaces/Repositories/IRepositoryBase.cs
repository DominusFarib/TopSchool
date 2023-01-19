using TopSchool.Domain.Entities;
using TopSchool.Domain.Helpers;

namespace TopSchool.Domain.Interfaces.Repositories;

public interface IRepositoryBase<TEntity> where TEntity : EntityBase
{
    Task<TEntity> InsertAsync(TEntity pItem);
    Task<TEntity> UpdateAsync(TEntity pItem);
    Task<bool> DeleteAsync(int pId);

    Task<TEntity> SelectAsync(int pId);
    Task<PaginationList<TEntity>> SelectAllAsync(PaginationConfig pageParams);
}