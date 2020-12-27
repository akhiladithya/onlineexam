using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using onlineexams.Models;
using onlineexams.Controllers;

namespace onlineexams.Controllers
{
    public class LoginUIController : Controller
    {
        LoginAPIController Log = new LoginAPIController();
        // GET: LoginUI
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult Login(login dd)
        {
            if (dd.Username != null && dd.Password != null)
            {
                List<Userregistration> userreglist = Log.Login_();
                Userregistration userreg = new Userregistration();
                Userregistration userreg1 = new Userregistration();

                var isExist = userreglist.Where(a => a.Userid.ToString() == dd.Username).FirstOrDefault();
                userreg1 = userreglist.Where(a => a.Userid.ToString() == dd.Username).FirstOrDefault();
                Session["uname"] = userreg1; 
                if (isExist!=null)
                {
                    userreg = Log.Logincred_(dd);

                }

                return RedirectToAction("data", "layout");
            }
            else
            {
                ViewBag.Error = "Please Enter Creditials";
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();

            return RedirectToAction("Login", "LoginUI");
        }

    }
}