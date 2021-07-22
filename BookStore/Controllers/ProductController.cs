using System.Collections.Generic;
using BookStore.Domain;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _productService.GetAll();
        }

        [HttpPut]
        public void Save([FromBody] IEnumerable<Product> products)
        {
            _productService.Save(products);
        }

        [HttpPost]
        public void AddOrderFile([FromBody] Order order)
        {
            _productService.AddOrder(order);
        }
    }
}
