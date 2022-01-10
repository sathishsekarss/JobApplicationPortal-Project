<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEnteringPage.Master" AutoEventWireup="true" CodeBehind="MasterLoginPage.aspx.cs" Inherits="JobApplicationPortal.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="MEDesignInstructions.css" rel="stylesheet" />
    <link href="DesignInstructions.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Login Box Code -->
    <div class="centerpadding" style="margin-top:-6%">
        <div id="rcornersM" style="background-color:#F5F5F5">
            <center>
            <h2>Enter your Credentials to Login</h2>
                <asp:TextBox ID="Username" placeholder="LoginId"  runat="server" class="TextBoxDesignM"/>
                <br />
                <br />
                <asp:TextBox ID="Password" placeholder=" Password" type="password" runat="server" class="TextBoxDesignM" />
                <br />
                <br />
                <asp:Button ID="LoginButton" runat="server" Text="Login" CssClass="buttondesignM" OnClick="LoginButton_Click" />
                <br />
                <br />
                <asp:Button ID="RegisterButton" runat="server" Text="Register" CssClass="buttondesignM" OnClick="RegisterButton_Click" />     <asp:Button Id="ForgotPasswordButton" runat="server" Text="Forgot Password" CssClass="buttondesignM" OnClick="ForgotPasswordButton_Click" />
        </center>
       </div>
    </div>
</asp:Content>
