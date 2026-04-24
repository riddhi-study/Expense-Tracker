<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Index.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ExpenseTracker.Admin.Contact" %>
<asp:Content ID="Contact" ContentPlaceHolderID="Admin1" runat="server">
    <asp:Label ID="con" runat="server" Text="All Contact Us Messages"></asp:Label>
    <asp:GridView ID="cont" runat="server" CssClass="grid"></asp:GridView>
</asp:Content>
