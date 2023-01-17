
using TopSchool.Domain.Entities;

namespace TopSchool.Domain.Interfaces.Repositories
{
    public interface IProfessorRepository : IRepositoryBase<Professor>
    {
        Task<Professor?> SelectByEmailAsync(string pEmail);
        Task<IEnumerable<Professor>?> SelectByLikeNameAsync(string pNamePart);
        Task<Professor?> SelectByNameAsync(string pName);

        Task<Professor?> SelectByMailAsync(string pMail);
    }
}