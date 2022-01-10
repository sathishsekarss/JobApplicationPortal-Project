<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEnteringPage.Master" AutoEventWireup="true" CodeBehind="MasterOTPVerificationPage.aspx.cs" Inherits="JobApplicationPortal.MasterOTPVerificationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="MEDesignInstructions.css" rel="stylesheet" />
    <link href="DesignInstructions.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centerpadding" style="margin-top:-2%" >
        <div id="rcornersM" style="background-color:#F5F5F5;">
            <center>
            <h2>OTP Verification</h2>
                <asp:TextBox ID="OTPField" placeholder="OTP"  runat="server" class="TextBoxDesignM"/>
                <br />
                <br />
                <p>Your One Time Password is:</p>
                <asp:Label ID="OTPPassword" runat="server" Text="NILL"/>&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="ImageButton" ImageUrl="~/Icons/Copy Icon.png" runat="server" Height="17px" OnClick="ImageButton_Click" Width="21px" />
                <br />
                <br />
                <asp:Button ID="SubmitButton" Text="Submit" runat="server" CssClass="buttondesignM" OnClick="SubmitButton_Click1"  />
        </center>
       </div>
    </div>
</asp:Content>
