using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using MvcRestaurant.Models;
using System.Web.Mvc;

namespace MvcRestaurant.Filters
{
    public class AuthorizationAttribute : AuthorizeAttribute 
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }

            IPrincipal user = httpContext.User;
            if (user.Identity.IsAuthenticated)
            {
                RestaurantEntities db = new RestaurantEntities();
                Waiter waiter = db.Waiters.SingleOrDefault(w => w.User.UserName == user.Identity.Name);
                if (waiter != null)
                {
                    var roleList = new List<string>();
                    roleList.Add("Waiter");
                    if (waiter.IsCoordinator == true)
                    {
                        roleList.Add("Coordinator");
                    }
                    var principal = new GenericPrincipal(user.Identity, roleList.ToArray());
                    httpContext.User = principal;
                }
    
            }
            return base.AuthorizeCore(httpContext);
        }
        
    }
    public enum Roles
    {
        Waiter,
        Coordinator
    }
}