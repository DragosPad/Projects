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
        public ActionResult Login()
        {
            return View();
        }

        //User is the model. and value for returnUrl will be automatically received by this action.
        [HttpPost]
        public ActionResult Login(User u, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(u.UserName, u.passWord))
                {
                    FormsAuthentication.SetAuthCookie(u.UserName, u.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
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
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            //if (ModelState.IsValid)
            //{
            //    string struName = Convert.ToString(u.UserName).ToUpper().Trim();
            //    string strPassword = Convert.ToString(u.passWord).ToUpper().Trim();

            //    //Verify credentials against database in real project
            //    if (struName == "123@123.com".ToUpper() && strPassword == "123".ToUpper())
            //    {
            //        FormsAuthentication.SetAuthCookie(u.UserName.ToUpper(), false);
            //        if (!string.IsNullOrEmpty(returnUrl))
            //        {
            //            return Redirect(returnUrl);
            //        }
            //        else
            //        {
            //            return RedirectToAction("details", "Test");
            //        }
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("authenticationError",
            //"User name or Password is wrong. Try it again");
            //        //lblError.Text = "User name or Password is wrong. Try it again";
            //    }
            //}
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
        public ActionResult Register(Registers model)
        {
            //if (ModelState.IsValid)
            //{
            //    // Attempt to register the user
            //    MembershipCreateStatus createStatus;
            //    Membership.CreateUser(model.UserName, model.Password, model.Email, "question", "answer", true, null, out createStatus);

            //    if (createStatus == MembershipCreateStatus.Success)
            //    {
            //        FormsAuthentication.SetAuthCookie(model.UserName, false /* createPersistentCookie */);
            //        return RedirectToAction("Index", "Home");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", ErrorCodeToString(createStatus));
            //    }
            //}

            // If we got this far, something failed, redisplay form
            return View(model);
        }

    }
}
