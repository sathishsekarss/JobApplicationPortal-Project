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
    public partial class MasterForMainPage : System.Web.UI.MasterPage
    {
        //Global Variables for MYSQL Connection
        MySql.Data.MySqlClient.MySqlConnection conn1;
        MySql.Data.MySqlClient.MySqlCommand cmd1;
        MySql.Data.MySqlClient.MySqlDataReader reader1;
        String queryStr1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Session["MoveForward"].ToString().Equals("MainPage"))
            {
                Response.Redirect("MasterLoginPage.aspx");
            }
            if(Session["MoveForward"]==null)
            {
                Response.Redirect("MasterLoginPage.aspx");
            }

            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebConnString"].ToString();
            conn1 = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn1.Open();
            queryStr1 = "";
            queryStr1 = "SELECT AdminName, LoggedInTime, LoggedOutTime FROM Admindetails WHERE AdminUsername='Admin@Djobs.com';";
            cmd1 = new MySql.Data.MySqlClient.MySqlCommand(queryStr1, conn1);
            reader1 = cmd1.ExecuteReader();
            //for reading the username and password from the database
            while (reader1.HasRows && reader1.Read())
            {
                AdminName.Text = reader1.GetString(reader1.GetOrdinal("AdminName"));
                LogInTime.Text = reader1.GetString(reader1.GetOrdinal("LoggedInTime"));
                LogOutTime.Text = reader1.GetString(reader1.GetOrdinal("LoggedOutTime"));
            }
            conn1.Close();
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
            Session["MoveForward"] = null;
            Response.Redirect("MasterLoginPage.aspx");
        }
    }
}