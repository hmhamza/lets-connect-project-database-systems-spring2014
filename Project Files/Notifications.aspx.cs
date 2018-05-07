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
    public partial class Notifications : System.Web.UI.Page
    {
        DataTable chat = new DataTable();
        myDAL obj = new myDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadNotifications();
        }

        protected void LoadNotifications()
        {

            string uid = Session["userID"] as string;
            chat = obj.LOADNOTIFICATIONS(uid);
            NotificationsDataList.DataSource = chat;
            NotificationsDataList.DataBind();
            ScriptManager.RegisterStartupScript(this, GetType(), "Test", "Change();", true);

        }

        protected void Accept_Click(object sender, EventArgs e)
        {
            int status = 1;
            string uid = Session["userID"] as string;
            String SUser = UserEmail.Text;
            obj.Request_Click(SUser,uid,status);
            //LoadNotifications();
        }

        protected void Decline_Click(object sender, EventArgs e)
        {
            int status = 0;
            string uid = Session["userID"] as string;
            String SUser = UserEmail.Text;
            obj.Request_Click(SUser, uid, status);
            LoadNotifications();
        }
    }
}