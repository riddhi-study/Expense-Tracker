<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ExpenseTracker.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Expense Tracker</title>
    <meta charset="utf-8" />
    <link rel="stylesheet" href="~/Content/home.css" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
        <%--<h1>Expense Tracker Management System</h1>
        <p>Track your expenses. Analyze your spending. Control your budget.</p>

        <asp:Button ID="btnRegister" runat="server" Text="Register" PostBackUrl="~/Register.aspx" />
        <asp:Button ID="btnLogin" runat="server" Text="Login" PostBackUrl="~/Login.aspx" />

         <h2>Key Features</h2>

        <h3>1. Expense Tracking</h3>
        <p>Add daily expenses, assign categories, and manage your spending easily.</p>

        <h3>2. Reports & Charts</h3>
        <p>View category-wise and monthly reports with visual charts.</p>

        <h3>3. Budget Management</h3>
        <p>Set a monthly budget and receive alerts when you exceed the limit.</p>

         <h2>How It Works</h2>

        <ol>
            <li>Register a new account</li>
            <li>Login to your dashboard</li>
            <li>Add your expenses</li>
            <li>View reports and analytics</li>
            <li>Set and monitor your monthly budget</li>
        </ol>--%>

        <!-- HERO SECTION -->
        <%--<section>
            <h1>Expense Tracker Management System</h1>
            <p>Track your expenses. Analyze your spending. Control your monthly budget.</p>

            <asp:Button ID="btnRegister" runat="server" Text="Register" PostBackUrl="~/User/Register.aspx" />
            <asp:Button ID="btnLogin" runat="server" Text="Login" PostBackUrl="~/User/Login.aspx" />
        </section>

        <hr />

        <!-- FEATURES SECTION -->
        <section>
            <h2>Key Features</h2>

            <h3>1. Expense Tracking</h3>
            <p>Add and manage daily expenses with categories.</p>

            <h3>2. Reports & Analytics</h3>
            <p>View monthly and category-wise reports with charts.</p>

            <h3>3. Budget Management</h3>
            <p>Set a monthly budget and monitor spending limits.</p>
        </section>

        <hr />

        <!-- HOW IT WORKS -->
        <section>
            <h2>How It Works</h2>
            <ol>
                <li>Register a new account</li>
                <li>Login to your dashboard</li>
                <li>Add your expenses</li>
                <li>View reports and charts</li>
                <li>Set and control your monthly budget</li>
            </ol>
        </section>--%>

        <!-- Header -->
        <header>
            <h1>Expense Tracker</h1>
        </header>

        <hr />

        <!-- Hero Section -->
        <section>
            <h2>Take Control of Your Money</h2>
            <p>Track expenses, analyze reports, and manage your monthly budget easily.</p>

            <br />

            <asp:Button ID="btnRegister" runat="server" Text="Register" PostBackUrl="~/User/Register.aspx" />
            &nbsp;
           
            <asp:Button ID="btnLogin" runat="server" Text="Login" PostBackUrl="~/User/Login.aspx" />
        </section>

        <hr />

        <!-- Features -->
        <section>
            <h3>What You Can Do</h3>
            <ul>
                <li>Add and manage daily expenses</li>
                <li>Filter by category and date</li>
                <li>View reports and charts</li>
                <li>Set and monitor monthly budget</li>
            </ul>
        </section>

        <hr />

        <hr />

        <section>
            <h3>How To Use</h3>

            <ol>
                <li>Register a new account</li>
                <li>Login to your dashboard</li>
                <li>Add your daily expenses</li>
                <li>Set your monthly budget</li>
                <li>View reports and monitor spending</li>
            </ol>
        </section>

        <!-- Footer -->
        <footer>
            <div class="footer-content">
                <span>© 2026 Expense Tracker Management System</span>
                <a href="Admin/Login.aspx" class="admin-link">Admin Login</a>
            </div>
        </footer>

    </form>
</body>
</html>
