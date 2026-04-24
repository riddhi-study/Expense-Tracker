using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using ExpenseTracker;


namespace ExpenseTracker.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        }

        protected void Login_Click(object sender, EventArgs e)
        {

            DBhelp db = new DBhelp();

            //String name = tnm.Text.Trim();
            //string username = adnm.Text.Trim();
            string email = tem.Text.Trim(); // only if email exists
            string pswd = pass.Text.Trim();



            //SqlParameter[] prms =
            //{
            //	new SqlParameter("@Name",username),
            //	new SqlParameter("@email",email),
            //	new SqlParameter("@pswd",pswd)

            //};

            //DataTable dt = db.executeSelect("admin", "*", "username=@Name	AND pswd=@pswd");

            string query = "SELECT admin_id FROM admin WHERE email=@Email AND pswd=@Password";

            SqlParameter[] prms =
    {
        new SqlParameter("@Email", email),
        new SqlParameter("@Password", pswd)
    };

            DataTable dt = db.executeSelect(query, prms);

            if (dt != null && dt.Rows.Count == 1)
            {
                int adminId = Convert.ToInt32(dt.Rows[0]["admin_id"]);

                Session["AdminID"] = adminId;

                //HttpCookie authCookie = new HttpCookie("AdminAuth");
                //authCookie.Value = adminId.ToString();
                //authCookie.Expires = DateTime.Now.AddDays(30);

                //Response.Cookies.Add(authCookie);

                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                Response.Write("Invalid email or password.");
            }

            //if (dt.Rows.Count > 0)
            //{
            //    int adminId = Convert.ToInt32(dt.Rows[0]["admin_id"]);
            //    //string username = dt.Rows[0]["username"].ToString();



            //    Session["AdminID"] = adminId;
            //    //Session["Username"] = username;


            //    Response.Redirect("Dashboard.aspx");
            //}
            //else
            //{
            //    Response.Write("Invalid username or password.");
            //}

        }
    }
}