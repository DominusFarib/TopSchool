using TopSchool.Domain.Entities;
using TopSchool.Domain.Interfaces.Repositories;

namespace TopSchool.Infra.Data.Repositories;

public class ProfessorRepository : RepositoryBase<Professor>, IProfessorRepository
{
    public ProfessorRepository(DataContext pDbContext) : base(pDbContext)
    {
        _dbSet = _dbContext.Set<Professor>();
    }

    public Task<Professor?> SelectByEmailAsync(string pEmail)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Professor>?> SelectByLikeNameAsync(string pNamePart)
    {
        throw new NotImplementedException();
    }

    public Task<Professor?> SelectByMailAsync(string pMail)
    {
        throw new NotImplementedException();
    }

    public Task<Professor?> SelectByNameAsync(string pName)
    {
        throw new NotImplementedException();
    }
}
