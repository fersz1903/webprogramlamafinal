using Microsoft.AspNetCore.Mvc;
using ServicePrj.Models;

namespace moonCafeWebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
                return RedirectToAction("SiparisPanel", "Admin");
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            Authentication auth = new Authentication();
            if (auth.loginControl(username, password))
            {
                // session işlemi
                HttpContext.Session.SetString("UserSession", username);
                // UserSession key adı. get ile burdan üretilen stringi alabiliriz.
                return RedirectToAction("SiparisPanel", "Admin");
            }
            ViewBag.Mesaj = auth.LoginErrorMessage;
            return View();
        }

        public IActionResult deleteSession()
        {
            HttpContext.Session.Remove("UserSession");
            return RedirectToAction("Login", "Login");
        }
    }
}
