using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Threading;

namespace JobApplicationPortal
{
    public partial class MasterOTPVerificationPage : System.Web.UI.Page
    {
        static String OTP;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["MoveForward"]==null)
            {
                Response.Redirect("MasterLoginPage.aspx");
            }
            if (Session["MoveForward"].ToString().Equals("MainToLoginPage"))
            {
                Response.Redirect("MasterMainPage.aspx");
            }
            if (Session["Validate"].ToString().Equals("OTPPage") || Session["Validate"].ToString().Equals("OTPPageForgotpassword"))
            {
                if (!this.IsPostBack)
                {
                    //Generating OTP
                    OTPPassword.Text = OTP = GenerateOTP();
                }
            }
        }

        private static string _Val;
        public static string Val
        {
            get { return _Val; }
            set { _Val = value; }
        }

        protected String GenerateOTP()
        {
            #region Code to Generate OTP
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";

            string characters = numbers;
            characters += alphabets + small_alphabets + numbers;
            int length = 8;
            string otp = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }
            return otp;
            #endregion
        }

        protected void SubmitButton_Click1(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                if (OTP.Equals(OTPField.Text))
                {
                    OTPPassword.Text = "";
                    OTPPassword.Text = "Correct";
                    if (Session["Validate"].ToString().Equals("OTPPage"))
                    {
                        Session["MoveForward"] = "MainPage";
                        Response.Redirect("MasterMainPage.aspx");
                    }
                    if (Session["Validate"].ToString().Equals("OTPPageForgotpassword"))
                    {
                        Response.Redirect("MasterForgotPasswordPage.aspx");
                    }
                }
                else
                {
                    OTPPassword.Text = "Incorrect";
                }
            }
        }

        public static void CopyText()
        {
            Clipboard.SetText(Val);
        }

        protected void ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Val = OTPPassword.Text;
            Thread staThread = new Thread(new ThreadStart(CopyText));
            staThread.ApartmentState = ApartmentState.STA;
            staThread.Start();
        }
    }
}