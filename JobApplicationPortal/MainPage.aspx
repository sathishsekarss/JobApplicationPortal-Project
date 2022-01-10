<%@ Page Title="" Language="C#" MasterPageFile="~/MasterContent.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="JobApplicationPortal.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="DesignInstructions.css" rel="stylesheet" />
    <style type="text/css">
        .floatleftside{
            float: left;  
           width: 50%;  
           height: 100px;  
           text-align: center;  
           margin-right:45%;
           margin-top:5%;

        }
        .floatrightside{
            float: right;  
           width: 50%;  
           height: 120%;  
           text-align: center;
           align-content:center;

           border: 2px solid black;
           overflow:auto;
           margin-top:-5%;
           margin-right:0.8%;
        }
        .floatrightsidetable{
            float: right;  
           width: 50%;  
           height: 120%;  
           text-align: center;
           align-content:center;

           border: 2px solid black;
           overflow:auto;
           margin-top:-5%;
           margin-right:0.8%;
        }
        .forTextBox{
            padding-left:50px;
            margin-left:-25%;
            margin-top:0%;
            margin-bottom:2px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="floatleftside">
    <asp:Chart ID="Chart1" runat="server" Height="320px" Width="400px">
        <Series>
            <asp:Series Name="Series1" YValuesPerPoint="2" ChartType="Pie">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
        <center><asp:Button ID="AgeButton" runat="server" Text="Age" />&nbsp;&nbsp;&nbsp;<asp:Button ID="ZipcodeButtong" runat="server" Text="Zipcode" onclick="ZipcodeButton_Click" />&nbsp;&nbsp;&nbsp;<asp:Button ID="CountryButton" runat="server" Text="Country" />&nbsp;&nbsp;&nbsp;<asp:Button ID="CourseButton" runat="server" Text="UG/PG" /></center>
        </div>
    <div class="floatrightside">
     <center><asp:TextBox ID="SearchDetailsBox" runat="server" CssClass="forTextBox" style="height: 29px" />&nbsp;&nbsp;&nbsp;Search by: &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DropDownList" runat="server">
            <asp:ListItem>Name</asp:ListItem>
            <asp:ListItem>Email</asp:ListItem>
            <asp:ListItem>PhNumber</asp:ListItem>
        </asp:DropDownList>&nbsp;&nbsp;&nbsp;<asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" /></center>
    <asp:GridView ID="GridView1" runat="server"  Height="198px" Width="339px" onrowcommand="ContactsGridView_RowCommand" >
        <Columns>
            <%--<asp:HyperLinkField HeaderText="View Details"  NavigateUrl="ViewApplication.aspx" Text="View Details" />--%>
            <asp:TemplateField>
                <ItemTemplate>
                    <%--<button Id="ButtonField" onclick="buttonfield_click">button</button>--%>
                    <%--<asp:Button ID="ButtonField" OnClick="buttonfield_click" runat="server" Text="View" />--%>
                    <asp:Button Text="View" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" HeaderText="View Details"  />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
        <asp:HiddenField Id="HiddenField1" runat="server" />
        <asp:label Id="label1" runat="server" Text="NILL"></asp:label>
     </div>
</asp:Content>
