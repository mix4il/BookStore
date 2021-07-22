using BookStore.Domain;
using BookStore.Repositories;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;


        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public IEnumerable<Product> GetAll()
        {
            _logger.LogInformation("Список контактов был запрошен!");
            return _productRepository.GetAllProducts();
        }

        public void Save(IEnumerable<Product> products)
        {
            if (products.Any(c => String.IsNullOrEmpty(c.Author)))
            {
                throw new ArgumentException("Имя контакта должно быть задано");
            }
            _logger.LogInformation("Список контактов был обновлен!");
            _productRepository.UpdateProducts(products);
        }

        public void AddOrder(Order order)
        {
            Random rnd = new Random();
            order.Id = rnd.Next(0, 10000);
            order.TotalPrice = GetTotalPrice(order.Books);
            order.TotalQuantity = GetTotalQuantity(order.Books);
            var json = JsonConvert.SerializeObject(order, Formatting.Indented);
            File.WriteAllText($"C:\\Users\\Михаил\\Downloads\\BookStore\\BookStore\\BookStore\\Data\\{order.Id}.json", json);
        }

        public int GetTotalPrice(Product[] products)
        {
            int totalPrice = 0;
            for(int i = 0; i <products.Length; i++)
            {
                totalPrice += products[i].Price * products[i].Quantity;
            }
            return (int)((totalPrice > 1000) ? totalPrice * 0.95 : totalPrice);
        }
        public int GetTotalQuantity(Product[] products)
        {
            int totalQuantity = 0;
            for(int i = 0; i < products.Length; i++)
            {
                totalQuantity+= products[i].Quantity;
            }
            return totalQuantity;
        }
    }
}
