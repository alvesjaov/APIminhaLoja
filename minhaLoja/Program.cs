using Microsoft.EntityFrameworkCore;
using minhaLoja.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Alteração para MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' is not found.");
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(connectionString));

// Adicionando configuração para ignorar referências circulares
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilitar o Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto API Minha Loja");
    c.RoutePrefix = string.Empty; // Para acessar o Swagger na raiz (http://localhost:5140/)
});

app.UseAuthorization();

app.MapControllers();

Console.WriteLine("Aplicação iniciada. Acesse http://localhost:5140/swagger para ver a documentação da API.");

await app.RunAsync();
