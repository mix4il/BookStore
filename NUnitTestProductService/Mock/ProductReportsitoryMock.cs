using BookStore.Domain;
using BookStore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProductService.Mock
{
    internal class ProductReportsitoryMock : IProductRepository
    {

        private IEnumerable<Product> _products = Array.Empty<Product>();


        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        public void UpdateProducts(IEnumerable<Product> products)
        {
            _products = products;
        }

    }
}
