using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoodReads.Models;

namespace GoodReads.Controllers
{
    public class UsersController : Controller
    {
        private Model1 db = new Model1();

        // GET: Users
        public ActionResult Index()
        {
            return View();
         
        }
        
        public ActionResult Edit()
        {
            if (Session["auth"] == null || Session["auth"].Equals("no"))
            {
                return RedirectToAction("Login", "Users");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(string password)
        {
            if (password != null)
            {
                Users user = db.Users.Find(Session["auth"]);
                if (user != null)
                {
                    user.Password = password;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                }
                
            }
            return RedirectToAction("Index", "Users");
        }

       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            string uname = username;
            string pass = password;
            var users = from u in db.Users
                        select u;
            var check = users.Where(data => data.Username.Equals(uname)).FirstOrDefault();
            if(check == null)
                return RedirectToAction("Login", "Users");
            if (!check.Password.Equals(password))
            {
                return Redirect("/Users/Login");
            }
            else
            {
                Session["auth"] = username;
                Session["role"] = check.Role;
                return Redirect("/Users/Index");
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string username, string password)
        {
            Session["auth"] = "no";
            Session["role"] = "no";
            try
            {
                var check = db.Users.Where(data => data.Username.Equals(username)).First();
            }
            catch (SystemException e)
            {
                Users newuser = new Users { Username = username, Password = password, Role = "reader" };
                db.Users.Add(newuser);
                db.SaveChanges();
                Session["auth"] = username;
                Session["role"] = newuser.Role;
                return RedirectToAction("Index", "Users");              
            }
            ViewBag.Display = "This username is already taken. Try something else";
            return RedirectToAction("Register", "Users");
        }
        public ActionResult Logout()
        {
            Session["auth"] = "no";
            Session["role"] = "no";
            return RedirectToAction("Login", "Users");
        }
    }
}
