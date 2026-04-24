<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="AddExpense.aspx.cs" Inherits="ExpenseTracker.User.AddExpense" %>
<asp:Content ID="addexpense" ContentPlaceHolderID="User1" runat="server">
   <%-- <asp:Label ID="cat" runat="server" Text="Category"></asp:Label>
    <asp:DropDownList id="selcat" runat="server"></asp:DropDownList>

    <asp:Label ID="am" runat="server" Text="Amount">Enter Amount</asp:Label>
    <asp:TextBox ID="tam" runat="server"></asp:TextBox> 

    <asp:Label ID="dt" runat="server" Text="Date"></asp:Label>
    <asp:TextBox ID="datte" runat="server" TextMode="Date"></asp:TextBox>

    <asp:Label ID="dec" runat="server" Text="Description"></asp:Label>
    <asp:TextBox ID="des" runat="server" TextMode="MultiLine"></asp:TextBox>

    <asp:Button ID="add" runat="server" Text="Add Expense" OnClick="Add_expense" />
    <asp:Label ID="added" runat="server"></asp:Label>--%>

     <div class="expense-form">
        <div class="form-group">
            <label class="form-label" for="selcat">Category</label>
            <asp:DropDownList id="selcat" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>

        <div class="form-group">
            <label class="form-label" for="tam">Enter Amount</label>
            <asp:TextBox ID="tam" runat="server" CssClass="form-control" placeholder="0.00"></asp:TextBox>
        </div>

        <div class="form-group">
            <label class="form-label" for="datte">Date</label>
            <asp:TextBox ID="datte" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label class="form-label" for="des">Description</label>
            <asp:TextBox ID="des" runat="server" TextMode="MultiLine" CssClass="form-control" placeholder="Enter details..." Rows="4"></asp:TextBox>
        </div>

        <asp:Button ID="add" runat="server" Text="Add Expense" OnClick="Add_expense" CssClass="btn-add" />

        <asp:Label ID="added" runat="server" CssClass="message" Visible="false"></asp:Label>
    </div>
</asp:Content>
