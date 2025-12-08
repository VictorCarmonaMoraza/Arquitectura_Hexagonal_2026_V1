using Domain.Entities;

namespace Domain.Ports.Secundary
{
    public interface IRepository
    {
        void Save(Product product);

        List<Product> GetAll();
    }
}
