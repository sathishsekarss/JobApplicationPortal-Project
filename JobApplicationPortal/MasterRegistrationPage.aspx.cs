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
    public partial class WebForm5 : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn1;
        MySql.Data.MySqlClient.MySqlCommand cmd1;
        MySql.Data.MySqlClient.MySqlDataReader reader1;
        String queryStr1;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            if(!this.IsPostBack)
            {
                //FOR LOADING THE DETAILS TO THE DROPDOWN LIST IN THE REGISTRATION PAGE -> SOURCE: WEB CONFIG FILE
                string[] Countrylist_values = System.Configuration.ConfigurationManager.AppSettings["Country"].ToString().Split(',');
                Countrylist.DataSource = Countrylist_values;
                Countrylist.DataBind();
                string[] Emaillist_values = System.Configuration.ConfigurationManager.AppSettings["EmailProvider"].ToString().Split(',');
                Emaildropdown.DataSource = Emaillist_values;
                Emaildropdown.DataBind();
                String[] UGPGValues= System.Configuration.ConfigurationManager.AppSettings["UGPGDetails"].ToString().Split(',');
                UGPGField.DataSource = UGPGValues;
                UGPGField.DataBind();
                String[] SexField= System.Configuration.ConfigurationManager.AppSettings["SexDetails"].ToString().Split(',');
                SexFieldDropDown.DataSource = SexField;
                SexFieldDropDown.DataBind();
                String[] FieldOfStudy= System.Configuration.ConfigurationManager.AppSettings["FeildOfStudyDetails"].ToString().Split(',');
                FieldOfStudyField.DataSource = FieldOfStudy;
                FieldOfStudyField.DataBind();
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Registration cancelled. Redirecting to the Home Page.');window.location.href='MasterLoginPage.aspx';", true);
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            //Set the value of all the Text Boxes and DropDown's to NULL
            NameField.Text = null;
            LastNameField.Text = null;
            AgeField.Text = null;
            DOBField.Text = null;
            SexFieldDropDown.Text= null;
            EmailField.Text = null;
            Address1Field.Text = null;
            Address2Field.Text = null;
            ZipcodeField.Text = null;
            UGPGField.Text = null;
            FieldOfStudyField.SelectedValue = null;
            CGPAField.Text = null;
            MobileNumberField.Text = null;

        }

        #region To display the Registration ID or Candidate ID in the alert box
        public static void MessageBox(System.Web.UI.Page page, int CanidateId)
        {
            //+ character added after strMsg "')"
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + CanidateId + "')", true);
            //alertMessage -> replace by "Your Registration ID is: "
        }
        #endregion

        protected void Submit_Click(object sender, EventArgs e)
        {
            /*****************GENERATION OF REGISTRATION ID OR CANDIDATE ID******************************   */
            int GlobalCandidateId;
            Random rd = new Random();
            int RandomNumber = rd.Next(1000000, 12431324);
            GlobalCandidateId = RandomNumber;

            int DetailsSubmitted = 0;

            /*CODE FOR CHECK THE SIZE OF FILE*/

            /*CHECK FOR THE FILE EXTENSION .DOC OR .DOCX*/
            float fileSize = InputFile.PostedFile.ContentLength;
            string extention = Path.GetExtension(InputFile.FileName);

            if (InputFile.HasFile)
            {
                if (extention.ToLower() != ".docx" && extention.ToLower() != ".pdf" && extention.ToLower() != ".doc")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('File with extenions .doc or .docs are only allowed.');", true);
                    return;
                }
                if (fileSize > 2097152)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Maximum file size allowed is 2 MB');", true);
                    return;
                }
            }


            #region Uploading the information in database -> Database Name: jobapplicationdbschema
            try
            {
                String EMail = EmailField.Text + "@" + Emaildropdown.SelectedValue;

                /* ****************INSERTING THE INFORMATION INTO THE DATABASE********************** */
                String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebConnString"].ToString();
                conn1 = new MySql.Data.MySqlClient.MySqlConnection(connString);
                conn1.Open();
                queryStr1 = "";
                queryStr1 = "INSERT INTO candidatedetails (CName,LastName, Age,DateOfBirth,Sex, Email, AddressOne,AddressTwo,Zipcode,Country,PGUG, FieldOfStudy, CGPA, MobileNumber,CId) VALUES('" + NameField.Text + "','" + LastNameField.Text + "'," + AgeField.Text + ",'" + DOBField.Text+"','"+ SexFieldDropDown.SelectedValue + "','" + EMail + "','" + Address1Field.Text + "','" + Address2Field.Text + "'," + ZipcodeField.Text + ",'" + Countrylist.SelectedValue + "','" + UGPGField.SelectedValue + "','" + FieldOfStudyField.SelectedValue + "','" + CGPAField.Text + "','" + MobileNumberField.Text + "','" + GlobalCandidateId + "')";
                //queryStr1 = "INSERT INTO candidatedetails (CName, Age, Email, AddressOne, AddressTwo, Zipcode, Country, PGUG, MobileNumber, CId) VALUES('" + NameField.Text + "'," + AgeField.Text + ",'" + EMail + "','" + Address1Field.Text + "','" + Address2Field.Text + "'," + ZipcodeField.Text + ",'" + Countrylist.SelectedValue + "','" + UGPGField.SelectedValue + "','" + MobileNumberField.Text + "'," + GlobalCandidateId + ")";
                //queryStr1 = "INSERT INTO candidatedetails (CName, Age, Email, AddressOne, AddressTwo, Zipcode, Country, PGUP, MobileNumber, CId) VALUES ('" + NameField.Text + "','" + AgeField.Text + "','" + EMail + "','" + Address1Field.Text + "','" + Address2Field.Text + "','" + ZipcodeField.Text + "','" + Countrylist.SelectedValue + "','" + "','" + UGPGField.SelectedValue + "','" + MobileNumberField.Text + "'," + GlobalCandidateId + ")";
                cmd1 = new MySql.Data.MySqlClient.MySqlCommand(queryStr1, conn1);
                reader1 = cmd1.ExecuteReader();
                conn1.Close();
                //end of connection for uploading the details in candidate details

                /*
                 * session field not in use........Need to do some testing
                //Session["EmailId"] = EmailField.Text;
                */

                DetailsSubmitted = 1;
                //MessageBox(this, GlobalCandidateId);

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
                StatusCheck.Text = ex.ToString();
                NameField.Text = ex.ToString();
                //Response.Write("<script>alert('Error Uploading Details.')</script>");
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('"+ex.ToString()+"');", true);
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
                                DetailsSubmitted++;
                                Session["GeneratedCandidateID"] = GlobalCandidateId;
                                Response.Redirect("MasterCandidateIDDisplayingPage.aspx");
                            }
                        }
                    }
                }
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            catch (Exception ex)
            {
                NameField.Text = ex.ToString();
                //Response.Write("<script>alert('Error Uploading Details.')</script>");
            }
            #endregion
            //if (DetailsSubmitted == 2)
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + GlobalCandidateId + "');", true);
            //}
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('"+ GlobalCandidateId +"');window.location.href='MasterLoginPage.aspx';", true);
            //MessageBox(this, GlobalCandidateId);
            //ClientScript.RegisterStartupScript(this.GetType(), "MessageBox", "alert('" + GlobalCandidateId + "');", true);
            //ClientScriptManager cs = this.ClientScript;
            //cs.RegisterStartupScript(this.GetType(), "test1", "alert('test1')", true);
            //Response.Write("window.alert('" + GlobalCandidateId + "');");
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>aler('" + GlobalCandidateId + "')</script>");
            Session["GeneratedCandidateID"] = GlobalCandidateId;
            Response.Redirect("MasterCandidateIDDisplayingPage.aspx");
        }
    }
}