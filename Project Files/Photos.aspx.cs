using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace slider
{
    public partial class Photos : System.Web.UI.Page
    {
        private static readonly string connString =
        System.Configuration.ConfigurationManager.ConnectionStrings["SQLDbConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // to store the image in DB
        protected void SAVE_IMAGE(object sender, EventArgs e)
        {
            string ImageName = string.Empty;
            byte[] Image = null;
            if (ImageUploadToDB.PostedFile != null && ImageUploadToDB.PostedFile.FileName != "")
            {
                ImageName = Path.GetFileName(ImageUploadToDB.FileName);
                Image = new byte[ImageUploadToDB.PostedFile.ContentLength];
                HttpPostedFile UploadedImage = ImageUploadToDB.PostedFile;
                UploadedImage.InputStream.Read(Image, 0, (int)ImageUploadToDB.PostedFile.ContentLength);
            }
            using (SqlConnection Sqlcon = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    Sqlcon.Open();
                    cmd.Connection = Sqlcon;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Save_Image";
                    cmd.Parameters.Add(new SqlParameter("@img", SqlDbType.Image));
                    cmd.Parameters["@img"].Value = Image;
                    string uid = Session["userID"] as string;
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = uid.ToString();//"manloo@gmail.com";
                    cmd.ExecuteNonQuery();
                    //int retVal = (int)cmd.Parameters["@pIntErrDescOut"].Value;
                }
            }
            //LoadImages();
        }

        //to get the image from DB and displaynig on website
        protected void LOAD_IMAGE(object sender, EventArgs e)
        {
            SqlDataAdapter SqlAda;
            DataSet ds;
            byte[] btImage = null;
            using (SqlConnection Sqlcon = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {


                    Sqlcon.Open();
                    cmd.Connection = Sqlcon;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Load_Image";
                    string uid = Session["userID"] as string;
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = uid.ToString();//"manloo@gmail.com";
                    SqlAda = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    SqlAda.Fill(ds);

                 


                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        btImage = (byte[])ds.Tables[0].Rows[i][0];

                        MemoryStream memoryStream = new MemoryStream(btImage, false);

                        System.Drawing.Image imgFromDataBase = System.Drawing.Image.FromStream(memoryStream);

                        string imageName = "~/Images/hw"+i+".jpg";
                        string savePath = Server.MapPath(@"Images\hw" + i + ".jpg");
                        imgFromDataBase.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                        //Image1.ImageUrl = imageName;



                        SqlConnection con = new SqlConnection(connString);
                        con.Open();
                        SqlCommand cmd1;

                        cmd1 = new SqlCommand("AddURL", con); //name of your procedure
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = uid.ToString();
                        cmd1.Parameters.Add("@URL", SqlDbType.NVarChar, 50).Value = imageName.ToString();
                        cmd1.ExecuteReader();



                     
                   
                       
                    }

                    DataTable d = new DataTable();
                    SqlConnection con1 = new SqlConnection(connString);
                    con1.Open();
                    SqlCommand cmdURL;


                    cmdURL = new SqlCommand("LoadURL", con1); //name of your procedure
                    cmdURL.CommandType = CommandType.StoredProcedure;

                    cmdURL.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = uid.ToString();//"manloo@gmail.com";
                    d.Load(cmdURL.ExecuteReader());

                    PhotosDataList.DataSource = d;

                    PhotosDataList.DataBind();






                    SqlConnection con2 = new SqlConnection(connString);
                    con2.Open();
                    SqlCommand cmd2;

                    cmd2 = new SqlCommand("DeleteURL", con2); //name of your procedure
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = uid.ToString();
                    cmd2.ExecuteReader();
                }

            }


        }
    }
}


