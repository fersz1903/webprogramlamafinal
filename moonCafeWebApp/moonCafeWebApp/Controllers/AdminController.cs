using Microsoft.AspNetCore.Mvc;
using ServicePrj.Classes;

namespace moonCafeWebApp.Controllers
{
    public class AdminController : Base
    {
        public IActionResult SiparisPanel()
        {
            // giriş yapılan sessionu alır.
            //var session = HttpContext.Session.GetString("UserSession");
            //ViewBag.Session = session;
            //DatabaseWorks db = new DatabaseWorks();
            //var siparisler = db.siparisListele();
            var orders = DatabaseService.listOrder();
            return View(orders);
        }

        [HttpPost]
        public IActionResult SiparisSil(int orderId)
        {
            //DatabaseWorks db = new DatabaseWorks();
            //bool kontrol = db.siparisSil(siparisId);
            DatabaseService.deleteOrder(orderId);
            return RedirectToAction("SiparisPanel", "Admin");
        }

        public IActionResult menuPanel(int categoryId)
        {
            var menu = DatabaseService.listMenu(categoryId);
            return View(menu);
        }

        [HttpPost]
        public IActionResult menuEditPanel(int menuId)
        {
            var menuWithCategories = DatabaseService.getMenuWithCategories(menuId);
            return View(menuWithCategories);
        }

        [HttpPost]
        public IActionResult menuEkle(IFormFile file, int categoryId, string Name, decimal Price)
        {
            var imagePath = "../images/" + DatabaseService.uploadImage(file);
            DatabaseService.addMenu(categoryId, Name, Price, imagePath);
            return RedirectToAction("menuPanel", "Admin", new { categoryId });
        }


        [HttpPost]
        public IActionResult menuSil(int menuId)
        {
            var id = DatabaseService.getCategoryIdByMenuId(menuId);
            DatabaseService.deleteMenu(menuId);
            return RedirectToAction("menuPanel", "Admin", new { categoryId = id });
        }

        [HttpPost]
        public IActionResult menuDuzenle(IFormFile file, int categoryId, int menuId, string Name, decimal Price)
        {
            if (file != null)
            {
                var imagePath = "../images/" + DatabaseService.uploadImage(file);
                DatabaseService.updateMenu(categoryId, menuId, Name, Price, imagePath);
            }
            else
            {
                DatabaseService.updateMenu(categoryId, menuId, Name, Price);
            }
            return RedirectToAction("menuPanel", "Admin", new { categoryId });
        }


        public IActionResult categoryPanel()
        {
            var categories = DatabaseService.listCategories();
            return View(categories);
        }

        [HttpPost]
        public IActionResult categoryEditPanel(int categoryId)
        {
            var category = DatabaseService.getCategory(categoryId);
            return View(category);
        }

        [HttpPost]
        public IActionResult categoriSil(int categoryId)
        {
            DatabaseService.deleteCategory(categoryId);
            return RedirectToAction("categoryPanel", "Admin");
        }

        [HttpPost]
        public IActionResult kategoriEkle(IFormFile file, string Name)
        {
            var imagePath = "../images/" + DatabaseService.uploadImage(file);
            DatabaseService.addCategory(Name, imagePath);
            return RedirectToAction("categoryPanel", "Admin");
        }

        public IActionResult categoryAddPanel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult kategoriDuzenle(IFormFile file, int categoryId, string Name)
        {
            if (file != null)
            {
                var imagePath = "../images/" + DatabaseService.uploadImage(file);
                DatabaseService.updateCategory(categoryId, Name, imagePath);
            }
            else
            {
                // update sırasında foto eklenmezse çalışacak
                DatabaseService.updateCategory(categoryId, Name);
            }
            return RedirectToAction("categoryPanel", "Admin");
        }


        public IActionResult menuAddPanel()
        {
            var categories = DatabaseService.listCategories();
            return View(categories);
        }

        public IActionResult songPanel()
        {
            var songs = DatabaseService.listSongs();
            return View(songs);
        }

        [HttpPost]
        public IActionResult SarkiSil(int songId)
        {
            DatabaseService.deleteSong(songId);
            return RedirectToAction("songPanel", "Admin");
        }
    }
}
