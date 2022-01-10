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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["WebConnString"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT CName AS Name,Age,Email, PGUG,CId FROM candidatedetails"))
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
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        series.Points.AddXY(rdr["CName"].ToString(), rdr["Age"]);
                    }
                }
            }
        }
        //buttonfield_click

        //method for generating chart with values
        //NOT COMPLETED
        protected void GenerateChartWithValues(String value1, String Value2)
        {
            //write the condition to check if the code is working or not
            string constr = ConfigurationManager.ConnectionStrings["WebConnString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                MySqlCommand cmd = new MySqlCommand("SELECT CName,Age FROM candidatedetails", con);
                con.Open();
                Series series = Chart1.Series["Series1"];
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    series.Points.AddXY(rdr["CName"].ToString(), rdr["Age"]);
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
                label1.Text = "The Row index is : "+ rowIndex;

                /*COUNTING THE TOTATL NUMBER OF COLOUMNS*/
                GridViewRow row = GridView1.Rows[rowIndex];
                int CellCount = GridView1.Rows[0].Cells.Count;
                if(CellCount<10)
                {
                    String name1 = row.Cells[5].Text;
                    Session["CandidateIDG"] = name1;
                    Response.Redirect("WebForm3.aspx");
                }

                /*IF THE GRID IS DISPLAYING THE WILDCARD SEARCH -> "***" */ 
                //string name = (row.FindControl("CId") as TextBox).Text;
                String name = row.Cells[10].Text;
                label1.Text = name;
                Session["CandidateIDG"] = name;
                Response.Redirect("WebForm3.aspx");
            }
        }



        protected void buttonfield_click(object sender, GridViewCommandEventArgs e)
        {

            //HiddenField1.Value=
            //Label value=(Label)GridView1.Rows[Convert.ToInt32(e.)]
            String value1 = GridView1.SelectedRow.Cells[1].Text;
            //label1.Text = value1;
            //Session["CandidateIdG"] = value1;
            //session

            Response.Redirect("ViewApplication.aspx");
        }

        #region zipcode
        protected void ZipcodeButton_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["WebConnString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                MySqlCommand cmd = new MySqlCommand("SELECT CName,Zipcode FROM candidatedetails", con);
                con.Open();
                Series series = Chart1.Series["Series1"];
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    series.Points.AddXY(rdr["CName"].ToString(), rdr["Zipcode"]);
                    //series.Points.AddX(rdr["Zipcode"]);
                }
            }
        }
        #endregion
        protected void SearchButton_Click(object sender, EventArgs e)
        {
            if (SearchDetailsBox.Text.Equals("***"))
            {
                string conr = ConfigurationManager.ConnectionStrings["WebConnString"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(conr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM candidatedetails"))
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
            else if(DropDownList.SelectedValue.Equals("Email")) //for searching using the email id
            {
                string conr = ConfigurationManager.ConnectionStrings["WebConnString"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(conr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM candidatedetails WHERE Email='" + SearchDetailsBox.Text + "'"))
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
            else if (DropDownList.SelectedValue.Equals("Name")) //for searching using the Name
            {
                string conr = ConfigurationManager.ConnectionStrings["WebConnString"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(conr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM candidatedetails WHERE CName LIKE '%" + SearchDetailsBox.Text + "%'"))
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
            else if (DropDownList.SelectedValue.Equals("PhNumber")) //for searching using the Mobile Number
            {
                string conr = ConfigurationManager.ConnectionStrings["WebConnString"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(conr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM candidatedetails WHERE MobileNumber='" + SearchDetailsBox.Text + "'"))
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
            else
            {
                
            }
            string constr = ConfigurationManager.ConnectionStrings["WebConnString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                MySqlCommand cmd = new MySqlCommand("SELECT CName,Age FROM candidatedetails", con);
                con.Open();
                Series series = Chart1.Series["Series1"];
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    series.Points.AddXY(rdr["CName"].ToString(), rdr["Age"]);
                }
            }
        }
    }
}