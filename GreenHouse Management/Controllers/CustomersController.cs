using GreenHouse_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenHouse_Management.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();

        // GET: /Customers or /Customers/Index
        public ActionResult Index()
        {
            List<Customer> customers = ctx.Customers.ToList();
            return View(customers);
        }

        // GET: /Customers/Add
        public ActionResult Add()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        // POST: /Customers/Create
        [HttpPost]
        public ActionResult Create(Customer c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ctx.Customers.Add(c);
                    ctx.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View("Add", c);
            }
            catch (Exception e)
            {
                return View("Add", c);
            }
        }

        // GET: /Customers/Details/id
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Customer customer = ctx.Customers.Find(id);
                if (customer == null)
                {
                    return HttpNotFound("Couldn't find the customer with id " + id.ToString());
                }
                return View(customer);
            }
            return HttpNotFound("Missing customer id parameter!");
        }

        // GET: /Customers/Edit/id
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Customer customer = ctx.Customers.Find(id);
                if (customer == null)
                {
                    return HttpNotFound("Couldn't find the customer with id " + id.ToString());
                }
                return View(customer);
            }
            return HttpNotFound("Missing customer id parameter!");
        }

        // PUT: /Customers/Update
        [HttpPut]
        public ActionResult Update(Customer c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Customer customer = ctx.Customers.Single(a => a.CustomerId == c.CustomerId);
                    if (TryUpdateModel(customer))
                    {
                        customer.Name = c.Name;
                        customer.Email = c.Email;
                        customer.PhoneNumber = c.PhoneNumber;
                        customer.Address = c.Address;
                        ctx.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View("Edit", c);
            }
            catch (Exception e)
            {
                return View("Edit", c);
            }
        }

        // DELETE: /Customers/Delete/id
        [HttpDelete]
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                Customer customer = ctx.Customers.Find(id);
                if (customer != null)
                {
                    ctx.Customers.Remove(customer);
                    ctx.SaveChanges();
                    return RedirectToAction("Index");
                }
                return HttpNotFound("Couldn't find the customer with id " + id.ToString());
            }
            return HttpNotFound("Missing customer id parameter!");
        }
    }
}