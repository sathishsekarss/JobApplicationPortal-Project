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
    public partial class MasterViewAllDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["WebConnString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT CId as CandidateID,CName AS Name,LastName,Age,Sex, AddressOne AS Address1,AddressTwo AS Address2, PGUG, FieldOfStudy,CGPA,SelectedStatus FROM candidatedetails"))
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
                String name = row.Cells[1].Text;
                //label1.Text = name;
                Session["CandidateIDG"] = name;
                Response.Redirect("WebForm3.aspx");
            }
        }
    }
}