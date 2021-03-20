using Castle.Core.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Shop.Controllers;
using Shop.Models.ApplicationUser;

namespace Shop.Test
{
    public class AccountControllerTest
    {
        private Mock<UserManager<ApplicationUser>> _userManager;
        private Mock<SignInManager<ApplicationUser>> _signInManager;
        private Mock<ILogger<AccountController>> _logger;

        private AccountController _controller;
        [SetUp]
        public void Setup()
        {
            

        }

        


    }
}
