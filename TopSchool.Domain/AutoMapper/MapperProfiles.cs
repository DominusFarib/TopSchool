using AutoMapper;
using TopSchool.Domain.Models;
using TopSchool.Domain.Entities;
using TopSchool.Domain.Helpers;
namespace TopSchool.Domain.AutoMapper;

public class MapperProfiles : Profile
{
    public MapperProfiles()
    {
        CreateMap<Aluno, AlunoModel>()
            .ForMember(dest => dest.Idade, opt => opt.MapFrom(src => src.DtNascimento.TotalYears()));
        //.ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome +" "+ src.SobreNome)

        CreateMap<AlunoModel, Aluno>();

        CreateMap<ProfessorModel, Professor>().ReverseMap();
        CreateMap<DisciplinaModel, Disciplina>().ReverseMap();

        //CreateMap<MunicipioResultModel, MunicipioEntity>().ReverseMap();

        //CreateMap<UFModel, UFEntity>().ReverseMap();
        //CreateMap<UFResultModel, UFEntity>().ReverseMap();

        //CreateMap<EnderecoModel, EnderecoEntity>().ReverseMap();
        //CreateMap<EnderecoResultModel, EnderecoEntity>().ReverseMap();
    }
}
