using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TopSchool.Domain.Interfaces.Repositories;
using TopSchool.Domain.Entities;
using TopSchool.Domain.Interfaces.Services;
using TopSchool.Domain.Models;
using TopSchool.Domain.AutoMapper;
using TopSchool.Service;
using TopSchool.Infra.Data;
using TopSchool.Infra.Data.Repositories;
using AutoMapper;

namespace TopSchool.Infra.CrossCutting
{
    public class ConfigServices
    {
        /// <summary>
        /// Injeção de Dependencias do projeto
        /// </summary>
        /// <param name="appServices"></param>

        public static void AddMapperProfiles(IServiceCollection appServices)
        {
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfiles());
            });

            IMapper autoMapper = mapConfig.CreateMapper();

            appServices.AddSingleton(autoMapper);
        }
        public static void AddDbContext(IServiceCollection appServices)
        {
            try
            {
                string dBConnectionString = Environment.GetEnvironmentVariable("CONNECTION");

                var dBType = Environment.GetEnvironmentVariable("DATABASE");
                dBConnectionString = "server=172.18.0.2;port=3306;uid=root;pwd=secreta;database=DbTopSchoolDb;";
                //dBConnectionString = "server=localhost;port=3306;uid=root;pwd=secreta;database=DbTopSchoolDb;";

                //var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
                //optionsBuilder.UseMySql(dBConnectionString);


                appServices.AddDbContext<DataContext>((provider, options) =>
                { options.UseMySql(dBConnectionString, ServerVersion.AutoDetect(dBConnectionString)); });
            }
            catch (Exception ex)
            {
                throw new Exception("Data Base não configurado: " + ex.Message, ex.InnerException);
            }

        }

        public static void AddServices(IServiceCollection appServices)
        {
            appServices.AddScoped<IRepositoryBase<EntityBase>, RepositoryBase<EntityBase>>();
            appServices.AddScoped<IAlunoRepository, AlunoRepository>();
            appServices.AddScoped<IProfessorRepository, ProfessorRepository>();

            appServices.AddScoped<IServiceBase<ModelBase, ModelBase>, ServiceBase<ModelBase, ModelBase, EntityBase>>();
            appServices.AddScoped<IAlunoService, AlunoService>();
            appServices.AddScoped<IProfessorService, ProfessorService>();


        }


    }
}
