<%@ Page Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="ExpenseTracker.User.Feedback" %>
<asp:Content ID="feed1" ContentPlaceHolderID="User1" runat="server">
<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="~/Content/feedback.css" />
</head>
<body>
    <form id="form1" runat="server">
         <div class="form-container">
            <h1 class="form-title">Help Us Improve</h1>
        <div class="form-group">
            <asp:Label ID="nm" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="tnm" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rnm" runat="server" ControlToValidate="tnm" ErrorMessage="please eter your name" ForeColor="Red" CssClass="validation-error"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="email" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="tem" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="remail" runat="server" ControlToValidate="tem" ErrorMessage="please enter your email" ForeColor="Red" CssClass="validation-error">
                <asp:RegularExpressionValidator ID="regemail" runat="server" ControlToValidate="tem" ErrorMessage="please enter in correct format" ForeColor="Red" ValidationExpression="^[^\s@]+@[^\s@]+\.[^\s@]+$" CssClass="validation-error"></asp:RegularExpressionValidator>
            </asp:RequiredFieldValidator>

        </div>
        <div class="form-group">
            <asp:Label ID="msg" runat="server" Text="Feedback" ></asp:Label>
            <asp:TextBox ID="tmsg" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfeed" runat="server" ControlToValidate="tmsg" ForeColor="Red" ErrorMessage="please write here.." CssClass="validation-error"></asp:RequiredFieldValidator>
        </div>
        <asp:Button ID="submit" runat="server" Text="Send" CssClass="submit-btn" OnClick="Click_Send" />
             <asp:Label id="result" runat="server" CssClass="message" Visible="false"></asp:Label>
            </div>
    </form>
</body>
</html>--%>
    <div class="feedback-page">
     <div class="form-container">
    <h1 class="form-title">Help Us Improve</h1>
<div class="form-group">
    <asp:Label ID="nm" runat="server" Text="Name"></asp:Label>
    <asp:TextBox ID="tnm" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rnm" runat="server" ControlToValidate="tnm" ErrorMessage="please eter your name" ForeColor="Red" CssClass="validation-error"></asp:RequiredFieldValidator>
</div>
<div class="form-group">
    <asp:Label ID="email" runat="server" Text="Email"></asp:Label>
    <asp:TextBox ID="tem" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ID="remail" runat="server" ControlToValidate="tem" ErrorMessage="please enter your email" ForeColor="Red" CssClass="validation-error">
        <asp:RegularExpressionValidator ID="regemail" runat="server" ControlToValidate="tem" ErrorMessage="please enter in correct format" ForeColor="Red" ValidationExpression="^[^\s@]+@[^\s@]+\.[^\s@]+$" CssClass="validation-error"></asp:RegularExpressionValidator>
    </asp:RequiredFieldValidator>

</div>
<div class="form-group">
    <asp:Label ID="msg" runat="server" Text="Feedback" ></asp:Label>
    <asp:TextBox ID="tmsg" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfeed" runat="server" ControlToValidate="tmsg" ForeColor="Red" ErrorMessage="please write here.." CssClass="validation-error"></asp:RequiredFieldValidator>
</div>
<asp:Button ID="submit" runat="server" Text="Send" CssClass="submit-btn" OnClick="Click_Send" />
     <asp:Label id="result" runat="server" CssClass="message" Visible="false"></asp:Label>
    </div>
    </div>
</asp:Content>