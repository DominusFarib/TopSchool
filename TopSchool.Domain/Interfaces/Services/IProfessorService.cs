using TopSchool.Domain.Helpers;
using TopSchool.Domain.Models;

namespace TopSchool.Domain.Interfaces.Services
{
    public interface IProfessorService : IServiceBase<ProfessorModel, ProfessorModel>
    {
        Task<ProfessorModel?> GetByNameAsync(string pName);
        Task<ProfessorModel?> GetByEmailAsync(string pEmail);
        Task<IEnumerable<ProfessorModel>> GetAllAsync(PaginationConfig pageParams);
        Task<IEnumerable<ProfessorModel>?> GetByLikeNameAsync(string pNamePart);

    }
}
