using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRestaurant.Models;
using System.Web.Security;

namespace MvcRestaurant.Controllers
{
    public class LoginController : Controller
    {
        private RestaurantEntities dbContext;

        public LoginController()
        {
            dbContext = new RestaurantEntities();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User u, string returnUrl, bool RememberMe)
        {
            
            if (ModelState.IsValid)
            {
                if(dbContext.Users.Any(user => user.UserName == u.UserName && user.passWord == u.passWord))
                {
                    FormsAuthentication.SetAuthCookie(u.UserName.ToUpper(), RememberMe);
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("authenticationError",
            "User name or Password is wrong. Try it again");
                    
                }
            }
            return View(u);
        }

        [Authorize]
        [HttpGet]
        public ActionResult logOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");

        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register register)
        {
            User registerLogin = new User();
            if (ModelState.IsValid)
            {
               
                registerLogin.UserName = register.UserName;
                registerLogin.passWord = register.Password;
                dbContext.Users.Add(registerLogin);
                dbContext.SaveChanges();
            }
            
            return View(register);
        }

    }
}
