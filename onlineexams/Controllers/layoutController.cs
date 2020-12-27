using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace onlineexams.Controllers
{
    public class layoutController : Controller
    {
        // GET: layout
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult data()
        {
            return View();
        }
    }
}