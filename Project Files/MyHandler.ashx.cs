using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace GridviewwithImages
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ImageHandler : IHttpHandler
    {

        private static readonly string connString =
       System.Configuration.ConfigurationManager.ConnectionStrings["SQLDbConnection"].ConnectionString;

        public void ProcessRequest(HttpContext context)
        {
            string imageid = context.Request.QueryString["ImID"];
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand command = new SqlCommand("select Image from Image where ImageID=" + imageid, con);
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            context.Response.BinaryWrite((Byte[])dr[0]);
            con.Close();
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}