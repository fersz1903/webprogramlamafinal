using Microsoft.AspNetCore.Mvc;
using moonCafeWebApp.Models;
using System.Diagnostics;
using ServicePrj.Classes;

namespace moonCafeWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Order()
        {
            return View();
        }

        [HttpPost]
        public IActionResult siparisVer(string orderText, int tableNo)
        {
            DatabaseService.addOrder(tableNo, orderText);
            return RedirectToAction("Order", "Home");
        }
        [HttpPost]
        public IActionResult songRequest(string songName, int tableNo)
        {
            DatabaseService.addSongRequest(tableNo, songName);
            return RedirectToAction("Order", "Home");
        }

        public IActionResult Menu()
        {
            var categories = DatabaseService.getCategories();
            return View(categories);
        }

        public IActionResult MenuDetail(int categoryId)
        {
            var menusWithCategories = DatabaseService.getMenusWithCategories(categoryId);
            return View(menusWithCategories);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}