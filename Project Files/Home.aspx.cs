using slider.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace slider
{
    public partial class Home : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        myDAL obj = new myDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
                Response.Redirect("hazaslider.aspx");
            else
            {
                LoadPosts();
            }
        }

        protected void LoadPosts()
        {
            
            string uid = Session["userID"] as string;
         dt=   obj.LOADPOSTS(uid);
         StatusDataList.DataSource = dt;
         
         StatusDataList.DataBind();
        }

        protected void UpdateStatus(object sender, EventArgs e)
        {
            String Status = writeStatus.Text;



            string uid = Session["userID"] as string;
            obj.UPDATESTATUS(uid, Status);

            Response.Redirect("Home.aspx");
            

          
       }
  
    }
}