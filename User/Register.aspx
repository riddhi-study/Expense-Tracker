<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ExpenseTracker.User.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="~/Content/reg.css" />
</head>
<body>
    <div class="register-card">
        <form id="form1" runat="server">
       
            <div class="register-header">
                <h2>Expense Tracker</h2>
                <p class="text-muted mb-0">Create your account to start tracking expenses</p>
            </div>
           <div class="form-floating">
                        <asp:Label ID="name" runat="server" Text="Name" CssClass="form-label"></asp:Label>
           
                        <asp:TextBox ID="nm" runat="server" CssClass="form-control"></asp:TextBox></div>
                        <asp:RequiredFieldValidator ID="rnm" runat="server" ControlToValidate="nm" ErrorMessage="please enter your name" ForeColor="Red"></asp:RequiredFieldValidator>
                        <%--<asp:CustomValidator ID="cnm" runat="server" ControlToValidate="nm" ErrorMessage="do not enter numbers or special charachters" ForeColor="Red"></asp:CustomValidator>--%>
                    

                <div class="form-floating">
                        <asp:Label ID="email" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                
                        <asp:TextBox ID="em" runat="server" CssClass="form-control"></asp:TextBox></div>
                        <asp:RequiredFieldValidator ID="remail" runat="server" ControlToValidate="em" ErrorMessage="please enter email" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rxem" runat="server" ControlToValidate="em" ErrorMessage="please enter email in the correct format" ValidationExpression="^[^\s@]+@[^\s@]+\.[^\s@]+$" ForeColor="Red"></asp:RegularExpressionValidator>
                
                    <div class="form-floating">
                    <asp:Label ID="pass" runat="server" Text="Password" CssClass="form-label"></asp:Label>
                
                        <asp:TextBox ID="pas" runat="server" CssClass="form-control"></asp:TextBox></div>
                        <asp:RequiredFieldValidator ID="rpas" runat="server" ControlToValidate="pas" ErrorMessage="please enter password" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator
                            ID="rvpas"
                            runat="server"
                            ControlToValidate="pas"
                            ValidationExpression="^.{8,10}$"
                            ErrorMessage="Password must be 8–10 characters long"
                            ForeColor="Red" />
                    
                        <div class="form-floating">
                        <asp:Label ID="cpass" runat="server" Text="Confirm Password" CssClass="form-label"></asp:Label>
                    
                        <asp:TextBox ID="tpass" runat="server" CssClass="form-control"></asp:TextBox></div>
                        <asp:RequiredFieldValidator ID="rcp" runat="server" ControlToValidate="tpass" ErrorMessage="confirm your password" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cpas" runat="server" ControlToValidate="tpass" ControlToCompare="pas" ErrorMessage="please enter the correct password" ForeColor="Red"></asp:CompareValidator>
                    
                    
                        <asp:Button ID="reg" runat="server" Text="Register" OnClick="Click_reg" CssClass="btn-register" />

                        <asp:HyperLink 
                            ID="lnkLogin" 
                            runat="server" 
                            NavigateUrl="Login.aspx"
                            CssClass="login-link">
                            Already have an account? Login
                        </asp:HyperLink>
                

        
    </form>
</div>
</body>
</html>
