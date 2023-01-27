using Microsoft.EntityFrameworkCore;
using TopSchool.Domain.Entities;
using TopSchool.Domain.Interfaces.Repositories;

namespace TopSchool.Infra.Data.Repositories;

public class AlunoRepository : RepositoryBase<Aluno>, IAlunoRepository
{
    public AlunoRepository(DataContext pDbContext) : base(pDbContext)
    {
        _dbSet = _dbContext.Set<Aluno>();
    }

    public async Task<Aluno?> GetByMatriculaAsync(int pMatricula)
    {
        try
        {
            return await _dbSet.SingleOrDefaultAsync(i => i.NrMatricula.Equals(pMatricula));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<IEnumerable<Aluno>?> SelectByLikeNameAsync(string pNamePart)
    {
        try
        {
            return await _dbSet.Where(i => i.Nome.Contains(pNamePart)).ToListAsync();
        }
        catch (Exception ex)
        {
            throw ex;
        }
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
