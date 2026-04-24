<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Index.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="ExpenseTracker.Admin.Dashboard" %>
<asp:Content ID="Dash1" ContentPlaceHolderID="Admin1" runat="server">

    <%--<div class="cards-grid">--%>
   <%-- <div class="card card-primary">
        <div class="card-header">
            <div class="card-title">Total Users</div>
         </div>
      </div>--%>
    <%--</div>--%>
    <div>
    <div class="cards-grid">
        <div class="card card-primary">
        <div class="card-header">
            <div class="card-title">Total Users</div>
                <asp:Label ID="total_user" runat="server" Text="0"></asp:Label>
            <%--<div class="card-icon">📊</div>--%>
        </div>
        <%--<div class="card-value">$12,546</div>
        <div style="color: var(--text-muted); font-size: 14px;">+12% from last month</div>--%>
    </div>
    <div class="card card-success">
        <div class="card-header">
            <div class="card-title">Total Expense Categories</div>
                <asp:Label ID="exp_cat" runat="server" Text="0"></asp:Label>
            <%--<div class="card-icon">📈</div>--%>
        </div>
        <%--<div class="card-value">1,234</div>
        <div style="color: var(--text-muted); font-size: 14px;">Active users</div>--%>
    </div>
    <div class="card card-warning">
        <div class="card-header">
            <div class="card-title">Total Feedbacks</div>
                <asp:Label ID="total_feed" runat="server" Text="0"></asp:Label>
            <%--<div class="card-icon">🌞</div>--%>
        </div>
        <%--<div class="card-value">567</div>
        <div style="color: var(--text-muted); font-size: 14px;">New sessions</div>--%>
    </div>
   <%-- <div class="card card-danger">
        <div class="card-header">
            <div class="card-title">Total Contact Us</div>--%>
            <%--<div class="card-icon">⚠️</div>--%>
        <%--</div>--%>
        <%--<div class="card-value">89</div>
        <div style="color: var(--text-muted); font-size: 14px;">Error rate</div>--%>
    </div>
</div>
</div>
</asp:Content>
