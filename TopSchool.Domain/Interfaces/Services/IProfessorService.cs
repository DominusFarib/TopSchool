using TopSchool.Domain.Models;

namespace TopSchool.Domain.Interfaces.Services
{
    public interface IProfessorService : IServiceBase<ProfessorModel, ProfessorModel>
    {
        Task<ProfessorModel?> GetByNameAsync(string pName);
        Task<ProfessorModel?> GetByEmailAsync(string pEmail);
        Task<IEnumerable<ProfessorModel>> GetAllAsync();
        Task<IEnumerable<ProfessorModel>?> GetByLikeNameAsync(string pNamePart);

    }
}
