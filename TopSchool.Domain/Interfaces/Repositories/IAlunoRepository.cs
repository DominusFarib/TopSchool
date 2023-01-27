
using TopSchool.Domain.Entities;

namespace TopSchool.Domain.Interfaces.Repositories
{
    public interface IAlunoRepository : IRepositoryBase<Aluno>
    {
        Task<Aluno?> GetByMatriculaAsync(int pMatricula);
        Task<IEnumerable<Aluno>?> SelectByLikeNameAsync(string pNamePart);
        Task<Aluno?> SelectByNameAsync(string pName);

        Task<Aluno?> SelectByMailAsync(string pMail);
    }
}