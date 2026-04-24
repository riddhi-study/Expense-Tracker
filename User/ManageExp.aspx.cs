using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExpenseTracker.Admin;

namespace ExpenseTracker.User
{
    public partial class ManageExp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadExpense();
            }
        }

        private void LoadExpense()
        {
            DBhelp db = new DBhelp();

            int uid = Convert.ToInt32(Session["UserID"]);

            //Response.Write("Session UID = " + uid);
            //Response.Write("Session UserID = " + Session["UserID"]);


            //string query = "SELECT * FROM Expenses WHERE UserId=@Uid"; 

            string query = @"
                   SELECT 
                    e.ExpenseId,
                    e.Amount,
                    FORMAT(e.ExpenseDate, 'dd/MM/yyyy') AS ExpenseDate,
                    e.Description,
                    c.name AS CategoryName
                FROM Expenses e
                LEFT JOIN category c ON e.CategoryId = c.category_id
                WHERE e.UserId = @Userid
                ORDER BY e.ExpenseDate";

            //            SELECT e.ExpenseId,
            //       e.Amount,
            //       e.ExpenseDate,
            //       e.Description,
            //       c.name AS CategoryName
            //FROM Expenses e
            //INNER JOIN category c
            //    ON e.CategoryId = c.category_id
            //WHERE e.UserId = 2; --replace with actual ID

            SqlParameter[] prms = {
                new SqlParameter("@Userid", uid)
            };

            DataTable dt = db.executeSelect(query, prms);

            expenses.DataSource = dt;
            expenses.DataBind();
        }

        protected void exp_rowedit(object sender, GridViewEditEventArgs e) // runs when user clicks on edit button in gridview
        {
            expenses.EditIndex = e.NewEditIndex; //this row is now editable , then gridview converts cells into textboxes
            LoadExpense();// to show the textboxes instead of labels
        }

        protected void exp_canceledit(object sender, GridViewCancelEditEventArgs e)
        {
            expenses.EditIndex = -1; // no rwo is in edit mode
            LoadExpense();
        }

        protected void exp_rowupdate(object sender, GridViewUpdateEventArgs e) //when user clicks on update button
        {
            DBhelp db = new DBhelp();



            //int id = Convert.ToInt32(items.Rows[e.RowIndex].Cells[1].Text); // extracting the id of the row that is being edited by the user
            int id = Convert.ToInt32(expenses.DataKeys[e.RowIndex].Value);

            //RowIndex = index of row being updated 
            //Rows[] specific gridview row
            //Cells[1] Id column
            //.Text = value of id

            TextBox tnm = (TextBox)expenses.Rows[e.RowIndex].Cells[2].Controls[0];

            string name = tnm.Text; // reading data that has been inputted from textbox

            SqlParameter[] prms =
            {
                new SqlParameter("@Name", name),
                new SqlParameter("@Id", id),
                //new SqlParameter("@catId",),
            };

            db.executeUpdate("UPDATE Expenses SET name=@Name WHERE ExpenseId=@Id", prms);// getting the data that is being updated by the user
            /*

                            baki che brooo , 
                        
                            idher update query baki che 


            */

            expenses.EditIndex = -1; // stop editing mode

            LoadExpense();
        }

        protected void exp_delete(object sender, GridViewDeleteEventArgs e)
        {
            DBhelp db = new DBhelp();

            int id = Convert.ToInt32(expenses.DataKeys[e.RowIndex].Value);

            //TextBox tnm = (TextBox)items.Rows[e.RowIndex].Cells[2].Controls[0];

            SqlParameter[] prms =
            {
                new SqlParameter("@Id",id)
            };

            //db.executeDelete("TestTable", "Id=@Id",prms);
            db.executeUpdate("DELETE FROM Expenses WHERE ExpenseId=@Id", prms);

            LoadExpense();
        }
    }
}