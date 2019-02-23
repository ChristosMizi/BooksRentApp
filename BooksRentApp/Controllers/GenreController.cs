using BooksRentApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BooksRentApp.Controllers
{
    public class GenreController : Controller
    {
        //1. we should create a DBContext Appliation obj, that is the obj through which we will be conecting to the db
        //and accessing the Genre table


        private ApplicationDbContext db;

        // initialize the obj

        public GenreController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Genre
        public ActionResult Index()
        {
            return View(db.Genres.ToList());
        }
        //it's just creating a new Genre, so i don't have to pass anything to the view
        //then i create the view for this action
        //This is a Get Action
        public ActionResult Create()
        {

            return View();
        }

        //Post Action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Genres.Add(genre);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Genre genre = db.Genres.Find(id);
            if (genre==null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (Genre genre)
        {
            if (ModelState.IsValid)
            {
                // Update only specific columns 
                /*
                 var GenreInDb =db.Genres.FirstOrDefault(g=>g.Id.Equals(genre.Id));
                 GenreInDb.Name = genre.Name;
                 */
                db.Entry(genre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {

                Genre genre = db.Genres.Find(id);
                db.Genres.Remove(genre);
                db.SaveChanges();
               
                
                return RedirectToAction("Index");
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();

        }
    }
}