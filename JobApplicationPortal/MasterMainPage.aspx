<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForMainPage.Master" AutoEventWireup="true" CodeBehind="MasterMainPage.aspx.cs" Inherits="JobApplicationPortal.MasterMainPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="MEDesignInstructions.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sides">
    <div class="container" style="display: flex; height: auto;">
        <div style="width: 50%;border:2px solid black; height: auto;background-color:#F5F5F5;">
            <center><h2>CHART</h2></center>
            <center>
            <asp:Chart ID="Chart1" runat="server" style="margin-top:5%;border:2px solid black;">
                <Series>
                    <asp:Series Name="Series1">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
           </center>
            <br />
            <br />
            <center><asp:Button ID="AgeButton" runat="server" Text="Age" OnClick="AgeButton_Click" CssClass="buttondesignM" />&nbsp;&nbsp;&nbsp;<asp:Button ID="ZipcodeButtong" runat="server" Text="Zipcode" onclick="ZipcodeButton_Click" CssClass="buttondesignM" />&nbsp;&nbsp;&nbsp;<asp:Button ID="CountryButton" runat="server" Text="Country" OnClick="CountryButton_Click" CssClass="buttondesignM" />&nbsp;&nbsp;&nbsp;<asp:Button ID="CourseButton" runat="server" Text="UG/PG" OnClick="CourseButton_Click" CssClass="buttondesignM" /></center>
            <br />
            <br />
        </div>
        <div style="flex-grow: 1;border:2px solid black;height: auto; overflow:auto;background-color:#F5F5F5">
            <center><h2>TABLE</h2></center>
            <center><asp:TextBox ID="SearchDetailsBox" runat="server" Placeholder="Search" CssClass="SearchTextBoxDesign" style="height: 29px; margin-top:8%"/>&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="SearchByDrowpDown" runat="server" CssClass="SearchByDropDownValue" ></asp:DropDownList>&nbsp;&nbsp;&nbsp;<asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="searchButtonDesign" OnClick="SearchButton_Click" /></center>
            <center>
                
                <asp:GridView ID="GridView1" runat="server" style="margin-top:12%;margin-left:5%;margin-right:5%;margin-bottom:20%;" OnRowCommand="ContactsGridView_RowCommand" >
                    <Columns>
                        <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="View Details" ShowHeader="True" Text="View" />
                    </Columns>
                </asp:GridView>
                
            </center>
        </div>
    </div>
</div>
</asp:Content>
