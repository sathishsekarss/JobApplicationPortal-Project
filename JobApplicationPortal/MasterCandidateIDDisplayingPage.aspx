<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEnteringPage.Master" AutoEventWireup="true" CodeBehind="MasterCandidateIDDisplayingPage.aspx.cs" Inherits="JobApplicationPortal.MasterCandidateIDDisplayingPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="MEDesignInstructions.css" rel="stylesheet" />
    <link href="DesignInstructions.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centerpadding" style="margin-top:-6%">
        <div id="rcornersM" style="background-color:#F5F5F5">
            <center>
            <h2>Your Candidate ID is:</h2>
                <br />
                <asp:Label ID="CandidateID" runat="server" Text="NILL" ></asp:Label>
                <br />
                <br />
                <asp:Button ID="DoneButon" runat="server" Text="Done" OnClick="DoneButon_Click" class="buttondesignM" />
        </center>
       </div>
    </div>
</asp:Content>
