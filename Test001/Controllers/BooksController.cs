using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test001.Models;

namespace Test001.Controllers
{
    public class BooksController : Controller
    {
        Database1Entities db = new Database1Entities();
        // GET: Books
        public ActionResult Index()
        {
            var res = from k in db.Books
                      select k;
            return View(res.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            var res = from k in db.Books
                      where k.BookId == id
                      select k;
            Book t = (Book)res.FirstOrDefault();
            return View(t);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            Book e1 = new Book();
            return View(e1);
        }

        // POST: Books/Create
        [HttpPost]
        public ActionResult Create(Book e1)
        {
            try
            {
                db.Books.Add(e1);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            var res = from k in db.Books
                      where k.BookId == id
                      select k;
            Book t = (Book)res.FirstOrDefault();
            return View(t);
        }

        // POST: Books/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Book t)
        {
            try
            {
                var res = from k in db.Books
                          where k.BookId == id
                          select k;
                Book b = (Book)res.FirstOrDefault();
                b.Title = t.Title;
                b.Author = t.Author;
                b.ISBN = t.ISBN;
                b.Publisher = t.Publisher;
                b.Year = t.Year;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            var res = from k in db.Books
                      where k.BookId == id
                      select k;
            Book t = (Book)res.FirstOrDefault();
            return View(t);
        }

        // POST: Books/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Book t)
        {
            try
            {
                var res = from k in db.Books
                          where k.BookId == id
                          select k;
                Book b = (Book)res.FirstOrDefault();
                db.Books.Remove(b);
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
