using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace ExpenseTracker.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }


        }

        private void LoadData()
        {
            DBhelp db = new DBhelp();

            if (Session["AdminID"] == null)
            {
                total_user.Text = "Access Denied!!";
                return;
            }

            

            //for total users
            string queryTotalUser = "SELECT COUNT(*) AS TotalUsers FROM users";

            DataTable dt = db.executeSelect(queryTotalUser, null);

            if (dt != null && dt.Rows.Count > 0)
            {
                total_user.Text = dt.Rows[0]["TotalUsers"].ToString();
                //Response.Write(dt.Rows[0][0].ToString());
            }
            else
            {
                total_user.Text = "0";
            }

            //for total expense category
            string queryTotalCategory = "SELECT COUNT(*) AS TotalCategory FROM category";

             dt = db.executeSelect(queryTotalCategory, null);

            if (dt != null && dt.Rows.Count > 0)
            {
                exp_cat.Text = dt.Rows[0]["TotalCategory"].ToString();
                
            }
            else
            {
                exp_cat.Text = "0";
            }

            //for total feedbacks
            string queryTotalFeed = "SELECT COUNT(*) AS TotalFeedback FROM feedback";

            dt = db.executeSelect(queryTotalFeed, null);

            if (dt != null && dt.Rows.Count > 0)
            {
                total_feed.Text = dt.Rows[0]["TotalFeedback"].ToString();
                
            }
            else
            {
                total_feed.Text = "0";
            }
        }
    }
}