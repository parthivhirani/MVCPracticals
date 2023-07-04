using MVCPractical15_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCPractical15_2.Controllers
{
    public class AccountsController : Controller
    {
        public ActionResult Login(UserModel user)
        {
            using (var context = new FormAuthenticationDBContext())
            {
                bool IsValidUser = context.Users.Any(u => u.UserName.ToLower() == user.UserName.ToLower() &&
                    u.UserPassword == user.UserPassword);

                if(IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("Index", "Employees");
                }
                ModelState.AddModelError("", "Invalid User!");
                return View();
            }   
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User user)
        {
            if(ModelState.IsValid)
            {
                using (var context = new FormAuthenticationDBContext())
                {
                    bool IsValidUser = context.Users.Any(u => u.UserName.ToLower() == user.UserName.ToLower() &&
                    u.UserPassword == user.UserPassword);
                    if (IsValidUser)
                    {
                        context.Users.Add(user);
                        context.SaveChanges();
                        return RedirectToAction("Login");
                    }
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}