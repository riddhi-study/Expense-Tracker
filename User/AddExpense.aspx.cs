using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpenseTracker.User
{
    public partial class AddExpense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("UserID = " + Session["UserID"]);

            if (Session["UserID"] == null)
            {
                Response.Redirect("~/User/Login.aspx");
            }
            if (!IsPostBack)
            {
                Loadcategories();
            }
        }

        void Loadcategories()
        {
            DBhelp db = new DBhelp();

            //DataTable dt = db.executeSelect("category", "category_id, name", "", "");

            //selcat.DataSource = dt;
            //selcat.DataTextField = "name";
            //selcat.DataValueField = "category_id";
            //selcat.DataBind();

            //selcat.Items.Insert(0, new ListItem("-- Select Category --", "0"));

            string query = "SELECT category_id, name FROM category";

            DataTable dt = db.executeSelect(query, null);

            selcat.DataSource = dt;
            selcat.DataTextField = "name";
            selcat.DataValueField = "category_id";
            selcat.DataBind();

            selcat.Items.Insert(0, new ListItem("-- Select Category --", "0"));
        }

        protected void Add_expense(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                added.Text = "Session expired. Please login again.";
                added.ForeColor = System.Drawing.Color.Red;
                return;
            }

            DBhelp db = new DBhelp();

            int userId = Convert.ToInt32(Session["UserID"]);
            //String amount = tam.Text.Trim();
            decimal amount = Convert.ToDecimal(tam.Text);
            //String date = datte.Text.Trim();
            String desc = des.Text.Trim();
            DateTime expenseDate = Convert.ToDateTime(datte.Text);
            int categoryId = Convert.ToInt32(selcat.SelectedValue);

            SqlParameter[] prms =
                {
                new SqlParameter("@Am",amount),
                    new SqlParameter("@Dt",expenseDate),
                    new SqlParameter("@Des",desc),
                    new SqlParameter("@catid",categoryId),
                    new SqlParameter("@Uid",userId)
            };

            //throw new Exception("TEST");

            int rows = db.executeUpdate("INSERT INTO Expenses (UserId,CategoryId,Amount,ExpenseDate,Description) VALUES (@Uid,@catid,@Am,@Dt,@Des)",prms);

            if(rows > 0)
            {
                added.Text = "Expense Added";
                added.ForeColor = System.Drawing.Color.Green;
                tam.Text = "";
                des.Text = "";
            }
            else
            {
                added.Text = "please try again later!!";
                added.ForeColor = System.Drawing.Color.Red;

            }
        }
    }
}