using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ProiectDaw
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\mssqllocaldb;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
        SqlCommand cmd = null;
        SqlDataReader dr = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("select id, name from Domains", con);
            dr = cmd.ExecuteReader();
            String dropDownMenu = "";

            while(dr.Read())
            {
                String domain = "<a href='viewList.aspx?id=" + dr["id"].ToString() + "'>" + dr["name"].ToString() + "</a>";
                dropDownMenu += domain;
            }

            dropDownMenuDiv.InnerHtml = dropDownMenu;
        }
    }
}