<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForMainPage.Master" AutoEventWireup="true" CodeBehind="MasterViewAllDetails.aspx.cs" Inherits="JobApplicationPortal.MasterViewAllDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body{
            background-color:#F5F5F5;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center style="margin-left:auto;margin-right:auto">
        <div>

            <asp:GridView ID="GridView1" runat="server"  OnRowCommand="ContactsGridView_RowCommand" style="" >
                    <Columns>
                        <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="View Details" ShowHeader="True" Text="View" />
                    </Columns>
             </asp:GridView>

        </div>
    </center>
</asp:Content>
