using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace onlineexams.Models
{


    public class Userregistration
    {
        public int? Userid { get; set; }
        [Required(ErrorMessage = "Please Enter the First Name")]
        public string FIRSTNAME { get; set; }
        [Required(ErrorMessage = "Please Enter the Last Name")]
        public string LASTNAME { get; set; }
        [Required(ErrorMessage = "Please Enter the PASSWORD")]
        public string PASSWORD { get; set; }
        [Required(ErrorMessage = "Please Enter the CONFIRM PASSWORD")]
        public string CONFORMPASSWORD { get; set; }
        [Required(ErrorMessage = "Please Enter the Email ID")]
        public string EMAILID { get; set; }
        [Required(ErrorMessage = "Please Enter the Moblie Number")]
        public string MOBILENUMBER { get; set; }
        public string LASTLOGINTIME { get; set; }
        public string STATUS { get; set; }
        public string Role { get; set; }
        public string AAdharnumber { get; set; }
        public string uniqueid { get; set; }
        public string createdate { get; set; }
    }
    public class Coursereg
    {

        public int? Courseid { get; set; }
        public string COURSENAME { get; set; }
        public string COURSEPERID { get; set; }
        public string COURSEFROMDATE { get; set; }
        public string COURSETODATE { get; set; }
        public string COURSEDURATIONINHRS { get; set; }
        public string NUMBEROSQUETIONS { get; set; }
        public string NUMBEROFDAYS { get; set; }
        public string TOTALMARKS { get; set; }
        public string Description { get; set; }
        public string COURSEAMOUNT { get; set; }
        public string TRAINERNAME { get; set; }
        public string COURSEIMPORTANCE { get; set; }
        public string STATUS { get; set; }
    }

    public class Courselist
    {
        public List<Coursereg> lst { get; set; }
        public int count { get; set; }
    }
    public class Usercourseassign
    {
        public int? COURSEID { get; set; }
        public int? USERID { get; set; }
        public string COURSRNAME { get; set; }
        public string DATEOFAPPROVE { get; set; }
        public string COURSEENDDATE { get; set; }
        public string COURSEDURATION { get; set; }
        public string EXAMSTATUSASSIGN { get; set; }
        public string STATUS { get; set; }
        public string TRANSACTIONID { get; set; }
    }
    public class Examtable
    {
        public int? USERID { get; set; }
        public int? COURSEID { get; set; }
        public string EXAMCODE { get; set; }
        public string ATTEMPT { get; set; }
        public string QUESTIONID { get; set; }
        public string QUESTION { get; set; }
        public string ANSWER { get; set; }
        public string USERANSWER { get; set; }
        public string MARKS { get; set; }
        public string TOTALMARKS { get; set; }
        public string STATUS { get; set; }
    }
    public class Audittrails
    {
        public int? USERID { get; set; }
        public string USERNAME { get; set; }
        public string ACTIONOFATTEMPT { get; set; }
        public string TYPEOFATTEMPT { get; set; }
        public string DESCRIPTION { get; set; }
        public string FRONTENDDATE { get; set; }
        public string BACKENDDATE { get; set; }
    }

    public class Outputclass
    {
        public string Msg { get; set; }
        public int Count { get; set; }
    }

    public class Forgetpassword
    {
        public string Type { get; set; }
        public string userid { get; set; }
        public string AAdhar { get; set; }
    }
    public class Userslist
    {
        public List<Userregistration> lst { get; set; }
        public int count { get; set; }
    }

    #region Number of QUESTIONS PAGE

    public class Questioneries
    {
        public int? COURSEID { get; set; }
        public int? QUESTIONID { get; set; }
        public string QUESTION { get; set; }
        public string TYPE { get; set; }
        public string MMarks { get; set; }
        public string OP1 { get; set; }
        public string OP2 { get; set; }
        public string OP3 { get; set; }
        public string OP4 { get; set; }
        public string ANSWER { get; set; }
        public string Qnscount { get; set; }
        public string Qnstatus { get; set; }
    }


    public class Quesionarieslist
    {
        public List<Questioneries> lstq { get; set; }
        public int count { get; set; }
    }

    #endregion

}