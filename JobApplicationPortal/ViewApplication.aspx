<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewApplication.aspx.cs" Inherits="JobApplicationPortal.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        table, th, td {
  border:1px solid black;
        }
    </style>
    <link href="DesignInstructions.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <center>
        <div id="rcorners1Table" class="centerpadding" style="margin-left:-35%; margin-top:-5%;">
           <table style="width:100%;" >
               <tr>
                   <td>Candidate ID:</td>
                   <td><asp:Label ID="CandidateIDLabel" runat="server" Text="NILL"></asp:Label></td>
               </tr>
               <tr>
                   <td>Name:</td>
                   <td><asp:Label ID="NameLabel" runat="server" Text="NILL"></asp:Label></td>
               </tr>
               <tr>
                   <td>Age:</td>
                   <td><asp:Label ID="AgeLabel" runat="server" Text="NILL"></asp:Label></td>
               </tr>
               <tr>
                   <td>Email:</td>
                   <td><asp:Label ID="EmailLabel" runat="server" Text="NILL"></asp:Label></td>
               </tr>
               <tr>
                   <td>Address 1:</td>
                   <td><asp:Label ID="Address1Label" runat="server" Text="NILL"></asp:Label></td>
               </tr>
               <tr>
                   <td>Address 2:</td>
                   <td><asp:Label ID="Address2Label" runat="server" Text="NILL"></asp:Label></td>
               </tr>
               <tr>
                   <td>Zipcode 2:</td>
                   <td><asp:Label ID="ZipcodeLabel" runat="server" Text="NILL"></asp:Label></td>
               </tr>
               <tr>
                   <td>Country</td>
                   <td><asp:Label ID="CountryLabel" runat="server" Text="NILL"></asp:Label></td>
               </tr>
               <tr>
                   <td>PG/UG details:</td>
                   <td><asp:Label ID="CourseLabel" runat="server" Text="NILL"></asp:Label></td>
               </tr>
               <tr>
                   <td>Mobile Number:</td>
                   <td><asp:Label ID="MobileNumberLabel" runat="server" Text="NILL"></asp:Label></td>
               </tr>
               <tr>
                   <td>Resume</td>
                   <td><asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="DownloadFile"></asp:LinkButton></td>
               </tr>
           </table>
            </div>
            </center>
    </form>
</body>
</html>
