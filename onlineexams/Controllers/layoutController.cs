using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using onlineexams.Models;

namespace onlineexams.Controllers
{
    public class layoutController : Controller
    {
        onlineexamAPIController ff = new onlineexamAPIController();
        // GET: layout
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult data()
        {
            List<Usercourseassign> qns = ff.Get_user_Requests();

            ViewBag.requests = qns[0].DATEOFAPPROVE;
            return View();
        }
        public ActionResult DashBoard()
        {
            Courselist colst = new Courselist();
            List<Coursereg> crlst = ff.CourseRegistration_data_();
            colst.lst = crlst;
            colst.count = crlst.Count;

            return View(colst);
        }
    }
}