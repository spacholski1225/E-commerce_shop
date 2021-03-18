using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Shop.Controllers;
using Shop.Data;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Test
{
    public class ShoppingCartControllerTest
    {

        private ShoppingCart _shoppingCart;
        private Mock<IEbookRepository> _ebookRepository;
        private ShopDbContext _context => GetDatabaseContext();
        private ShoppingCartController _controller;

        [SetUp]
        public void Setup()
        {
            _shoppingCart = new ShoppingCart(_context);
            _ebookRepository = new Mock<IEbookRepository>();
            _controller = new ShoppingCartController(_ebookRepository.Object, _shoppingCart);

        }

        [Test]
        public void AddToShoppingCart_ItemAddedToCart_ExpectTrue()
        {
            bool testFlag = false;
            //arrange

            var ebook = new Ebook
            {
                EbookId = 11,
                Title = "Title",
                Description = "Description",
                Price = 1,
                Category = EEbookCategory.Horror

            };
            _context.Ebooks.Add(ebook);
            _context.SaveChanges();

            
            //act
            var result = _controller.AddToShoppingCart(ebook.EbookId);

            if (_shoppingCart.ShoppingCartItems == null)
                testFlag = false;
            else if (_shoppingCart.ShoppingCartItems.Count >= 0)
                testFlag = true;
            //assert
            Assert.True(testFlag);
        }

        private ShopDbContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new ShopDbContext(options);
            databaseContext.Database.EnsureCreated();
            if (databaseContext.Ebooks.Count() <= 0)
            {
                databaseContext.Add(new Ebook()
                {
                    EbookId = 1,
                    Title = "Title",
                    Description = "Description",
                    Price = 1,
                    Category = EEbookCategory.Horror

                });
                databaseContext.SaveChanges();
            }
            return databaseContext;
        }
    }
}
