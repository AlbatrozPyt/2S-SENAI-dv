using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o servico de controllers
builder.Services.AddControllers();

// Adiciona servicos de autenticacao JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

// Define os parametros de validacao do token
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // Valida quem esta solicitando
        ValidateIssuer = true,

        // Valida quem esta recebendo
        ValidateAudience = true,

        // Define se o tempo de expiracao do token sera validado
        ValidateLifetime = true,

        // Forma de criptografia e a ainda a validacao da chave de autenticacao
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev")),

        // Valida o tempo de expiracao do token
        ClockSkew = TimeSpan.FromMinutes(5),

        // De onde esta vindo (issuer)
        ValidIssuer = "webapi.filmes.tarde",

        // Para onde esta indo (audience)
        ValidAudience = "webapi.filmes.tarde"
    };
});


// Adicione o gerador do Swagger à coleção de serviços no Program.cs
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "1ª Versão",
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
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    // Usando Autenticacao no swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

// Habilite o middleware para atender ao documento JSON gerado e à interface do usuário do Swagger, também em Program.cs
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// A interface do usuário do Swagger e a incorpora em outros programas
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseAuthentication();
app.UseAuthorization();

// Mapear os controllers
app.MapControllers();

app.Run();
