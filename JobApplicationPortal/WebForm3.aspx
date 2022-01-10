<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForMainPage.Master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="JobApplicationPortal.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /*.table1, .th1, .td1 {
  border:1px solid black;
        }*/
        .bordercode{
            border:1px solid black;
        }
        .tablecell{
            border:1px solid black;
        }
        body{
            background-color:#898F9C;
        }
    </style>
    <link href="MEDesignInstructions.css" rel="stylesheet" />
    <link href="DesignInstructions.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <center><asp:Label ID="StatusMessage" Text="Data Retrieved Successfully" runat="server" ></asp:Label></center>
    <div style="margin-left:18%;margin-right:18%;margin-top:2.5%;">
    <table class="bordercode" style="width:100%;border-radius:12px;background-color:#F5F5F5;" >
               <tr>
                   <td class="tablecell">Candidate ID:</td>
                   <td class="tablecell"><asp:Label ID="CandidateIDLabel" runat="server" Text="NILL"></asp:Label></td>
               </tr>
               <tr>
                   <td class="tablecell">Name:</td>
                   <td class="tablecell"><asp:Label ID="NameLabel" runat="server" Text="NILL"></asp:Label></td>
               </tr>
                <tr>
                   <td class="tablecell">Last Name:</td>
                   <td class="tablecell"><asp:Label ID="LastNameField" runat="server" Text="NILL"></asp:Label></td>
               </tr>
               <tr>
                   <td class="tablecell">Age:</td>
                   <td class="tablecell"><asp:Label ID="AgeLabel" runat="server" Text="NILL"></asp:Label></td>
               </tr>
                <tr>
                   <td class="tablecell">Date Of Birth:</td>
                   <td class="tablecell"><asp:Label ID="DOBLabel" runat="server" Text="NILL"></asp:Label></td>
               </tr>
                <tr>
                   <td class="tablecell">Sex:</td>
                   <td class="tablecell"><asp:Label ID="SexLabel" runat="server" Text="NILL"></asp:Label></td>
               </tr>
               <tr>
                   <td class="tablecell">Email:</td>
                   <td class="tablecell"><asp:Label ID="EmailLabel" runat="server" Text="NILL"></asp:Label></td>
               </tr>
               <tr>
                   <td class="tablecell">Address 1:</td>
                   <td class="tablecell"><asp:Label ID="Address1Label" runat="server" Text="NILL"></asp:Label></td>
               </tr>
               <tr>
                   <td class="tablecell">Address 2:</td>
                   <td class="tablecell"><asp:Label ID="Address2Label" runat="server" Text="NILL"></asp:Label></td>
               </tr>
               <tr>
                   <td class="tablecell">Zipcode 2:</td>
                   <td class="tablecell"><asp:Label ID="ZipcodeLabel" runat="server" Text="NILL"></asp:Label></td>
               </tr>
               <tr>
                   <td class="tablecell">Country</td>
                   <td class="tablecell"><asp:Label ID="CountryLabel" runat="server" Text="NILL"></asp:Label></td>
               </tr>
               <tr>
                   <td class="tablecell">PG/UG details:</td>
                   <td class="tablecell"><asp:Label ID="CourseLabel" runat="server" Text="NILL"></asp:Label></td>
               </tr>
                <tr>
                   <td class="tablecell">Field of Study:</td>
                   <td class="tablecell"><asp:Label ID="FieldOfStudyLabel" runat="server" Text="NILL"></asp:Label></td>
               </tr>
                <tr>
                   <td class="tablecell">CGPA:</td>
                   <td class="tablecell"><asp:Label ID="CGPALabel" runat="server" Text="NILL"></asp:Label></td>
               </tr>
               <tr>
                   <td class="tablecell">Mobile Number:</td>
                   <td class="tablecell"><asp:Label ID="MobileNumberLabel" runat="server" Text="NILL"></asp:Label></td>
               </tr>
               <tr>
                   <td class="tablecell">Resume</td>
                   <td class="tablecell"><asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="DownloadFile"></asp:LinkButton></td>
               </tr>
           </table>
    </div>
    <br />
    <center><asp:Button ID="RejectCandidateButton" runat="server" CssClass="buttondesignM" Text="Reject" OnClick="RejectCandidateButton_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="SelectCandidateButton" runat="server" CssClass="buttondesignM" Text="Select" OnClick="SelectCandidateButton_Click" /></center>
    <br />
</asp:Content>
