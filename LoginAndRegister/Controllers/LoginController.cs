using VersaTechWebApp.Models;
using VersaTechWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VersaTechWebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProcessLogin(Account account)
        {
            SecurityService securityService= new SecurityService();
            if (securityService.IsValid(account))
            {
                return View("LoginSuccess", account);
            }
            else
            {
                return View("LoginFailure", account);
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.userAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + " successfully registered.";
            }
            return View();
        }

    }
}
