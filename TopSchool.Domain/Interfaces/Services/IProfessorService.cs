using TopSchool.Domain.Models;

namespace TopSchool.Domain.Interfaces.Services
{
    public interface IProfessorService : IServiceBase<ProfessorModel, ProfessorModel>
    {
        Task<ProfessorModel?> GetByNameAsync(string pName);
        Task<IEnumerable<ProfessorModel>?> GetByAlunoIdAsync(int pAlunoId);
        Task<IEnumerable<ProfessorModel>?> GetByLikeNameAsync(string pNamePart);
    }
}
