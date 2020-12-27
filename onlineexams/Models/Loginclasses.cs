using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace onlineexams.Models
{
    public class Loginclasses
    {
    }
    public class login
    {
        [Required(ErrorMessage = "Please Enter the Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please Enter the Password")]
        public string Password { get; set; }
    }
}