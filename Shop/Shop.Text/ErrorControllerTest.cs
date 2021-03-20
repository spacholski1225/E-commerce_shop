using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Shop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Test
{
    public class ErrorControllerTest
    {
        private ErrorController errorController;
        [SetUp]
        public void Setup()
        {
            errorController = new ErrorController();
        }

        [Test]
        public void NotFound_404Or500Code_ExpectErrorMessage()
        {
            var result = errorController.NotFound(404);

            Assert.That(result, Is.InstanceOf<ViewResult>());
        }
    }
}
