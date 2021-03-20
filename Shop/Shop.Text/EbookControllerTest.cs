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
        private EbookController ebookController;
        ShopDbContext _context => GetDatabaseContext();


        [SetUp]
        public  void Setup()
        {
            _ebookRepoMock = new Mock<IEbookRepository>();
            _hostingEnvironmentMock = new Mock<IWebHostEnvironment>();

            ebookController = new EbookController(_ebookRepoMock.Object, _hostingEnvironmentMock.Object,
                                                _context);
        }

        [Test]
        public void Create_CreateNewValidModel_ExpectTrue()
        {
            bool testFlag = false;

            var mockEbook = new CreateEbookViewModel
            {
                Title = "Mock Title",
                Description = "Mock description",
                Price = 30,
                Category = EEbookCategory.Horror
               
            };


            ebookController.Create(mockEbook);

            if(_context.Ebooks.Count() > 0)
                testFlag = true;
            else
                testFlag = false;

            Assert.True(testFlag);
        }

        [Test]
        public void Edit_GetModelToEdit_ExpectViewResult()
        {
           
            var result = ebookController.Edit(1);
            
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }

        private ShopDbContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new ShopDbContext(options);
            databaseContext.Database.EnsureCreated();
            
            if(databaseContext.Ebooks.Count() <= 0)
            {
                databaseContext.Add(new Ebook()
                {
                    EbookId = 0,
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
