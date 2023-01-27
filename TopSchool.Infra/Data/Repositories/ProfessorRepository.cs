using Microsoft.EntityFrameworkCore;
using TopSchool.Domain.Entities;
using TopSchool.Domain.Interfaces.Repositories;

namespace TopSchool.Infra.Data.Repositories;

public class ProfessorRepository : RepositoryBase<Professor>, IProfessorRepository
{
    public ProfessorRepository(DataContext pDbContext) : base(pDbContext)
    {
        _dbSet = _dbContext.Set<Professor>();
    }

    public async Task<IEnumerable<Professor>?> SelectByAlunoIdAsync(int pAlunoId)
    {
        try
        {
            //var ret = await _dbContext.DbSetProfessor
            //     .Include(
            //         pd => pd.DisciplinasDoProfessor.Where(i => i.AlunosDaDisciplina.Any(a => a.AlunoId == pAlunoId))
            //     )
            //     .ThenInclude(d => d.Disciplina).Where(m => m.DisciplinasDoProfessor.Count()>0)
            //     .ToListAsync();

            //// ret = ret.Where(l => l.DisciplinasDoProfessor.Any()).ToList();

            //var bet = await _dbContext.DbSetProfessor
            //    .Join(_dbContext.DbSetDisciplinaProfessor,
            //        dp => dp.Id,
            //        da => da.ProfessorId, (dp, da) => new DisciplinaProfessores { 
            //            Id = da.Id,
            //            ProfessorId = da.ProfessorId,
            //            Professor = dp,
            //            Disciplina = da.Disciplina
            //        })
            //    .Join(_dbContext.DbSetAlunoDisciplina.Where(v => v.AlunoId == pAlunoId),
            //        dp => dp.Id,
            //        da => da.DisciplinaProfessoresId, (dp, da) => dp)
            //    .ToListAsync();


            var ret = await (from p in _dbContext.DbSetProfessor
                             select( new Professor
                             {
                                 Id = p.Id,
                                 Nome = p.Nome,
                                 NrMatricula = p.NrMatricula,
                                 DisciplinasDoProfessor = (
                                    from a in _dbContext.DbSetDisciplinaProfessor
                                    join da in _dbContext.DbSetAlunoDisciplina on a.Id equals da.DisciplinaProfessoresId
                                    where (a.ProfessorId == p.Id && da.AlunoId == pAlunoId)
                                    select new DisciplinaProfessores {
                                        Id = a.Id,
                                        ProfessorId = a.ProfessorId,
                                        Disciplina = a.Disciplina
                                    }).ToList() 
                             })
                             ).Where(l=>l.DisciplinasDoProfessor.Any()).ToListAsync();

            return ret;
        }
        catch (Exception ex)
        {
            throw ex;
        }
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
