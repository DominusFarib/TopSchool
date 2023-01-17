using AutoMapper;
using TopSchool.Domain.Models;
using TopSchool.Domain.Entities;

namespace TopSchool.Domain.AutoMapper;

public class MapperProfiles : Profile
{
    public MapperProfiles()
    {
        CreateMap<AlunoModel, Aluno>().ReverseMap();
        CreateMap<ProfessorModel, Professor>().ReverseMap();

        //CreateMap<MunicipioResultModel, MunicipioEntity>().ReverseMap();

        //CreateMap<UFModel, UFEntity>().ReverseMap();
        //CreateMap<UFResultModel, UFEntity>().ReverseMap();

        //CreateMap<EnderecoModel, EnderecoEntity>().ReverseMap();
        //CreateMap<EnderecoResultModel, EnderecoEntity>().ReverseMap();
    }
}
