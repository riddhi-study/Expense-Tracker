using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ExpenseTracker.User
{
    public partial class Feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("UserID = " + Session["UserID"]);

            if (Session["UserID"] == null)
            {
                Response.Redirect("~/User/Login.aspx");
            }
            
        }

        protected void Click_Send(object sender, EventArgs e)
        {
            DBhelp db = new DBhelp();

            int uid = Convert.ToInt32(Session["UserID"]);
            String name = tnm.Text.Trim();
            String email = tem.Text.Trim();
            String msg = tmsg.Text.Trim();

            SqlParameter[] prms =
            {
                new SqlParameter("@Uid",uid),
                new SqlParameter("@Name",name),
                new SqlParameter("@Email",email),
                new SqlParameter("@Msg",msg)
            };

            int rows = db.executeUpdate("INSERT INTO feedback (user_id,name,email,msg) VALUES (@Uid,@Name,@Email,@Msg)",prms);

            if (rows > 0)
            {
                result.Text = "Sent!!";
                result.ForeColor = System.Drawing.Color.Green;
                tnm.Text = "";
                tem.Text = "";
                tmsg.Text = "";
            }
            else
            {
                result.Text = "please try again later.";
                result.ForeColor = System.Drawing.Color.Red;
            }
        }

    }
}