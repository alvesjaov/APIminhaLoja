using Microsoft.EntityFrameworkCore;
using minhaLoja.Data;

var builder = WebApplication.CreateBuilder(args);

// Adicionando o DbContext aos serviços
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Outros serviços necessários para a aplicação
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilitar o Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "minhaLoja API V1");
    c.RoutePrefix = string.Empty; // Para acessar o Swagger na raiz (http://localhost:5140/)
});

app.UseAuthorization();

app.MapControllers();

Console.WriteLine("Aplicação iniciada. Acesse http://localhost:5140/swagger para ver a documentação da API.");

await app.RunAsync();