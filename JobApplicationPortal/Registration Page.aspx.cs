using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace JobApplicationPortal
{
    public partial class Registration_Page : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn1;
        MySql.Data.MySqlClient.MySqlCommand cmd1;
        MySql.Data.MySqlClient.MySqlDataReader reader1;
        String queryStr1;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region To display the Registration ID or Candidate ID in the alert box
        public static void MessageBox(System.Web.UI.Page page, int RandomNumber)
        {
            //+ character added after strMsg "')"
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "Your Registration ID is: ", "alert('"+  RandomNumber + "')", true);
            //alerMessage -> replace by "Your Registration ID is: "
        }
        #endregion

        //not completed
        public static void Upload_document(object sender, EventArgs e)
        {
            
        }


        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            /*****************GENERATION OF REGISTRATION ID OR CANDIDATE ID******************************   */
            int GlobalCandidateId;
            Random rd = new Random();
            int RandomNumber = rd.Next(1000000, 12431324);
            GlobalCandidateId = RandomNumber;

            /*CODE FOR CHECK THE SIZE OF FILE*/

            #region Uploading the information in database -> Database Name: jobapplicationdbschema
            try
            {
                /* ****************INSERTING THE INFORMATION INTO THE DATABASE********************** */
                String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebConnString"].ToString();
                conn1 = new MySql.Data.MySqlClient.MySqlConnection(connString);
                conn1.Open();
                queryStr1 = "";
                queryStr1 = "INSERT INTO candidatedetails (CName, Age, Email, AddressOne, AddressTwo, Zipcode, Country, PGUG, MobileNumber, CId) VALUES('" + NameField.Text + "'," + AgeField.Text + ",'" + EmailField.Text + "','" + Address1Field.Text + "','" + Address2Field.Text + "'," + ZipcodeField.Text + ",'" + dropdownlist.SelectedValue + "','" + CourseField.Text + "','" + MobileNumberField.Text + "'," + GlobalCandidateId + ")";
                cmd1 = new MySql.Data.MySqlClient.MySqlCommand(queryStr1, conn1);
                reader1 = cmd1.ExecuteReader();
                conn1.Close();
                //end of connection for uploading the details in candidate details

                /*
                 * session field not in use........Need to do some testing
                //Session["EmailId"] = EmailField.Text;
                */

                //calling the MessageBox method for display the Candidate Id or Registration Id in the alert box
                MessageBox(this, RandomNumber);

                //**********code is working but need to be modified for updating in the database*************
                //conn1.Open();
                //queryStr1 = "INSERT INTO dummy_table (CandidateID) VALUES('" + RandomNumber + "');";
                //cmd1 = new MySql.Data.MySqlClient.MySqlCommand(queryStr1, conn1);
                //reader1 = cmd1.ExecuteReader();
                //conn1.Close();
                //end of connection in uploading the Candidate Id in dummy_table
            }
            catch (Exception ex)
            {
                Status.Text = ex.Message;
            }
            #endregion

            #region For uploadind the Files into the database
            try
            {
                string filename = Path.GetFileName(InputFile.PostedFile.FileName);
                string contentType = InputFile.PostedFile.ContentType;
                using (Stream fs = InputFile.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        string constr = ConfigurationManager.ConnectionStrings["WebConnString"].ConnectionString;
                        using (MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(constr))
                        {
                            string query = "insert into dummy_table values (@CandidateID,@Name, @ContentType, @Resume)";
                            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query))
                            {
                                cmd.Connection = con;
                                //cmd.Parameters.AddWithValue("@Email", Session["EmailId"].ToString());
                                cmd.Parameters.AddWithValue("@CandidateID", GlobalCandidateId);
                                cmd.Parameters.AddWithValue("@Name", filename);
                                cmd.Parameters.AddWithValue("@ContentType", contentType);
                                cmd.Parameters.AddWithValue("@Resume", bytes);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                    }
                }
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            catch (Exception ex)
            {
                Status.Text = ex.ToString();
            }
            #endregion
        }

        protected void dropdownlist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}