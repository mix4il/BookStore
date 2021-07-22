using BookStore.Domain;
using BookStore.Repositories;
using BookStore.Services;
using NUnit.Framework;
using NUnitTestProductService.Mock;
using System;

namespace NUnitTestProductService
{
    [TestFixture]
    public class ProductServiceTests
    {

        private ProductService _productService;
        private IProductRepository _productRepository;

        [SetUp]
        public void Setup()
        {
            var logger = new LoggerMock<ProductService>();

            _productRepository = new ProductReportsitoryMock();
            _productService = new ProductService(_productRepository, logger);
        }

        [Test]
        public void AddOrder_OrderWithEmptyName_ThrowArgumentException()
        {
            // Arrange
            var order = new Order();

            // Act
            TestDelegate saveOrder = () =>
            {
                _productService.AddOrder(new Order());
            };

            // Assert
            Assert.Throws(typeof(ArgumentException), saveOrder);
        }

        [Test]
        public void GetTotalPrice_EqualPrice_Test()
        {
            var order = new Order
            {
                Books = new Product[]
              {
              new Product() { Price = 1000,
              Quantity = 1},
              new Product() { Price = 500,
                  Quantity = 1 }
              }
            };

            int totalPrice =_productService.GetTotalPrice(order.Books);
            Assert.AreEqual(totalPrice, 1425);
        }

        [Test]
        public void GetTotalQuantity_EqualQuantity_Test()
        {
            var order = new Order
            {
                Books = new Product[]
              {
              new Product() { Quantity = 5 },
              new Product() { Quantity = 10 }
              }
            };
            int totalQuantity = _productService.GetTotalQuantity(order.Books);
            Assert.AreEqual(totalQuantity, 15);
        }
    }
}