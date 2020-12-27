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