using BookStore.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositories
{  
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();

        public void UpdateProducts(IEnumerable<Product> products);
    }
}
