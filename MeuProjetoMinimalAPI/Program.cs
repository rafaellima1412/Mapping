using AutoMapper;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.MapGet("/", (IMapper mapper) =>
{
    // Aqui você pode usar o mapper para mapear objetos

    return "Exemplo do uso do AutoMapper";
});

app.Run();