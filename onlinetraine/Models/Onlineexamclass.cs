﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onlinetraine.Models
{
    public class Onlineexamclass
    {
    }

    public class Userregistration
    {
        public int? Userid { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string PASSWORD { get; set; }
        public string CONFORMPASSWORD { get; set; }
        public string EMAILID { get; set; }
        public string MOBILENUMBER { get; set; }
        public string LASTLOGINTIME { get; set; }
        public string STATUS { get; set; }
    }
    public class Coursereg
    {
        public int? Courseid { get; set; }
        public string COURSENAME { get; set; }
        public string COURSEPERID { get; set; }
        public string COURSEFROMDATE { get; set; }
        public string COURSETODATE { get; set; }
        public string NUMBEROSQUETIONS { get; set; }
        public string NUMBEROFDAYS { get; set; }
        public string TOTALMARKS { get; set; }
        public string STATUS { get; set; }
    }
    public class Questioneries
    {
        public int? COURSEID { get; set; }
        public int? QUESTIONID { get; set; }
        public string QUESTION { get; set; }
        public string TYPE { get; set; }
        public string OP1 { get; set; }
        public string OP2 { get; set; }
        public string OP3 { get; set; }
        public string OP4 { get; set; }
        public string ANSWER { get; set; }
    }
    public class Usercourseassign
    {
        public int? COURSEID { get; set; }
        public int? USERID { get; set; }
        public string DATEOFAPPROVE { get; set; }
        public string COURSEENDDATE { get; set; }
        public string COURSEDURATION { get; set; }
        public string EXAMSTATUSASSIGN { get; set; }
        public string STATUS { get; set; }
    }
    public class Examtable
    {
        public int? USERID { get; set; }
        public int? COURSEID { get; set; }
        public string QUESTION { get; set; }
        public string ANSWER { get; set; }
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
}