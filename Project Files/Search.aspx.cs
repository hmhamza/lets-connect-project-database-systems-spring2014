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
    public partial class Search : System.Web.UI.Page
    {

        DataTable search = new DataTable();
        myDAL obj = new myDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
                Response.Redirect("hazaslider.aspx");
            else
            {
               
            }
        }


        protected void Search_Button_Click(object sender, EventArgs e)
        {
            String Name = SearchBox.Text;
          
            myDAL objMyDal = new myDAL();

            search = objMyDal.SEARCHUSER(Name);

            if (true)
            {
                SearchDataList.DataSource = search;
                SearchDataList.DataBind();
                message.InnerHtml = Convert.ToString("Following Users Found");
            }
            else
            {
                message.InnerHtml = Convert.ToString("No User Found");
                SearchDataList.DataSource = null;
                SearchDataList.DataBind();
            }



        }

        protected void Add_Friend(object sender, EventArgs e)
        {
            String Message = UserEmail.Text;
            string uid = Session["userID"] as string;
            obj.ADDFRIEND(Message,uid);
        }
    }
}