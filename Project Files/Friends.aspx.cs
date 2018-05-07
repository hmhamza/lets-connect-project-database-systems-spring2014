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
    public partial class Friends : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        myDAL obj = new myDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
                Response.Redirect("hazaslider.aspx");
            else
            {
                LoadFriends();
            }
        }

        protected void LoadFriends()
        {
            string uid = Session["userID"] as string;
            dt = obj.LOADFRIENDS(uid);
            FriendsDataList.DataSource = dt;
            FriendsDataList.DataBind();
        }
    }
}