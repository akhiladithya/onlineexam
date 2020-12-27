using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace onlineexams.Models
{
    public class Logindb
    {
        SqlConnection conn = new SqlConnection("Data Source=.;database=ONLINETRAINEE; uid=sa;Password=P@ssw0rd;Integrated Security = True;");

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


        public List<Userregistration> Login()
        {
            List<Userregistration> userreglist = new List<Userregistration>();
            try
            {
                SqlCommand cmd = new SqlCommand("GET_USERDATA", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                Connection();
                SqlDataReader dr = cmd.ExecuteReader();
                Userregistration userreglst1;
                while (dr.Read())
                {
                    userreglst1 = new Userregistration();
                    userreglst1.Userid = dr["USER_ID"] != null ? Convert.ToInt32(dr["USER_ID"]) : 0;
                    userreglst1.FIRSTNAME = dr["Username"] != null ? dr["Username"].ToString() : "";
                    userreglst1.PASSWORD = dr["PASSWORD"] != null ? dr["PASSWORD"].ToString() : "";
                    userreglst1.CONFORMPASSWORD = dr["CONFIRMPASSWORD"] != null ? dr["CONFIRMPASSWORD"].ToString() : "";
                    userreglst1.EMAILID = dr["EMAIL_ID"] != null ? dr["EMAIL_ID"].ToString() : "";
                    userreglst1.MOBILENUMBER = dr["MOBILE_NUMBER"] != null ? dr["MOBILE_NUMBER"].ToString() : "";
                    userreglst1.AAdharnumber = dr["AADHARNUMBER"] != null ? dr["AADHARNUMBER"].ToString() : "";
                    userreglst1.LASTLOGINTIME = dr["LASTLOGINTIME"] != null ? dr["LASTLOGINTIME"].ToString() : "";
                    userreglst1.STATUS = dr["STATUS"] != null ? dr["STATUS"].ToString() : "";
                    userreglst1.uniqueid = dr["UNIQUEID"] != null ? dr["UNIQUEID"].ToString() : "";
                    userreglst1.Role = dr["ROLE"] != null ? dr["ROLE"].ToString() : "";
                    userreglst1.createdate = dr["CREATED_DATE"] != null ? dr["CREATED_DATE"].ToString() : "";
                    userreglist.Add(userreglst1);
                }
                return userreglist;
            }
            catch(Exception ch)
            {
                return userreglist;
            }
            finally
            {
                conn.Close();
            }
        }

        int uid;
        string pwd;
        public Userregistration Logincred(login dd)
        {
            Userregistration userreglst = new Userregistration();

            try
            {
                SqlCommand cmd = new SqlCommand("USER_LOGIN", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USERID",dd.Username);
                cmd.Parameters.AddWithValue("@PASSWORD",dd.Password);
                Connection();
                SqlDataReader dr = cmd.ExecuteReader();
               // Userregistration ur;
                while(dr.Read())
                {

                    userreglst.STATUS = dr["STATUS"] != null ? dr["STATUS"].ToString() : "";
                    //userreglst.Add(ur);
                }
                return userreglst;
            }
            catch (Exception ch)
            {
                return userreglst;
            }
            finally
            {
                conn.Close();
            }
        }



    }
}