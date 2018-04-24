using AplikacjaWebowa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AplikacjaWebowa.ViewModels;

namespace AplikacjaWebowa.Controllers
{
    public class HomeController : Controller
    {


        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            var users = _context.Users.ToList();

            var model = new NewUserViewModel {users = _context.Users.ToList()};
            return View(model);
        }

        public ActionResult Register()
        {
            var users = _context.Users.ToList();
            var model = new NewUserViewModel { users = _context.Users.ToList() };

            return View(model);
        }

        [HttpPost]
        public ActionResult Save(User user)
        {
            user.Birthday = DateTime.Now;
            if (!_context.Users.Any(u=>u.Email==user.Email))
            {

                _context.Users.Add(user);
            }
            else
            {
                return Content("Taki uzytkownik juz istnieje");
            }

            _context.SaveChanges();

            //return Content("Pomyślne logowanie");
            return RedirectToAction("List", "Recipes");
        }

    }
}