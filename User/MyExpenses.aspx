<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="MyExpenses.aspx.cs" Inherits="ExpenseTracker.User.MyExpenses" %>
<asp:Content ID="MyExpens" ContentPlaceHolderID="User1" runat="server">
    <%-- <div class="content-header">
     <h1 class="content-title"></h1>
     <button class="table-btn">New Report</button>
 </div>--%>

 <div class="cards-grid">
     <div class="card card-primary">
         <div class="card-header">
             <div class="card-title">Total Expense</div>
                 <asp:Label ID="TE" runat="server" Text="0"></asp:Label>
             <%--<div class="card-icon">📊</div>--%>
         </div>
         <%--<div class="card-value">$12,546</div>--%>
         <%--<div style="color: var(--text-light); font-size: 14px;">+12% from last month</div>--%>
     </div>
     <div class="card card-success">
         <div class="card-header">
             <div class="card-title">Mostly used category</div>
                 <asp:Label ID="used_cat" runat="server" Text="0"></asp:Label>
             <%--<div class="card-icon">📈</div>--%>
         </div>
         <%--<div class="card-value">1,234</div>--%>
         <%--<div style="color: var(--text-light); font-size: 14px;">Active users</div>--%>
     </div>
    <%-- <div class="card card-warning">
         <div class="card-header">
             <div class="card-title">Category added</div>
                 <asp:Label ID="add_cat" runat="server" Text="0"></asp:Label>--%>
             <%--<div class="card-icon">🌞</div>--%>
         <%--</div>--%>
         <%--<div class="card-value">567</div>--%>
         <%--<div style="color: var(--text-light); font-size: 14px;">New sessions</div>--%>
     <%--</div>--%>
     <div class="card card-danger">
         <div class="card-header">
             <div class="card-title">Budget</div>
                 <asp:Label ID="BD" runat="server" Text="0"></asp:Label>
             <%--<div class="card-icon">⚠️</div>--%>
         </div>
         <%--<div class="card-value">89</div>--%>
         <%--<div style="color: var(--text-light); font-size: 14px;">Error rate</div>--%>
     </div>
 </div>

 <%--<div class="table-container">--%>
     <%--<div class="table-header">--%>
         <%--<h2 class="table-title">Summary of expenses</h2>--%>
         <%--<button class="table-btn">View All</button>--%>
     <%--</div>--%>
    <%-- <table>
         <thead>
             <tr>
                 <th>Name</th>
                 <th>Position</th>
                 <th>Office</th>
                 <th>Age</th>
                 <th>Start date</th>
                 <th>Salary</th>
             </tr>
         </thead>
         <tbody>
             <tr>
                 <td>Tiger Nixon</td>
                 <td>System Architect</td>
                 <td>Edinburgh</td>
                 <td>61</td>
                 <td>2011/04/25</td>
                 <td>$320,800</td>
             </tr>
             <tr>
                 <td>Garrett Winters</td>
                 <td>Accountant</td>
                 <td>Tokyo</td>
                 <td>63</td>
                 <td>2011/07/25</td>
                 <td>$170,750</td>
             </tr>
         </tbody>
     </table>--%>
     <asp:Label ID="lblBudgetAlert"
    runat="server"
    Font-Bold="true">
</asp:Label>
<br /><br />
 <%--</div>--%>
</asp:Content>
