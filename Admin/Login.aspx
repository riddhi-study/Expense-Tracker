<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ExpenseTracker.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="~/Content/login.css" />
</head>
<body>
    <%--<div class="container">
        <form id="log_admin" runat="server">

            <table>
                <div class="form-control">
                    <tr>
                        <td>Admin Name :
                    <asp:TextBox ID="adnm" runat="server"></asp:TextBox><br />
                        </td>
                    </tr>
                </div>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="reqnm" runat="server" ErrorMessage="please enter name" ControlToValidate="adnm"></asp:RequiredFieldValidator></td>
                </tr>
                <div class="form-control">
                    <tr>
                        <td>Admin Password :
                    <asp:TextBox ID="adpass" runat="server"></asp:TextBox><br />
                        </td>
                    </tr>
                </div>
                <%--<tr>--%>
                <%--<td>
                    <asp:RequiredFieldValidator ID="reqpass" runat="server" ErrorMessage="please enter password" ControlToValidate="adpass"></asp:RequiredFieldValidator></td>
                <%--</tr>--%>
                <%--<tr><td>Confirm Password : <asp:TextBox ID="conpass" runat="server"></asp:TextBox><br /></td></tr>--%>
               <%-- <tr>
                    <td>
                        <asp:Button ID="login" OnClick="Click_Login" Text="Login" runat="server" /></td>
                </tr>
            </table>
        </form>
    </div>--%>
    <form id="form1" runat="server">
    <div class="login-container">
        <div class="login-box">
            <h2>Admin Login</h2>
            <div class="input-group">
                <asp:TextBox ID="tem" runat="server" placeholder="Email" required="required"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="tem" 
                    ErrorMessage="Name is required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="input-group">
                <asp:TextBox ID="pass" runat="server" TextMode="Password" placeholder="Password" required="required"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="pass" 
                    ErrorMessage="Password is required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="Login_Click" CssClass="login-btn" />
        </div>
    </div>
</form>
     <%--<script src="~/js/login.js"></script>--%>


</body>
</html>
