using Microsoft.AspNetCore.Http;
using ServicePrj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePrj.Classes
{
    public class DatabaseService
    {
        public static List<CmOrder> listOrder()
        {
            using (var context = new MooncafedbContext())
            {
                var orders = context.CmOrders.ToList();
                return orders;
            }
        }

        public static List<CmCategory> listCategory()
        {
            using (var context = new MooncafedbContext())
            {
                var categories = context.CmCategories.ToList();
                return categories;
            }
        }

        public static List<CmSong> listSongs()
        {
            using (var context = new MooncafedbContext())
            {
                var songs = context.CmSongs.ToList();
                return songs;
            }
        }


        public static void deleteOrder(int id)
        {
            // select işlemi ile silme
            using (var context = new MooncafedbContext())
            {
                var o = context.CmOrders.FirstOrDefault(i => i.Id == id); // koşulu içeriye yazabiliriz.
                if (o != null)
                {
                    context.CmOrders.Remove(o); // siparişi siler
                    context.SaveChanges();
                    System.Console.WriteLine("Veri silindi");
                }
            }
        }

        public static void deleteMenu(int id)
        {
            // select işlemi ile silme
            using (var context = new MooncafedbContext())
            {
                var m = context.CmMenus.FirstOrDefault(i => i.Id == id);
                if (m != null)
                {
                    context.CmMenus.Remove(m);
                    context.SaveChanges();
                    System.Console.WriteLine("Veri silindi");
                }
            }
        }

        public static void deleteCategory(int id)
        {
            // select işlemi ile silme
            using (var context = new MooncafedbContext())
            {
                var c = context.CmCategories.FirstOrDefault(i => i.Id == id);
                if (c != null)
                {
                    context.CmCategories.Remove(c);
                    var m = context.CmMenus.Where(j => j.CategoryId == id).ToList(); // silinen kategorideki menüleri de siler
                    if (m != null)
                    {
                        context.CmMenus.RemoveRange(m);
                    }
                    context.SaveChanges();
                    System.Console.WriteLine("Veri silindi");
                }
            }
        }

        public static void deleteSong(int id)
        {
            // select işlemi ile silme
            using (var context = new MooncafedbContext())
            {
                var s = context.CmSongs.FirstOrDefault(i => i.Id == id);
                if (s != null)
                {
                    context.CmSongs.Remove(s);
                    context.SaveChanges();
                    System.Console.WriteLine("Veri silindi");
                }
            }
        }



        public static List<CmMenu> listMenu(int categroyId)
        {
            using (var context = new MooncafedbContext())
            {
                var menus = context.CmMenus.Where(i => i.CategoryId == categroyId).ToList();
                return menus;
            }
        }

        public static List<CmCategory> listCategories()
        {
            using (var context = new MooncafedbContext())
            {
                var categories = context.CmCategories.ToList();
                return categories;
            }
        }

        public static CmCategory getCategory(int id)
        {
            using (var context = new MooncafedbContext())
            {
                var category = context.CmCategories.Where(c => c.Id == id).FirstOrDefault();
                return category;
            }
        }

        public static List<CmCategory> getCategories()
        {
            using (var context = new MooncafedbContext())
            {
                var categories = context.CmCategories.ToList();
                return categories;
            }
        }

        public static CmMenu getMenu(int id)
        {
            using (var context = new MooncafedbContext())
            {
                var menu = context.CmMenus.Where(m => m.Id == id).FirstOrDefault();
                return menu;
            }
        }
        public static int getCategoryIdByMenuId(int menuId)
        {
            using (var context = new MooncafedbContext())
            {
                var menu = context.CmMenus.Where(m => m.Id == menuId).FirstOrDefault();
                return menu.CategoryId;
            }
        }


        public static List<CmMenu> getMenusByCategoryId(int id)
        {
            using (var context = new MooncafedbContext())
            {
                var menus = context.CmMenus.Where(m => m.CategoryId == id).ToList();
                return menus;
            }
        }


        public static ViewModels.MenuViewModel getMenuWithCategories(int id)
        {
            using (var context = new MooncafedbContext())
            {
                var menu = getMenu(id);
                var categories = context.CmCategories.ToList();
                var menuWithCategories = new ViewModels.MenuViewModel { Categories = categories, Menu = menu };
                return menuWithCategories;
            }
        }

        public static ViewModels.MenuDetailViewModel getMenusWithCategories(int categoryId)
        {
            using (var context = new MooncafedbContext())
            {
                var menus = getMenusByCategoryId(categoryId);
                var categories = context.CmCategories.ToList();
                var menusWithCategories = new ViewModels.MenuDetailViewModel { Categories = categories, Menus = menus };
                return menusWithCategories;
            }
        }


        public static void addCategory(string ctgryName, string path)
        {
            using (var context = new MooncafedbContext())
            {
                var category = new CmCategory { Name = ctgryName, ImagePath = path };
                context.CmCategories.Add(category);
                context.SaveChanges();
                System.Console.WriteLine("Veriler Eklendi");
            }
        }

        public static void addMenu(int ctgryId, string menuName, decimal price, string path)
        {
            using (var context = new MooncafedbContext())
            {
                var menu = new CmMenu { CategoryId = ctgryId, Name = menuName, Price = price, ImagePath = path };
                context.CmMenus.Add(menu);
                context.SaveChanges();
                System.Console.WriteLine("Veriler Eklendi");
            }
        }

        public static void addOrder(int tableNo, string oText)
        {
            using (var context = new MooncafedbContext())
            {
                var o = new CmOrder { TableNo = tableNo, Name = oText };
                context.CmOrders.Add(o);
                context.SaveChanges();
                System.Console.WriteLine("Veriler Eklendi");
            }
        }

        public static void addSongRequest(int tableNo, string songText)
        {
            using (var context = new MooncafedbContext())
            {
                var song = new CmSong { TableNo = tableNo, SongName = songText };
                context.CmSongs.Add(song);
                context.SaveChanges();
                System.Console.WriteLine("Veriler Eklendi");
            }
        }


        public static void updateMenu(int ctgryId, int menuId, string menuName, decimal price, string path)
        {
            using (var context = new MooncafedbContext())
            {
                var menu = getMenu(menuId);
                context.CmMenus.Attach(menu);
                menu.CategoryId = ctgryId;
                menu.Name = menuName;
                menu.Price = price;
                menu.ImagePath = path;
                context.SaveChanges();
                System.Console.WriteLine("Veriler Guncellendi");
            }
        }

        // update without image
        public static void updateMenu(int ctgryId, int menuId, string menuName, decimal price)
        {
            using (var context = new MooncafedbContext())
            {
                var menu = getMenu(menuId);
                context.CmMenus.Attach(menu);
                menu.CategoryId = ctgryId;
                menu.Name = menuName;
                menu.Price = price;
                context.SaveChanges();
                System.Console.WriteLine("Veriler Guncellendi");
            }
        }


        public static void updateCategory(int ctgryId, string ctgryName, string path)
        {
            using (var context = new MooncafedbContext())
            {
                var category = getCategory(ctgryId);
                context.CmCategories.Attach(category);
                category.Id = ctgryId;
                category.Name = ctgryName;
                category.ImagePath = path;
                context.SaveChanges();
                System.Console.WriteLine("Veriler Guncellendi");
            }
        }

        // fotoğraf almadan update
        public static void updateCategory(int ctgryId, string ctgryName)
        {
            using (var context = new MooncafedbContext())
            {
                var category = getCategory(ctgryId);
                context.CmCategories.Attach(category);
                category.Id = ctgryId;
                category.Name = ctgryName;
                context.SaveChanges();
                System.Console.WriteLine("Veriler Guncellendi");
            }
        }

        public static string uploadImage(IFormFile file)
        {
            var localImageDir = $"wwwroot/images";
            var localImagePath = $"{localImageDir}/{file.FileName}";

            if (!Directory.Exists(Path.Combine(localImageDir)))
            {
                Directory.CreateDirectory(Path.Combine(localImageDir));
            }

            using (Stream fileStream = new FileStream(localImagePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            //string modelsImagePath = Path.GetFileNameWithoutExtension(file.FileName).ToString();
            string modelsImagePath = Path.GetFileName(file.FileName).ToString();
            return modelsImagePath;
        }
    }
}
