using TopSchool.Domain.Models;
using TopSchool.Domain.Entities;
using TopSchool.Domain.Interfaces.Services;
using TopSchool.Domain.Interfaces.Repositories;

using AutoMapper;

namespace TopSchool.Service;

public class ServiceBase<ModelTarget, ModelResult, TEntity> :
    IServiceBase<ModelTarget, ModelResult>
    where ModelTarget : ModelBase
    where ModelResult : ModelBase
    where TEntity : EntityBase
{
    protected IRepositoryBase<TEntity> _RepositoryBase;
    protected IMapper _autoMapper;

    public ServiceBase(IRepositoryBase<TEntity> pRepositoryBase, IMapper mapper)
    {
        _RepositoryBase = pRepositoryBase;
        _autoMapper = mapper;
    }

    /// <summary>
    /// Delete Register on Database
    /// </summary>
    /// <param name="pId">Id Register</param>
    /// <returns></returns>
    public async Task<bool> Delete(int pId)
    {
        return await _RepositoryBase.DeleteAsync(pId);
    }

    public async Task<ModelResult> Get(int pId)
    {
        var ret = await _RepositoryBase.SelectAsync(pId);
        return _autoMapper.Map<ModelResult>(ret) ?? Activator.CreateInstance<ModelResult>();
    }

    /// <summary>
    /// Add new Register on Database
    /// </summary>
    /// <param name="pItem">Domain Entity</param>
    /// <returns></returns>
    public async Task<ModelResult> Post(ModelTarget pItem)
    {
        try
        {
            var newItem = _autoMapper.Map<TEntity>(pItem);
            var ret = await _RepositoryBase.InsertAsync(newItem);

            return _autoMapper.Map<ModelResult>(ret);
        }
        catch (Exception ex)
        {
            throw new Exception("Que droga de SQLite:" + ex.Message, ex.InnerException);
        }
    }

    public async Task<bool> Post(List<ModelTarget> pItems)
    {
        try
        {
            foreach (var item in pItems)
            {
                var newItem = _autoMapper.Map<TEntity>(item);
                var ret = await _RepositoryBase.InsertAsync(newItem);
            }

            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            throw new Exception("Que droga de SQLite:" + ex.Message, ex.InnerException);
        }
    }


    /// <summary>
    /// Update Register on Database
    /// </summary>
    /// <param name="pItem">Domain Entity</param>
    /// <returns></returns>
    public async Task<ModelResult> Put(ModelResult pItem)
    {
        var updatedItem = _autoMapper.Map<TEntity>(pItem);
        var ret = await _RepositoryBase.UpdateAsync(updatedItem);

        return _autoMapper.Map<ModelResult>(ret);
    }
}
