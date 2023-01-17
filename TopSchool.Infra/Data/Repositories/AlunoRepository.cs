using TopSchool.Domain.Entities;
using TopSchool.Domain.Interfaces.Repositories;

namespace TopSchool.Infra.Data.Repositories;

public class AlunoRepository : RepositoryBase<Aluno>, IAlunoRepository
{
    public AlunoRepository(DataContext pDbContext) : base(pDbContext)
    {
        _dbSet = _dbContext.Set<Aluno>();
    }

    public Task<Aluno?> SelectByEmailAsync(string pEmail)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Aluno>?> SelectByLikeNameAsync(string pNamePart)
    {
        throw new NotImplementedException();
    }

    public Task<Aluno?> SelectByMailAsync(string pMail)
    {
        throw new NotImplementedException();
    }

    public Task<Aluno?> SelectByNameAsync(string pName)
    {
        throw new NotImplementedException();
    }
}
