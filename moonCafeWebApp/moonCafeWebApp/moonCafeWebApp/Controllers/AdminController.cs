using Microsoft.AspNetCore.Mvc;

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
            var orders = DatabaseWorks.listOrder();
            return View(orders);
        }

        [HttpPost]
        public IActionResult SiparisSil(int orderId)
        {
            //DatabaseWorks db = new DatabaseWorks();
            //bool kontrol = db.siparisSil(siparisId);
            DatabaseWorks.deleteOrder(orderId);
            return RedirectToAction("SiparisPanel", "Admin");
        }

        public IActionResult menuPanel(int categoryId)
        {
            var menu = DatabaseWorks.listMenu(categoryId);
            return View(menu);
        }

        [HttpPost]
        public IActionResult menuEditPanel(int menuId)
        {
            var menuWithCategories = DatabaseWorks.getMenuWithCategories(menuId);
            return View(menuWithCategories);
        }

        [HttpPost]
        public IActionResult menuEkle(IFormFile file, int categoryId, string Name, decimal Price)
        {
            var imagePath = "../images/" + DatabaseWorks.uploadImage(file);
            DatabaseWorks.addMenu(categoryId, Name, Price, imagePath);
            return RedirectToAction("menuPanel", "Admin", new { categoryId });
        }


        [HttpPost]
        public IActionResult menuSil(int menuId)
        {
            var id = DatabaseWorks.getCategoryIdByMenuId(menuId);
            DatabaseWorks.deleteMenu(menuId);
            return RedirectToAction("menuPanel", "Admin", new { categoryId = id });
        }

        [HttpPost]
        public IActionResult menuDuzenle(IFormFile file, int categoryId, int menuId, string Name, decimal Price)
        {
            if (file != null)
            {
                var imagePath = "../images/" + DatabaseWorks.uploadImage(file);
                DatabaseWorks.updateMenu(categoryId, menuId, Name, Price, imagePath);
            }
            else
            {
                DatabaseWorks.updateMenu(categoryId, menuId, Name, Price);
            }
            return RedirectToAction("menuPanel", "Admin", new { categoryId });
        }


        public IActionResult categoryPanel()
        {
            var categories = DatabaseWorks.listCategories();
            return View(categories);
        }

        [HttpPost]
        public IActionResult categoryEditPanel(int categoryId)
        {
            var category = DatabaseWorks.getCategory(categoryId);
            return View(category);
        }

        [HttpPost]
        public IActionResult categoriSil(int categoryId)
        {
            DatabaseWorks.deleteCategory(categoryId);
            return RedirectToAction("categoryPanel", "Admin");
        }

        [HttpPost]
        public IActionResult kategoriEkle(IFormFile file, string Name)
        {
            var imagePath = "../images/" + DatabaseWorks.uploadImage(file);
            DatabaseWorks.addCategory(Name, imagePath);
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
                var imagePath = "../images/" + DatabaseWorks.uploadImage(file);
                DatabaseWorks.updateCategory(categoryId, Name, imagePath);
            }
            else
            {
                // update sırasında foto eklenmezse çalışacak
                DatabaseWorks.updateCategory(categoryId, Name);
            }
            return RedirectToAction("categoryPanel", "Admin");
        }


        public IActionResult menuAddPanel()
        {
            var categories = DatabaseWorks.listCategories();
            return View(categories);
        }

        public IActionResult songPanel()
        {
            var songs = DatabaseWorks.listSongs();
            return View(songs);
        }

        [HttpPost]
        public IActionResult SarkiSil(int songId)
        {
            DatabaseWorks.deleteSong(songId);
            return RedirectToAction("songPanel", "Admin");
        }
    }
}
