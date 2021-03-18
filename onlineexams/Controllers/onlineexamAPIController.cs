using onlineexams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace onlineexams.Controllers
{
    public class onlineexamAPIController : ApiController
    {
        Onlineexamdbclass dbcls = new Onlineexamdbclass();

        #region Create User
        public Userregistration Create_user_(Userregistration userreg)
        {
            return dbcls.Create_user(userreg);
        }
        #endregion

        #region Create Course
        public Outputclass Create_Course_(Coursereg coureg)
        {
            return dbcls.Create_Course(coureg);
        }
        #endregion



        #region Create Course Assign

        [HttpGet]
        public List<Coursereg> Get_cources_usercourseassign()
        {
            return dbcls.Get_cources_usercourseassign();
        }

         [HttpGet]
        public List<Usercourseassign> Get_cources_request(string userid)
        {
            return dbcls.Get_cources_request(userid);
        }

        public Outputclass Create_QUESTIONs_(Usercourseassign usas)
        {
            return dbcls.Create_CourseAssign(usas);
        }

        [HttpGet]
        public List<Usercourseassign> Get_userassigndata()
        {
            return dbcls.Get_userassigndata();
        }

        [HttpGet]
        public List<Usercourseassign> Get_user_Requests()
        {
            return dbcls.Get_user_Requests();
        }

        
        [HttpGet]
        public List<Usercourseassign> DASHBOARD_COURSE_REQUESTS()
        {
            return dbcls.DASHBOARD_COURSE_REQUESTS();
        }
         
        [HttpGet]
        public Outputclass COURSE_APPROVE(string userid, string courseid,string text)
        {
            return dbcls.COURSE_APPROVE(userid,courseid,text);
        }



        #endregion

       

        #region Userregistration data
        [HttpGet]
        public List<Userregistration> UserRegistration_data_()
        {
            return dbcls.UserRegistration_data();
        }
        #endregion

        #region Course Registration data
        [HttpGet]
        public List<Coursereg> CourseRegistration_data_()
        {
            return dbcls.CourseRegistration_data();
        }
        #endregion

        #region Course Name Exists or not
        public bool Course_Isexistornot(string cname)
        {
            return dbcls.Course_Isexistornot(cname);
        }
        #endregion




        #region QUESTIONERIES data
        
        #endregion

        #region User Assign data
        [HttpGet]
        public List<Usercourseassign> Usercourseassign_data_()
        {
            return dbcls.Usercourseassign_data();
        }
        #endregion

        #region Exam data
        [HttpGet]
        public List<Examtable> Exam_data_()
        {
            return dbcls.Exam_data();
        }
        #endregion

        #region AUDITTRAILS data
        [HttpGet]
        public List<Audittrails> Audittrails_data_()
        {
            return dbcls.Audittrails_data();
        }
        #endregion

        #region ForgetPassword
        [HttpGet]
        public string Forgetpassword_(Forgetpassword forgetpwd)
        {
            return dbcls.Forgetpassword(forgetpwd);
        }
        #endregion

        #region Course Update
        [HttpPost]
        public Outputclass Update_Course_(Coursereg coureg)
        {
            return dbcls.Update_Course(coureg);
        }
        #endregion

        #region Question Entery
        public List<Coursereg> Show_Course_data()
        {
            return dbcls.Show_Course_data();
        }
        public string Get_Noofqns(string Courseid)
        {
            return dbcls.Get_Noofqns(Courseid);
        }
        public Outputclass Update_qns(Coursereg coureg)
        {
            return dbcls.Update_qns(coureg);
        }
        [HttpGet]
        public List<Coursereg> Get_Course_QNData()
        {
            return dbcls.Get_Course_QNData();
        }

        #endregion

        #region Course Questions Entry
        [HttpGet]
        public Outputclass Create_QUESTIONs(Questioneries qns)
        {
            return dbcls.Create_QUESTIONs(qns);
        }

        [HttpGet]
        public List<Coursereg> SHOW_COURSE_NOTNULL()
        {
            return dbcls.SHOW_COURSE_NOTNULL();
        }

        [HttpGet]
        public List<Questioneries> GET_QNS_COUNT(string Courseid)
        {
            return dbcls.GET_QNS_COUNT(Courseid);
        }

        [HttpGet]
        public List<Questioneries> GET_QNS_STATUS(string Courseid)
        {
            return dbcls.GET_QNS_STATUS(Courseid);
        }

        [HttpGet]
        public List<Questioneries> Questio_data(string coid)
        {
            return dbcls.Questio_data(coid);
        }

        [HttpGet]
        public Outputclass Update_QUESTIONs(Questioneries qns)
        {
            return dbcls.Update_QUESTIONs(qns);
        }

        [HttpGet]
        public Questioneries Get_databasedonqid(string Qid)
        {
            return dbcls.Get_databasedonqid(Qid);
        }
        #endregion

        public Outputclass Insert_transid(Usercourseassign usercouass)
        {
            return dbcls.Insert_transid(usercouass);
        }

        #region Create Exam
        public Outputclass Create_Exam_(Examtable exam)
        {
            return dbcls.Create_Exam(exam);
        }

        [HttpGet]
        public List<Questioneries> GEET_QUESTIONS_BASEDONCOURSEID(string cid)
        {
            return dbcls.GEET_QUESTIONS_BASEDONCOURSEID(cid);
        }

        [HttpGet]
        public List<Coursereg> GET_APPROVE_EXAMCOURSE(string userid)
        {
            return dbcls.GET_APPROVE_EXAMCOURSE(userid);
        }

        [HttpPost]
        public Outputclass Insert_Examrequest(string COURSEID, string USERID)
        {
            return dbcls.Insert_Examrequest(COURSEID, USERID);
        }

        #endregion



    }
}
