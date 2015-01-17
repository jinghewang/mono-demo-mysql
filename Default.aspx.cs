using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("xxxxx");
        Response.Write(Environment.CurrentDirectory);

        
    }

    public DataSet testsql2()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ToString();
        //"Server=localhost;Database=btg;User ID=root;Password=123456;Pooling=false";
        MySqlConnection dbcon;
        dbcon = new MySqlConnection(connectionString);
        dbcon.Open();
        
        MySqlCommand dbcmd = dbcon.CreateCommand();
        string sql =
            "SELECT loginname, name " +
            "FROM user";
        dbcmd.CommandText = sql;
        MySqlDataAdapter adapt = new MySqlDataAdapter(dbcmd);
        DataSet ds = new DataSet();
        adapt.Fill(ds);
        // requires a table to be created named employee
        // with columns firstname and lastname
        // such as,
        //        CREATE TABLE employee (
        //           firstname varchar(32),
        //           lastname varchar(32));
        
        // clean up
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;

        return ds;
    }

    public void testsql()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ToString();
        //"Server=localhost;Database=btg;User ID=root;Password=123456;Pooling=false";
        IDbConnection dbcon;
        dbcon = new MySqlConnection(connectionString);
        dbcon.Open();
        IDbCommand dbcmd = dbcon.CreateCommand();
        // requires a table to be created named employee
        // with columns firstname and lastname
        // such as,
        //        CREATE TABLE employee (
        //           firstname varchar(32),
        //           lastname varchar(32));
        string sql =
            "SELECT loginname, name " +
            "FROM user";
        dbcmd.CommandText = sql;
        IDataReader reader = dbcmd.ExecuteReader();
        int num = 0;
        Response.Write("<table>");
        while (reader.Read())
        {
            num++;
            string FirstName = (string)reader["loginname"];
            string LastName = (string)reader["name"];
            string str = string.Format("<tr><td>Name:{0} lastname:{1}<td></tr>", FirstName,LastName);
            Response.Write(str);

            if (num > 10)
                break;
        }
        Response.Write("</table>");

        // clean up
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            this.testsql();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}