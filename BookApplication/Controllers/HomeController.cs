using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookApplication.Models;
using System.Web.Mvc.Html;

namespace BookApplication.Controllers
{
    public class HomeController : Controller
    {
        private BookDB db = new BookDB();
        private const int DefaultPageSize = 3;
        private IList<Book> allProducts = new List<Book>();
        // private readonly string[] categories = new string[3] { "Shoes", "Electronics", "Food" };
        //
        // GET: /Home/

        public ActionResult Index(ListModel listModel, string btnSearch, string sortOrder, string sort, string desc, string isfeedback, int? page)
        {
            //Проверяем, нажата ли кнопка "Поиск"
            if (btnSearch == null)
            {
                ModelState.Clear();
                listModel = (ListModel)TempData["model"];
            }
            else page = 1;
            TempData["model"] = listModel;

            if (listModel == null)
                listModel = new ListModel();
            ViewBag.CurrentSort = desc;

            if (listModel.Name != null && listModel.Name != "")
                listModel.Result = db.Books.Where(x => x.Name.Contains(listModel.Name)).ToList();
            else listModel.Result = db.Books.ToList();

            ViewBag.TotalOrdersCount = listModel.Result.Count;
            return View(listModel);

        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id = 0)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            var AuthorLists = new List<SelectListItem>
                                                          {
                                                              new SelectListItem {Value = "Акунин", Text = "Акунин"},
                                                              new SelectListItem {Value = "Бунин", Text = "Бунин"}, 
                                                              new SelectListItem {Value = "Пушкин", Text = "Пушкин"}

                                                          };
            ViewBag.AuthorList = new SelectList(AuthorLists, "Value", "Text");
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var AuthorLists = new List<SelectListItem>
                                                          {
                                                              new SelectListItem {Value = "Акунин", Text = "Акунин"},
                                                              new SelectListItem {Value = "Бунин", Text = "Бунин"},
                                                               new SelectListItem {Value = "Пушкин", Text = "Пушкин"}

                                                          };
            ViewBag.AuthorList = new SelectList(AuthorLists, "Value", "Text");
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}