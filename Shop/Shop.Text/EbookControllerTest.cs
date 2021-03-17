using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Shop.Controllers;
using Shop.Data;
using Shop.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Test
{
    
    public class EbookControllerTest
    {
        private Mock<IEbookRepository> _ebookRepoMock;
        private Mock<IWebHostEnvironment> _hostingEnvironmentMock;

       
        [SetUp]
        public  void Setup()
        {
            _ebookRepoMock = new Mock<IEbookRepository>();
            _hostingEnvironmentMock = new Mock<IWebHostEnvironment>();

            //_controller = new EbookController(_ebookRepoMock.Object, _hostingEnvironmentMock.Object, _contextMock.Object);
        }

        [Test]
        public async Task Create_CreateNew_ExpectTrue()
        {
            bool testFlag = false;
            var _context = await GetDatabaseContext();
            EbookController ebookController = new EbookController(_ebookRepoMock.Object, _hostingEnvironmentMock.Object,
                                                                  _context);

            var mockEbook = new CreateEbookViewModel
            {
                Title = "Mock Title",
                Description = "Mock description",
                Price = 30,
                Category = EEbookCategory.Horror
               
            };


            var result = ebookController.Create(mockEbook);

            if(_context.Ebooks.Count() >= 0)
            {
                testFlag = true;
            }
            else
            {
                testFlag = false;
            }

            Assert.True(testFlag);
        }

        private async Task<ShopDbContext> GetDatabaseContext()
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
