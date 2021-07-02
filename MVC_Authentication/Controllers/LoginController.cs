using MVC_Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_Authentication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            ViewBag.IsInvalidCredentials = false;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginUser loginUser, string ReturnUrl)
        {
            if(ModelState.IsValid)
            {
                if (IsValidUser(loginUser))
                {
                    if (ReturnUrl == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(ReturnUrl);
                    }
                }
                else
                {
                    ViewBag.IsInvalidCredentials = true;
                    return View();
                }
            }
            else
            {
                ViewBag.IsInvalidCredentials = false;
                return View();
            }
        }

        public bool IsValidUser(LoginUser loginUser)
        {
            LoginUser savedUser;
            using (ContextFile contextfile = new ContextFile())
            {
                savedUser = contextfile.loginUsers.Where(o => o.UserName == loginUser.UserName && o.Password == loginUser.Password).FirstOrDefault();
            }
            if (savedUser == null)
            {
                return false;
            }
            else
            {
                FormsAuthentication.SetAuthCookie(savedUser.UserName, false);
                Session["User"] = savedUser.UserName;
                return true;
            }
        }
        public ActionResult Logout()
        {
            Session["user"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }

    }
}