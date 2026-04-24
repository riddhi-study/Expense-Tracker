<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="ExpenseTracker.User.Report" %>

<asp:Content ID="repo" ContentPlaceHolderID="User1" runat="server">
     
   
    <%--<div class="container report-container">

    <!-- ===== PAGE TITLE ===== -->
    <div class="row mb-4">
        <div class="col-12">
            <h2 class="fw-bold mb-2">Expense Report</h2>
            <hr />
        </div>
    </div>

    <!-- ===== SUMMARY CARDS ===== -->
    <div class="row mb-4">

        <div class="col-lg-4 col-md-6 mb-3">
            <div class="report-card summary-card">
                <h6>Total Expense</h6>
                <asp:Label ID="lblTotalExpense" runat="server"
                    CssClass="summary-value"></asp:Label>
            </div>
        </div>

        <div class="col-lg-4 col-md-6 mb-3">
            <div class="report-card summary-card">
                <h6>Average Expense</h6>
                <asp:Label ID="lblAverageExpense" runat="server"
                    CssClass="summary-value"></asp:Label>
            </div>
        </div>

        <div class="col-lg-4 col-md-12 mb-3">
            <div class="report-card summary-card">
                <h6>Total Records</h6>
                <asp:Label ID="lblRecordCount" runat="server"
                    CssClass="summary-value"></asp:Label>
            </div>
        </div>

    </div>

    <!-- ===== FILTER SECTION ===== -->
    <div class="report-card p-4 mb-4">
        <div class="row g-3">

            <div class="col-lg-3 col-md-6">
                <label class="form-label">Report Type</label>
                <asp:DropDownList ID="ddlReportType" runat="server"
                    CssClass="form-select">
                    <asp:ListItem Text="Daily" Value="Daily"></asp:ListItem>
                    <asp:ListItem Text="Weekly" Value="Weekly"></asp:ListItem>
                    <asp:ListItem Text="Monthly" Value="Monthly"></asp:ListItem>
                    <asp:ListItem Text="Yearly" Value="Yearly"></asp:ListItem>
                    <asp:ListItem Text="Category Wise" Value="Category"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="col-lg-3 col-md-6">
                <label class="form-label">Chart Type</label>
                <asp:DropDownList ID="ddlChartType" runat="server"
                    CssClass="form-select">
                    <asp:ListItem Text="Bar Chart" Value="bar"></asp:ListItem>
                    <asp:ListItem Text="Pie Chart" Value="pie"></asp:ListItem>
                    <asp:ListItem Text="Line Chart" Value="line"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="col-lg-3 col-md-6">
                <label class="form-label">From Date</label>
                <asp:TextBox ID="txtFromDate" runat="server"
                    CssClass="form-control"
                    TextMode="Date"></asp:TextBox>
            </div>

            <div class="col-lg-3 col-md-6">
                <label class="form-label">To Date</label>
                <asp:TextBox ID="txtToDate" runat="server"
                    CssClass="form-control"
                    TextMode="Date"></asp:TextBox>
            </div>

            <!-- Buttons -->
            <div class="col-12 text-end mt-3">

                <asp:Button ID="btnFilter" runat="server"
                    Text="Apply Filter"
                    CssClass="btn btn-success btn-modern"
                    OnClick="btnFilter_Click" />

                <asp:Button ID="btnDownloadPdf"
                    runat="server"
                    Text="Download PDF"
                    CssClass="btn btn-outline-success btn-modern ms-2"
                    OnClientClick="return captureChartAndDownload();"
                    OnClick="btnDownloadPdf_Click" />

            </div>

        </div>
    </div>

    <!-- ===== TABLE SECTION ===== -->
    <div class="report-card p-4 mb-4">
        <h5 class="mb-3">Detailed Expenses</h5>

        <asp:GridView ID="gvReport" runat="server"
            CssClass="table table-bordered table-striped table-hover"
            EmptyDataText="No records found."
            AutoGenerateColumns="true">
        </asp:GridView>
    </div>

    <!-- ===== CHART SECTION ===== -->
    <div class="report-card p-4">
        <h5 class="mb-3">Expense Visualization</h5>
        <canvas id="reportChart" style="max-height: 300px;"></canvas>
    </div>

    <asp:HiddenField ID="hfChartImage" runat="server" />

</div>--%>
    

<div class="report-container">

    <h2 class="page-title">Expense Report</h2>

    <!-- ===== SUMMARY SECTION ===== -->
    <div class="stats-grid">

        <div class="stat-card">
            <div class="stat-icon">💼</div>
            <div>
                <div class="stat-title">Total Expense</div>
                <asp:Label ID="lblTotalExpense" runat="server" CssClass="stat-value"></asp:Label>
            </div>
        </div>

        <div class="stat-card">
            <div class="stat-icon">📊</div>
            <div>
                <div class="stat-title">Average Expense</div>
                <asp:Label ID="lblAverageExpense" runat="server" CssClass="stat-value"></asp:Label>
            </div>
        </div>

        <div class="stat-card">
            <div class="stat-icon">📋</div>
            <div>
                <div class="stat-title">Total Records</div>
                <asp:Label ID="lblRecordCount" runat="server" CssClass="stat-value"></asp:Label>
            </div>
        </div>

    </div>

    <!-- ===== FILTER SECTION ===== -->
    <div class="filter-section">

        <div class="filter-group">
            <label>Report Type</label>
            <asp:DropDownList ID="ddlReportType" runat="server">
                 
                 <asp:ListItem Text="Daily" Value="Daily"></asp:ListItem>
                 <asp:ListItem Text="Weekly" Value="Weekly"></asp:ListItem>
                 <asp:ListItem Text="Monthly" Value="Monthly"></asp:ListItem>
                 <asp:ListItem Text="Yearly" Value="Yearly"></asp:ListItem>
                 <asp:ListItem Text="Category Wise" Value="Category"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="filter-group">
            <label>Chart Type</label>
            <asp:DropDownList ID="ddlChartType" runat="server">
                <asp:ListItem Text="Bar Chart" Value="bar"></asp:ListItem>
                <asp:ListItem Text="Pie Chart" Value="pie"></asp:ListItem>
                <asp:ListItem Text="Line Chart" Value="line"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="filter-group">
            <label>From</label>
            <asp:TextBox ID="txtFromDate" runat="server" TextMode="Date"></asp:TextBox>
        </div>

        <div class="filter-group">
            <label>To</label>
            <asp:TextBox ID="txtToDate" runat="server" TextMode="Date"></asp:TextBox>
        </div>

        <div class="filter-actions">
            <asp:Button ID="btnFilter" runat="server" Text="Apply Filter" OnClick="btnFilter_Click" CssClass="btn-primary" />
            <asp:Button ID="btnDownloadPdf" runat="server" Text="Download PDF"
                OnClientClick="return captureChartAndDownload();"
                OnClick="btnDownloadPdf_Click"
                CssClass="btn-outline" />
        </div>

    </div>

    <!-- ===== TABLE SECTION ===== -->
    <div class="card-section">
        <h4>Detailed Expenses</h4>
        <asp:GridView ID="gvReport" runat="server" CssClass="custom-table"
            EmptyDataText="No records found."></asp:GridView>
    </div>

    <!-- ===== CHART SECTION ===== -->
    <div class="card-section">
        <h4>Expense Visualization</h4>
        <canvas id="reportChart"></canvas>
    </div>

    <asp:HiddenField ID="hfChartImage" runat="server" />

</div>




   
    <script>
        var chartInstance;

        function renderChart(labels, dataValues, chartType) {

            var ctx = document.getElementById('reportChart').getContext('2d');

            if (chartInstance) {
                chartInstance.destroy();
            }

            chartInstance = new Chart(ctx, {
                type: chartType,
                data: {
                    labels: labels,
                    //datasets: [{
                    //    label: "Expense Report",
                    //    data: dataValues,
                    //    borderWidth: 1
                    //}]
                    datasets: [{
                        label: "Expense Report",
                        data: dataValues,
                        backgroundColor: [
                            '#4CAF50',
                            '#2196F3',
                            '#FF9800',
                            '#E91E63',
                            '#9C27B0',
                            '#00BCD4'
                        ],
                        borderWidth: 1
                    }]
                },
                options: {
                    responsive: true,
                    plugins: {
                        legend: {
                            display: true
                        }
                    }
                }
            });
        }

        function captureChartAndDownload() {

            <%--var canvas = document.getElementById('reportChart');
            var imageData = canvas.toDataURL("image/png");

            document.getElementById('<%= hfChartImage.ClientID %>').value = imageData;

            __doPostBack('<%= btnDownloadPdf.UniqueID %>', '');--%>
            var canvas = document.getElementById('reportChart');

            if (!canvas) {
                alert("Chart not available.");
                return false;
            }

            var imageData = canvas.toDataURL("image/png");

            document.getElementById('<%= hfChartImage.ClientID %>').value = imageData;

            return true; // allow normal postback
        }

        document.addEventListener("DOMContentLoaded", function () {

            var reportDropdown = document.getElementById('<%= ddlReportType.ClientID %>');
            var chartDropdown = document.getElementById('<%= ddlChartType.ClientID %>');

            function updateChartOptions() {


                //var reportType = reportDropdown.value;

                //for (let option of chartDropdown.options) {
                //    option.style.display = "block";
                //}

                //if (reportType === "Category") {
                //    hideOption("line");
                //} else {
                //    hideOption("pie");
                //}
                var reportType = reportDropdown.value;

                for (let option of chartDropdown.options) {
                    option.style.display = "block";
                }

                if (reportType === "Category") {
                    hideOption("line");

                    if (chartDropdown.value === "line") {
                        chartDropdown.value = "pie";
                    }

                } else {

                    hideOption("pie");

                    if (chartDropdown.value === "pie") {
                        chartDropdown.value = "bar";
                    }
                }
            }

            function hideOption(value) {
                for (let option of chartDropdown.options) {
                    if (option.value === value) {
                        option.style.display = "none";
                    }
                }
            }

            reportDropdown.addEventListener('change', updateChartOptions);

            // 🔥 Run once on page load
            updateChartOptions();
        });

    </script>
</asp:Content>

