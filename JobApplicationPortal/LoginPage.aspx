<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="JobApplicationPortal.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="DesignInstructions.css" rel="stylesheet"/>
    <style type="text/css">
        .auto-style1 {
            height: 558px;
            width: 1361px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <video autoplay muted loop id="myvideo">
            <source src="Background Videos/video.mp4" type="video/mp4"/>
        </video>
        <center class="centerpadding">
            <div id="rcorners1">
                <h2>Enter your Credentials to Login</h2>
                <asp:TextBox ID="Username" placeholder="LoginId"  runat="server" class="TextBoxDesign"/>
                <br />
                <br />
                <asp:TextBox ID="Password" placeholder=" Password" type="password" runat="server" class="TextBoxDesign" />
                <br />
                <br />
                <asp:Button ID="LoginButton" runat="server" Text="Login" CssClass="buttondesign" OnClick="LoginButton_Click" />
                <br />
                <br />
                <asp:Button ID="RegisterButton" runat="server" Text="Register" CssClass="buttondesign" OnClick="RegisterButton_Click" />     <asp:Button Id="ForgotPasswordButton" runat="server" Text="Forgot Password" CssClass="buttondesign" />
            </div>
        </center>
        <center>
        <asp:Label ID="Validate" runat="server" Text="Enter your Credentials"/>
        </center>
        <footer>
            <center><p>	&copy; 2021 DJOBS</p></center>
        </footer>
    </form>
</body>
</html>
