using GoodReads.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoodReads.Controllers
{
    public class HomeController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Index()
        {

            if (Session["auth"] == null)
            {
                Session["auth"] = "no";
                Session["role"] = "no";
            }
            return View();
            
        }

        public ActionResult About()
        {

            if (Session["auth"] == null)
            {
                Session["auth"] = "no";
                Session["role"] = "no";
            }



            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            if (Session["auth"] == null)
            {
                Session["auth"] = "no";
                Session["role"] = "no";
            }
            return View();
        }
    }
}