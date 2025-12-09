

using Domain.Ports.Primary;
using Domain.Ports.Secundary;
using Domain.Services;
using JsonRepository;
using Microsoft.Extensions.DependencyInjection;
using System;

// Definimos la ruta del archivo JSON
string pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "product.json");


// 
var services = new ServiceCollection();
// Registramos el repositorio con la ruta del archivo JSON
services.AddTransient<IRepository>(provider=>new ProductRepository(pathFile));
services.AddTransient<IService,ProductService>();

var serviceProvider = services.BuildServiceProvider();
var productService = serviceProvider.GetService<IService>();



