using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpenseTracker.Admin
{
    public partial class Feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            //DBhelp db = new DBhelp();

            //DataTable dt = db.executeSelect("feedback", "*", "", "");

            //feeddata.DataSource = dt;
            //feeddata.DataBind();

            DBhelp db = new DBhelp();



            string query = "SELECT * FROM feedback";



            DataTable dt = db.executeSelect(query, null);

            feeddata.DataSource = dt;
            feeddata.DataBind();
        }

        protected void feed_rowedit(object sender, GridViewEditEventArgs e) // runs when user clicks on edit button in gridview
        {
            feeddata.EditIndex = e.NewEditIndex; //this row is now editable , then gridview converts cells into textboxes
            LoadData();// to show the textboxes instead of labels
        }

        protected void feed_canceledit(object sender, GridViewCancelEditEventArgs e)
        {
            feeddata.EditIndex = -1; // no rwo is in edit mode
            LoadData();
        }

        protected void feed_rowupdate(object sender, GridViewUpdateEventArgs e) //when user clicks on update button
        {
            DBhelp db = new DBhelp();



            //int id = Convert.ToInt32(items.Rows[e.RowIndex].Cells[1].Text); // extracting the id of the row that is being edited by the user
            int id = Convert.ToInt32(feeddata.DataKeys[e.RowIndex].Value);

            //RowIndex = index of row being updated 
            //Rows[] specific gridview row
            //Cells[1] Id column
            //.Text = value of id

            TextBox tnm = (TextBox)feeddata.Rows[e.RowIndex].Cells[2].Controls[0];

            string name = tnm.Text; // reading data that has been inputted from textbox

            SqlParameter[] prms =
            {
                new SqlParameter("@Name", name),
                new SqlParameter("@Id", id)
            };

            db.executeUpdate("UPDATE feedback SET name=@Name WHERE feedback_id=@Id", prms);// getting the data that is being updated by the user

            feeddata.EditIndex = -1; // stop editing mode

            LoadData();
        }

        protected void feed_delete(object sender, GridViewDeleteEventArgs e)
        {
            DBhelp db = new DBhelp();

            int id = Convert.ToInt32(feeddata.DataKeys[e.RowIndex].Value);

            //TextBox tnm = (TextBox)items.Rows[e.RowIndex].Cells[2].Controls[0];

            SqlParameter[] prms =
            {
                new SqlParameter("@Id",id)
            };

            //db.executeDelete("TestTable", "Id=@Id",prms);
            db.executeUpdate("DELETE FROM feedback WHERE feedback_id=@Id", prms);

            LoadData();
        }

    }
}