using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AngularPageController : Controller
    {
        // GET: AngularPage
        public ActionResult Index()
        {
            return new FilePathResult("~/Views/AngularPage/myApp.html", "text/html");
        }
        public ActionResult createAccount()
        {
            return new FilePathResult("~/Views/AngularPage/createAccount.html", "text/html");
        }
        public ActionResult createAirline()
        {
            return new FilePathResult("~/Views/AngularPage/createAirline.html", "text/html");
        }
        public ActionResult createAdmin()
        {
            return new FilePathResult("~/Views/AngularPage/createAdmin.html", "text/html");
        }
        public ActionResult futureFlights()
        {
            return new FilePathResult("~/Views/AngularPage/futureFlights.html", "text/html");
        }
        public ActionResult Login()
        {
            return new FilePathResult("~/Views/React/index.html", "text/html");
        }
    }
}