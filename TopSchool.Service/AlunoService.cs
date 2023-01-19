using TopSchool.Domain.Models;
using TopSchool.Domain.Entities;
using TopSchool.Domain.Interfaces.Services;
using TopSchool.Domain.Interfaces.Repositories;
using AutoMapper;
using TopSchool.Domain.Helpers;

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

    public async Task<PaginationList<AlunoModel>> GetAllAsync(PaginationConfig pageParams)
    {
        var ret = await _usuarioRepository.SelectAllAsync(pageParams);

        //PaginationList<AlunoModel> lista = new PaginationList<AlunoModel>
        //{
        //    CurPage = ret.CurPage,
        //    ItemsPerPage = ret.ItemsPerPage,
        //    TotalItems = ret.TotalItems,
        //    TotalPages = ret.TotalPages
        //};

        //foreach (var item in ret)
        //{
        //    lista.Add(_autoMapper.Map<AlunoModel>(item));
        //}

        try
        {
            var retModel = _autoMapper.Map<PaginationList<AlunoModel>>(ret);

            retModel.CurPage = ret.CurPage;
            retModel.ItemsPerPage = ret.ItemsPerPage;
            retModel.TotalItems = ret.TotalItems;
            retModel.TotalPages = ret.TotalPages;

            return retModel;
        }
        catch (Exception ex)
        {
            throw ex;
        }
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