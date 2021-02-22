using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ReactController : Controller
    {
        // GET: React
        public ActionResult Index()
        {
            return new FilePathResult("~/Views/React/index.html", "text/html");
        }

    }
}      