using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace JobApplicationPortal
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        MySql.Data.MySqlClient.MySqlConnection conn1;
        MySql.Data.MySqlClient.MySqlCommand cmd1;
        MySql.Data.MySqlClient.MySqlDataReader reader1;
        String queryStr1;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LogOutButton_Click(object sender, ImageClickEventArgs e)
        {
            #region Sending the loggout details to the database -> Database Name: AdminDetails
            DateTime LoggedOutTime = DateTime.Now;
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebConnString"].ToString();
            conn1 = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn1.Open();
            queryStr1 = "";
            queryStr1 = "UPDATE admindetails SET LoggedInTime='" + Session["LoggedInTime"].ToString() + "', LoggedOutTime='" + LoggedOutTime + "' WHERE AdminUsername='Admin@Djobs.com';";
            cmd1 = new MySql.Data.MySqlClient.MySqlCommand(queryStr1, conn1);
            reader1 = cmd1.ExecuteReader();
            conn1.Close();
            #endregion

            //redirecting to the login page
            Response.Redirect("LoginPage.aspx");
        }

        protected void UserInfoButton_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Write("<script>alert('Inserted successfully!')</script>");
        }
    }
}