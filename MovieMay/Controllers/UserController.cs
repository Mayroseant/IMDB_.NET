using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MovieMay.Models;
using MovieMayDL;
using MovieMayDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieMay.Controllers
{
    public class UserController : Controller
    {
        //Data Layer
        public UserDL udl = new UserDL();

        //Login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([Bind] User user)
        {
            //Valid user
            bool res = udl.UserValidate(user);
            if (res == true)
            {
                //Create the identity for the user (cookie)
                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Role, user.UserRole)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Movie");
            }
            else
            {
                TempData["msg"] = "Role/Email/Password wrong!";
                return View();
            }
        }
        //Logout
        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        //Signup
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signup([Bind] User user)
        {
            bool res = udl.UserReg(user);
            if(res == true)
            {
                return RedirectToAction("Login");
            }
            else
            {
                TempData["msg"] = "The email already exists!";
                return View();
            }
        }
    }
}
