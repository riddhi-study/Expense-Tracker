using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpenseTracker.User
{
    public partial class MyExpenses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSummaryData();
                CheckBudgetAlert();

            }
        }
        //        private void LoadSummaryData()
        //        {
        //            DBhelp db = new DBhelp();

        //            int userId = Convert.ToInt32(Session["UserID"]); // Get logged-in user ID

        //            // Query total expenses for user
        //            string queryTotalExpense = "SELECT ISNULL(SUM(amount), 0) as TotalExpense FROM Expenses WHERE UserId = @UserID";
        //            SqlParameter[] parametersTotal = { new SqlParameter("@UserID", userId) };
        //            DataTable dtTotal = db.executeSelect(queryTotalExpense, parametersTotal);

        //            if (dtTotal.Rows.Count > 0)
        //            {
        //                TE.Text = dtTotal.Rows[0]["TotalExpense"].ToString();
        //            }

        //            // Query mostly used category (example)
        //            string queryCategory = @"
        //             SELECT TOP 1 c.name AS category, COUNT(e.ExpenseId) AS UsageCount
        //FROM Expenses e
        //INNER JOIN category c ON e.CategoryId = c.category_id
        //WHERE e.UserId = @UserID   -- replace with a real user id
        //GROUP BY c.name
        //ORDER BY UsageCount DESC;";

        //            DataTable dtCategory = db.executeSelect(queryCategory, parametersTotal);

        //            if (dtCategory != null && dtCategory.Rows.Count > 0 && used_cat != null)
        //            {
        //                var categoryValue = dtCategory.Rows[0]["category"];
        //                used_cat.Text = categoryValue != DBNull.Value ? categoryValue.ToString() : string.Empty;
        //            }



        //            // You can add more queries similarly for Category added, Budget, etc.
        //        }

        private void LoadSummaryData()
        {
            DBhelp db = new DBhelp();

            if (Session["UserID"] == null)
            {
                TE.Text = "User not logged in";
                BD.Text = "User not logged in";
                return;
            }

            int userId = Convert.ToInt32(Session["UserID"]);

            // Total Expenses
            string queryTotalExpense = "SELECT ISNULL(SUM(amount), 0) as TotalExpense FROM Expenses WHERE UserId = @UserID";
            SqlParameter[] parametersTotal = { new SqlParameter("@UserID", userId) };
            DataTable dtTotal = db.executeSelect(queryTotalExpense, parametersTotal);

            if (dtTotal != null && dtTotal.Rows.Count > 0)
                TE.Text = dtTotal.Rows[0]["TotalExpense"].ToString();
            else
                TE.Text = "0";

            // Mostly used category
            string queryCategory = @"
                SELECT TOP 1 c.name AS category, COUNT(e.ExpenseId) AS UsageCount
                FROM Expenses e
                INNER JOIN category c ON e.CategoryId = c.category_id
                WHERE e.UserId = @Userid
                GROUP BY c.name
                ORDER BY UsageCount DESC";
            SqlParameter[] paracat = { new SqlParameter("@UserID",userId)};


            if (parametersTotal == null)
            {
                used_cat.Text = "Parameters are null";
                return;
            }

            DataTable dtCategory = db.executeSelect(queryCategory, paracat);

            if (dtCategory == null)
            {
                used_cat.Text = "DataTable is null";
            }
            else if (dtCategory.Rows.Count == 0)
            {
                used_cat.Text = "No rows returned";
            }
            else if (used_cat == null)
            {
                // Control not found
            }
            else
            {
                var categoryValue = dtCategory.Rows[0]["category"];
                used_cat.Text = categoryValue != DBNull.Value ? categoryValue.ToString() : "No category";
            }

            //Budget

            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            string queryBudget = @"
                SELECT BudgetAmount
                FROM Budget
                WHERE UserId = @UserID
                AND CategoryId IS NULL
                AND BudgetMonth = @Month
                AND BudgetYear = @Year";

            SqlParameter[] paramBud =
            {
                new SqlParameter("@UserID", userId),
                new SqlParameter("@Month", month),
                new SqlParameter("@Year", year)
            };

            DataTable dtbud = db.executeSelect(queryBudget, paramBud);

            if (dtbud != null && dtbud.Rows.Count > 0)
                BD.Text = dtbud.Rows[0]["BudgetAmount"].ToString();
            else
                BD.Text = "0";
        }

        private void CheckBudgetAlert()
        {
            DBhelp db = new DBhelp();

            int userId = Convert.ToInt32(Session["UserID"]);
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            // 1️⃣ Get Monthly Budget
            string budgetQuery = @"
                SELECT BudgetAmount
                FROM Budget
                WHERE UserId=@UserId
                AND CategoryId IS NULL
                AND BudgetMonth=@Month
                AND BudgetYear=@Year";

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@Month", month),
                new SqlParameter("@Year", year)
            };

            DataTable budgetDt = db.executeSelect(budgetQuery, param);

            if (budgetDt.Rows.Count == 0)
            {
                lblBudgetAlert.ForeColor = System.Drawing.Color.Blue;
                lblBudgetAlert.Text = "ℹ No monthly budget set for this month.";
                return;
            }

            decimal monthlyBudget = Convert.ToDecimal(budgetDt.Rows[0]["BudgetAmount"]);

            // 2️⃣ Get Total Expenses
            string expenseQuery = @"
                SELECT ISNULL(SUM(Amount),0)
                FROM Expenses
                WHERE UserId=@UserId
                AND MONTH(ExpenseDate)=@Month
                AND YEAR(ExpenseDate)=@Year";

            SqlParameter[] paramexp = new SqlParameter[]
           {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@Month", month),
                new SqlParameter("@Year", year)
           };

            DataTable expenseDt = db.executeSelect(expenseQuery, paramexp);

            //decimal totalExpense = Convert.ToDecimal(expenseDt.Rows[0][0]);

            decimal totalExpense = 0;

            if (expenseDt != null && expenseDt.Rows.Count > 0)
            {
                totalExpense = Convert.ToDecimal(expenseDt.Rows[0][0]);
            }

            decimal percentage = 0;

            if (monthlyBudget > 0)
                percentage = (totalExpense / monthlyBudget) * 100;

            // 3️⃣ Decide Alert
            if (percentage >= 100)
            {
                lblBudgetAlert.ForeColor = System.Drawing.Color.Red;
                lblBudgetAlert.Text = "🚨 Budget Exceeded! You have used " + percentage.ToString("0") + "% of your monthly budget.";
            }
            else if (percentage >= 80)
            {
                lblBudgetAlert.ForeColor = System.Drawing.Color.Orange;
                lblBudgetAlert.Text = "⚠ Warning: You have used " + percentage.ToString("0") + "% of your monthly budget.";
            }
            else
            {
                lblBudgetAlert.ForeColor = System.Drawing.Color.Green;
                lblBudgetAlert.Text = "✅ You are within your budget (" + percentage.ToString("0") + "% used).";
            }
        }


    }
}