<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ExpenseTracker.User.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="~/Content/user_login.css" />
</head>
<body>
    <div class="container">
    <form id="form1" runat="server" class="login-card">
       
        
            <%--<table>
                <tr>--%>
                     
  
    <h2 class="login-header">Expense Tracker</h2>
    <p style="text-align:center; color:#1B5E20;">Sign in to your account</p>

    <div class="form-floating">
      <label class="form-label" for="tnm">Username</label>
      <asp:TextBox ID="tnm" runat="server" CssClass="form-control" placeholder="Enter Username" />
    </div>

    <div class="form-floating">
      <label class="form-label" for="tpass">Password</label>
      <asp:TextBox ID="tpass" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter Password" />
    </div>

    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="Click_Login" CssClass="btn-login" />

        <asp:HyperLink 
            ID="lnkLogin" 
            runat="server" 
            NavigateUrl="Register.aspx"
            CssClass="reg-link">
            Don't have an account? Register
        </asp:HyperLink>
    </form>

    </div>
<%--            <img src="<%= ResolveUrl("~/Images/fingerprint.jpg") %>" />--%>
            


</body>
</html>
