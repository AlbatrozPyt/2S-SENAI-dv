using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using web_api_health_clinic.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new TimeSpanConverter());
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

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
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("webapi-chave-autenticacao-health-clinic")),

        // Valida o tempo de expiracao do token
        ClockSkew = TimeSpan.FromMinutes(5),

        // De onde esta vindo (issuer)
        ValidIssuer = "webapi.healthClinic-tarde",

        // Para onde esta indo (audience)
        ValidAudience = "webapi.healthClinic-tarde"
    };
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "1� Vers�o",
        Title = "Health Clinic",
        Description = "API Health Clinic.",
        Contact = new OpenApiContact
        {
            Name = "Matheus Enrike",
            Url = new Uri("https://github.com/AlbatrozPyt")
        }
    });


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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
