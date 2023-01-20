using Microsoft.EntityFrameworkCore;
using TopSchool.Domain.Entities;
using TopSchool.Domain.Helpers;
using TopSchool.Domain.Interfaces.Repositories;

namespace TopSchool.Infra.Data.Repositories;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
{
    protected DataContext _dbContext;
    protected DbSet<TEntity> _dbSet;

    public RepositoryBase(DataContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }

    public async Task<bool> DeleteAsync(int pId)
    {
        try
        {
            var itemOld = await _dbSet.SingleOrDefaultAsync(i => i.Id == pId);

            if (itemOld != null)
            {
                _dbSet.Remove(itemOld);

                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete(int pId)
    {
        try
        {
            var itemOld = _dbSet.AsNoTracking().SingleOrDefaultAsync(i => i.Id == pId);

            if (itemOld != null)
            {
                var task = _dbSet.Remove(itemOld.Result);

                _dbContext.SaveChangesAsync();

                return task.State == EntityState.Deleted;
            }

            return false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<TEntity> InsertAsync(TEntity pItem)
    {
        try
        {
            pItem.DtCreate = DateTime.UtcNow;
            _ = await _dbSet.AddAsync(pItem);
            _ = await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return pItem;
    }

    public async Task<TEntity> SelectAsync(int pId)
    {
        try
        {
            return await _dbSet.SingleOrDefaultAsync(i => i.Id.Equals(pId));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<PaginationList<TEntity>> SelectAllAsync(PaginationConfig pageParams)
    {
        try
        {
            /*
            IQueryable<Aluno> query = _dbContext.DbSetAluno;

            query.Include(a => a.AlunoDisciplinas)
                .ThenInclude(ad => ad.ProfessorDaDisciplina)
                .ThenInclude(pd => pd.Disciplina)
                .ThenInclude(d=>d.ProfessoresDaDisciplinas)
                .ThenInclude(d=>d.Professor);

            query= query.AsNoTracking().OrderBy(a => a.Nome);

            return await query.ToListAsync();
           */

            /// return await _dbSet.ToListAsync();
            /// 
            var items = await _dbSet.ToListAsync();

            return await PaginationList<TEntity>.GetNextPageAsync(items, pageParams.CurrentPage, pageParams.ItemsPerPage);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<TEntity> UpdateAsync(TEntity pItem)
    {
        try
        {
            var itemOld = await _dbSet.SingleOrDefaultAsync(i => i.Id == pItem.Id);

            if (itemOld != null)
            {
                pItem.DtUpdate = DateTime.UtcNow;
                pItem.DtCreate = itemOld.DtCreate;

                _dbContext.Entry(itemOld).CurrentValues.SetValues(pItem);

                await _dbContext.SaveChangesAsync();

                return pItem;
            }

            return null;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
