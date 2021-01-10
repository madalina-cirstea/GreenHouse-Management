using GreenHouse_Management.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenHouse_Management.Controllers
{
    public class GreenhousesController : Controller
    {
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();

        // GET: Greenhouses
        // get greenhouse for current user
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();

            Greenhouse greenhouse = ctx.Greenhouses.FirstOrDefault(g => g.User.Id.Equals(userId));            

            if (greenhouse == null)
            {
                return RedirectToAction("Register");
            }

            return View(greenhouse);
        }

        // GET: Greenhouses/Register
        // register greenhouse for current user
        public ActionResult Register()
        {
            Greenhouse greenhouse = new Greenhouse();
            return View(greenhouse);
        }

        // POST: /Greenhouses/Register
        [HttpPost]
        public ActionResult Register(Greenhouse greenhouse)
        {
            try
            {
                string userId = User.Identity.GetUserId();
                ApplicationUser user = ctx.Users.Find(userId);
                greenhouse.User = user;
                greenhouse.ProductKey = ctx.RegisteredUsers.FirstOrDefault(u => u.Email.Equals(user.Email)).RegistrationCode;
                greenhouse.RegistrationDate = DateTime.Now;

                //if (ModelState.IsValid)
                //{
                    ctx.Greenhouses.Add(greenhouse);
                    ctx.SaveChanges();
                    return RedirectToAction("Index");
                //}
                //return View("Register", greenhouse);
            }
            catch (Exception e)
            {
                return View("Register", greenhouse);
            }
        }
    }
}