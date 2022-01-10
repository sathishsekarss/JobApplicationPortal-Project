using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.DataVisualization.Charting;


namespace JobApplicationPortal
{
    public partial class MasterMainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Session["MoveForward"].ToString().Equals("MainPage"))
            {
                Response.Redirect("MasterLoginPage.aspx");
            }

            if (!this.IsPostBack)
            {
                String[] SearchByValues = System.Configuration.ConfigurationManager.AppSettings["SearchDetails"].ToString().Split(',');
                SearchByDrowpDown.DataSource = SearchByValues;
                SearchByDrowpDown.DataBind();
            }

            if (!this.IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["WebConnString"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT CName AS Name,FieldOfStudy,PGUG AS PG_UG,CGPA,CId AS Candidate_ID FROM candidatedetails WHERE CGPA>8.0 LIMIT 8;"))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            da.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }
            }

            if (!this.IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["WebConnString"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT CName,Age FROM candidatedetails", con);
                    con.Open();
                    Series series = Chart1.Series["Series1"];
                    Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        series.Points.AddXY(rdr["CName"].ToString(), rdr["Age"]);
                    }
                }
            }
        }

        public void LoadChart()
        {
            string constr = ConfigurationManager.ConnectionStrings["WebConnString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                MySqlCommand cmd = new MySqlCommand("SELECT CName,Age FROM candidatedetails", con);
                con.Open();
                Series series = Chart1.Series["Series1"];
                Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    series.Points.AddXY(rdr["CName"].ToString(), rdr["Age"]);
                }
            }
        }

        protected void AgeButton_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["WebConnString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                MySqlCommand cmd = new MySqlCommand("SELECT CName,Age FROM candidatedetails", con);
                con.Open();
                Series series = Chart1.Series["Series1"];
                Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    series.Points.AddXY(rdr["CName"].ToString(), rdr["Age"]);
                    //series.Points.AddX(rdr["Zipcode"]);
                }
            }
        }

        protected void ZipcodeButton_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["WebConnString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(DISTINCT CName) AS CandidateName,Zipcode FROM candidatedetails GROUP BY Zipcode", con);
                con.Open();
                Series series = Chart1.Series["Series1"];
                Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    series.Points.AddXY(rdr["Zipcode"].ToString(), rdr["CandidateName"]);
                    //series.Points.AddX(rdr["Zipcode"]);
                }
            }
        }

        protected void CountryButton_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["WebConnString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(DISTINCT CName) AS CandidateName,Country FROM candidatedetails GROUP BY Country", con);
                con.Open();
                Series series = Chart1.Series["Series1"];
                Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    series.Points.AddXY(rdr["Country"].ToString(), rdr["CandidateName"]);
                    //series.Points.AddX(rdr["Zipcode"]);
                }
            }
        }

        protected void CourseButton_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["WebConnString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(DISTINCT CName) AS CandidateName,PGUG FROM candidatedetails GROUP BY PGUG", con);
                con.Open();
                Series series = Chart1.Series["Series1"];
                Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    series.Points.AddXY(rdr["PGUG"].ToString(), rdr["CandidateName"]);
                    //series.Points.AddX(rdr["Zipcode"]);
                }
            }
        }

        protected void ContactsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //code is working -> DO NOT CHANGE
            if (e.CommandName == "Select")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                //label1.Text = "The Row index is : " + rowIndex;

                /*COUNTING THE TOTATL NUMBER OF COLOUMNS*/
                GridViewRow row = GridView1.Rows[rowIndex];
                int CellCount = GridView1.Rows[0].Cells.Count;
                if (CellCount < 10)
                {
                    String name1 = row.Cells[5].Text;
                    Session["CandidateIDG"] = name1;
                    Response.Redirect("WebForm3.aspx");
                }

                /*IF THE GRID IS DISPLAYING THE WILDCARD SEARCH -> "***" */
                //string name = (row.FindControl("CId") as TextBox).Text;
                String name = row.Cells[10].Text;
                //label1.Text = name;
                Session["CandidateIDG"] = name;
                Response.Redirect("WebForm3.aspx");
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            if (SearchDetailsBox.Text.Equals("***"))
            {
                string conr = ConfigurationManager.ConnectionStrings["WebConnString"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(conr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT CName AS Name,FieldOfStudy,PGUG AS PG_UG,CGPA,CId AS Candidate_ID FROM candidatedetails"))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            da.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }
            }
            else if (SearchByDrowpDown.SelectedValue.Equals("Email")) //for searching using the email id
            {
                string conr = ConfigurationManager.ConnectionStrings["WebConnString"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(conr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT CName AS Name,FieldOfStudy,PGUG AS PG_UG,CGPA,CId AS Candidate_ID FROM candidatedetails WHERE Email='" + SearchDetailsBox.Text + "'"))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            da.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }
            }
            else if(SearchByDrowpDown.SelectedValue.Equals("CandidateId"))
            {
                string conr = ConfigurationManager.ConnectionStrings["WebConnString"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(conr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT CName AS Name,FieldOfStudy,PGUG AS PG_UG,CGPA,CId AS Candidate_ID FROM candidatedetails WHERE CId='" + SearchDetailsBox.Text + "'"))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            da.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }
            }
            else if (SearchByDrowpDown.SelectedValue.Equals("Name")) //for searching using the Name
            {
                string conr = ConfigurationManager.ConnectionStrings["WebConnString"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(conr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT CName AS Name,FieldOfStudy,PGUG AS PG_UG,CGPA,CId AS Candidate_ID FROM candidatedetails WHERE CName LIKE '%" + SearchDetailsBox.Text + "%'"))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            da.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }
            }
            else if (SearchByDrowpDown.SelectedValue.Equals("Ph-Number")) //for searching using the Mobile Number
            {
                string conr = ConfigurationManager.ConnectionStrings["WebConnString"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(conr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT CName AS Name,FieldOfStudy,PGUG AS PG_UG,CGPA,CId AS Candidate_ID FROM candidatedetails WHERE MobileNumber='" + SearchDetailsBox.Text + "'"))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            da.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }
            }
            else if(SearchByDrowpDown.SelectedValue.Equals("All")) //Redirects the page for viewing all the details in the database in grid view alone
            {
                Response.Redirect("MasterViewAllDetails.aspx");
            }
            else
            {

            }
            LoadChart();
        }
    }
}