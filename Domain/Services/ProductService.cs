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
            var products = _repository.GetAll();
            return products;
        }

        public void Register(string marca, decimal price)
        {
            //Creacion de un nuevo producto
            var product = new Product(Guid.NewGuid(), marca, price);

            //Guardamos el producto
            _repository.Save(product);

        }
    }
}
