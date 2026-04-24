<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Index.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="ExpenseTracker.Admin.Users" %>
<asp:Content ID="Users" ContentPlaceHolderID="Admin1" runat="server">
    <asp:Label ID="l1" Text="All Users" runat="server"></asp:Label>
    <asp:GridView 
        ID="user" 
        runat="server" 
        CssClass="grid"
        CellPaddin="5"
        BorderWidth="1"
        DataKeyNames="user_id"
        AutoGenerateColumns="false"
        ShowHeaderWhenEmpty="true"
        EmptyDataText="No record found." 
        OnRowCancelingEdit="user_canceledit" 
        OnRowEditing="user_rowedit" 
        OnRowUpdating="user_rowupdate" 
        OnRowDeleting="user_delete" 
        GridLines="None" 
        UseAccessibleHeader="true">

         <Columns>
        <asp:BoundField DataField="user_id" HeaderText="ID" />
        <asp:BoundField DataField="name" HeaderText="Name" />
        <asp:BoundField DataField="email" HeaderText="Email" />
             <asp:BoundField DataField="pswd" HeaderText="Password" />
             <asp:BoundField DataField="status" HeaderText="Status" />
             <asp:BoundField DataField="created_at" HeaderText="Registered at" />
             <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" HeaderText="Actions" />
    </Columns>

        

    </asp:GridView>

    <%--<asp:Button ID="show_active" runat="server" OnClick="show_user"/>
    <asp:Button ID="show_inactive" runat="server" OnClick="show_user"/>--%>
</asp:Content>
