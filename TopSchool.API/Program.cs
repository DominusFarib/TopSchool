using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Newtonsoft.Json;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using TopSchool.Infra.CrossCutting;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(
//        builder =>
//        {
//            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
//        });
//});
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(MyAllowSpecificOrigins,
//                          policy =>
//                          {
//                              policy.WithOrigins("http://localhost:4200",
//                                                  "http://localhost:8000/")
//                                                  .AllowAnyHeader()
//                                                  .AllowAnyMethod()
//                                                  .AllowAnyHeader();
//                          });
//});

builder.Services.AddCors();

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    //opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    //opt.JsonSerializerOptions.MaxDepth = 4;
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddControllersWithViews().AddJsonOptions(opt =>
{
    //opt.JsonSerializerOptions.MaxDepth = 4;
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddMvc().AddJsonOptions(opt =>
{
    //opt.JsonSerializerOptions.MaxDepth = 4;
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddVersionedApiExplorer(opt =>
{
    opt.GroupNameFormat = "'v' VVV";
    opt.SubstituteApiVersionInUrl = true; // pode por a vers�o da URL do EndPoint da API

}).AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(6, 0);
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.ReportApiVersions = true;
}); 


var apiDescriptionProvider = builder.Services
    .BuildServiceProvider()
    .GetService<IApiVersionDescriptionProvider>();

builder.Services.AddSwaggerGen(opt =>
{
    // Exibindo todas as vers�es das Controller
    foreach (var version in apiDescriptionProvider.ApiVersionDescriptions)
    {
        opt.SwaggerDoc(
            version.GroupName,
            new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Email = "dofari.dfr@gmail.com",
                    Name = "Dominus Farib",
                    Url = new Uri("http://www.oeste.com")
                },
                Description = "API para controle de dados escolares",
                Title = "TopSchool Web API NET6",
                Version = version.ApiVersion.ToString(),
                License = new Microsoft.OpenApi.Models.OpenApiLicense
                {
                    Name = "Free open source"
                }
            });
    }
    var xmlAssemblyFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlAssemblyPath = Path.Combine(AppContext.BaseDirectory, xmlAssemblyFile);
    opt.IncludeXmlComments(xmlAssemblyPath);

});

var configSettings = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environments.Development}.json", optional: true, reloadOnChange: true);


ConfigServices.AddMapperProfiles(builder.Services);
ConfigServices.AddDbContext(builder.Services);
ConfigServices.AddServices(builder.Services);


var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        // Exibindo todas as vers�es das Controller
        foreach (var version in apiDescriptionProvider.ApiVersionDescriptions)
        {
            opt.SwaggerEndpoint($"/swagger/{version.GroupName}/swagger.json", version.GroupName.ToLowerInvariant());
        }
        opt.RoutePrefix = "topschool";
    });
}*/
app.UseSwagger();
app.UseSwaggerUI(opt =>
{
    // Exibindo todas as vers�es das Controller
    foreach (var version in apiDescriptionProvider.ApiVersionDescriptions)
    {
        opt.SwaggerEndpoint($"/swagger/{version.GroupName}/swagger.json", version.GroupName.ToLowerInvariant());
    }
    opt.RoutePrefix = "";
});
app.UseRouting();

// app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
// app.UseCors();
app.UseCors(MyAllowSpecificOrigins);
app.UseMiddleware(typeof(ConfigCors)); // Custom CORS settings
app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.Run();
