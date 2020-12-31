using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenHouse_Management.Models;
using GreenHouse_Management.Models.ViewModels;

namespace GreenHouse_Management.Controllers
{
    [AllowAnonymous]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();

        [NonAction]
        public IEnumerable<SelectListItem> GetAllCustomers()
        {
            var selectList = new List<SelectListItem>();

            foreach (var customer in ctx.Customers.ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = customer.CustomerId.ToString(),
                    Text = customer.Name
                });
            }

            return selectList;
        }

        // GET: /Products or /Products/Index
        public ActionResult Index()
        {
            List<Product> products = ctx.Products.ToList();
            List<Customer> customers = ctx.Customers.ToList();

            ProductsCustomersViewModel pc = new ProductsCustomersViewModel
            {
                ProductsList = products,
                CustomersList = customers
            };

            return View(pc);
        }

        // GET: /Products/Add
        public ActionResult Add()
        {
            ProductCustomersViewModel pc = new ProductCustomersViewModel
            {
                Product = new Product(),
                CustomersList = GetAllCustomers()
            };

            return View(pc);
        }

        // POST: /Products/Create
        [HttpPost]
        public ActionResult Create(ProductCustomersViewModel pc)
        {

            // verifica daca s-a realizat corect fenomenul de MODEL BINDING
            // - daca nu s-au incalcat in timpul procesului de binding reguli de validare 
            if (ModelState.IsValid)
            {
                Product p = new Product(pc.Product);

                // generate ProductKey using ProductId and CustomerId and a random alphabetical character
                Random rnd = new Random();
                char randomChar = (char)rnd.Next('a', 'z');
                string key = randomChar + p.ProductId.ToString() + "-" + p.CustomerId.ToString();
                p.ProductKey = key;

                ctx.Products.Add(p);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Add", pc);
        }

        // GET: /Products/Details/id
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Product product = ctx.Products.Find(id);
                if (product == null)
                {
                    return HttpNotFound("Couldn't find the product with id " + id.ToString());
                }
                return View(product);
            }
            return HttpNotFound("Missing product id parameter!");
        }

        // GET: /Products/Edit/id
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Product product = ctx.Products.Find(id);
                if (product == null)
                {
                    return HttpNotFound("Couldn't find the product with id " + id.ToString());
                }
                return View(product);
            }
            return HttpNotFound("Missing product id parameter!");
        }

        // PUT: /Products/Update
        [HttpPut]
        public ActionResult Update(Product p)
        {
            if (ModelState.IsValid)
            {
                Product product = ctx.Products.Single(a => a.ProductId == p.ProductId);
                if (TryUpdateModel(product))
                {
                    product.Name = p.Name;
                    product.Status = p.Status;
                    ctx.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View("Edit", p);
        }

        // DELETE: /Products/Delete/id
        [HttpDelete]
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                Product product = ctx.Products.Find(id);
                if (product != null)
                {
                    ctx.Products.Remove(product);
                    ctx.SaveChanges();
                    return RedirectToAction("Index");
                }
                return HttpNotFound("Couldn't find the product with id " + id.ToString());
            }
            return HttpNotFound("Missing product id parameter!");
        }
    }
}