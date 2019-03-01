using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoodReads.Models;

namespace GoodReads.Controllers
{
    public class BookDetailsController : Controller
    {
        private Model1 db = new Model1();

        // GET: BookDetails
        public ActionResult Index(string searchbook)
        {
            if (Session["auth"] == null || Session["auth"].Equals("no"))
                return RedirectToAction("Login", "Users");

            var books = from b in db.BookDetails
                        select b;
            if (!string.IsNullOrEmpty(searchbook))
            {
                books = books.Where(data => data.BookName.Contains(searchbook));
            }
            ViewBag.Books = books;
            return View();
        }
        public ActionResult Index2(string searchauthor)
        {
            if (Session["auth"] == null || Session["auth"].Equals("no"))
                return RedirectToAction("Login", "Users");
            var books = from b in db.BookDetails
                        select b;
            if (!string.IsNullOrEmpty(searchauthor))
            {
                books = books.Where(data => data.Author.Contains(searchauthor));
            }
            ViewBag.Books = books;
            return View();
        }
        public ActionResult Index3(string searchgenre)
        {
            if (Session["auth"] == null || Session["auth"].Equals("no"))
                return RedirectToAction("Login", "Users");

            var books = from b in db.BookDetails
                        select b;
            if (!string.IsNullOrEmpty(searchgenre))
            {
                books = books.Where(data => data.Genre.Contains(searchgenre));
            }
            ViewBag.Books = books;
            return View();
        }
      

        // GET: BookDetails/Create
        public ActionResult Create()
        {
            if (Session["auth"] == null || Session["auth"].Equals("no"))
                return RedirectToAction("Login", "Users");
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(string BookName, int BookId, string Author, string Genre, HttpPostedFileBase image, HttpPostedFileBase pdf)
        {
            if (Session["auth"] == null || Session["auth"].Equals("no"))
                return RedirectToAction("Login", "Users");
            string p_ext = Path.GetExtension(pdf.FileName);
            string i_ext = Path.GetExtension(image.FileName);
           
            if (!p_ext.Equals(".pdf") || !i_ext.Equals(".jpg"))
            {
                
                return Redirect("/BookDetails/Create");
            }
            string imgname = "/Images/" + Path.GetFileName(image.FileName);
            string pdfname = "/Files/" + Path.GetFileName(pdf.FileName);
            image.SaveAs(@"E:\WDDN\Progs\GoodReads\GoodReads\Images\" + Path.GetFileName(image.FileName));
            pdf.SaveAs(@"E:\WDDN\Progs\GoodReads\GoodReads\Files\" + Path.GetFileName(pdf.FileName));
            BookDetails bd = new BookDetails { BookName = BookName, BookId = BookId, Author = Author, Genre = Genre, Imagepath = imgname, Filepath = pdfname };
            db.BookDetails.Add(bd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        

        // GET: BookDetails/Delete/5
        public ActionResult Delete(string id)
        {
            if (Session["auth"] == null || Session["auth"].Equals("no"))
                return RedirectToAction("Login", "Users");

            if (id == null)
            {
                return RedirectToAction("Index");
            }
            BookDetails bookDetails = db.BookDetails.Where(data => data.BookName.Equals(id)).FirstOrDefault();
            if (bookDetails == null)
            {
                return RedirectToAction("Index");
            }
            return View(bookDetails);
        }

        // POST: BookDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (Session["auth"] == null || Session["auth"].Equals("no"))
                return RedirectToAction("Login", "Users");

            BookDetails bookDetails = db.BookDetails.Find(id);
            if (bookDetails == null)
                return RedirectToAction("Index", "BookDetails");
            db.BookDetails.Remove(bookDetails);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
