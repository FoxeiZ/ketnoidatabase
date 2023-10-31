using KetNoiDatabase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KetNoiDatabase.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        DBSportStoreEntities database = new DBSportStoreEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category cate)
        {
            if (ModelState.IsValid)
            {
                database.Categories.Add(cate);
                database.SaveChanges();
                return RedirectToAction("Index", "Product");
            }

            return View(cate);
        }

        [NotMapped]
        public List<Category> ListCate { get; set; }

        public PartialViewResult CategoryPartial()
        {
            var cateList = database.Categories.ToList();
            return PartialView(cateList);
        }
    }
}