using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpenseTracker.Admin
{
    public partial class Index : System.Web.UI.MasterPage
    {


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

        //    // 🔐 Session protection (MAIN LOGIC)
        //    if (Session["AdminID"] == null)
        //    {
        //        Response.Redirect("~/Admin/Login.aspx", true);
        //    }
        //}

        //protected void btnLogout_Click(object sender, EventArgs e)
        //{
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.Cache.SetNoStore();
        //    Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));

        //    Session.Clear();
        //    Session.Abandon();

        //    Response.Redirect("~/Admin/Login.aspx", true);
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            // Prevent back-button access after logout
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));

            string currentPage = System.IO.Path.GetFileName(Request.Path).ToLower();

            // Allow login page without session
            if (currentPage == "login.aspx")
                return;

            if (Session["AdminID"] == null)
            {
                Response.Redirect("~/Admin/Login.aspx", true);
            }

            // 🔐 Session protection with persistent cookie restore
            //if (Session["AdminID"] == null)
            //{
            //    HttpCookie adminCookie = Request.Cookies["AdminAuth"];

            //    if (adminCookie != null)
            //    {
            //        // Restore session from cookie
            //        Session["AdminID"] = adminCookie.Value;
            //    }
            //    else
            //    {
            //        Response.Redirect("~/Admin/Login.aspx", true);
            //    }
            //}
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
            //if (Request.Cookies["AdminAuth"] != null)
            //{
            //    HttpCookie cookie = new HttpCookie("AdminAuth");
            //    cookie.Expires = DateTime.Now.AddDays(-1);
            //    Response.Cookies.Add(cookie);
            //}

            Response.Redirect("~/Admin/Login.aspx", true);
        }
    }
}