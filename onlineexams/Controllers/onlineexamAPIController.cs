﻿using onlineexams.Models;
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

        #region Create Questions
        public Outputclass Create_QUESTIONs_(Questioneries qns)
        {
            return dbcls.Create_QUESTIONs(qns);
        }
        #endregion

        #region Create Course Assign
        public Outputclass Create_QUESTIONs_(Usercourseassign usas)
        {
            return dbcls.Create_CourseAssign(usas);
        }
        #endregion

        #region Create Exam
        public Outputclass Create_Exam_(Examtable exam)
        {
            return dbcls.Create_Exam(exam);
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
        [HttpGet]
        public List<Questioneries> Questio_data_()
        {
            return dbcls.Questio_data();
        }
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




    }
}
