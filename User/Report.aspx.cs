using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace ExpenseTracker.User
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            DBhelp db = new DBhelp();

            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            if (string.IsNullOrEmpty(txtFromDate.Text) ||
                string.IsNullOrEmpty(txtToDate.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
                    "alert", "alert('Please select both dates');", true);
                return;
            }

            

            DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime toDate = Convert.ToDateTime(txtToDate.Text);

            if (fromDate > toDate)
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
                    "alert", "alert('From Date cannot be greater than To Date');", true);
                return;
            }

            string reportType = ddlReportType.SelectedValue;
            int userId = Convert.ToInt32(Session["UserId"]);
            Response.Write(Session["UserID"]);

            //string query = "";

            //if (reportType == "Daily")
            //{
            //    query = @"SELECT 
            //    CAST(ExpenseDate AS DATE) AS ReportDate,
            //    SUM(Amount) AS TotalAmount
            //  FROM Expenses
            //  WHERE UserId = @UserId
            //  AND ExpenseDate >= @FromDate
            //  AND ExpenseDate < @ToDate
            //  GROUP BY CAST(ExpenseDate AS DATE)
            //  ORDER BY ReportDate DESC";


            //}
            //else if (reportType == "Yearly")
            //{

            //    query = @"SELECT 
            //    YEAR(ExpenseDate) AS Year,
            //    SUM(Amount) AS TotalAmount
            //  FROM Expenses
            //  WHERE UserId = @UserId
            //  AND ExpenseDate >= @FromDate
            //  AND ExpenseDate < @ToDate
            //  GROUP BY YEAR(ExpenseDate)
            //  ORDER BY Year DESC";
            //}

            //else if (reportType == "Weekly")
            //{
            //    query = @"SELECT 
            //    DATEPART(YEAR, ExpenseDate) AS Year,
            //    DATEPART(WEEK, ExpenseDate) AS WeekNumber,
            //    SUM(Amount) AS TotalAmount
            //  FROM Expenses
            //  WHERE UserId = @UserId
            //  AND ExpenseDate >= @FromDate
            //  AND ExpenseDate < @ToDate
            //  GROUP BY DATEPART(YEAR, ExpenseDate),
            //           DATEPART(WEEK, ExpenseDate)
            //  ORDER BY Year DESC, WeekNumber DESC";
            //}

            //else if(reportType == "Monthly")
            //{
            //    query = @"SELECT 
            //    DATEPART(YEAR, ExpenseDate) AS Year,
            //    DATEPART(WEEK, ExpenseDate) AS WeekNumber,
            //    SUM(Amount) AS TotalAmount
            //  FROM Expenses
            //  WHERE UserId = @UserId
            //  AND ExpenseDate >= @FromDate
            //  AND ExpenseDate < @ToDate
            //  GROUP BY DATEPART(YEAR, ExpenseDate),
            //           DATEPART(WEEK, ExpenseDate)
            //  ORDER BY Year DESC, WeekNumber DESC";
            //}

            //else if (reportType == "Category")
            //{
            //    query = @"SELECT 
            //    c.name AS CategoryName,
            //    SUM(e.Amount) AS TotalAmount
            //  FROM Expenses e
            //  INNER JOIN category c 
            //      ON e.CategoryId = c.category_id
            //  WHERE e.UserId = @UserId
            //  AND e.ExpenseDate >= @FromDate
            //  AND e.ExpenseDate < @ToDate
            //  GROUP BY c.name
            //  ORDER BY TotalAmount DESC";


            //}

            //string reportType = ddlReportType.SelectedValue;
            //int userId = Convert.ToInt32(Session["UserId"]);

            string query = BuildQuery(reportType);


            // VERY IMPORTANT: handle datetime correctly
            toDate = toDate.AddDays(1);

           

            SqlParameter[] prms = {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate", toDate)
            };

           

            DataTable dt = db.executeSelect(query, prms);


            decimal grandTotal = 0;
            int recordCount = 0;
            decimal average = 0;

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    grandTotal += Convert.ToDecimal(row["TotalAmount"]);
                }

                recordCount = dt.Rows.Count;
                average = grandTotal / recordCount;
            }

            lblTotalExpense.Text = "Total Expense: ₹ " + grandTotal;
            //lblAverageExpense.Text = "Average: ₹ " + average;
            lblAverageExpense.Text = "Average: ₹ " + Math.Round(average, 2);
            lblRecordCount.Text = "Total Records: " + recordCount;

            gvReport.DataSource = dt;
            gvReport.DataBind();

            if (dt != null && dt.Rows.Count > 0)
            {
                var labels = new List<string>();
                var values = new List<decimal>();

                foreach (DataRow row in dt.Rows)
                {
                    labels.Add(row[0].ToString());
                    values.Add(Convert.ToDecimal(row["TotalAmount"]));
                }

                var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

                string jsonLabels = serializer.Serialize(labels);
                string jsonValues = serializer.Serialize(values);
                string chartType = ddlChartType.SelectedValue;

                ClientScript.RegisterStartupScript(this.GetType(), "chartScript",
                    $"renderChart({jsonLabels}, {jsonValues}, '{chartType}');", true);
            }
        }
        protected void btnDownloadPdf_Click(object sender, EventArgs e)
        {
            string reportType = ddlReportType.SelectedValue;

            DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime toDate = Convert.ToDateTime(txtToDate.Text);
            toDate = toDate.AddDays(1);

            int userId = Convert.ToInt32(Session["UserID"]);

            // Reuse your existing query building logic here
            string query = BuildQuery(reportType); // We'll define this properly next

            SqlParameter[] prms = {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate", toDate)
            };

            DBhelp db = new DBhelp();
            DataTable dt = db.executeSelect(query, prms);

            Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter.GetInstance(pdfDoc, memoryStream);

            pdfDoc.Open();

            pdfDoc.Add(new Paragraph("Expense Report"));
            pdfDoc.Add(new Paragraph("Report Type: " + reportType));
            pdfDoc.Add(new Paragraph("Date Range: " + txtFromDate.Text + " to " + txtToDate.Text));
            pdfDoc.Add(new Paragraph(" "));

            PdfPTable table = new PdfPTable(dt.Columns.Count);

            foreach (DataColumn column in dt.Columns)
            {
                table.AddCell(new Phrase(column.ColumnName));
            }

            foreach (DataRow row in dt.Rows)
            {
                foreach (var cell in row.ItemArray)
                {
                    table.AddCell(new Phrase(cell.ToString()));
                }
            }

            //pdfDoc.Add(table);
            //pdfDoc.Close();

            pdfDoc.Add(table);

            // Add some spacing
            pdfDoc.Add(new Paragraph(" "));

            // 🔥 ADD CHART IMAGE HERE
            string base64Image = hfChartImage.Value;

            if (!string.IsNullOrEmpty(base64Image))
            {
                string base64 = base64Image.Split(',')[1];
                byte[] bytes = Convert.FromBase64String(base64);

                iTextSharp.text.Image chartImage =
                    iTextSharp.text.Image.GetInstance(bytes);

                chartImage.ScaleToFit(500f, 400f);
                chartImage.Alignment = Element.ALIGN_CENTER;

                pdfDoc.Add(chartImage);
            }

            pdfDoc.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=ExpenseReport.pdf");
            Response.BinaryWrite(memoryStream.ToArray());
            Response.End();
        }
        private string BuildQuery(string reportType)
        {
            string query = "";

            if (reportType == "Daily")
            {
                query = @"SELECT 
                    CAST(ExpenseDate AS DATE) AS ReportDate,
                    SUM(Amount) AS TotalAmount
                  FROM Expenses
                  WHERE UserId = @UserId
                  AND ExpenseDate >= @FromDate
                  AND ExpenseDate < @ToDate
                  GROUP BY CAST(ExpenseDate AS DATE)
                  ORDER BY ReportDate DESC";
            }
            else if (reportType == "Weekly")
            {
                query = @"SELECT 
                    DATEPART(YEAR, ExpenseDate) AS Year,
                    DATEPART(WEEK, ExpenseDate) AS WeekNumber,
                    SUM(Amount) AS TotalAmount
                  FROM Expenses
                  WHERE UserId = @UserId
                  AND ExpenseDate >= @FromDate
                  AND ExpenseDate < @ToDate
                  GROUP BY DATEPART(YEAR, ExpenseDate),
                           DATEPART(WEEK, ExpenseDate)
                  ORDER BY Year DESC, WeekNumber DESC";
            }
            else if (reportType == "Monthly")
            {
                query = @"SELECT 
                    YEAR(ExpenseDate) AS Year,
                    MONTH(ExpenseDate) AS Month,
                    SUM(Amount) AS TotalAmount
                  FROM Expenses
                  WHERE UserId = @UserId
                  AND ExpenseDate >= @FromDate
                  AND ExpenseDate < @ToDate
                  GROUP BY YEAR(ExpenseDate),
                           MONTH(ExpenseDate)
                  ORDER BY Year DESC, Month DESC";
            }
            else if (reportType == "Yearly")
            {
                query = @"SELECT 
                    YEAR(ExpenseDate) AS Year,
                    SUM(Amount) AS TotalAmount
                  FROM Expenses
                  WHERE UserId = @UserId
                  AND ExpenseDate >= @FromDate
                  AND ExpenseDate < @ToDate
                  GROUP BY YEAR(ExpenseDate)
                  ORDER BY Year DESC";
            }
            else if (reportType == "Category")
            {
                query = @"SELECT 
                    c.name AS CategoryName,
                    SUM(e.Amount) AS TotalAmount
                  FROM Expenses e
                  INNER JOIN category c 
                      ON e.CategoryId = c.category_id
                  WHERE e.UserId = @UserId
                  AND e.ExpenseDate >= @FromDate
                  AND e.ExpenseDate < @ToDate
                  GROUP BY c.name
                  ORDER BY TotalAmount DESC";
            }

            return query;
        }
    }
}