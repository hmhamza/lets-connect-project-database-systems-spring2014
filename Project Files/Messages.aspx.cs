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
    public partial class Messages : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        myDAL obj = new myDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
                Response.Redirect("hazaslider.aspx");
            else
            {
                LoadMessages();
            }
        }

        protected void LoadMessages()
        {
            string uid = Session["userID"] as string;
            dt = obj.LOADCHAT(uid);
            MessagesDataList.DataSource = dt;
            MessagesDataList.DataBind();
        }




    }
}