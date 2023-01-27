using TopSchool.Domain.Models;
using TopSchool.Domain.Entities;
using TopSchool.Domain.Interfaces.Services;
using TopSchool.Domain.Interfaces.Repositories;
using AutoMapper;

namespace TopSchool.Service;

public class AlunoService : ServiceBase<AlunoModel, AlunoModel, Aluno>, IAlunoService
{
    private readonly IAlunoRepository _alunoRepository;
    public AlunoService(IAlunoRepository pAlunoRepository, IMapper mapper)
    : base(pAlunoRepository, mapper)
    {
        _alunoRepository = pAlunoRepository;
        _autoMapper = mapper;
    }

    public async Task<AlunoModel?> GetByMatriculaAsync(int pMatricula)
    {
        var ret = await _alunoRepository.GetByMatriculaAsync(pMatricula);
        return _autoMapper.Map<AlunoModel>(ret) ?? Activator.CreateInstance<AlunoModel>();
    }

    public async Task<IEnumerable<AlunoModel>?> GetByLikeNameAsync(string pNamePart)
    {
        var ret = await _alunoRepository.SelectByLikeNameAsync(pNamePart);
        return _autoMapper.Map<IEnumerable<AlunoModel>>(ret) ?? Activator.CreateInstance< IEnumerable<AlunoModel>>();
    }

    public Task<AlunoModel?> GetByNameAsync(string pName)
    {
        throw new NotImplementedException();
    }
}