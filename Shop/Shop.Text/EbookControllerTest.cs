using Microsoft.AspNetCore.Hosting;
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
    [TestFixture]
    public class EbookControllerTest
    {
        private readonly Mock<IEbookRepository> _ebookRepoMock;
        private readonly Mock<IWebHostEnvironment> _hostingEnvironmentMock;
        private readonly Mock<ShopDbContext> _contextMock;

        private readonly EbookController _controller;
        public EbookControllerTest()
        {
            _ebookRepoMock = new Mock<IEbookRepository>();
            _hostingEnvironmentMock = new Mock<IWebHostEnvironment>();
            _contextMock = new Mock<ShopDbContext>();

            _controller = new EbookController(_ebookRepoMock.Object, _hostingEnvironmentMock.Object, _contextMock.Object);
        }

        [Test]
        public void Create_CreateNew_ExpectTrue()
        {
            bool test = false;
            string message = "";

            var mockEbook = new CreateEbookViewModel
            {
                Title = "Mock Title",
                Description = "Mock description",
                Price = 30,
                Category = EEbookCategory.Horror
               
            };

           _controller.Create(mockEbook);

            var result = _ebookRepoMock.Object.GetAllEbooks.ToList();

            if (result.Count > 0)
            {
                test = true;
                message = "";
            }
            else
            {
                test = false;
                message = "Error ebook does not add";
            }

            Assert.IsTrue(test, message);
        }
    }
}
