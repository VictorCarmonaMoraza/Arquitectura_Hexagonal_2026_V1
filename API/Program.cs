using Domain.Ports.Primary;
using Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

// Definimos la ruta del archivo JSON
string pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "productApi.json");
//.Services.AddTransient<Domain.Ports.Secundary.IRepository>(provider => new JsonRepository.ProductRepository(pathFile));
builder.Services.AddTransient<Domain.Ports.Secundary.IRepository>(provider => new XMLRepository.XMLProductRepository(pathFile));
builder.Services.AddTransient<IService, ProductService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
