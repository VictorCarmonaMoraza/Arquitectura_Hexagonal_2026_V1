using Domain.Entities;
using Domain.Ports.Primary;
using Domain.Ports.Secundary;

namespace Domain.Services
{
    public class ProductService : IService
    {
        private readonly IRepository _repository;


        //Constructor
        public ProductService(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> GetAll()
        {

            //Metodos del repositorio
            var products = _repository.GetAll();
            //Devolvemos los productos
            return products;
        }

        public void Register(string marca, decimal price)
        {
            //Creacion de un nuevo producto
            var product = new Product(Guid.NewGuid(), marca, price);

            //Guardamos el producto, metodo del repositorio
            _repository.Save(product);

        }
    }
}
