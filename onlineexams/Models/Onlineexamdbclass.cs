using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace onlineexams.Models
{
    public class Onlineexamdbclass
    {
        //SqlConnection conn = new SqlConnection("Data Source=.;database=ONLINETRAINEE; uid=sa;Password=P@ssw0rd;Integrated Security = True;");
        SqlConnection conn = new SqlConnection("Data Source=.;database=ONLINETRAINEE; Integrated Security = True;");
       
        #region Connectionstring
        public void Connection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
        }
        #endregion

        #region User Registration
        public Userregistration Create_user(Userregistration userreg)
        {
            Userregistration dd = new Userregistration();
            try
            {
                SqlCommand cmd = new SqlCommand("Insert_USERREGISTRATION", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FINAME", userreg.FIRSTNAME);
                cmd.Parameters.AddWithValue("@LASTNAME ", userreg.LASTNAME);//it is related to aadharnumber property
                cmd.Parameters.AddWithValue("@PASSWORD", userreg.PASSWORD);
                cmd.Parameters.AddWithValue("@CONFORMPASSWORD", userreg.CONFORMPASSWORD);
                cmd.Parameters.AddWithValue("@EMAILID", userreg.EMAILID);
                cmd.Parameters.AddWithValue("@MOBILENUMBER", userreg.MOBILENUMBER);
                //cmd.Parameters.AddWithValue("@LASTLOGINTIME", "fsf");
                cmd.Parameters.AddWithValue("@STATUS", "ACTIVE");
                Connection();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //var dd = new Userregistration();
                    dd.FIRSTNAME = dr["USER_ID"].ToString();
                    

                }
                dr.Close();

                return dd;
            }
            catch (Exception ex)
            {

                dd.STATUS = ex.ToString();
                return dd;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region Course Registration
        public Outputclass Create_Course(Coursereg coureg)
        {
            Outputclass outputclass = new Outputclass();
            try
            {
                SqlCommand cmd = new SqlCommand("Insert_COURSEREGISTRATION", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@COURSENAME", coureg.COURSENAME);
                cmd.Parameters.AddWithValue("@COURSEPERIOD", coureg.COURSEPERID);
                cmd.Parameters.AddWithValue("@COURSEFROMDATE", coureg.COURSEFROMDATE);
                cmd.Parameters.AddWithValue("@COURSETODATE", coureg.COURSETODATE);
                //cmd.Parameters.AddWithValue("@NUMBEROSQUETIONS", coureg.NUMBEROSQUETIONS);
                cmd.Parameters.AddWithValue("@NUMBEROFDAYS", coureg.NUMBEROFDAYS);
                cmd.Parameters.AddWithValue("@TOTALMARKS", coureg.TOTALMARKS);
                cmd.Parameters.AddWithValue("@STATUS", "ACTIVE");
                cmd.Parameters.AddWithValue("@DESCRIPTION", coureg.Description);
                cmd.Parameters.AddWithValue("@COURSEAMOUNT", coureg.COURSEAMOUNT);
                cmd.Parameters.AddWithValue("@TRAINER", coureg.TRAINERNAME);
                cmd.Parameters.AddWithValue("@COURSEIMPORTANCE", coureg.COURSEIMPORTANCE);
                Connection();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    outputclass.Count = i;
                }
                return outputclass;
            }
            catch (Exception ex)
            {

                outputclass.Msg = ex.ToString();
                return outputclass;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region QUESTIONERIES
        public Outputclass Create_QUESTIONs(Questioneries qns)
        {
            Outputclass outputclass = new Outputclass();
            try
            {
                SqlCommand cmd = new SqlCommand("Insert_QUESTIONERIES", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@COURSEID", qns.COURSEID);
                //cmd.Parameters.AddWithValue("@QUESTIONID", qns.QUESTIONID);
                cmd.Parameters.AddWithValue("@QUESTION", qns.QUESTION);
                cmd.Parameters.AddWithValue("@TYPE", qns.TYPE);
                cmd.Parameters.AddWithValue("@Marks", qns.MMarks);
                cmd.Parameters.AddWithValue("@A", qns.OP1);
                cmd.Parameters.AddWithValue("@B", qns.OP2);
                cmd.Parameters.AddWithValue("@C", qns.OP3);
                cmd.Parameters.AddWithValue("@D", qns.OP4);
                cmd.Parameters.AddWithValue("@ANSWER", qns.ANSWER);
                Connection();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    outputclass.Count = i;
                }
                return outputclass;
            }
            catch (Exception ex)
            {

                outputclass.Msg = ex.ToString();
                return outputclass;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region Exam Create
        public Outputclass Create_Exam(Examtable exam)
        {
            Outputclass outputclass = new Outputclass();
            try
            {
                SqlCommand cmd = new SqlCommand("Insert_EXAMTABLE", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USERID", exam.USERID);
                cmd.Parameters.AddWithValue("@COURSEID", exam.COURSEID);
                cmd.Parameters.AddWithValue("@QUESTION", exam.QUESTION);
                cmd.Parameters.AddWithValue("@ANSWER", exam.ANSWER);
                cmd.Parameters.AddWithValue("@MARKS", exam.MARKS);
                cmd.Parameters.AddWithValue("@TOTALMARKS", exam.TOTALMARKS);
                cmd.Parameters.AddWithValue("@STATUS", exam.STATUS);
                Connection();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    outputclass.Count = i;
                }
                return outputclass;
            }
            catch (Exception ex)
            {

                outputclass.Msg = ex.ToString();
                return outputclass;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region User Course Assign
        public Outputclass Create_CourseAssign(Usercourseassign usercouass)
        {
            Outputclass outputclass = new Outputclass();
            try
            {
                SqlCommand cmd = new SqlCommand("Insert_USERCOURSEASSIGN", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@COURSEID", usercouass.COURSEID);
                cmd.Parameters.AddWithValue("@USERID", usercouass.USERID);
                cmd.Parameters.AddWithValue("@DATEOFAPPROVE", usercouass.DATEOFAPPROVE);
                cmd.Parameters.AddWithValue("@COURSEENDDATE", usercouass.COURSEENDDATE);
                cmd.Parameters.AddWithValue("@COURSEDURATION", usercouass.COURSEDURATION);
                cmd.Parameters.AddWithValue("@EXAMSTATUSASSIGN", usercouass.EXAMSTATUSASSIGN);
                cmd.Parameters.AddWithValue("@STATUS", usercouass.STATUS);
                Connection();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    outputclass.Count = i;
                }
                return outputclass;
            }
            catch (Exception ex)
            {

                outputclass.Msg = ex.ToString();
                return outputclass;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region AUDITTRAILS
        public Outputclass AUDITTRAILS(Audittrails adt)
        {
            Outputclass outputclass = new Outputclass();
            try
            {
                SqlCommand cmd = new SqlCommand("Insert_AUDITTRAILS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USERID", adt.USERID);
                cmd.Parameters.AddWithValue("@USERNAME", adt.USERNAME);
                cmd.Parameters.AddWithValue("@ACTIONOFATTEMPT", adt.ACTIONOFATTEMPT);
                cmd.Parameters.AddWithValue("@TYPEOFATTEMPT", adt.TYPEOFATTEMPT);
                cmd.Parameters.AddWithValue("@DESCRIPTION", adt.DESCRIPTION);
                cmd.Parameters.AddWithValue("@FRONTENDDATE", adt.FRONTENDDATE);
                cmd.Parameters.AddWithValue("@BACKENDDATE", adt.BACKENDDATE);
                Connection();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    outputclass.Count = i;
                }
                return outputclass;
            }
            catch (Exception ex)
            {

                outputclass.Msg = ex.ToString();
                return outputclass;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion s

        #region Userregistration data
        public List<Userregistration> UserRegistration_data()
        {
            List<Userregistration> userreglist = new List<Userregistration>();
            try
            {
                SqlCommand cmd = new SqlCommand("GET_USERREGISTRATION", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                Connection();
                SqlDataReader dr = cmd.ExecuteReader();
                Userregistration userreglst1;
                while(dr.Read())
                {
                    userreglst1 = new Userregistration();
                    userreglst1.Userid = dr["USER_ID"] != null ?Convert.ToInt32(dr["USER_ID"]) : 0;
                    userreglst1.FIRSTNAME = dr["Username"] != null ? dr["Username"].ToString() : "";
                    //userreglst1.LASTNAME = dr["LASTNAME"] != null ? dr["LASTNAME"].ToString() : "";
                    userreglst1.PASSWORD = dr["PASSWORD"] != null ? dr["PASSWORD"].ToString() : "";
                    userreglst1.CONFORMPASSWORD = dr["CONFIRMPASSWORD"] != null ? dr["CONFIRMPASSWORD"].ToString() : "";
                    userreglst1.EMAILID = dr["EMAIL_ID"] != null ? dr["EMAIL_ID"].ToString() : "";
                    userreglst1.MOBILENUMBER = dr["MOBILE_NUMBER"] != null ? dr["MOBILE_NUMBER"].ToString() : "";
                    userreglst1.AAdharnumber= dr["AADHARNUMBER"] != null ? dr["AADHARNUMBER"].ToString() : "";
                    userreglst1.LASTLOGINTIME= dr["LASTLOGINTIME"] != null ? dr["LASTLOGINTIME"].ToString() : "";
                    userreglst1.LASTLOGINTIME= dr["ROLE"] != null ? dr["ROLE"].ToString() : "";
                    userreglst1.STATUS = dr["STATUS"] != null ? dr["STATUS"].ToString() : "";
                    userreglist.Add(userreglst1);
                }
                return userreglist;
            }
            catch (Exception ch)
            {
                return userreglist;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region Course Name Exists or Not
        public bool Course_Isexistornot(string cname)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("courseexists",conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@course",cname);
                Connection();
                var hh = cmd.ExecuteScalar();
                if (hh.ToString() == "false")
                    return false; //if  CourseName Exist return true
                else
                    return true;//if  CourseName not-Exist return false
            }
            catch (Exception ch)
            {

                return true;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion


        #region Course Registration data
        public List<Coursereg> CourseRegistration_data()
        {
            List<Coursereg> coureglist = new List<Coursereg>();
            try
            {
                SqlCommand cmd = new SqlCommand("GET_COURSEREGISTRATION", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                Connection();
                SqlDataReader dr = cmd.ExecuteReader();
                Coursereg coureglist1;
                while (dr.Read())
                {
                    coureglist1 = new Coursereg();
                    coureglist1.Courseid = dr["COURSEID"] != null ? Convert.ToInt32(dr["COURSEID"]) : 0;
                    coureglist1.COURSENAME= dr["COURSENAME"] != null ? dr["COURSENAME"].ToString() : "";
                    coureglist1.COURSEPERID = dr["COURSEPERIOD"] != null ? dr["COURSEPERIOD"].ToString() : "";
                    coureglist1.COURSEFROMDATE = dr["COURSEFROMDATE"] != null ? dr["COURSEFROMDATE"].ToString() : "";
                    coureglist1.COURSETODATE = dr["COURSETODATE"] != null ? dr["COURSETODATE"].ToString() : "";
                    coureglist1.NUMBEROSQUETIONS = dr["NUMBEROSQUETIONS"] != null ? dr["NUMBEROSQUETIONS"].ToString() : "";
                    coureglist1.NUMBEROFDAYS= dr["NUMBEROFDAYS"] != null ? dr["NUMBEROFDAYS"].ToString() : "";
                    coureglist1.TOTALMARKS = dr["TOTALMARKS"] != null ? dr["TOTALMARKS"].ToString() : "";
                    coureglist1.STATUS = dr["STATUS"] != null ? dr["STATUS"].ToString() : "";
                    coureglist1.Description = dr["COURSEDESCRIPTION"] != null ? dr["COURSEDESCRIPTION"].ToString() : "";
                    coureglist1.TRAINERNAME = dr["COURSETRAINER"] != null ? dr["COURSETRAINER"].ToString() : "";
                    coureglist1.COURSEAMOUNT = dr["COURSEAMOUNT"] != null ? dr["COURSEAMOUNT"].ToString() : "";
                    coureglist1.COURSEIMPORTANCE = dr["courseimportance"] != null ? dr["courseimportance"].ToString() : "";
                    coureglist.Add(coureglist1);
                }
                return coureglist;
            }
            catch (Exception ch)
            {
                return coureglist;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region QUESTIONERIES data
        public List<Questioneries> Questio_data()
        {
            List<Questioneries> qnslist = new List<Questioneries>();
            try
            {
                SqlCommand cmd = new SqlCommand("GET_QUESTIONERIES", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                Connection();
                SqlDataReader dr = cmd.ExecuteReader();
                Questioneries qnslist1;
                while (dr.Read())
                {
                    qnslist1 = new Questioneries();
                    qnslist1.COURSEID = dr["COURSEID"] != null ? Convert.ToInt32(dr["COURSEID"]) : 0;
                    qnslist1.QUESTIONID = dr["QUESTIONID"] != null ? Convert.ToInt32(dr["QUESTIONID"]) : 0;
                    qnslist1.QUESTION = dr["QUESTION"] != null ? dr["QUESTION"].ToString() : "";
                    qnslist1.TYPE = dr["TYPE"] != null ? dr["TYPE"].ToString() : "";
                    qnslist1.OP1 = dr["A"] != null ? dr["A"].ToString() : "";
                    qnslist1.OP2 = dr["B"] != null ? dr["B"].ToString() : "";
                    qnslist1.OP3 = dr["B"] != null ? dr["B"].ToString() : "";
                    qnslist1.OP4 = dr["D"] != null ? dr["D"].ToString() : "";
                    qnslist1.ANSWER = dr["ANSWER"] != null ? dr["ANSWER"].ToString() : "";
                    qnslist.Add(qnslist1);
                }
                return qnslist;
            }
            catch (Exception ch)
            {
                return qnslist;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region Curse Assign data
        public List<Usercourseassign> Usercourseassign_data()
        {
            List<Usercourseassign> ucalist = new List<Usercourseassign>();
            try
            {
                SqlCommand cmd = new SqlCommand("GET_QUESTIONERIES", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                Connection();
                SqlDataReader dr = cmd.ExecuteReader();
                Usercourseassign ucalist1;
                while (dr.Read())
                {
                    ucalist1 = new Usercourseassign();
                    ucalist1.COURSEID = dr["COURSEID"] != null ? Convert.ToInt32(dr["COURSEID"]) : 0;
                    ucalist1.USERID = dr["USERID"] != null ? Convert.ToInt32(dr["USERID"]) : 0;
                    ucalist1.DATEOFAPPROVE = dr["DATEOFAPPROVE"] != null ? dr["DATEOFAPPROVE"].ToString() : "";
                    ucalist1.COURSEENDDATE = dr["COURSEENDDATE"] != null ? dr["COURSEENDDATE"].ToString() : "";
                    ucalist1.COURSEDURATION = dr["COURSEDURATION"] != null ? dr["COURSEDURATION"].ToString() : "";
                    ucalist1.EXAMSTATUSASSIGN = dr["EXAMSTATUSASSIGN"] != null ? dr["EXAMSTATUSASSIGN"].ToString() : "";
                    ucalist1.STATUS = dr["STATUS"] != null ? dr["STATUS"].ToString() : "";
                    ucalist.Add(ucalist1);
                }
                return ucalist;
            }
            catch (Exception ch)
            {
                return ucalist;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region Exam data
        public List<Examtable> Exam_data()
        {
            List<Examtable> exlist = new List<Examtable>();
            try
            {
                SqlCommand cmd = new SqlCommand("GET_EXAMTABLE", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                Connection();
                SqlDataReader dr = cmd.ExecuteReader();
                Examtable exlist1;
                while (dr.Read())
                {
                    exlist1 = new Examtable();
                    exlist1.USERID = dr["USERID"] != null ? Convert.ToInt32(dr["USERID"]) : 0;
                    exlist1.COURSEID = dr["COURSEID"] != null ? Convert.ToInt32(dr["COURSEID"]) : 0;
                    exlist1.QUESTION = dr["QUESTION"] != null ? dr["QUESTION"].ToString() : "";
                    exlist1.ANSWER = dr["ANSWER"] != null ? dr["ANSWER"].ToString() : "";
                    exlist1.MARKS = dr["MARKS"] != null ? dr["MARKS"].ToString() : "";
                    exlist1.TOTALMARKS = dr["TOTALMARKS"] != null ? dr["TOTALMARKS"].ToString() : "";
                    exlist1.STATUS = dr["STATUS"] != null ? dr["STATUS"].ToString() : "";
                    exlist.Add(exlist1);
                }
                return exlist;
            }
            catch (Exception ch)
            {
                return exlist;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region AUDITTRAILS data
        public List<Audittrails> Audittrails_data()
        {
            List<Audittrails> adtlist = new List<Audittrails>();
            try
            {
                SqlCommand cmd = new SqlCommand("GET_AUDITTRAILS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                Connection();
                SqlDataReader dr = cmd.ExecuteReader();
                Audittrails adtlist1;
                while (dr.Read())
                {
                    adtlist1 = new Audittrails();
                    adtlist1.USERID = dr["USERID"] != null ? Convert.ToInt32(dr["USERID"]) : 0;
                    adtlist1.USERNAME = dr["USERNAME"] != null ? dr["USERNAME"].ToString() : "";
                    adtlist1.ACTIONOFATTEMPT = dr["ACTIONOFATTEMPT"] != null ? dr["ACTIONOFATTEMPT"].ToString() : "";
                    adtlist1.TYPEOFATTEMPT = dr["TYPEOFATTEMPT"] != null ? dr["TYPEOFATTEMPT"].ToString() : "";
                    adtlist1.DESCRIPTION = dr["DESCRIPTION"] != null ? dr["DESCRIPTION"].ToString() : "";
                    adtlist1.FRONTENDDATE = dr["FRONTENDDATE"] != null ? dr["FRONTENDDATE"].ToString() : "";
                    adtlist1.BACKENDDATE = dr["BACKENDDATE"] != null ? dr["BACKENDDATE"].ToString() : "";
                    adtlist.Add(adtlist1);
                }
                return adtlist;
            }
            catch (Exception ch)
            {
                return adtlist;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region ForgetPassword
        public string Forgetpassword(Forgetpassword forgetpwd)
        {
            string result ="";
            try
            {
                SqlCommand cmd = new SqlCommand("FORGOT_CREDENTIALS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TYPE", forgetpwd.Type);
                cmd.Parameters.AddWithValue("@UID", forgetpwd.userid);
                cmd.Parameters.AddWithValue("@AADHAR", forgetpwd.AAdhar);
                Connection();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result = dr["RESULT"] != null ? dr["RESULT"].ToString() : "";
                    
                }
                dr.Close();
                return result;

            }
            catch (Exception ex)
            {
                result=ex.ToString();
                return result; 
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region Course Update
        public Outputclass Update_Course(Coursereg coureg)
        {
            Outputclass outputclass = new Outputclass();
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATECOURSE", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CName", coureg.COURSENAME);
                cmd.Parameters.AddWithValue("@CNOOFD", coureg.COURSEPERID);
                cmd.Parameters.AddWithValue("@CSTDT", coureg.COURSEFROMDATE);
                cmd.Parameters.AddWithValue("@CEDT", coureg.COURSETODATE);
                cmd.Parameters.AddWithValue("@CDES", coureg.Description);
                cmd.Parameters.AddWithValue("@CAMT", coureg.COURSEAMOUNT);
                cmd.Parameters.AddWithValue("@CTRAINERNAME", coureg.TRAINERNAME);
                cmd.Parameters.AddWithValue("@STATUS", coureg.STATUS);
                cmd.Parameters.AddWithValue("@CIMPORTANCE", coureg.COURSEIMPORTANCE);
                Connection();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    outputclass.Count = i;
                }
                return outputclass;
            }
            catch (Exception ex)
            {

                outputclass.Msg = ex.ToString();
                return outputclass;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion


        #region Number of QUESTIONS PAGE
        public string Get_Noofqns(string Courseid)
        {
            string qns = "";
            try
            {
                SqlCommand cmd = new SqlCommand("GET_NOOFQNS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CID", Courseid);
                DataTable dt = new DataTable();
                Connection();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    qns = dr["NUMBEROSQUETIONS"] != null ? dr["NUMBEROSQUETIONS"].ToString() : "";

                }
                dr.Close();
                return qns;
            }
            catch (Exception ch)
            {
                qns = ch.Message;
                return qns;
            }
            finally
            {
                conn.Close();
            }
        }


        public List<Coursereg> Show_Course_data()
        {
            List<Coursereg> coreg = new List<Coursereg>();

            try
            {
                SqlCommand cmd = new SqlCommand("SHOW_COURSE", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                Connection();
                SqlDataReader dr = cmd.ExecuteReader();
                Coursereg coreg1;
                while (dr.Read())
                {
                    coreg1 = new Coursereg();
                    coreg1.Courseid = dr["COURSEID"] != null ? Convert.ToInt32(dr["COURSEID"]) : 0; ;
                    coreg1.COURSENAME = dr["COURSENAME"] != null ? dr["COURSENAME"].ToString() : "";
                    coreg.Add(coreg1);
                }
                dr.Close();
                return coreg;
            }
            catch (Exception ch)
            {
                
                return coreg;
            }
            finally
            {
                conn.Close();
            }
        }

        public Outputclass Update_qns(Coursereg coureg)
        {
            Outputclass outputclass = new Outputclass();
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE_QNS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CID", coureg.Courseid);
                cmd.Parameters.AddWithValue("@NOOFQNS", coureg.NUMBEROSQUETIONS);
                Connection();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    outputclass.Count = i;
                }
                return outputclass;
            }
            catch (Exception ex)
            {

                outputclass.Msg = ex.ToString();
                return outputclass;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Coursereg> Get_Course_QNData()
        {
            List<Coursereg> coursereg = new List<Coursereg>();
            try
            {
                SqlCommand cmd = new SqlCommand("GET_COURSE_QNNUMBERS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                Connection();
                SqlDataReader dr = cmd.ExecuteReader();
                Coursereg coursereg1;
                while (dr.Read())
                {
                    coursereg1 = new Coursereg();
                    coursereg1.COURSENAME = dr["COURSENAME"] != null ? dr["COURSENAME"].ToString() : "";
                    coursereg1.NUMBEROSQUETIONS = dr["NUMBEROSQUETIONS"] != null ? dr["NUMBEROSQUETIONS"].ToString() : "";
                    if(coursereg1.NUMBEROSQUETIONS==""||coursereg1.NUMBEROSQUETIONS==null)
                    {
                        coursereg1.NUMBEROSQUETIONS = "0";
                    }
                    coursereg.Add(coursereg1);
                }
                return coursereg;
                dr.Close();
            }
            catch (Exception ch)
            {
                return coursereg;
            }
            finally
            {
                conn.Close();
            }
        }


        #endregion

    }
}