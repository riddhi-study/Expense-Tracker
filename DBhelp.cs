//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace ExpenseTracker
//{
//    public class DBhelp
//    {
//    }
//}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace ExpenseTracker
{
    public class DBhelp
    {
        public static String dbName = "DB_NAME"; //OPTIONAL
        public static String workStationID = ".";
        private String conStr;
        //private String conStr1;
        private SqlConnection objCon;
        private SqlDataAdapter objAdp;
        private DataTable objTab;
        private SqlCommand objCmd;
        private String strQuery;
        public String strErrorMsg;
        public string Blankmsg;
        public DBhelp()
        {
        }

        public int executeUpdate(string query, SqlParameter[] parameters)
        {
            Connection();
            objCmd = new SqlCommand(query, objCon);

            //foreach (SqlParameter p in parameters)
            //{
            //    objCmd.Parameters.Add(p);
            //}
            foreach (SqlParameter p in parameters)
            {
                objCmd.Parameters.Add(new SqlParameter(p.ParameterName, p.Value));
            }

            return objCmd.ExecuteNonQuery();
        }
        public void Connection()
        {
            conStr = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            //conStr = ConfigurationManager.ConnectionStrings["cs1"].ConnectionString;
            if (objCon != null)
            {
                String temp = objCon.State.ToString();
                if (objCon.State == ConnectionState.Closed)
                {
                    objCon.Open();
                }
            }
            else
            {
                objCon = new SqlConnection(conStr);
                // objCon = new SqlConnection(conStr1);
                objCon.Open();
            }
        }
        //public DataTable executeSelect(String strTable, String strColumnList, String strCriteria, String strOrderBy)
        //{
        //    try
        //    {
        //        Connection();
        //        strQuery = "SELECT " + strColumnList + " FROM " + strTable;
        //        if (strCriteria != "")
        //        {
        //            strQuery += " WHERE " + strCriteria;
        //        }
        //        if (strOrderBy != "")
        //        {
        //            strQuery += " ORDER BY " + strOrderBy;
        //        }
        //        objAdp = new SqlDataAdapter(strQuery, objCon);
        //        objTab = new DataTable();
        //        objAdp.Fill(objTab);
        //        return objTab;
        //    }
        //    catch (Exception ex)
        //    {
        //        strErrorMsg = ex.Message.ToString();
        //    }
        //    return null;
        //}

        public DataTable executeSelect(string query, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();  // <-- initialize it
            try
            {
                Connection();
                objCmd = new SqlCommand(query, objCon);

                if (parameters != null)
                {
                    foreach (SqlParameter p in parameters)
                    {
                        objCmd.Parameters.Add(p);
                    }
                }

                objAdp = new SqlDataAdapter(objCmd);
                objTab = new DataTable();
                objAdp.Fill(objTab);
                return objTab;
            }
            catch (Exception ex)
            {
                strErrorMsg = ex.Message;
                //throw new Exception("Database Error: " + ex.Message);
            }
            return null;
        }
        public int executeUpdate(String strQuery)
        {
            try
            {
                Connection();
                objCmd = new SqlCommand(strQuery, objCon);
                return objCmd.ExecuteNonQuery();
                //executenonquery() returns th number of rows affected
            }
            catch (Exception ex)
            {
                strErrorMsg = ex.Message.ToString();
            }
            return 0;
        }
        public int executeDelete(String strTable, String strCriteria)
        {
            try
            {
                strQuery = "DELETE FROM " + strTable + " WHERE " + strCriteria;
                Connection();
                objCmd = new SqlCommand(strQuery, objCon);
                return objCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                strErrorMsg = ex.Message.ToString();
            }
            return 0;
        }
        public void ClearControl(Control parent)
        {
            foreach (Control ctlTemp in parent.Controls)
            {
                if (ctlTemp.GetType() == typeof(TextBox))
                {
                    TextBox txtTemp = (TextBox)ctlTemp;
                    txtTemp.Text = "";
                }
                if (ctlTemp.GetType() == typeof(DropDownList))
                {
                    DropDownList dlTemp = (DropDownList)ctlTemp;
                    dlTemp.SelectedIndex = 0;
                }
                if (ctlTemp.GetType() == typeof(ListBox))
                {
                    ListBox dlTemp = (ListBox)ctlTemp;
                    dlTemp.SelectedIndex = 0;
                }
                if (ctlTemp.HasControls())
                {
                    ClearControl(ctlTemp);
                }
            }
        }
    }
}