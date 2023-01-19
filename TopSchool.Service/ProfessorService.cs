using TopSchool.Domain.Models;
using TopSchool.Domain.Entities;
using TopSchool.Domain.Interfaces.Services;
using TopSchool.Domain.Interfaces.Repositories;
using AutoMapper;
using TopSchool.Domain.Helpers;

namespace TopSchool.Service;

public class ProfessorService : ServiceBase<ProfessorModel, ProfessorModel, Professor>, IProfessorService
{
    private readonly IProfessorRepository _usuarioRepository;
    public ProfessorService(IProfessorRepository pProfessorRepository, IMapper mapper)
    : base(pProfessorRepository, mapper)
    {
        _usuarioRepository = pProfessorRepository;
        _autoMapper = mapper;
    }

    public async Task<IEnumerable<ProfessorModel>> GetAllAsync(PaginationConfig pageParams)
    {
        var ret = await _usuarioRepository.SelectAllAsync(pageParams);
        return _autoMapper.Map<IEnumerable<ProfessorModel>>(ret);
    }

    public Task<ProfessorModel?> GetByEmailAsync(string pEmail)
    {
        throw new NotImplementedException();
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