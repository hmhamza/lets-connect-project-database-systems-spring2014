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
    public partial class Sign_Up : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Sign_Up_Button_Click(object sender,EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Test", "Submit();", true);
            if (ValueHiddenField1.Value == "1")
            {
                String FN = First_Name.Text;
                String LN = Last_Name.Text;
                String email = Email.Text;
                String Pass = Password.Text;
                String Gender;
                String Day = Days_List.SelectedValue;
                String Month = Month_List.SelectedValue;
                String Year = Year_List.SelectedValue;
                bool isMale = Male_Button.Checked;

                if (isMale)
                {
                    Gender = "M";
                }
                else
                {
                    Gender = "F";
                }


                myDAL objMyDal = new myDAL();
                int Result = objMyDal.UpdateItem(FN, LN, email, Pass, Gender, Day, Month, Year);

                if (Result == 1)
                {
                    message.InnerHtml = Convert.ToString("Your Account Has Been Created With The Given Information");
                }
                else
                {
                    message.InnerHtml = Convert.ToString("Email Id Already in Use");
                }
            }
        }
    }
}