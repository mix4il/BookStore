using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain;

namespace BookStore.Repositories
{
    public class JsonProductRepository: IProductRepository
    {
        private readonly FileInfo _fileInfo;

        public JsonProductRepository(FileInfo fileInfo)
        {
            _fileInfo = fileInfo;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return JsonConvert.DeserializeObject<Product[]>(File.ReadAllText(_fileInfo.FullName));
        }

        public void UpdateProducts(IEnumerable<Product> products)
        {
            File.WriteAllText(_fileInfo.FullName, JsonConvert.SerializeObject(products, Formatting.Indented));
        }

    }
}
