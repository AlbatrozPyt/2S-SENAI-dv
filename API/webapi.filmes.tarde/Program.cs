var builder = WebApplication.CreateBuilder(args);

// Adiciona o servico de controllers
builder.Services.AddControllers();

var app = builder.Build();

// Mapear os controllers
app.MapControllers();

app.Run();
