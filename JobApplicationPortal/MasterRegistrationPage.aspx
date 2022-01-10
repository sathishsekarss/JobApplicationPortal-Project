<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEnteringPage.Master" AutoEventWireup="true" CodeBehind="MasterRegistrationPage.aspx.cs" Inherits="JobApplicationPortal.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="MEDesignInstructions.css" rel="stylesheet" />
    <link href="DesignInstructions.css" rel="stylesheet" />
    <style>
        .table1{
            border:2px solid black;
        }
        /*.bordercode{
            border:1px solid black;
        }
        .tablecell{
            border:1px solid black;
        }*/
        .auto-style3 {
            margin-left: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<center><h2>Enter your Details to Register yourself:</h2></center>--%>
    <center><asp:Label ID="LabelField" runat="server" Text=""></asp:Label></center>
    <div style="margin-right:18%;margin-left:18%;overflow:auto;">
    <table class="bordercode" style="width:100%;margin-top:5%;border:2px solid black;border-radius:20px;background-color:#F5F5F5;overflow-y:auto;border-collapse:separate;border-spacing:4px;" >
               <tr>
                   <td class="tablecell">First Name:</td>
                   <td class="tablecell"><asp:TextBox ID="NameField" runat="server" class="rTextBoxDesign"/></td>
               </tr>
                <tr>
                   <td class="tablecell">Last Name:</td>
                   <td class="tablecell"><asp:TextBox ID="LastNameField" runat="server" class="rTextBoxDesign"/></td>
               </tr>
                <tr>
                   <td class="tablecell">Date of Birth:</td>
                   <td class="tablecell"><asp:TextBox ID="DOBField" runat="server" class="rTextBoxDesign" placeholder="Format:DD-MM-YYYY"/></td>
               </tr>
               <tr>
                   <td class="tablecell">Age:</td>
                   <td class="tablecell"><asp:TextBox ID="AgeField" runat="server" class="rTextBoxDesign"/></td>
               </tr>
                <tr>
                   <td class="tablecell">Sex:</td>
                   <td class="tablecell"><asp:DropDownList ID="SexFieldDropDown" runat="server" CssClass="rTextBoxDesign" style="border:2px solid black;" ></asp:DropDownList></td>
               </tr>
               <tr>
                   <td class="tablecell">Email:</td>
                   <td class="tablecell"><asp:TextBox ID="EmailField" runat="server" class="rTextBoxDesign"/>&nbsp;&nbsp;&nbsp;@&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="Emaildropdown" runat="server" CssClass="rTextBoxDesign" style="border:2px solid black;" ></asp:DropDownList></td>
               </tr>
               <tr>
                   <td class="tablecell">Address 1:</td>
                   <td class="tablecell"><asp:TextBox ID="Address1Field" runat="server" class="rTextBoxDesign"/></td>
               </tr>
               <tr>
                   <td class="tablecell">Address 2:</td>
                   <td class="tablecell"><asp:TextBox ID="Address2Field" runat="server" class="rTextBoxDesign"/></td>
               </tr>
               <tr>
                   <td class="tablecell">Zipcode 2:</td>
                   <td class="tablecell"><asp:TextBox ID="ZipcodeField" runat="server" class="rTextBoxDesign"/></td>
               </tr>
               <tr>
                   <td class="tablecell">Country</td>
                   <td class="tablecell"><asp:DropDownList ID="Countrylist" runat="server" CssClass="rTextBoxDesign" style="border:2px solid black;" ></asp:DropDownList></td>
               </tr>
               <tr>
                   <td class="tablecell">PG/UG details:</td>
                   <td class="tablecell"><asp:DropDownList ID="UGPGField" runat="server" CssClass="rTextBoxDesign" style="border:2px solid black;" ></asp:DropDownList></td>
               </tr>
               <tr>
                   <td class="tablecell">Field of Study:</td>
                   <td class="tablecell"><asp:DropDownList ID="FieldOfStudyField" runat="server" CssClass="rTextBoxDesign" style="border:2px solid black;" ></asp:DropDownList></td>
               </tr>
               <tr>
                   <td class="tablecell">CGPA:</td>
                   <td class="tablecell"><asp:TextBox ID="CGPAField" runat="server" class="rTextBoxDesign" placeholder="Enter CGPA Out of 10" /></td>
               </tr>
               <tr>
                   <td class="tablecell">Mobile Number:</td>
                   <td class="tablecell"><asp:TextBox ID="MobileNumberField" runat="server"  class="rTextBoxDesign" /></td>
               </tr>
               <tr>
                   <td class="tablecell">Resume</td>
                   <td class="tablecell"><asp:FileUpload ID="InputFile" runat="server" /></td>
               </tr>
           </table>
        <br />
        <center><asp:Button ID="CancelButton" runat="server" CssClass="buttondesignM" Text="Cancel" OnClick="CancelButton_Click" />&nbsp;&nbsp;&nbsp;<asp:Button ID="ResetButton" runat="server" CssClass="buttondesignM" text="Reset" OnClick="ResetButton_Click" />&nbsp;&nbsp;&nbsp;<asp:Button ID="Submit" runat="server" CssClass="buttondesignM" Text="Submit" OnClick="Submit_Click" /></center>
        <br />
        <asp:Label ID="StatusCheck" runat="server" Text="" />
    </div>
</asp:Content>
