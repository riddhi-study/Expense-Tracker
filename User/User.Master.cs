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
    public partial class User : System.Web.UI.MasterPage
    {
        //    protected void Page_Load(object sender, EventArgs e)
        //    {



        //        // Allow login page without session
        //        string currentPage = System.IO.Path.GetFileName(Request.Path).ToLower();

        //        if (currentPage == "login.aspx" || currentPage == "Register.aspx")
        //            return;

        //        if (Session["UserID"] == null)
        //        {
        //            Response.Redirect("~/User/Login.aspx");
        //        }


        //}

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    // Prevent back-button access after logout
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.Cache.SetNoStore();
        //    Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));

        //    string currentPage = System.IO.Path.GetFileName(Request.Path).ToLower();

        //    // Allow login page without session
        //    if (currentPage == "login.aspx")
        //        return;

        //    // 🔐 Session protection with persistent cookie restore
        //    if (Session["UserID"] == null)
        //    {
        //        HttpCookie adminCookie = Request.Cookies["UserAuth"];

        //        if (adminCookie != null)
        //        {
        //            // Restore session from cookie
        //            Session["UserID"] = adminCookie.Value;
        //        }
        //        else
        //        {
        //            Response.Redirect("~/User/Login.aspx", true);
        //        }

        //        if (!IsPostBack)
        //        {
        //            if (Session["UserID"] != null)
        //            {

        //                string fullName = Session["Username"].ToString();
        //                string email = Session["Email"].ToString();

        //                lblFullName.Text = fullName;
        //                lblEmail.Text = email;

        //                txtFullName.Text = fullName;
        //                txtEmail.Text = email;

        //                // Initials
        //                string initials = "";
        //                foreach (var part in fullName.Split(' '))
        //                {
        //                    if (!string.IsNullOrEmpty(part))
        //                        initials += part[0];
        //                }
        //                lblInitials.Text = initials.ToUpper();
        //            }
        //            else
        //            {
        //                Response.Redirect("~/Login.aspx");
        //            }
        //        }

        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            // Prevent caching
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));

            string currentPage = System.IO.Path.GetFileName(Request.Path).ToLower();

            if (currentPage == "login.aspx")
                return;

            if (Session["UserID"] == null)
            {
                Response.Redirect("~/User/Login.aspx", true);
            }
            // 🔐 Step 1: Restore session from cookie if needed
            //if (Session["UserID"] == null)
            //{
            //    HttpCookie userCookie = Request.Cookies["UserAuth"];

            //    if (userCookie != null)
            //    {
            //        Session["UserID"] = userCookie.Value;

            //        // 🔥 VERY IMPORTANT:
            //        // If restoring from cookie, fetch user details from DB
            //        LoadUserFromDatabase(userCookie.Value);
            //    }
            //    else
            //    {
            //        Response.Redirect("~/User/Login.aspx");
            //        return;
            //    }
            //}

            // 🔐 Step 2: Load profile display
            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    string fullName = Session["Username"].ToString();
                    string email = Session["Email"]?.ToString() ?? "";

                    lblFullName.Text = fullName;
                    lblEmail.Text = email;

                    lblFullName.Text = fullName;
                    lblEmail.Text = email;

                    // Initials
                    string initials = "";
                    foreach (var part in fullName.Split(' '))
                    {
                        if (!string.IsNullOrEmpty(part))
                            initials += part[0];
                    }

                    lblInitials.Text = initials.ToUpper();
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Prevent caching
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));

            // Destroy session
            Session.Clear();
            Session.Abandon();

            // Delete persistent cookie
            //if (Request.Cookies["UserAuth"] != null)
            //{
            //    HttpCookie cookie = new HttpCookie("UserAuth");
            //    cookie.Expires = DateTime.Now.AddDays(-1);
            //    Response.Cookies.Add(cookie);
            //}

            Response.Redirect("~/User/Login.aspx", true);
        }

        protected void btnSaveProfile_Click(object sender, EventArgs e)
        {
            //DBhelp db = new DBhelp();

            //string newName = txtFullName.Text.Trim();
            //string newEmail = txtEmail.Text.Trim();
            //int userId = Convert.ToInt32(Session["UserId"]);

            //string query = "UPDATE Users SET FullName=@FullName, Email=@Email WHERE UserId=@UserId";

            //using (SqlConnection con = new SqlConnection(
            //    ConfigurationManager.ConnectionStrings["YourConnection"].ConnectionString))
            //{
            //    SqlCommand cmd = new SqlCommand(query, con);
            //    cmd.Parameters.AddWithValue("@FullName", newName);
            //    cmd.Parameters.AddWithValue("@Email", newEmail);
            //    cmd.Parameters.AddWithValue("@UserId", userId);

            //    con.Open();
            //    cmd.ExecuteNonQuery();

            DBhelp db = new DBhelp();

            string newName = lblFullName.Text.Trim();
            string newEmail = lblEmail.Text.Trim();
            int userId = Convert.ToInt32(Session["UserID"]);

            string query = "UPDATE users SET name=@FullName, email=@Email WHERE user_id=@UserId";

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@FullName", newName),
                new SqlParameter("@Email", newEmail),
                new SqlParameter("@UserId", userId)
            };

            db.executeUpdate(query, param);

            Response.Write("Before Update<br>");
            Response.Write("UserID: " + Session["UserID"] + "<br>");
            Response.Write("New Name: " + newName + "<br>");
            Response.Write("New Email: " + newEmail + "<br>");

            int rows = db.executeUpdate(query, param);

            Response.Write("Rows affected: " + rows);
            Response.End();

            // Update Session
            Session["Username"] = newName;
            Session["Email"] = newEmail;


            //Response.Redirect(Request.RawUrl);

            lblFullName.Text = newName;
            lblEmail.Text = newEmail;

            txtFullName.Text = newName;
            txtEmail.Text = newEmail;

            Session["Username"] = newName;
            Session["Email"] = newEmail;

            ScriptManager.RegisterStartupScript(this, this.GetType(),
       "closeEdit", "cancelEdit();", true);
        }

        private void LoadUserFromDatabase(string userId)
        {
            DBhelp db = new DBhelp();

            string query = "SELECT name, email FROM users WHERE user_id=@Userid";

            SqlParameter[] prms =
            {
        new SqlParameter("@Userid", userId)
    };

            DataTable dt = db.executeSelect(query, prms);

            if (dt.Rows.Count > 0)
            {
                Session["Username"] = dt.Rows[0]["name"].ToString();
                Session["Email"] = dt.Rows[0]["email"].ToString();
            }
        }

    }
}