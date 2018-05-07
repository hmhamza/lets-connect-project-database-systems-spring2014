using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using slider.DAL;

namespace slider
{
    public partial class hazaSlider : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Search_Button_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this,GetType(),"Test","Submit();",true);
            if (ValueHiddenField.Value == "1")
            {
                String email = Email.Text;
                String password = Password.Text;

                myDAL objMyDal = new myDAL();

                int found = 0;

                found = objMyDal.SearchItem(email, password);

                if (found == 1)
                {
                    message.InnerHtml = Convert.ToString("Correct Email and Password Combination...");
                    Session["userID"] = email.ToString();

                    Context.Response.Redirect("Home.aspx");

                }
                else
                {
                    if (found == 2)
                    {
                        message.InnerHtml = Convert.ToString("Password Is Incorrect");
                    }
                    else
                    {
                        message.InnerHtml = Convert.ToString("No User With The Given Email Is Found");
                    }
                }
            }

        }
    }
}