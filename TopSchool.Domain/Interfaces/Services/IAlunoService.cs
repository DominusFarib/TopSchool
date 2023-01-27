using TopSchool.Domain.Models;

namespace TopSchool.Domain.Interfaces.Services
{
    public interface IAlunoService : IServiceBase<AlunoModel, AlunoModel>
    {
        Task<AlunoModel?> GetByNameAsync(string pName);
        Task<AlunoModel?> GetByMatriculaAsync(int pMatricula);
        Task<IEnumerable<AlunoModel>?> GetByLikeNameAsync(string pNamePart);
    }
}
