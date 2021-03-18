using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Shop.Controllers;
using Shop.Data;
using Shop.Models;
using System;

namespace Shop.Test
{
    class OrderControllerTest
    {
        private ShoppingCart _shoppingCartMock;
        private Mock<IOrderRepository> _orderRepositoryMock;
        private ShopDbContext _context => GetDatabaseContext();
        private OrderController _controller; 
        [SetUp]
        public void Setup()
        {
            _shoppingCartMock = new ShoppingCart(_context);
            _orderRepositoryMock = new Mock<IOrderRepository>();

            _controller = new OrderController(_orderRepositoryMock.Object, _shoppingCartMock);
        }

        [Test]
        public void Checkout_CheckReturnValue_ExpectViewResult()
        {
            //arrange
            _shoppingCartMock.AddToCart(new Ebook
            {
                EbookId = 0,
                Title = "Title",
                Description = "Description",
                Price = 1,
                Category = EEbookCategory.Horror
            }, 1);

            //act
            var result = _controller.Checkout();

            //assert 
            Assert.That(result, Is.InstanceOf<ViewResult>());
            
        }

        private ShopDbContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new ShopDbContext(options);
            databaseContext.Database.EnsureCreated();

            return databaseContext;
        }

    }
}
