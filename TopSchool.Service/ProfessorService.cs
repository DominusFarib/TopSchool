using TopSchool.Domain.Models;
using TopSchool.Domain.Entities;
using TopSchool.Domain.Interfaces.Services;
using TopSchool.Domain.Interfaces.Repositories;
using AutoMapper;

namespace TopSchool.Service;

public class ProfessorService : ServiceBase<ProfessorModel, ProfessorModel, Professor>, IProfessorService
{
    private readonly IProfessorRepository _profRepository;
    public ProfessorService(IProfessorRepository pProfessorRepository, IMapper mapper)
    : base(pProfessorRepository, mapper)
    {
        _profRepository = pProfessorRepository;
        _autoMapper = mapper;
    }

    public async Task<IEnumerable<ProfessorModel>?> GetByAlunoIdAsync(int pAlunoId)
    {
        var ret = await _profRepository.SelectByAlunoIdAsync(pAlunoId);
        return _autoMapper.Map<IEnumerable<ProfessorModel>>(ret) ?? Activator.CreateInstance<IEnumerable<ProfessorModel>>();

    }

    public Task<IEnumerable<ProfessorModel>?> GetByLikeNameAsync(string pNamePart)
    {
        throw new NotImplementedException();
    }

    public Task<ProfessorModel?> GetByNameAsync(string pName)
    {
        throw new NotImplementedException();
    }
}