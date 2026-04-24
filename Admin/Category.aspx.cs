using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExpenseTracker.User;

namespace ExpenseTracker.Admin
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadData();
            }

        }

        protected void LoadData()
        {
            //DBhelp db = new DBhelp();

            //DataTable dt = db.executeSelect("category", "*", "", "");

            //cat2.DataSource = dt;

            //cat2.DataBind();

            DBhelp db = new DBhelp();

            

            string query = "SELECT * FROM category";

            

            DataTable dt = db.executeSelect(query,null);

            cat2.DataSource = dt;
            cat2.DataBind();
        }

        protected void Add_Category(object sender, EventArgs e)
        {
            DBhelp db = new DBhelp();

            String name = nm.Text.Trim();

            SqlParameter[] prms =
            {
                new SqlParameter("@NM",name)
            };

            int rows = db.executeUpdate("INSERT INTO category (name) VALUES (@NM)", prms);

            if(rows>0)
            {
                //Response.Write("Category added!!");
                show.Text = "Category Added!!";
                show.ForeColor = System.Drawing.Color.Green;
                nm.Text = "";

                LoadData();  
            }
            else
            {

                show.Text = "Failed!";
                show.ForeColor = System.Drawing.Color.Red;

            }
        }

        protected void cat_rowedit(object sender, GridViewEditEventArgs e) // runs when user clicks on edit button in gridview
        {
            cat2.EditIndex = e.NewEditIndex; //this row is now editable , then gridview converts cells into textboxes
            LoadData();// to show the textboxes instead of labels
        }

        protected void cat_canceledit(object sender, GridViewCancelEditEventArgs e)
        {
            cat2.EditIndex = -1; // no rwo is in edit mode
            LoadData();
        }

        protected void cat_rowupdate(object sender, GridViewUpdateEventArgs e) //when user clicks on update button
        {
            DBhelp db = new DBhelp();



            //int id = Convert.ToInt32(items.Rows[e.RowIndex].Cells[1].Text); // extracting the id of the row that is being edited by the user
            int id = Convert.ToInt32(cat2.DataKeys[e.RowIndex].Value);

            //RowIndex = index of row being updated 
            //Rows[] specific gridview row
            //Cells[1] Id column
            //.Text = value of id

            TextBox tnm = (TextBox)cat2.Rows[e.RowIndex].Cells[2].Controls[0];

            string name = tnm.Text; // reading data that has been inputted from textbox

            SqlParameter[] prms =
            {
                new SqlParameter("@Name", name),
                new SqlParameter("@Id", id)
            };

            db.executeUpdate("UPDATE category SET name=@Name WHERE category_id=@Id", prms);// getting the data that is being updated by the user

            cat2.EditIndex = -1; // stop editing mode

            LoadData();
        }

        protected void cat_delete(object sender, GridViewDeleteEventArgs e)
        {
            DBhelp db = new DBhelp();

            int id = Convert.ToInt32(cat2.DataKeys[e.RowIndex].Value);

            //TextBox tnm = (TextBox)items.Rows[e.RowIndex].Cells[2].Controls[0];

            SqlParameter[] prms =
            {
                new SqlParameter("@Id",id)
            };

            //db.executeDelete("TestTable", "Id=@Id",prms);
            db.executeUpdate("DELETE FROM category WHERE category_id=@Id", prms);

            LoadData();
        }
       
    }
}