using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using onlineexams.Models;

namespace onlineexams.Controllers
{
    public class LoginAPIController : ApiController
    {
        Logindb ldb = new Logindb();

        [HttpGet]
        public List<Userregistration> Login_()
        {
           return ldb.Login();
        }


        [HttpGet]
        public Userregistration Logincred_(login dd)
        {
           return ldb.Logincred(dd);
        }


    }
}
