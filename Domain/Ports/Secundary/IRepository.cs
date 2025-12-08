using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports.Secundary
{
    public interface IRepository
    {
        void Save(Product product);

        List<Product> GetAll();
    }
}
