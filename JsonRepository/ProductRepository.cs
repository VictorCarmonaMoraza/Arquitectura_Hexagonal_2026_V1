using Domain.Entities;
using Domain.Ports.Secundary;
using System.Text.Json;

namespace JsonRepository
{
    public class ProductRepository : IRepository
    {
        private readonly string _path;

        public ProductRepository(string path)
        {
            _path = path;
        }

        public List<Product> GetAll()
        {
            //Comprobar si el fichero eciste
            if (!File.Exists(_path))
            {
                return new List<Product>();
            }

            //Leemos la informacion del archivo
            string jsonString = File.ReadAllText(_path);
            //Deserializamos la informacion
            var products = JsonSerializer.Deserialize<List<Product>>(jsonString);

            //El archivo puede estar vacio en ese caso devolvemos una lista vacia
            return products ?? new List<Product>();

        }

        public void Save(Product product)
        {
            //Obtenemos todos los productos
            var products = GetAll();

            //Añadimos el nuevo producto
            products.Add(product);

            //Serializamos la informacion
            var options = new JsonSerializerOptions { WriteIndented = true };


            //Convertimos a cadena de texto
            string jsonString = JsonSerializer.Serialize(products, options);
            //Escribimos en el archivo
            File.WriteAllText(_path, jsonString);

        }
    }
}
