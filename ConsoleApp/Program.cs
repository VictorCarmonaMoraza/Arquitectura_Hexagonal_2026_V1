

using Domain.Ports.Primary;
using Domain.Ports.Secundary;
using Domain.Services;
using JsonRepository;
using Microsoft.Extensions.DependencyInjection;
using System;

// Definimos la ruta del archivo JSON
string pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "productConsola.json");


// 
var services = new ServiceCollection();
// Registramos el repositorio con la ruta del archivo JSON
services.AddTransient<IRepository>(provider => new ProductRepository(pathFile));
services.AddTransient<IService, ProductService>();

var serviceProvider = services.BuildServiceProvider();
var productService = serviceProvider.GetService<IService>();

while (true)
{
    try
    {
        Console.WriteLine("1. Register Product");
        Console.WriteLine("2. List Products");
        Console.WriteLine("3. Exit");

        Console.Write("Select an option: ");
        var input = Console.ReadLine();
        switch (input)
        {
            case "1":
                Console.WriteLine("Ingrese un producto");
                string name = Console.ReadLine() ?? "";
                Console.WriteLine("Ingrese el precio");
                decimal price = decimal.Parse(Console.ReadLine() ?? "0");
                productService?.Register(name, price);
                Console.WriteLine("Producto registrado exitosamente.");
                break;
            case "2":
                Console.WriteLine("Lista de productos:");
                foreach (var product in productService?.GetAll())
                {
                    Console.WriteLine($"-{product.Name} => ${product.Price}");
                }
                break;
            case "3":
                Console.WriteLine("Saliendo...");
                return;
            default:
                Console.WriteLine("Opcion no valida. Intente de nuevo.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}



