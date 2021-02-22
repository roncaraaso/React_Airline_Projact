using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class JSController : Controller
    {
        // GET: JS
        public ActionResult DeleteCustomer()
        {
            return new FilePathResult("~/Views/JS/DeleteCustomer.html", "text/html");
        }
        // GET: JS
        public ActionResult FlightSearch()
        {
            return new FilePathResult("~/Views/JS/FlightSearch.html", "text/html");
        }
        // GET: JS
        public ActionResult ShowCustomer()
        {
            return new FilePathResult("~/Views/JS/ShowCustomer.html", "text/html");
        }
        // GET: JS
        public ActionResult UpdateCustomer()
        {
            return new FilePathResult("~/Views/JS/UpdateCustomer.html", "text/html");
        }
        public ActionResult Landing()
        {
            return new FilePathResult("~/Views/JS/Landing.html", "text/html");
        }
        public ActionResult Departures()
        {
            return new FilePathResult("~/Views/JS/Depureture.html", "text/html");
        }
    }
}