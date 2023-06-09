using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace moonCafeWebApp.Controllers
{
    public class Base : Controller
    {
        public bool IsSessionAlive()
        {
            var session = HttpContext.Session.GetString("UserSession");
            if (session == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (IsSessionAlive() == false)
            {
                TempData["error"] = "Sayfayı görüntülemek için giriş yapmalısınız!";
                context.Result = RedirectToAction("Login", "Login");
            }
        }
    }
}
