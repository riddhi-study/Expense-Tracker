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
    public partial class Budget : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategories();
                BindBudgets();
            }
        }
        private void BindCategories()
        {
            DBhelp db = new DBhelp();

            string query = "SELECT category_id, name FROM category";

        //    SqlParameter[] param = new SqlParameter[]
        //    {
        //new SqlParameter("@UserId", Session["UserId"])
        //    };

            DataTable dt = db.executeSelect(query, null);

            ddlCategory.DataSource = dt;
            ddlCategory.DataTextField = "name";
            ddlCategory.DataValueField = "category_id";
            ddlCategory.DataBind();

            ddlCategory.Items.Insert(0, new ListItem("-- Select Category --", "0"));
        }
        protected void btnShowMonthly_Click(object sender, EventArgs e)
        {
            pnlMonthly.Visible = true;
            pnlCategory.Visible = false;

            btnShowMonthly.CssClass = "bdg-tab-btn";
            btnShowCategory.CssClass = "bdg-tab-btn bdg-tab-outline";
        }

        protected void btnShowCategory_Click(object sender, EventArgs e)
        {
            pnlMonthly.Visible = false;
            pnlCategory.Visible = true;

            btnShowMonthly.CssClass = "bdg-tab-btn bdg-tab-outline";
            btnShowCategory.CssClass = "bdg-tab-btn";
        }

        protected void btnSaveMonthly_Click(object sender, EventArgs e)
        {
            DBhelp db = new DBhelp();

            int userId = Convert.ToInt32(Session["UserID"]);
            int month = Convert.ToInt32(ddlMonthMonthly.SelectedValue);
            int year = Convert.ToInt32(ddlYearMonthly.SelectedValue);
            decimal amount = Convert.ToDecimal(txtMonthlyAmount.Text);

            // First check if record exists
            string checkQuery = "SELECT COUNT(*) FROM Budget WHERE UserId=@UserId AND CategoryId IS NULL AND BudgetMonth=@Month AND BudgetYear=@Year";

            SqlParameter[] checkParams = new SqlParameter[]
            {
        new SqlParameter("@UserId", userId),
        new SqlParameter("@Month", month),
        new SqlParameter("@Year", year)
            };

            DataTable dt = db.executeSelect(checkQuery, checkParams);

            int count = Convert.ToInt32(dt.Rows[0][0]);

            if (count > 0)
            {
                // UPDATE
                string updateQuery = "UPDATE Budget SET BudgetAmount=@Amount WHERE UserId=@UserId AND CategoryId IS NULL AND BudgetMonth=@Month AND BudgetYear=@Year";

                SqlParameter[] updateParams = new SqlParameter[]
                {
            new SqlParameter("@Amount", amount),
            new SqlParameter("@UserId", userId),
            new SqlParameter("@Month", month),
            new SqlParameter("@Year", year)
                };

                db.executeUpdate(updateQuery, updateParams);
            }
            else
            {
                // INSERT
                string insertQuery = "INSERT INTO Budget(UserId, CategoryId, BudgetAmount, BudgetMonth, BudgetYear, CreatedAt) VALUES(@UserId, NULL, @Amount, @Month, @Year, GETDATE())";

                SqlParameter[] insertParams = new SqlParameter[]
                {
            new SqlParameter("@UserId", userId),
            new SqlParameter("@Amount", amount),
            new SqlParameter("@Month", month),
            new SqlParameter("@Year", year)
                };

                db.executeUpdate(insertQuery, insertParams);
            }

            txtMonthlyAmount.Text = "";
            BindBudgets();
        }

        //protected void btnSaveCategory_Click(object sender, EventArgs e)
        //{
        //    DBhelp db = new DBhelp();

        //    int userId = Convert.ToInt32(Session["UserID"]);
        //    int month = Convert.ToInt32(ddlMonthCategory.SelectedValue);
        //    int year = Convert.ToInt32(ddlYearCategory.SelectedValue);
        //    int categoryId = Convert.ToInt32(ddlCategory.SelectedValue);
        //    decimal amount = Convert.ToDecimal(txtCategoryAmount.Text);

        //    if (categoryId == 0)
        //    {
        //        Response.Write("Please select a category.");
        //        return;
        //    }

        //    if (amount <= 0)
        //    {
        //        Response.Write("Amount must be greater than 0.");
        //        return;
        //    }

        //    // Check if record exists
        //    string checkQuery = @"
        //        SELECT COUNT(*) 
        //        FROM Budget 
        //        WHERE UserId=@UserId 
        //        AND CategoryId=@CategoryId 
        //        AND BudgetMonth=@Month 
        //        AND BudgetYear=@Year";

        //    SqlParameter[] checkParams = new SqlParameter[]
        //    {
        //        new SqlParameter("@UserId", userId),
        //        new SqlParameter("@CategoryId", categoryId),
        //        new SqlParameter("@Month", month),
        //        new SqlParameter("@Year", year)
        //    };

        //    DataTable dt = db.executeSelect(checkQuery, checkParams);

        //    int count = Convert.ToInt32(dt.Rows[0][0]);

        //    if (count > 0)
        //    {
        //        // UPDATE
        //        string updateQuery = @"
        //            UPDATE Budget 
        //            SET BudgetAmount=@Amount 
        //            WHERE UserId=@UserId 
        //            AND CategoryId=@CategoryId 
        //            AND BudgetMonth=@Month 
        //            AND BudgetYear=@Year";

        //        SqlParameter[] updateParams = new SqlParameter[]
        //        {
        //    new SqlParameter("@Amount", amount),
        //    new SqlParameter("@UserId", userId),
        //    new SqlParameter("@CategoryId", categoryId),
        //    new SqlParameter("@Month", month),
        //    new SqlParameter("@Year", year)
        //        };

        //        db.executeUpdate(updateQuery, updateParams);
        //    }
        //    else
        //    {
        //        // INSERT
        //        string insertQuery = @"
        //    INSERT INTO Budget(UserId, CategoryId, BudgetAmount, BudgetMonth, BudgetYear, CreatedAt)
        //    VALUES(@UserId, @CategoryId, @Amount, @Month, @Year, GETDATE())";

        //        SqlParameter[] insertParams = new SqlParameter[]
        //        {
        //    new SqlParameter("@UserId", userId),
        //    new SqlParameter("@CategoryId", categoryId),
        //    new SqlParameter("@Amount", amount),
        //    new SqlParameter("@Month", month),
        //    new SqlParameter("@Year", year)
        //        };

        //        db.executeUpdate(insertQuery, insertParams);
        //    }

        //    txtCategoryAmount.Text = "";
        //    BindBudgets();
        //}

        protected void btnSaveCategory_Click(object sender, EventArgs e)
        {
            DBhelp db = new DBhelp();

            int userId = Convert.ToInt32(Session["UserID"]);
            int month = Convert.ToInt32(ddlMonthCategory.SelectedValue);
            int year = Convert.ToInt32(ddlYearCategory.SelectedValue);
            int categoryId = Convert.ToInt32(ddlCategory.SelectedValue);
            decimal amount = Convert.ToDecimal(txtCategoryAmount.Text);

            if (categoryId == 0)
            {
                Response.Write("Please select a category.");
                return;
            }

            if (amount <= 0)
            {
                Response.Write("Amount must be greater than 0.");
                return;
            }

            // ================================
            // STEP 1: Get Monthly Budget
            // ================================
            string monthlyQuery = @"
        SELECT BudgetAmount 
        FROM Budget
        WHERE UserId=@UserId
        AND CategoryId IS NULL
        AND BudgetMonth=@Month
        AND BudgetYear=@Year";

            SqlParameter[] monthlyParams = new SqlParameter[]
            {
        new SqlParameter("@UserId", userId),
        new SqlParameter("@Month", month),
        new SqlParameter("@Year", year)
            };

            DataTable monthlyDt = db.executeSelect(monthlyQuery, monthlyParams);

            if (monthlyDt.Rows.Count == 0)
            {
                Response.Write("Please set monthly budget first.");
                return;
            }

            decimal monthlyBudget = Convert.ToDecimal(monthlyDt.Rows[0]["BudgetAmount"]);

            // ==========================================
            // STEP 2: Get existing category total
            // Exclude current category (important for update)
            // ==========================================
            string sumQuery = @"
        SELECT ISNULL(SUM(BudgetAmount),0)
        FROM Budget
        WHERE UserId=@UserId
        AND CategoryId IS NOT NULL
        AND BudgetMonth=@Month
        AND BudgetYear=@Year
        AND CategoryId <> @CategoryId";

            SqlParameter[] sumParams = new SqlParameter[]
            {
        new SqlParameter("@UserId", userId),
        new SqlParameter("@Month", month),
        new SqlParameter("@Year", year),
        new SqlParameter("@CategoryId", categoryId)
            };

            DataTable sumDt = db.executeSelect(sumQuery, sumParams);
            decimal existingTotal = Convert.ToDecimal(sumDt.Rows[0][0]);

            // ==========================================
            // STEP 3: Validate against monthly limit
            // ==========================================
            if (existingTotal + amount > monthlyBudget)
            {
                Response.Write("Category budgets exceed monthly budget limit.");
                return;
            }

            // ==========================================
            // STEP 4: Check if record exists (Insert/Update)
            // ==========================================
            string checkQuery = @"
        SELECT COUNT(*) 
        FROM Budget 
        WHERE UserId=@UserId 
        AND CategoryId=@CategoryId 
        AND BudgetMonth=@Month 
        AND BudgetYear=@Year";

            SqlParameter[] checkParams = new SqlParameter[]
            {
        new SqlParameter("@UserId", userId),
        new SqlParameter("@CategoryId", categoryId),
        new SqlParameter("@Month", month),
        new SqlParameter("@Year", year)
            };

            DataTable dt = db.executeSelect(checkQuery, checkParams);
            int count = Convert.ToInt32(dt.Rows[0][0]);

            if (count > 0)
            {
                // UPDATE
                string updateQuery = @"
            UPDATE Budget 
            SET BudgetAmount=@Amount 
            WHERE UserId=@UserId 
            AND CategoryId=@CategoryId 
            AND BudgetMonth=@Month 
            AND BudgetYear=@Year";

                SqlParameter[] updateParams = new SqlParameter[]
                {
            new SqlParameter("@Amount", amount),
            new SqlParameter("@UserId", userId),
            new SqlParameter("@CategoryId", categoryId),
            new SqlParameter("@Month", month),
            new SqlParameter("@Year", year)
                };

                db.executeUpdate(updateQuery, updateParams);
            }
            else
            {
                // INSERT
                string insertQuery = @"
            INSERT INTO Budget(UserId, CategoryId, BudgetAmount, BudgetMonth, BudgetYear, CreatedAt)
            VALUES(@UserId, @CategoryId, @Amount, @Month, @Year, GETDATE())";

                SqlParameter[] insertParams = new SqlParameter[]
                {
            new SqlParameter("@UserId", userId),
            new SqlParameter("@CategoryId", categoryId),
            new SqlParameter("@Amount", amount),
            new SqlParameter("@Month", month),
            new SqlParameter("@Year", year)
                };

                db.executeUpdate(insertQuery, insertParams);
            }

            txtCategoryAmount.Text = "";
            BindBudgets();
        }

        protected void gvBudgets_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DBhelp db = new DBhelp();

            int budgetId = Convert.ToInt32(gvBudgets.DataKeys[e.RowIndex].Value);

            string query = "DELETE FROM Budget WHERE BudgetId=@BudgetId";

            SqlParameter[] param = new SqlParameter[]
            {
        new SqlParameter("@BudgetId", budgetId)
            };

            int row=db.executeUpdate(query, param);

            if(row>0)
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Budget deleted successfully.";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error deleting budget.";

            }

            BindBudgets();
        }
        private void BindBudgets()
        {
            DBhelp db = new DBhelp();

            int userId = Convert.ToInt32(Session["UserID"]);

            string query = @"
                    SELECT 
                b.BudgetId,
                DATENAME(MONTH, DATEFROMPARTS(b.BudgetYear, b.BudgetMonth, 1)) AS BudgetMonth,
                b.BudgetYear,
                ISNULL(c.name, 'Overall') AS CategoryName,
                b.BudgetAmount
            FROM Budget b
            LEFT JOIN category c 
                ON b.CategoryId = c.category_id
            WHERE b.UserId = @UserId
            ORDER BY b.BudgetYear DESC, b.BudgetMonth DESC";

            SqlParameter[] param = new SqlParameter[]
            {
        new SqlParameter("@UserId", userId)
            };

            DataTable dt = db.executeSelect(query, param);

            gvBudgets.DataSource = dt;
            gvBudgets.DataBind();
        }
    }
}