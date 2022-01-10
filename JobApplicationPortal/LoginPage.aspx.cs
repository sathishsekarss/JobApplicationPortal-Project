using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace JobApplicationPortal
{
    public partial class LoginPage : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn1;
        MySql.Data.MySqlClient.MySqlCommand cmd1;
        MySql.Data.MySqlClient.MySqlDataReader reader1;
        String queryStr1;
        protected void Page_Load(object sender, EventArgs e)
        {
            //creating a session id and storing the login time

            if (!this.IsPostBack)
            {
                DateTime now = DateTime.Now;
                Session["LoggedInTime"] = now;
            }
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration Page.aspx");
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (Username.Text.Equals("") || Password.Text.Equals(""))
            {
                Validate.Text = "Please enter the details";
                return;
            }
            try
            {
                String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebConnString"].ToString();
                conn1 = new MySql.Data.MySqlClient.MySqlConnection(connString);
                conn1.Open();
                queryStr1 = "";
                queryStr1 = "SELECT * FROM jobapplicationdbschema.admindetails WHERE AdminUsername='" + Username.Text + "' AND AdminPassword='" + Password.Text + "'";
                cmd1 = new MySql.Data.MySqlClient.MySqlCommand(queryStr1, conn1);
                reader1 = cmd1.ExecuteReader();
                String USERNAME = "";
                String PASSWORD = "";
                //for reading the username and password from the database
                while (reader1.HasRows && reader1.Read())
                {
                    USERNAME = reader1.GetString(reader1.GetOrdinal("AdminUsername"));
                    PASSWORD = reader1.GetString(reader1.GetOrdinal("AdminPassword"));
                }
                //emptying the resources
                queryStr1 = "";
                //check if the credentials are the same or not
                if (USERNAME.Equals(Username.Text) && PASSWORD.Equals(Password.Text))
                {
                    Session["Validate"] = 1234;
                    Session["Username"] = Username.Text;
                    Response.Redirect("OTP Verification page.aspx");
                }

                else
                {
                    if (USERNAME.Equals(Username.Text))
                    {
                        if (PASSWORD.Equals(Password.Text))
                        {
                            Validate.Text = "Something is wrong. Contact helpline.";
                        }
                        else
                        {
                            Validate.Text = "Password is incorrect";
                        }
                    }
                    else
                    {
                        Validate.Text = "Incorrect credentials";
                    }
                }
                conn1.Close();
            }
            catch (Exception ex)
            {
                Validate.Text = "There is some error";
            }
        }
    }
}