using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC_Authentication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public string Secured()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Application code executed using ");
            stringBuilder.Append(System.Security.Principal.WindowsIdentity.GetCurrent().Name + "<br/>");
            stringBuilder.Append("Is User Authenticated: ");
            stringBuilder.Append(User.Identity.IsAuthenticated.ToString() + "<br/>");
            stringBuilder.Append("Authentication Type, if Authenticated: ");
            stringBuilder.Append(User.Identity.AuthenticationType + "<br/>");
            stringBuilder.Append("User Name, if Authenticated: ");
            stringBuilder.Append(User.Identity.Name + "<br/>");

            return stringBuilder.ToString();
        }
    }
}