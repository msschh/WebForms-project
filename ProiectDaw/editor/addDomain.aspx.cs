using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ProiectDaw.editor
{
    public partial class addDomain : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\mssqllocaldb;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
        SqlCommand cmd = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddDomain(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("INSERT INTO Domains (Name) VALUES (@name)", con);
            cmd.Parameters.AddWithValue("@name", TextBox1.Text);
            cmd.ExecuteNonQuery();
            Response.Redirect("~/Default.aspx");
        }
    }
}