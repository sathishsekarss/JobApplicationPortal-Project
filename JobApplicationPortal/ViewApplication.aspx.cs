﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Configuration;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace JobApplicationPortal
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn1;
        MySql.Data.MySqlClient.MySqlCommand cmd1;
        MySql.Data.MySqlClient.MySqlDataReader reader1;
        String queryStr1;

        public static String EncryptInformation(String type, String Information)
        {
            String temp = "";
            int flag = 0;
            if(type.Equals("Email"))
            {
                for (int i = 0; i < Information.Length; i++)
                {
                    if(i<3)
                    {
                        temp += Information[i];
                    }
                    if(Information[i]=='@')
                    {
                        flag = 1;
                    }
                    if(flag==1)
                    {
                        temp += Information[i];
                        continue;
                    }
                    temp += '*';
                }
                return temp;
            }
            return Information;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            String Name;
            //get the sessionID

            //the all the details
            try
            {
                String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebConnString"].ToString();
                conn1 = new MySql.Data.MySqlClient.MySqlConnection(connString);
                conn1.Open();
                queryStr1 = "";
                queryStr1 = "SELECT CName, Age, Email, AddressOne, AddressTwo, Zipcode, Country, PGUG, MobileNumber, CId FROM candidatedetails WHERE CId='"+Session["CandidateIDG"].ToString()+"';";
                cmd1 = new MySql.Data.MySqlClient.MySqlCommand(queryStr1, conn1);
                reader1 = cmd1.ExecuteReader();

                //some labels are not working should check on that
                while (reader1.HasRows && reader1.Read())
                {
                    NameLabel.Text = Name = reader1.GetString(reader1.GetOrdinal("CName"));
                    //AgeLabel.Text = reader1.GetInt32(reader1.GetOrdinal("Age"));
                    //AgeLabel.Text =reader1.GetInt32(reader1.GetInt32("Age")).ToString();
                    AgeLabel.Text = reader1.GetString(reader1.GetOrdinal("Age"));
                    EmailLabel.Text = EncryptInformation("Email", reader1.GetString(reader1.GetOrdinal("Email")));
                    Address1Label.Text = reader1.GetString(reader1.GetOrdinal("AddressOne"));
                    Address2Label.Text = reader1.GetString(reader1.GetOrdinal("AddressTwo"));
                    CountryLabel.Text = reader1.GetString(reader1.GetOrdinal("Country"));
                    CourseLabel.Text = reader1.GetString(reader1.GetOrdinal("PGUG"));
                    MobileNumberLabel.Text = reader1.GetString(reader1.GetOrdinal("MobileNumber"));
                    CandidateIDLabel.Text = reader1.GetString(reader1.GetOrdinal("CId"));
                    //ZipcodeLabel.Text = reader1.GetString(reader1.GetInt32("Zipcode")).ToString();
                    ZipcodeLabel.Text = reader1.GetString(reader1.GetOrdinal("Zipcode"));
                    Session["CId"] = Name;
                }
                conn1.Close();
            }
            catch (Exception ex)
            {
                //CurrentOrderDetails.Text = ex.ToString();
                Address1Label.Text = ex.ToString();
            }

            //code for downloading the resume from the database
        }
        protected void DownloadFile(object sender, EventArgs e)
        {
            //int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["WebConnString"].ToString();
            using (MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(constr))
            {
                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
                {
                    cmd.CommandText = "select Name, Resume, ContentType from dummy_table where CandidateID='"+Session["CandidateIDG"].ToString()+"';";
                    //cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (MySql.Data.MySqlClient.MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["Resume"];
                        contentType = sdr["ContentType"].ToString();
                        fileName = sdr["Name"].ToString();
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
    }
}