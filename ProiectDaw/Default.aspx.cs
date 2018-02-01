using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ProiectDaw
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            ListView1.ItemCommand += new EventHandler<ListViewCommandEventArgs>(ListView1_ItemCommand);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\mssqllocaldb;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
                SqlDataAdapter adp = new SqlDataAdapter("SELECT TOP 10 ART.ID as 'ArticleId', ART.TITLE as 'ArticleTitle', ART.DATE as 'DateOfCreation', DOM.NAME as 'DomainName', USR.USERNAME as 'Username' FROM ARTICLES as ART INNER JOIN USERS as USR ON ART.AUTHOR_ID = USR.UserId INNER JOIN DOMAINS DOM ON ART.DOMAIN_ID = DOM.ID ORDER BY ART.DATE DESC;", con);
                adp.Fill(dt);
                ListView1.DataSource = dt;
                ListView1.DataBind();
            }
        }

        void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int primaryKey = Convert.ToInt32((String)e.CommandArgument);
            //Session["ArticleId"] = primaryKey;
            Response.Redirect("~/viewArticol.aspx?id=" + primaryKey);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Roles.CreateRole("Editor");
        }

        protected void FiltreazaDupaTitlu(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\mssqllocaldb;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            SqlCommand com = new SqlCommand("SELECT TOP 10 ART.ID as 'ArticleId', ART.TITLE as 'ArticleTitle', ART.DATE as 'DateOfCreation', DOM.NAME as 'DomainName', USR.USERNAME as 'Username' FROM ARTICLES as ART INNER JOIN USERS as USR ON ART.AUTHOR_ID = USR.UserId INNER JOIN DOMAINS DOM ON ART.DOMAIN_ID = DOM.ID WHERE lower(ART.TITLE) LIKE lower(@title) AND lower(USR.UserName) like lower(@username) ORDER BY ART.DATE DESC;", con);
            com.Parameters.AddWithValue("@title", "%" + TextBox1.Text + "%");
            com.Parameters.AddWithValue("@username", "%" + TextBox2.Text + "%");
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dt);
            ListView1.DataSource = dt;
            ListView1.DataBind();
        }
    }
}