using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Catalog.Business;
using Catalog.DataAccess;
using CatalogWeb.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace CatalogWeb.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (LoginUser(model.Username, model.Password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,model.Username)
                };
                var userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("List","Product");
            }
            else
            {
                ViewBag.Error = "Username or password is wrong...";
                return View();
            }
            
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }



        public IActionResult Register() 
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username,string password)
        {
            var dataService = new UserService();
            try
            {
                dataService.Register(username, password);
                
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return RedirectToAction("Login");
        }


        private bool LoginUser(string username, string password)
        {
            var dataService = new UserService();
            if (dataService.Login(username, password))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}