using Microsoft.EntityFrameworkCore;
using MinhaLojaAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuração do DbContext com a string de conexão
builder.Services.AddDbContext<LojaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Outros serviços necessários para a aplicação
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilitar o Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Run();
