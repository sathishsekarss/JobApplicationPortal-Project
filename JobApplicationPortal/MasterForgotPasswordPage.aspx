<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEnteringPage.Master" AutoEventWireup="true" CodeBehind="MasterForgotPasswordPage.aspx.cs" Inherits="JobApplicationPortal.MasterForgotPasswordPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="MEDesignInstructions.css" rel="stylesheet" />
    <link href="DesignInstructions.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centerpadding" style="margin-top:-6%">
        <div id="rcornersM" style="background-color:#F5F5F5">
            <center>
            <h2>Create New Password</h2>
                <asp:TextBox ID="Password" placeholder="Enter your New Password"  runat="server" class="TextBoxDesignM"/>
                <br />
                <br />
                <asp:TextBox ID="Password_Reenter" placeholder="Reenter your New Password" type="password" runat="server" CssClass="TextBoxDesignM"  />
                <br />
                <br />
                <asp:Button ID="LoginButton" runat="server" Text="Submit" CssClass="buttondesignM" OnClick="SubmitButton_Click"  />
                <br />
        </center>
       </div>
    </div>
    <asp:Label ID="Status" runat="server" Text="" />
</asp:Content>
