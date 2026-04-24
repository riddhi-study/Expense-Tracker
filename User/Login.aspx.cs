using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using ExpenseTracker.Admin;

namespace ExpenseTracker.User
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        }

        //protected void click_login(object sender, EventArgs e)
        //{
        //    Response.Write("login successful!!");

        //}

        protected void Click_Login(object sender, EventArgs e)
        {
            DBhelp db = new DBhelp();

            String name = tnm.Text.Trim();
            String pass = tpass.Text.Trim();

            

            string query = "SELECT user_id, name, email, pswd FROM users WHERE name=@Name";

            SqlParameter[] prms =
            {
                 new SqlParameter("@Name", name)
                 //new SqlParameter("@Pass",pass)
            };

            DataTable dt = db.executeSelect(query, prms);

            if (dt.Rows.Count == 0)
            {
                Response.Write("No user found");
                return;
            }

            Response.Write("User Found: " + dt.Rows[0]["name"]);


            if (dt != null && dt.Rows.Count == 1)
            {
                string storedHash = dt.Rows[0]["pswd"].ToString();

                bool isValidPassword = BCrypt.Net.BCrypt.Verify(pass, storedHash);

                if (isValidPassword)
                {
                    int userId = Convert.ToInt32(dt.Rows[0]["user_id"]);
                    string username = dt.Rows[0]["name"].ToString();
                    string email = dt.Rows[0]["email"].ToString();   // ADD THIS


                    Session["UserID"] = userId;
                    Session["Username"] = username;
                    Session["Email"] = email;  // ADD THIS

                    //HttpCookie authCookie = new HttpCookie("UserAuth");
                    //authCookie.Value = userId.ToString();
                    //authCookie.Expires = DateTime.Now.AddDays(30);

                    //Response.Cookies.Add(authCookie);

                    Response.Redirect("~/User/MyExpenses.aspx");
                }
                else
                {
                    Response.Write("Invalid username or password.");
                }
            }
            else
            {
                Response.Write("Invalid username or password.");
            }

        }
    }
}