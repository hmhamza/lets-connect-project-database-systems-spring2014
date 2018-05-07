using slider.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace slider
{
    public partial class Lets_Connect : System.Web.UI.MasterPage
    {
        DataTable data = new DataTable();
        myDAL obj = new myDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadChat();
            LoadFriendsList();
            LoadBirthdays();
        }

        protected void LoadBirthdays()
        {

            string uid = Session["userID"] as string;
            data = obj.LOADBIRTHDAYS(uid);
            BirthdayDataList.DataSource = data;
            BirthdayDataList.DataBind();
         
        }

        protected void LoadChat()
        {

            string uid = Session["userID"] as string;
            data = obj.LOADCHAT(uid);
            ChatDataList.DataSource = data;
            ChatDataList.DataBind();

            data = obj.LOADONLINE(uid);
            OnlineDataList.DataSource = data;
            OnlineDataList.DataBind();
        }

        protected void LoadFriendsList()
        {


            string uid = Session["userID"] as string;
            data = obj.LOADFRIENDS_DROP(uid);

            Friends_List.DataSource = data;
            Friends_List.DataTextField = "First_Name";
            Friends_List.DataValueField = Friends_List.DataTextField;
            Friends_List.DataBind();
        }

        protected void timer1_Tick(object sender, EventArgs e)
        {
            LoadChat();
        }

        protected void New(object sender, EventArgs e)
        {
            string uid = Session["userID"] as string;
            int found = obj.Check_New(uid);
            if (found > 0)
            {
                Page.RegisterStartupScript("unique_key", "<script type=\"text/javascript\">Change()</script>");
            }
        }

        protected void SendMessage(object sender, EventArgs e)
        {
            String Message = MessageBox.Text;
            String Friend_Name = Friends_List.SelectedValue;
            //string value = DropDownList3.SelectedValue;
            string uid = Session["userID"] as string;
            obj.SENDMESSAGE(uid, Message, Friend_Name);


            Response.Redirect("Home.aspx");

        }


        protected void Log_Out(object sender, EventArgs e)
        {
            string uid = Session["userID"] as string;
            obj.SETOFFLINE(uid);
            Session.RemoveAll();
            Response.Redirect("hazaslider.aspx");

        }

        protected void Deactivate(object sender, EventArgs e)
        {
            string uid = Session["userID"] as string;
            obj.DeleteUSER(uid);
            Session.RemoveAll();
            Response.Redirect("hazaslider.aspx");
        }

        protected void Notifications_Click(object sender, EventArgs e)
        {
            Response.Redirect("Notifications.aspx");
        }

    }
}