<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration Page.aspx.cs" Inherits="JobApplicationPortal.Registration_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">               
    <title></title>
    <link href="DesignInstructions.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <center>
        <div>
            <img src="Background Images/Registration Page Image.jpg" class="rbackgroundimage" />
            <div class="rcentered" id="rrcorners1">
                <p class="rtextalign">Name:     <asp:TextBox ID="NameField" runat="server" class="rTextBoxDesign"/></p>
                <p class="rtextalign">Age:      <asp:TextBox ID="AgeField" runat="server" class="rTextBoxDesign"/></p>
                <p class="rtextalign">Email:    <asp:TextBox ID="EmailField" runat="server" class="rTextBoxDesign"/></p>
                <p class="rtextalign">Address1: <asp:TextBox ID="Address1Field" runat="server" class="rTextBoxDesign"/></p>
                <p class="rtextalign">Address2: <asp:TextBox ID="Address2Field" runat="server" class="rTextBoxDesign"/></p>
                <p class="rtextalign">Zipcode:  <asp:TextBox ID="ZipcodeField" runat="server" class="rTextBoxDesign"/></p>
                <p class="rtextalign">Country: <asp:DropDownList ID="dropdownlist" runat="server">
                    <asp:ListItem>India</asp:ListItem>
                    <asp:ListItem>USA</asp:ListItem>
                    <asp:ListItem>Britain</asp:ListItem>
                    <asp:ListItem>Germany</asp:ListItem>
                    <asp:ListItem>Italy</asp:ListItem>  
                    <asp:ListItem>Japan</asp:ListItem>
                    <asp:ListItem>China</asp:ListItem>
                    <asp:ListItem>Thailand</asp:ListItem>
                    <asp:ListItem>USA West</asp:ListItem>
                    </asp:DropDownList></p>
                <!--<p class="rtextalign">Country:  <asp:TextBox ID="CountryField" runat="server" class="rTextBoxDesign" /></p>-->
                <p class="rtextalign">PG/UG:    <asp:TextBox ID="CourseField" runat="server" class="rTextBoxDesign"/></p>
                <p class="rtextalign">Ph Number:<asp:TextBox ID="MobileNumberField" runat="server" class="rTextBoxDesign" /></p>
                <p class="rtextalign">Resume:   <asp:FileUpload ID="InputFile" runat="server" /></p>
                <br />
                <asp:Button ID="CancelButton" runat="server" Text="Canel" CssClass="buttondesign" /><asp:Button ID="ResetButton" runat="server" Text="Reset" CssClass="buttondesign" /><asp:Button ID="SubmitButton" runat="server" Text="Register" CssClass="buttondesign" OnClick="SubmitButton_Click" />
            </div>
        </div>
            <asp:Label ID="Status" runat="server" Text="" />
            <br />
            <br />
            <asp:Label ID="CandidateID" runat="server" Text="" />
        </center>
    </form>
</body>
</html>
