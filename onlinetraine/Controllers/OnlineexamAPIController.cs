using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using onlinetraine.Models;

namespace onlinetraine.Controllers
{
    public class OnlineexamAPIController : ApiController
    {
        Onlineexamdbclass dbcls = new Onlineexamdbclass();

        #region Create User
        public Outputclass Create_user_(Userregistration userreg)
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

        #region Create Exam
        public Outputclass Create_Exam_(Examtable exam)
        {
            return dbcls.Create_Exam(exam);
        }
        #endregion


    }
}
