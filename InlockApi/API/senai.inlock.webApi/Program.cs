using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Adicione o gerador do Swagger � cole��o de servi�os no Program.cs
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "1� Vers�o",
        Title = "API de Generos e Filmes",
        Description = "API para listar, cadastrar, buscar e atualizar filmes ou generos.",
        // TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Matheus Enrike",
            Url = new Uri("https://github.com/AlbatrozPyt")
        }
    });

    // Configura o Swagger para criar o arquivo XML
    // var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    // options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Habilite o middleware para atender ao documento JSON gerado e � interface do usu�rio do Swagger, tamb�m em Program.cs
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// A interface do usu�rio do Swagger e a incorpora em outros programas
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

// Mapear os controllers
app.MapControllers();

app.Run();
