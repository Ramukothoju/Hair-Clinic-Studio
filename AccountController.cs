using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HairClinic.Models;
namespace HairClinic.Controllers
{
    public class AccountController : Controller
    {
        HairStudioEntities contxt=new HairStudioEntities();
        SqlDal sd = new SqlDal();
        public ActionResult Login()

        {
            return View();
        }

        [HttpPost]
        public ActionResult login(Login model)
        {
            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.UserId, false);
                if (!string.IsNullOrEmpty(model.returnUrl) && Url.IsLocalUrl(model.returnUrl))
                {
                    return Redirect(model.returnUrl);
                }
                return RedirectToAction("clientinfo", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }


        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        // POST: /Account/SignIn
        [HttpPost]
        public ActionResult SignIn(Singin model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                // Check if username and password are valid (you need to implement your own logic here)
                if (ModelState.IsValid)
                {
                    sd.SiginData(model);
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("clientinfo", "Home"); // Redirect to home page on successful sign-in
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }
            return View(model);
        }
    }
}