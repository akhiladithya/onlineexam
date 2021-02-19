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

            List<Coursereg> crlst = ff.CourseRegistration_data_();
            colst.lst = crlst;
            colst.count = crlst.Count;
            return View(colst);

        }
        [HttpPost]
        public string coursepost(Coursereg cur)
        {
            Outputclass op = new Outputclass();
            op = ff.Create_Course_(cur);
            if (op.Count > 0)
            {
                return "1";
            }
            else
            {
                return "0";
            }


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

        public JsonResult Course_Isexistornot(string cname)
        {
           bool op= ff.Course_Isexistornot(cname);
            return Json(op, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Updatecoursereg(Coursereg reg)
        {
            string stat = "";
            Outputclass op = ff.Update_Course_(reg); 
            if(op.Count > 0)
            {
                stat = "true";

            }
            else
            {
                stat = "false";
            }

            return Json(stat,JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult GetusersList()
        {
            Userslist lst1 = new Userslist();
            lst1.lst = ff.UserRegistration_data_();
            lst1.count = lst1.lst.Count;
            return View(lst1);
        }
        public ActionResult NOFQNSENTRY()
        {
            List<Coursereg> dd = ff.Show_Course_data();
            ViewBag.getcourses = new SelectList(dd, "Courseid", "COURSENAME");
            List<Coursereg> dd1 = ff.Get_Course_QNData();
            //Courselist colst = new Courselist();

            //List<Coursereg> crlst = ff.Get_Course_QNData();
            //colst.lst = crlst;
            //colst.count = crlst.Count;

            return View(dd1);
        }

        public JsonResult Get_Course_QNData()
        {
            //List<Coursereg> dd = ff.Get_Course_QNData();
            //ViewBag.getcourses = new SelectList(dd, "Courseid", "COURSENAME");
            //return View();


            Courselist colst = new Courselist();

            List<Coursereg> crlst = ff.Get_Course_QNData();
            colst.lst = crlst;
            colst.count = crlst.Count;
            return Json(colst,JsonRequestBehavior.AllowGet);
        }

        public JsonResult insertques(Coursereg coureg)
        {
            //Outputclass Update_qns(Coursereg coureg)
            // {
            //     return dbcls.Update_qns(coureg);
            // }
            Outputclass update = ff.Update_qns(coureg);
            return Json(update.Count, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getquestins(string Courseid)
        {
            string dd = ff.Get_Noofqns(Courseid);
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
        public ActionResult popup()
        {
            return View();
        }

        #region Course Questions Entry
        
        [HttpPost]
        public ActionResult Create_QUESTIONs(Questioneries qns)
        {
            Outputclass op = ff.Create_QUESTIONs(qns);

            return Json(op, JsonRequestBehavior.AllowGet);
        }
        public ActionResult QUestionEntry()
        {
            List<Coursereg> dd = ff.Show_Course_data();
            ViewBag.getcourses = new SelectList(dd, "Courseid", "COURSENAME");
            List<Coursereg> dd1 = ff.SHOW_COURSE_NOTNULL();
            return View(dd1);
        }

        public JsonResult GET_QNS_COUNT(string Courseid)
        {
            List<Questioneries> Qncount = ff.GET_QNS_COUNT(Courseid);
            return Json(Qncount, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GET_QNS_STATUS(string Courseid)
        {
            List<Questioneries> Qnstatus = ff.GET_QNS_STATUS(Courseid);
            return Json(Qnstatus, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Questio_data(string coid)
        {
            //Quesionarieslist colst = new Courselist();

            //List<Coursereg> crlst = ff.CourseRegistration_data_();
            //colst.lst = crlst;
            //colst.count = crlst.Count;
            ////return View(colst);

            Quesionarieslist qnlst = new Quesionarieslist();
            List<Questioneries>  qns = ff.Questio_data(coid);
            qnlst.lstq = qns;
            qnlst.count = qns.Count;
            return Json(qns, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult getquestionid(string Qid)
        {
            Session["QID"] = Qid;

            return Json(true, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetQuestionupdate()
        {
            string qq = Session["QID"].ToString();
            Questioneries dds = ff.Get_databasedonqid(qq);

            return View(dds);

        }
        [HttpPost]
        public ActionResult Update_QUESTIONs(Questioneries qns)
        {
            //string qq = Session["QID"].ToString();
            qns.QUESTIONID = Convert.ToInt32(Session["QID"].ToString());
            Outputclass op = ff.Update_QUESTIONs(qns);

            return Json(op, JsonRequestBehavior.AllowGet);
        }



        #endregion

        [HttpGet]
        public ActionResult Get_cources_usercourseassign()
        {

            Coursereg qnlst = new Coursereg();
            List<Coursereg> qns = ff.Get_cources_usercourseassign();
            
            return Json(qns, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Get_userassigndata()
        {

            Usercourseassign qnlst = new Usercourseassign();
            List<Usercourseassign> qns = ff.Get_userassigndata();
            
            return Json(qns, JsonRequestBehavior.AllowGet);
        }




    }
}