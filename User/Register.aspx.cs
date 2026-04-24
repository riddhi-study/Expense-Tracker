using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BCrypt.Net;

namespace ExpenseTracker.User
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Click_reg(object sender, EventArgs e)
        {
            DBhelp db = new DBhelp();

            String name = nm.Text.Trim();
            String email = em.Text.Trim();
            String pswd = pas.Text.Trim();

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(pswd);


            SqlParameter[] prms =
            {
                new SqlParameter("@Name",name),
                new SqlParameter("@Email",email),
                new SqlParameter("@Pass",hashedPassword)
            };

            int rows = db.executeUpdate("INSERT INTO users (name,email,pswd) VALUES (@Name,@Email,@Pass)", prms);

            if (rows > 0)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                //Response.Redirect("Login.aspx");
                Response.Write("please try again later!!");
            }
        }
    }
}