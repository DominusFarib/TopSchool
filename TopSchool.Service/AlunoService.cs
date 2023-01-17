using TopSchool.Domain.Models;
using TopSchool.Domain.Entities;
using TopSchool.Domain.Interfaces.Services;
using TopSchool.Domain.Interfaces.Repositories;
using AutoMapper;

namespace TopSchool.Service;

public class AlunoService : ServiceBase<AlunoModel, AlunoModel, Aluno>, IAlunoService
{
    private readonly IAlunoRepository _usuarioRepository;
    public AlunoService(IAlunoRepository pAlunoRepository, IMapper mapper)
    : base(pAlunoRepository, mapper)
    {
        _usuarioRepository = pAlunoRepository;
        _autoMapper = mapper;
    }

    public async Task<IEnumerable<AlunoModel>> GetAllAsync()
    {
        var ret = await _usuarioRepository.SelectAllAsync();
        return _autoMapper.Map<IEnumerable<AlunoModel>>(ret);
    }

    public Task<AlunoModel?> GetByEmailAsync(string pEmail)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AlunoModel>?> GetByLikeNameAsync(string pNamePart)
    {
        throw new NotImplementedException();
    }

    public Task<AlunoModel?> GetByNameAsync(string pName)
    {
        throw new NotImplementedException();
    }
}