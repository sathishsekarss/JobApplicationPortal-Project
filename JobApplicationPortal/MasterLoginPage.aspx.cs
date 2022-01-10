using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Helpers;

namespace JobApplicationPortal
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        #region Global variable for MYSQL connection
        MySql.Data.MySqlClient.MySqlConnection conn1;
        MySql.Data.MySqlClient.MySqlCommand cmd1;
        MySql.Data.MySqlClient.MySqlDataReader reader1;
        String queryStr1;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //creating a session id and storing the login time

            if (!this.IsPostBack)
            {
                DateTime now = DateTime.Now;
                Session["LoggedInTime"] = now;
            }

        }

        public static Boolean decryptPasssword(String salt, String PlainPass, String HashedPass)
        {

            PlainPass = PlainPass + salt; // append salt key
            bool result = Crypto.VerifyHashedPassword(HashedPass, PlainPass); //verify password
            return result;
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            //check if the LOGIN UserId and Password is correct or not
            if (Username.Text.Equals("") || Password.Text.Equals(""))
            {
                Response.Write("<script>alert('Please enter details.')</script>");
                return;
            }
            try
            {
                String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebConnString"].ToString();
                conn1 = new MySql.Data.MySqlClient.MySqlConnection(connString);
                conn1.Open();
                queryStr1 = "";
                queryStr1 = "SELECT * FROM jobapplicationdbschema.admindetails WHERE AdminUsername='" + Username.Text + "';";
                cmd1 = new MySql.Data.MySqlClient.MySqlCommand(queryStr1, conn1);
                reader1 = cmd1.ExecuteReader();
                String Salt = "";
                String HashedPassword = "";
                //for reading the username and password from the database
                while (reader1.HasRows && reader1.Read())
                {
                    Salt = reader1.GetString(reader1.GetOrdinal("SaltKey"));
                    HashedPassword = reader1.GetString(reader1.GetOrdinal("HashedKey"));
                }
                
                //emptying the resources
                queryStr1 = "";
                conn1.Close();
                if (decryptPasssword(Salt,Password.Text,HashedPassword))
                {
                    Session["Validate"] = "OTPPage";
                    Session["Username"] = Username.Text;
                    Session["MoveForward"] = "OTPPage";
                    Response.Redirect("MasterOTPVerificationPage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Incorrect Password')</script>");
                }
                //check if the credentials are the same or not
                //if (USERNAME.Equals(Username.Text) && PASSWORD.Equals(Password.Text))
                //{
                //    Session["Validate"] = "OTPPage";
                //    Session["Username"] = Username.Text;

                //    //Redirecting to the OTP verification page
                //    Response.Redirect("MasterOTPVerificationPage.aspx");
                //}

                //else
                //{
                //    if (USERNAME.Equals(Username.Text))
                //    {
                //        if (PASSWORD.Equals(Password.Text))
                //        {
                //            Response.Write("<script>alert('Something is Wrong contact Helpline')</script>");
                //        }
                //        else
                //        {
                //            Response.Write("<script>alert('Incorrect Password')</script>");
                //        }
                //    }
                //    else
                //    {
                //        Response.Write("<script>alert('Incorrect Credentials')</script>");
                //    }
                //}
            }
            catch (Exception ex)
            {
                Username.Text = ex.ToString();
                Response.Write("<script>alert('Some Error occured during login, Please try loggin in after some time.')</script>");
            }
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            //Redirection to the registration page
            Response.Redirect("MasterRegistrationPage.aspx");
        }

        protected void ForgotPasswordButton_Click(object sender, EventArgs e)
        {
            Session["Username"] = Username.Text;
            Session["Validate"] = "OTPPageForgotpassword";
            Response.Redirect("MasterOTPVerificationPage.aspx");
        }
    }
}