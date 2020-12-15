using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace onlinetraine.Models
{
    public class AdminDbclass
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["akhil"].ConnectionString);

        


    }
}