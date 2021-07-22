using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface IProductService
    {
        public IEnumerable<Product> GetAll();

        public void Save(IEnumerable<Product> contacts);

        public void AddOrder(Order contacts);
    }
}
