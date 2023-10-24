using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KetNoiDatabase.Models;

namespace KetNoiDatabase.Controllers
{
    public class CustomersController : Controller
    {
        private DBSportStoreEntities db = new DBSportStoreEntities();
        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCus,NameCus,PhoneCus,EmailCus")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index", "Product");
            }

            return View(customer);
        }
    }
}
