using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace slider.DAL
{
    public class myDAL
    {
        private static readonly string connString =
        System.Configuration.ConfigurationManager.ConnectionStrings["SQLDbConnection"].ConnectionString;

        public int SearchItem(String Email, String Password)
        {
            int Found =0;
            int Id = 0;
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("UserLogin", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@EmailID", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 40);
                cmd.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@EmailID"].Value = Email;
                cmd.Parameters["@Password"].Value = Password;


                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@status"].Value); //convert to output parameter to interger format
                Id = Convert.ToInt32(cmd.Parameters["@UserID"].Value); //convert to output parameter to interger format
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;
        }

        public int UpdateItem(String First_Name, String Last_Name, String EmailID, String Password, String Gender, String Day, String Month, String Year)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            int result = 0;
            int Age = DateTime.Today.Year;
            try
            {
                cmd = new SqlCommand("CreateLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@EmailID", SqlDbType.NVarChar, 50).Value = EmailID;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 40).Value = Password;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = First_Name;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = Last_Name;
                cmd.Parameters.Add("@Gender", SqlDbType.NVarChar, 50).Value = Gender;
                cmd.Parameters.Add("@Day", SqlDbType.NVarChar, 50).Value = Day;
                cmd.Parameters.Add("@Month", SqlDbType.NVarChar, 50).Value = Month;
                cmd.Parameters.Add("@Year", SqlDbType.NVarChar, 50).Value = Year;
                cmd.Parameters.Add("@Age", SqlDbType.NVarChar, 50).Value = Age;
                cmd.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                result = Convert.ToInt32(cmd.Parameters["@status"].Value); //convert to output parameter to interger format

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public DataTable LOADPOSTS(string id)
        {
            DataTable d = new DataTable();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("GetStatus", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = id.ToString();//"manloo@gmail.com";
                d.Load(cmd.ExecuteReader());
            
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return d;
                
        }

        public DataTable LOADCHAT(string id)
        {
            DataTable d = new DataTable();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("LoadMessages", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = id.ToString();//"manloo@gmail.com";
                d.Load(cmd.ExecuteReader());

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return d;

        }

        public DataTable SEARCHUSER(string Name)
        {
            DataTable d = new DataTable();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SearchUsers", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = Name.ToString();

                d.Load(cmd.ExecuteReader());

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return d;

        }

        public void UPDATESTATUS(String EmailID, String Statement)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            
            try
            {
                cmd = new SqlCommand("UpdateStatus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@EmailID", SqlDbType.NVarChar, 50).Value = EmailID;
                cmd.Parameters.Add("@Statement", SqlDbType.NVarChar, 1000).Value = Statement;
               
            

                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public int Check_New(string email)
        {
            int found = 0;

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("CheckNewNotification", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@EmailID", SqlDbType.NVarChar, 50).Value = email.ToString();
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                found = Convert.ToInt32(cmd.Parameters["@result"].Value); //convert to output parameter to integer format

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return found;
        }

        public DataTable LOADFRIENDS(string id)
        {
            DataTable d = new DataTable();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("LoadFriends", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = id.ToString();//"manloo@gmail.com";
                d.Load(cmd.ExecuteReader());

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return d;

        }

        public DataTable LOADFRIENDS_DROP(string id)
        {
            DataTable d = new DataTable();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("LoadFriends_Drop", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = id.ToString();//"manloo@gmail.com";
                d.Load(cmd.ExecuteReader());

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return d;

        }

        public void SETOFFLINE(String EmailID)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("SetOffline", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = EmailID;


                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable LOADONLINE(string id)
        {
            DataTable d = new DataTable();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("LoadOnlineFriends", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = id.ToString();//"manloo@gmail.com";
                d.Load(cmd.ExecuteReader());

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return d;

        }

        public void SENDMESSAGE(string id, String Message, String Friend_name)
        {
            DataTable d = new DataTable();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SendMessage", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = id.ToString();//"manloo@gmail.com";
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 50).Value = Message;
                cmd.Parameters.Add("@Friend_Name", SqlDbType.NVarChar, 1000).Value = Friend_name;
                d.Load(cmd.ExecuteReader());

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

        }


        public void ADDFRIEND(String RUid, String SUid)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("Request Check", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SendingUserEmail", SqlDbType.NVarChar, 50).Value = SUid;
                cmd.Parameters.Add("@ReceivingUserEmail", SqlDbType.NVarChar, 50).Value = RUid;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }


        public DataTable LOADNEWSFEED(string id)
        {
            DataTable d = new DataTable();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("NewsFeed", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = id.ToString();//"manloo@gmail.com";
                d.Load(cmd.ExecuteReader());

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return d;

        }

        public DataTable LOADBIRTHDAYS(string id)
        {
            DataTable d = new DataTable();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("LoadBirthdays", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = id.ToString();//"manloo@gmail.com";
                d.Load(cmd.ExecuteReader());

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return d;

        }

        public void DeleteUSER(String EmailID)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("Remove User", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = EmailID;

                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable LOADNOTIFICATIONS(string id)
        {
            DataTable d = new DataTable();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("LoadNotifications", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = id.ToString();//"manloo@gmail.com";
                d.Load(cmd.ExecuteReader());

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return d;

        }

        public void Request_Click(String SUser, String RUser, int status)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("Request Accept Decline", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SendingUserEmail", SqlDbType.NVarChar, 50).Value = SUser;
                cmd.Parameters.Add("@ReceivingUserEmail", SqlDbType.NVarChar, 50).Value = RUser;
                cmd.Parameters.Add("@status", SqlDbType.NVarChar, 50).Value = status;

                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }
       
    }
    
}