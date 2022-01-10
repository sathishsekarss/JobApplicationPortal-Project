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
    public partial class MasterForgotPasswordPage : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn1;
        MySql.Data.MySqlClient.MySqlCommand cmd1;
        MySql.Data.MySqlClient.MySqlDataReader reader1;
        String queryStr1;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (Password.Text.Equals(Password_Reenter.Text))
            {
                try
                {
                    /*GENERATING HASHED PASSWORD*/
                    String Salt = Crypto.GenerateSalt();
                    String PasswordWithSalth = Password.Text + Salt;
                    String hashedPassword = Crypto.HashPassword(PasswordWithSalth);
                    String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebConnString"].ToString();
                    conn1 = new MySql.Data.MySqlClient.MySqlConnection(connString);
                    conn1.Open();
                    queryStr1 = "";
                    queryStr1 = "UPDATE admindetails SET SaltKey='" + Salt + "', HashedKey='" + hashedPassword + "' WHERE AdminUsername='" + Session["Username"].ToString() + "';";
                    //queryStr1 = "UPDATE admindetails SET AdminPassword='" + Password.Text + "' WHERE AdminUsername='" + Session["Username"].ToString() + "';
                    cmd1 = new MySql.Data.MySqlClient.MySqlCommand(queryStr1, conn1);
                    reader1 = cmd1.ExecuteReader();
                    conn1.Close();
                }
                catch (Exception ex)
                {
                    Status.Text = ex.ToString();
                }
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Password Changed Successfully.');window.location.href='MasterLoginPage.aspx';", true);
            }
            else
            {
                Response.Write("<script>alert('Password Mistmatch')</script>");
            }
        }
    }
}