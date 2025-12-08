using Domain.Entities;

namespace Domain.Ports.Primary
{
    public interface IService
    {
        void Register(string marca, decimal price);

        IEnumerable<Product> GetAll();
    }
}
