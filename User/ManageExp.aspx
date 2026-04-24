<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="ManageExp.aspx.cs" Inherits="ExpenseTracker.User.ManageExp" %>
<asp:Content ID="manageexp" ContentPlaceHolderID="User1" runat="server">
    <asp:GridView 
        ID="expenses" 
        runat="server" 
        CellPaddin="5"
        BorderWidth="1"
        DataKeyNames="ExpenseId"
        AutoGenerateColumns="false"
        ShowHeaderWhenEmpty="true"
        EmptyDataText="No any expenses added by you."
        OnRowCancelingEdit="exp_canceledit" 
        OnRowEditing="exp_rowedit" 
        OnRowUpdating="exp_rowupdate" 
        OnRowDeleting="exp_delete" 
        GridLines="None" 
        UseAccessibleHeader="true" 
       
        CssClass="grid">

             <Columns>
    <asp:BoundField DataField="ExpenseId" HeaderText="Expense ID" />
                 <asp:BoundField DataField="CategoryName" HeaderText="Category" />
    <asp:BoundField DataField="Amount" HeaderText="Amount" />
                 <asp:BoundField DataField="Description" HeaderText="Description" />
    <asp:BoundField DataField="ExpenseDate" HeaderText="Expense Date" />
         
         
                 <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" HeaderText="Actions" />
</Columns>

    </asp:GridView>
</asp:Content>
