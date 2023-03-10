
using TopSchool.Domain.Helpers;
using TopSchool.Domain.Models;

namespace TopSchool.Domain.Interfaces.Services;
public interface IServiceBase<ModelParam, ModelResult>
    where ModelParam : ModelBase
    where ModelResult : ModelBase
{
    Task<ModelResult> Get(int pId);
    Task<ModelResult> Post(ModelParam pItem);
    Task<ModelResult> Put(ModelResult pItem);
    Task<bool> Post(List<ModelParam> pItems);
    Task<bool> Delete(int pId);

    Task<PaginationList<ModelResult>> GetAllAsync(PaginationConfig pageParams);

}
