<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Budget.aspx.cs" Inherits="ExpenseTracker.User.Budget" %>
<asp:Content ID="budget" ContentPlaceHolderID="User1" runat="server">
    <%--<div class="container mt-4">

    <h3 class="mb-4">Set Budget</h3>

    <!-- Tabs -->
    <ul class="nav nav-tabs" id="budgetTab" role="tablist">
        <li class="nav-item">
            <button class="nav-link active" id="monthly-tab"
                data-bs-toggle="tab"
                data-bs-target="#monthly"
                type="button">
                Monthly Budget
            </button>
        </li>
        <li class="nav-item">
            <button class="nav-link" id="category-tab"
                data-bs-toggle="tab"
                data-bs-target="#category"
                type="button">
                Category Budget
            </button>
        </li>
    </ul>

    <div class="tab-content border border-top-0 p-4 bg-white">

        <!-- ================= MONTHLY TAB ================= -->
        <div class="tab-pane fade show active" id="monthly">

            <div class="row mb-3">
                <div class="col-md-4">
                    <label>Month</label>
                    <asp:DropDownList ID="ddlMonthMonthly" runat="server" CssClass="form-control">
                        <asp:ListItem Text="January" Value="1" />
                        <asp:ListItem Text="February" Value="2" />
                        <asp:ListItem Text="March" Value="3" />
                        <asp:ListItem Text="April" Value="4" />
                        <asp:ListItem Text="May" Value="5" />
                        <asp:ListItem Text="June" Value="6" />
                        <asp:ListItem Text="July" Value="7" />
                        <asp:ListItem Text="August" Value="8" />
                        <asp:ListItem Text="September" Value="9" />
                        <asp:ListItem Text="October" Value="10" />
                        <asp:ListItem Text="November" Value="11" />
                        <asp:ListItem Text="December" Value="12" />
                    </asp:DropDownList>
                </div>

                <div class="col-md-4">
                    <label>Year</label>
                    <asp:DropDownList ID="ddlYearMonthly" runat="server" CssClass="form-control">
                        <asp:ListItem Text="2025" />
                        <asp:ListItem Text="2026" />
                        <asp:ListItem Text="2027" />
                    </asp:DropDownList>
                </div>

                <div class="col-md-4">
                    <label>Budget Amount (₹)</label>
                    <asp:TextBox ID="txtMonthlyAmount" runat="server"
                        CssClass="form-control"
                        TextMode="Number" />
                </div>
            </div>

            <asp:Button ID="btnSaveMonthly"
                runat="server"
                Text="Save Monthly Budget"
                CssClass="btn btn-primary" />

        </div>


        <!-- ================= CATEGORY TAB ================= -->
        <div class="tab-pane fade" id="category">

            <div class="row mb-3">
                <div class="col-md-3">
                    <label>Month</label>
                    <asp:DropDownList ID="ddlMonthCategory" runat="server" CssClass="form-control">
                        <asp:ListItem Text="January" Value="1" />
                        <asp:ListItem Text="February" Value="2" />
                        <asp:ListItem Text="March" Value="3" />
                        <asp:ListItem Text="April" Value="4" />
                        <asp:ListItem Text="May" Value="5" />
                        <asp:ListItem Text="June" Value="6" />
                        <asp:ListItem Text="July" Value="7" />
                        <asp:ListItem Text="August" Value="8" />
                        <asp:ListItem Text="September" Value="9" />
                        <asp:ListItem Text="October" Value="10" />
                        <asp:ListItem Text="November" Value="11" />
                        <asp:ListItem Text="December" Value="12" />
                    </asp:DropDownList>
                </div>

                <div class="col-md-3">
                    <label>Year</label>
                    <asp:DropDownList ID="ddlYearCategory" runat="server" CssClass="form-control">
                        <asp:ListItem Text="2025" />
                        <asp:ListItem Text="2026" />
                        <asp:ListItem Text="2027" />
                    </asp:DropDownList>
                </div>

                <div class="col-md-3">
                    <label>Category</label>
                    <asp:DropDownList ID="ddlCategory"
                        runat="server"
                        CssClass="form-control">
                      
                        
                    </asp:DropDownList>
                </div>

                <div class="col-md-3">
                    <label>Budget Amount (₹)</label>
                    <asp:TextBox ID="txtCategoryAmount"
                        runat="server"
                        CssClass="form-control"
                        TextMode="Number" />
                </div>
            </div>

            <asp:Button ID="btnSaveCategory"
                runat="server"
                Text="Save Category Budget"
                CssClass="btn btn-success" />

        </div>

    </div>


    <!-- ================= EXISTING BUDGETS TABLE ================= -->

    <div class="mt-5">
        <h5>Existing Budgets</h5>

        <asp:GridView ID="gvBudgets"
            runat="server"
            CssClass="table table-bordered table-striped mt-3"
            AutoGenerateColumns="false">

            <Columns>
                <asp:BoundField DataField="BudgetMonth" HeaderText="Month" />
                <asp:BoundField DataField="BudgetYear" HeaderText="Year" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category" />
                <asp:BoundField DataField="BudgetAmount" HeaderText="Amount (₹)" />

                <asp:CommandField ShowEditButton="true" />
                <asp:CommandField ShowDeleteButton="true" />
            </Columns>

        </asp:GridView>
    </div>

</div>--%>

   <%-- <div style="padding:20px;">

        <h3>Set Budget</h3>

        <!-- Toggle Buttons -->
        <asp:Button ID="btnShowMonthly"
            runat="server"
            Text="Monthly Budget"
            OnClick="btnShowMonthly_Click" />

        <asp:Button ID="btnShowCategory"
            runat="server"
            Text="Category Budget"
            OnClick="btnShowCategory_Click" />

        <hr />

        <!-- ================= MONTHLY PANEL ================= -->
        <asp:Panel ID="pnlMonthly" runat="server">

            <h4>Monthly Budget</h4>

            <p>
                Month:
                <asp:DropDownList ID="ddlMonthMonthly" runat="server">
                    <asp:ListItem Text="January" Value="1" />
                    <asp:ListItem Text="February" Value="2" />
                    <asp:ListItem Text="March" Value="3" />
                    <asp:ListItem Text="April" Value="4" />
                    <asp:ListItem Text="May" Value="5" />
                    <asp:ListItem Text="June" Value="6" />
                    <asp:ListItem Text="July" Value="7" />
                    <asp:ListItem Text="August" Value="8" />
                    <asp:ListItem Text="September" Value="9" />
                    <asp:ListItem Text="October" Value="10" />
                    <asp:ListItem Text="November" Value="11" />
                    <asp:ListItem Text="December" Value="12" />
                </asp:DropDownList>
            </p>

            <p>
                Year:
                <asp:DropDownList ID="ddlYearMonthly" runat="server">
                    <asp:ListItem Text="2025" />
                    <asp:ListItem Text="2026" />
                    <asp:ListItem Text="2027" />
                </asp:DropDownList>
            </p>

            <p>
                Budget Amount:
                <asp:TextBox ID="txtMonthlyAmount"
                    runat="server"
                    TextMode="Number" />
            </p>

            <asp:Button ID="btnSaveMonthly"
                runat="server"
                Text="Save Monthly Budget" OnClick="btnSaveMonthly_Click"/>

        </asp:Panel>

        <!-- ================= CATEGORY PANEL ================= -->
        <asp:Panel ID="pnlCategory"
            runat="server"
            Visible="false">

            <h4>Category Budget</h4>

            <p>
                Month:
                <asp:DropDownList ID="ddlMonthCategory" runat="server">
                    <asp:ListItem Text="January" Value="1" />
                    <asp:ListItem Text="February" Value="2" />
                    <asp:ListItem Text="March" Value="3" />
                    <asp:ListItem Text="April" Value="4" />
                    <asp:ListItem Text="May" Value="5" />
                    <asp:ListItem Text="June" Value="6" />
                    <asp:ListItem Text="July" Value="7" />
                    <asp:ListItem Text="August" Value="8" />
                    <asp:ListItem Text="September" Value="9" />
                    <asp:ListItem Text="October" Value="10" />
                    <asp:ListItem Text="November" Value="11" />
                    <asp:ListItem Text="December" Value="12" />
                </asp:DropDownList>
            </p>

            <p>
                Year:
                <asp:DropDownList ID="ddlYearCategory" runat="server">
                    <asp:ListItem Text="2025" />
                    <asp:ListItem Text="2026" />
                    <asp:ListItem Text="2027" />
                </asp:DropDownList>
            </p>

            <p>
                Category:
                <asp:DropDownList ID="ddlCategory"
                    runat="server">
                </asp:DropDownList>
            </p>

            <p>
                Budget Amount:
                <asp:TextBox ID="txtCategoryAmount"
                    runat="server"
                    TextMode="Number" />
            </p>

            <asp:Button ID="btnSaveCategory"
                runat="server"
                Text="Save Category Budget" OnClick="btnSaveCategory_Click" />

        </asp:Panel>

        <hr />

        <!-- ================= EXISTING BUDGETS ================= -->

        <h4>Existing Budgets</h4>

        <asp:Label ID="lblMessage" 
            runat="server" 
            ForeColor="Green" 
            EnableViewState="false">
        </asp:Label>
        <br /><br />

        <asp:GridView ID="gvBudgets"
            runat="server"
            AutoGenerateColumns="false"
             DataKeyNames="BudgetId"
    OnRowDeleting="gvBudgets_RowDeleting">

            <Columns>
                <asp:BoundField DataField="BudgetMonth" HeaderText="Month" />
                <asp:BoundField DataField="BudgetYear" HeaderText="Year" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category" />
                <%--<asp:BoundField DataField="BudgetAmount" HeaderText="Amount" />--%>
<%--                            <asp:BoundField 
                DataField="BudgetAmount" 
                HeaderText="Amount (₹)" 
                DataFormatString="{0:N2}" 
                HtmlEncode="false" />--%>

                <%--<asp:CommandField ShowEditButton="true" />--%>
                <%--<asp:CommandField ShowDeleteButton="true" />
            </Columns>

        </asp:GridView>

    </div>--%>

    <div class="bdg-wrapper">

    <!-- Page Title -->
    <div class="bdg-header">
        <h2>Budget Management</h2>
        <p>Set and manage your monthly and category budgets</p>
    </div>

    <!-- Toggle Buttons -->
    <div class="bdg-tabs">
        <asp:Button ID="btnShowMonthly"
            runat="server"
            Text="Monthly Budget"
            CssClass="bdg-tab-btn"
            OnClick="btnShowMonthly_Click" />

        <asp:Button ID="btnShowCategory"
            runat="server"
            Text="Category Budget"
            CssClass="bdg-tab-btn bdg-tab-outline"
            OnClick="btnShowCategory_Click" />
    </div>


    <!-- ================= MONTHLY PANEL ================= -->
    <asp:Panel ID="pnlMonthly" runat="server" CssClass="bdg-card">

        <h3 class="bdg-card-title">Set Monthly Budget</h3>

        <div class="bdg-row">
            <div class="bdg-field">
                <label>Month</label>
                <asp:DropDownList ID="ddlMonthMonthly" runat="server" CssClass="bdg-input">
                    <asp:ListItem Text="January" Value="1" />
                    <asp:ListItem Text="February" Value="2" />
                    <asp:ListItem Text="March" Value="3" />
                    <asp:ListItem Text="April" Value="4" />
                    <asp:ListItem Text="May" Value="5" />
                    <asp:ListItem Text="June" Value="6" />
                    <asp:ListItem Text="July" Value="7" />
                    <asp:ListItem Text="August" Value="8" />
                    <asp:ListItem Text="September" Value="9" />
                    <asp:ListItem Text="October" Value="10" />
                    <asp:ListItem Text="November" Value="11" />
                    <asp:ListItem Text="December" Value="12" />
                </asp:DropDownList>
            </div>

            <div class="bdg-field">
                <label>Year</label>
                <asp:DropDownList ID="ddlYearMonthly" runat="server" CssClass="bdg-input">
                    <asp:ListItem Text="2025" />
                    <asp:ListItem Text="2026" />
                    <asp:ListItem Text="2027" />
                </asp:DropDownList>
            </div>
        </div>

        <div class="bdg-field">
            <label>Budget Amount (₹)</label>
            <asp:TextBox ID="txtMonthlyAmount"
                runat="server"
                TextMode="Number"
                CssClass="bdg-input" />
        </div>

        <asp:Button ID="btnSaveMonthly"
            runat="server"
            Text="Save Monthly Budget"
            CssClass="bdg-btn"
            OnClick="btnSaveMonthly_Click" />

    </asp:Panel>



    <!-- ================= CATEGORY PANEL ================= -->
    <asp:Panel ID="pnlCategory"
        runat="server"
        Visible="false"
        CssClass="bdg-card">

        <h3 class="bdg-card-title">Category Budget</h3>

        <div class="bdg-row">
            <div class="bdg-field">
                <label>Month</label>
                <asp:DropDownList ID="ddlMonthCategory" runat="server" CssClass="bdg-input">
                    <asp:ListItem Text="January" Value="1" />
                    <asp:ListItem Text="February" Value="2" />
                    <asp:ListItem Text="March" Value="3" />
                    <asp:ListItem Text="April" Value="4" />
                    <asp:ListItem Text="May" Value="5" />
                    <asp:ListItem Text="June" Value="6" />
                    <asp:ListItem Text="July" Value="7" />
                    <asp:ListItem Text="August" Value="8" />
                    <asp:ListItem Text="September" Value="9" />
                    <asp:ListItem Text="October" Value="10" />
                    <asp:ListItem Text="November" Value="11" />
                    <asp:ListItem Text="December" Value="12" />
                </asp:DropDownList>
            </div>

            <div class="bdg-field">
                <label>Year</label>
                <asp:DropDownList ID="ddlYearCategory" runat="server" CssClass="bdg-input">
                    <asp:ListItem Text="2025" />
                    <asp:ListItem Text="2026" />
                    <asp:ListItem Text="2027" />
                </asp:DropDownList>
            </div>

            <div class="bdg-field">
                <label>Category</label>
                <asp:DropDownList ID="ddlCategory"
                    runat="server"
                    CssClass="bdg-input">
                </asp:DropDownList>
            </div>
        </div>

        <div class="bdg-field">
            <label>Budget Amount (₹)</label>
            <asp:TextBox ID="txtCategoryAmount"
                runat="server"
                TextMode="Number"
                CssClass="bdg-input" />
        </div>

        <asp:Button ID="btnSaveCategory"
            runat="server"
            Text="Save Category Budget"
            CssClass="bdg-btn"
            OnClick="btnSaveCategory_Click" />

    </asp:Panel>



    <!-- ================= EXISTING BUDGETS ================= -->

    <div class="bdg-card">

        <h3 class="bdg-card-title">Existing Budgets</h3>

        <asp:Label ID="lblMessage"
            runat="server"
            CssClass="bdg-message"
            EnableViewState="false">
        </asp:Label>

        <asp:GridView ID="gvBudgets"
            runat="server"
            CssClass="bdg-table"
            AutoGenerateColumns="false"
            DataKeyNames="BudgetId"
            OnRowDeleting="gvBudgets_RowDeleting">

            <Columns>
                <asp:BoundField DataField="BudgetMonth" HeaderText="Month" />
                <asp:BoundField DataField="BudgetYear" HeaderText="Year" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category" />
                <asp:BoundField
                    DataField="BudgetAmount"
                    HeaderText="Amount (₹)"
                    DataFormatString="{0:N2}"
                    HtmlEncode="false" />
                <asp:CommandField ShowDeleteButton="true" />
            </Columns>

        </asp:GridView>

    </div>

</div>


</asp:Content>
