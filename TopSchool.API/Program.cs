using Microsoft.AspNetCore.Http.Json;
using TopSchool.Infra.CrossCutting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    o.JsonSerializerOptions.MaxDepth = 4;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configSettings = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environments.Development}.json", optional: true, reloadOnChange: true);


ConfigServices.AddMapperProfiles(builder.Services);
ConfigServices.AddDbContext(builder.Services);
ConfigServices.AddServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
