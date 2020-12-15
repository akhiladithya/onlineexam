using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace onlinetraine.Models
{
    public class Onlineexamdbclass
    {
        SqlConnection conn = new SqlConnection("server=.;database=ONLINETRAINEE;uid=sa;password=P@ssw0rd");
        public void Connection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
        }

        #region User Registration
        public Outputclass Create_user(Userregistration userreg)
        {
            Outputclass outputclass = new Outputclass();
            try
            {
                SqlCommand cmd = new SqlCommand("Insert_COURSEREGISTRATION", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FINAME", userreg.FIRSTNAME);
                cmd.Parameters.AddWithValue("@LASTNAME ", userreg.LASTNAME);
                cmd.Parameters.AddWithValue("@PASSWORD", userreg.PASSWORD);
                cmd.Parameters.AddWithValue("@CONFORMPASSWORD", userreg.CONFORMPASSWORD);
                cmd.Parameters.AddWithValue("@EMAILID", userreg.EMAILID);
                cmd.Parameters.AddWithValue("@MOBILENUMBER", userreg.MOBILENUMBER);
                cmd.Parameters.AddWithValue("@LASTLOGINTIME", userreg.LASTLOGINTIME);
                cmd.Parameters.AddWithValue("@STATUS", userreg.STATUS);
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
                cmd.Parameters.AddWithValue("@NUMBEROSQUETIONS", coureg.NUMBEROSQUETIONS);
                cmd.Parameters.AddWithValue("@NUMBEROFDAYS", coureg.NUMBEROFDAYS);
                cmd.Parameters.AddWithValue("@TOTALMARKS", coureg.TOTALMARKS);
                cmd.Parameters.AddWithValue("@STATUS", coureg.STATUS);
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
                cmd.Parameters.AddWithValue("@QUESTIONID", qns.QUESTIONID);
                cmd.Parameters.AddWithValue("@QUESTION", qns.QUESTION);
                cmd.Parameters.AddWithValue("@TYPE", qns.TYPE);
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

        #region QUESTIONERIES
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
    }
}