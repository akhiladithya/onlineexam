using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using onlineexams.Models;
using onlineexams.Controllers;


namespace onlineexams.Controllers
{
    public class onlineExamUIController : Controller
    {
        // GET: onlineExamUI
        onlineexamAPIController ff = new onlineexamAPIController();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public JsonResult createUserpost(Userregistration create)
        {
            Userregistration ddd = ff.Create_user_(create);

            return Json(ddd, JsonRequestBehavior.AllowGet);
        }
        public JsonResult user(string userid)
        {
            Session["userid"] = userid;
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getuser()
        {
            Userregistration ddd = new Userregistration();

                            
            ddd.FIRSTNAME = Session["userid"].ToString();
            //ddd.FIRSTNAME = "1034";

            return View(ddd);
        }
        public ActionResult forgotpassword()
        {
            return View();
        }
        public JsonResult forgot(Forgetpassword pwd)
        {
            string dd = ff.Forgetpassword_(pwd);
            return Json(dd, JsonRequestBehavior.AllowGet);
            
        }
        [HttpGet]
        public ActionResult CourseRegistration()
        {
            Courselist colst = new Courselist();

           List<Coursereg> crlst= ff.CourseRegistration_data_();
            colst.lst = crlst;
            colst.count = crlst.Count;
            return View(colst);

        }
        [HttpPost]
        public Outputclass coursepost(Coursereg cur)
        {
            Outputclass op = new Outputclass();
            op= ff.Create_Course_(cur);
            return op;

        }
        public JsonResult setcoursid(string cid)
        {

            Session["CID"] = cid;
            
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpadateCourse()
        {
            List<Coursereg> crlst = ff.CourseRegistration_data_();
            Coursereg dd = new Coursereg();
            dd.Courseid = Convert.ToInt32(Session["CID"].ToString());
            dd = crlst.Where(a => a.Courseid == dd.Courseid).FirstOrDefault();
            return View(dd);
        }

        [HttpPost]
        public ActionResult Updatecoursereg(Coursereg reg)
        {
            Outputclass op = ff.Update_Course_(reg);   

            return View();
        }
        
        public ActionResult GetusersList()
        {
            Userslist lst1 = new Userslist();
            lst1.lst = ff.UserRegistration_data_();
            lst1.count = lst1.lst.Count;
            return View(lst1);
        }

        public string getip()//No use
        {
            string ip = "";
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string IPAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(IPAddress))
            {
                string[] addresses = IPAddress.Split(',');
                if (addresses.Length != 0)
                {
                    ViewData["data"] = addresses[0];
                    ip = addresses[0];
                }

            }
            ViewData["data11"] = context.Request.ServerVariables["REMOTE_ADDR"];
            // ip="10.10.10.65";
            // return ip;
            return ViewData["data11"].ToString();
        }
    }
}