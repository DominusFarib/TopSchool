using TopSchool.Domain.Models;

namespace TopSchool.Domain.Interfaces.Services
{
    public interface IAlunoService : IServiceBase<AlunoModel, AlunoModel>
    {
        Task<AlunoModel?> GetByNameAsync(string pName);
        Task<AlunoModel?> GetByEmailAsync(string pEmail);
        Task<IEnumerable<AlunoModel>> GetAllAsync();
        Task<IEnumerable<AlunoModel>?> GetByLikeNameAsync(string pNamePart);

    }
}
