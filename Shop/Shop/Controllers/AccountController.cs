﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Models.ApplicationUser;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };



                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var emailEnd = user.NormalizedEmail.Split('@').Last();
                    if (emailEnd == "ADMIN.COM")
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");

                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                    }
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl)
        {
            LoginViewModel model = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }


                ModelState.AddModelError(String.Empty, "Invalid Login Attempt");

            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Profile()
        {

            var user = _userManager.Users;

            return View(user);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account",
                                            new
                                            {
                                                ReturnUrl = returnUrl
                                            });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return new ChallengeResult(provider, properties);
        }

        [AllowAnonymous]
        public async  Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            LoginViewModel loginViewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            if(remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                return View("Login", loginViewModel);
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();

            if(info == null)
            {
                ModelState.AddModelError(string.Empty, "Error loading external login information.");
                return View("Login", loginViewModel);
            }

            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey,
                                                                             isPersistent: false, bypassTwoFactor: true);


            if (signInResult.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }

            var email = info.Principal.FindFirstValue(ClaimTypes.Email);

            if(email != null)
            {
                var user = await _userManager.FindByEmailAsync(email);

                if(user == null)
                {
                    user = new ApplicationUser
                    {
                        UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                        Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                    };
                    await _userManager.CreateAsync(user);
                }

                await _userManager.AddLoginAsync(user, info);
                await _signInManager.SignInAsync(user, isPersistent: false);

                return LocalRedirect(returnUrl);
            }
            ViewBag.ErrorTitle = $"Email claim not received from {info.LoginProvider}";
            ViewBag.ErrorMessage = "Please contact with support";

            return View("Error");
        }
    }
}
